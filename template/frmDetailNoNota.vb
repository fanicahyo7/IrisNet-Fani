Imports meCore
Imports System.Data.SqlClient
Public Class frmDetailNoNota
    Dim isNew As Boolean = True
    Dim db As New cMeDB
    Dim pKode As String = "asdjaksdjqi01298310owueqiowueakdh"

    Sub loadDetail()
        Dim pQuery As String = ""
       
        pQuery = "Select Kode, Keterangan,StartNumber,EndNumber,FlagAktif, UserEntry,DateTimeENtry,UserUpdate,DateTimeUpdate from mstDaftarNota where Kode = '" & pKode & "'"

        db.FillMe(pQuery, True)

        If db.Rows.Count > 0 Then
            isNew = False
            FillFormFromDataRow(Me, db.Rows(0))
            SetTextReadOnly({tKode})

            If IsDBNull(db.Rows(0)!FlagAktif) = True Then
                cFlagAktif.Checked = False
            ElseIf db.Rows(0)!FlagAktif = 0 Then
                cFlagAktif.Checked = False
            Else
                cFlagAktif.Checked = True
            End If
        Else
            ClearValue(Me)
            isNew = True
            SetTextReadOnly({tKode}, False)
        End If
    End Sub
    Private Sub frmDetailNoNota_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tKeterangan.Properties.CharacterCasing = CharacterCasing.Upper
        If Me.Tag <> "" Then pKode = Me.Tag
        koneksi()
        
        loadDetail()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If CheckBeforeSave({tKode, tKeterangan, tStartNumber, tEndNumber}) = True Then
            Try
                Dim drow As DataRow
                If isNew = True Then
                    drow = db.NewRow
                Else
                    drow = db.Rows(0)
                End If

                drow!Kode = tKode.Text
                drow!Keterangan = tKeterangan.Text
                drow!StartNumber = tStartNumber.Text
                drow!EndNumber = tEndNumber.Text
                drow!FlagAktif = cFlagAktif.Checked

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

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Close()
    End Sub

    Private Sub tKode_Validated(sender As Object, e As EventArgs) Handles tKode.Validated
        pKode = tKode.Text
        Dim pQuery As String = ""
        pQuery = "Select Kode, Keterangan,StartNumber,EndNumber,FlagAktif, UserEntry,DateTimeENtry,UserUpdate,DateTimeUpdate from mstDaftarNota where Kode = '" & pKode & "'"
        db.FillMe(pQuery, True)

        If db.Rows.Count > 0 Then
            isNew = False
            FillFormFromDataRow(Me, db.Rows(0))

            If IsDBNull(db.Rows(0)!FlagAktif) = True Then
                cFlagAktif.Checked = False
            ElseIf db.Rows(0)!FlagAktif = 0 Then
                cFlagAktif.Checked = False
            Else
                cFlagAktif.Checked = True
            End If
        Else
            ClearValue(Me, {"tKode"})
            cFlagAktif.Checked = False
            isNew = True
        End If
    End Sub
End Class