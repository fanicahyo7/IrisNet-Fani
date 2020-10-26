<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDetailPelunasan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDetailPelunasan))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.tFaktur = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.dgList = New meCore.ctrlMeDataGrid()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.tPelunasan = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.tPembulatan = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.tTotalPelunasan = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.btnKeluar = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem5 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tFaktur.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tPelunasan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tPembulatan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tTotalPelunasan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.btnKeluar)
        Me.LayoutControl1.Controls.Add(Me.tTotalPelunasan)
        Me.LayoutControl1.Controls.Add(Me.tPembulatan)
        Me.LayoutControl1.Controls.Add(Me.tPelunasan)
        Me.LayoutControl1.Controls.Add(Me.dgList)
        Me.LayoutControl1.Controls.Add(Me.tFaktur)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(769, 331)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.EmptySpaceItem1, Me.EmptySpaceItem2, Me.EmptySpaceItem3, Me.EmptySpaceItem4, Me.EmptySpaceItem5})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(769, 331)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'tFaktur
        '
        Me.tFaktur.Location = New System.Drawing.Point(92, 12)
        Me.tFaktur.Name = "tFaktur"
        Me.tFaktur.Size = New System.Drawing.Size(172, 20)
        Me.tFaktur.StyleController = Me.LayoutControl1
        Me.tFaktur.TabIndex = 4
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.tFaktur
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.MaxSize = New System.Drawing.Size(256, 24)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(256, 24)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(256, 24)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.Text = "Faktur"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(76, 13)
        '
        'dgList
        '
        Me.dgList.colSum = Nothing
        Me.dgList.ConnString = Nothing
        Me.dgList.dSourceUsePK = True
        Me.dgList.FilterPopUpMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
        Me.dgList.Location = New System.Drawing.Point(12, 36)
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
        Me.dgList.Size = New System.Drawing.Size(745, 169)
        Me.dgList.TabIndex = 5
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.dgList
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(749, 173)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'tPelunasan
        '
        Me.tPelunasan.Location = New System.Drawing.Point(647, 209)
        Me.tPelunasan.Name = "tPelunasan"
        Me.tPelunasan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tPelunasan.Size = New System.Drawing.Size(110, 20)
        Me.tPelunasan.StyleController = Me.LayoutControl1
        Me.tPelunasan.TabIndex = 6
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.tPelunasan
        Me.LayoutControlItem3.Location = New System.Drawing.Point(555, 197)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(194, 24)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(194, 24)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(194, 24)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.Text = "Pelunasan"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(76, 13)
        '
        'tPembulatan
        '
        Me.tPembulatan.Location = New System.Drawing.Point(647, 233)
        Me.tPembulatan.Name = "tPembulatan"
        Me.tPembulatan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tPembulatan.Size = New System.Drawing.Size(110, 20)
        Me.tPembulatan.StyleController = Me.LayoutControl1
        Me.tPembulatan.TabIndex = 7
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.tPembulatan
        Me.LayoutControlItem4.Location = New System.Drawing.Point(555, 221)
        Me.LayoutControlItem4.MaxSize = New System.Drawing.Size(194, 24)
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(194, 24)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(194, 24)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem4.Text = "Pembulatan"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(76, 13)
        '
        'tTotalPelunasan
        '
        Me.tTotalPelunasan.Location = New System.Drawing.Point(647, 257)
        Me.tTotalPelunasan.Name = "tTotalPelunasan"
        Me.tTotalPelunasan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tTotalPelunasan.Size = New System.Drawing.Size(110, 20)
        Me.tTotalPelunasan.StyleController = Me.LayoutControl1
        Me.tTotalPelunasan.TabIndex = 8
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.tTotalPelunasan
        Me.LayoutControlItem5.Location = New System.Drawing.Point(555, 245)
        Me.LayoutControlItem5.MaxSize = New System.Drawing.Size(194, 24)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(194, 24)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(194, 24)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.Text = "Total Pelunasan"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(76, 13)
        '
        'btnKeluar
        '
        Me.btnKeluar.Image = CType(resources.GetObject("btnKeluar.Image"), System.Drawing.Image)
        Me.btnKeluar.Location = New System.Drawing.Point(661, 281)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(96, 38)
        Me.btnKeluar.StyleController = Me.LayoutControl1
        Me.btnKeluar.TabIndex = 9
        Me.btnKeluar.Text = "Keluar"
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.btnKeluar
        Me.LayoutControlItem6.Location = New System.Drawing.Point(649, 269)
        Me.LayoutControlItem6.MaxSize = New System.Drawing.Size(100, 42)
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(100, 42)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(100, 42)
        Me.LayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(256, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(493, 24)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 197)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(555, 24)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(0, 221)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(555, 24)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(0, 245)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(555, 24)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem5
        '
        Me.EmptySpaceItem5.AllowHotTrack = False
        Me.EmptySpaceItem5.Location = New System.Drawing.Point(0, 269)
        Me.EmptySpaceItem5.Name = "EmptySpaceItem5"
        Me.EmptySpaceItem5.Size = New System.Drawing.Size(649, 42)
        Me.EmptySpaceItem5.TextSize = New System.Drawing.Size(0, 0)
        '
        'frmDetailPelunasan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(769, 331)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "frmDetailPelunasan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detail Pelunasan"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tFaktur.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tPelunasan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tPembulatan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tTotalPelunasan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents btnKeluar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tTotalPelunasan As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tPembulatan As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tPelunasan As DevExpress.XtraEditors.TextEdit
    Friend WithEvents dgList As meCore.ctrlMeDataGrid
    Friend WithEvents tFaktur As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem5 As DevExpress.XtraLayout.EmptySpaceItem
End Class
