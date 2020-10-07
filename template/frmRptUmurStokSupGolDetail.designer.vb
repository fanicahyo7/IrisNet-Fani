<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptUmurStokSupGolDetail
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim XyDiagram1 As DevExpress.XtraCharts.XYDiagram = New DevExpress.XtraCharts.XYDiagram()
        Dim Series1 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim LineSeriesView1 As DevExpress.XtraCharts.LineSeriesView = New DevExpress.XtraCharts.LineSeriesView()
        Dim LineSeriesView2 As DevExpress.XtraCharts.LineSeriesView = New DevExpress.XtraCharts.LineSeriesView()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRptUmurStokSupGolDetail))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.ceTransaksi = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.ceQuery = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.filterstock = New template.ctrlFilterStock()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.spJual = New DevExpress.XtraEditors.SpinEdit()
        Me.chart = New DevExpress.XtraCharts.ChartControl()
        Me.cmbRefreshData = New DevExpress.XtraEditors.SimpleButton()
        Me.chkSaldo = New DevExpress.XtraEditors.CheckEdit()
        Me.spHariJual = New DevExpress.XtraEditors.SpinEdit()
        Me.spHariBeli = New DevExpress.XtraEditors.SpinEdit()
        Me.cmbUmurJual = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cmbUmurBeli = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.mdgList = New meCore.ctrlMeDataGrid()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lcgF = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.ceTransaksi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ceQuery.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spJual.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(LineSeriesView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(LineSeriesView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSaldo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spHariJual.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spHariBeli.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbUmurJual.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbUmurBeli.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcgF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.ceTransaksi)
        Me.LayoutControl1.Controls.Add(Me.ceQuery)
        Me.LayoutControl1.Controls.Add(Me.filterstock)
        Me.LayoutControl1.Controls.Add(Me.LabelControl1)
        Me.LayoutControl1.Controls.Add(Me.spJual)
        Me.LayoutControl1.Controls.Add(Me.chart)
        Me.LayoutControl1.Controls.Add(Me.cmbRefreshData)
        Me.LayoutControl1.Controls.Add(Me.chkSaldo)
        Me.LayoutControl1.Controls.Add(Me.spHariJual)
        Me.LayoutControl1.Controls.Add(Me.spHariBeli)
        Me.LayoutControl1.Controls.Add(Me.cmbUmurJual)
        Me.LayoutControl1.Controls.Add(Me.cmbUmurBeli)
        Me.LayoutControl1.Controls.Add(Me.mdgList)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1070, 539)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'ceTransaksi
        '
        Me.ceTransaksi.Location = New System.Drawing.Point(56, 53)
        Me.ceTransaksi.Name = "ceTransaksi"
        Me.ceTransaksi.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ceTransaksi.Properties.Items.AddRange(New Object() {"SEMUA", "BO", "KASIR"})
        Me.ceTransaksi.Size = New System.Drawing.Size(255, 20)
        Me.ceTransaksi.StyleController = Me.LayoutControl1
        Me.ceTransaksi.TabIndex = 2
        '
        'ceQuery
        '
        Me.ceQuery.Location = New System.Drawing.Point(56, 5)
        Me.ceQuery.Name = "ceQuery"
        Me.ceQuery.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ceQuery.Properties.Items.AddRange(New Object() {"Supplier", "Golongan"})
        Me.ceQuery.Size = New System.Drawing.Size(255, 20)
        Me.ceQuery.StyleController = Me.LayoutControl1
        Me.ceQuery.TabIndex = 0
        '
        'filterstock
        '
        Me.filterstock.FilterGolongan = True
        Me.filterstock.FilterJenis = True
        Me.filterstock.FilterSupplier = True
        Me.filterstock.FilterTahunSaldo = True
        Me.filterstock.Location = New System.Drawing.Point(56, 29)
        Me.filterstock.Name = "filterstock"
        Me.filterstock.Size = New System.Drawing.Size(255, 20)
        Me.filterstock.TabIndex = 3
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(106, 132)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(101, 23)
        Me.LabelControl1.StyleController = Me.LayoutControl1
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Hari ke belakang"
        '
        'spJual
        '
        Me.spJual.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.spJual.Location = New System.Drawing.Point(56, 132)
        Me.spJual.Name = "spJual"
        Me.spJual.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.spJual.Size = New System.Drawing.Size(46, 20)
        Me.spJual.StyleController = Me.LayoutControl1
        Me.spJual.TabIndex = 8
        Me.spJual.ToolTip = "Qty Jual X hari ke belakang.. data akan tampil di kolom Qty Jual"
        '
        'chart
        '
        Me.chart.DataBindings = Nothing
        XyDiagram1.AxisX.CrosshairAxisLabelOptions.BackColor = System.Drawing.Color.White
        XyDiagram1.AxisX.Interlaced = True
        XyDiagram1.AxisX.Label.Angle = 270
        XyDiagram1.AxisX.Label.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        XyDiagram1.AxisX.Tickmarks.MinorVisible = False
        XyDiagram1.AxisX.Visibility = DevExpress.Utils.DefaultBoolean.[True]
        XyDiagram1.AxisX.VisibleInPanesSerializable = "-1"
        XyDiagram1.AxisY.Label.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        XyDiagram1.AxisY.VisibleInPanesSerializable = "-1"
        Me.chart.Diagram = XyDiagram1
        Me.chart.Legend.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chart.Legend.Name = "Default Legend"
        Me.chart.Legend.Title.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.[True]
        Me.chart.Location = New System.Drawing.Point(5, 399)
        Me.chart.Name = "chart"
        Series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.[True]
        Series1.Name = "Series 1"
        Series1.ShowInLegend = False
        Series1.View = LineSeriesView1
        Me.chart.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series1}
        Me.chart.SeriesTemplate.View = LineSeriesView2
        Me.chart.Size = New System.Drawing.Size(1060, 135)
        Me.chart.TabIndex = 12
        '
        'cmbRefreshData
        '
        Me.cmbRefreshData.Image = CType(resources.GetObject("cmbRefreshData.Image"), System.Drawing.Image)
        Me.cmbRefreshData.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.cmbRefreshData.Location = New System.Drawing.Point(211, 77)
        Me.cmbRefreshData.Name = "cmbRefreshData"
        Me.cmbRefreshData.Size = New System.Drawing.Size(100, 78)
        Me.cmbRefreshData.StyleController = Me.LayoutControl1
        Me.cmbRefreshData.TabIndex = 9
        Me.cmbRefreshData.Text = "Ambil Data"
        '
        'chkSaldo
        '
        Me.chkSaldo.Location = New System.Drawing.Point(715, 87)
        Me.chkSaldo.Name = "chkSaldo"
        Me.chkSaldo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.[Default]
        Me.chkSaldo.Properties.Caption = ""
        Me.chkSaldo.Size = New System.Drawing.Size(350, 19)
        Me.chkSaldo.StyleController = Me.LayoutControl1
        Me.chkSaldo.TabIndex = 10
        '
        'spHariJual
        '
        Me.spHariJual.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.spHariJual.Location = New System.Drawing.Point(106, 105)
        Me.spHariJual.Name = "spHariJual"
        Me.spHariJual.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.spHariJual.Size = New System.Drawing.Size(50, 20)
        Me.spHariJual.StyleController = Me.LayoutControl1
        Me.spHariJual.TabIndex = 7
        '
        'spHariBeli
        '
        Me.spHariBeli.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.spHariBeli.Location = New System.Drawing.Point(106, 77)
        Me.spHariBeli.Name = "spHariBeli"
        Me.spHariBeli.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.spHariBeli.Size = New System.Drawing.Size(50, 20)
        Me.spHariBeli.StyleController = Me.LayoutControl1
        Me.spHariBeli.TabIndex = 5
        '
        'cmbUmurJual
        '
        Me.cmbUmurJual.Location = New System.Drawing.Point(56, 105)
        Me.cmbUmurJual.Name = "cmbUmurJual"
        Me.cmbUmurJual.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbUmurJual.Properties.Items.AddRange(New Object() {">=", "<="})
        Me.cmbUmurJual.Size = New System.Drawing.Size(46, 20)
        Me.cmbUmurJual.StyleController = Me.LayoutControl1
        Me.cmbUmurJual.TabIndex = 6
        '
        'cmbUmurBeli
        '
        Me.cmbUmurBeli.Location = New System.Drawing.Point(56, 77)
        Me.cmbUmurBeli.Name = "cmbUmurBeli"
        Me.cmbUmurBeli.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbUmurBeli.Properties.Items.AddRange(New Object() {">=", "<="})
        Me.cmbUmurBeli.Size = New System.Drawing.Size(46, 20)
        Me.cmbUmurBeli.StyleController = Me.LayoutControl1
        Me.cmbUmurBeli.TabIndex = 4
        '
        'mdgList
        '
        Me.mdgList.colSum = Nothing
        Me.mdgList.ConnString = Nothing
        Me.mdgList.dSourceUsePK = True
        Me.mdgList.FilterPopUpMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
        Me.mdgList.Location = New System.Drawing.Point(5, 159)
        Me.mdgList.Name = "mdgList"
        Me.mdgList.PopDeleteShow = False
        Me.mdgList.PopExportShow = True
        Me.mdgList.PopNewShow = False
        Me.mdgList.PopOpenShow = False
        Me.mdgList.PopPrintShow = False
        Me.mdgList.PopRefreshShow = False
        Me.mdgList.Query = Nothing
        Me.mdgList.QueryTime = Nothing
        Me.mdgList.ShowFooter = True
        Me.mdgList.Size = New System.Drawing.Size(1060, 236)
        Me.mdgList.TabIndex = 11
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.EmptySpaceItem3, Me.LayoutControlItem8, Me.lcgF, Me.LayoutControlItem2, Me.LayoutControlItem7, Me.EmptySpaceItem1, Me.LayoutControlItem13, Me.LayoutControlItem14})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1070, 539)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.mdgList
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 154)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1064, 240)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(310, 82)
        Me.EmptySpaceItem3.MaxSize = New System.Drawing.Size(0, 72)
        Me.EmptySpaceItem3.MinSize = New System.Drawing.Size(10, 72)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(349, 72)
        Me.EmptySpaceItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.chkSaldo
        Me.LayoutControlItem8.Location = New System.Drawing.Point(659, 82)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(405, 72)
        Me.LayoutControlItem8.Text = "Saldo 0"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(48, 13)
        Me.LayoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'lcgF
        '
        Me.lcgF.GroupBordersVisible = False
        Me.lcgF.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem6, Me.LayoutControlItem5, Me.LayoutControlItem10, Me.LayoutControlItem11, Me.LayoutControlItem9})
        Me.lcgF.Location = New System.Drawing.Point(0, 72)
        Me.lcgF.Name = "lcgF"
        Me.lcgF.Size = New System.Drawing.Size(310, 82)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.cmbUmurBeli
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(101, 28)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(101, 28)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(101, 28)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.Text = "Umur beli"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(48, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.cmbUmurJual
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 28)
        Me.LayoutControlItem4.MaxSize = New System.Drawing.Size(101, 27)
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(101, 27)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(101, 27)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem4.Text = "Umur Jual"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(48, 13)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.spHariJual
        Me.LayoutControlItem6.Location = New System.Drawing.Point(101, 28)
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(105, 24)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(105, 27)
        Me.LayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem6.Text = "hari"
        Me.LayoutControlItem6.TextLocation = DevExpress.Utils.Locations.Right
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(48, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.spHariBeli
        Me.LayoutControlItem5.Location = New System.Drawing.Point(101, 0)
        Me.LayoutControlItem5.MaxSize = New System.Drawing.Size(105, 0)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(105, 24)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(105, 28)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.Text = "hari"
        Me.LayoutControlItem5.TextLocation = DevExpress.Utils.Locations.Right
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(48, 13)
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.spJual
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 55)
        Me.LayoutControlItem10.MaxSize = New System.Drawing.Size(101, 27)
        Me.LayoutControlItem10.MinSize = New System.Drawing.Size(101, 27)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(101, 27)
        Me.LayoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem10.Text = "Penjualan"
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(48, 13)
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.LabelControl1
        Me.LayoutControlItem11.Location = New System.Drawing.Point(101, 55)
        Me.LayoutControlItem11.MinSize = New System.Drawing.Size(83, 17)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(105, 27)
        Me.LayoutControlItem11.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem11.TextVisible = False
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.cmbRefreshData
        Me.LayoutControlItem9.Location = New System.Drawing.Point(206, 0)
        Me.LayoutControlItem9.MinSize = New System.Drawing.Size(51, 26)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(104, 82)
        Me.LayoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.chart
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 394)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(1064, 139)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.filterstock
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem7.MaxSize = New System.Drawing.Size(310, 24)
        Me.LayoutControlItem7.MinSize = New System.Drawing.Size(310, 24)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(310, 24)
        Me.LayoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem7.Text = "Filter Stok"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(48, 13)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(310, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(754, 82)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.ceQuery
        Me.LayoutControlItem13.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(310, 24)
        Me.LayoutControlItem13.Text = "Query"
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(48, 13)
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.ceTransaksi
        Me.LayoutControlItem14.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(310, 24)
        Me.LayoutControlItem14.Text = "Transaksi"
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(48, 13)
        '
        'frmRptUmurStokSupGol
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1070, 539)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "frmRptUmurStokSupGol"
        Me.Text = "Umur Stok"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.ceTransaksi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ceQuery.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spJual.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(LineSeriesView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(LineSeriesView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSaldo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spHariJual.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spHariBeli.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbUmurJual.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbUmurBeli.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcgF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents mdgList As meCore.ctrlMeDataGrid
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmbRefreshData As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkSaldo As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents spHariJual As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents spHariBeli As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents cmbUmurJual As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cmbUmurBeli As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents lcgF As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents spJual As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents filterstock As ctrlFilterStock
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents ceQuery As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ceTransaksi As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents chart As DevExpress.XtraCharts.ChartControl
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
End Class
