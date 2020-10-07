<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMstTeamOrder
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnHapusSemua = New DevExpress.XtraEditors.SimpleButton()
        Me.btnPilihSemua = New DevExpress.XtraEditors.SimpleButton()
        Me.btnHapus = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSimpan = New DevExpress.XtraEditors.SimpleButton()
        Me.tNama = New DevExpress.XtraEditors.TextEdit()
        Me.cKdSupplier = New meCore.cMeButtonBrowser()
        Me.CMeButtonBrowser1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.mdgListPilihan = New meCore.ctrlMeDataGrid()
        Me.tUserName = New DevExpress.XtraEditors.TextEdit()
        Me.tFirstName = New DevExpress.XtraEditors.TextEdit()
        Me.mdgList = New meCore.ctrlMeDataGrid()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem5 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem6 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tNama.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cKdSupplier.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CMeButtonBrowser1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tUserName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tFirstName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.DataGridView1)
        Me.LayoutControl1.Controls.Add(Me.btnHapusSemua)
        Me.LayoutControl1.Controls.Add(Me.btnPilihSemua)
        Me.LayoutControl1.Controls.Add(Me.btnHapus)
        Me.LayoutControl1.Controls.Add(Me.btnSimpan)
        Me.LayoutControl1.Controls.Add(Me.tNama)
        Me.LayoutControl1.Controls.Add(Me.cKdSupplier)
        Me.LayoutControl1.Controls.Add(Me.mdgListPilihan)
        Me.LayoutControl1.Controls.Add(Me.tUserName)
        Me.LayoutControl1.Controls.Add(Me.tFirstName)
        Me.LayoutControl1.Controls.Add(Me.mdgList)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(857, 394)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 362)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(298, 20)
        Me.DataGridView1.TabIndex = 14
        '
        'btnHapusSemua
        '
        Me.btnHapusSemua.Location = New System.Drawing.Point(462, 360)
        Me.btnHapusSemua.Name = "btnHapusSemua"
        Me.btnHapusSemua.Size = New System.Drawing.Size(130, 22)
        Me.btnHapusSemua.StyleController = Me.LayoutControl1
        Me.btnHapusSemua.TabIndex = 13
        Me.btnHapusSemua.Text = "Hapus Semua"
        '
        'btnPilihSemua
        '
        Me.btnPilihSemua.Location = New System.Drawing.Point(314, 360)
        Me.btnPilihSemua.Name = "btnPilihSemua"
        Me.btnPilihSemua.Size = New System.Drawing.Size(144, 22)
        Me.btnPilihSemua.StyleController = Me.LayoutControl1
        Me.btnPilihSemua.TabIndex = 12
        Me.btnPilihSemua.Text = "Pilih Semua"
        '
        'btnHapus
        '
        Me.btnHapus.Location = New System.Drawing.Point(655, 334)
        Me.btnHapus.Name = "btnHapus"
        Me.btnHapus.Size = New System.Drawing.Size(190, 22)
        Me.btnHapus.StyleController = Me.LayoutControl1
        Me.btnHapus.TabIndex = 11
        Me.btnHapus.Text = "Hapus"
        '
        'btnSimpan
        '
        Me.btnSimpan.Location = New System.Drawing.Point(515, 334)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(136, 22)
        Me.btnSimpan.StyleController = Me.LayoutControl1
        Me.btnSimpan.TabIndex = 10
        Me.btnSimpan.Text = "Simpan"
        '
        'tNama
        '
        Me.tNama.Location = New System.Drawing.Point(387, 310)
        Me.tNama.Name = "tNama"
        Me.tNama.Size = New System.Drawing.Size(228, 20)
        Me.tNama.StyleController = Me.LayoutControl1
        Me.tNama.TabIndex = 9
        '
        'cKdSupplier
        '
        Me.cKdSupplier.Location = New System.Drawing.Point(387, 286)
        Me.cKdSupplier.Name = "cKdSupplier"
        Me.cKdSupplier.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cKdSupplier.Properties.NullText = ""
        Me.cKdSupplier.Properties.View = Me.CMeButtonBrowser1View
        Me.cKdSupplier.Size = New System.Drawing.Size(124, 20)
        Me.cKdSupplier.StyleController = Me.LayoutControl1
        Me.cKdSupplier.TabIndex = 8
        '
        'CMeButtonBrowser1View
        '
        Me.CMeButtonBrowser1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.CMeButtonBrowser1View.Name = "CMeButtonBrowser1View"
        Me.CMeButtonBrowser1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.CMeButtonBrowser1View.OptionsView.ShowGroupPanel = False
        '
        'mdgListPilihan
        '
        Me.mdgListPilihan.colSum = Nothing
        Me.mdgListPilihan.ConnString = Nothing
        Me.mdgListPilihan.dSourceUsePK = True
        Me.mdgListPilihan.FilterPopUpMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
        Me.mdgListPilihan.Location = New System.Drawing.Point(314, 60)
        Me.mdgListPilihan.Name = "mdgListPilihan"
        Me.mdgListPilihan.PopDeleteShow = False
        Me.mdgListPilihan.PopExportShow = True
        Me.mdgListPilihan.PopNewShow = False
        Me.mdgListPilihan.PopOpenShow = False
        Me.mdgListPilihan.PopPrintShow = False
        Me.mdgListPilihan.PopRefreshShow = False
        Me.mdgListPilihan.Query = Nothing
        Me.mdgListPilihan.QueryTime = Nothing
        Me.mdgListPilihan.ShowFooter = True
        Me.mdgListPilihan.Size = New System.Drawing.Size(531, 222)
        Me.mdgListPilihan.TabIndex = 7
        '
        'tUserName
        '
        Me.tUserName.Location = New System.Drawing.Point(387, 12)
        Me.tUserName.Name = "tUserName"
        Me.tUserName.Size = New System.Drawing.Size(119, 20)
        Me.tUserName.StyleController = Me.LayoutControl1
        Me.tUserName.TabIndex = 6
        '
        'tFirstName
        '
        Me.tFirstName.Location = New System.Drawing.Point(387, 36)
        Me.tFirstName.Name = "tFirstName"
        Me.tFirstName.Size = New System.Drawing.Size(242, 20)
        Me.tFirstName.StyleController = Me.LayoutControl1
        Me.tFirstName.TabIndex = 5
        '
        'mdgList
        '
        Me.mdgList.colSum = Nothing
        Me.mdgList.ConnString = Nothing
        Me.mdgList.dSourceUsePK = True
        Me.mdgList.FilterPopUpMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
        Me.mdgList.Location = New System.Drawing.Point(12, 12)
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
        Me.mdgList.Size = New System.Drawing.Size(298, 346)
        Me.mdgList.TabIndex = 4
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem2, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.LayoutControlItem8, Me.EmptySpaceItem1, Me.LayoutControlItem9, Me.LayoutControlItem10, Me.EmptySpaceItem2, Me.EmptySpaceItem3, Me.EmptySpaceItem4, Me.EmptySpaceItem5, Me.EmptySpaceItem6, Me.LayoutControlItem11})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(857, 394)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.mdgList
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(302, 350)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.tUserName
        Me.LayoutControlItem3.Location = New System.Drawing.Point(302, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(196, 24)
        Me.LayoutControlItem3.Text = "Login"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(70, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.mdgListPilihan
        Me.LayoutControlItem4.Location = New System.Drawing.Point(302, 48)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(535, 226)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.tFirstName
        Me.LayoutControlItem2.Location = New System.Drawing.Point(302, 24)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(319, 24)
        Me.LayoutControlItem2.Text = "Nama Lengkap"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(70, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.cKdSupplier
        Me.LayoutControlItem5.Location = New System.Drawing.Point(302, 274)
        Me.LayoutControlItem5.MaxSize = New System.Drawing.Size(201, 24)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(201, 24)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(201, 24)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.Text = "Kode Supplier"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(70, 13)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.tNama
        Me.LayoutControlItem6.Location = New System.Drawing.Point(302, 298)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(305, 24)
        Me.LayoutControlItem6.Text = "Nama"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(70, 13)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.btnSimpan
        Me.LayoutControlItem7.Location = New System.Drawing.Point(503, 322)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(140, 26)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.btnHapus
        Me.LayoutControlItem8.Location = New System.Drawing.Point(643, 322)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(194, 26)
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(302, 322)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(201, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.btnPilihSemua
        Me.LayoutControlItem9.Location = New System.Drawing.Point(302, 348)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(148, 26)
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.btnHapusSemua
        Me.LayoutControlItem10.Location = New System.Drawing.Point(450, 348)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(134, 26)
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem10.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(584, 348)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(253, 26)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(498, 0)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(339, 24)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(621, 24)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(216, 24)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem5
        '
        Me.EmptySpaceItem5.AllowHotTrack = False
        Me.EmptySpaceItem5.Location = New System.Drawing.Point(503, 274)
        Me.EmptySpaceItem5.Name = "EmptySpaceItem5"
        Me.EmptySpaceItem5.Size = New System.Drawing.Size(334, 24)
        Me.EmptySpaceItem5.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem6
        '
        Me.EmptySpaceItem6.AllowHotTrack = False
        Me.EmptySpaceItem6.Location = New System.Drawing.Point(607, 298)
        Me.EmptySpaceItem6.Name = "EmptySpaceItem6"
        Me.EmptySpaceItem6.Size = New System.Drawing.Size(230, 24)
        Me.EmptySpaceItem6.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.DataGridView1
        Me.LayoutControlItem11.Location = New System.Drawing.Point(0, 350)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(302, 24)
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem11.TextVisible = False
        '
        'frmMstTeamOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(857, 394)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "frmMstTeamOrder"
        Me.Text = "frmMstTeamOrder"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tNama.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cKdSupplier.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CMeButtonBrowser1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tUserName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tFirstName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents btnHapusSemua As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnPilihSemua As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnHapus As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSimpan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tNama As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cKdSupplier As meCore.cMeButtonBrowser
    Friend WithEvents CMeButtonBrowser1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents mdgListPilihan As meCore.ctrlMeDataGrid
    Friend WithEvents tUserName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tFirstName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents mdgList As meCore.ctrlMeDataGrid
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem5 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem6 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
End Class
