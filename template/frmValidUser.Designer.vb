<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmValidUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmValidUser))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.btnkeluar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnvalidate = New DevExpress.XtraEditors.SimpleButton()
        Me.tpassword = New DevExpress.XtraEditors.TextEdit()
        Me.tUsername = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.CtrlMeDataGrid1 = New meCore.ctrlMeDataGrid()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.tpassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tUsername.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.btnkeluar)
        Me.LayoutControl1.Controls.Add(Me.btnvalidate)
        Me.LayoutControl1.Controls.Add(Me.tpassword)
        Me.LayoutControl1.Controls.Add(Me.tUsername)
        Me.LayoutControl1.Controls.Add(Me.LabelControl1)
        Me.LayoutControl1.Controls.Add(Me.CtrlMeDataGrid1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(377, 312)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'btnkeluar
        '
        Me.btnkeluar.Image = CType(resources.GetObject("btnkeluar.Image"), System.Drawing.Image)
        Me.btnkeluar.Location = New System.Drawing.Point(248, 262)
        Me.btnkeluar.Name = "btnkeluar"
        Me.btnkeluar.Size = New System.Drawing.Size(117, 38)
        Me.btnkeluar.StyleController = Me.LayoutControl1
        Me.btnkeluar.TabIndex = 9
        Me.btnkeluar.Text = "Keluar"
        '
        'btnvalidate
        '
        Me.btnvalidate.Image = CType(resources.GetObject("btnvalidate.Image"), System.Drawing.Image)
        Me.btnvalidate.Location = New System.Drawing.Point(127, 262)
        Me.btnvalidate.Name = "btnvalidate"
        Me.btnvalidate.Size = New System.Drawing.Size(117, 38)
        Me.btnvalidate.StyleController = Me.LayoutControl1
        Me.btnvalidate.TabIndex = 8
        Me.btnvalidate.Text = "Validate"
        '
        'tpassword
        '
        Me.tpassword.Location = New System.Drawing.Point(67, 238)
        Me.tpassword.Name = "tpassword"
        Me.tpassword.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tpassword.Size = New System.Drawing.Size(119, 20)
        Me.tpassword.StyleController = Me.LayoutControl1
        Me.tpassword.TabIndex = 7
        '
        'tUsername
        '
        Me.tUsername.Location = New System.Drawing.Point(67, 214)
        Me.tUsername.Name = "tUsername"
        Me.tUsername.Properties.ReadOnly = True
        Me.tUsername.Size = New System.Drawing.Size(119, 20)
        Me.tUsername.StyleController = Me.LayoutControl1
        Me.tUsername.TabIndex = 6
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(106, 19)
        Me.LabelControl1.StyleController = Me.LayoutControl1
        Me.LabelControl1.TabIndex = 5
        Me.LabelControl1.Text = "Validasi User"
        '
        'CtrlMeDataGrid1
        '
        Me.CtrlMeDataGrid1.colSum = Nothing
        Me.CtrlMeDataGrid1.ConnString = Nothing
        Me.CtrlMeDataGrid1.dSourceUsePK = True
        Me.CtrlMeDataGrid1.FilterPopUpMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
        Me.CtrlMeDataGrid1.Location = New System.Drawing.Point(12, 35)
        Me.CtrlMeDataGrid1.Name = "CtrlMeDataGrid1"
        Me.CtrlMeDataGrid1.PopDeleteShow = False
        Me.CtrlMeDataGrid1.PopExportShow = True
        Me.CtrlMeDataGrid1.PopNewShow = False
        Me.CtrlMeDataGrid1.PopOpenShow = False
        Me.CtrlMeDataGrid1.PopPrintShow = False
        Me.CtrlMeDataGrid1.PopRefreshShow = False
        Me.CtrlMeDataGrid1.Query = Nothing
        Me.CtrlMeDataGrid1.QueryTime = Nothing
        Me.CtrlMeDataGrid1.ShowFooter = True
        Me.CtrlMeDataGrid1.Size = New System.Drawing.Size(353, 175)
        Me.CtrlMeDataGrid1.TabIndex = 4
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.EmptySpaceItem1, Me.EmptySpaceItem2, Me.EmptySpaceItem3})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(377, 312)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.CtrlMeDataGrid1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 23)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(357, 179)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.LabelControl1
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(357, 23)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.tUsername
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 202)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(178, 24)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(178, 24)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(178, 24)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.Text = "User Name"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(52, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.tpassword
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 226)
        Me.LayoutControlItem4.MaxSize = New System.Drawing.Size(178, 24)
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(178, 24)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(178, 24)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem4.Text = "Password"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(52, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.btnvalidate
        Me.LayoutControlItem5.Image = CType(resources.GetObject("LayoutControlItem5.Image"), System.Drawing.Image)
        Me.LayoutControlItem5.Location = New System.Drawing.Point(115, 250)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(121, 42)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.btnkeluar
        Me.LayoutControlItem6.Location = New System.Drawing.Point(236, 250)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(121, 42)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 250)
        Me.EmptySpaceItem1.MaxSize = New System.Drawing.Size(115, 42)
        Me.EmptySpaceItem1.MinSize = New System.Drawing.Size(115, 42)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(115, 42)
        Me.EmptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(178, 202)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(179, 24)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(178, 226)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(179, 24)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'frmValidUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(377, 312)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "frmValidUser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmValidUser"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.tpassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tUsername.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents btnkeluar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnvalidate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tpassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tUsername As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CtrlMeDataGrid1 As meCore.ctrlMeDataGrid
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
End Class
