<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPengunjung
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPengunjung))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.tNamaSecurity = New DevExpress.XtraEditors.TextEdit()
        Me.cShift = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.btnKeluar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSimpan = New DevExpress.XtraEditors.SimpleButton()
        Me.tManula = New System.Windows.Forms.NumericUpDown()
        Me.tDewasa = New System.Windows.Forms.NumericUpDown()
        Me.tRemaja = New System.Windows.Forms.NumericUpDown()
        Me.tAnak = New System.Windows.Forms.NumericUpDown()
        Me.dTanggal = New DevExpress.XtraEditors.DateEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem5 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.tNamaSecurity.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cShift.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tManula, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tDewasa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tRemaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tAnak, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dTanggal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dTanggal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.tNamaSecurity)
        Me.LayoutControl1.Controls.Add(Me.cShift)
        Me.LayoutControl1.Controls.Add(Me.btnKeluar)
        Me.LayoutControl1.Controls.Add(Me.btnSimpan)
        Me.LayoutControl1.Controls.Add(Me.tManula)
        Me.LayoutControl1.Controls.Add(Me.tDewasa)
        Me.LayoutControl1.Controls.Add(Me.tRemaja)
        Me.LayoutControl1.Controls.Add(Me.tAnak)
        Me.LayoutControl1.Controls.Add(Me.dTanggal)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(289, 183)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'tNamaSecurity
        '
        Me.tNamaSecurity.Location = New System.Drawing.Point(84, 60)
        Me.tNamaSecurity.Name = "tNamaSecurity"
        Me.tNamaSecurity.Size = New System.Drawing.Size(193, 20)
        Me.tNamaSecurity.StyleController = Me.LayoutControl1
        Me.tNamaSecurity.TabIndex = 12
        '
        'cShift
        '
        Me.cShift.Location = New System.Drawing.Point(84, 36)
        Me.cShift.Name = "cShift"
        Me.cShift.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cShift.Properties.Items.AddRange(New Object() {"SIANG", "MALAM"})
        Me.cShift.Size = New System.Drawing.Size(83, 20)
        Me.cShift.StyleController = Me.LayoutControl1
        Me.cShift.TabIndex = 11
        '
        'btnKeluar
        '
        Me.btnKeluar.Image = CType(resources.GetObject("btnKeluar.Image"), System.Drawing.Image)
        Me.btnKeluar.Location = New System.Drawing.Point(188, 132)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(89, 39)
        Me.btnKeluar.StyleController = Me.LayoutControl1
        Me.btnKeluar.TabIndex = 10
        Me.btnKeluar.Text = "Keluar"
        '
        'btnSimpan
        '
        Me.btnSimpan.Image = CType(resources.GetObject("btnSimpan.Image"), System.Drawing.Image)
        Me.btnSimpan.Location = New System.Drawing.Point(86, 132)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(98, 39)
        Me.btnSimpan.StyleController = Me.LayoutControl1
        Me.btnSimpan.TabIndex = 9
        Me.btnSimpan.Text = "Simpan"
        '
        'tManula
        '
        Me.tManula.Location = New System.Drawing.Point(219, 108)
        Me.tManula.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.tManula.Name = "tManula"
        Me.tManula.Size = New System.Drawing.Size(58, 21)
        Me.tManula.TabIndex = 8
        '
        'tDewasa
        '
        Me.tDewasa.Location = New System.Drawing.Point(219, 84)
        Me.tDewasa.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.tDewasa.Name = "tDewasa"
        Me.tDewasa.Size = New System.Drawing.Size(58, 21)
        Me.tDewasa.TabIndex = 7
        '
        'tRemaja
        '
        Me.tRemaja.Location = New System.Drawing.Point(84, 108)
        Me.tRemaja.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.tRemaja.Name = "tRemaja"
        Me.tRemaja.Size = New System.Drawing.Size(59, 21)
        Me.tRemaja.TabIndex = 6
        '
        'tAnak
        '
        Me.tAnak.Location = New System.Drawing.Point(84, 84)
        Me.tAnak.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.tAnak.Name = "tAnak"
        Me.tAnak.Size = New System.Drawing.Size(59, 21)
        Me.tAnak.TabIndex = 5
        '
        'dTanggal
        '
        Me.dTanggal.EditValue = Nothing
        Me.dTanggal.Location = New System.Drawing.Point(84, 12)
        Me.dTanggal.Name = "dTanggal"
        Me.dTanggal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dTanggal.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dTanggal.Size = New System.Drawing.Size(83, 20)
        Me.dTanggal.StyleController = Me.LayoutControl1
        Me.dTanggal.TabIndex = 4
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem6, Me.EmptySpaceItem2, Me.LayoutControlItem7, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.EmptySpaceItem5, Me.LayoutControlItem8, Me.EmptySpaceItem1, Me.LayoutControlItem9})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(289, 183)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.dTanggal
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.MaxSize = New System.Drawing.Size(159, 24)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(159, 24)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(159, 24)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.Text = "Tanggal"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(69, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.tAnak
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem2.MaxSize = New System.Drawing.Size(135, 24)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(135, 24)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(135, 24)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.Text = "Anak-Anak"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(69, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.tRemaja
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 96)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(135, 24)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(135, 24)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(135, 24)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.Text = "Remaja"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(69, 13)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.btnSimpan
        Me.LayoutControlItem6.Location = New System.Drawing.Point(74, 120)
        Me.LayoutControlItem6.MaxSize = New System.Drawing.Size(102, 43)
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(102, 43)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(102, 43)
        Me.LayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(159, 0)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(110, 24)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.btnKeluar
        Me.LayoutControlItem7.Location = New System.Drawing.Point(176, 120)
        Me.LayoutControlItem7.MaxSize = New System.Drawing.Size(93, 43)
        Me.LayoutControlItem7.MinSize = New System.Drawing.Size(93, 43)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(93, 43)
        Me.LayoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.tDewasa
        Me.LayoutControlItem4.Location = New System.Drawing.Point(135, 72)
        Me.LayoutControlItem4.MaxSize = New System.Drawing.Size(134, 24)
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(134, 24)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(134, 24)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem4.Text = "  Dewasa"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(69, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.tManula
        Me.LayoutControlItem5.Location = New System.Drawing.Point(135, 96)
        Me.LayoutControlItem5.MaxSize = New System.Drawing.Size(134, 24)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(134, 24)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(134, 24)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.Text = "  Manula"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(69, 13)
        '
        'EmptySpaceItem5
        '
        Me.EmptySpaceItem5.AllowHotTrack = False
        Me.EmptySpaceItem5.Location = New System.Drawing.Point(0, 120)
        Me.EmptySpaceItem5.MaxSize = New System.Drawing.Size(74, 43)
        Me.EmptySpaceItem5.MinSize = New System.Drawing.Size(74, 43)
        Me.EmptySpaceItem5.Name = "EmptySpaceItem5"
        Me.EmptySpaceItem5.Size = New System.Drawing.Size(74, 43)
        Me.EmptySpaceItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem5.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.cShift
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem8.MaxSize = New System.Drawing.Size(159, 24)
        Me.LayoutControlItem8.MinSize = New System.Drawing.Size(159, 24)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(159, 24)
        Me.LayoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem8.Text = "Shift Kerja"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(69, 13)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(159, 24)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(110, 24)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.tNamaSecurity
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem9.MaxSize = New System.Drawing.Size(269, 24)
        Me.LayoutControlItem9.MinSize = New System.Drawing.Size(269, 24)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(269, 24)
        Me.LayoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem9.Text = "Nama Security"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(69, 13)
        '
        'frmPengunjung
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(289, 183)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "frmPengunjung"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmPengunjung"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.tNamaSecurity.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cShift.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tManula, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tDewasa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tRemaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tAnak, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dTanggal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dTanggal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents btnSimpan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tManula As System.Windows.Forms.NumericUpDown
    Friend WithEvents tDewasa As System.Windows.Forms.NumericUpDown
    Friend WithEvents tRemaja As System.Windows.Forms.NumericUpDown
    Friend WithEvents tAnak As System.Windows.Forms.NumericUpDown
    Friend WithEvents dTanggal As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnKeluar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem5 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents tNamaSecurity As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cShift As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
End Class
