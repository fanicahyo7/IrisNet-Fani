<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmmstBankAdd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmmstBankAdd))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.cStatus = New DevExpress.XtraEditors.CheckEdit()
        Me.tKdBank = New DevExpress.XtraEditors.TextEdit()
        Me.btnSimpan = New DevExpress.XtraEditors.SimpleButton()
        Me.btnBaru = New DevExpress.XtraEditors.SimpleButton()
        Me.tNoRekLength = New DevExpress.XtraEditors.SpinEdit()
        Me.tNamaBank = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.cStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tKdBank.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tNoRekLength.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tNamaBank.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.cStatus)
        Me.LayoutControl1.Controls.Add(Me.tKdBank)
        Me.LayoutControl1.Controls.Add(Me.btnSimpan)
        Me.LayoutControl1.Controls.Add(Me.btnBaru)
        Me.LayoutControl1.Controls.Add(Me.tNoRekLength)
        Me.LayoutControl1.Controls.Add(Me.tNamaBank)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(447, 159)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'cStatus
        '
        Me.cStatus.Location = New System.Drawing.Point(12, 12)
        Me.cStatus.Name = "cStatus"
        Me.cStatus.Properties.Caption = "Aktif"
        Me.cStatus.Size = New System.Drawing.Size(423, 19)
        Me.cStatus.StyleController = Me.LayoutControl1
        Me.cStatus.TabIndex = 10
        '
        'tKdBank
        '
        Me.tKdBank.Location = New System.Drawing.Point(93, 35)
        Me.tKdBank.Name = "tKdBank"
        Me.tKdBank.Size = New System.Drawing.Size(105, 20)
        Me.tKdBank.StyleController = Me.LayoutControl1
        Me.tKdBank.TabIndex = 9
        '
        'btnSimpan
        '
        Me.btnSimpan.Image = CType(resources.GetObject("btnSimpan.Image"), System.Drawing.Image)
        Me.btnSimpan.Location = New System.Drawing.Point(308, 107)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(127, 40)
        Me.btnSimpan.StyleController = Me.LayoutControl1
        Me.btnSimpan.TabIndex = 8
        Me.btnSimpan.Text = "Simpan"
        '
        'btnBaru
        '
        Me.btnBaru.Image = CType(resources.GetObject("btnBaru.Image"), System.Drawing.Image)
        Me.btnBaru.Location = New System.Drawing.Point(179, 107)
        Me.btnBaru.Name = "btnBaru"
        Me.btnBaru.Size = New System.Drawing.Size(125, 40)
        Me.btnBaru.StyleController = Me.LayoutControl1
        Me.btnBaru.TabIndex = 7
        Me.btnBaru.Text = "Baru"
        '
        'tNoRekLength
        '
        Me.tNoRekLength.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.tNoRekLength.Location = New System.Drawing.Point(93, 83)
        Me.tNoRekLength.Name = "tNoRekLength"
        Me.tNoRekLength.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.tNoRekLength.Size = New System.Drawing.Size(56, 20)
        Me.tNoRekLength.StyleController = Me.LayoutControl1
        Me.tNoRekLength.TabIndex = 6
        '
        'tNamaBank
        '
        Me.tNamaBank.Location = New System.Drawing.Point(93, 59)
        Me.tNamaBank.Name = "tNamaBank"
        Me.tNamaBank.Size = New System.Drawing.Size(206, 20)
        Me.tNamaBank.StyleController = Me.LayoutControl1
        Me.tNamaBank.TabIndex = 5
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem3, Me.EmptySpaceItem2, Me.LayoutControlItem1, Me.LayoutControlItem4, Me.EmptySpaceItem3, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.EmptySpaceItem1, Me.EmptySpaceItem4})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(447, 159)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.tNamaBank
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 47)
        Me.LayoutControlItem2.MaxSize = New System.Drawing.Size(291, 24)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(291, 24)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(291, 24)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.Text = "Nama Bank"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(78, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.tNoRekLength
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 71)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(141, 24)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(141, 24)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(141, 24)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.Text = "No. Rek. Length"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(78, 13)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(141, 71)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(286, 24)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.btnBaru
        Me.LayoutControlItem1.Location = New System.Drawing.Point(167, 95)
        Me.LayoutControlItem1.MaxSize = New System.Drawing.Size(129, 44)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(129, 44)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(129, 44)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.btnSimpan
        Me.LayoutControlItem4.Location = New System.Drawing.Point(296, 95)
        Me.LayoutControlItem4.MaxSize = New System.Drawing.Size(131, 44)
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(131, 44)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(131, 44)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(0, 95)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(167, 44)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.tKdBank
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 23)
        Me.LayoutControlItem5.MaxSize = New System.Drawing.Size(190, 24)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(190, 24)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(190, 24)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.Text = "Kode Bank"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(78, 13)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.cStatus
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem6.MaxSize = New System.Drawing.Size(427, 23)
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(427, 23)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(427, 23)
        Me.LayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(190, 23)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(237, 24)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(291, 47)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(136, 24)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'frmmstBankAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(447, 159)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "frmmstBankAdd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.cStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tKdBank.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tNoRekLength.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tNamaBank.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents tKdBank As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnSimpan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnBaru As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tNoRekLength As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents tNamaBank As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cStatus As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
End Class
