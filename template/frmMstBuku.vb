Imports meCore
Imports System.Data.SqlClient
Public Class frmMstBuku

    Private Sub frmMstBuku_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        cPenyusun1.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cPenyusun1.AutoCompleteSource = AutoCompleteSource.ListItems
        cPenyusun2.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cPenyusun2.AutoCompleteSource = AutoCompleteSource.ListItems
        cPenyusun3.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cPenyusun3.AutoCompleteSource = AutoCompleteSource.ListItems

        rJudulIndo.Checked = True
        tKodeBuku.Text = "B"

        Dim qPenerbit As String = "select Kode,Nama,Alamat from mstPenerbit order by nama"
        cPenerbit.FirstInit(PubConnStr, qPenerbit, {tNamaPenerbit}, True)

        'Dim qPenyusun As String = "select Distinct Keterangan from mstPenyusun order by keterangan"
        'da = New SqlDataAdapter(qPenyusun, kon)
        'Dim dtpenyusun As New DataTable
        'da.Fill(dtpenyusun)

        'cPenyusun1.DataSource = dtpenyusun
        'cPenyusun1.DisplayMember = "Keterangan"
        'cPenyusun1.ValueMember = "Keterangan"
        'cPenyusun2.DataSource = dtpenyusun
        'cPenyusun2.DisplayMember = "Keterangan"
        'cPenyusun2.ValueMember = "Keterangan"
        'cPenyusun3.DataSource = dtpenyusun
        'cPenyusun3.DisplayMember = "Keterangan"
        'cPenyusun3.ValueMember = "Keterangan"
        'cPenyusun1.Text = ""
        'cPenyusun2.Text = ""
        'cPenyusun3.Text = ""
    End Sub

    Sub judul()
        If rJudulIndo.Checked = True Then
            If tJudulIndo.Text = "" Then
                If tJudulEng.Text = "" Then
                    tJudul.Text = ""
                Else
                    tJudul.Text = tJudulEng.Text
                End If
            Else
                If tJudulEng.Text = "" Then
                    tJudul.Text = tJudulIndo.Text
                Else
                    tJudul.Text = tJudulIndo.Text & " (" & tJudulEng.Text & ")"
                End If
            End If
        ElseIf rJudulEng.Checked = True Then
            If tJudulEng.Text = "" Then
                If tJudulIndo.Text = "" Then
                    tJudul.Text = ""
                Else
                    tJudul.Text = tJudulIndo.Text
                End If
            Else
                If tJudulIndo.Text = "" Then
                    tJudul.Text = tJudulEng.Text
                Else
                    tJudul.Text = tJudulEng.Text & " (" & tJudulIndo.Text & ")"
                End If
            End If
        End If
    End Sub

    Private Sub rJudulEng_CheckedChanged(sender As Object, e As EventArgs) Handles rJudulEng.CheckedChanged
        judul()
    End Sub

    Private Sub rJudulIndo_CheckedChanged(sender As Object, e As EventArgs) Handles rJudulIndo.CheckedChanged
        judul()
    End Sub

    Private Sub tJudulIndo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tJudulIndo.KeyPress
        If (Asc(e.KeyChar) = 32) Then
            history()
        End If
    End Sub
    Sub history()
        Dim query As String = _
                "select Judul, Jilid, Edisi, NamaPenerbit, Penyusun, Kode from vwBuku where Status = 1 and Left(kode,1) = '" & Strings.Left(tKodeBuku.Text, 1) & "'  and  Judul like '%" & tJudulIndo.Text & "%'  order by judul"
        dgHistory.FirstInit(query, {1, 0.5, 0.5, 1, 1, 1})
        dgHistory.RefreshData(False)
    End Sub
    Private Sub tJudulIndo_Validated(sender As Object, e As EventArgs) Handles tJudulIndo.Validated
        judul()
        If Not tJudulIndo.Text = "" Then
            history()
        End If
    End Sub

    Private Sub tJudulEng_Enter(sender As Object, e As EventArgs) Handles tJudulEng.Enter

    End Sub

    Private Sub tJudulEng_Validated(sender As Object, e As EventArgs) Handles tJudulEng.Validated
        judul()
    End Sub
End Class