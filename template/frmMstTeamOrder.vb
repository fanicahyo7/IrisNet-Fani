Imports meCore
Imports System.Data.SqlClient
Public Class frmMstTeamOrder
    Dim db As New cMeDB
    Dim proses As String = ""
    Private Sub frmMstTeamOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tUserName.Properties.CharacterCasing = CharacterCasing.Upper
        tFirstName.Properties.CharacterCasing = CharacterCasing.Upper
        tNama.Properties.CharacterCasing = CharacterCasing.Upper
        SetTextReadOnly({tUserName, tFirstName})
        LayoutControlItem11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        Dim ckd As String = "select Kode,Nama,Alamat from mstSupplier Where FlagActive = 1  Order by kode"
        cKdSupplier.FirstInit(PubConnStr, ckd, {tNama})

        Dim qq As String = "select UserName as Login, FirstName as NamaLengkap , Initial, b.Keterangan as Level " & _
            "from UserLogin a  left join stLevel b on a.UserLevel = b.Kode and a.AppName = b.AppName where Status = 1 order by FirstName"
        mdgList.FirstInit(qq, {0.8, 1, 0.5, 1})
        mdgList.RefreshData(False)
    End Sub

    Private Sub mdgList_Grid_DoubleClick(sender As Object, e As EventArgs) Handles mdgList.Grid_DoubleClick
        tUserName.Text = mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Login")
        tFirstName.Text = mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "NamaLengkap")
        koneksi()
        refreshpilihan()
    End Sub
    Sub refreshpilihan()
        Dim kk As String = "select Kode, b.Nama, b.Alamat, Kota from mstOrderTeam a left join mstSupplier b " & _
            "on a.KdSupplier = b.kode where a.UserLogin = '" & mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Login") & "' order by a.KdSupplier"
        mdgListPilihan.FirstInit(kk, {0.8, 0.8, 1, 0.8})
        mdgListPilihan.RefreshData()
    End Sub

    Private Sub mdgListPilihan_Grid_DoubleClick(sender As Object, e As EventArgs) Handles mdgListPilihan.Grid_DoubleClick
        cKdSupplier.Text = mdgListPilihan.GetRowCellValue(mdgListPilihan.FocusedRowHandle, "Kode")
    End Sub

    Sub prosesdata(ByRef prs As String)
        If CheckBeforeSave({cKdSupplier, tNama}) = True Then
            Try
                Dim query As String = ""
                If prs = "Tambah" Then
                    query = "insert into mstOrderTeam (UserLogin,KdSupplier)values('" & tUserName.Text & "','" & cKdSupplier.Text & "')"
                ElseIf prs = "Update" Then
                    query = "update mstOrderTeam set UserLogin='" & tUserName.Text & "',KdSupplier='" & cKdSupplier.Text & "' where UserLogin='" & tUserName.Text & "' AND KdSupplier='" & cKdSupplier.Text & "'"
                End If
                cmd = New SqlCommand(query, kon)
                cmd.ExecuteNonQuery()
                If prs = "Tambah" Then
                    query = "insert into mstOrderTeam (UserLogin,KdSupplier)values('" & tUserName.Text & "','" & cKdSupplier.Text & "')"
                ElseIf prs = "Update" Then
                    query = "update mstOrderTeam set UserLogin='" & tUserName.Text & "',KdSupplier='" & cKdSupplier.Text & "' where UserLogin='" & tUserName.Text & "' AND KdSupplier='" & cKdSupplier.Text & "'"
                End If
                Pesan({"Data Berhasil Disimpan"}, "Informasi")
            Catch ex As Exception
                Pesan({"GAGAL SIMPAN DATA", "", "Err : " & ex.Message.ToString})
            End Try
        End If
    End Sub


    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Dim question As String
        question = MsgBox("Simpan Data?", vbYesNo, "Konfirmasi")
        If question = vbYes Then
            Dim dKode() As DataRow = mdgListPilihan.DataSource.Select("Kode = '" & cKdSupplier.Text & "' ")
            If dKode.Length > 0 Then
                prosesdata("Update")
            Else
                prosesdata("Tambah")
            End If
            refreshpilihan()
            cKdSupplier.Text = ""
            tNama.Text = ""
        End If
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        If mdgListPilihan.GetRowCellValue(mdgListPilihan.FocusedRowHandle, "Kode") = Nothing Or tUserName.Text = "" Then
            Exit Sub
        Else
            Dim question, query As String
            question = MsgBox("Hapus " & mdgListPilihan.GetRowCellValue(mdgListPilihan.FocusedRowHandle, "Kode") & " Pada User " & tUserName.Text & "?", vbYesNo, "Konfirmasi")
            If question = vbYes Then
                query = "delete from mstOrderTeam where UserLogin='" & tUserName.Text & "' AND KdSupplier='" & mdgListPilihan.GetRowCellValue(mdgListPilihan.FocusedRowHandle, "Kode") & "'"
                cmd = New SqlCommand(query, kon)
                cmd.ExecuteNonQuery()
                Pesan({"Data Berhasil Dihapus"}, "Informasi")
                refreshpilihan()
            End If
        End If
    End Sub

    Private Sub btnHapusSemua_Click(sender As Object, e As EventArgs) Handles btnHapusSemua.Click
        If tUserName.Text = "" Then
            Exit Sub
        Else
            Dim question, query As String
            question = MsgBox("Hapus Semua Supplier Pada User " & tUserName.Text & "?", vbYesNo, "Konfirmasi")
            If question = vbYes Then
                query = "delete from mstOrderTeam where UserLogin='" & tUserName.Text & "'"
                cmd = New SqlCommand(query, kon)
                cmd.ExecuteNonQuery()
                Pesan({"Data Berhasil Dihapus"}, "Informasi")
                refreshpilihan()
            End If
        End If
    End Sub

    Private Sub btnPilihSemua_Click(sender As Object, e As EventArgs) Handles btnPilihSemua.Click
        If tUserName.Text = "" Then
            Exit Sub
        Else
            Dim question, query As String
            question = MsgBox("Set Semua Supplier Pada User " & tUserName.Text & "?", vbYesNo, "Konfirmasi")
            If question = vbYes Then
                Dim jmlqry As String = "select Kode from mstSupplier Where FlagActive = 1"
                cmd = New SqlCommand(jmlqry, kon)
                dt = New DataTable
                dt.Load(cmd.ExecuteReader())
                DataGridView1.DataSource = dt

                For a = 0 To DataGridView1.Rows.Count - 2
                    Dim dd As DataGridViewRow = DataGridView1.Rows(a)
                    Dim slksi As String = "select count(*) as Jumlah from mstOrderTeam where UserLogin='" & tUserName.Text & "' and KdSupplier='" & dd.Cells("Kode").Value & "'"
                    cmd = New SqlCommand(slksi, kon)
                    rd = cmd.ExecuteReader
                    rd.Read()
                    If rd!Jumlah = 0 Then
                        rd.Close()
                        query = "insert into mstOrderTeam (UserLogin,KdSupplier)values('" & tUserName.Text & "','" & dd.Cells("Kode").Value & "')"
                        cmd = New SqlCommand(query, kon)
                        cmd.ExecuteNonQuery()
                    End If
                    rd.Close()
                Next
                Pesan({"Data Berhasil Disimpan"}, "Informasi")
                refreshpilihan()
            End If
        End If
    End Sub

    Private Sub mdgList_Load(sender As Object, e As EventArgs) Handles mdgList.Load

    End Sub
End Class