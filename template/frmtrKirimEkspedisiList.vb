Imports meCore
Imports System.Data.SqlClient
Public Class frmtrKirimEkspedisiList

    Private Sub frmtrKirimEkspedisiList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'initForm(Me, EnfrmSizeNotMax.efsnm2Medium, DevExpress.XtraLayout.MoveFocusDirection.DownThenAcross)
        btnUpdateResi.Enabled = False
        btnCetakUlang.Enabled = False
        dTanggalAkhir.EditValue = Format(DateAdd(DateInterval.Day, 0, Now), "dd/MM/yyyy")
        dTanggalAwal.EditValue = Format(DateAdd(DateInterval.Day, -7, dTanggalAkhir.EditValue), "dd/MM/yyyy")

        dTanggalAkhir.EditValue = Now
        dTanggalAwal.EditValue = DateAdd(DateInterval.Day, -7, Now)
        koneksi()
    End Sub

    Private Sub btnRefreshData_Click(sender As Object, e As EventArgs) Handles btnRefreshData.Click
        Dim SQL As String = "select Faktur,Jenis,TglKirim,CaraKirim,PIC,KodeEkspedisi,NoNotaEkspedisi,NoResi," & _
            "NoTracking,TglNotaEkspedisi,DikirimDari,JenisBarang,JumlahBarang,BeratBarang,TotalBiaya,UserEntry," & _
            "DateTimeEntry,UserValid,DateTimeValid from trKirimEkspedisi where TglKirim between '" & Format(CDate(dTanggalAwal.EditValue), "yyyy/MM/dd") & "' and '" & Format(CDate(dTanggalAkhir.EditValue), "yyyy/MM/dd") & "'"
        dgkirim.FirstInit(SQL, {1.5, 1.8, 1, 1.5, 1, 1, 1.1, 1.3, _
                                1, 1.5, 1.6, 1, 1, 1, 1, 1, _
                                1, 0.5, 0.5}, , , {"UserValid", "DateTimeValid"}, , , False)
        dgkirim.RefreshData(False)
    End Sub

    Private Sub btnKirimEkspedisi_Click(sender As Object, e As EventArgs) Handles btnKirimEkspedisi.Click
        Using xx As New frmAmbilFaktur
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub dgkirim_Grid_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles dgkirim.Grid_CustomDrawCell
        If Not dgkirim.GetRowCellValue(e.RowHandle, "UserValid").ToString = "" Then
            e.Appearance.ForeColor = Color.Green
        End If
    End Sub

    Private Sub dgkirim_Grid_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles dgkirim.Grid_SelectionChanged
        If IsDBNull(dgkirim.GetRowCellValue(dgkirim.FocusedRowHandle, "UserValid")) Then
            btnUpdateResi.Enabled = True
            btnCetakUlang.Enabled = True
        Else
            btnUpdateResi.Enabled = False
            btnCetakUlang.Enabled = False
        End If
    End Sub

    Private Sub dgkirim_Load(sender As Object, e As EventArgs) Handles dgkirim.Load

    End Sub

    Private Sub btnUpdateResi_Click(sender As Object, e As EventArgs) Handles btnUpdateResi.Click
        If dgkirim.GetRowCount_Gridview > 0 Then
            Dim pKode As String = dgkirim.GetRowCellValue(dgkirim.FocusedRowHandle, "Faktur")
            Dim jns As Integer = 0
            Dim nopengajuan As String = ""
            Dim tgl As DateTime

            If dgkirim.GetRowCellValue(dgkirim.FocusedRowHandle, "Jenis") = "SUPPLIER" Then
                jns = 0 
            ElseIf dgkirim.GetRowCellValue(dgkirim.FocusedRowHandle, "Jenis") = "CUSTOMER" Then
                jns = 1
            ElseIf dgkirim.GetRowCellValue(dgkirim.FocusedRowHandle, "Jenis") = "PENGAJUAN BAYAR SUPPLIER" Then
                jns = 2
                'nopengajuan = dgkirim.GetRowCellValue(dgkirim.FocusedRowHandle, "NoPengajuan")
                'cmd = New SqlCommand("select distinct TglPengajuan from trPengajuanBayarHd where NoPengajuan='" & nopengajuan & "'", kon)
                'rd = cmd.ExecuteReader
                'rd.Read()
                'If rd.HasRows Then
                ' tgl = rd!TglPengajuan
                'End If
                ' rd.Close()
            End If

            Using xx As New frmtrKirimEkspedisi
                xx.Tag = pKode
                xx.nopengajuan = nopengajuan
                xx.jenis = jns
                If jns = 2 Then
                    xx.date1 = tgl
                    xx.date2 = tgl
                End If
                xx.ShowDialog(Me)
            End Using
            btnRefreshData.PerformClick()
        End If
    End Sub

    Private Sub btnCetakUlang_Click(sender As Object, e As EventArgs) Handles btnCetakUlang.Click
        Dim jj As String = ""
        If dgkirim.GetRowCellValue(dgkirim.FocusedRowHandle, "Jenis") = "SUPPLIER" Then
            jj = "mstSupplier"
        ElseIf dgkirim.GetRowCellValue(dgkirim.FocusedRowHandle, "Jenis") = "CUSTOMER" Then
            jj = "mstCustomer"
        End If

        If Not dgkirim.GetRowCellValue(dgkirim.FocusedRowHandle, "Jenis") = "PENGAJUAN BAYAR SUPPLIER" Then
            Dim pQueRpt As String = _
                "select b.*, a.Faktur,a.Faktur,a.FakturReferensi,a.Tujuan,(select Nama from " & jj & " where Kode=a.Tujuan) as NamaTujuan,(select Alamat from " & jj & " where Kode=a.Tujuan) as AlamatTujuan,a.Total," & _
                "(select Nama from mstEkspedisi where Kode = b.KodeEkspedisi) as NamaEkspedisi from trKirimEkspedisiDetail a " & _
                "inner join trKirimEkspedisi b on a.Faktur = b.Faktur " & _
                "where b.faktur = '" & dgkirim.GetRowCellValue(dgkirim.FocusedRowHandle, "Faktur") & "'"
            ShowReport(pQueRpt, "rptSuratJalanEkspedisi", {compNama, compAlamat, compNoTlp, compNPWP})
        Else

            Dim pQueryRpt As String = _
                                    "SELECT a.FakturPCRKonsPby as NoPengajuan, a.Total as JumlahPengajuan,c.*,(select top 1 TglPengajuan from trPengajuanBayarHd where NoPengajuan= a.FakturPCRKonsPby) as TglPengajuan," & _
                                    "(select Nama from mstEkspedisi where Kode = c.KodeEkspedisi) as NamaEkspedisi " & _
                                    "FROM trKirimEkspedisiDetail a " & _
                                    "left join trKirimEkspedisi c on a.Faktur = c.Faktur " & _
                                    "where a.Faktur='" & dgkirim.GetRowCellValue(dgkirim.FocusedRowHandle, "Faktur") & "'"
            ShowReport(pQueryRpt, "rptSuratJalanEkspedisiPengajuanBayar", {compNama, compAlamat, compNoTlp, compNPWP})
        End If
    End Sub
End Class