Imports meCore
Imports System.Data.SqlClient

Public Class frmLapForecastHutang

    Private Sub frmLapForecastHutang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dTahun.Properties.DisplayFormat.FormatString = "yyyy"
        dTahun.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        dTahun.Properties.EditMask = "yyyy"
        dTahun.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearsGroupView
        dTahun.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView

        dTahun.EditValue = Now
    End Sub

    Private Sub btnAmbilData_Click(sender As Object, e As EventArgs) Handles btnAmbilData.Click
        Dim sql As String = _
            "select MingguKe,KdUnit,TotalOmzet,TotalBO, TotalOmzet+TotalBO as Anu, Prosentase,TotalQuota,QuotaAwal,TotalPengajuan," & _
            "LainLain,TotalTransfer,TotalBiayaTrans,TotalPembulatan,SisaQuota,SaldoAwal," & _
            "TglPengajuanAwal,TglPengajuanAkhir,TglOmzetAwal,TglOmzetAkhir from mstPerhitunganUnit " & _
            "where year(Tanggal)='" & Format(dTahun.EditValue, "yyyy") & "' order by Tanggal asc"
        dgPerhitunganUnit.FirstInit(sql, {0.8, 0.5, 1, 1, 1, 0.8, 1, 1, 1, _
                                    0.8, 1, 1, 1, 1, 1, _
                                          0.8, 0.8, 0.8, 0.8}, {"TotalOmzet", "TotalQuota", "TotalPengajuan", "TotalTransfer", "TotalBiayaTrans", "TotalPembulatan", "SisaQuota"}, , _
                                      {"KdUnit"})
        '{"TglPengajuanAwal", "TglPengajuanAkhir", "TglOmzetAwal", "TglOmzetAkhir"}
        dgPerhitunganUnit.RefreshData(False)
    End Sub

    Private Sub dgPerhitunganUnit_Grid_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles dgPerhitunganUnit.Grid_SelectionChanged
        Dim dateakhir As DateTime = dgPerhitunganUnit.GetRowCellValue(dgPerhitunganUnit.FocusedRowHandle, "TglOmzetAkhir")
        dateakhir = DateAdd(DateInterval.Day, 1, dateakhir)
        ''" & Format(dgPerhitunganUnit.GetRowCellValue(dgPerhitunganUnit.FocusedRowHandle, "TglOmzetAwal"), "yyyyMMdd")
        Dim queryOmzet As String = _
        "DECLARE @TglAwal AS VARCHAR(8) " & _
        "DECLARE @TglAkhir AS VARCHAR(8) " & _
        "DECLARE @SQLc varchar(5000) " & _
        "SET @Tglawal = '" & Format(dgPerhitunganUnit.GetRowCellValue(dgPerhitunganUnit.FocusedRowHandle, "TglOmzetAwal"), "yyyyMMdd") & "' " & _
        "SET @TglAkhir = '" & Format(dgPerhitunganUnit.GetRowCellValue(dgPerhitunganUnit.FocusedRowHandle, "TglOmzetAkhir"), "yyyyMMdd") & "'; " & _
        "With cteKasirCard " & _
          "AS ( SELECT LEFT(a.Faktur, 13) AS Faktur, a.Metode, " & _
           "             SUM(a.pay) AS Jumlah " & _
            "   FROM     trCSBayar a " & _
             "  INNER JOIN trCSHeader b on a.Faktur = b.Faktur " & _
        "WHERE b.FlagRetur = 0 " & _
        "      AND Tanggal between @TglAwal and @TglAkhir " & _
         "      GROUP BY LEFT(a.Faktur, 13), Metode, CASE WHEN a.Metode = 'KARTU' THEN a.KdCard " & _
          "          WHEN a.Metode = 'VOUCHER' then a.Keterangan1 + ' ' + a.Keterangan2      " & _
           "         WHEN a.Metode = 'TUNAI' then 'TUNAI'      " & _
            "                          ELSE a.KdCard " & _
        "End " & _
        "UNION " & _
         "      SELECT Faktur, 'TUNAI', TotalTunai  FROM trCSModal " & _
       " WHERE Len(faktur) = 13 " & _
        "      AND Tanggal between @TglAwal and @TglAkhir " & _
         "    )," & _
        "cteLKHCard " & _
         " AS ( SELECT   Faktur, 'KARTU' as Metode, Jumlah " & _
          "     FROM     trCSRekapDetailCard a " & _
           "    WHERE CONVERT([date],'20' + substring(faktur,(8),(6)),(0)) between @TglAwal and @TglAkhir " & _
        "UNION ALL " & _
         "      SELECT   Faktur, 'TUNAI', Setoran " & _
          "     FROM     trCSRekap a " & _
           "    WHERE CONVERT([date],'20' + substring(faktur,(8),(6)),(0)) between @TglAwal and @TglAkhir " & _
            " ), cteFinal " & _
             "as (" & _
        "SELECT  a.Faktur, a.Metode, c.Kasir, ISNULL(a.Jumlah, 0) AS JumlahIRIS," & _
         "   ISNULL(b.Jumlah, 0) AS JumlahLKH " & _
        "FROM    cteKasirCard a " & _
         "   LEFT JOIN cteLKHCard b ON a.Faktur = b.Faktur AND a.Metode = b.Metode " & _
        "LEFT JOIN trCSModal c ON a.Faktur = c.Faktur " & _
        "UNION ALL " & _
        "SELECT  b.Faktur, b.Metode, c.Kasir, ISNULL(a.Jumlah, 0) AS JumlahIRIS," & _
         "   ISNULL(b.Jumlah, 0) AS JumlahLKH " & _
        "FROM    cteLKHCard b " & _
        "    LEFT JOIN cteKasirCard a ON a.Faktur = b.Faktur AND a.Metode = b.Metode " & _
        "LEFT JOIN trCSModal c ON b.Faktur = c.Faktur " & _
        ")," & _
        "ctefinallagi as(" & _
        " select DISTINCT 'KASIR' as Jenis, a.Faktur, a.Kasir, a.JumlahIRIS " & _
        "From cteFinal a " & _
        ")," & _
        "ctebo as (" & _
        "select 'BO' as Jenis,Faktur, 'PENJUALAN BO' as Kasir ,isnull(total,0) + ISNULL(deposit,0) as Omzet from trLPtgHeader where TglLunas between @TglAwal and @TglAkhir " & _
        ") " & _
        "select Jenis,Faktur,Kasir,sum(JumlahIRIS) as Omzet from ctefinallagi " & _
        "group by Jenis,Faktur,Kasir " & _
        "union all select * from ctebo"

        dgOmzet.FirstInit(queryOmzet, {0.5, 1, 0.8, _
                                     1}, {"Omzet"})
        dgOmzet.RefreshData(False)

        Dim queryPengajuan As String = _
            "select KdUnit,TglPengajuan,NoBTT,KdSupplier,NamaSupplier,case when Valid=0 then 0 else Valid+Promo end as Pengajuan,Transfer-Promo as Transfer,BiayaTrans,Pembulatan,KdBank from trPengajuanBayarHd " & _
            "where TglPengajuan >= '" & Format(dgPerhitunganUnit.GetRowCellValue(dgPerhitunganUnit.FocusedRowHandle, "TglPengajuanAwal"), "yyyyMMdd") & "' and TglPengajuan <= '" & Format(dgPerhitunganUnit.GetRowCellValue(dgPerhitunganUnit.FocusedRowHandle, "TglPengajuanAkhir"), "yyyyMMdd") & "' "
        dgPengajuan.FirstInit(queryPengajuan, {0.5, 0.8, 1, 0.8, 1, 1, 1, 1, 1, 0.5}, {"Pengajuan", "Transfer", "BiayaTrans", "Pembulatan"}, , {"KdUnit"})
        dgPengajuan.RefreshData(False)
    End Sub
End Class