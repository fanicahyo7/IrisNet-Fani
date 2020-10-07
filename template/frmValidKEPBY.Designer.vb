<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmValidKEPBY
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmValidKEPBY))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.dgPBY = New meCore.ctrlMeDataGrid()
        Me.btnAmbilData = New DevExpress.XtraEditors.SimpleButton()
        Me.dTanggal2 = New DevExpress.XtraEditors.DateEdit()
        Me.dTanggal1 = New DevExpress.XtraEditors.DateEdit()
        Me.dgList = New meCore.ctrlMeDataGrid()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.dTanggal2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dTanggal2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dTanggal1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dTanggal1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.dgPBY)
        Me.LayoutControl1.Controls.Add(Me.btnAmbilData)
        Me.LayoutControl1.Controls.Add(Me.dTanggal2)
        Me.LayoutControl1.Controls.Add(Me.dTanggal1)
        Me.LayoutControl1.Controls.Add(Me.dgList)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(807, 360)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'dgPBY
        '
        Me.dgPBY.colSum = Nothing
        Me.dgPBY.ConnString = Nothing
        Me.dgPBY.dSourceUsePK = True
        Me.dgPBY.FilterPopUpMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
        Me.dgPBY.Location = New System.Drawing.Point(618, 55)
        Me.dgPBY.Name = "dgPBY"
        Me.dgPBY.PopDeleteShow = False
        Me.dgPBY.PopExportShow = True
        Me.dgPBY.PopNewShow = False
        Me.dgPBY.PopOpenShow = False
        Me.dgPBY.PopPrintShow = False
        Me.dgPBY.PopRefreshShow = False
        Me.dgPBY.Query = Nothing
        Me.dgPBY.QueryTime = Nothing
        Me.dgPBY.ShowFooter = True
        Me.dgPBY.Size = New System.Drawing.Size(184, 300)
        Me.dgPBY.TabIndex = 8
        '
        'btnAmbilData
        '
        Me.btnAmbilData.Image = CType(resources.GetObject("btnAmbilData.Image"), System.Drawing.Image)
        Me.btnAmbilData.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnAmbilData.Location = New System.Drawing.Point(46, 29)
        Me.btnAmbilData.Name = "btnAmbilData"
        Me.btnAmbilData.Size = New System.Drawing.Size(235, 22)
        Me.btnAmbilData.StyleController = Me.LayoutControl1
        Me.btnAmbilData.TabIndex = 7
        Me.btnAmbilData.Text = "Ambil Data"
        '
        'dTanggal2
        '
        Me.dTanggal2.EditValue = Nothing
        Me.dTanggal2.Location = New System.Drawing.Point(186, 5)
        Me.dTanggal2.Name = "dTanggal2"
        Me.dTanggal2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dTanggal2.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dTanggal2.Size = New System.Drawing.Size(95, 20)
        Me.dTanggal2.StyleController = Me.LayoutControl1
        Me.dTanggal2.TabIndex = 6
        '
        'dTanggal1
        '
        Me.dTanggal1.EditValue = Nothing
        Me.dTanggal1.Location = New System.Drawing.Point(46, 5)
        Me.dTanggal1.Name = "dTanggal1"
        Me.dTanggal1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dTanggal1.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dTanggal1.Size = New System.Drawing.Size(95, 20)
        Me.dTanggal1.StyleController = Me.LayoutControl1
        Me.dTanggal1.TabIndex = 5
        '
        'dgList
        '
        Me.dgList.colSum = Nothing
        Me.dgList.ConnString = Nothing
        Me.dgList.dSourceUsePK = True
        Me.dgList.FilterPopUpMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
        Me.dgList.Location = New System.Drawing.Point(5, 55)
        Me.dgList.Name = "dgList"
        Me.dgList.PopDeleteShow = False
        Me.dgList.PopExportShow = True
        Me.dgList.PopNewShow = False
        Me.dgList.PopOpenShow = False
        Me.dgList.PopPrintShow = False
        Me.dgList.PopRefreshShow = False
        Me.dgList.Query = Nothing
        Me.dgList.QueryTime = Nothing
        Me.dgList.ShowFooter = True
        Me.dgList.Size = New System.Drawing.Size(609, 300)
        Me.dgList.TabIndex = 4
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.EmptySpaceItem1, Me.EmptySpaceItem2, Me.LayoutControlItem5})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(807, 360)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.dgList
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 50)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(613, 304)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.dTanggal1
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.MaxSize = New System.Drawing.Size(140, 24)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(140, 24)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(140, 24)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.Text = "Tanggal"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(38, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.dTanggal2
        Me.LayoutControlItem3.Location = New System.Drawing.Point(140, 0)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(140, 24)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(140, 24)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(140, 24)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.Text = "   s/d   "
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(38, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.btnAmbilData
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem4.MaxSize = New System.Drawing.Size(280, 26)
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(280, 26)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(280, 26)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem4.Text = " "
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(38, 13)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(280, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(521, 24)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(280, 24)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(521, 26)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.dgPBY
        Me.LayoutControlItem5.Location = New System.Drawing.Point(613, 50)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(188, 304)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'frmValidKEPBY
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(807, 360)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "frmValidKEPBY"
        Me.Text = "frmValidKEPBY"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.dTanggal2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dTanggal2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dTanggal1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dTanggal1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents btnAmbilData As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents dTanggal2 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents dTanggal1 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents dgList As meCore.ctrlMeDataGrid
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents dgPBY As meCore.ctrlMeDataGrid
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
End Class
