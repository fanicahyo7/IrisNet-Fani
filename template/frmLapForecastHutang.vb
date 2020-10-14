Imports meCore

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
            "select MingguKe,KdUnit,TotalOmzet,TotalBO,Prosentase,TotalQuota,QuotaAwal,TotalPengajuan," & _
            "LainLain,TotalTransfer,TotalBiayaTrans,TotalPembulatan,SisaQuota,SaldoAwal," & _
            "TglPengajuanAwal,TglPengajuanAkhir,TglOmzetAwal,TglOmzetAkhir from mstPerhitunganUnit where year(Tanggal)='" & Format(dTahun.EditValue, "yyyy") & "'"
        dgPerhitunganUnit.FirstInit(sql, {0.8, 0.5, 1, 1, 0.8, 1, 1, 1, _
                                    0.8, 1, 1, 1, 1, 1, _
                                          0.8, 0.8, 0.8, 0.8}, {"TotalOmzet", "TotalQuota", "TotalPengajuan", "TotalTransfer", "TotalBiayaTrans", "TotalPembulatan", "SisaQuota"}, , _
                                      {"KdUnit"})
        '{"TglPengajuanAwal", "TglPengajuanAkhir", "TglOmzetAwal", "TglOmzetAkhir"}
        dgPerhitunganUnit.RefreshData(False)
    End Sub

    Private Sub dgPerhitunganUnit_Grid_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles dgPerhitunganUnit.Grid_SelectionChanged
        Dim queryOmzet As String = _
            "select Jenis,faktur as Faktur,Tanggal," & _
            "Keterangan= case when Jenis='KASIR' then " & _
            "(select UserName from UserLogin where Initial=SUBSTRING(Faktur,4,3)) else 'PENJUALAN BO' end," & _ 
            "sum(Jumlah) as Omzet from tblGetPenjualanNett('" & Format(dgPerhitunganUnit.GetRowCellValue(dgPerhitunganUnit.FocusedRowHandle, "TglOmzetAwal"), "yyyyMMdd") & "','" & Format(dgPerhitunganUnit.GetRowCellValue(dgPerhitunganUnit.FocusedRowHandle, "TglOmzetAkhir"), "yyyyMMdd") & "') group by Jenis,faktur,Tanggal"
        dgOmzet.FirstInit(queryOmzet, {0.5, 1, 0.8, _
                                     1, 1}, {"Omzet"})
        dgOmzet.RefreshData(False)

        Dim queryPengajuan As String = _
            "select KdUnit,TglPengajuan,NoBTT,KdSupplier,NamaSupplier,Pengajuan,Transfer,BiayaTrans,Pembulatan from trPengajuanBayarHd " & _
            "where TglPengajuan >= '" & Format(dgPerhitunganUnit.GetRowCellValue(dgPerhitunganUnit.FocusedRowHandle, "TglPengajuanAwal"), "yyyyMMdd") & "' and TglPengajuan < '" & Format(dgPerhitunganUnit.GetRowCellValue(dgPerhitunganUnit.FocusedRowHandle, "TglPengajuanAkhir"), "yyyyMMdd") & "'"
        dgPengajuan.FirstInit(queryPengajuan, {0.5, 0.8, 1, 0.8, 1, 1, 1, 1, 1}, {"Pengajuan", "Transfer", "BiayaTrans", "Pembulatan"}, , {"KdUnit"})
        dgPengajuan.RefreshData(False)
    End Sub

    Private Sub dgPerhitunganUnit_Load(sender As Object, e As EventArgs) Handles dgPerhitunganUnit.Load

    End Sub
End Class