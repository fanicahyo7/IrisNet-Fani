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
        Dim queryOmzet As String = _
        "DECLARE @TglAwal AS VARCHAR(8) " & _
        "DECLARE @TglAkhir AS VARCHAR(8) " & _
        "DECLARE @SQLc varchar(5000) " & _
        "SET @Tglawal = '" & Format(dgPerhitunganUnit.GetRowCellValue(dgPerhitunganUnit.FocusedRowHandle, "TglOmzetAwal"), "yyyyMMdd") & "' " & _
        "SET @TglAkhir = '" & Format(dgPerhitunganUnit.GetRowCellValue(dgPerhitunganUnit.FocusedRowHandle, "TglOmzetAkhir"), "yyyyMMdd") & "'; " & _
        "With cteKasirCard " & _
         "AS ( SELECT LEFT(a.Faktur, 13) AS Faktur, a.Metode, " & _
        "KdCard = CASE WHEN a.Metode = 'KARTU' THEN a.KdCard " & _
        "WHEN a.Metode = 'VOUCHER' then a.Keterangan1 + ' ' + a.Keterangan2 " & _
        "WHEN a.Metode = 'TUNAI' then 'TUNAI' ELSE a.KdCard END, SUM(a.pay) AS Jumlah, Tanggal " & _
        "FROM trCSBayar a INNER JOIN trCSHeader b on a.Faktur = b.Faktur " & _
        "WHERE b.FlagRetur = 0 AND Tanggal between @TglAwal and @TglAkhir " & _
        "GROUP BY LEFT(a.Faktur, 13), Metode, " & _
        "CASE WHEN a.Metode = 'KARTU' THEN a.KdCard " & _
        "WHEN a.Metode = 'VOUCHER' then a.Keterangan1 + ' ' + a.Keterangan2 " & _
        "WHEN a.Metode = 'TUNAI' then 'TUNAI' " & _
        "ELSE a.KdCard END,Tanggal " & _
        "UNION " & _
         "SELECT Faktur, 'TUNAI','TUNAI', TotalTunai,Tanggal  FROM trCSModal " & _
        "WHERE Len(faktur) = 13 AND Tanggal between @TglAwal and @TglAkhir " & _
         ")," & _
        "cteLKHCard AS (" & _
        "SELECT LEFT(a.Faktur, 13) as Faktur, 'KARTU' as Metode, KodeCard AS KdCard, Jumlah, b.Tanggal " & _
          "FROM trCSRekapDetailCard a " & _
        "left join trCSHeader b on a.Faktur = LEFT(b.Faktur, 13) " & _
        "WHERE CONVERT([date],'20' + substring(a.faktur,(8),(6)),(0)) between @TglAwal and @TglAkhir " & _
        "UNION ALL " & _
         "SELECT Faktur, 'TUNAI', 'TUNAI' AS KdCard, Setoran, Tanggal FROM trCSRekap a " & _
         "WHERE CONVERT([date],'20' + substring(faktur,(8),(6)),(0)) between @TglAwal and @TglAkhir" & _
        "), " & _
        "cteFinal as (" & _
        "SELECT  a.Faktur, a.Metode, c.Kasir, a.KdCard, ISNULL(a.Jumlah, 0) AS JumlahIRIS," & _
         "ISNULL(b.Jumlah, 0) AS JumlahLKH, a.Tanggal FROM cteKasirCard a " & _
         "LEFT JOIN cteLKHCard b ON a.KdCard = b.KdCard AND a.Faktur = b.Faktur AND a.Metode = b.Metode " & _
        "LEFT JOIN trCSModal c ON a.Faktur = c.Faktur " & _
        "UNION ALL " & _
        "SELECT  b.Faktur, b.Metode, c.Kasir, b.KdCard, ISNULL(a.Jumlah, 0) AS JumlahIRIS," & _
        "ISNULL(b.Jumlah, 0) AS JumlahLKH,a.Tanggal FROM cteLKHCard b " & _
        "LEFT JOIN cteKasirCard a ON a.KdCard = b.KdCard AND a.Faktur = b.Faktur AND a.Metode = b.Metode " & _
        "LEFT JOIN trCSModal c ON b.Faktur = c.Faktur " & _
        ")," & _
        "cteomzet as( " & _
        "select DISTINCT a.Faktur, a.Kasir, a.KdCard, a.JumlahIRIS, " & _
        "Tanggal From cteFinal a) " & _
        "select 'KASIR' as Jenis, Faktur,Tanggal,Kasir as Keterangan,sum(JumlahIRIS) as Omzet from cteomzet " & _
        "where Tanggal is not null group by Faktur,Kasir,Tanggal"

        'Dim queryOmzet As String = _
        '    "DECLARE @TglAwal AS VARCHAR(8) " & _
        '    "DECLARE @TglAkhir AS VARCHAR(8) " & _
        '    "DECLARE @SQLc varchar(5000) " & _
        '    "SET @Tglawal = '" & Format(dgPerhitunganUnit.GetRowCellValue(dgPerhitunganUnit.FocusedRowHandle, "TglOmzetAwal"), "yyyyMMdd") & "' " & _
        '    "SET @TglAkhir = '" & Format(dgPerhitunganUnit.GetRowCellValue(dgPerhitunganUnit.FocusedRowHandle, "TglOmzetAkhir"), "yyyyMMdd") & "'; " & _
        '    "With cteKasirCard " & _
        '      "AS ( SELECT LEFT(a.Faktur, 13) AS Faktur, a.Metode, " & _
        '       "KdCard = CASE WHEN a.Metode = 'KARTU' THEN a.KdCard " & _
        '        "WHEN a.Metode = 'VOUCHER' then a.Keterangan1 + ' ' + a.Keterangan2 " & _
        '        "WHEN a.Metode = 'TUNAI' then 'TUNAI' ELSE a.KdCard END, SUM(a.pay) AS Jumlah, Tanggal " & _
        '        "FROM trCSBayar a INNER JOIN trCSHeader b on a.Faktur = b.Faktur " & _
        '        "WHERE b.FlagRetur = 0 AND Tanggal between @TglAwal and @TglAkhir " & _
        '        "GROUP BY LEFT(a.Faktur, 13), Metode, " & _
        '        "CASE WHEN a.Metode = 'KARTU' THEN a.KdCard " & _
        '        "WHEN a.Metode = 'VOUCHER' then a.Keterangan1 + ' ' + a.Keterangan2 " & _
        '        "WHEN a.Metode = 'TUNAI' then 'TUNAI' " & _
        '        "ELSE a.KdCard END,Tanggal " & _
        '    "UNION " & _
        '     "SELECT Faktur, 'TUNAI','TUNAI', TotalTunai,Tanggal  FROM trCSModal " & _
        '    "WHERE Len(faktur) = 13 AND Tanggal between @TglAwal and @TglAkhir " & _
        '     ")," & _
        '    "cteLKHCard AS (" & _
        '    "SELECT LEFT(a.Faktur, 13) as Faktur, 'KARTU' as Metode, KodeCard AS KdCard, Jumlah, b.Tanggal " & _
        '      "FROM trCSRekapDetailCard a " & _
        '    "left join trCSHeader b on a.Faktur = LEFT(b.Faktur, 13) " & _
        '    "WHERE CONVERT([date],'20' + substring(a.faktur,(8),(6)),(0)) between @TglAwal and @TglAkhir " & _
        '    "UNION ALL " & _
        '     "SELECT Faktur, 'TUNAI', 'TUNAI' AS KdCard, Setoran, Tanggal FROM trCSRekap a " & _
        '     "WHERE CONVERT([date],'20' + substring(faktur,(8),(6)),(0)) between @TglAwal and @TglAkhir" & _
        '    "), " & _
        '    "cteFinal as (" & _
        '    "SELECT  a.Faktur, a.Metode, c.Kasir, a.KdCard, ISNULL(a.Jumlah, 0) AS JumlahIRIS," & _
        '     "ISNULL(b.Jumlah, 0) AS JumlahLKH, a.Tanggal FROM cteKasirCard a " & _
        '     "LEFT JOIN cteLKHCard b ON a.KdCard = b.KdCard AND a.Faktur = b.Faktur AND a.Metode = b.Metode " & _
        '    "LEFT JOIN trCSModal c ON a.Faktur = c.Faktur " & _
        '    "UNION ALL " & _
        '    "SELECT  b.Faktur, b.Metode, c.Kasir, b.KdCard, ISNULL(a.Jumlah, 0) AS JumlahIRIS," & _
        '    "ISNULL(b.Jumlah, 0) AS JumlahLKH,a.Tanggal FROM cteLKHCard b " & _
        '    "LEFT JOIN cteKasirCard a ON a.KdCard = b.KdCard AND a.Faktur = b.Faktur AND a.Metode = b.Metode " & _
        '    "LEFT JOIN trCSModal c ON b.Faktur = c.Faktur " & _
        '    ")," & _
        '    "cteomzet as( " & _
        '    "select DISTINCT a.Faktur, a.Kasir, a.KdCard, a.JumlahIRIS, " & _
        '    "Tanggal From cteFinal a), " & _
        '    "ctebo as(" & _
        '    "select Faktur,Tanggal,'PENJUALAN BO' as Keterangan, ISNULL(Total,0) + ISNULL(Deposit,0) as Omzet from trLPtgHeader " & _
        '    "where Tanggal between @TglAwal and @TglAkhir) " & _
        '    "select 'KASIR' as Jenis, Faktur,Tanggal,Kasir as Keterangan,sum(JumlahIRIS) as Omzet from cteomzet " & _
        '    "where Tanggal is not null group by Faktur,Kasir,Tanggal " & _
        '    "union all " & _
        '    "select 'BO' as Jenis,Faktur,Tanggal,Keterangan,Omzet from ctebo"

        dgOmzet.FirstInit(queryOmzet, {0.5, 1, 0.8, 0.8, _
                                     1}, {"Omzet"})
        dgOmzet.RefreshData(False)

        Dim queryPengajuan As String = _
            "select KdUnit,TglPengajuan,NoBTT,KdSupplier,NamaSupplier,case when Valid=0 then 0 else Valid+Promo end as Pengajuan,Transfer-Promo as Transfer,BiayaTrans,Pembulatan from trPengajuanBayarHd " & _
            "where TglPengajuan >= '" & Format(dgPerhitunganUnit.GetRowCellValue(dgPerhitunganUnit.FocusedRowHandle, "TglPengajuanAwal"), "yyyyMMdd") & "' and TglPengajuan <= '" & Format(dgPerhitunganUnit.GetRowCellValue(dgPerhitunganUnit.FocusedRowHandle, "TglPengajuanAkhir"), "yyyyMMdd") & "' "
        dgPengajuan.FirstInit(queryPengajuan, {0.5, 0.8, 1, 0.8, 1, 1, 1, 1, 1}, {"Pengajuan", "Transfer", "BiayaTrans", "Pembulatan"}, , {"KdUnit"})
        dgPengajuan.RefreshData(False)
    End Sub
End Class