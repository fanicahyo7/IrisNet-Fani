<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTotalWithdrawal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTotalWithdrawal))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.btnContohExcel = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.sTotalTunai = New DevExpress.XtraEditors.SpinEdit()
        Me.sTotalByPromosi = New DevExpress.XtraEditors.SpinEdit()
        Me.tNoBukti = New DevExpress.XtraEditors.TextEdit()
        Me.tLokasi = New DevExpress.XtraEditors.TextEdit()
        Me.btnPelunasan = New DevExpress.XtraEditors.SimpleButton()
        Me.btnImport = New DevExpress.XtraEditors.SimpleButton()
        Me.dgList = New meCore.ctrlMeDataGrid()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.sTotalByKomisi = New DevExpress.XtraEditors.SpinEdit()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.sTotalPiutangOngkir = New DevExpress.XtraEditors.SpinEdit()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.sTotalByKerugian = New DevExpress.XtraEditors.SpinEdit()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.sTotal = New DevExpress.XtraEditors.SpinEdit()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.sCashback = New DevExpress.XtraEditors.SpinEdit()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.sTotalTunai.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sTotalByPromosi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tNoBukti.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tLokasi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sTotalByKomisi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sTotalPiutangOngkir.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sTotalByKerugian.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sTotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sCashback.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.sCashback)
        Me.LayoutControl1.Controls.Add(Me.sTotal)
        Me.LayoutControl1.Controls.Add(Me.sTotalByKerugian)
        Me.LayoutControl1.Controls.Add(Me.sTotalPiutangOngkir)
        Me.LayoutControl1.Controls.Add(Me.sTotalByKomisi)
        Me.LayoutControl1.Controls.Add(Me.btnContohExcel)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl1.Controls.Add(Me.sTotalTunai)
        Me.LayoutControl1.Controls.Add(Me.sTotalByPromosi)
        Me.LayoutControl1.Controls.Add(Me.tNoBukti)
        Me.LayoutControl1.Controls.Add(Me.tLokasi)
        Me.LayoutControl1.Controls.Add(Me.btnPelunasan)
        Me.LayoutControl1.Controls.Add(Me.btnImport)
        Me.LayoutControl1.Controls.Add(Me.dgList)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(650, 120, 450, 400)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(716, 368)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'btnContohExcel
        '
        Me.btnContohExcel.Image = CType(resources.GetObject("btnContohExcel.Image"), System.Drawing.Image)
        Me.btnContohExcel.Location = New System.Drawing.Point(12, 318)
        Me.btnContohExcel.Name = "btnContohExcel"
        Me.btnContohExcel.Size = New System.Drawing.Size(144, 38)
        Me.btnContohExcel.StyleController = Me.LayoutControl1
        Me.btnContohExcel.TabIndex = 14
        Me.btnContohExcel.Text = "Contoh Format Excel"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(450, 12)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(77, 22)
        Me.SimpleButton1.StyleController = Me.LayoutControl1
        Me.SimpleButton1.TabIndex = 13
        Me.SimpleButton1.Text = "SimpleButton1"
        '
        'sTotalTunai
        '
        Me.sTotalTunai.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.sTotalTunai.Location = New System.Drawing.Point(91, 294)
        Me.sTotalTunai.Name = "sTotalTunai"
        Me.sTotalTunai.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.sTotalTunai.Size = New System.Drawing.Size(174, 20)
        Me.sTotalTunai.StyleController = Me.LayoutControl1
        Me.sTotalTunai.TabIndex = 12
        '
        'sTotalByPromosi
        '
        Me.sTotalByPromosi.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.sTotalByPromosi.Location = New System.Drawing.Point(91, 198)
        Me.sTotalByPromosi.Name = "sTotalByPromosi"
        Me.sTotalByPromosi.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.sTotalByPromosi.Size = New System.Drawing.Size(174, 20)
        Me.sTotalByPromosi.StyleController = Me.LayoutControl1
        Me.sTotalByPromosi.TabIndex = 10
        '
        'tNoBukti
        '
        Me.tNoBukti.Location = New System.Drawing.Point(91, 126)
        Me.tNoBukti.Name = "tNoBukti"
        Me.tNoBukti.Size = New System.Drawing.Size(174, 20)
        Me.tNoBukti.StyleController = Me.LayoutControl1
        Me.tNoBukti.TabIndex = 9
        '
        'tLokasi
        '
        Me.tLokasi.Location = New System.Drawing.Point(91, 12)
        Me.tLokasi.Name = "tLokasi"
        Me.tLokasi.Size = New System.Drawing.Size(233, 20)
        Me.tLokasi.StyleController = Me.LayoutControl1
        Me.tLokasi.TabIndex = 8
        '
        'btnPelunasan
        '
        Me.btnPelunasan.Image = CType(resources.GetObject("btnPelunasan.Image"), System.Drawing.Image)
        Me.btnPelunasan.Location = New System.Drawing.Point(562, 318)
        Me.btnPelunasan.Name = "btnPelunasan"
        Me.btnPelunasan.Size = New System.Drawing.Size(142, 38)
        Me.btnPelunasan.StyleController = Me.LayoutControl1
        Me.btnPelunasan.TabIndex = 7
        Me.btnPelunasan.Text = "Pelunasan"
        '
        'btnImport
        '
        Me.btnImport.Image = CType(resources.GetObject("btnImport.Image"), System.Drawing.Image)
        Me.btnImport.Location = New System.Drawing.Point(328, 12)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(118, 38)
        Me.btnImport.StyleController = Me.LayoutControl1
        Me.btnImport.TabIndex = 6
        Me.btnImport.Text = "Import Excel"
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
        Me.dgList.Size = New System.Drawing.Size(692, 68)
        Me.dgList.TabIndex = 4
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem3, Me.EmptySpaceItem1, Me.LayoutControlItem4, Me.EmptySpaceItem2, Me.LayoutControlItem2, Me.LayoutControlItem5, Me.EmptySpaceItem3, Me.LayoutControlItem6, Me.LayoutControlItem8, Me.LayoutControlItem9, Me.LayoutControlItem10, Me.LayoutControlItem7, Me.LayoutControlItem11, Me.LayoutControlItem12, Me.LayoutControlItem13, Me.LayoutControlItem14})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(716, 368)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.dgList
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 42)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(696, 72)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.btnImport
        Me.LayoutControlItem3.Location = New System.Drawing.Point(316, 0)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(122, 42)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(122, 42)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(122, 42)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(519, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(177, 42)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.btnPelunasan
        Me.LayoutControlItem4.Location = New System.Drawing.Point(550, 306)
        Me.LayoutControlItem4.MaxSize = New System.Drawing.Size(146, 42)
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(146, 42)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(146, 42)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(148, 306)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(402, 42)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.tLokasi
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(316, 42)
        Me.LayoutControlItem2.Text = "Lokasi"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(76, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.tNoBukti
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 114)
        Me.LayoutControlItem5.MaxSize = New System.Drawing.Size(257, 24)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(257, 24)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(257, 24)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.Text = "No. Bukti"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(76, 13)
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(257, 114)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(439, 192)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.sTotalByPromosi
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 186)
        Me.LayoutControlItem6.MaxSize = New System.Drawing.Size(257, 24)
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(257, 24)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(257, 24)
        Me.LayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem6.Text = "Total Promosi"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(76, 13)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.sTotalTunai
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 282)
        Me.LayoutControlItem8.MaxSize = New System.Drawing.Size(257, 24)
        Me.LayoutControlItem8.MinSize = New System.Drawing.Size(257, 24)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(257, 24)
        Me.LayoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem8.Text = "Total Pelunasan"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(76, 13)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.SimpleButton1
        Me.LayoutControlItem9.Location = New System.Drawing.Point(438, 0)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(81, 42)
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.btnContohExcel
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 306)
        Me.LayoutControlItem10.MaxSize = New System.Drawing.Size(148, 42)
        Me.LayoutControlItem10.MinSize = New System.Drawing.Size(148, 42)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(148, 42)
        Me.LayoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem10.TextVisible = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'sTotalByKomisi
        '
        Me.sTotalByKomisi.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.sTotalByKomisi.Location = New System.Drawing.Point(91, 222)
        Me.sTotalByKomisi.Name = "sTotalByKomisi"
        Me.sTotalByKomisi.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.sTotalByKomisi.Size = New System.Drawing.Size(174, 20)
        Me.sTotalByKomisi.StyleController = Me.LayoutControl1
        Me.sTotalByKomisi.TabIndex = 15
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.sTotalByKomisi
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 210)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(257, 24)
        Me.LayoutControlItem7.Text = "Total Komisi"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(76, 13)
        '
        'sTotalPiutangOngkir
        '
        Me.sTotalPiutangOngkir.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.sTotalPiutangOngkir.Location = New System.Drawing.Point(91, 246)
        Me.sTotalPiutangOngkir.Name = "sTotalPiutangOngkir"
        Me.sTotalPiutangOngkir.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.sTotalPiutangOngkir.Size = New System.Drawing.Size(174, 20)
        Me.sTotalPiutangOngkir.StyleController = Me.LayoutControl1
        Me.sTotalPiutangOngkir.TabIndex = 16
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.sTotalPiutangOngkir
        Me.LayoutControlItem11.Location = New System.Drawing.Point(0, 234)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(257, 24)
        Me.LayoutControlItem11.Text = "Piutang Ongkir"
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(76, 13)
        '
        'sTotalByKerugian
        '
        Me.sTotalByKerugian.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.sTotalByKerugian.Location = New System.Drawing.Point(91, 270)
        Me.sTotalByKerugian.Name = "sTotalByKerugian"
        Me.sTotalByKerugian.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.sTotalByKerugian.Size = New System.Drawing.Size(174, 20)
        Me.sTotalByKerugian.StyleController = Me.LayoutControl1
        Me.sTotalByKerugian.TabIndex = 17
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.sTotalByKerugian
        Me.LayoutControlItem12.Location = New System.Drawing.Point(0, 258)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(257, 24)
        Me.LayoutControlItem12.Text = "Total Kerugian"
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(76, 13)
        '
        'sTotal
        '
        Me.sTotal.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.sTotal.Location = New System.Drawing.Point(91, 150)
        Me.sTotal.Name = "sTotal"
        Me.sTotal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.sTotal.Size = New System.Drawing.Size(174, 20)
        Me.sTotal.StyleController = Me.LayoutControl1
        Me.sTotal.TabIndex = 18
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.sTotal
        Me.LayoutControlItem13.Location = New System.Drawing.Point(0, 138)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(257, 24)
        Me.LayoutControlItem13.Text = "Total"
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(76, 13)
        '
        'sCashback
        '
        Me.sCashback.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.sCashback.Location = New System.Drawing.Point(91, 174)
        Me.sCashback.Name = "sCashback"
        Me.sCashback.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.sCashback.Size = New System.Drawing.Size(174, 20)
        Me.sCashback.StyleController = Me.LayoutControl1
        Me.sCashback.TabIndex = 19
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.sCashback
        Me.LayoutControlItem14.Location = New System.Drawing.Point(0, 162)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(257, 24)
        Me.LayoutControlItem14.Text = "Cashback"
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(76, 13)
        '
        'frmTotalWithdrawal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(716, 368)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "frmTotalWithdrawal"
        Me.Text = "frmTotalWithdrawal"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.sTotalTunai.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sTotalByPromosi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tNoBukti.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tLokasi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sTotalByKomisi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sTotalPiutangOngkir.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sTotalByKerugian.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sTotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sCashback.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents btnImport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents dgList As meCore.ctrlMeDataGrid
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnPelunasan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents tLokasi As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents tNoBukti As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents sTotalTunai As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents sTotalByPromosi As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnContohExcel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents sTotalByKerugian As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents sTotalPiutangOngkir As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents sTotalByKomisi As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents sCashback As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents sTotal As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
End Class
