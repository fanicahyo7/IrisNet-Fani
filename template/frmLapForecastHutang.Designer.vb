<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLapForecastHutang
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
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.btnAmbilData = New DevExpress.XtraEditors.SimpleButton()
        Me.dgPengajuan = New meCore.ctrlMeDataGrid()
        Me.dgOmzet = New meCore.ctrlMeDataGrid()
        Me.dTahun = New DevExpress.XtraEditors.DateEdit()
        Me.dgPerhitunganUnit = New meCore.ctrlMeDataGrid()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.dTahun.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dTahun.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.btnAmbilData)
        Me.LayoutControl1.Controls.Add(Me.dgPengajuan)
        Me.LayoutControl1.Controls.Add(Me.dgOmzet)
        Me.LayoutControl1.Controls.Add(Me.dTahun)
        Me.LayoutControl1.Controls.Add(Me.dgPerhitunganUnit)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(796, 512)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'btnAmbilData
        '
        Me.btnAmbilData.Location = New System.Drawing.Point(124, 12)
        Me.btnAmbilData.Name = "btnAmbilData"
        Me.btnAmbilData.Size = New System.Drawing.Size(162, 22)
        Me.btnAmbilData.StyleController = Me.LayoutControl1
        Me.btnAmbilData.TabIndex = 8
        Me.btnAmbilData.Text = "Ambil Data"
        '
        'dgPengajuan
        '
        Me.dgPengajuan.colSum = Nothing
        Me.dgPengajuan.ConnString = Nothing
        Me.dgPengajuan.dSourceUsePK = True
        Me.dgPengajuan.FilterPopUpMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
        Me.dgPengajuan.Location = New System.Drawing.Point(400, 170)
        Me.dgPengajuan.Name = "dgPengajuan"
        Me.dgPengajuan.PopDeleteShow = False
        Me.dgPengajuan.PopExportShow = True
        Me.dgPengajuan.PopNewShow = False
        Me.dgPengajuan.PopOpenShow = False
        Me.dgPengajuan.PopPrintShow = False
        Me.dgPengajuan.PopRefreshShow = False
        Me.dgPengajuan.Query = Nothing
        Me.dgPengajuan.QueryTime = Nothing
        Me.dgPengajuan.ShowFooter = True
        Me.dgPengajuan.Size = New System.Drawing.Size(384, 330)
        Me.dgPengajuan.TabIndex = 7
        '
        'dgOmzet
        '
        Me.dgOmzet.colSum = Nothing
        Me.dgOmzet.ConnString = Nothing
        Me.dgOmzet.dSourceUsePK = True
        Me.dgOmzet.FilterPopUpMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
        Me.dgOmzet.Location = New System.Drawing.Point(12, 170)
        Me.dgOmzet.Name = "dgOmzet"
        Me.dgOmzet.PopDeleteShow = False
        Me.dgOmzet.PopExportShow = True
        Me.dgOmzet.PopNewShow = False
        Me.dgOmzet.PopOpenShow = False
        Me.dgOmzet.PopPrintShow = False
        Me.dgOmzet.PopRefreshShow = False
        Me.dgOmzet.Query = Nothing
        Me.dgOmzet.QueryTime = Nothing
        Me.dgOmzet.ShowFooter = True
        Me.dgOmzet.Size = New System.Drawing.Size(384, 330)
        Me.dgOmzet.TabIndex = 6
        '
        'dTahun
        '
        Me.dTahun.EditValue = Nothing
        Me.dTahun.Location = New System.Drawing.Point(45, 12)
        Me.dTahun.Name = "dTahun"
        Me.dTahun.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dTahun.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dTahun.Size = New System.Drawing.Size(75, 20)
        Me.dTahun.StyleController = Me.LayoutControl1
        Me.dTahun.TabIndex = 5
        '
        'dgPerhitunganUnit
        '
        Me.dgPerhitunganUnit.colSum = Nothing
        Me.dgPerhitunganUnit.ConnString = Nothing
        Me.dgPerhitunganUnit.dSourceUsePK = True
        Me.dgPerhitunganUnit.FilterPopUpMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
        Me.dgPerhitunganUnit.Location = New System.Drawing.Point(12, 38)
        Me.dgPerhitunganUnit.Name = "dgPerhitunganUnit"
        Me.dgPerhitunganUnit.PopDeleteShow = False
        Me.dgPerhitunganUnit.PopExportShow = True
        Me.dgPerhitunganUnit.PopNewShow = False
        Me.dgPerhitunganUnit.PopOpenShow = False
        Me.dgPerhitunganUnit.PopPrintShow = False
        Me.dgPerhitunganUnit.PopRefreshShow = False
        Me.dgPerhitunganUnit.Query = Nothing
        Me.dgPerhitunganUnit.QueryTime = Nothing
        Me.dgPerhitunganUnit.ShowFooter = True
        Me.dgPerhitunganUnit.Size = New System.Drawing.Size(772, 128)
        Me.dgPerhitunganUnit.TabIndex = 4
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.EmptySpaceItem1})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(796, 512)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.dgPerhitunganUnit
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(776, 132)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.dTahun
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(112, 26)
        Me.LayoutControlItem2.Text = "Tahun"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(30, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.dgOmzet
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 158)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(388, 334)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.dgPengajuan
        Me.LayoutControlItem4.Location = New System.Drawing.Point(388, 158)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(388, 334)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.btnAmbilData
        Me.LayoutControlItem5.Location = New System.Drawing.Point(112, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(166, 26)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(278, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(498, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'frmLapForecastHutang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(796, 512)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "frmLapForecastHutang"
        Me.Text = "frmLapForecastHutang"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.dTahun.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dTahun.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents btnAmbilData As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents dgPengajuan As meCore.ctrlMeDataGrid
    Friend WithEvents dgOmzet As meCore.ctrlMeDataGrid
    Friend WithEvents dTahun As DevExpress.XtraEditors.DateEdit
    Friend WithEvents dgPerhitunganUnit As meCore.ctrlMeDataGrid
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
End Class
