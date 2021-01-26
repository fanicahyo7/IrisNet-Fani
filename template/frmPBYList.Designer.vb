<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPBYList
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
        Me.btnCetak = New DevExpress.XtraEditors.SimpleButton()
        Me.btnPBYBaru = New DevExpress.XtraEditors.SimpleButton()
        Me.btnPerforma = New DevExpress.XtraEditors.SimpleButton()
        Me.btnExport = New DevExpress.XtraEditors.SimpleButton()
        Me.btnLaporan = New DevExpress.XtraEditors.SimpleButton()
        Me.btnValidasi = New DevExpress.XtraEditors.SimpleButton()
        Me.sTotalSisa = New DevExpress.XtraEditors.SpinEdit()
        Me.sTotalLunas = New DevExpress.XtraEditors.SpinEdit()
        Me.sTotalValid = New DevExpress.XtraEditors.SpinEdit()
        Me.sPengajuan = New DevExpress.XtraEditors.SpinEdit()
        Me.dgListDetail = New meCore.ctrlMeDataGrid()
        Me.dgList = New meCore.ctrlMeDataGrid()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem15 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem16 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem17 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem5 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.sTotalSisa.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sTotalLunas.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sTotalValid.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sPengajuan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.btnCetak)
        Me.LayoutControl1.Controls.Add(Me.btnPBYBaru)
        Me.LayoutControl1.Controls.Add(Me.btnPerforma)
        Me.LayoutControl1.Controls.Add(Me.btnExport)
        Me.LayoutControl1.Controls.Add(Me.btnLaporan)
        Me.LayoutControl1.Controls.Add(Me.btnValidasi)
        Me.LayoutControl1.Controls.Add(Me.sTotalSisa)
        Me.LayoutControl1.Controls.Add(Me.sTotalLunas)
        Me.LayoutControl1.Controls.Add(Me.sTotalValid)
        Me.LayoutControl1.Controls.Add(Me.sPengajuan)
        Me.LayoutControl1.Controls.Add(Me.dgListDetail)
        Me.LayoutControl1.Controls.Add(Me.dgList)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(805, 413)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'btnCetak
        '
        Me.btnCetak.Location = New System.Drawing.Point(436, 379)
        Me.btnCetak.Name = "btnCetak"
        Me.btnCetak.Size = New System.Drawing.Size(115, 22)
        Me.btnCetak.StyleController = Me.LayoutControl1
        Me.btnCetak.TabIndex = 27
        Me.btnCetak.Text = "Cetak"
        '
        'btnPBYBaru
        '
        Me.btnPBYBaru.Location = New System.Drawing.Point(555, 379)
        Me.btnPBYBaru.Name = "btnPBYBaru"
        Me.btnPBYBaru.Size = New System.Drawing.Size(156, 22)
        Me.btnPBYBaru.StyleController = Me.LayoutControl1
        Me.btnPBYBaru.TabIndex = 26
        Me.btnPBYBaru.Text = "Buat Pengajuan Baru"
        '
        'btnPerforma
        '
        Me.btnPerforma.Location = New System.Drawing.Point(715, 379)
        Me.btnPerforma.Name = "btnPerforma"
        Me.btnPerforma.Size = New System.Drawing.Size(78, 22)
        Me.btnPerforma.StyleController = Me.LayoutControl1
        Me.btnPerforma.TabIndex = 25
        Me.btnPerforma.Text = "Buat Performa"
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(317, 379)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(115, 22)
        Me.btnExport.StyleController = Me.LayoutControl1
        Me.btnExport.TabIndex = 24
        Me.btnExport.Text = "Export"
        '
        'btnLaporan
        '
        Me.btnLaporan.Location = New System.Drawing.Point(147, 379)
        Me.btnLaporan.Name = "btnLaporan"
        Me.btnLaporan.Size = New System.Drawing.Size(118, 22)
        Me.btnLaporan.StyleController = Me.LayoutControl1
        Me.btnLaporan.TabIndex = 23
        Me.btnLaporan.Text = "Laporan"
        '
        'btnValidasi
        '
        Me.btnValidasi.Location = New System.Drawing.Point(12, 379)
        Me.btnValidasi.Name = "btnValidasi"
        Me.btnValidasi.Size = New System.Drawing.Size(131, 22)
        Me.btnValidasi.StyleController = Me.LayoutControl1
        Me.btnValidasi.TabIndex = 22
        Me.btnValidasi.Text = "Validasi Pengajuan"
        '
        'sTotalSisa
        '
        Me.sTotalSisa.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.sTotalSisa.Location = New System.Drawing.Point(249, 355)
        Me.sTotalSisa.Name = "sTotalSisa"
        Me.sTotalSisa.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.sTotalSisa.Size = New System.Drawing.Size(116, 20)
        Me.sTotalSisa.StyleController = Me.LayoutControl1
        Me.sTotalSisa.TabIndex = 21
        '
        'sTotalLunas
        '
        Me.sTotalLunas.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.sTotalLunas.Location = New System.Drawing.Point(249, 331)
        Me.sTotalLunas.Name = "sTotalLunas"
        Me.sTotalLunas.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.sTotalLunas.Size = New System.Drawing.Size(116, 20)
        Me.sTotalLunas.StyleController = Me.LayoutControl1
        Me.sTotalLunas.TabIndex = 20
        '
        'sTotalValid
        '
        Me.sTotalValid.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.sTotalValid.Location = New System.Drawing.Point(249, 307)
        Me.sTotalValid.Name = "sTotalValid"
        Me.sTotalValid.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.sTotalValid.Size = New System.Drawing.Size(116, 20)
        Me.sTotalValid.StyleController = Me.LayoutControl1
        Me.sTotalValid.TabIndex = 19
        '
        'sPengajuan
        '
        Me.sPengajuan.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.sPengajuan.Location = New System.Drawing.Point(249, 283)
        Me.sPengajuan.Name = "sPengajuan"
        Me.sPengajuan.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.sPengajuan.Size = New System.Drawing.Size(116, 20)
        Me.sPengajuan.StyleController = Me.LayoutControl1
        Me.sPengajuan.TabIndex = 18
        '
        'dgListDetail
        '
        Me.dgListDetail.colSum = Nothing
        Me.dgListDetail.ConnString = Nothing
        Me.dgListDetail.dSourceUsePK = True
        Me.dgListDetail.FilterPopUpMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
        Me.dgListDetail.Location = New System.Drawing.Point(191, 12)
        Me.dgListDetail.Name = "dgListDetail"
        Me.dgListDetail.PopDeleteShow = False
        Me.dgListDetail.PopExportShow = True
        Me.dgListDetail.PopNewShow = False
        Me.dgListDetail.PopOpenShow = False
        Me.dgListDetail.PopPrintShow = False
        Me.dgListDetail.PopRefreshShow = False
        Me.dgListDetail.Query = Nothing
        Me.dgListDetail.QueryTime = Nothing
        Me.dgListDetail.ShowFooter = True
        Me.dgListDetail.Size = New System.Drawing.Size(602, 267)
        Me.dgListDetail.TabIndex = 5
        '
        'dgList
        '
        Me.dgList.colSum = Nothing
        Me.dgList.ConnString = Nothing
        Me.dgList.dSourceUsePK = True
        Me.dgList.FilterPopUpMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
        Me.dgList.Location = New System.Drawing.Point(12, 12)
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
        Me.dgList.Size = New System.Drawing.Size(175, 363)
        Me.dgList.TabIndex = 4
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem14, Me.LayoutControlItem15, Me.LayoutControlItem16, Me.LayoutControlItem17, Me.EmptySpaceItem1, Me.EmptySpaceItem2, Me.EmptySpaceItem3, Me.EmptySpaceItem4, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.EmptySpaceItem5, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.LayoutControlItem8})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(805, 413)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.dgList
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(179, 367)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.dgListDetail
        Me.LayoutControlItem2.Location = New System.Drawing.Point(179, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(606, 271)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.sPengajuan
        Me.LayoutControlItem14.Location = New System.Drawing.Point(179, 271)
        Me.LayoutControlItem14.MaxSize = New System.Drawing.Size(178, 24)
        Me.LayoutControlItem14.MinSize = New System.Drawing.Size(178, 24)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(178, 24)
        Me.LayoutControlItem14.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem14.Text = "Pengajuan"
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(55, 13)
        '
        'LayoutControlItem15
        '
        Me.LayoutControlItem15.Control = Me.sTotalValid
        Me.LayoutControlItem15.Location = New System.Drawing.Point(179, 295)
        Me.LayoutControlItem15.MaxSize = New System.Drawing.Size(178, 24)
        Me.LayoutControlItem15.MinSize = New System.Drawing.Size(178, 24)
        Me.LayoutControlItem15.Name = "LayoutControlItem15"
        Me.LayoutControlItem15.Size = New System.Drawing.Size(178, 24)
        Me.LayoutControlItem15.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem15.Text = "Total Valid"
        Me.LayoutControlItem15.TextSize = New System.Drawing.Size(55, 13)
        '
        'LayoutControlItem16
        '
        Me.LayoutControlItem16.Control = Me.sTotalLunas
        Me.LayoutControlItem16.Location = New System.Drawing.Point(179, 319)
        Me.LayoutControlItem16.MaxSize = New System.Drawing.Size(178, 24)
        Me.LayoutControlItem16.MinSize = New System.Drawing.Size(178, 24)
        Me.LayoutControlItem16.Name = "LayoutControlItem16"
        Me.LayoutControlItem16.Size = New System.Drawing.Size(178, 24)
        Me.LayoutControlItem16.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem16.Text = "Total Lunas"
        Me.LayoutControlItem16.TextSize = New System.Drawing.Size(55, 13)
        '
        'LayoutControlItem17
        '
        Me.LayoutControlItem17.Control = Me.sTotalSisa
        Me.LayoutControlItem17.Location = New System.Drawing.Point(179, 343)
        Me.LayoutControlItem17.MaxSize = New System.Drawing.Size(178, 24)
        Me.LayoutControlItem17.MinSize = New System.Drawing.Size(178, 24)
        Me.LayoutControlItem17.Name = "LayoutControlItem17"
        Me.LayoutControlItem17.Size = New System.Drawing.Size(178, 24)
        Me.LayoutControlItem17.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem17.Text = "Total Sisa"
        Me.LayoutControlItem17.TextSize = New System.Drawing.Size(55, 13)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(357, 295)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(428, 24)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(357, 271)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(428, 24)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(357, 319)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(428, 24)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(357, 343)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(428, 24)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.btnValidasi
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 367)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(135, 26)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.btnLaporan
        Me.LayoutControlItem4.Location = New System.Drawing.Point(135, 367)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(122, 26)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.btnExport
        Me.LayoutControlItem5.Location = New System.Drawing.Point(305, 367)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(119, 26)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'EmptySpaceItem5
        '
        Me.EmptySpaceItem5.AllowHotTrack = False
        Me.EmptySpaceItem5.Location = New System.Drawing.Point(257, 367)
        Me.EmptySpaceItem5.Name = "EmptySpaceItem5"
        Me.EmptySpaceItem5.Size = New System.Drawing.Size(48, 26)
        Me.EmptySpaceItem5.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.btnPerforma
        Me.LayoutControlItem6.Location = New System.Drawing.Point(703, 367)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(82, 26)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.btnPBYBaru
        Me.LayoutControlItem7.Location = New System.Drawing.Point(543, 367)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(160, 26)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.btnCetak
        Me.LayoutControlItem8.Location = New System.Drawing.Point(424, 367)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(119, 26)
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'frmPBYList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(805, 413)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "frmPBYList"
        Me.Text = "frmPBYList"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.sTotalSisa.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sTotalLunas.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sTotalValid.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sPengajuan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents sTotalSisa As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents sTotalLunas As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents sTotalValid As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents sPengajuan As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents dgListDetail As meCore.ctrlMeDataGrid
    Friend WithEvents dgList As meCore.ctrlMeDataGrid
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem15 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem16 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem17 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents btnCetak As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnPBYBaru As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnPerforma As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnExport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnLaporan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnValidasi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem5 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
End Class
