Imports meCore
Public Class frmTerimaEkspedisi
    Dim isNew As Boolean = True
    Dim db As New cMeDB
    Dim pKode As String = "asdjaksdjqi01298310owueqiowueakdh"
    Dim pubKodeUnit As String = "601"
    Dim pubUserInit As String = "FAN"

    Sub loadDetail()
        Dim pQuery As String = "Select * from trTerimaEkspedisi where Faktur = '" & pKode & "'"
        db.FillMe(pQuery, True)
        pubUserEntry = "FANI"
        If db.Rows.Count > 0 Then
            isNew = False
            FillFormFromDataRow(Me, db.Rows(0))
            SetTextReadOnly({tFaktur, dTglTerima, cCaraKirim, cKdEkspedisi, tNamaEkspedisi, tNoNota, tDari, tJenisBarang, nBeratBrg, nJumlahBrg, cSatuanJum, nTotal, tPembawa, tPenerima, mKeterangan})
        Else
            ClearValue(Me)
            SetTextReadOnly({tFaktur}, True)
            isNew = True
            cCaraKirim.Text = "MELALUI EKSPEDISI"
            cSatuanJum.Text = "Koli"
            fakturotomatis()
        End If
    End Sub
    Private Sub frmTerimaEkspedisi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.Tag <> "" Then pKode = Me.Tag
        tFaktur.Properties.CharacterCasing = CharacterCasing.Upper
        tNamaEkspedisi.Properties.CharacterCasing = CharacterCasing.Upper
        tNoNota.Properties.CharacterCasing = CharacterCasing.Upper
        tDari.Properties.CharacterCasing = CharacterCasing.Upper
        tJenisBarang.Properties.CharacterCasing = CharacterCasing.Upper
        tPembawa.Properties.CharacterCasing = CharacterCasing.Upper
        tPenerima.Properties.CharacterCasing = CharacterCasing.Upper
        mKeterangan.Properties.CharacterCasing = CharacterCasing.Upper

        isiekspedisi()
        loadDetail()
    End Sub

    Sub isiekspedisi()
        Dim p As String = "select Kode,Nama from mstEkspedisi"
        cKdEkspedisi.FirstInit(PubConnStr, p, {tNamaEkspedisi})
    End Sub

    Sub fakturotomatis()
        tFaktur.Text = GetNewFakturSQLServ(PubConnStr, "trTerimaEkspedisi", "Faktur", pubKodeUnit & pubUserInit & "-TE", Date.Now.ToString("yyMMdd"), 5, "")
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If CheckBeforeSave({tFaktur, tDari}) = True Then
            Try
                Dim drow As DataRow
                If isNew = True Then
                    drow = db.NewRow
                Else
                    drow = db.Rows(0)
                End If

                drow!Faktur = tFaktur.Text
                drow!Dari = tDari.Text
                drow!CaraKirim = cCaraKirim.Text
                drow!KdEkspedisi = cKdEkspedisi.Text
                drow!TglTerima = dTglTerima.Text
                drow!NoNota = tNoNota.Text
                drow!JenisBarang = tJenisBarang.Text
                drow!JumlahBrg = CInt(nJumlahBrg.Text)
                drow!SatuanJum = cSatuanJum.Text
                drow!BeratBrg = CInt(nBeratBrg.Text)
                drow!SatuanBrt = cSatuanJum.Text
                drow!Total = CInt(nTotal.Text)
                drow!Pembawa = tPembawa.Text
                drow!Penerima = tPenerima.Text
                drow!Keterangan = mKeterangan.Text
                drow!UserEntry = pubUserEntry
                drow!DateTimeEntry = Now

                If isNew Then db.Rows.Add(drow)
                db.UpdateMeToRealDBNoTry()
                Pesan({IIf(isNew = True, "Simpan", "Update") & " Data BERHASIL"})
            Catch ex As Exception
                Pesan({"GAGAL SIMPAN DATA", "", "Err : " & ex.Message.ToString})
            End Try
        End If
    End Sub

    Private Sub cCaraKirim_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cCaraKirim.SelectedIndexChanged
        If cCaraKirim.Text = "MELALUI EKSPEDISI" Then
            cKdEkspedisi.Enabled = True
            tNoNota.Enabled = True
        Else
            cKdEkspedisi.Enabled = False
            tNoNota.Enabled = False
            cKdEkspedisi.Text = ""
            tNoNota.Text = ""
            tNamaEkspedisi.Text = ""
        End If
    End Sub
End Class