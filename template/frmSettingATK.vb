Imports meCore
Imports System.Data.SqlClient
Public Class frmSettingATK

    Private Sub frmSettingATK_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        tKode.Properties.CharacterCasing = CharacterCasing.Upper
        tKeterangan.Properties.CharacterCasing = CharacterCasing.Upper
        Dim sql As String = "select Kode,Keterangan from mstJenis order by Kode"
        dgJenis.FirstInit(sql, {0.5, 1})
        dgJenis.RefreshData()
    End Sub

    Private Sub XtraTabControl1_Click(sender As Object, e As EventArgs) Handles XtraTabControl.Click
        refreshgrid()
    End Sub
    Sub refreshgrid()
        Dim sql As String = ""

        Select Case (XtraTabControl.SelectedTabPageIndex.ToString)
            Case 0
                ClearValue(Me)
                sql = "select Kode,Keterangan from mstJenis order by Kode"
                dgJenis.FirstInit(sql, {0.5, 1})
                dgJenis.RefreshData()
            Case 1
                ClearValue(Me)
                sql = "select Kode,Keterangan from mstMerek order by Kode"
                dgMerek.FirstInit(sql, {0.5, 1})
                dgMerek.RefreshData()
            Case 2
                ClearValue(Me)
                sql = "select Kode,Keterangan from mstTipe order by Kode"
                dgTipe.FirstInit(sql, {0.5, 1})
                dgTipe.RefreshData()
            Case 3
                ClearValue(Me)
                sql = "select Kode,Keterangan from mstBahan order by Kode"
                dgBahan.FirstInit(sql, {0.5, 1})
                dgBahan.RefreshData()
            Case 4
                ClearValue(Me)
                sql = "select Kode,Keterangan from mstUkuranAtk order by Kode"
                dgUkuran.FirstInit(sql, {0.5, 1})
                dgUkuran.RefreshData()
            Case 5
                ClearValue(Me)
                sql = "select Kode,Keterangan from mstWarna order by Kode"
                dgWarna.FirstInit(sql, {0.5, 1})
                dgWarna.RefreshData()
            Case Else
                Exit Sub
        End Select
    End Sub
    Private Sub dgSerial_Grid_DoubleClick(sender As Object, e As EventArgs) Handles dgJenis.Grid_DoubleClick
        tKode.Text = dgJenis.GetRowCellValue(dgJenis.FocusedRowHandle, "Kode")
        tKeterangan.Text = dgJenis.GetRowCellValue(dgJenis.FocusedRowHandle, "Keterangan")
    End Sub

    Private Sub dgCover_Grid_DoubleClick(sender As Object, e As EventArgs) Handles dgMerek.Grid_DoubleClick
        tKode.Text = dgMerek.GetRowCellValue(dgMerek.FocusedRowHandle, "Kode")
        tKeterangan.Text = dgMerek.GetRowCellValue(dgMerek.FocusedRowHandle, "Keterangan")
    End Sub


    Private Sub dgJenisKertas_Grid_DoubleClick(sender As Object, e As EventArgs) Handles dgTipe.Grid_DoubleClick
        tKode.Text = dgTipe.GetRowCellValue(dgTipe.FocusedRowHandle, "Kode")
        tKeterangan.Text = dgTipe.GetRowCellValue(dgTipe.FocusedRowHandle, "Keterangan")
    End Sub

    Private Sub dgUkuran_Grid_DoubleClick(sender As Object, e As EventArgs) Handles dgBahan.Grid_DoubleClick
        tKode.Text = dgBahan.GetRowCellValue(dgBahan.FocusedRowHandle, "Kode")
        tKeterangan.Text = dgBahan.GetRowCellValue(dgBahan.FocusedRowHandle, "Keterangan")
    End Sub

    Private Sub btnBaru_Click(sender As Object, e As EventArgs) Handles btnBaru.Click
        ClearValue(Me)
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If Trim(tKode.Text).Length > 0 Then
            Dim jumlah As Integer
            Dim tbl As String = ""

            Select Case (XtraTabControl.SelectedTabPageIndex.ToString)
                Case 0
                    Dim dKode() As DataRow = dgJenis.DataSource.Select("Kode = '" & Trim(tKode.Text) & "' ")
                    jumlah = dKode.Length
                    tbl = "mstJenis"
                Case 1
                    Dim dKode() As DataRow = dgMerek.DataSource.Select("Kode = '" & Trim(tKode.Text) & "' ")
                    jumlah = dKode.Length
                    tbl = "mstMerek"
                Case 2
                    Dim dKode() As DataRow = dgTipe.DataSource.Select("Kode = '" & Trim(tKode.Text) & "' ")
                    jumlah = dKode.Length
                    tbl = "mstTipe"
                Case 3
                    Dim dKode() As DataRow = dgBahan.DataSource.Select("Kode = '" & Trim(tKode.Text) & "' ")
                    jumlah = dKode.Length
                    tbl = "mstBahan"
                Case 4
                    Dim dKode() As DataRow = dgUkuran.DataSource.Select("Kode = '" & Trim(tKode.Text) & "' ")
                    jumlah = dKode.Length
                    tbl = "mstUkuranAtk"
                Case 5
                    Dim dKode() As DataRow = dgWarna.DataSource.Select("Kode = '" & Trim(tKode.Text) & "' ")
                    jumlah = dKode.Length
                    tbl = "mstWarna"
            End Select

            Dim question As String
            question = MsgBox("Simpan Data?" & vbCrLf & "ID :" & Trim(tKode.Text) & "", vbYesNo, "Konfirmasi")
            If question = vbYes Then
                If jumlah > 0 Then
                    prosesdata("Update", tbl)
                Else
                    prosesdata("Tambah", tbl)
                End If
                refreshgrid()
                ClearValue(Me)
            End If
        Else
            Pesan({"Isi Kode"}, "Peringatan")
        End If
    End Sub

    Sub prosesdata(ByRef prs As String, ByRef tbl As String)
        If CheckBeforeSave({tKode, tKeterangan}) = True Then
            Try
                Dim query As String = ""
                If prs = "Tambah" Then
                    query = "insert into " & tbl & " (Kode,Keterangan,UserEntry,DateTimeEntry)values('" & Trim(tKode.Text) & "','" & Trim(tKeterangan.Text) & "','" & pubUserEntry & "','" & DTOC(Now, "/", True) & "')"
                ElseIf prs = "Update" Then
                    query = "update " & tbl & " set Keterangan='" & Trim(tKeterangan.Text) & "',UserUpdate='" & pubUserEntry & "',DateTimeUpdate='" & DTOC(Now, "/", True) & "' where Kode='" & Trim(tKode.Text) & "'"
                End If
                cmd = New SqlCommand(query, kon)
                cmd.ExecuteNonQuery()
                Pesan({"Data Berhasil Disimpan"}, "Informasi")
            Catch ex As Exception
                Pesan({"GAGAL SIMPAN DATA", "", "Err : " & ex.Message.ToString})
            End Try
        End If
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        Dim question As String = ""
        Dim query As String = ""

        Select Case (XtraTabControl.SelectedTabPageIndex.ToString)
            Case 0
                If dgJenis.GetRowCellValue(dgJenis.FocusedRowHandle, "Kode") = Nothing Then
                    Exit Sub
                Else
                    question = MsgBox("Hapus " & dgJenis.GetRowCellValue(dgJenis.FocusedRowHandle, "Kode") & " ?", vbYesNo, "Konfirmasi")
                    query = "delete from MstJenis where Kode='" & dgJenis.GetRowCellValue(dgJenis.FocusedRowHandle, "Kode") & "'"
                End If
            Case 1
                If dgMerek.GetRowCellValue(dgMerek.FocusedRowHandle, "Kode") = Nothing Then
                    Exit Sub
                Else
                    question = MsgBox("Hapus " & dgMerek.GetRowCellValue(dgMerek.FocusedRowHandle, "Kode") & " ?", vbYesNo, "Konfirmasi")
                    query = "delete from MstMerek where Kode='" & dgMerek.GetRowCellValue(dgMerek.FocusedRowHandle, "Kode") & "'"
                End If
            Case 2
                If dgTipe.GetRowCellValue(dgTipe.FocusedRowHandle, "Kode") = Nothing Then
                    Exit Sub
                Else
                    question = MsgBox("Hapus " & dgTipe.GetRowCellValue(dgTipe.FocusedRowHandle, "Kode") & " ?", vbYesNo, "Konfirmasi")
                    query = "delete from MstTipe where Kode='" & dgTipe.GetRowCellValue(dgTipe.FocusedRowHandle, "Kode") & "'"
                End If
            Case 3
                If dgBahan.GetRowCellValue(dgBahan.FocusedRowHandle, "Kode") = Nothing Then
                    Exit Sub
                Else
                    question = MsgBox("Hapus " & dgBahan.GetRowCellValue(dgBahan.FocusedRowHandle, "Kode") & " ?", vbYesNo, "Konfirmasi")
                    query = "delete from MstBahan where Kode='" & dgBahan.GetRowCellValue(dgBahan.FocusedRowHandle, "Kode") & "'"
                End If
            Case 4
                If dgUkuran.GetRowCellValue(dgUkuran.FocusedRowHandle, "Kode") = Nothing Then
                    Exit Sub
                Else
                    question = MsgBox("Hapus " & dgUkuran.GetRowCellValue(dgUkuran.FocusedRowHandle, "Kode") & " ?", vbYesNo, "Konfirmasi")
                    query = "delete from MstUkuranAtk where Kode='" & dgUkuran.GetRowCellValue(dgUkuran.FocusedRowHandle, "Kode") & "'"
                End If
            Case 5
                If dgWarna.GetRowCellValue(dgWarna.FocusedRowHandle, "Kode") = Nothing Then
                    Exit Sub
                Else
                    question = MsgBox("Hapus " & dgWarna.GetRowCellValue(dgWarna.FocusedRowHandle, "Kode") & " ?", vbYesNo, "Konfirmasi")
                    query = "delete from MstWarna where Kode='" & dgWarna.GetRowCellValue(dgWarna.FocusedRowHandle, "Kode") & "'"
                End If
        End Select
        If question = vbYes Then
            cmd = New SqlCommand(query, kon)
            cmd.ExecuteNonQuery()
            Pesan({"Data Berhasil Dihapus"}, "Informasi")
            refreshgrid()
        End If
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Close()
    End Sub

    Private Sub dgUkuran_Grid_DoubleClick1(sender As Object, e As EventArgs) Handles dgUkuran.Grid_DoubleClick
        tKode.Text = dgUkuran.GetRowCellValue(dgUkuran.FocusedRowHandle, "Kode")
        tKeterangan.Text = dgUkuran.GetRowCellValue(dgUkuran.FocusedRowHandle, "Keterangan")
    End Sub

    Private Sub dgWarna_Grid_DoubleClick(sender As Object, e As EventArgs) Handles dgWarna.Grid_DoubleClick
        tKode.Text = dgWarna.GetRowCellValue(dgWarna.FocusedRowHandle, "Kode")
        tKeterangan.Text = dgWarna.GetRowCellValue(dgWarna.FocusedRowHandle, "Keterangan")
    End Sub
End Class