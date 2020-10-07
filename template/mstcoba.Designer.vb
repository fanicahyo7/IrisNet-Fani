<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mstcoba
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.dTanggal = New DevExpress.XtraEditors.DateEdit()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnsimpan = New DevExpress.XtraEditors.SimpleButton()
        Me.btnbaru = New DevExpress.XtraEditors.SimpleButton()
        Me.tAlamat = New DevExpress.XtraEditors.TextEdit()
        Me.tNamacst = New DevExpress.XtraEditors.TextEdit()
        Me.tKodecst = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.tTanggal = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.dTanggal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dTanggal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tAlamat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tNamacst.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tKodecst.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tTanggal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.dTanggal)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl1.Controls.Add(Me.btnsimpan)
        Me.LayoutControl1.Controls.Add(Me.btnbaru)
        Me.LayoutControl1.Controls.Add(Me.tAlamat)
        Me.LayoutControl1.Controls.Add(Me.tNamacst)
        Me.LayoutControl1.Controls.Add(Me.tKodecst)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(394, 133)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'dTanggal
        '
        Me.dTanggal.EditValue = Nothing
        Me.dTanggal.Location = New System.Drawing.Point(53, 49)
        Me.dTanggal.Name = "dTanggal"
        Me.dTanggal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dTanggal.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dTanggal.Size = New System.Drawing.Size(312, 20)
        Me.dTanggal.StyleController = Me.LayoutControl1
        Me.dTanggal.TabIndex = 10
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(199, 99)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(81, 22)
        Me.SimpleButton1.StyleController = Me.LayoutControl1
        Me.SimpleButton1.TabIndex = 9
        Me.SimpleButton1.Text = "Simpan 2"
        '
        'btnsimpan
        '
        Me.btnsimpan.Location = New System.Drawing.Point(199, 73)
        Me.btnsimpan.Name = "btnsimpan"
        Me.btnsimpan.Size = New System.Drawing.Size(166, 22)
        Me.btnsimpan.StyleController = Me.LayoutControl1
        Me.btnsimpan.TabIndex = 8
        Me.btnsimpan.Text = "Simpan"
        '
        'btnbaru
        '
        Me.btnbaru.Location = New System.Drawing.Point(12, 73)
        Me.btnbaru.Name = "btnbaru"
        Me.btnbaru.Size = New System.Drawing.Size(183, 22)
        Me.btnbaru.StyleController = Me.LayoutControl1
        Me.btnbaru.TabIndex = 7
        Me.btnbaru.Text = "Baru"
        '
        'tAlamat
        '
        Me.tAlamat.Location = New System.Drawing.Point(53, 25)
        Me.tAlamat.Name = "tAlamat"
        Me.tAlamat.Size = New System.Drawing.Size(312, 20)
        Me.tAlamat.StyleController = Me.LayoutControl1
        Me.tAlamat.TabIndex = 6
        '
        'tNamacst
        '
        Me.tNamacst.Location = New System.Drawing.Point(53, 1)
        Me.tNamacst.Name = "tNamacst"
        Me.tNamacst.Size = New System.Drawing.Size(312, 20)
        Me.tNamacst.StyleController = Me.LayoutControl1
        Me.tNamacst.TabIndex = 5
        '
        'tKodecst
        '
        Me.tKodecst.EditValue = ""
        Me.tKodecst.Location = New System.Drawing.Point(53, -23)
        Me.tKodecst.Name = "tKodecst"
        Me.tKodecst.Size = New System.Drawing.Size(312, 20)
        Me.tKodecst.StyleController = Me.LayoutControl1
        Me.tKodecst.TabIndex = 4
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.EmptySpaceItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.tTanggal})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, -35)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(377, 168)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.tKodecst
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(357, 24)
        Me.LayoutControlItem1.Text = "Kode"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(38, 13)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(272, 122)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(85, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.tNamacst
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(357, 24)
        Me.LayoutControlItem2.Text = "Nama"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(38, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.tAlamat
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(357, 24)
        Me.LayoutControlItem3.Text = "Alamat"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(38, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.btnbaru
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 96)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(187, 52)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.btnsimpan
        Me.LayoutControlItem5.Location = New System.Drawing.Point(187, 96)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(170, 26)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.SimpleButton1
        Me.LayoutControlItem6.Location = New System.Drawing.Point(187, 122)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(85, 26)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'tTanggal
        '
        Me.tTanggal.Control = Me.dTanggal
        Me.tTanggal.Location = New System.Drawing.Point(0, 72)
        Me.tTanggal.Name = "tTanggal"
        Me.tTanggal.Size = New System.Drawing.Size(357, 24)
        Me.tTanggal.Text = "Tanggal"
        Me.tTanggal.TextSize = New System.Drawing.Size(38, 13)
        '
        'mstcoba
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 133)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "mstcoba"
        Me.Text = "mstcoba"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.dTanggal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dTanggal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tAlamat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tNamacst.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tKodecst.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tTanggal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents btnsimpan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnbaru As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tAlamat As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tNamacst As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tKodecst As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents dTanggal As DevExpress.XtraEditors.DateEdit
    Friend WithEvents tTanggal As DevExpress.XtraLayout.LayoutControlItem
End Class
