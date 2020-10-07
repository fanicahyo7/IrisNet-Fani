
Imports meCore

Public Class mstCustomer
    Dim isNew As Boolean = True
    Dim db As New cMeDB
    Dim pKode As String = "asdjaksdjqi01298310owueqiowueakdh"

    Private Sub mstCustomer_Load(sender As Object, e As EventArgs) Handles Me.Load
        initForm(Me, EnfrmSizeNotMax.efsnm2Medium, DevExpress.XtraLayout.MoveFocusDirection.DownThenAcross)

        If Me.Tag <> "" Then pKode = Me.Tag

        loadDetail()
    End Sub

    Sub loadDetail()
        Dim pQuery As String = _
            "Select Kode, Nama, Alamat, Kodepos from mstcustomer where kode = '" & pKode & "'"
        db.FillMe(pQuery, True)

        If db.Rows.Count > 0 Then
            isNew = False
            FillFormFromDataRow(Me, db.Rows(0))
            SetTextReadOnly({tKode})
        Else
            cmdNew.PerformClick()
        End If
    End Sub

    Private Sub cmdNew_Click(sender As Object, e As EventArgs) Handles cmdNew.Click
        ClearValue(Me)
        SetTextReadOnly({tKode}, False)
        isNew = True
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        If CheckBeforeSave({tKode, tNama, tAlamat, tKodepos}) = True Then
            Try
                Dim drow As DataRow
                If isNew = True Then
                    drow = db.NewRow
                Else
                    drow = db.Rows(0)
                End If

                drow!Kode = tKode.Text
                drow!Nama = tNama.Text
                drow!Alamat = tAlamat.Text
                drow!Kodepos = tKodepos.Text

                If isNew Then db.Rows.Add(drow)
                db.UpdateMeToRealDBNoTry()
                Pesan({IIf(isNew = True, "Simpan", "Update") & " Data BERHASIL"})
            Catch ex As Exception
                Pesan({"GAGAL SIMPAN DATA", "", "Err : " & ex.Message.ToString})
            End Try
        End If
    End Sub

    Private Sub cmdSave2_Click(sender As Object, e As EventArgs) Handles cmdSave2.Click
        If CheckBeforeSave({tKode, tNama, tAlamat, tKodepos}) = True Then
            Try
                Dim arrField() As String = _
                    {"Kode", "Nama", "Alamat", "Kodepos"}

                Dim arrValue() As String = _
                    {tKode.Text, tNama.Text, tAlamat.Text, tKodepos.Text}

                Dim result As Boolean = _
                    db.ExecInsertUpdate("mstCustomer", arrField, arrValue, " kode = '" & pKode & "'")

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