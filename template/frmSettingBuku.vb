Imports meCore
Imports System.Data.SqlClient
Public Class frmSettingBuku

    Private Sub frmSettingBuku_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        tKode.Properties.CharacterCasing = CharacterCasing.Upper
        tKeterangan.Properties.CharacterCasing = CharacterCasing.Upper
        Dim sql As String = "select Kode,Keterangan,Show from MstSerial order by Kode"
        dgSerial.FirstInit(sql, {0.5, 1, 0.5}, , , {"Show"})
        dgSerial.RefreshData()
    End Sub

    Private Sub XtraTabControl1_Click(sender As Object, e As EventArgs) Handles XtraTabControl1.Click
        refreshgrid()
    End Sub
    Sub refreshgrid()
        Dim sql As String = ""

        Select Case (XtraTabControl1.SelectedTabPageIndex.ToString)
            Case 0
                ClearValue(Me)
                LayoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                sql = "select Kode,Keterangan,Show from MstSerial order by Kode"
                dgSerial.FirstInit(sql, {0.5, 1, 0.5}, , , {"Show"})
                dgSerial.RefreshData()
            Case 1
                ClearValue(Me)
                LayoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                sql = "select Kode,Keterangan,Show from MstCover order by Kode"
                dgCover.FirstInit(sql, {0.5, 1, 0.5}, , , {"Show"})
                dgCover.RefreshData()
            Case 2
                ClearValue(Me)
                LayoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                sql = "select Kode,Keterangan,Show from MstJenisKertas order by Kode"
                dgJenisKertas.FirstInit(sql, {0.5, 1, 0.5}, , , {"Show"})
                dgJenisKertas.RefreshData()
            Case 3
                ClearValue(Me)
                LayoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                sql = "select Kode,Keterangan from MstUkuranBuku order by Kode"
                dgUkuran.FirstInit(sql, {0.5, 1})
                dgUkuran.RefreshData()
            Case Else
                Exit Sub
        End Select
    End Sub
    Private Sub dgSerial_Grid_DoubleClick(sender As Object, e As EventArgs) Handles dgSerial.Grid_DoubleClick
        tKode.Text = dgSerial.GetRowCellValue(dgSerial.FocusedRowHandle, "Kode")
        tKeterangan.Text = dgSerial.GetRowCellValue(dgSerial.FocusedRowHandle, "Keterangan")
        Dim anu As Boolean
        If dgSerial.GetRowCellValue(dgSerial.FocusedRowHandle, "Show") = 1 Then
            anu = True
        Else
            anu = False
        End If
        cShow.Checked = anu
    End Sub


    Private Sub dgCover_Grid_DoubleClick(sender As Object, e As EventArgs) Handles dgCover.Grid_DoubleClick
        tKode.Text = dgCover.GetRowCellValue(dgCover.FocusedRowHandle, "Kode")
        tKeterangan.Text = dgCover.GetRowCellValue(dgCover.FocusedRowHandle, "Keterangan")
        Dim anu As Boolean
        If dgCover.GetRowCellValue(dgCover.FocusedRowHandle, "Show") = 1 Then
            anu = True
        Else
            anu = False
        End If
        cShow.Checked = anu
    End Sub


    Private Sub dgJenisKertas_Grid_DoubleClick(sender As Object, e As EventArgs) Handles dgJenisKertas.Grid_DoubleClick
        tKode.Text = dgJenisKertas.GetRowCellValue(dgJenisKertas.FocusedRowHandle, "Kode")
        tKeterangan.Text = dgJenisKertas.GetRowCellValue(dgJenisKertas.FocusedRowHandle, "Keterangan")
        Dim anu As Boolean
        If dgJenisKertas.GetRowCellValue(dgJenisKertas.FocusedRowHandle, "Show") = 1 Then
            anu = True
        Else
            anu = False
        End If
        cShow.Checked = anu
    End Sub

    Private Sub dgUkuran_Grid_DoubleClick(sender As Object, e As EventArgs) Handles dgUkuran.Grid_DoubleClick
        tKode.Text = dgUkuran.GetRowCellValue(dgUkuran.FocusedRowHandle, "Kode")
        tKeterangan.Text = dgUkuran.GetRowCellValue(dgUkuran.FocusedRowHandle, "Keterangan")
        Dim anu As Boolean
        If dgUkuran.GetRowCellValue(dgUkuran.FocusedRowHandle, "Show") = 1 Then
            anu = True
        Else
            anu = False
        End If
        cShow.Checked = anu
    End Sub

    Private Sub btnBaru_Click(sender As Object, e As EventArgs) Handles btnBaru.Click
        ClearValue(Me)
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If Trim(tKode.Text).Length > 0 Then
            Dim jumlah As Integer
            Dim tbl As String = ""
            Dim cek As String = ""
            Select Case (XtraTabControl1.SelectedTabPageIndex.ToString)
                Case 0
                    Dim dKode() As DataRow = dgSerial.DataSource.Select("Kode = '" & Trim(tKode.Text) & "' ")
                    jumlah = dKode.Length
                    tbl = "MstSerial"
                    If cShow.Checked = True Then
                        cek = "1"
                    Else
                        cek = "0"
                    End If
                Case 1
                    Dim dKode() As DataRow = dgCover.DataSource.Select("Kode = '" & Trim(tKode.Text) & "' ")
                    jumlah = dKode.Length
                    tbl = "MstCover"
                    If cShow.Checked = True Then
                        cek = "1"
                    Else
                        cek = "0"
                    End If
                Case 2
                    Dim dKode() As DataRow = dgJenisKertas.DataSource.Select("Kode = '" & Trim(tKode.Text) & "' ")
                    jumlah = dKode.Length
                    tbl = "MstJenisKertas"
                    If cShow.Checked = True Then
                        cek = "1"
                    Else
                        cek = "0"
                    End If
                Case 3
                    Dim dKode() As DataRow = dgUkuran.DataSource.Select("Kode = '" & Trim(tKode.Text) & "' ")
                    jumlah = dKode.Length
                    tbl = "MstUkuranBuku"
                    cek = "1"
            End Select
            Dim question As String
            question = MsgBox("Simpan Data?" & vbCrLf & "ID :" & Trim(tKode.Text) & "", vbYesNo, "Konfirmasi")
            If question = vbYes Then

                If jumlah > 0 Then
                    prosesdata("Update", tbl, cek)
                Else
                    prosesdata("Tambah", tbl, cek)
                End If
                refreshgrid()
                ClearValue(Me)
            End If
        Else
            Pesan({"Isi Kode"}, "Peringatan")
        End If
    End Sub

    Sub prosesdata(ByRef prs As String, ByRef tbl As String, ByRef isicek As String)

        If CheckBeforeSave({tKode, tKeterangan}) = True Then
            Try
                Dim query As String = ""
                If prs = "Tambah" Then
                    query = "insert into " & tbl & " (Kode,Keterangan,UserEntry,DateTimeEntry,Show)values('" & Trim(tKode.Text) & "','" & Trim(tKeterangan.Text) & "','" & pubUserEntry & "','" & DTOC(Now, "/", True) & "','" & isicek & "')"
                ElseIf prs = "Update" Then
                    query = "update " & tbl & " set Keterangan='" & Trim(tKeterangan.Text) & "',UserUpdate='" & pubUserEntry & "',DateTimeUpdate='" & DTOC(Now, "/", True) & "',Show='" & isicek & "' where Kode='" & Trim(tKode.Text) & "'"
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

        Select Case (XtraTabControl1.SelectedTabPageIndex.ToString)
            Case 0
                If dgSerial.GetRowCellValue(dgSerial.FocusedRowHandle, "Kode") = Nothing Then
                    Exit Sub
                Else
                    question = MsgBox("Hapus " & dgSerial.GetRowCellValue(dgSerial.FocusedRowHandle, "Kode") & " ?", vbYesNo, "Konfirmasi")
                    query = "delete from MstSerial where Kode='" & dgSerial.GetRowCellValue(dgSerial.FocusedRowHandle, "Kode") & "'"
                End If
            Case 1
                If dgCover.GetRowCellValue(dgCover.FocusedRowHandle, "Kode") = Nothing Then
                    Exit Sub
                Else
                    question = MsgBox("Hapus " & dgCover.GetRowCellValue(dgCover.FocusedRowHandle, "Kode") & " ?", vbYesNo, "Konfirmasi")
                    query = "delete from MstCover where Kode='" & dgCover.GetRowCellValue(dgCover.FocusedRowHandle, "Kode") & "'"
                End If
            Case 2
                If dgJenisKertas.GetRowCellValue(dgJenisKertas.FocusedRowHandle, "Kode") = Nothing Then
                    Exit Sub
                Else
                    question = MsgBox("Hapus " & dgJenisKertas.GetRowCellValue(dgJenisKertas.FocusedRowHandle, "Kode") & " ?", vbYesNo, "Konfirmasi")
                    query = "delete from MstJenisKertas where Kode='" & dgJenisKertas.GetRowCellValue(dgJenisKertas.FocusedRowHandle, "Kode") & "'"
                End If
            Case 3
                If dgUkuran.GetRowCellValue(dgUkuran.FocusedRowHandle, "Kode") = Nothing Then
                    Exit Sub
                Else
                    question = MsgBox("Hapus " & dgUkuran.GetRowCellValue(dgUkuran.FocusedRowHandle, "Kode") & " ?", vbYesNo, "Konfirmasi")
                    query = "delete from MstUkuranBuku where Kode='" & dgUkuran.GetRowCellValue(dgUkuran.FocusedRowHandle, "Kode") & "'"
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
End Class