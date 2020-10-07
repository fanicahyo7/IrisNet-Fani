
Imports meCore

Public Class ctrlFilterStock
    Dim pAlias As String = ""

    Dim initHeight As Integer = 0
    Dim PopupContainerControlHeightOri As Integer

    Private isFilterSupplier As Boolean = True
    Private isFilterJenis As Boolean = True
    Private isFIlterGolongan As Boolean = True
    Private isFilterTahunSaldo As Boolean = True

    Public Property FilterTahunSaldo As Boolean
        Set(value As Boolean)
            isFilterTahunSaldo = value
            If isFilterTahunSaldo Then
                LayoutControlItem13.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutControlItem14.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutControlItem15.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutControlItem16.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutControlItem10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            Else
                LayoutControlItem13.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutControlItem14.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutControlItem15.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutControlItem16.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutControlItem10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            End If
        End Set
        Get
            Return isFilterTahunSaldo
        End Get
    End Property

    Public Property FilterGolongan As Boolean
        Get
            Return isFIlterGolongan
        End Get
        Set(value As Boolean)
            isFIlterGolongan = value
            If isFIlterGolongan Then
                lcKdGolongan.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                lcKdGolonganKet.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            Else
                lcKdGolongan.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                lcKdGolonganKet.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            End If
        End Set
    End Property

    Public Property FilterSupplier As Boolean
        Set(value As Boolean)
            isFilterSupplier = value
            If isFilterSupplier Then
                lcKdSupplier.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                lcKdSupplierKet.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            Else
                lcKdSupplier.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                lcKdSupplierKet.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            End If
        End Set
        Get
            Return isFilterSupplier
        End Get
    End Property

    Public Property FilterJenis As Boolean
        Set(value As Boolean)
            isFilterJenis = value
            If isFilterJenis Then
                lcJenis.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            Else
                lcJenis.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            End If
        End Set
        Get
            Return isFilterJenis
        End Get
    End Property

    Public Overrides Property Text As String
        Set(value As String)
            popedit.Text = value
        End Set
        Get
            Return popedit.Text
        End Get
    End Property

    Private Sub ctrlFilterStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initForm(Me, , DevExpress.XtraLayout.MoveFocusDirection.AcrossThenDown)
        popedit.Top = 0
        popedit.Left = 0
        Me.Width = popedit.Width
        Me.Height = popedit.Height
        popedit.Dock = DockStyle.Fill

        If DesignMode = False Then
            mSupplier.FirstInit(PubConnStr, "Select Kode, Nama from mstsupplier", {tSupplier}, , , , , , {1, 3})
            mGolongan.FirstInit(PubConnStr, "Select Keterangan as Nama,Kode from mstGolongan", {tGolongan}, , , , , , {1, 3})
            'mPenerbit.FirstInit(PubConnStr, "Select Kode, Nama from mstPenerbit", {tPenerbit}, , , , , , {1, 3})
        End If

        cClear.TabStop = False
        SpinClearButton({sTahunTerbit1, sTahunTerbit2, sSaldo1, sSaldo2})
    End Sub

    Public Sub setQueryAlias(aliasX As String)
        pAlias = aliasX
    End Sub

    Private Sub popedit_BeforePopup(sender As Object, e As EventArgs) Handles popedit.BeforePopup
        If cJenis.Text.Length = 0 Then cJenis.SelectedIndex = 0
        If cBukuAtk.Text.Length = 0 Then cBukuAtk.SelectedIndex = 0
        tJudul.Focus()
        tJudul.Select()
    End Sub

    Private Sub popedit_Closed(sender As Object, e As DevExpress.XtraEditors.Controls.ClosedEventArgs) Handles popedit.Closed
        Dim pQueWhereStok As String = ""
        Dim pquesupgol As String = ""
        Dim xAlias As String = IIf(pAlias.Length > 0, pAlias & ".", "")

        If tJudul.Text.Length > 0 Then pQueWhereStok &= " " & xAlias & "Judul like '%" & tJudul.Text & "%' AND"
        If mSupplier.Text.Length > 0 Then pQueWhereStok &= " " & xAlias & "KdSupplier = '" & mSupplier.Text & "' AND"
        If mGolongan.Text.Length > 0 Then pQueWhereStok &= " " & xAlias & "NamaGolongan = '" & mGolongan.Text & "' AND"
        If mPenerbit.Text.Length > 0 Then pQueWhereStok &= " " & xAlias & "KdPenerbit = '" & mPenerbit.Text & "' AND"
        If tPenyusun.Text.Length > 0 Then pQueWhereStok &= " " & xAlias & "Penyusun like '%" & tPenyusun.Text & "%' AND"
        If cJenis.Text <> "SEMUA" Then pQueWhereStok &= " " & xAlias & "Konsinyasi = " & IIf(cJenis.Text = "KONSINYASI", 1, 0) & " AND"
        If cBukuAtk.Text <> "SEMUA" Then pQueWhereStok &= " " & xAlias & "BukuAtk = '" & cBukuAtk.Text & "' AND"
        If sTahunTerbit1.EditValue > 0 And sTahunTerbit2.EditValue > 0 Then pQueWhereStok &= " " & xAlias & "Tahun BETWEEN '" & sTahunTerbit1.EditValue.ToString & "' AND '" & sTahunTerbit2.EditValue.ToString & "' AND"
        If sSaldo1.EditValue > 0 Or sSaldo2.EditValue > 0 Then pQueWhereStok &= " " & xAlias & "Saldo BETWEEN " & sSaldo1.EditValue.ToString & " AND " & sSaldo2.EditValue.ToString & " AND"


        If pQueWhereStok.Length > 0 Then pQueWhereStok = Mid(pQueWhereStok, 1, pQueWhereStok.Length - 3)
        popedit.Text = pQueWhereStok
        popedit.ToolTip = pQueWhereStok
    End Sub

    Private Sub cClear_Click(sender As Object, e As EventArgs) Handles cClear.Click
        ClearValue(PopupContainerControl1)
        cJenis.SelectedIndex = 0
        cBukuAtk.SelectedIndex = 0
    End Sub

    Private Sub cClose_Click(sender As Object, e As EventArgs) Handles cClose.Click
        popedit.ClosePopup()
    End Sub

    Private Sub mGolongan_EditValueChanged(sender As Object, e As EventArgs) Handles mGolongan.EditValueChanged

    End Sub
End Class
