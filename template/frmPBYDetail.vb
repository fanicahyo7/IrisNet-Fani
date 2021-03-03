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
            dgList.FirstInit(querygrid, {0.8, 1, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8}, , {"CashBack", "Ongkir", "LainLain", "LebihKurang"})
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
End Class


