Imports meCore
Imports System.Data.SqlClient
Public Class frmDetailCard
    Dim isNew As Boolean = True
    Dim db As New cMeDB
    Dim pKode As String = "asdjaksdjqi01298310owueqiowueakdh"
    Private Sub frmDetailCard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tKode.Properties.CharacterCasing = CharacterCasing.Upper
        tKeterangan.Properties.CharacterCasing = CharacterCasing.Upper
        If Me.Tag <> "" Then pKode = Me.Tag

        loadDetail()
    End Sub

    Sub loadDetail()
        Dim pQuery As String = ""
        pQuery = "Select Kode, Jenis, Keterangan , Charge, UserEntry,DateTimeENtry,UserUpdate,DateTimeUpdate from mstCard where Kode = '" & pKode & "'"
        db.FillMe(pQuery, True)

        If db.Rows.Count > 0 Then
            isNew = False
            FillFormFromDataRow(Me, db.Rows(0))
            SetTextReadOnly({tKode})
        Else
            ClearValue(Me)
            isNew = True
            cJenis.SelectedIndex = 0
            SetTextReadOnly({tKode}, False)
        End If
    End Sub

    Private Sub cJenis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cJenis.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Close()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If CheckBeforeSave({tKode, tKeterangan}) = True Then
            Try
                Dim drow As DataRow
                If isNew = True Then
                    drow = db.NewRow
                Else
                    drow = db.Rows(0)
                End If

                drow!Kode = tKode.Text
                drow!Keterangan = tKeterangan.Text
                drow!Charge = tCharge.Value

                If cJenis.SelectedIndex = 0 Then
                    drow!Jenis = "K"
                Else
                    drow!Jenis = "D"
                End If

                If isNew = True Then
                    drow!UserEntry = pubUserEntry
                    drow!DateTimeEntry = Now
                Else
                    drow!UserUpdate = pubUserEntry
                    drow!DateTimeUpdate = Now
                End If

                If isNew Then db.Rows.Add(drow)
                db.UpdateMeToRealDBNoTry()
                Pesan({IIf(isNew = True, "Simpan", "Update") & " Data BERHASIL"})
                Close()
            Catch ex As Exception
                Pesan({"GAGAL SIMPAN DATA", "", "Err : " & ex.Message.ToString})
            End Try
        End If
    End Sub

    Private Sub cJenis_TextChanged(sender As Object, e As EventArgs) Handles cJenis.TextChanged
        If cJenis.Text = "K" Then
            cJenis.SelectedIndex = 0
        ElseIf cJenis.Text = "D" Then
            cJenis.SelectedIndex = 1
        End If
    End Sub

    Private Sub tKode_Validated(sender As Object, e As EventArgs) Handles tKode.Validated
        pKode = tKode.Text
        Dim pQuery As String = ""
        pQuery = "Select Kode, Jenis, Keterangan , Charge, UserEntry,DateTimeENtry,UserUpdate,DateTimeUpdate from mstCard where Kode = '" & pKode & "'"
        db.FillMe(pQuery, True)

        If db.Rows.Count > 0 Then
            isNew = False
            FillFormFromDataRow(Me, db.Rows(0))
        Else
            isNew = True
            ClearValue(Me, {"tKode"})
            cJenis.SelectedIndex = 0
        End If
    End Sub
End Class