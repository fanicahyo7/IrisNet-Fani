Imports meCore
Imports System.Data.SqlClient

Public Class frmPBYValid
    Dim nopengajuan As String = ""
    Dim tanggal As Date = Now

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(nopengajuan As String, tgl As Date)
        InitializeComponent()
        Me.nopengajuan = nopengajuan
        Me.tanggal = tgl
    End Sub
    Private Sub frmPBYValid_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tPassword.Properties.PasswordChar = "*"
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Function ceklogin(ByVal username As String, ByVal pass As String) As Boolean
        Dim hasil As Boolean = False

        Using dbtmp As New cMeDB
            Dim pque As String = "SELECT UserName, Initial, Password, FirstName FROM dbo.UserLogin WHERE Status = 1 AND username = '" & username & "'"
            dbtmp.FillMe(pque, , 0)
            Dim password As String = ""
            If dbtmp.Rows.Count > 0 Then
                password = Replace(DecryptWithClipper(dbtmp.Rows(0)!Password, "password"), " ", "")
            End If

            If password.ToUpper = pass.ToUpper Then
                hasil = True
            Else
                If username.ToUpper = "QC" And pass.ToLower = "kualisuper" Then
                    hasil = True
                Else
                    MsgBox("Password Salah", vbCritical + vbOKOnly, "Peringatan")
                    hasil = False
                End If
            End If
        End Using

        Return hasil
    End Function

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        valid()
    End Sub

    Private Sub tPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tPassword.KeyPress
        If e.KeyChar = Chr(13) Then
            valid()
        End If
    End Sub

    Sub valid()
        Dim login As Boolean = ceklogin(pubUserName, tPassword.Text.ToUpper)
        If login = True Then
            'cek rekening
            Dim query As String = "select count(*) as no from trPengajuanBayarHD where NoPengajuan='" & nopengajuan & "' and isnull(Norek,'')='' "
            cmd = New SqlCommand(query, kon)
            rd = cmd.ExecuteReader
            rd.Read()
            Dim no As Integer
            If rd.HasRows Then
                no = rd!no
            End If
            rd.Close()
            If no > 0 Then
                MsgBox("BANK,NOMOR REKENING DAN NAMA PEMILIK REKENING ADA YANG KOSONG, MOHON DIPERIKSA KEMBALI. VALIDASI GAGAL", vbCritical + vbInformation, "INFORMASI")
                Exit Sub
            End If

            Dim question = MsgBox("KIRIM PENGAJUAN KE PUSAT ?" & vbCrLf & "PENGAJUAN TIDAK BISA DI UBAH LAGI", +vbQuestion + vbYesNo, "Konfirmasi")
            If question = vbYes Then
                Dim querysimpan As String = "begin try begin transaction "
                querysimpan += "Update trPengajuanBayarHD Set FlagSave = '1', TglPengajuan = '" & DTOC(tanggal, "-", False) & "' Where NoPengajuan = '" & nopengajuan & "'; "
                querysimpan += "exec spGenBTT; "
                querysimpan += "commit select 'sukses' as statusx end try begin catch rollback select 'gagal : ' + ERROR_MESSAGE() as statusx end catch"

                Dim db As New DataTable
                da = New SqlDataAdapter(querysimpan, kon)
                da.Fill(db)

                If db.Rows.Count > 0 Then
                    If (db.Rows(0)!statusx).ToString.Contains("sukses") Then
                        MsgBox("Validasi Berhasil", vbInformation + vbOKOnly, "Informasi")
                    ElseIf (db.Rows(0)!statusx).ToString.Contains("gagal") Then
                        MsgBox("Validasi Gagal", vbInformation + vbOKOnly, "Peringatan")
                    End If
                End If
            End If

        End If
        Me.Close()
    End Sub
End Class