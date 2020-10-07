Imports meCore
Public Class mstcoba
    Dim isNew As Boolean = True
    Dim db As New cMeDB
    Dim pKode As String = "asdjaksdjqi01298310owueqiowueakdh"

    Sub loadDetail()
        Dim pQuery As String = "Select Kodecst, Namacst, Alamat, Tanggal from tblatihan where Kodecst = '" & pKode & "'"
        db.FillMe(pQuery, True)

        If db.Rows.Count > 0 Then
            isNew = False
            FillFormFromDataRow(Me, db.Rows(0))
            SetTextReadOnly({tKodecst})
        Else
            btnbaru.PerformClick()
        End If
    End Sub
    Private Sub btnbaru_Click(sender As Object, e As EventArgs) Handles btnbaru.Click
        ClearValue(Me)
        SetTextReadOnly({tKodecst}, False)
        isNew = True
    End Sub

    Private Sub mstcoba_Load(sender As Object, e As EventArgs) Handles Me.Load
        'initForm(Me, EnfrmSizeNotMax.efsnm2Medium, DevExpress.XtraLayout.MoveFocusDirection.DownThenAcross)

        If Me.Tag <> "" Then pKode = Me.Tag

        loadDetail()
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        If CheckBeforeSave({tKodecst, tNamacst, tAlamat}) = True Then
            Try
                Dim drow As DataRow
                If isNew = True Then
                    drow = db.NewRow
                Else
                    drow = db.Rows(0)
                End If

                drow!Kodecst = tKodecst.Text
                drow!Namacst = tNamacst.Text
                drow!Alamat = tAlamat.Text
                drow!Tanggal = dTanggal.Text

                If isNew Then db.Rows.Add(drow)
                db.UpdateMeToRealDBNoTry()
                Pesan({IIf(isNew = True, "Simpan", "Update") & " Data BERHASIL"})
            Catch ex As Exception
                Pesan({"GAGAL SIMPAN DATA", "", "Err : " & ex.Message.ToString})
            End Try
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If CheckBeforeSave({tKodecst, tNamacst, tAlamat}) = True Then
            Try
                Dim arrField() As String = {"Kodecst", "Namacst", "Alamat", "Tanggal"}

                Dim arrValue() As String = {tKodecst.Text, tNamacst.Text, tAlamat.Text, dTanggal.Text}

                Dim result As Boolean = db.ExecInsertUpdate("tblatihan", arrField, arrValue, " Kodecst = '" & pKode & "'")

                If result = True Then
                    Pesan({"BERHASIL"})
                Else
                    Pesan({"GAGAL"})
                End If
            Catch ex As Exception
                Pesan({"GAGAL", "", "Err : " & ex.Message.ToString})
            End Try
        End If
    End Sub
End Class