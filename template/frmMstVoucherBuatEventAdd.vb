Imports meCore
Imports System.Data.SqlClient
Public Class frmMstVoucherBuatEventAdd
    Dim isNew As Boolean = True
    Dim db As New cMeDB
    Dim pKode As String = "asdjaksdjqi01298310owueqiowueakdh"
    Private Sub frmMstVoucherBuatEventAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        dTglAwal.EditValue = Now
        dTglAwalTukar.EditValue = Now
        dTglAkhir.EditValue = DateAdd(DateInterval.Day, 30, Now)
        dTglAkhirTukar.EditValue = DateAdd(DateInterval.Day, 30, Now)

        LayoutControlItem24.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        SetTextReadOnly({tKdVoucher, tNamaBarang})
        rJenisEvent.SelectedIndex = 1
        rJenisEvent.SelectedIndex = 0

        Dim tanggal2 As Date = #11/12/2015 12:00:52 AM#

        loadDetail()
    End Sub
    Sub loadDetail()
        Dim pQuery As String = ""
        pQuery = "select kdVoucher,kdTrans,Keterangan,TglAwal,TglAkhir," & _
                    "FlagVoucher,Kelipatan,Keterangan1,Keterangan2,Keterangan3," & _
                    "TglAwalTukar,TglAkhirTukar,Nilai,PaketGroup,KodeGimmick," & _
                    "Gimmick,GimmickPoint,BTSPoint,UserEntry,DateTimeEntry," & _
                    "flagVoucherQty,UserEntry,DateTimeEntry,UserUpdate,DateTimeUpdate from trEventVoucher where Kode = '" & pKode & "'"
        db.FillMe(pQuery, True)

        If db.Rows.Count > 0 Then
            isNew = False
            FillFormFromDataRow(Me, db.Rows(0))
            SetTextReadOnly({tKdVoucher})
            'Else
            '    ClearValue(Me)
            '    isNew = True
            '    SetTextReadOnly({tKdVoucher}, False)
        End If
    End Sub

    Sub fakturvoucer(ByRef kd As String)
        Dim tgl As String = Format(Now, "yyMM")
        Dim quer As String = "select max(SUBSTRING(kdVoucher,9,2)) as max from trEventVoucher where left(kdVoucher,7) = '" & kd & tgl & "'"
        cmd = New SqlCommand(quer, kon)
        rd = cmd.ExecuteReader
        rd.Read()
        If IsDBNull(rd!max) Then
            tKdVoucher.Text = "" & kd & tgl & ".01"
        Else
            tKdVoucher.Text = Val(Strings.Mid(rd.Item("max").ToString, 1, 2)) + 1
            If Len(tKdVoucher.Text) = 1 Then
                tKdVoucher.Text = "" & kd & tgl & ".0" & tKdVoucher.Text & ""
            ElseIf Len(tKdVoucher.Text) = 2 Then
                tKdVoucher.Text = "" & kd & tgl & "." & tKdVoucher.Text & ""
            End If
        End If
        rd.Close()
    End Sub

    Private Sub rJenis_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rJenis.SelectedIndexChanged
        If rJenis.SelectedIndex = 0 Then
            cPaketGroup.Checked = False
            LayoutControlItem24.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            sKelipatan.Enabled = True
            tKeterangan1.Enabled = True
            tKeterangan2.Enabled = True
            tKeterangan3.Enabled = True
        Else
            cPaketGroup.Checked = False
            LayoutControlItem24.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            sKelipatan.Enabled = False
            tKeterangan1.Enabled = False
            tKeterangan2.Enabled = False
            tKeterangan3.Enabled = False
        End If
    End Sub

    Private Sub rJenisEvent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rJenisEvent.SelectedIndexChanged
        If rJenisEvent.SelectedIndex = 0 Then
            cFlagVoucherQty.Checked = False
            tKeteranganVoucher.Text = "Berlaku Untuk Memperoleh Potongan Harga"
            cFlagVoucherQty.Enabled = True
            rJenis.Enabled = False
            dTglAwalTukar.Enabled = True
            dTglAkhirTukar.Enabled = True
            sNilai.Enabled = True
            sBTSPoint.Enabled = True
            sGimmick.Enabled = True
            sGimmickPoint.Enabled = True
            cKodeGimmick.Enabled = True
            rJenis.SelectedIndex = 0
            sKelipatan.Value = 0
            fakturvoucer("VCR")
        Else
            cFlagVoucherQty.Checked = False
            tKeteranganVoucher.Text = "Berlaku Untuk Penukaran Souvenir Saat Pengundian"
            cFlagVoucherQty.Enabled = False
            cFlagVoucherQty.Enabled = False
            rJenis.Enabled = True
            dTglAwalTukar.Enabled = False
            dTglAkhirTukar.Enabled = False
            sNilai.Enabled = False
            sBTSPoint.Enabled = False
            sGimmick.Enabled = False
            sGimmickPoint.Enabled = False
            cKodeGimmick.Enabled = False
            rJenis.SelectedIndex = 0
            sKelipatan.Value = 0
            fakturvoucer("KPN")
        End If
    End Sub

    Private Sub cFlagVoucherQty_CheckedChanged(sender As Object, e As EventArgs) Handles cFlagVoucherQty.CheckedChanged
        If cFlagVoucherQty.Checked = True Then
            dTglAwalTukar.Enabled = False
            dTglAkhirTukar.Enabled = False
            sGimmick.Enabled = False
            sGimmickPoint.Enabled = False
            cKodeGimmick.Enabled = False
            sKelipatan.Enabled = False
            sKelipatan.Value = 0
        Else
            dTglAwalTukar.Enabled = True
            dTglAkhirTukar.Enabled = True
            sGimmick.Enabled = True
            sGimmickPoint.Enabled = True
            cKodeGimmick.Enabled = True
            sKelipatan.Enabled = True
            sKelipatan.Value = 0
        End If
    End Sub

    Private Sub cPaketGroup_CheckedChanged(sender As Object, e As EventArgs) Handles cPaketGroup.CheckedChanged
        If cPaketGroup.Checked = True Then
            sKelipatan.Enabled = True
            tKeterangan1.Enabled = True
            tKeterangan2.Enabled = True
            tKeterangan3.Enabled = True
        Else
            sKelipatan.Enabled = False
            tKeterangan1.Enabled = False
            tKeterangan2.Enabled = False
            tKeterangan3.Enabled = False
        End If
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        tKdTrans.Text = Trim(tKdTrans.Text)
        tKeterangan.Text = Trim(tKeterangan.Text)
        tKeterangan1.Text = Trim(tKeterangan1.Text)
        tKeterangan2.Text = Trim(tKeterangan2.Text)
        tKeterangan3.Text = Trim(tKeterangan3.Text)

        If CheckBeforeSave({tKdVoucher, tKeterangan}) = True Then
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

                    Dim voucher As Boolean
                    If rJenisEvent.SelectedIndex = 0 Then
                        voucher = True
                    Else
                        voucher = False
                    End If

                    drow!KdVoucher = tKdVoucher.Text
                    drow!KdTrans = tKdTrans.Text
                    drow!Keterangan = tKeterangan.Text
                    drow!TglAwal = dTglAwal.Text
                    drow!TglAkhir = dTglAkhir.Text & " 23:59:59"
                    drow!FlagVoucher = voucher
                    drow!Kelipatan = sKelipatan.Value
                    drow!Keterangan1 = tKeterangan1.Text
                    drow!Keterangan2 = tKeterangan2.Text
                    drow!Keterangan3 = tKeterangan3.Text
                    drow!TglAwalTukar = dTglAwalTukar.Text
                    drow!TglAkhirTukar = dTglAkhirTukar.Text & " 23:59:59"
                    drow!Nilai = sNilai.Value
                    drow!PaketGroup = cPaketGroup.Checked
                    drow!KodeGimmick = cKodeGimmick.Text
                    drow!Gimmick = sGimmick.Value
                    drow!GimmickPoint = sGimmickPoint.Value
                    drow!BTSPoint = sBTSPoint.Value
                    drow!FlagVoucherQty = cFlagVoucherQty.Checked

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
End Class