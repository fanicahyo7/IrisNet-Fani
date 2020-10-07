<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmtrKirimEkspedisiList
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmtrKirimEkspedisiList))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.btnCetakUlang = New DevExpress.XtraEditors.SimpleButton()
        Me.btnUpdateResi = New DevExpress.XtraEditors.SimpleButton()
        Me.dgkirim = New meCore.ctrlMeDataGrid()
        Me.btnKirimEkspedisi = New DevExpress.XtraEditors.SimpleButton()
        Me.btnRefreshData = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.dTanggalAwal = New DevExpress.XtraEditors.DateEdit()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.dTanggalAkhir = New DevExpress.XtraEditors.DateEdit()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dTanggalAwal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dTanggalAwal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dTanggalAkhir.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dTanggalAkhir.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.dTanggalAkhir)
        Me.LayoutControl1.Controls.Add(Me.dTanggalAwal)
        Me.LayoutControl1.Controls.Add(Me.btnCetakUlang)
        Me.LayoutControl1.Controls.Add(Me.btnUpdateResi)
        Me.LayoutControl1.Controls.Add(Me.dgkirim)
        Me.LayoutControl1.Controls.Add(Me.btnKirimEkspedisi)
        Me.LayoutControl1.Controls.Add(Me.btnRefreshData)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(723, 546)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'btnCetakUlang
        '
        Me.btnCetakUlang.Image = CType(resources.GetObject("btnCetakUlang.Image"), System.Drawing.Image)
        Me.btnCetakUlang.Location = New System.Drawing.Point(12, 496)
        Me.btnCetakUlang.Name = "btnCetakUlang"
        Me.btnCetakUlang.Size = New System.Drawing.Size(164, 38)
        Me.btnCetakUlang.StyleController = Me.LayoutControl1
        Me.btnCetakUlang.TabIndex = 8
        Me.btnCetakUlang.Text = "Cetak Surat Jalan Ulang"
        '
        'btnUpdateResi
        '
        Me.btnUpdateResi.Location = New System.Drawing.Point(374, 36)
        Me.btnUpdateResi.Name = "btnUpdateResi"
        Me.btnUpdateResi.Size = New System.Drawing.Size(166, 22)
        Me.btnUpdateResi.StyleController = Me.LayoutControl1
        Me.btnUpdateResi.TabIndex = 7
        Me.btnUpdateResi.Text = "Update Resi"
        '
        'dgkirim
        '
        Me.dgkirim.colSum = Nothing
        Me.dgkirim.ConnString = Nothing
        Me.dgkirim.dSourceUsePK = True
        Me.dgkirim.FilterPopUpMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
        Me.dgkirim.Location = New System.Drawing.Point(12, 62)
        Me.dgkirim.Name = "dgkirim"
        Me.dgkirim.PopDeleteShow = False
        Me.dgkirim.PopExportShow = True
        Me.dgkirim.PopNewShow = False
        Me.dgkirim.PopOpenShow = False
        Me.dgkirim.PopPrintShow = False
        Me.dgkirim.PopRefreshShow = False
        Me.dgkirim.Query = Nothing
        Me.dgkirim.QueryTime = Nothing
        Me.dgkirim.ShowFooter = True
        Me.dgkirim.Size = New System.Drawing.Size(699, 430)
        Me.dgkirim.TabIndex = 6
        '
        'btnKirimEkspedisi
        '
        Me.btnKirimEkspedisi.Location = New System.Drawing.Point(205, 36)
        Me.btnKirimEkspedisi.Name = "btnKirimEkspedisi"
        Me.btnKirimEkspedisi.Size = New System.Drawing.Size(165, 22)
        Me.btnKirimEkspedisi.StyleController = Me.LayoutControl1
        Me.btnKirimEkspedisi.TabIndex = 5
        Me.btnKirimEkspedisi.Text = "Kirim Ekspedisi"
        '
        'btnRefreshData
        '
        Me.btnRefreshData.Location = New System.Drawing.Point(12, 36)
        Me.btnRefreshData.Name = "btnRefreshData"
        Me.btnRefreshData.Size = New System.Drawing.Size(189, 22)
        Me.btnRefreshData.StyleController = Me.LayoutControl1
        Me.btnRefreshData.TabIndex = 4
        Me.btnRefreshData.Text = "Refresh Data"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.EmptySpaceItem2, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.EmptySpaceItem3, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.EmptySpaceItem1})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(723, 546)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.btnRefreshData
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(193, 26)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.btnKirimEkspedisi
        Me.LayoutControlItem2.Location = New System.Drawing.Point(193, 24)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(169, 26)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.dgkirim
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 50)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(703, 434)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(532, 24)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(171, 26)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.btnUpdateResi
        Me.LayoutControlItem4.Location = New System.Drawing.Point(362, 24)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(170, 26)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.btnCetakUlang
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 484)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(168, 42)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(168, 484)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(535, 42)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'dTanggalAwal
        '
        Me.dTanggalAwal.EditValue = Nothing
        Me.dTanggalAwal.Location = New System.Drawing.Point(53, 12)
        Me.dTanggalAwal.Name = "dTanggalAwal"
        Me.dTanggalAwal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dTanggalAwal.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dTanggalAwal.Size = New System.Drawing.Size(114, 20)
        Me.dTanggalAwal.StyleController = Me.LayoutControl1
        Me.dTanggalAwal.TabIndex = 9
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.dTanggalAwal
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem6.MaxSize = New System.Drawing.Size(159, 24)
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(159, 24)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(159, 24)
        Me.LayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem6.Text = "Tanggal"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(38, 13)
        '
        'dTanggalAkhir
        '
        Me.dTanggalAkhir.EditValue = Nothing
        Me.dTanggalAkhir.Location = New System.Drawing.Point(212, 12)
        Me.dTanggalAkhir.Name = "dTanggalAkhir"
        Me.dTanggalAkhir.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dTanggalAkhir.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dTanggalAkhir.Size = New System.Drawing.Size(128, 20)
        Me.dTanggalAkhir.StyleController = Me.LayoutControl1
        Me.dTanggalAkhir.TabIndex = 10
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.dTanggalAkhir
        Me.LayoutControlItem7.Location = New System.Drawing.Point(159, 0)
        Me.LayoutControlItem7.MaxSize = New System.Drawing.Size(173, 24)
        Me.LayoutControlItem7.MinSize = New System.Drawing.Size(173, 24)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(173, 24)
        Me.LayoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem7.Text = "    S/D"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(38, 13)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(332, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(371, 24)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'frmtrKirimEkspedisiList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(723, 546)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "frmtrKirimEkspedisiList"
        Me.Text = "Form Kirim Ekspedisi List"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dTanggalAwal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dTanggalAwal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dTanggalAkhir.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dTanggalAkhir.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents btnKirimEkspedisi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnRefreshData As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents dgkirim As meCore.ctrlMeDataGrid
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents btnUpdateResi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnCetakUlang As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents dTanggalAkhir As DevExpress.XtraEditors.DateEdit
    Friend WithEvents dTanggalAwal As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
End Class
