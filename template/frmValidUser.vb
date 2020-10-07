Imports meCore
Imports System.Data.SqlClient
Public Class frmValidUser
    'Dim pubUserEntry As String = "FANI"

    Private Sub frmValidUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tUsername.Properties.CharacterCasing = CharacterCasing.Upper
        tpassword.Properties.CharacterCasing = CharacterCasing.Upper
        koneksi()
        Dim query As String
        query = "select UserName, FirstName as NamaLengkap,UserLevel,Initial, b.Keterangan as NamaLevel, status from UserLogin a " & _
                "left join stLevel b on a.UserLevel  = b.kode and b.AppName = 'IRIS SOFT.' " & _
                "where a.Appname = 'IRIS SOFT.' and status = '1' and UserLevel = '00' " & _
                "order by Status desc, UserLevel, UserName"
        CtrlMeDataGrid1.FirstInit(query, {1, 1, 1, 1, 1, 1}, , , {"UserLevel", "Initial", "NamaLevel", "status"})
        CtrlMeDataGrid1.RefreshData()
    End Sub

    Private Sub CtrlMeDataGrid1_Grid_DoubleClick(sender As Object, e As EventArgs) Handles CtrlMeDataGrid1.Grid_DoubleClick
        tUsername.Text = CtrlMeDataGrid1.GetRowCellValue(CtrlMeDataGrid1.FocusedRowHandle, "UserName")
    End Sub

    Private Sub CtrlMeDataGrid1_Load(sender As Object, e As EventArgs) Handles CtrlMeDataGrid1.Load

    End Sub

    Private Sub btnvalidate_Click(sender As Object, e As EventArgs) Handles btnvalidate.Click
        Dim cloginpass As String
        cloginpass = "select * from UserLogin where UserName='" & tUsername.Text & "'"
        cmd = New SqlCommand(cloginpass, kon)
        rd = cmd.ExecuteReader
        rd.Read()
        Dim pPasword As String = Replace(DecryptWithClipper(rd!Password, "password"), " ", "")
        If Not LCase(pPasword) = LCase(tpassword.Text) Then
            MsgBox("Login Gagal", vbCritical + vbOKOnly, "Peringatan")
            rd.Close()
        Else
            rd.Close()
            Dim query As String
            query = "Update mstEvent Set UserValidate = '" & pubUserEntry & "', DateTimeValidate = '" & DTOC(Now, "/", True) & "' Where kode = '" & Me.Tag & "'"
            cmd = New SqlCommand(query, kon)
            cmd.ExecuteNonQuery()
            MsgBox("Validasi Berhasil", vbInformation + vbOKOnly, "Informasi")
            Me.Close()
        End If
    End Sub
End Class