<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSaldoPiutang
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSaldoPiutang))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.dTanggal = New DevExpress.XtraEditors.DateEdit()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.btnTampil = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.dgList = New meCore.ctrlMeDataGrid()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dTanggal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dTanggal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.dgList)
        Me.LayoutControl1.Controls.Add(Me.btnTampil)
        Me.LayoutControl1.Controls.Add(Me.dTanggal)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(817, 455)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.EmptySpaceItem1})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(817, 455)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'dTanggal
        '
        Me.dTanggal.EditValue = Nothing
        Me.dTanggal.Location = New System.Drawing.Point(90, 12)
        Me.dTanggal.Name = "dTanggal"
        Me.dTanggal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dTanggal.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dTanggal.Size = New System.Drawing.Size(110, 20)
        Me.dTanggal.StyleController = Me.LayoutControl1
        Me.dTanggal.TabIndex = 4
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.dTanggal
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.MaxSize = New System.Drawing.Size(192, 26)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(192, 26)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(192, 42)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.Text = "Sampai Dengan"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(74, 13)
        '
        'btnTampil
        '
        Me.btnTampil.Image = CType(resources.GetObject("btnTampil.Image"), System.Drawing.Image)
        Me.btnTampil.Location = New System.Drawing.Point(204, 12)
        Me.btnTampil.Name = "btnTampil"
        Me.btnTampil.Size = New System.Drawing.Size(127, 38)
        Me.btnTampil.StyleController = Me.LayoutControl1
        Me.btnTampil.TabIndex = 5
        Me.btnTampil.Text = "Tampilkan Data"
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.btnTampil
        Me.LayoutControlItem2.Location = New System.Drawing.Point(192, 0)
        Me.LayoutControlItem2.MaxSize = New System.Drawing.Size(131, 42)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(131, 42)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(131, 42)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'dgList
        '
        Me.dgList.colSum = Nothing
        Me.dgList.ConnString = Nothing
        Me.dgList.dSourceUsePK = True
        Me.dgList.FilterPopUpMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
        Me.dgList.Location = New System.Drawing.Point(12, 54)
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
        Me.dgList.Size = New System.Drawing.Size(793, 389)
        Me.dgList.TabIndex = 6
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.dgList
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 42)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(797, 393)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(323, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(474, 42)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'frmSaldoPiutang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(817, 455)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "frmSaldoPiutang"
        Me.Text = "frmSaldoPiutang"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dTanggal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dTanggal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents dgList As meCore.ctrlMeDataGrid
    Friend WithEvents btnTampil As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents dTanggal As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
End Class
