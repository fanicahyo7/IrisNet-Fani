Imports meCore
Public Class frmMstMargin
    Dim isNew As Boolean = True
    Dim db As New cMeDB
    Dim pKode As String = "asdjaksdjqi01298310owueqiowueakdh"
    Private Sub frmMstMargin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tMax5.Text = "Ke Atas"
        tKode.Properties.CharacterCasing = CharacterCasing.Upper
        tKeterangan.Properties.CharacterCasing = CharacterCasing.Upper

        SetTextReadOnly({tMax5})

        If Me.Tag <> "" Then pKode = Me.Tag

        loadDetail()
    End Sub

    Sub loadDetail()
        Dim pQuery As String = ""
        pQuery = "select Kode,Keterangan,MarginMin,Min1,Max1,Margin1,Min2,Max2,Margin2,Min3,Max3,Margin3,Min4,Max4,Margin4,Min5,Margin5,UserEntry,DateTimeEntry,UserUpdate,DateTimeUpdate from MstTypeDisc where Kode = '" & pKode & "'"
        db.FillMe(pQuery, True)

        If db.Rows.Count > 0 Then
            isNew = False
            FillFormFromDataRow(Me, db.Rows(0))
            SetTextReadOnly({tKode})
        Else
            ClearValue(Me, {"tMax5"})
            setawal()
            isNew = True
            SetTextReadOnly({tKode}, False)
        End If
    End Sub

    Sub setawal()
        tMin1.Value = 1
        tMax1.Value = 10
        tMin2.Value = 11
        tMax2.Value = 20
        tMin3.Value = 21
        tMax3.Value = 30
        tMin4.Value = 31
        tMax4.Value = 50
        tMin5.Value = 51
    End Sub
    Private Sub tMarginMin_EditValueChanged(sender As Object, e As EventArgs) Handles tMarginMin.EditValueChanged

    End Sub

    Private Sub tMarginMin_Validated(sender As Object, e As EventArgs) Handles tMarginMin.Validated
        Dim question As String
        question = MsgBox("Set Otomatis ?", vbYesNo, "Konfirmasi")
        If question = vbYes Then
            Dim nIndikator As Double
            Select Case tMarginMin.Value
                Case Is = 0
                    nIndikator = 0
                Case Is <= 5
                    nIndikator = 0.5
                Case Is <= 10
                    nIndikator = 1
                Case Is <= 15
                    nIndikator = 2
                Case Else
                    nIndikator = 2.5
            End Select

            tMargin5.Value = tMarginMin.Value
            tMargin4.Value = tMargin5.Value + nIndikator
            tMargin3.Value = tMargin4.Value + nIndikator
            tMargin2.Value = tMargin3.Value + nIndikator
            tMargin1.Value = tMargin2.Value + nIndikator
        End If
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Close()
    End Sub

    Private Sub tKode_EditValueChanged(sender As Object, e As EventArgs) Handles tKode.EditValueChanged

    End Sub

    Private Sub tKode_Validated(sender As Object, e As EventArgs) Handles tKode.Validated
        pKode = tKode.Text
        Dim pQuery As String = ""
        pQuery = "select Kode,Keterangan,MarginMin,Min1,Max1,Margin1,Min2,Max2,Margin2,Min3,Max3,Margin3,Min4,Max4,Margin4,Min5,Margin5,UserEntry,DateTimeEntry,UserUpdate,DateTimeUpdate from MstTypeDisc where Kode = '" & pKode & "'"
        db.FillMe(pQuery, True)

        If db.Rows.Count > 0 Then
            isNew = False
            FillFormFromDataRow(Me, db.Rows(0))
            SetTextReadOnly({tKode})
        Else
            ClearValue(Me, {"tKode", "tMax5"})
            setawal()
            isNew = True
            SetTextReadOnly({tKode}, False)
        End If
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        tKode.Text = Trim(tKode.Text)
        tKeterangan.Text = Trim(tKeterangan.Text)

        If CheckBeforeSave({tKode, tKeterangan, tMin1, tMin2, tMin3, tMin4, tMin5, tMax1, tMax2, tMax3, tMax4, tMax5}) = True Then
            Dim question As String
            question = MsgBox("Simpan Data?", vbYesNo, "Konfirmasi")
            If question = vbYes Then
                Try
                    Dim drow As DataRow
                    If isNew = True Then
                        drow = db.NewRow
                    Else
                        drow = db.Rows(0)
                    End If

                    drow!Kode = tKode.Text
                    drow!Keterangan = tKeterangan.Text
                    drow!MarginMin = tMarginMin.Value
                    drow!Min1 = tMin1.Value
                    drow!Max1 = tMax1.Value
                    drow!Margin1 = tMargin1.Value
                    drow!Min2 = tMin2.Value
                    drow!Max2 = tMax2.Value
                    drow!Margin2 = tMargin2.Value
                    drow!Min3 = tMin3.Value
                    drow!Max3 = tMax3.Value
                    drow!Margin3 = tMargin3.Value
                    drow!Min4 = tMin4.Value
                    drow!Max4 = tMax4.Value
                    drow!Margin4 = tMargin4.Value
                    drow!Min5 = tMin5.Value
                    drow!Margin5 = tMargin5.Value

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
        End If
    End Sub

    Private Sub tMin5_Validated(sender As Object, e As EventArgs) Handles tMin5.Validated
        If tMin5.Value <= tMax4.Value Then
            tMin5.Value = tMax4.Value + 1
        End If
    End Sub

    Private Sub tMax4_Validated(sender As Object, e As EventArgs) Handles tMax4.Validated
        If tMax4.Value >= tMin5.Value Or tMax4.Value <= tMin4.Value Then
            tMax4.Value = tMin5.Value - 1
        End If
    End Sub

    Private Sub tMin4_Validated(sender As Object, e As EventArgs) Handles tMin4.Validated
        If tMin4.Value <= tMax3.Value Or tMin4.Value >= tMax4.Value Then
            tMin4.Value = tMax3.Value + 1
        End If
    End Sub

    Private Sub tMax3_Validated(sender As Object, e As EventArgs) Handles tMax3.Validated
        If tMax3.Value >= tMin4.Value Or tMax3.Value <= tMin3.Value Then
            tMax3.Value = tMin4.Value - 1
        End If
    End Sub

    Private Sub tMin3_Validated(sender As Object, e As EventArgs) Handles tMin3.Validated
        If tMin3.Value <= tMax2.Value Or tMin3.Value >= tMax3.Value Then
            tMin3.Value = tMax2.Value + 1
        End If
    End Sub

    Private Sub tMax2_Validated(sender As Object, e As EventArgs) Handles tMax2.Validated
        If tMax2.Value >= tMin3.Value Or tMax2.Value <= tMin2.Value Then
            tMax2.Value = tMin3.Value - 1
        End If
    End Sub

    Private Sub tMin2_Validated(sender As Object, e As EventArgs) Handles tMin2.Validated
        If tMin2.Value <= tMax1.Value Or tMin2.Value >= tMax2.Value Then
            tMin2.Value = tMax1.Value + 1
        End If
    End Sub

    Private Sub tMax1_Validated(sender As Object, e As EventArgs) Handles tMax1.Validated
        If tMax1.Value >= tMin2.Value Or tMax1.Value <= tMin1.Value Then
            tMax1.Value = tMin2.Value - 1
        End If
    End Sub

    Private Sub tMin1_Validated(sender As Object, e As EventArgs) Handles tMin1.Validated
        If tMin1.Value <= 0 Then
            tMin1.Value = 1
        End If
    End Sub
End Class