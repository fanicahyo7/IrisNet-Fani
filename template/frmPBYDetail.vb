Imports meCore
Imports System.Data.SqlClient

Public Class frmPBYDetail
    Dim kumpulanctr As String = ""
    Dim index As Integer = 0
    Dim status As String = ""
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(noctr As String, index As Integer, status As String)
        InitializeComponent()
        Me.kumpulanctr = noctr
        Me.index = index - 1
        Me.status = status
    End Sub
    Private Sub frmPBYDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        cTransferKe.Enabled = False
        SetTextReadOnly({tNoCtr, tNoPengajuan, tKdSupplier, tNamaSupplier, tTglPengajuan, tBank, tNoRek, tAtasNama, sTerjual, sCashBack, sOngkir, sLainLain, sLebihKurang, sPengajuan, sPembulatan, sBiayaTrans, sTransfer})

        sPengajuan.Properties.Mask.UseMaskAsDisplayFormat = True
        sTerjual.Properties.Mask.UseMaskAsDisplayFormat = True
        sCashBack.Properties.Mask.UseMaskAsDisplayFormat = True
        sOngkir.Properties.Mask.UseMaskAsDisplayFormat = True
        sLainLain.Properties.Mask.UseMaskAsDisplayFormat = True
        sLebihKurang.Properties.Mask.UseMaskAsDisplayFormat = True
        sPromo.Properties.Mask.UseMaskAsDisplayFormat = True
        sBiayaTrans.Properties.Mask.UseMaskAsDisplayFormat = True
        sPembulatan.Properties.Mask.UseMaskAsDisplayFormat = True
        sTransfer.Properties.Mask.UseMaskAsDisplayFormat = True

        tNoCtr.Text = Strings.Split(kumpulanctr, ",")(index)
        refreshpage()

        btnNext.Enabled = False
        btnPrevious.Enabled = False

        tombolnextprev()

        btnDeposit.Enabled = False
        btnFaktur.Enabled = False
    End Sub

    Sub refreshhalaman()
        Dim db As New cMeDB
        Dim query As String = "select * from trPengajuanBayarHd where NoCtr ='" & tNoCtr.Text & "'"
        db.FillMe(query, True)

        If db.Rows.Count > 0 Then
            FillFormFromDataRow(Me, db.Rows(0))
        End If
    End Sub

    Sub refreshpage()
        refreshhalaman()
        Dim querygrid As String = "select Faktur, FakturAsli, TglFaktur, TerJual, CashBack, Ongkir, LainLain, LebihKurang, Pengajuan from vwPengajuanBayarDt where noCTR = '" & tNoCtr.Text & "' and (terjual <> 0 or LainLain<>0) order by nopengajuan,nobtt,TglFaktur,faktur"
        If status.ToUpper = "KIRIM PENGAJUAN KE PUSAT" Then
            SetTextReadOnly({sPromo})
            dgList.FirstInit(querygrid, {0.8, 1, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8})
            btnHapus.Enabled = False
            btnFaktur.Enabled = False
            btnDeposit.Enabled = False
        Else
            If cTransferKe.Text.ToUpper = "OPERASIONAL" Then
                dgList.FirstInit(querygrid, {0.8, 1, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8}, , {"LainLain"})
                SetTextReadOnly({sPromo})
            Else
                dgList.FirstInit(querygrid, {0.8, 1, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8}, , {"CashBack", "Ongkir", "LainLain", "LebihKurang"})
            End If
            btnHapus.Enabled = True
            btnFaktur.Enabled = True
            btnDeposit.Enabled = True
        End If
        dgList.RefreshData(False)
    End Sub

    Sub tombolnextprev()
        If index > 0 And index < (Strings.Split(kumpulanctr, ",").Length - 2) Then
            btnNext.Enabled = True
            btnPrevious.Enabled = True
        ElseIf index = 0 And index < (Strings.Split(kumpulanctr, ",").Length - 2) Then
            btnNext.Enabled = True
            btnPrevious.Enabled = False
        ElseIf index = 0 And index = (Strings.Split(kumpulanctr, ",").Length - 2) Then
            btnNext.Enabled = False
            btnPrevious.Enabled = False
        ElseIf index = (Strings.Split(kumpulanctr, ",").Length - 2) Then
            btnNext.Enabled = False
            btnPrevious.Enabled = True
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        index += 1
        tombolnextprev()
        tNoCtr.Text = Strings.Split(kumpulanctr, ",")(index)
        refreshpage()
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        index -= 1
        tombolnextprev()
        tNoCtr.Text = Strings.Split(kumpulanctr, ",")(index)
        refreshpage()
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Me.Close()
    End Sub

    Private Sub dgList_Grid_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles dgList.Grid_ValidateRow
        If IsDBNull(dgList.GetRowCellValue(e.RowHandle, "CashBack")) Then
            dgList.SetRowCellValue(e.RowHandle, "CashBack", 0)
        End If
        If IsDBNull(dgList.GetRowCellValue(e.RowHandle, "Ongkir")) Then
            dgList.SetRowCellValue(e.RowHandle, "Ongkir", 0)
        End If
        If IsDBNull(dgList.GetRowCellValue(e.RowHandle, "LebihKurang")) Then
            dgList.SetRowCellValue(e.RowHandle, "LebihKurang", 0)
        End If
        If IsDBNull(dgList.GetRowCellValue(e.RowHandle, "LainLain")) Then
            dgList.SetRowCellValue(e.RowHandle, "LainLain", 0)
        End If

        dgList.SetRowCellValue(e.RowHandle, "CashBack", (dgList.GetRowCellValue(e.RowHandle, "CashBack") * -1))
        Dim query As String = _
            "Update trPengajuanBayarDT Set CashBack = '" & dgList.GetRowCellValue(e.RowHandle, "CashBack") & "', Ongkir = '" & dgList.GetRowCellValue(e.RowHandle, "Ongkir") & "', LebihKurang = '" & dgList.GetRowCellValue(e.RowHandle, "LebihKurang") & "', LainLain = '" & dgList.GetRowCellValue(e.RowHandle, "LainLain") & "' Where NoCtr = '" & tNoCtr.Text & "' and Faktur = '" & dgList.GetRowCellValue(e.RowHandle, "Faktur") & "'"
        cmd = New SqlCommand(query, kon)
        cmd.ExecuteNonQuery()

        refreshhalaman()
    End Sub

    Private Sub sPromo_Validated(sender As Object, e As EventArgs) Handles sPromo.Validated
        Dim query As String = "Update trPengajuanBayarHD Set TransferKe = '" & cTransferKe.Text.ToUpper & "', Promo = '" & sPromo.EditValue & "', Bank = '" & tBank.Text & "', AtasNama = '" & tAtasNama.Text & "', NoRek = '" & tNoRek.Text & "' Where NoCtr = '" & tNoCtr.Text & "'"
        cmd = New SqlCommand(query, kon)
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        Dim faktur As String = dgList.GetRowCellValue(dgList.FocusedRowHandle, "Faktur")
        If Not faktur = "" Then
            Dim query As String = "select sum(terjual) as Pengajuan from trPengajuanBayarDT where faktur <> '" & faktur & "' and noctr='" & tNoCtr.Text & "'"
            cmd = New SqlCommand(query, kon)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                If Not IsDBNull(rd!Pengajuan) Then
                    If rd!Pengajuan < 0 Then
                        rd.Close()
                        MsgBox("Nilai Pengajuan Bayar Hutang Supplier Tidak Boleh Minus.", vbCritical + vbOKOnly, "Informasi")
                        Exit Sub
                    End If
                End If
            Else
                rd.Close()
                Exit Sub
            End If
            rd.Close()

            If Len(faktur) <> 0 Then
                Dim konfirmasi = MsgBox("HAPUS FAKTUR " & faktur & " ?", vbYesNo + vbQuestion, "Konfirmasi")
                If konfirmasi = vbYes Then
                    Dim where As String = "Faktur"
                    If (Len(faktur) = 8) And dgList.GetRowCellValue(dgList.FocusedRowHandle, "FakturAsli").ToString.ToUpper = "PERHITUNGAN" Then
                        where = "Faktur"
                    ElseIf Strings.Mid(faktur, 8, 2).ToUpper = "PH" Then
                        where = "FakturAsli"
                    End If
                    Dim qhps As String = _
                        "Delete from trPengajuanBayarDt where " & where & " = '" & faktur & "' and NoCtr = '" & tNoCtr.Text & "'"
                    cmd = New SqlCommand(qhps, kon)
                    cmd.ExecuteNonQuery()
                End If
            End If
        End If
        refreshpage()
    End Sub

    Private Sub btnFaktur_Click(sender As Object, e As EventArgs) Handles btnFaktur.Click
        Dim query As String = _
            "Select top 1 sum(Pengajuan) as hasil from trPengajuanBayarHD where NoPengajuan ='" & tNoPengajuan.Text & "'"
        cmd = New SqlCommand(query, kon)
        rd = cmd.ExecuteReader
        rd.Read()
        Dim jml As Double = 0
        If rd.HasRows Then
            jml = rd!hasil
        End If
        rd.Close()
        Dim query2 As String = "select top 1 * from trPengajuanBayarHd where NoPengajuan ='" & tNoPengajuan.Text & "'"
        cmd = New SqlCommand(query2, kon)
        rd = cmd.ExecuteReader
        rd.Read()
        Dim transfer As String = ""
        Dim kategori As String = ""
        If rd.HasRows Then
            transfer = rd!TransferKe
            kategori = rd!Kategori
        End If
        rd.Close()
        Using xx As New frmPBYAdd(tNoPengajuan.Text, jml, "", "Retur Beli", transfer)
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub btnDeposit_Click(sender As Object, e As EventArgs) Handles btnDeposit.Click
        Dim query As String = _
           "Select top 1 sum(Pengajuan) as hasil from trPengajuanBayarHD where NoPengajuan ='" & tNoPengajuan.Text & "'"
        cmd = New SqlCommand(query, kon)
        rd = cmd.ExecuteReader
        rd.Read()
        Dim jml As Double = 0
        If rd.HasRows Then
            jml = rd!hasil
        End If
        rd.Close()
        Dim query2 As String = "select top 1 * from trPengajuanBayarHd where NoPengajuan ='" & tNoPengajuan.Text & "'"
        cmd = New SqlCommand(query2, kon)
        rd = cmd.ExecuteReader
        rd.Read()
        Dim transfer As String = ""
        Dim kategori As String = ""
        If rd.HasRows Then
            transfer = rd!TransferKe
            kategori = rd!Kategori
        End If
        rd.Close()
        Using xx As New frmPBYAdd(tNoPengajuan.Text, jml, kategori.ToUpper, "Deposit", transfer)
            xx.ShowDialog(Me)
        End Using
    End Sub
End Class


