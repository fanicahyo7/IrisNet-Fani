Imports meCore

Public Class frmLapForecastHutang

    Private Sub frmLapForecastHutang_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnAmbilData_Click(sender As Object, e As EventArgs) Handles btnAmbilData.Click
        Dim sql As String = _
            "select MingguKe,KdUnit,TotalOmzet,TotalBO,Prosentase,TotalQuota,QuotaAwal,TotalPengajuan," & _
            "LainLain,TotalTransfer,TotalBiayaTrans,TotalPembulatan,SisaQuota,SaldoAwal," & _
            "TglPengajuanAwal,TglPengajuanAKhir,TglOmzetAwal,TglOmzetAkhir from mstPerhitunganUnit"
        dgPerhitunganUnit.FirstInit(sql, {0.8, 0.5, 1, 1, 0.8, 1, 1, 1, _
                                    0.8, 1, 1, 1, 1, 1, _
                                    0.8, 0.8, 0.8, 0.8}, , , {"TglPengajuanAwal", "TglPengajuanAKhir", "TglOmzetAwal", "TglOmzetAkhir"})
        dgPerhitunganUnit.RefreshData(False)


    End Sub

    Private Sub dgPerhitunganUnit_Load(sender As Object, e As EventArgs) Handles dgPerhitunganUnit.Load
        Dim queryOmzet As String = _
            "select Jenis,faktur as Faktur,Tanggal," & _
            "Keterangan= case when Jenis='KASIR' then " & _
            "(select UserName from UserLogin where Initial=SUBSTRING(Faktur,4,3)) else 'PENJUALAN BO' end" & _
            ",sum(Jumlah) from tblGetPenjualanNett('tglomzetawal','tglomzetakhir') group by faktur"


        Dim queryPengajuan As String = _
            "select KdUnit,TglPengajuan,NoBTT,KdSupplier,NamaSupplier,Pengajuan,Transfer,BiayaTrans,Pembulatan from trPengajuanBayarHd " & _
            "where TglPengajuan between 'awal' and 'akhir'"
    End Sub
End Class