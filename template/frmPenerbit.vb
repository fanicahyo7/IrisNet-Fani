Imports meCore
Public Class frmPenerbit
    Dim isNew As Boolean = True
    Dim db As New cMeDB
    Dim pKode As String = "asdjaksdjqi01298310owueqiowueakdh"
    Private Sub frmPenerbit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tKode.Properties.CharacterCasing = CharacterCasing.Upper
        tNama.Properties.CharacterCasing = CharacterCasing.Upper
        tAlamat.Properties.CharacterCasing = CharacterCasing.Upper
        tKota.Properties.CharacterCasing = CharacterCasing.Upper
        tPropinsi.Properties.CharacterCasing = CharacterCasing.Upper
        tEmail.Properties.CharacterCasing = CharacterCasing.Upper
        tAlamatKirim.Properties.CharacterCasing = CharacterCasing.Upper
        tKotaKirim.Properties.CharacterCasing = CharacterCasing.Upper
        tKodePosKirim.Properties.CharacterCasing = CharacterCasing.Upper
        tPropinsiKirim.Properties.CharacterCasing = CharacterCasing.Upper
        tNamaCP.Properties.CharacterCasing = CharacterCasing.Upper
        tJabatanCP.Properties.CharacterCasing = CharacterCasing.Upper
        tAtasNama.Properties.CharacterCasing = CharacterCasing.Upper
        mKeterangan.Properties.CharacterCasing = CharacterCasing.Upper

        rJenis.SelectedIndex = 0
        cAlamatPerusahaan.Checked = True
        isiwilayah()
        tBank.Enabled = False
        tCabang.Enabled = False
        tNoAccount.Enabled = False
        tAtasNama.Enabled = False

        koneksi()

        If Me.Tag <> "" Then pKode = Me.Tag

        loadDetail()

    End Sub
    Sub loadDetail()
        Dim pQuery As String = ""
        pQuery = "select Jenis,Kode,Nama,Alamat,Kota,FlagActive,KodePos,Propinsi,Telepon1,Telepon2," & _
            "Faks,Email,Wilayah,KdTipe,AlamatKirim,KotaKirim,KodePosKirim,PropinsiKirim,NPWP," & _
            "PKP,NamaCP,JabatanCP,HandphoneCP,Lama,CreditLimit,Discount,DiscLevel,Bank," & _
            "NoAccount,AtasNama,Keterangan,UserEntry,DateTimeEntry,UserUpdate,DateTimeUpdate " & _
            "from mstPenerbit where Kode = '" & pKode & "'"
        db.FillMe(pQuery, True)

        If db.Rows.Count > 0 Then
            isNew = False
            FillFormFromDataRow(Me, db.Rows(0))
            SetTextReadOnly({tKode})
            If cPKP.Text = "True" Then
                cPKP.SelectedIndex = 0
            Else
                cPKP.SelectedIndex = 1
            End If
            cekalamat()
        Else
            ClearValue(Me)
            isNew = True
            SetTextReadOnly({tKode}, False)
        End If
    End Sub
    Private Sub rJenis_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rJenis.SelectedIndexChanged
        If rJenis.SelectedIndex = 1 Then
            LayoutControlGroup4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlGroup3.Text = "Alamat Lengkap"
        Else
            LayoutControlGroup4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlGroup3.Text = "Alamat Perusahaan"
        End If
    End Sub

    Private Sub cAlamatPerusahaan_CheckedChanged(sender As Object, e As EventArgs) Handles cAlamatPerusahaan.CheckedChanged
        If cAlamatPerusahaan.Checked = True Then
            SetTextReadOnly({tAlamatKirim, tKotaKirim, tKodePosKirim, tPropinsiKirim}, True)
            tAlamatKirim.Text = tAlamat.Text
            tKotaKirim.Text = tKota.Text
            tKodePosKirim.Text = tKodePos.Text
            tPropinsiKirim.Text = tPropinsi.Text
        Else
            SetTextReadOnly({tAlamatKirim, tKotaKirim, tKodePosKirim, tPropinsiKirim}, False)
        End If
    End Sub

    Private Sub tAlamat_EditValueChanged(sender As Object, e As EventArgs) Handles tAlamat.EditValueChanged
        If cAlamatPerusahaan.Checked = True Then
            tAlamatKirim.Text = tAlamat.Text
        End If
    End Sub

    Private Sub tKota_EditValueChanged(sender As Object, e As EventArgs) Handles tKota.EditValueChanged
        If cAlamatPerusahaan.Checked = True Then
            tKotaKirim.Text = tKota.Text
        End If
    End Sub

    Private Sub tKodePos_EditValueChanged(sender As Object, e As EventArgs) Handles tKodePos.EditValueChanged
        If cAlamatPerusahaan.Checked = True Then
            tKodePosKirim.Text = tKodePos.Text
        End If
    End Sub

    Private Sub tPropinsi_EditValueChanged(sender As Object, e As EventArgs) Handles tPropinsi.EditValueChanged
        If cAlamatPerusahaan.Checked = True Then
            tPropinsiKirim.Text = tPropinsi.Text
        End If
    End Sub

    Private Sub btnWilayah_Click(sender As Object, e As EventArgs) Handles btnWilayah.Click
        Using xx As New frmDetailGudang
            xx.Text = "Master Wilayah"
            xx.ShowDialog(Me)
            isiwilayah()
        End Using
    End Sub
    Sub isiwilayah()
        Dim sql As String = "select Kode,Keterangan from mstWilayah order by Kode"
        cWilayah.FirstInit(PubConnStr, sql, {tNamaWilayah})
    End Sub

    Private Sub tKode_EditValueChanged(sender As Object, e As EventArgs) Handles tKode.EditValueChanged

    End Sub
    Sub cekalamat()
        If tAlamatKirim.Text = tAlamat.Text And tKotaKirim.Text = tKota.Text And tKodePosKirim.Text = tKodePos.Text And tPropinsiKirim.Text = tPropinsi.Text Then
            cAlamatPerusahaan.Checked = True
        Else
            cAlamatPerusahaan.Checked = False
        End If
    End Sub
    Private Sub tKode_Validated(sender As Object, e As EventArgs) Handles tKode.Validated
        pKode = tKode.Text
        Dim pQuery As String = ""
        pQuery = "select Jenis,Kode,Nama,Alamat,Kota,FlagActive,KodePos,Propinsi,Telepon1,Telepon2," & _
            "Faks,Email,Wilayah,KdTipe,AlamatKirim,KotaKirim,KodePosKirim,PropinsiKirim,NPWP," & _
            "PKP,NamaCP,JabatanCP,HandphoneCP,Lama,CreditLimit,Discount,DiscLevel,Bank," & _
            "NoAccount,AtasNama,Keterangan,UserEntry,DateTimeEntry,UserUpdate,DateTimeUpdate " & _
            "from mstPenerbit where Kode = '" & pKode & "'"
        db.FillMe(pQuery, True)

        If db.Rows.Count > 0 Then
            isNew = False
            FillFormFromDataRow(Me, db.Rows(0))
            If cPKP.Text = "True" Then
                cPKP.SelectedIndex = 0
            Else
                cPKP.SelectedIndex = 1
            End If
            cekalamat()
        Else
            ClearValue(Me, {"tKode"})
            isNew = True
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
        tEmail.Text = Trim(tEmail.Text)
        tAlamatKirim.Text = Trim(tAlamatKirim.Text)
        tKotaKirim.Text = Trim(tKotaKirim.Text)
        tKodePosKirim.Text = Trim(tKodePosKirim.Text)
        tPropinsiKirim.Text = Trim(tPropinsiKirim.Text)
        tNPWP.Text = Trim(tNPWP.Text)
        tNamaCP.Text = Trim(tNamaCP.Text)
        tJabatanCP.Text = Trim(tJabatanCP.Text)
        tHandPhoneCP.Text = Trim(tHandPhoneCP.Text)
        tCreditLimit.Text = Trim(tCreditLimit.Text)
        tDiscount.Text = Trim(tDiscount.Text)
        tNoAccount.Text = Trim(tNoAccount.Text)
        tAtasNama.Text = Trim(tAtasNama.Text)
        mKeterangan.Text = Trim(mKeterangan.Text)

        If CheckBeforeSave({tKode, tNama, tAlamat, tKota, tPropinsi, cWilayah}) = True Then
            Try
                Dim drow As DataRow
                If isNew = True Then
                    drow = db.NewRow
                Else
                    drow = db.Rows(0)
                End If

                Dim jenis As String = ""
                If rJenis.SelectedIndex = 0 Then
                    jenis = "PERUSAHAAN"
                Else
                    jenis = "PERORANGAN"
                End If
                Dim pkp As Boolean
                If cPKP.SelectedIndex = 0 Then
                    pkp = True
                Else
                    pkp = False
                End If
                drow!Jenis = jenis
                drow!Kode = tKode.Text
                drow!Nama = tNama.Text
                drow!Alamat = tAlamat.Text
                drow!Kota = tKota.Text
                drow!KodePos = tKodePos.Text
                drow!Propinsi = tPropinsi.Text
                drow!Telepon1 = tTelepon1.Text
                drow!Telepon2 = tTelepon2.Text
                drow!Faks = tFaks.Text
                drow!Email = tEmail.Text
                drow!Wilayah = cWilayah.Text
                drow!AlamatKirim = tAlamatKirim.Text
                drow!KotaKirim = tKotaKirim.Text
                drow!KodePosKirim = tKodePosKirim.Text
                drow!PropinsiKirim = tPropinsiKirim.Text
                drow!NPWP = tNPWP.Text
                drow!PKP = pkp
                drow!NamaCP = tNamaCP.Text
                drow!JabatanCP = tJabatanCP.Text
                drow!HandPhoneCP = tHandPhoneCP.Text
                drow!Lama = sLama.Value
                drow!CreditLimit = tCreditLimit.Text
                drow!Discount = tDiscount.Text
                drow!Bank = tBank.Text
                drow!NoAccount = tNoAccount.Text
                drow!AtasNama = tAtasNama.Text
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
End Class