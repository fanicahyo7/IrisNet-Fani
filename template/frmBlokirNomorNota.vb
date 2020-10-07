Imports System.Data.SqlClient
Public Class frmBlokirNomorNota

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Using xx As New frmLaporanNotaManual
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub tNomor_Validated(sender As Object, e As EventArgs) Handles tNomor.Validated
        cek()
    End Sub
    Sub cek()
        Dim start, endnum As Integer
        Dim qstart As String
        Dim qendnum As String

        qstart = "Select min(startNumber) as Nilai from mstDaftarNota where flagaktif=1"
        cmd = New SqlCommand(qstart, kon)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            start = rd!Nilai
        End If
        rd.Close()

        qendnum = "Select max(EndNumber) as Nilai from mstDaftarNota where flagaktif=1"
        cmd = New SqlCommand(qendnum, kon)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            endnum = rd!Nilai
        End If
        rd.Close()

        If CInt(tNomor.Value) >= start And CInt(tNomor.Value) <= endnum Then
            Dim cek As String = "select nomor from mstDaftarNotaDetail where Tahun='" & Format(Now, "yyyy") & "' and nomor='" & tNomor.Value & "'"
            cmd = New SqlCommand(cek, kon)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                MsgBox("Nomor Nota Anda Sudah Terpakai Atau Terblokir", vbOKOnly + vbOKOnly, "Informasi")
                tNomor.Value = 0
                tNomor.Focus()
                rd.Close()
                Exit Sub
            End If
            rd.Close()
        Else
            MsgBox("Nomor Nota Anda Tidak Terdaftar, Hubungi Supervisor", vbOKOnly + vbInformation, "Informasi")
            tNomor.Value = 0
            tNomor.Focus()
            Exit Sub
        End If
    End Sub
    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Close()
    End Sub

    Private Sub frmBlokirNomorNota_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()

        tNomor.Properties.MaxLength = 10
    End Sub

    Private Sub btnBlokir_Click(sender As Object, e As EventArgs) Handles btnBlokir.Click
        cek()
        Dim question As String
        question = MsgBox("Anda Yakin Blokir Nota Nomor " & tNomor.Value & "?", vbYesNo, "Konfirmasi")
        If question = vbYes Then
            Dim query As String = "INSERT INTO mstDaftarNotaDetail (Tahun,Nomor,Faktur,FlagBlokir) values ('" & Format(Now, "yyyy") & "','" & Trim(tNomor.Value) & "','" & Trim(tKeterangan.Text) & "',1)"
            cmd = New SqlCommand(query, kon)
            cmd.ExecuteNonQuery()
            MsgBox("Blokir Nomor Nota Berhasil", vbOKOnly + vbInformation, "Informasi")
        End If
    End Sub

End Class