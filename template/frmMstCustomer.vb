Imports meCore
Public Class frmMstCustomer
    Dim isNew As Boolean = True
    Dim pKode As String = "asdjaksdjqi01298310owueqiowueakdh"

    Dim pQuery As String = _
        "Select Status, Jenis, NamaPerusahaan, NamaPemilik, AlamatNPWPKTP, " & _
        "       KotaNPWP, KodePosNPWP, Alamat, Kota, KodePos, " & _
        "       Propinsi, Telepon1, Telepon2, Faks, Handphone, " & _
        "       Email, StatusPajak, Bendaharawan, NamaCP, JabatanCP, " & _
        "       TelponCP, HandPhoneCP, EmailCP, StatusKerjaSama, TerminKredit, " & _
        "       PIC, AlamatKirim, KotaKirim, PropinsiKirim, KodePosKirim, " & _
        "       TelponKirim, HandPhoneKirim, StatusNPWP, NPWP, SuratPernyataanBermaterai, " & _
        "       StatusKTP, KTP, NoPKP, PKP, PenunjukanBendahara, " & _
        "       KeteranganDomisili, StatusKTPPIC, KTPPIC, StatusKartuPegawai, KartuPegawai, " & _
        "       PermintaanData, Transaksi, Nama, Kode, UserEntry, DatetimeEntry, UserUpdate, DatetimeUpdate, StatusSPK " & _
        "from mstCustomer where Kode = '@Kode'"

    Private Sub mstCustomer_Load(sender As Object, e As EventArgs) Handles Me.Load
        initForm(Me, EnfrmSizeNotMax.efsnm0Default, DevExpress.XtraLayout.MoveFocusDirection.AcrossThenDown)
        If Me.Tag <> "" Then pKode = Me.Tag

        SetTextReadOnly({tKartuPegawai, tKTPPIC, tNoPKP, tKTP, tNPWP})
        loadDetail()
        lciCekKode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never


        Dim scrollBar As DevExpress.XtraEditors.VScrollBar = LayoutControl1.Controls.OfType(Of DevExpress.XtraEditors.VScrollBar)().FirstOrDefault()
        If scrollBar IsNot Nothing Then
            scrollBar.Value = 0 'your value here  
        End If

        tKodePos.Properties.MaxLength = 5
        tKodePosKirim.Properties.MaxLength = 5
        tKodePosNPWP.Properties.MaxLength = 5
        tKodeUnit.Text = pubKodeUnit & "."
        SetTextReadOnly({tKodeUnit})
    End Sub

    Sub loadDetail()
        'Dim pKodeUnit As String = Mid(pKode, 1, 3)
        'Dim pKodetmp As String = Mid(pKode, 4, 50)

        Dim dRow As DataRow = Nothing
        Dim dbt As New cMeDB
        Try
            Dim pQue As String = pQuery.Replace("@Kode", pKode)
            dbt.FillMe(pQue, , , , , False)
        Catch ex As Exception
            Pesan({"err : " & ex.Message.ToString})
        End Try

        If dbt.Rows.Count > 0 Then
            isNew = False
            FillFormFromDataRow(Me, dbt.Rows(0))
            SetTextReadOnly({tKode})
            tKode.Text = Mid(tKode.Text, 5, 50)

            Select Case tJenis.Text
                Case "PT", "PERUSAHAAN" : rJenis.SelectedIndex = 0
                Case "CV" : rJenis.SelectedIndex = 1
                Case "UD" : rJenis.SelectedIndex = 2
                Case "PERORANGAN" : rJenis.SelectedIndex = 3
                Case Else : rJenis.SelectedIndex = 4
            End Select


            If tStatusPajak.Text = "0" Or tStatusPajak.Text = "" Then
                rStatusPajak.SelectedIndex = 0
            Else
                rStatusPajak.SelectedIndex = 1
            End If

            If tBendaharawan.Text = "0" Or tBendaharawan.Text = "" Then
                rBendaharawan.SelectedIndex = 0
            Else
                rBendaharawan.SelectedIndex = 1
            End If

            If tStatusKerjaSama.Text = "0" Or tStatusKerjaSama.Text = "" Then
                rStatusKerjaSama.SelectedIndex = 0
            Else
                rStatusKerjaSama.SelectedIndex = 1
            End If
            CekKodeIsExist()
            rJenis.Focus()
        Else
            btnSImpan.Enabled = False
            ClearValue(Me)
            rJenis.Focus()
        End If
    End Sub

    Private Sub btnSImpan_Click(sender As Object, e As EventArgs) Handles btnSImpan.Click
        If rJenis.Properties.Items(rJenis.SelectedIndex).Description.ToUpper = "PERORANGAN" Then
            If CheckBeforeSave({cStatus, rJenis, tAlamat, tKota, tKodePos, _
                    tPropinsi, tTelepon1, _
                    rBendaharawan, _
                    rStatusKerjaSama, tTerminKredit, _
                    rTransaksi, tNama, tKode}) = False Then Exit Sub
        Else
            If CheckBeforeSave({cStatus, rJenis, tAlamat, tKota, tKodePos, _
                    tPropinsi, tTelepon1, tTelepon2, tFaks, tHandphone, _
                    tEmail, rBendaharawan, tNamaCP, tJabatanCP, tTelponCP, _
                    tHandPhoneCP, tEmailCP, rStatusKerjaSama, tTerminKredit, tPIC, _
                    tAlamatKirim, tKotaKirim, tPropinsiKirim, tKodePosKirim, tTelponKirim, _
                    tHandPhoneKirim, rTransaksi, tNama, tKode}) = False Then Exit Sub
        End If

        If cStatusNPWP.Checked Then If CheckBeforeSave({tNPWP}) = False Then Exit Sub
        If cStatusKTP.Checked Then If CheckBeforeSave({tKTP}) = False Then Exit Sub
        If cPKP.Checked Then If CheckBeforeSave({tNoPKP}) = False Then Exit Sub
        If cStatusKTPPIC.Checked Then If CheckBeforeSave({tKTPPIC}) = False Then Exit Sub
        If cStatusKartuPegawai.Checked Then If CheckBeforeSave({tKartuPegawai}) = False Then Exit Sub

        Dim isNewx As Boolean = True
        Dim drow As DataRow = Nothing

        Using dbt As New cMeDB
            Try
                Dim pKodetmp As String = pubKodeUnit & "." & tKode.Text
                Dim pQue As String = pQuery.Replace("@Kode", pKodetmp)
                dbt.FillMe(pQue)
                If dbt.Rows.Count > 0 Then
                    drow = dbt.Rows(0)
                    isNewx = False
                Else
                    drow = dbt.NewRow
                End If

                drow!Status = cStatus.Checked
                drow!Jenis = rJenis.Properties.Items(rJenis.SelectedIndex).Description
                drow!NamaPerusahaan = tNamaPerusahaan.Text
                drow!NamaPemilik = tNamaPemilik.Text
                drow!AlamatNPWPKTP = tAlamatNPWPKTP.Text
                drow!KotaNPWP = tKotaNPWP.Text
                drow!KodePosNPWP = tKodePosNPWP.Text
                drow!Alamat = tAlamat.Text
                drow!Kota = tKota.Text
                drow!KodePos = tKodePos.Text
                drow!Propinsi = tPropinsi.Text
                drow!Telepon1 = tTelepon1.Text
                drow!Telepon2 = tTelepon2.Text
                drow!Faks = tFaks.Text
                drow!HandPhone = tHandphone.Text
                drow!Email = tEmail.Text
                drow!StatusPajak = rStatusPajak.SelectedIndex.ToString
                drow!Bendaharawan = rBendaharawan.SelectedIndex.ToString
                drow!NamaCP = tNamaCP.Text
                drow!JabatanCP = tJabatanCP.Text
                drow!TelponCP = tTelponCP.Text
                drow!HandphoneCP = tHandPhoneCP.Text
                drow!EmailCP = tEmailCP.Text
                drow!StatusKerjasama = rStatusKerjaSama.SelectedIndex
                drow!TerminKredit = tTerminKredit.Text
                drow!PIC = tPIC.Text
                drow!AlamatKirim = tAlamatKirim.Text
                drow!KotaKirim = tKotaKirim.Text
                drow!PropinsiKirim = tPropinsiKirim.Text
                drow!KodePosKirim = tKodePosKirim.Text
                drow!TelponKirim = tTelponKirim.Text
                drow!HandPhoneKirim = tHandPhoneKirim.Text
                drow!StatusNPWP = cStatusNPWP.Checked
                drow!NPWP = tNPWP.Text
                drow!SuratPernyataanBermaterai = cSuratPernyataanBermaterai.Checked
                drow!StatusKTP = cStatusKTP.Checked
                drow!KTP = tKTP.Text
                drow!PKP = cPKP.Checked
                drow!NoPKP = tNoPKP.Text
                drow!PenunjukanBendahara = cPenunjukanBendahara.Checked
                drow!KeteranganDomisili = cKeteranganDomisili.Checked
                drow!StatusKTPPIC = cStatusKTPPIC.Checked
                drow!KTPPIC = tKTPPIC.Text
                drow!StatusKartuPegawai = cStatusKartuPegawai.Checked
                drow!KartuPegawai = tKartuPegawai.Text
                drow!PermintaanData = cPermintaanData.Checked
                drow!Transaksi = rTransaksi.Properties.Items(rTransaksi.SelectedIndex).Description.ToUpper
                drow!Nama = tNama.Text
                drow!Kode = pKodetmp
                drow!StatusSPK = cStatusSPK.Checked

                If isNewx Then
                    drow!UserEntry = pubUserEntry
                    drow!DatetimeEntry = GetServerDatetime()
                    dbt.Rows.Add(drow)
                Else
                    drow!UserUpdate = pubUserEntry
                    drow!DatetimeUpdate = GetServerDatetime()
                End If

                dbt.UpdateMeToRealDBNoTry()
                Pesan({IIf(isNew = True, "Simpan", "Update") & " Data BERHASIL"})
                Me.Close()
            Catch ex As Exception
                Pesan({"GAGAL SIMPAN DATA", "", "Err : " & ex.Message.ToString})
            End Try
        End Using
    End Sub

    Private Sub cStatusNPWP_CheckedChanged(sender As Object, e As EventArgs) Handles cStatusNPWP.CheckedChanged
        SetTextReadOnly({tNPWP}, Not (cStatusNPWP.Checked))
        If cStatusNPWP.Checked = False Then tNPWP.Text = ""
    End Sub

    Private Sub cStatusKTP_CheckedChanged(sender As Object, e As EventArgs) Handles cStatusKTP.CheckedChanged
        SetTextReadOnly({tKTP}, Not (cStatusKTP.Checked))
        If cStatusKTP.Checked = False Then tKTP.Text = ""
    End Sub

    Private Sub cPKP_CheckedChanged(sender As Object, e As EventArgs) Handles cPKP.CheckedChanged
        SetTextReadOnly({tNoPKP}, Not (cPKP.Checked))
        If cPKP.Checked = False Then tNoPKP.Text = ""
    End Sub

    Private Sub cStatusKTPPIC_CheckedChanged(sender As Object, e As EventArgs) Handles cStatusKTPPIC.CheckedChanged
        SetTextReadOnly({tKTPPIC}, Not (cStatusKTPPIC.Checked))
        If cStatusKTPPIC.Checked = False Then tKTPPIC.Text = ""
    End Sub

    Private Sub cStatusKartuPegawai_CheckedChanged(sender As Object, e As EventArgs) Handles cStatusKartuPegawai.CheckedChanged
        SetTextReadOnly({tKartuPegawai}, Not (cStatusKartuPegawai.Checked))
        If cStatusKartuPegawai.Checked = False Then tKartuPegawai.Text = ""
    End Sub

    Dim dbSama As cMeDB
    Private Sub cmdCekKode_Click(sender As Object, e As EventArgs) Handles cmdCekKode.Click
        If CheckBeforeSave({tKode}) = False Then Exit Sub

        If isNew Then
            lciCekKode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            If CekKodeIsExist() = True Then
                chkKodeExist.Checked = False
                chkKodeExist.Text = "Tidak bisa diPakai"
                btnSImpan.Enabled = False
            Else
                chkKodeExist.Checked = True
                chkKodeExist.Text = "Bisa di Pakai"
                btnSImpan.Enabled = True
            End If
        Else
            lciCekKode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If
    End Sub

    Function CekKodeIsExist() As Boolean
        mdgListSama.Grid_ClearData()
        Dim pRet As Boolean = True

        Dim pKodeX As String = tKode.Text.PadRight(5, "_")
        Dim awaw As String = _
        "select Kode, Jenis, Nama, Alamat, Kota from mstcustomer where kode = '" & pubKodeUnit & "." & tKode.Text & "'"
        'dbSama = "select Kode, Jenis, Nama, Alamat, Kota from mstcustomer where kode like '%." & tKode.Text & "'"
        mdgListSama.FirstInit(awaw, {0.8, 0.8, 1, 2, 1})
        mdgListSama.RefreshData(False)

        If mdgListSama.gvMain.RowCount = 0 Then pRet = False

        'mdgListSama.DataSource = dbSama
        'mdgListSama.colWidth = {1, 0.6, 1, 2, 2, 1}
        'mdgListSama.RefreshDataView()
        'If dbSama.Rows.Count = 0 Then pRet = False
        Return pRet
    End Function
End Class