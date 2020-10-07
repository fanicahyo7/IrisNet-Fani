<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptBarangKeluarMasuk
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRptBarangKeluarMasuk))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.dTanggalAkhir = New DevExpress.XtraEditors.DateEdit()
        Me.dTanggalAwal = New DevExpress.XtraEditors.DateEdit()
        Me.ceQuery = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.filterstock = New template.ctrlFilterStock()
        Me.chart = New DevExpress.XtraCharts.ChartControl()
        Me.cmbRefreshData = New DevExpress.XtraEditors.SimpleButton()
        Me.mdgList = New meCore.ctrlMeDataGrid()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lcgF = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem15 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.dTanggalAkhir.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dTanggalAkhir.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dTanggalAwal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dTanggalAwal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ceQuery.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(LineSeriesView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(LineSeriesView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcgF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.dTanggalAkhir)
        Me.LayoutControl1.Controls.Add(Me.dTanggalAwal)
        Me.LayoutControl1.Controls.Add(Me.ceQuery)
        Me.LayoutControl1.Controls.Add(Me.filterstock)
        Me.LayoutControl1.Controls.Add(Me.chart)
        Me.LayoutControl1.Controls.Add(Me.cmbRefreshData)
        Me.LayoutControl1.Controls.Add(Me.mdgList)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1070, 539)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'dTanggalAkhir
        '
        Me.dTanggalAkhir.EditValue = Nothing
        Me.dTanggalAkhir.Location = New System.Drawing.Point(211, 5)
        Me.dTanggalAkhir.Name = "dTanggalAkhir"
        Me.dTanggalAkhir.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dTanggalAkhir.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dTanggalAkhir.Size = New System.Drawing.Size(100, 20)
        Me.dTanggalAkhir.StyleController = Me.LayoutControl1
        Me.dTanggalAkhir.TabIndex = 14
        '
        'dTanggalAwal
        '
        Me.dTanggalAwal.EditValue = Nothing
        Me.dTanggalAwal.Location = New System.Drawing.Point(56, 5)
        Me.dTanggalAwal.Name = "dTanggalAwal"
        Me.dTanggalAwal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dTanggalAwal.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dTanggalAwal.Size = New System.Drawing.Size(100, 20)
        Me.dTanggalAwal.StyleController = Me.LayoutControl1
        Me.dTanggalAwal.TabIndex = 13
        '
        'ceQuery
        '
        Me.ceQuery.Location = New System.Drawing.Point(56, 29)
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
        Me.filterstock.Location = New System.Drawing.Point(56, 53)
        Me.filterstock.Name = "filterstock"
        Me.filterstock.Size = New System.Drawing.Size(255, 20)
        Me.filterstock.TabIndex = 3
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
        Me.cmbRefreshData.Location = New System.Drawing.Point(5, 77)
        Me.cmbRefreshData.Name = "cmbRefreshData"
        Me.cmbRefreshData.Size = New System.Drawing.Size(306, 73)
        Me.cmbRefreshData.StyleController = Me.LayoutControl1
        Me.cmbRefreshData.TabIndex = 9
        Me.cmbRefreshData.Text = "Ambil Data"
        '
        'mdgList
        '
        Me.mdgList.colSum = Nothing
        Me.mdgList.ConnString = Nothing
        Me.mdgList.dSourceUsePK = True
        Me.mdgList.FilterPopUpMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
        Me.mdgList.Location = New System.Drawing.Point(5, 154)
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
        Me.mdgList.Size = New System.Drawing.Size(1060, 241)
        Me.mdgList.TabIndex = 11
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.lcgF, Me.LayoutControlItem2, Me.LayoutControlItem7, Me.EmptySpaceItem1, Me.LayoutControlItem13, Me.LayoutControlItem12, Me.LayoutControlItem15})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1070, 539)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.mdgList
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 149)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1064, 245)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'lcgF
        '
        Me.lcgF.GroupBordersVisible = False
        Me.lcgF.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem9})
        Me.lcgF.Location = New System.Drawing.Point(0, 72)
        Me.lcgF.Name = "lcgF"
        Me.lcgF.Size = New System.Drawing.Size(310, 77)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.cmbRefreshData
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem9.MinSize = New System.Drawing.Size(64, 59)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(310, 77)
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
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 48)
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
        Me.EmptySpaceItem1.MaxSize = New System.Drawing.Size(754, 149)
        Me.EmptySpaceItem1.MinSize = New System.Drawing.Size(754, 149)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(754, 149)
        Me.EmptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.ceQuery
        Me.LayoutControlItem13.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(310, 24)
        Me.LayoutControlItem13.Text = "Query"
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(48, 13)
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.dTanggalAwal
        Me.LayoutControlItem12.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(155, 24)
        Me.LayoutControlItem12.Text = "Tanggal"
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(48, 13)
        '
        'LayoutControlItem15
        '
        Me.LayoutControlItem15.Control = Me.dTanggalAkhir
        Me.LayoutControlItem15.Location = New System.Drawing.Point(155, 0)
        Me.LayoutControlItem15.Name = "LayoutControlItem15"
        Me.LayoutControlItem15.Size = New System.Drawing.Size(155, 24)
        Me.LayoutControlItem15.Text = "     S/D"
        Me.LayoutControlItem15.TextSize = New System.Drawing.Size(48, 13)
        '
        'frmRptBarangKeluarMasuk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1070, 539)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "frmRptBarangKeluarMasuk"
        Me.Text = "Barang Masuk Keluar"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.dTanggalAkhir.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dTanggalAkhir.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dTanggalAwal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dTanggalAwal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ceQuery.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(LineSeriesView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(LineSeriesView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcgF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents mdgList As meCore.ctrlMeDataGrid
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmbRefreshData As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lcgF As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents filterstock As ctrlFilterStock
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ceQuery As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents chart As DevExpress.XtraCharts.ChartControl
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents dTanggalAwal As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents dTanggalAkhir As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem15 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
End Class
