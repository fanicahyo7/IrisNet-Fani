<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptGolSupTerlaris
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
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRptGolSupTerlaris))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.lblTips = New DevExpress.XtraEditors.LabelControl()
        Me.cJenis = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cBukuAtk = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.tFilterInf = New DevExpress.XtraEditors.TextEdit()
        Me.mFilter = New meCore.mebuttonedit()
        Me.cRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.cQuery = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cTrans = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.d2 = New DevExpress.XtraEditors.DateEdit()
        Me.d1 = New DevExpress.XtraEditors.DateEdit()
        Me.mdgList = New meCore.ctrlMeDataGrid()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lcgHeader = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.cJenis.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cBukuAtk.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tFilterInf.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mFilter.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cQuery.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cTrans.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.d2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.d2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.d1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.d1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcgHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.lblTips)
        Me.LayoutControl1.Controls.Add(Me.cJenis)
        Me.LayoutControl1.Controls.Add(Me.cBukuAtk)
        Me.LayoutControl1.Controls.Add(Me.tFilterInf)
        Me.LayoutControl1.Controls.Add(Me.mFilter)
        Me.LayoutControl1.Controls.Add(Me.cRefresh)
        Me.LayoutControl1.Controls.Add(Me.cQuery)
        Me.LayoutControl1.Controls.Add(Me.cTrans)
        Me.LayoutControl1.Controls.Add(Me.d2)
        Me.LayoutControl1.Controls.Add(Me.d1)
        Me.LayoutControl1.Controls.Add(Me.mdgList)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(732, 313)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'lblTips
        '
        Me.lblTips.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblTips.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.lblTips.Appearance.Options.UseFont = True
        Me.lblTips.Appearance.Options.UseForeColor = True
        Me.lblTips.Appearance.Options.UseTextOptions = True
        Me.lblTips.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.lblTips.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.lblTips.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.lblTips.Location = New System.Drawing.Point(521, 5)
        Me.lblTips.Name = "lblTips"
        Me.lblTips.Size = New System.Drawing.Size(206, 78)
        Me.lblTips.StyleController = Me.LayoutControl1
        Me.lblTips.TabIndex = 15
        Me.lblTips.Text = "LabelControl1 asdakjshdakjsd aksjdhaksdjha skda sdhaksjdhiqwueq  qoweqowieuq asda" & _
    "jloq alksdjalksdj"
        '
        'cJenis
        '
        Me.cJenis.Location = New System.Drawing.Point(213, 53)
        Me.cJenis.Name = "cJenis"
        Me.cJenis.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cJenis.Properties.Items.AddRange(New Object() {"TOTAL", "KONSI", "KREDIT"})
        Me.cJenis.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cJenis.Size = New System.Drawing.Size(108, 20)
        Me.cJenis.StyleController = Me.LayoutControl1
        Me.cJenis.TabIndex = 14
        '
        'cBukuAtk
        '
        Me.cBukuAtk.Location = New System.Drawing.Point(53, 53)
        Me.cBukuAtk.Name = "cBukuAtk"
        Me.cBukuAtk.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cBukuAtk.Properties.Items.AddRange(New Object() {"TOTAL", "BUKU", "ATK"})
        Me.cBukuAtk.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cBukuAtk.Size = New System.Drawing.Size(108, 20)
        Me.cBukuAtk.StyleController = Me.LayoutControl1
        Me.cBukuAtk.TabIndex = 13
        '
        'tFilterInf
        '
        Me.tFilterInf.Location = New System.Drawing.Point(165, 101)
        Me.tFilterInf.Name = "tFilterInf"
        Me.tFilterInf.Size = New System.Drawing.Size(156, 20)
        Me.tFilterInf.StyleController = Me.LayoutControl1
        Me.tFilterInf.TabIndex = 11
        '
        'mFilter
        '
        Me.mFilter.Location = New System.Drawing.Point(53, 101)
        Me.mFilter.Name = "mFilter"
        Me.mFilter.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "Add New", Nothing, Nothing, True)})
        Me.mFilter.Size = New System.Drawing.Size(108, 20)
        Me.mFilter.StyleController = Me.LayoutControl1
        Me.mFilter.TabIndex = 10
        '
        'cRefresh
        '
        Me.cRefresh.Image = CType(resources.GetObject("cRefresh.Image"), System.Drawing.Image)
        Me.cRefresh.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.cRefresh.Location = New System.Drawing.Point(325, 5)
        Me.cRefresh.Name = "cRefresh"
        Me.cRefresh.Size = New System.Drawing.Size(192, 116)
        Me.cRefresh.StyleController = Me.LayoutControl1
        Me.cRefresh.TabIndex = 9
        Me.cRefresh.Text = "Refresh"
        '
        'cQuery
        '
        Me.cQuery.Location = New System.Drawing.Point(53, 77)
        Me.cQuery.Name = "cQuery"
        Me.cQuery.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cQuery.Properties.Items.AddRange(New Object() {"SUPPLIER", "GOLONGAN"})
        Me.cQuery.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cQuery.Size = New System.Drawing.Size(268, 20)
        Me.cQuery.StyleController = Me.LayoutControl1
        Me.cQuery.TabIndex = 8
        '
        'cTrans
        '
        Me.cTrans.Location = New System.Drawing.Point(53, 29)
        Me.cTrans.Name = "cTrans"
        Me.cTrans.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cTrans.Properties.Items.AddRange(New Object() {"TOTAL", "BO", "KASIR"})
        Me.cTrans.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cTrans.Size = New System.Drawing.Size(268, 20)
        Me.cTrans.StyleController = Me.LayoutControl1
        Me.cTrans.TabIndex = 7
        '
        'd2
        '
        Me.d2.EditValue = Nothing
        Me.d2.Location = New System.Drawing.Point(213, 5)
        Me.d2.Name = "d2"
        Me.d2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.d2.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.d2.Size = New System.Drawing.Size(108, 20)
        Me.d2.StyleController = Me.LayoutControl1
        Me.d2.TabIndex = 6
        '
        'd1
        '
        Me.d1.EditValue = Nothing
        Me.d1.Location = New System.Drawing.Point(53, 5)
        Me.d1.Name = "d1"
        Me.d1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.d1.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.d1.Size = New System.Drawing.Size(108, 20)
        Me.d1.StyleController = Me.LayoutControl1
        Me.d1.TabIndex = 5
        '
        'mdgList
        '
        Me.mdgList.colSum = Nothing
        Me.mdgList.ConnString = Nothing
        Me.mdgList.dSourceUsePK = True
        Me.mdgList.Location = New System.Drawing.Point(5, 125)
        Me.mdgList.Name = "mdgList"
        Me.mdgList.PopDeleteShow = False
        Me.mdgList.PopNewShow = False
        Me.mdgList.PopOpenShow = False
        Me.mdgList.PopRefreshShow = False
        Me.mdgList.Query = Nothing
        Me.mdgList.QueryTime = Nothing
        Me.mdgList.ShowFooter = True
        Me.mdgList.Size = New System.Drawing.Size(722, 183)
        Me.mdgList.TabIndex = 4
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.lcgHeader})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(732, 313)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.mdgList
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 120)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(726, 187)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'lcgHeader
        '
        Me.lcgHeader.GroupBordersVisible = False
        Me.lcgHeader.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup2, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem7, Me.LayoutControlItem8, Me.LayoutControlItem6, Me.LayoutControlItem10, Me.LayoutControlItem11, Me.LayoutControlItem9, Me.EmptySpaceItem1})
        Me.lcgHeader.Location = New System.Drawing.Point(0, 0)
        Me.lcgHeader.Name = "lcgHeader"
        Me.lcgHeader.Size = New System.Drawing.Size(726, 120)
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.GroupBordersVisible = False
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem3})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(320, 24)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.d1
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.MaxSize = New System.Drawing.Size(160, 24)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(160, 24)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(160, 24)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.Text = "Tanggal"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(45, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.d2
        Me.LayoutControlItem3.Location = New System.Drawing.Point(160, 0)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(160, 24)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(160, 24)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(160, 24)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.Text = "   s/d   "
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(45, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.cTrans
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(320, 24)
        Me.LayoutControlItem4.Text = "Transaksi"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(45, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.cQuery
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(320, 24)
        Me.LayoutControlItem5.Text = "Query"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(45, 13)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.mFilter
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 96)
        Me.LayoutControlItem7.MaxSize = New System.Drawing.Size(160, 24)
        Me.LayoutControlItem7.MinSize = New System.Drawing.Size(160, 24)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(160, 24)
        Me.LayoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem7.Text = "Filter"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(45, 13)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.tFilterInf
        Me.LayoutControlItem8.Location = New System.Drawing.Point(160, 96)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(160, 24)
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.cRefresh
        Me.LayoutControlItem6.Location = New System.Drawing.Point(320, 0)
        Me.LayoutControlItem6.MaxSize = New System.Drawing.Size(196, 0)
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(196, 26)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(196, 120)
        Me.LayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.cBukuAtk
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem10.MaxSize = New System.Drawing.Size(160, 24)
        Me.LayoutControlItem10.MinSize = New System.Drawing.Size(160, 24)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(160, 24)
        Me.LayoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem10.Text = "Buku ATK"
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(45, 13)
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.cJenis
        Me.LayoutControlItem11.Location = New System.Drawing.Point(160, 48)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(160, 24)
        Me.LayoutControlItem11.Text = "Jenis"
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(45, 13)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.lblTips
        Me.LayoutControlItem9.Location = New System.Drawing.Point(516, 0)
        Me.LayoutControlItem9.MinSize = New System.Drawing.Size(70, 17)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(210, 82)
        Me.LayoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(516, 82)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(210, 38)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'frmRptGolSupTerlaris
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(732, 313)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "frmRptGolSupTerlaris"
        Me.Text = "frmRptGolSupTerlaris"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.cJenis.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cBukuAtk.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tFilterInf.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mFilter.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cQuery.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cTrans.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.d2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.d2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.d1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.d1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcgHeader, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents cQuery As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cTrans As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents d2 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents d1 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents mdgList As meCore.ctrlMeDataGrid
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents tFilterInf As DevExpress.XtraEditors.TextEdit
    Friend WithEvents mFilter As meCore.mebuttonedit
    Friend WithEvents cRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lcgHeader As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents cJenis As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cBukuAtk As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lblTips As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
End Class
