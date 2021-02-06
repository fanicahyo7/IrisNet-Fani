Imports meCore
Imports System.Data.SqlClient

Public Class frmPBYaddPerforma

    Private Sub frmPBYaddPerforma_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        Dim qkdsup As String = "select Kode, Nama, Bank, NoAccount, AtasNama from mstSupplier Order by Nama"
        cKodeSupplier.FirstInit(PubConnStr, qkdsup, {tNama, tNamaBank, tNoRekening, tAtasNama}, , , , , , {0.9, 2})
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Dim question = MsgBox("Simpan performa Supplier?", vbQuestion + vbYesNo, "Konfirmasi")
        If question = vbYes Then
            MsgBox("Oyi")
        Else
            MsgBox("Kadit")
        End If
    End Sub

    Private Sub cKodeSupplier_EditValueChanged(sender As Object, e As EventArgs) Handles cKodeSupplier.EditValueChanged
        Dim carikode As String = _
            "select max(SUBSTRING( NoPengajuan,12,2)) as max from trPengajuanBayarHd where left(nopengajuan,11) = '" & pubKodeUnit & "PBY-" & Format(Now, "yyMM") & "'"
        cmd = New SqlCommand(carikode, kon)
        rd = cmd.ExecuteReader
        Dim angka As String = ""
        rd.Read()
        If rd.HasRows Then
            angka = rd!max
            If angka = "" Then
                angka = "01"
            Else
                angka = CInt(angka) + 1
                If Len(angka) = 1 Then
                    angka = "0" & angka
                End If
            End If
        End If
        rd.Close()
        tNoPengajuan.Text = "" & pubKodeUnit & "PBY-" & Format(Now, "yyMM") & "" & angka

        Dim carictr As String = _
        "select max(SUBSTRING( NoCtr,12,3)) as max from trPengajuanBayarHd where left(noctr,11) = '" & pubKodeUnit & "CTR-" & Format(Now, "yyMM") & "'"
        cmd = New SqlCommand(carictr, kon)
        rd = cmd.ExecuteReader
        Dim angkactr As String = ""
        rd.Read()
        If rd.HasRows Then
            angkactr = rd!max
            If angka = "" Then
                angka = "001"
            Else
                angkactr = CInt(angkactr) + 1
                If Len(angkactr) = 1 Then
                    angkactr = "00" & angkactr
                ElseIf Len(angkactr) = 2 Then
                    angkactr = "0" & angkactr
                End If
            End If
        End If
        rd.Close()
        tCtr.Text = "" & pubKodeUnit & "CTR-" & Format(Now, "yyMM") & ""

        'select max(SUBSTRING( Faktur,18,2)) as max from trPengajuanBayarDt where left(Faktur,17) = '601PRF-AGUNG.2102'

    End Sub
End Class