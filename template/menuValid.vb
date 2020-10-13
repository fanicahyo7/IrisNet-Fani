Imports meCore
Imports System.Data.SqlClient
Public Class menuValid

    Private Sub ReturPembelianToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturPembelianToolStripMenuItem.Click
        Using xx As New frmValidReturBeli
            xx.Text = "Validasi Retur Pembelian"
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub menuValid_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Using dbx As New cMeDB
            Try
                dbx.FillMe("select keterangan from stdefault where kode = 30")
                If dbx IsNot Nothing Then
                    If dbx.Rows.Count > 0 Then
                        pubKodeUnit = dbx.Rows(0)!keterangan
                    End If
                End If
            Catch ex As Exception

            End Try
        End Using

        'create a new TreeView
        'Dim TreeView1 As TreeView
        'TreeView1 = New TreeView()
        'TreeView1.Location = New Point(25, 25)
        'TreeView1.Size = New Size(150, 150)

        'Me.Controls.Add(TreeView1)
        'TreeView1.Nodes.Clear()
        ''Creating the root node
        'Dim root = New TreeNode("Application")
        'TreeView1.Nodes.Add(root)
        'TreeView1.Nodes(0).Nodes.Add(New TreeNode("Project 1"))

        ''Creating child nodes under the first child

        'For loopindex As Integer = 1 To 4
        '    TreeView1.Nodes(0).Nodes(0).Nodes.Add(New  _
        '       TreeNode("Sub Project" & Str(loopindex)))
        'Next loopindex
        '' creating child nodes under the root
        'TreeView1.Nodes(0).Nodes.Add(New TreeNode("Project 6"))
        ''creating child nodes under the created child node

        'For loopindex As Integer = 1 To 3
        '    TreeView1.Nodes(0).Nodes(1).Nodes.Add(New  _
        '       TreeNode("Project File" & Str(loopindex)))
        'Next loopindex

        'root.ExpandAll()

        koneksi()
        menuheader()
        menuchild()
        TreeView1.ExpandAll()
    End Sub

    Sub menuheader()
        cmd = New SqlCommand("select distinct Master from stMeUserMenu where UserID='ANIK' AND TabX='TRANSAKSI'", kon)
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "Menu")
        Dim i As Integer

        TreeView1.Nodes.Clear()
        TreeView1.BeginUpdate()
        For i = 0 To ds.Tables(0).Rows.Count - 1
            Dim node As New TreeNode
            Dim str As String = ds.Tables(0).Rows(i)("Master").ToString
            node = TreeView1.Nodes.Add(str)
            node.Tag = ds.Tables(0).Rows(i)("Master").ToString()
            node.ImageIndex = 1
            node.SelectedImageIndex = 1
            node.Name = ds.Tables(0).Rows(i)("Master")
            node.Text = str
        Next
        TreeView1.EndUpdate()
    End Sub

    Sub menuchild()
        Dim idx As Integer
        Dim rw As Integer

        For idx = 0 To TreeView1.Nodes.Count - 1
            cmd = New SqlCommand("select * from stMeUserMenu where UserID='ANIK' AND TabX='TRANSAKSI' AND Master= '" & TreeView1.Nodes(idx).Tag & "'", kon)
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            da.Fill(ds, "Menu")
            For rw = 0 To ds.Tables(0).Rows.Count - 1
                Dim node As New TreeNode
                Dim str As String = ds.Tables(0).Rows(rw)("Detail").ToString
                node = TreeView1.Nodes(idx).Nodes.Add(str)
                node.Tag = ds.Tables(0).Rows(rw)("Detail").ToString()
                node.Name = ds.Tables(0).Rows(rw)("Detail")
                node.Text = str
            Next
        Next
    End Sub

    Private Sub PembelianToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PembelianToolStripMenuItem.Click
        Using xx As New frmValidReturBeli
            xx.Text = "Validasi Pembelian"
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub ReturToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturToolStripMenuItem.Click
        Using xx As New frmValidReturBeli
            xx.Text = "Validasi Penerimaan Konsinyasi"
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub ReturPenerimaanKonsinyasiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturPenerimaanKonsinyasiToolStripMenuItem.Click
        Using xx As New frmValidReturBeli
            xx.Text = "Validasi Retur Penerimaan Konsinyasi"
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub PenjualanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PenjualanToolStripMenuItem.Click
        Using xx As New frmValidReturBeli
            xx.Text = "Validasi Penjualan"
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub ReturPenjualanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturPenjualanToolStripMenuItem.Click
        Using xx As New frmValidReturBeli
            xx.Text = "Validasi Retur Penjualan"
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub MutasiGudangToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MutasiGudangToolStripMenuItem.Click
        Using xx As New frmValidReturBeli
            xx.Text = "Validasi Mutasi Gudang"
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub KirimKonsinyasiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KirimKonsinyasiToolStripMenuItem.Click
        Using xx As New frmValidReturBeli
            xx.Text = "Validasi Kirim Konsinyasi"
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub ReturKirimKonsiyasiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturKirimKonsiyasiToolStripMenuItem.Click
        Using xx As New frmValidReturBeli
            xx.Text = "Validasi Retur Kirim Konsinyasi"
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub EventPameranToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EventPameranToolStripMenuItem.Click
        Using xx As New frmValidReturBeli
            xx.Text = "Validasi Event Pameran"
            xx.ShowDialog(Me)
        End Using
    End Sub
    Private Sub KirimEkspedisiToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles KirimEkspedisiToolStripMenuItem2.Click
        Using xx As New frmValidReturBeli
            xx.Text = "Validasi Kirim Ekspedisi"
            xx.ShowDialog(Me)
        End Using
    End Sub
    Private Sub KirimEkspedisiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KirimEkspedisiToolStripMenuItem.Click
        Using xx As New frmValidReturBeli
            xx.Text = "Validasi Terima Ekspedisi"
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub PenjualanToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PenjualanToolStripMenuItem1.Click
        Using xx As New frmRptUmurStok
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub MutasiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MutasiToolStripMenuItem.Click
        Using xx As New frmRptUmurStokSupGol
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub AsdsdfdgToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsdsdfdgToolStripMenuItem.Click
        Using xx As New frmRptGolSupTerlaris
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub UmurStokSupGolToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TeamOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TeamOrderToolStripMenuItem.Click
        Using xx As New frmMstTeamOrder
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub PembelianToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PembelianToolStripMenuItem1.Click
        Using xx As New frmReturPembelianUtm
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub KonsinyasiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KonsinyasiToolStripMenuItem.Click
        Using xx As New frmReturKonsUtm
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub SettingBukuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingBukuToolStripMenuItem.Click
        Using xx As New frmSettingBuku
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub SettingATKToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingATKToolStripMenuItem.Click
        Using xx As New frmSettingATK
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub GudangToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GudangToolStripMenuItem.Click
        Using xx As New frmMstGudang
            xx.Text = "Master Gudang"
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub WilayahToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WilayahToolStripMenuItem.Click
        Using xx As New frmMstGudang
            xx.Text = "Master Wilayah"
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub RakToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RakToolStripMenuItem.Click
        Using xx As New frmMstGudang
            xx.Text = "Master Rak"
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub TypeCustomerSupplierToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TypeCustomerSupplierToolStripMenuItem.Click
        Using xx As New frmMstGudang
            xx.Text = "Master Type Customer Supplier"
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub GolonganToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GolonganToolStripMenuItem.Click
        Using xx As New frmMstGudang
            xx.Text = "Master Golongan"
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub CardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CardToolStripMenuItem.Click
        Using xx As New frmMstGudang
            xx.Text = "Master Card"
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub DaftarNomorNotaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DaftarNomorNotaToolStripMenuItem.Click
        Using xx As New frmMstGudang
            xx.Text = "Daftar Nomor Nota"
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub EkspedisiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EkspedisiToolStripMenuItem.Click
        Using xx As New frmMstEkspedisiList
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub StockNonProfitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockNonProfitToolStripMenuItem.Click
        Using xx As New frmMstGudang
            xx.Text = "Master Stock Non Profit"
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub SalesmanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesmanToolStripMenuItem.Click
        Using xx As New frmMstSalesmanList
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub OutletToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OutletToolStripMenuItem.Click
        Using xx As New frmMstOutletList
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub PenerbitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PenerbitToolStripMenuItem.Click
        Using xx As New frmMstPenerbitList
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub SToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub MarginToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MarginToolStripMenuItem.Click
        Using xx As New frmMstMarginList
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub PembelianToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles PembelianToolStripMenuItem2.Click
        Using xx As New frmPenjualanBO
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub MutasiToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MutasiToolStripMenuItem1.Click
        Using xx As New frmMutasi
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub KirimEkspedisiToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles KirimEkspedisiToolStripMenuItem1.Click
        Using xx As New frmtrKirimEkspedisiList
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub PengunjungToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PengunjungToolStripMenuItem.Click
        Using xx As New frmPengunjungList
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub UserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserToolStripMenuItem.Click
        Using xx As New frmPengunjungValidList
            xx.ShowDialog(Me)
        End Using
    End Sub

    
    Private Sub BankToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BankToolStripMenuItem.Click
        Using xx As New frmMstBank
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub TerimaEkspedisiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TerimaEkspedisiToolStripMenuItem.Click
        Using xx As New frmTerimaEkspedisiList
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub VoucherToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VoucherToolStripMenuItem.Click
        Using xx As New frmMstVoucherList
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Using xx As New Form1
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub VoucherBuatEventToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VoucherBuatEventToolStripMenuItem.Click
        Using xx As New frmMstVoucherBuatEvent
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub BlokirNomorNotaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BlokirNomorNotaToolStripMenuItem.Click
        Using xx As New frmBlokirNomorNota
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub TreeView1_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        'Select Case e.Node.Text
        '    Case "Project File 2"
        '        Form11.Show()
        'End Select
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect

    End Sub

    Private Sub BarangMasukKeluarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BarangMasukKeluarToolStripMenuItem.Click
        Using xx As New frmRptBarangKeluarMasuk
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub PiutangCustomerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PiutangCustomerToolStripMenuItem.Click
        Using xx As New frmLapKartuPiutangCustomer
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub KirimEkspedisiPBYToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KirimEkspedisiPBYToolStripMenuItem.Click
        Using xx As New frmValidKEPBY
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub BukuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BukuToolStripMenuItem.Click
        Using xx As New frmMstBuku
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub ATKToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ATKToolStripMenuItem.Click
        Using xx As New frmMstATK
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub ForeCastHutangToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ForeCastHutangToolStripMenuItem.Click
        Using xx As New frmLapForecastHutang
            xx.ShowDialog(Me)
        End Using
    End Sub
End Class