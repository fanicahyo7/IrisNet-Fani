<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLapNPM
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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLapNPM))
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.cCompany = New DevExpress.XtraEditors.CheckedListBoxControl()
        Me.cJenis = New System.Windows.Forms.ComboBox()
        Me.dPeriode = New DevExpress.XtraEditors.DateEdit()
        Me.tJenis = New DevExpress.XtraEditors.TextEdit()
        Me.btnAmbilData = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.cCompany, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dPeriode.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dPeriode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tJenis.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GridControl1
        Me.GridView2.Name = "GridView2"
        '
        'GridControl1
        '
        GridLevelNode1.LevelTemplate = Me.GridView2
        GridLevelNode1.RelationName = "Level1"
        Me.GridControl1.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl1.Location = New System.Drawing.Point(12, 237)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(772, 195)
        Me.GridControl1.TabIndex = 13
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1, Me.GridView2})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.cCompany)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Controls.Add(Me.cJenis)
        Me.LayoutControl1.Controls.Add(Me.dPeriode)
        Me.LayoutControl1.Controls.Add(Me.tJenis)
        Me.LayoutControl1.Controls.Add(Me.btnAmbilData)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(796, 444)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'cCompany
        '
        Me.cCompany.Cursor = System.Windows.Forms.Cursors.Default
        Me.cCompany.Location = New System.Drawing.Point(84, 37)
        Me.cCompany.Name = "cCompany"
        Me.cCompany.Size = New System.Drawing.Size(496, 130)
        Me.cCompany.StyleController = Me.LayoutControl1
        Me.cCompany.TabIndex = 14
        '
        'cJenis
        '
        Me.cJenis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cJenis.FormattingEnabled = True
        Me.cJenis.Items.AddRange(New Object() {"UE", "UM"})
        Me.cJenis.Location = New System.Drawing.Point(84, 12)
        Me.cJenis.Name = "cJenis"
        Me.cJenis.Size = New System.Drawing.Size(78, 21)
        Me.cJenis.TabIndex = 12
        '
        'dPeriode
        '
        Me.dPeriode.EditValue = Nothing
        Me.dPeriode.Location = New System.Drawing.Point(84, 171)
        Me.dPeriode.Name = "dPeriode"
        Me.dPeriode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dPeriode.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dPeriode.Size = New System.Drawing.Size(108, 20)
        Me.dPeriode.StyleController = Me.LayoutControl1
        Me.dPeriode.TabIndex = 10
        '
        'tJenis
        '
        Me.tJenis.Location = New System.Drawing.Point(166, 12)
        Me.tJenis.Name = "tJenis"
        Me.tJenis.Size = New System.Drawing.Size(618, 20)
        Me.tJenis.StyleController = Me.LayoutControl1
        Me.tJenis.TabIndex = 9
        '
        'btnAmbilData
        '
        Me.btnAmbilData.Image = CType(resources.GetObject("btnAmbilData.Image"), System.Drawing.Image)
        Me.btnAmbilData.Location = New System.Drawing.Point(84, 195)
        Me.btnAmbilData.Name = "btnAmbilData"
        Me.btnAmbilData.Size = New System.Drawing.Size(108, 38)
        Me.btnAmbilData.StyleController = Me.LayoutControl1
        Me.btnAmbilData.TabIndex = 8
        Me.btnAmbilData.Text = "Ambil Data"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.EmptySpaceItem2, Me.EmptySpaceItem3, Me.LayoutControlItem9, Me.LayoutControlItem2, Me.LayoutControlItem1, Me.EmptySpaceItem4})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(796, 444)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.btnAmbilData
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 183)
        Me.LayoutControlItem5.MaxSize = New System.Drawing.Size(184, 42)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(184, 42)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(184, 42)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.Text = " "
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(69, 13)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.tJenis
        Me.LayoutControlItem6.Location = New System.Drawing.Point(154, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(622, 25)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.dPeriode
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 159)
        Me.LayoutControlItem7.MaxSize = New System.Drawing.Size(184, 24)
        Me.LayoutControlItem7.MinSize = New System.Drawing.Size(184, 24)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(184, 24)
        Me.LayoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem7.Text = "Periode"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(69, 13)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(184, 159)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(592, 24)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(184, 183)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(592, 42)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.cJenis
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem9.MaxSize = New System.Drawing.Size(154, 25)
        Me.LayoutControlItem9.MinSize = New System.Drawing.Size(154, 25)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(154, 25)
        Me.LayoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem9.Text = "Jenis"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(69, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.GridControl1
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 225)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(776, 199)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.cCompany
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 25)
        Me.LayoutControlItem1.MaxSize = New System.Drawing.Size(572, 134)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(572, 134)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(572, 134)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.Text = "KodeCompany"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(69, 13)
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(572, 25)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(204, 134)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'frmLapNPM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(796, 444)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "frmLapNPM"
        Me.Text = "frmLapNPM"
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.cCompany, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dPeriode.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dPeriode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tJenis.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents tJenis As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnAmbilData As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents dPeriode As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents cJenis As System.Windows.Forms.ComboBox
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cCompany As DevExpress.XtraEditors.CheckedListBoxControl
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
End Class
