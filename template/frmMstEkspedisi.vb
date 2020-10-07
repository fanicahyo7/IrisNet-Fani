Imports meCore
Public Class frmMstEkspedisi
    Dim isNew As Boolean = True
    Dim db As New cMeDB
    Dim pKode As String = "asdjaksdjqi01298310owueqiowueakdh"
    Private Sub frmMstEkspedisi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tKode.Properties.CharacterCasing = CharacterCasing.Upper
        tNama.Properties.CharacterCasing = CharacterCasing.Upper
        tAlamat.Properties.CharacterCasing = CharacterCasing.Upper
        tKota.Properties.CharacterCasing = CharacterCasing.Upper
        tPropinsi.Properties.CharacterCasing = CharacterCasing.Upper
        tNamaCP.Properties.CharacterCasing = CharacterCasing.Upper
        mKeterangan.Properties.CharacterCasing = CharacterCasing.Upper
        If Me.Tag <> "" Then pKode = Me.Tag

        loadDetail()
    End Sub

    Sub loadDetail()
        Dim pQuery As String = ""
        pQuery = "select Kode,Nama,Alamat,Kota,KodePos,Propinsi,Telepon1,Telepon2,Faks,NamaCP,Keterangan,UserEntry,DateTimeEntry,UserUpdate,DateTimeUpdate from mstEkspedisi where Kode = '" & pKode & "'"
        db.FillMe(pQuery, True)

        If db.Rows.Count > 0 Then
            isNew = False
            FillFormFromDataRow(Me, db.Rows(0))
            SetTextReadOnly({tKode})
        Else
            ClearValue(Me)
            isNew = True
            SetTextReadOnly({tKode}, False)
        End If
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Close()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        tKode.Text = Trim(tKode.Text)
        tNama.Text = Trim(tNama.Text)
        tAlamat.Text = Trim(tAlamat.Text)
        tKota.Text = Trim(tKota.Text)
        tKodePos.Text = Trim(tKodePos.Text)
        tPropinsi.Text = Trim(tPropinsi.Text)
        tTelepon1.Text = Trim(tTelepon1.Text)
        tTelepon2.Text = Trim(tTelepon2.Text)
        tFaks.Text = Trim(tFaks.Text)
        tNamaCP.Text = Trim(tNamaCP.Text)
        mKeterangan.Text = Trim(mKeterangan.Text)
        If CheckBeforeSave({tKode, tNama, tAlamat, tKota, tPropinsi, tTelepon1}) = True Then
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
                drow!Kota = tKota.Text
                drow!KodePos = tKodePos.Text
                drow!Propinsi = tPropinsi.Text
                drow!Telepon1 = tTelepon1.Text
                drow!Telepon2 = tTelepon2.Text
                drow!Faks = tFaks.Text
                drow!NamaCP = tNamaCP.Text
                drow!Keterangan = mKeterangan.Text

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

    Private Sub tKode_Validated(sender As Object, e As EventArgs) Handles tKode.Validated
        Dim pQuery As String = ""
        pQuery = "select Kode,Nama,Alamat,Kota,KodePos,Propinsi,Telepon1,Telepon2,Faks,NamaCP,Keterangan,UserEntry,DateTimeEntry,UserUpdate,DateTimeUpdate from mstEkspedisi where Kode = '" & tKode.Text & "'"
        db.FillMe(pQuery, True)

        If db.Rows.Count > 0 Then
            isNew = False
            FillFormFromDataRow(Me, db.Rows(0))
        Else
            ClearValue(Me, {"tKode"})
            isNew = True
        End If
    End Sub

    Private Sub tTelepon1_EditValueChanged(sender As Object, e As EventArgs) Handles tTelepon1.EditValueChanged
        If Not IsNumeric(tTelepon1.Text) Then
            tTelepon1.Text = "0"
        End If
    End Sub

    Private Sub tTelepon2_EditValueChanged(sender As Object, e As EventArgs) Handles tTelepon2.EditValueChanged
        If Not IsNumeric(tTelepon2.Text) Then
            tTelepon2.Text = "0"
        End If
    End Sub

    Private Sub tFaks_EditValueChanged(sender As Object, e As EventArgs) Handles tFaks.EditValueChanged
        If Not IsNumeric(tFaks.Text) Then
            tFaks.Text = "0"
        End If
    End Sub
End Class