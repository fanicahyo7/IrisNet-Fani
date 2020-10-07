Imports meCore
Imports System.Data.SqlClient
Public Class frmValidReturBeliDetail
    Public judul As String = ""

    Private Sub frmValidReturBeliDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initForm(Me, EnfrmSizeNotMax.efsnm3Big)
        Text = judul
        SetTextReadOnly({tFaktur, tTanggal, tCustomer, tAlamat, tFakturAsli, tTanggalFaktur, tJatuhTempo, _
                         tSurat, tGudang, tJenis, tNoEkspedisi, tDiskFKT, _
                         tKeterangan, tUserEntry, tStatus1, _
                         tSubTotal, tDiscount, tGrandTotal})

        SpinClearButton({tSubTotal, tDiscount, tGrandTotal})
        SpinFormatString({tSubTotal, tDiscount, tGrandTotal}, "n0")

        koneksi()
        Dim query As String = ""
        Select Case judul.ToLower
            Case "validasi retur pembelian"
                query = "select *,b.FakturAsli,a.UserValid as sivalid,isnull(a.Jenis,'RETUR FISIK') as Jenisnya from trPCRHeader a inner join trPCHeader b on b.Faktur = FakturBeli where  a.Faktur='" & Me.Tag & "'"
            Case "validasi pembelian"
                query = "select *,UserValid as sivalid from trPCHeader where Faktur = '" & Me.Tag & "'"
            Case "validasi penerimaan konsinyasi"
                query = "select *,UserValid as sivalid from trKonsHeader where Faktur = '" & Me.Tag & "'"
            Case "validasi retur penerimaan konsinyasi"
                query = "select *,b.FakturAsli,a.UserValid as sivalid from trKonsRHeader a inner join trKonsHeader b on a.FakturKons = b.Faktur where a.Faktur='" & Me.Tag & "'"
            Case "validasi penjualan"
                query = "select *,UserValid as sivalid from trSLHeader where Faktur = '" & Me.Tag & "'"
            Case "validasi retur penjualan"
                query = "select *,UserValid as sivalid from trSLRHeader where Faktur ='" & Me.Tag & "'"
            Case "validasi mutasi gudang"
                query = "select *,UserValid as sivalid from trMTHeader where Faktur ='" & Me.Tag & "'"
            Case "validasi kirim konsinyasi"
                query = "select *,UserValid as sivalid from trSKonsHeader where Faktur ='" & Me.Tag & "'"
            Case "validasi retur kirim konsinyasi"
                query = "select *,UserValid as sivalid from trSKonsRHeader where Faktur ='" & Me.Tag & "'"
            Case Else
                Exit Sub
        End Select

        cmd = New SqlCommand(query, kon)
        rd = cmd.ExecuteReader
        rd.Read()
        tFaktur.Text = rd!Faktur
        tTanggal.Text = rd!Tanggal
        tUserEntry.Text = rd!UserEntry
        If Not judul.ToLower = "validasi mutasi gudang" Then
            tGudang.Text = rd!KdGudang
            tDiskFKT.Text = rd!DiscFaktur
            tKeterangan.Text = rd!Keterangan
            tSubTotal.Text = rd!SubTotal
            tDiscount.Text = rd!Discount
            tGrandTotal.Text = rd!Total
        End If

        Try
            If rd!FlagPajakFaktur = True Then
                lcipajak.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            End If
        Catch ex As Exception

        End Try


        Dim valid As String
        If IsDBNull(rd!sivalid) = True Then
            valid = ""
        Else
            valid = rd!sivalid
        End If

        Dim kode As String = ""

        If judul.ToLower = "validasi retur pembelian" Then
            tFakturAsli.Text = rd!FakturAsli
            tJenis.Text = rd!Jenisnya
            tJatuhTempo.Text = rd!JthTmp
            tNoEkspedisi.Text = rd!NoEkspedisi
            kode = rd!KdSupplier
            rd.Close()
            carisupplier(kode)
        ElseIf judul.ToLower = "validasi pembelian" Then
            tFakturAsli.Text = rd!FakturAsli
            tJenis.Text = rd!Jenis
            tNoEkspedisi.Text = rd!NoEkspedisi
            If IsDBNull(rd!JthTmp) Then
                tJatuhTempo.Text = ""
            Else
                tJatuhTempo.Text = rd!JthTmp
            End If
            If IsDBNull(rd!TglFaktur) Then
                tTanggalFaktur.Text = ""
            Else
                tTanggalFaktur.Text = rd!TglFaktur
            End If
            kode = rd!KdSupplier
            rd.Close()
            carisupplier(kode)
        ElseIf judul.ToLower = "validasi penerimaan konsinyasi" Or judul.ToLower = "validasi retur penerimaan konsinyasi" Then
            tTanggalFaktur.Text = rd!TglFaktur
            tFakturAsli.Text = rd!FakturAsli
            tJatuhTempo.Text = rd!JthTmp
            kode = rd!KdSupplier
            rd.Close()
            carisupplier(kode)
        ElseIf judul.ToLower = "validasi penjualan" Then
            tJenis.Text = rd!Jenis
            tJatuhTempo.Text = rd!JthTmp
            kode = rd!KdCustomer
            rd.Close()
            caricustomer(kode)
        ElseIf judul.ToLower = "validasi retur penjualan" Then
            kode = rd!KdCustomer
            rd.Close()
            caricustomer(kode)
        ElseIf judul.ToLower = "validasi mutasi gudang" Then
            tFakturAsli.Text = rd!FakturAsli
            tJenis.Text = rd!Jenis
            If Not rd!KdSupplier = "" Then
                kode = rd!KdSupplier
                rd.Close()
                carisupplier(kode)
            End If
        ElseIf judul.ToLower = "validasi kirim konsinyasi" Or judul = "validasi retur kirim konsinyasi" Then
            kode = rd!KdCustomer
            rd.Close()
            caricustomer(kode)
        End If
        rd.Close()

        If valid = "" Then
            tStatus1.Text = "NOT VALIDATED"
        Else
            query = "select * from trValidasi where Faktur='" & Me.Tag & "'"
            Dim rrd As SqlDataReader
            cmd = New SqlCommand(query, kon)
            rrd = cmd.ExecuteReader
            rrd.Read()
            tStatus1.Text = "VALIDATED, " & rrd!UserEntry & " " & rrd!DateTimeEntry
            rrd.Close()
        End If

        Select Case judul.ToLower
            Case "validasi retur pembelian"
                query = "select b.Kode,b.KdProduksi,NamaBarang=(select Judul from mstStock where Kode=b.KdBuku),b.Penyusun,b.Jilid,b.NamaPenerbit,b.Qty,b.Harga,b.Disc,b.Jumlah,b.HJual,b.Disc1 from vwPCR b  where Faktur = '" & Me.Tag & "'  Order by urutan"
                CtrlMeDataGrid1.FirstInit(query, {1, 1, 2, 1.5, 0.5, 1, 0.5, 1, 0.5, 1, 1, 1}, , , , , , False)
            Case "validasi pembelian"
                query = "select Kode,KdProduksi,NamaBarang=(select Judul from mstStock where Kode=KdBuku),NamaGolongan,Penyusun,Jilid as JL,NamaPenerbit,Qty,Harga,Disc,Jumlah,HJual,Disc1,Selisih,Gpm from vwPC where Faktur = '" & Me.Tag & "' order by urutan"
                CtrlMeDataGrid1.FirstInit(query, {1, 1, 2, 1.5, 0.5, 1, 0.5, 1, 0.5, 1, 1, 1}, , , , , , False)
            Case "validasi penerimaan konsinyasi"
                query = "select Kode,KdProduksi,NamaBarang=(select Judul from mstStock where Kode=KdBuku),NamaGolongan,Penyusun,Jilid as JL,NamaPenerbit,Qty,Harga,Disc,Jumlah,HJual,Disc1,Selisih,Gpm from vwKons where Faktur = '" & Me.Tag & "' order by urutan"
                CtrlMeDataGrid1.FirstInit(query, {1, 1, 2, 1.5, 0.5, 1, 0.5, 1, 0.5, 1, 1, 1}, , , , , , False)
            Case "validasi retur penerimaan konsinyasi"
                query = "select b.Kode,b.KdProduksi,NamaBarang=(select Judul from mstStock where Kode=b.KdBuku),b.Penyusun,b.Jilid,b.NamaPenerbit,b.Qty,b.Harga,b.Disc,b.Jumlah,b.HJual,b.Disc1 from vwKonsR b  where Faktur = '" & Me.Tag & "'  Order by urutan"
                CtrlMeDataGrid1.FirstInit(query, {1, 1, 2, 1.5, 0.5, 1, 0.5, 1, 0.5, 1, 1, 1}, , , , , , False)
            Case "validasi penjualan"
                query = "select b.Kode,NamaBarang=(select Judul from mstStock where Kode=b.KdBuku),b.Penyusun,b.Jilid,b.NamaPenerbit,b.Qty,b.Harga,b.Disc,b.Jumlah,b.HJual,b.Disc1 from vwSL b  where Faktur = '" & Me.Tag & "'  Order by urutan"
                CtrlMeDataGrid1.FirstInit(query, {1, 2, 1.5, 0.5, 1, 0.5, 1, 0.5, 1, 1, 1}, , , , , , False)
            Case "validasi retur penjualan"
                query = "select b.Kode,NamaBarang=(select Judul from mstStock where Kode=b.KdBuku),b.Penyusun,b.Jilid,b.NamaPenerbit,b.Qty,b.Harga,b.Disc,b.Jumlah,b.HJual,b.Disc1 from vwSLR b  where Faktur = '" & Me.Tag & "'  Order by urutan"
                CtrlMeDataGrid1.FirstInit(query, {1, 2, 1.5, 0.5, 1, 0.5, 1, 0.5, 1, 1, 1}, , , , , , False)
            Case "validasi mutasi gudang"
                query = "select a.Kode,kdprod=(select KdProduksi from mstStock where Kode1=b.KdBuku),a.Judul,a.Penyusun,a.Jilid,a.NamaPenerbit,a.QTY from vwMT a inner join mstStkSup b on a.Kode = b.Kode where Faktur ='" & Me.Tag & "'  Order by a.urutan"
                CtrlMeDataGrid1.FirstInit(query, {1, 1, 2, 1.5, 0.5, 1, 0.5}, , , , , , False)
            Case "validasi kirim konsinyasi"
                query = "select Kode,kdprod=(select KdProduksi from mstStock where Kode=KdBuku),Judul,Penyusun,Jilid,NamaPenerbit,Qty,Harga,Disc,HJual,Jumlah,Disc1 from vwSKons  where Faktur = '" & Me.Tag & "'  Order by urutan"
                CtrlMeDataGrid1.FirstInit(query, {1, 1, 2, 1.5, 0.5, 1, 0.5, 1, 1, 1, 1, 1}, , , , , , False)
            Case "validasi retur kirim konsinyasi"
                query = "select Kode,kdprod=(select KdProduksi from mstStock where Kode=KdBuku),Judul,Penyusun,Jilid,NamaPenerbit,Qty,Harga,Disc,HJual,Jumlah,Disc1 from vwSKonsR  where Faktur = '" & Me.Tag & "'  Order by urutan"
                CtrlMeDataGrid1.FirstInit(query, {1, 1, 2, 1.5, 0.5, 1, 0.5, 1, 1, 1, 1, 1}, , , , , , False)
        End Select
        CtrlMeDataGrid1.RefreshData()
    End Sub
    Sub carisupplier(ByVal kdsupplier As String)
        Dim query As String = "select Nama,Alamat from mstSupplier where Kode='" & kdsupplier & "'"
        Dim dddr As SqlDataReader
        cmd = New SqlCommand(query, kon)
        dddr = cmd.ExecuteReader
        dddr.Read()
        tCustomer.Text = dddr!Nama
        tAlamat.Text = dddr!Alamat
        dddr.Close()
    End Sub
    Sub caricustomer(ByVal kdcst As String)
        Dim query As String = "select Nama,Alamat from mstCustomer where Kode='" & kdcst & "'"
        Dim dddr As SqlDataReader
        cmd = New SqlCommand(query, kon)
        dddr = cmd.ExecuteReader
        dddr.Read()
        tCustomer.Text = dddr!Nama
        tAlamat.Text = dddr!Alamat
        dddr.Close()
    End Sub
End Class