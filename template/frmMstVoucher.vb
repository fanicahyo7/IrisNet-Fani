Imports meCore
Imports System.Data.SqlClient
Public Class frmMstVoucher
    Dim isNew As Boolean = True
    Dim db As New cMeDB
    Dim pKode As String = "asdjaksdjqi01298310owueqiowueakdh"
    Dim rst As Boolean = True
    Private Sub frmMstVoucher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tKode.Properties.CharacterCasing = CharacterCasing.Upper
        tKeterangan.Properties.CharacterCasing = CharacterCasing.Upper
        If Me.Tag <> "" Then pKode = Me.Tag
        koneksi()
        cKdSupplier.FirstInit(PubConnStr, "select Kode,Nama,Alamat from mstSupplier where status='1'", {tNamaSupplier})
        SetTextReadOnly({sStartNumber, sEndNumber})
        loadDetail()
    End Sub

    Sub loadDetail()
        Dim pQuery As String = ""
        pQuery = "select Status,Kode,Keterangan,Nominal,StartDate,ExpiredDate,StartNumber,EndNumber,UserEntry,DateTimeEntry,KdSupplier from MstVoucher where Kode = '" & pKode & "'"
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

    Sub startnumber()
        cmd = New SqlCommand("select max(SUBSTRING( EndNumber,1,10)) as max from mstVoucher", kon)
        rd = cmd.ExecuteReader
        rd.Read()
        If Not rd.HasRows Then
            sStartNumber.Text = "0000000000"
        Else
            sStartNumber.Text = Val(Strings.Mid(rd.Item("max").ToString, 1, 10)) + 1
            If Len(sStartNumber.Text) = 1 Then
                sStartNumber.Text = "000000000" & sStartNumber.Text & ""
            ElseIf Len(sStartNumber.Text) = 2 Then
                sStartNumber.Text = "00000000" & sStartNumber.Text & ""
            ElseIf Len(sStartNumber.Text) = 3 Then
                sStartNumber.Text = "0000000" & sStartNumber.Text & ""
            ElseIf Len(sStartNumber.Text) = 4 Then
                sStartNumber.Text = "000000" & sStartNumber.Text & ""
            ElseIf Len(sStartNumber.Text) = 5 Then
                sStartNumber.Text = "00000" & sStartNumber.Text & ""
            ElseIf Len(sStartNumber.Text) = 6 Then
                sStartNumber.Text = "0000" & sStartNumber.Text & ""
            ElseIf Len(sStartNumber.Text) = 7 Then
                sStartNumber.Text = "000" & sStartNumber.Text & ""
            ElseIf Len(sStartNumber.Text) = 8 Then
                sStartNumber.Text = "00" & sStartNumber.Text & ""
            ElseIf Len(sStartNumber.Text) = 9 Then
                sStartNumber.Text = "0" & sStartNumber.Text & ""
            ElseIf Len(sStartNumber.Text) = 10 Then
                sStartNumber.Text = sStartNumber.Text
            End If
        End If
        rd.Close()
    End Sub
    Sub endnumber()
        Dim endnovoucher As String
        endnovoucher = Val(Strings.Mid(sStartNumber.Text, 1, 10)) + (sQty.Value - 1)
        If Len(endnovoucher) = 1 Then
            sEndNumber.Text = "000000000" & endnovoucher & ""
        ElseIf Len(endnovoucher) = 2 Then
            sEndNumber.Text = "00000000" & endnovoucher & ""
        ElseIf Len(endnovoucher) = 3 Then
            sEndNumber.Text = "0000000" & endnovoucher & ""
        ElseIf Len(endnovoucher) = 4 Then
            sEndNumber.Text = "000000" & endnovoucher & ""
        ElseIf Len(endnovoucher) = 5 Then
            sEndNumber.Text = "00000" & endnovoucher & ""
        ElseIf Len(endnovoucher) = 6 Then
            sEndNumber.Text = "0000" & endnovoucher & ""
        ElseIf Len(endnovoucher) = 7 Then
            sEndNumber.Text = "000" & endnovoucher & ""
        ElseIf Len(endnovoucher) = 8 Then
            sEndNumber.Text = "00" & endnovoucher & ""
        ElseIf Len(endnovoucher) = 9 Then
            sEndNumber.Text = "0" & endnovoucher & ""
        ElseIf Len(endnovoucher) = 10 Then
            sEndNumber.Text = endnovoucher
        End If
    End Sub

    Private Sub rJenis_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rJenis.SelectedIndexChanged
        If rJenis.SelectedIndex = 0 Then
            If rst = True Then
                ClearValue(Me, {"rJenis"})
            End If
            startnumber()
            SetTextReadOnly({cKdSupplier})
            sQty.Enabled = True
        Else
            If rst = True Then
                ClearValue(Me, {"rJenis", "cKdSupplier"})
            End If
            SetTextReadOnly({cKdSupplier}, False)
            sQty.Enabled = False
        End If
        rst = True
    End Sub

    Private Sub sQty_EditValueChanged(sender As Object, e As EventArgs) Handles sQty.EditValueChanged
        endnumber()
    End Sub

    Private Sub sQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles sQty.KeyPress
        If (e.KeyChar = Chr(13)) Then
            endnumber()
        End If
    End Sub

    Private Sub tKode_Validated(sender As Object, e As EventArgs) Handles tKode.Validated
        pKode = tKode.Text
        Dim pQuery As String = ""
        pQuery = "select Status,Kode,Keterangan,Nominal,StartDate,ExpiredDate,StartNumber,EndNumber,UserEntry,DateTimeEntry,KdSupplier from MstVoucher where Kode = '" & pKode & "'"
        db.FillMe(pQuery, True)
        rst = False
        If db.Rows.Count > 0 Then
            isNew = False
            FillFormFromDataRow(Me, db.Rows(0))
            sQty.Value = (Val(sEndNumber.Text) - Val(sStartNumber.Text)) + 1
            If cKdSupplier.Text = "" Then
                rJenis.SelectedIndex = 0
            Else
                rJenis.SelectedIndex = 1
            End If
        Else
            isNew = True
        End If
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Close()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        tKode.Text = Trim(tKode.Text)
        tKeterangan.Text = Trim(tKeterangan.Text)

        If CheckBeforeSave({tKode, tKeterangan, sNominal}) = True Then
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

                    drow!Status = 1
                    drow!Kode = tKode.Text
                    drow!Keterangan = tKeterangan.Text
                    drow!StartDate = dStartDate.Text
                    drow!ExpiredDate = dExpiredDate.Text
                    drow!Nominal = sNominal.Value
                    drow!StartNumber = sStartNumber.Text
                    drow!EndNumber = sEndNumber.Text
                    drow!KdSupplier = cKdSupplier.Text

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