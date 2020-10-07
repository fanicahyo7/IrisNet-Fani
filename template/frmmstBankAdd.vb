Imports meCore
Public Class frmmstBankAdd
    Dim isNew As Boolean = True
    Dim db As New cMeDB
    Dim pKode As String = "asdjaksdjqi01298310owueqiowueakdh"

    Sub loadDetail()
        Dim pQuery As String = "Select Status, KdBank, NamaBank, NoRekLength, UserEntry, DateTimeEntry, UserUpdate, DateTimeUpdate from mstBank where KdBank = '" & pKode & "'"
        db.FillMe(pQuery, True)

        If db.Rows.Count > 0 Then
            isNew = False
            FillFormFromDataRow(Me, db.Rows(0))
            SetTextReadOnly({tKdBank})
        Else
            btnBaru.PerformClick()
        End If
    End Sub
    Private Sub frmmstBankAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tKdBank.Properties.CharacterCasing = CharacterCasing.Upper
        tNamaBank.Properties.CharacterCasing = CharacterCasing.Upper
        If Me.Tag <> "" Then pKode = Me.Tag

        loadDetail()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        tKdBank.Text = Trim(tKdBank.Text)
        tNamaBank.Text = Trim(tNamaBank.Text)
        If CheckBeforeSave({tKdBank, tNamaBank}) = True Then
            Try
                Dim drow As DataRow
                If isNew = True Then
                    drow = db.NewRow
                Else
                    drow = db.Rows(0)
                End If

                drow!KdBank = tKdBank.Text
                drow!NamaBank = tNamaBank.Text
                drow!NoRekLength = tNoRekLength.Text
                drow!Status = cStatus.Checked

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

    Private Sub btnBaru_Click(sender As Object, e As EventArgs) Handles btnBaru.Click
        ClearValue(Me)
        SetTextReadOnly({tKdBank}, False)
        isNew = True
    End Sub

    Private Sub tKdBank_Validated(sender As Object, e As EventArgs) Handles tKdBank.Validated
        pKode = tKdBank.Text
        Dim query As String = "select * from mstBank where KdBank='" & pKode & "'"
        db.FillMe(query, True)

        If db.Rows.Count > 0 Then
            isNew = False
            FillFormFromDataRow(Me, db.Rows(0))
        Else
            ClearValue(Me, {"tKdBank"})
            isNew = True
        End If
    End Sub
End Class