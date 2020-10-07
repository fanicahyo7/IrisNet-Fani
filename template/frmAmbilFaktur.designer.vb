<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAmbilFaktur
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAmbilFaktur))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.dgDetail = New meCore.ctrlMeDataGrid()
        Me.tNamaTujuan = New DevExpress.XtraEditors.TextEdit()
        Me.date2 = New DevExpress.XtraEditors.DateEdit()
        Me.date1 = New DevExpress.XtraEditors.DateEdit()
        Me.btnAmbil = New DevExpress.XtraEditors.SimpleButton()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Faktur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FakturReferensi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tujuan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Keterangan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sKonsinyasi = New DevExpress.XtraEditors.LabelControl()
        Me.btntampilkan = New DevExpress.XtraEditors.SimpleButton()
        Me.cTujuan = New meCore.cMeButtonBrowser()
        Me.CMeButtonBrowser1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.rJenis = New DevExpress.XtraEditors.RadioGroup()
        Me.dgfaktur = New meCore.ctrlMeDataGrid()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem5 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.tNamaTujuan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.date2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.date2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.date1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.date1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cTujuan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CMeButtonBrowser1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rJenis.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.dgDetail)
        Me.LayoutControl1.Controls.Add(Me.tNamaTujuan)
        Me.LayoutControl1.Controls.Add(Me.date2)
        Me.LayoutControl1.Controls.Add(Me.date1)
        Me.LayoutControl1.Controls.Add(Me.btnAmbil)
        Me.LayoutControl1.Controls.Add(Me.DataGridView1)
        Me.LayoutControl1.Controls.Add(Me.sKonsinyasi)
        Me.LayoutControl1.Controls.Add(Me.btntampilkan)
        Me.LayoutControl1.Controls.Add(Me.cTujuan)
        Me.LayoutControl1.Controls.Add(Me.rJenis)
        Me.LayoutControl1.Controls.Add(Me.dgfaktur)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem8, Me.LayoutControlItem9})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(791, 495)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'dgDetail
        '
        Me.dgDetail.colSum = Nothing
        Me.dgDetail.ConnString = Nothing
        Me.dgDetail.dSourceUsePK = True
        Me.dgDetail.FilterPopUpMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
        Me.dgDetail.Location = New System.Drawing.Point(323, 132)
        Me.dgDetail.Name = "dgDetail"
        Me.dgDetail.PopDeleteShow = False
        Me.dgDetail.PopExportShow = True
        Me.dgDetail.PopNewShow = False
        Me.dgDetail.PopOpenShow = False
        Me.dgDetail.PopPrintShow = False
        Me.dgDetail.PopRefreshShow = False
        Me.dgDetail.Query = Nothing
        Me.dgDetail.QueryTime = Nothing
        Me.dgDetail.ShowFooter = True
        Me.dgDetail.Size = New System.Drawing.Size(463, 332)
        Me.dgDetail.TabIndex = 19
        '
        'tNamaTujuan
        '
        Me.tNamaTujuan.Location = New System.Drawing.Point(46, 82)
        Me.tNamaTujuan.Name = "tNamaTujuan"
        Me.tNamaTujuan.Size = New System.Drawing.Size(238, 20)
        Me.tNamaTujuan.StyleController = Me.LayoutControl1
        Me.tNamaTujuan.TabIndex = 18
        '
        'date2
        '
        Me.date2.EditValue = Nothing
        Me.date2.Location = New System.Drawing.Point(184, 34)
        Me.date2.Name = "date2"
        Me.date2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.date2.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.date2.Size = New System.Drawing.Size(100, 20)
        Me.date2.StyleController = Me.LayoutControl1
        Me.date2.TabIndex = 17
        '
        'date1
        '
        Me.date1.EditValue = Nothing
        Me.date1.Location = New System.Drawing.Point(46, 34)
        Me.date1.Name = "date1"
        Me.date1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.date1.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.date1.Size = New System.Drawing.Size(93, 20)
        Me.date1.StyleController = Me.LayoutControl1
        Me.date1.TabIndex = 16
        '
        'btnAmbil
        '
        Me.btnAmbil.Image = CType(resources.GetObject("btnAmbil.Image"), System.Drawing.Image)
        Me.btnAmbil.Location = New System.Drawing.Point(655, 468)
        Me.btnAmbil.Name = "btnAmbil"
        Me.btnAmbil.Size = New System.Drawing.Size(131, 22)
        Me.btnAmbil.StyleController = Me.LayoutControl1
        Me.btnAmbil.TabIndex = 14
        Me.btnAmbil.Text = "Ambil Ekspedisi"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Faktur, Me.FakturReferensi, Me.Tujuan, Me.Keterangan, Me.Total})
        Me.DataGridView1.Location = New System.Drawing.Point(117, 324)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(662, 159)
        Me.DataGridView1.TabIndex = 13
        '
        'Faktur
        '
        Me.Faktur.HeaderText = "Faktur"
        Me.Faktur.Name = "Faktur"
        '
        'FakturReferensi
        '
        Me.FakturReferensi.HeaderText = "FakturReferensi"
        Me.FakturReferensi.Name = "FakturReferensi"
        '
        'Tujuan
        '
        Me.Tujuan.HeaderText = "Tujuan"
        Me.Tujuan.Name = "Tujuan"
        '
        'Keterangan
        '
        Me.Keterangan.HeaderText = "Keterangan"
        Me.Keterangan.Name = "Keterangan"
        '
        'Total
        '
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        '
        'sKonsinyasi
        '
        Me.sKonsinyasi.Location = New System.Drawing.Point(12, 358)
        Me.sKonsinyasi.Name = "sKonsinyasi"
        Me.sKonsinyasi.Size = New System.Drawing.Size(66, 13)
        Me.sKonsinyasi.StyleController = Me.LayoutControl1
        Me.sKonsinyasi.TabIndex = 12
        Me.sKonsinyasi.Text = "LabelControl2"
        '
        'btntampilkan
        '
        Me.btntampilkan.Image = CType(resources.GetObject("btntampilkan.Image"), System.Drawing.Image)
        Me.btntampilkan.Location = New System.Drawing.Point(46, 106)
        Me.btntampilkan.Name = "btntampilkan"
        Me.btntampilkan.Size = New System.Drawing.Size(238, 22)
        Me.btntampilkan.StyleController = Me.LayoutControl1
        Me.btntampilkan.TabIndex = 10
        Me.btntampilkan.Text = "Tampilkan Faktur"
        '
        'cTujuan
        '
        Me.cTujuan.Location = New System.Drawing.Point(46, 58)
        Me.cTujuan.Name = "cTujuan"
        Me.cTujuan.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cTujuan.Properties.NullText = ""
        Me.cTujuan.Properties.View = Me.CMeButtonBrowser1View
        Me.cTujuan.Size = New System.Drawing.Size(238, 20)
        Me.cTujuan.StyleController = Me.LayoutControl1
        Me.cTujuan.TabIndex = 9
        '
        'CMeButtonBrowser1View
        '
        Me.CMeButtonBrowser1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.CMeButtonBrowser1View.Name = "CMeButtonBrowser1View"
        Me.CMeButtonBrowser1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.CMeButtonBrowser1View.OptionsView.ShowGroupPanel = False
        '
        'rJenis
        '
        Me.rJenis.Location = New System.Drawing.Point(46, 5)
        Me.rJenis.Name = "rJenis"
        Me.rJenis.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("0", "Supplier"), New DevExpress.XtraEditors.Controls.RadioGroupItem("1", "Customer"), New DevExpress.XtraEditors.Controls.RadioGroupItem("2", "Pengajuan Bayar Supplier")})
        Me.rJenis.Size = New System.Drawing.Size(437, 25)
        Me.rJenis.StyleController = Me.LayoutControl1
        Me.rJenis.TabIndex = 5
        '
        'dgfaktur
        '
        Me.dgfaktur.colSum = Nothing
        Me.dgfaktur.ConnString = Nothing
        Me.dgfaktur.dSourceUsePK = True
        Me.dgfaktur.FilterPopUpMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
        Me.dgfaktur.Location = New System.Drawing.Point(5, 132)
        Me.dgfaktur.Name = "dgfaktur"
        Me.dgfaktur.PopDeleteShow = False
        Me.dgfaktur.PopExportShow = True
        Me.dgfaktur.PopNewShow = False
        Me.dgfaktur.PopOpenShow = False
        Me.dgfaktur.PopPrintShow = False
        Me.dgfaktur.PopRefreshShow = False
        Me.dgfaktur.Query = Nothing
        Me.dgfaktur.QueryTime = Nothing
        Me.dgfaktur.ShowFooter = True
        Me.dgfaktur.Size = New System.Drawing.Size(314, 332)
        Me.dgfaktur.TabIndex = 4
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.sKonsinyasi
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 346)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(771, 17)
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.DataGridView1
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 312)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(771, 163)
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(102, 13)
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem6, Me.LayoutControlItem5, Me.LayoutControlItem10, Me.EmptySpaceItem1, Me.EmptySpaceItem3, Me.EmptySpaceItem2, Me.EmptySpaceItem4, Me.EmptySpaceItem5, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem7, Me.LayoutControlItem11})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(791, 495)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.dgfaktur
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 127)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(318, 336)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.rJenis
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.MaxSize = New System.Drawing.Size(482, 29)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(482, 29)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(482, 29)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.Text = "Jenis"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(38, 13)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.cTujuan
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 53)
        Me.LayoutControlItem6.MaxSize = New System.Drawing.Size(283, 24)
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(283, 24)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(283, 24)
        Me.LayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem6.Text = "Tujuan"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(38, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.btntampilkan
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 101)
        Me.LayoutControlItem5.MaxSize = New System.Drawing.Size(283, 26)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(283, 26)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(283, 26)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.Text = " "
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(38, 13)
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.btnAmbil
        Me.LayoutControlItem10.Location = New System.Drawing.Point(650, 463)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(135, 26)
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem10.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(482, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(303, 29)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(283, 29)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(502, 24)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(283, 53)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(502, 48)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(283, 101)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(502, 26)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem5
        '
        Me.EmptySpaceItem5.AllowHotTrack = False
        Me.EmptySpaceItem5.Location = New System.Drawing.Point(0, 463)
        Me.EmptySpaceItem5.Name = "EmptySpaceItem5"
        Me.EmptySpaceItem5.Size = New System.Drawing.Size(650, 26)
        Me.EmptySpaceItem5.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.date1
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 29)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(138, 24)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(138, 24)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(138, 24)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.Text = "Tanggal"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(38, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.date2
        Me.LayoutControlItem4.Location = New System.Drawing.Point(138, 29)
        Me.LayoutControlItem4.MaxSize = New System.Drawing.Size(145, 24)
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(145, 24)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(145, 24)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem4.Text = "   S/D"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(38, 13)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.tNamaTujuan
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 77)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(283, 24)
        Me.LayoutControlItem7.Text = " "
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(38, 13)
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.dgDetail
        Me.LayoutControlItem11.Location = New System.Drawing.Point(318, 127)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(467, 336)
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem11.TextVisible = False
        '
        'frmAmbilFaktur
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(791, 495)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "frmAmbilFaktur"
        Me.Text = "Form Ambil Faktur"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.tNamaTujuan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.date2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.date2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.date1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.date1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cTujuan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CMeButtonBrowser1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rJenis.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents btntampilkan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cTujuan As meCore.cMeButtonBrowser
    Friend WithEvents CMeButtonBrowser1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents rJenis As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents dgfaktur As meCore.ctrlMeDataGrid
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents sKonsinyasi As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnAmbil As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Faktur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FakturReferensi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tujuan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Keterangan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem5 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents date2 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents date1 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents tNamaTujuan As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents dgDetail As meCore.ctrlMeDataGrid
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
End Class
