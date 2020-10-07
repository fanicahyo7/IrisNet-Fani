Imports System.Data.Sql
Imports System.Data.SqlClient
Imports meCore
Public Class frmReturPembelian

    Public jns As String = ""
    Dim isNew As Boolean = True
    Dim pKode As String = "asdjaksdjqi01298310owueqiowueakdh"

    Sub fakturoto()
        Dim tabel As String = ""
        Dim initfak As String = ""
        If Not cJenis.Text = "RETUR PENERIMAAN BARANG KONSINYASI" Then
            tabel = "trPCRHeader"
            initfak = "-RB"
        Else
            tabel = "trKonsRHeader"
            initfak = "-RT"
        End If
        'tFaktur.Text = GetNewFakturSQLServ(PubConnStr, tabel, "Faktur", pubKodeUnit & pubUserInit & initfak, Date.Now.ToString("yyMMdd"), 5, "")
        tFaktur.Text = GetNewFakturTogamasSQLServ(PubConnStr, tabel, FakturReset.Tahunan, "Faktur", pubKodeUnit & pubUserInit & initfak, DTOC(Now), 5, "")

    End Sub

    Sub selsup()
        cKdSupplier.Text = ""
        Dim query As String
        If Not cJenis.Text = "RETUR PENERIMAAN BARANG KONSINYASI" Then
            query = "Select Kode, Nama, Alamat, case when Konsinyasi=1 then 'KONSI' else 'NON-KONSI' END as Kons from mstSupplier where Konsinyasi='0'"
        Else
            query = "Select Kode, Nama, Alamat, case when Konsinyasi=1 then 'KONSI' else 'NON-KONSI' END as Kons from mstSupplier where Konsinyasi='1'"
        End If

        cKdSupplier.FirstInit(PubConnStr, query, {tNama, tAlamat, tKonsi}, , , , , False, {0.6, 1.5, 2, 0.8})
    End Sub

    Private Sub frmReturPembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initForm(Me, EnfrmSizeNotMax.efsnm0Default, DevExpress.XtraLayout.MoveFocusDirection.DownThenAcross)
        LayoutControlItem21.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        koneksi()


        If Me.Tag <> "" Then pKode = Me.Tag
        'If jns = "RETUR PENERIMAAN BARANG KONSINYASI" Then
        '    cJenis.SelectedIndex = 5
        'End If

        cJenis.Properties.Items.Clear()
        If Text.ToUpper.Contains("RETUR KONSINYASI") = False Then
            cJenis.Properties.Items.AddRange({"RETUR FISIK", "RETUR ADMIN GANTI JUDUL", "RETUR ADMIN GANTI QTY", "RETUR ADMIN GANTI SUPPLIER", "RETUR ADMIN ECER"})
        Else
            cJenis.Properties.Items.Add("RETUR PENERIMAAN BARANG KONSINYASI")
        End If
        cJenis.SelectedIndex = 0

        Dim query As String = _
                "Select Kode,Nama,Alamat from mstSupplier where Konsinyasi='0'"
        cKdSupplierBaru.FirstInit(PubConnStr, query, {tNamaSupplier})
        LoadDetail()
        refreshtot()
    End Sub

    Sub LoadDetail()
        Dim db As New cMeDB
        Dim pQuery As String
        If Not cJenis.Text = "RETUR PENERIMAAN BARANG KONSINYASI" Then
            pQuery = "Select Faktur,isnull(Jenis,'RETUR FISIK') as Jenis,Tanggal,KdSupplier,FakturBeli,KdGudang,DiscFaktur,Keterangan,PersPPn,SubTotal,Discount,PPn,Total,UserEntry,DateTimeEntry,UserValid,DateTimeValid,NoValidated from trPCRHeader where Faktur = '" & pKode & "'"
        Else
            pQuery = "Select Faktur,Tanggal,KdSupplier,FakturKons,KdGudang,DiscFaktur,Keterangan,PersPPn,SubTotal,Discount,PPn,Total,UserEntry,DateTimeEntry,UserValid,DateTimeValid,NoValidated from trKonsRHeader where Faktur = '" & pKode & "'"
        End If
        db.FillMe(pQuery, True)

        If db.Rows.Count > 0 Then
            isNew = False

            FillFormFromDataRow(Me, db.Rows(0))

            If Not cJenis.Text = "RETUR PENERIMAAN BARANG KONSINYASI" Then
                cFakturBeli.Text = db.Rows(0)!FakturBeli
            Else
                cFakturBeli.Text = db.Rows(0)!FakturKons
            End If
            cFakturBeli_EditValueChanged(Nothing, Nothing)
            SetTextReadOnly({tKdGudang, tTanggal, sSubTotal, tDiscFaktur, sDiscount, sTotal, sPPn, sPersPPn, tFaktur, _
                             cKdSupplier, cFakturBeli, tFakturAsli, tKeterangan, cJenis})
            btnSimpan.Enabled = False
        Else
            btnSimpan.Enabled = True
            btnbaru.PerformClick()
            selsup()
            fakturoto()
            cmd = New SqlCommand("select Keterangan from stDefault where Kode='26'", kon)
            rd = cmd.ExecuteReader
            rd.Read()
            tKdGudang.Text = rd.Item(0)
            rd.Close()
            Dim tgl As Date = Format(Now, "dd/MM/yyyy")
            tTanggal.Text = tgl

            mdgKodeBaru.Enabled = False

            SetTextReadOnly({tKdGudang, tTanggal, sSubTotal, tDiscFaktur, sDiscount, sTotal, sPPn, sPersPPn, tFaktur, _
                             tFakturAsli})
            cJenis.SelectedIndex = 0
        End If

        'tampilkan barang yg sudah tersimpan
        If Not cJenis.Text = "RETUR PENERIMAAN BARANG KONSINYASI" Then
            If isNew = False Then
                Dim aa As String = "select * from trPCHeader where Faktur='" & cFakturBeli.Text & "'"
                cmd = New SqlCommand(aa, kon)
                rd = cmd.ExecuteReader
                rd.Read()
                tFakturAsli.Text = rd!FakturAsli
                rd.Close()

                Dim qq As String = "select * from trPCRAdminGen where Faktur='" & tFaktur.Text & "'"
                cmd = New SqlCommand(qq, kon)
                dt = New DataTable
                dt.Load(cmd.ExecuteReader())
                DataGridView1.DataSource = dt

                For c = 0 To DataGridView1.RowCount - 2
                    For a = 0 To mdgList.DataSource.Rows.Count - 1
                        Dim dd As DataGridViewRow = DataGridView1.Rows(c)

                        If IsDBNull(dd.Cells("KodeLama").Value) Then
                            Dim qw As String = _
                            "select * from trPCRDetail where Faktur='" & tFaktur.Text & "' and Kode='" & dd.Cells("Kode").Value & "'"
                            cmd = New SqlCommand(qw, kon)
                            rd = cmd.ExecuteReader
                            rd.Read()
                            If rd.HasRows Then
                                dd.Cells("KodeLama").Value = rd!Kode
                            End If
                            rd.Close()
                        End If

                        If dd.Cells("KodeLama").Value = mdgList.GetRowCellValue(a, "Kode") Then
                            cmd = New SqlCommand("select * from vwStkSup where KdSupplier='" & cKdSupplier.Text & "' and Kode='" & DataGridView1.Item(3, c).Value & "'", kon)
                            rd = cmd.ExecuteReader
                            rd.Read()

                            Dim sld As String = ""
                            Dim Disc As String = ""
                            Dim harga As String = ""

                            Select Case cJenis.Text
                                Case "RETUR FISIK"
                                    mdgList.SetRowCellValue(a, "QtyRetur", dd.Cells("Qty").Value)
                                    sld = "QtyRetur"
                                    Disc = "Disc"
                                    harga = "Harga"
                                Case "RETUR ADMIN GANTI QTY"
                                    mdgList.SetRowCellValue(a, "QtyRetur", dd.Cells("Qty").Value)
                                    mdgList.SetRowCellValue(a, "HargaBaru", dd.Cells("Harga").Value)
                                    mdgList.SetRowCellValue(a, "DiscBaru", dd.Cells("Disc").Value)
                                    sld = "QtyRetur"
                                    Disc = "DiscBaru"
                                    harga = "HargaBaru"
                                Case "RETUR ADMIN GANTI JUDUL"
                                    mdgList.SetRowCellValue(a, "KodeBaru", dd.Cells("Kode").Value)
                                    If rd.HasRows Then
                                        mdgList.SetRowCellValue(a, "JudulBaru", rd!Judul)
                                    End If
                                    sld = "QtyFKT"
                                    Disc = "Disc"
                                    harga = "Harga"
                                Case "RETUR ADMIN GANTI SUPPLIER"
                                    SetTextReadOnly({cKdSupplierBaru})
                                    lciKodeBaru.Enabled = False
                                    cKdSupplierBaru.Text = dd.Cells("KdSupplier").Value
                                    mdgList.SetRowCellValue(a, "KodeBaru", dd.Cells("Kode").Value)
                                    sld = "QtyFKT"
                                    Disc = "Disc"
                                    harga = "Harga"
                                Case "RETUR ADMIN ECER"
                                    mdgList.SetRowCellValue(a, "KodeBaru", dd.Cells("Kode").Value)
                                    If rd.HasRows Then
                                        mdgList.SetRowCellValue(a, "JudulBaru", rd!Judul)
                                    End If
                                    mdgList.SetRowCellValue(a, "QtyBaru", dd.Cells("Qty").Value)
                                    mdgList.SetRowCellValue(a, "HargaBaru", dd.Cells("Harga").Value)
                                    mdgList.SetRowCellValue(a, "DiscBaru", dd.Cells("Disc").Value)
                                    sld = "QtyBaru"
                                    Disc = "DiscBaru"
                                    harga = "HargaBaru"
                                    rd.Close()

                                    cmd = New SqlCommand("select * from trPCRDetail where Faktur='" & tFaktur.Text & "'", kon)
                                    rd = cmd.ExecuteReader
                                    rd.Read()
                                    If rd.HasRows Then
                                        mdgList.SetRowCellValue(a, "QtyRetur", rd!Qty)
                                    End If
                            End Select
                            rd.Close()
                            Dim total, diskon As Double
                            total = CDbl(mdgList.GetRowCellValue(a, "" & sld & "")) * CDbl(mdgList.GetRowCellValue(a, "" & harga & ""))
                            diskon = total * (CDbl(mdgList.GetRowCellValue(a, "" & Disc & "")) / 100)
                            mdgList.SetRowCellValue(a, "JumlahRetur", total - diskon)
                        End If
                    Next
                Next
            End If

        Else
            If isNew = False Then
                Dim aa As String = "select * from trKonsHeader where Faktur='" & cFakturBeli.Text & "'"
                cmd = New SqlCommand(aa, kon)
                rd = cmd.ExecuteReader
                rd.Read()
                tFakturAsli.Text = rd!FakturAsli
                rd.Close()

                Dim qq As String = "select * from trKonsRDetail where Faktur='" & tFaktur.Text & "'"
                cmd = New SqlCommand(qq, kon)
                dt = New DataTable
                dt.Load(cmd.ExecuteReader())
                DataGridView1.DataSource = dt

                For c = 0 To DataGridView1.RowCount - 2
                    For a = 0 To mdgList.DataSource.Rows.Count - 1
                        Dim dd As DataGridViewRow = DataGridView1.Rows(c)

                        If dd.Cells("Kode").Value = mdgList.GetRowCellValue(a, "Kode") Then
                            Dim sld, Disc, harga As String
                            mdgList.SetRowCellValue(a, "QtyRetur", dd.Cells("Qty").Value)
                            sld = "QtyRetur"
                            Disc = "Disc"
                            harga = "Harga"

                            rd.Close()
                            Dim total, diskon As Double
                            total = CDbl(mdgList.GetRowCellValue(a, "" & sld & "")) * CDbl(mdgList.GetRowCellValue(a, "" & harga & ""))
                            diskon = total * (CDbl(mdgList.GetRowCellValue(a, "" & Disc & "")) / 100)
                            mdgList.SetRowCellValue(a, "JumlahRetur", total - diskon)
                        End If
                    Next
                Next
            End If
        End If
        mdgList.RefreshDataView()
    End Sub

    Private Sub cKdSupplier_EditValueChanged(sender As Object, e As EventArgs) Handles cKdSupplier.EditValueChanged
        'If isFirstInit = True Then Exit Sub

        If Not cKdSupplier.Text = "" Then
            Dim query As String
            If Not cJenis.Text = "RETUR PENERIMAAN BARANG KONSINYASI" Then
                query = "Select Faktur,FakturAsli,Total from trPCHeader where kdSupplier='" & cKdSupplier.Text & "' and isnull(Uservalid,'') <> ''"
            Else
                query = "Select Faktur,FakturAsli,Total from trKonsHeader where kdSupplier='" & cKdSupplier.Text & "' and isnull(Uservalid,'') <> '' order by Tanggal ASC"
            End If

            cFakturBeli.FirstInit(PubConnStr, query, {tFakturAsli}, , , , , , {1.3, 1.3, 1})
        End If
    End Sub

    Private Sub cFakturBeli_EditValueChanged(sender As Object, e As EventArgs) Handles cFakturBeli.EditValueChanged
        'If CheckBeforeSave({cFakturBeli}) = False Then Exit Sub
        'If isFirstInit = True Then Exit Sub
        Dim vw As String = ""
        If Not cJenis.Text = "RETUR PENERIMAAN BARANG KONSINYASI" Then
            vw = "vwPC"
        Else
            vw = "vwKONS"
        End If
        Dim jml As String = ""
        If Not cJenis.Text = "RETUR ADMIN ECER" And Not cJenis.Text = "RETUR ADMIN GANTI QTY" Then
            jml = "Jumlah"
        Else
            jml = "cast(0 as numeric(10))"
        End If
        Dim query As String = ""
        query = _
            "select b.Kode, cast('' as varchar(225)) as KodeBaru,Judul, cast('' as varchar(225)) as JudulBaru, " & _
            "       Saldo = isnull((select sum(akhir) from trStkGud a where b.kode = a.kode and a.KdGudang = '" & tKdGudang.Text & "'),0), " & _
            "       b.Qty as QtyFKT,b.QtyRetur as QtyReturSebelumnya,b.Harga,b.Disc,cast(0 as numeric(10)) as QtyRetur, " & _
            "       cast(0 as numeric(10)) as QtyBaru,cast(0 as numeric(10)) as HargaBaru,cast(0 as numeric(10)) as DiscBaru, " & _
            "       cast(0 as numeric(10)) as JumlahRetur, " & jml & " as JumlahTerima,b.DiscFaktur,b.Keterangan, " & _
            "       b.PersPPn, b.KdBuku " & _
            "from " & vw & " b " & _
            "where Faktur = '" & cFakturBeli.Text & "' and substring(faktur, 7,1) = '-' order by urutan"

        'query = _
        '    "select b.Kode, cast('' as varchar(225)) as KodeBaru,Judul, cast('' as varchar(225)) as JudulBaru, " & _
        '    "       Saldo = 4, " & _
        '    "       b.Qty as QtyFKT,b.QtyRetur as QtyReturSebelumnya,b.Harga,b.Disc,cast(0 as numeric(10)) as QtyRetur, " & _
        '    "       cast(0 as numeric(10)) as QtyBaru,cast(0 as numeric(10)) as HargaBaru,cast(0 as numeric(10)) as DiscBaru, " & _
        '    "       cast(0 as numeric(10)) as JumlahRetur, Jumlah as JumlahTerima,b.DiscFaktur,b.Keterangan, " & _
        '    "       b.PersPPn, b.KdBuku " & _
        '    "from " & vw & " b " & _
        '    "where Faktur = '" & cFakturBeli.Text & "' and substring(faktur, 7,1) = '-' order by urutan"

        Dim pVisFalse() As String = Nothing
        Dim pColEntry() As String = Nothing
        Dim fitGrid As Boolean = False

        Select Case cJenis.Text
            Case "RETUR ADMIN GANTI JUDUL"
                pVisFalse = {"QtyBaru", "HargaBaru", "DiscBaru", "JumlahTerima", "KdBuku", "Keterangan", "PersPPn"}
                getKodeBaru()
            Case "RETUR ADMIN GANTI QTY"
                pVisFalse = {"KodeBaru", "JudulBaru", "QtyBaru", "KdBuku", "Saldo", "DiscFaktur", "Keterangan", "PersPPn"}
                pColEntry = {"QtyRetur"}
            Case "RETUR ADMIN GANTI SUPPLIER"
                pVisFalse = {"JudulBaru", "QtyBaru", "HargaBaru", "DiscBaru", "JumlahTerima", "KdBuku", "Keterangan", "PersPPn"}
            Case "RETUR ADMIN ECER"
                pVisFalse = {"DiscFaktur", "Keterangan", "PersPPn", "KdBuku"}
                pColEntry = {"QtyRetur", "QtyBaru"}
                getKodeBaru()
            Case "RETUR FISIK"
                pVisFalse = {"QtyBaru", "HargaBaru", "DiscBaru", "JumlahTerima", "KdBuku", "KodeBaru", "JudulBaru", "DiscFaktur", "Keterangan", "PersPPn"}
                pColEntry = {"QtyRetur"}
                fitGrid = True
            Case "RETUR PENERIMAAN BARANG KONSINYASI"
                pVisFalse = {"QtyBaru", "HargaBaru", "DiscBaru", "JumlahTerima", "KdBuku", "KodeBaru", "JudulBaru", "DiscFaktur", "Keterangan", "PersPPn"}
                pColEntry = {"QtyRetur"}
                fitGrid = True
        End Select
        If isNew = True Then
            mdgList.FirstInit(query, {0.9, 0.9, 1.5, 1.5, _
                              0.5, _
                              0.5, 0.5, 1, 0.5, 0.5, _
                              0.5, 1, 0.5, _
                              1, 1, 1, 2, _
                              1, 1}, {"JumlahRetur", "JumlahTerima", "QtyFKT", "QtyReturSebelumnya", "QtyRetur", "QtyBaru"}, _
                          pColEntry, _
                          pVisFalse, _
                          , 40, fitGrid, 2, )
        Else
            mdgList.FirstInit(query, {0.9, 0.9, 1.5, 1.5, _
                  0.5, _
                  0.5, 0.5, 1, 0.5, 0.5, _
                  0.5, 1, 0.5, _
                  1, 1, 1, 2, _
                  1, 1}, {"JumlahRetur", "JumlahTerima", "QtyFKT", "QtyReturSebelumnya", "QtyRetur", "QtyBaru"}, _
              , _
              pVisFalse, _
              , 40, fitGrid, 2, )
        End If
        mdgList.RefreshData(False)

        tDiscFaktur.Text = ""
        tKeterangan.Text = ""
        sPersPPn.Text = ""
        If mdgList.GetRowCount_dSource > 0 Then
            tDiscFaktur.Text = mdgList.DataSource.Rows(0).Item("DiscFaktur")
            tKeterangan.Text = mdgList.DataSource.Rows(0).Item("Keterangan")
            sPersPPn.Text = mdgList.DataSource.Rows(0).Item("PersPPn")
        End If
    End Sub

    Sub getKodeBaru()
        If cFakturBeli.Text.Length = 0 Then Exit Sub
        Dim qq As String = _
            "select b.Kode,Judul, b.KdBuku from vwStkSup b where b.KdSupplier='" & cKdSupplier.Text & "'"
        mdgKodeBaru.FirstInit(qq, {0.9, 2, 0.8}, , , , , , False)
        mdgKodeBaru.RefreshData()
    End Sub

    Private Sub btnbaru_Click(sender As Object, e As EventArgs) Handles btnbaru.Click
        ClearValue(Me)
        sDiscount.Text = "0"
        sPersPPn.Text = "0"
        sSubTotal.Text = "0"
        mdgList.Grid_ClearDataAndColumns()
        mdgHistory.Grid_ClearDataAndColumns()
        mdgKodeBaru.Grid_ClearDataAndColumns()
        cmd = New SqlCommand("select Keterangan from stDefault where Kode='26'", kon)
        rd = cmd.ExecuteReader
        rd.Read()
        tKdGudang.Text = rd.Item(0)
        rd.Close()
        fakturoto()
        Dim tgl As Date = Format(Now, "dd/MM/yyyy")
        tTanggal.Text = tgl
        tKdGudang.ReadOnly = True
        cKdSupplier.Enabled = True
        tKonsi.Text = ""
        tAlamat.Text = ""
        tNama.Text = ""
    End Sub

    Private Sub CtrlMeDataGrid1_Grid_DoubleClick(sender As Object, e As EventArgs) Handles mdgList.Grid_DoubleClick
        If cJenis.Text = "RETUR ADMIN GANTI SUPPLIER" Then
            If cKdSupplierBaru.Text = "" Then
                MsgBox("Pilih Supplier Baru Terlebih Dahulu", vbCritical + vbOKOnly, "Peringatan")
            Else
                Dim buku, splbaru As String
                If cKdSupplierBaru.Text = "" Then
                    buku = "4566756"
                    splbaru = "dfhfdhgfdhdfjd"
                Else
                    buku = mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "KdBuku")
                    splbaru = cKdSupplierBaru.Text
                End If
                Dim query2 As String = _
                    "select Kode,Judul,KdBuku from vwStkSup where KdBuku='" & buku & "' and KdSupplier='" & splbaru & "'"
                mdgKodeBaru.FirstInit(query2, {1, 1, 1}, , , {"KdBuku"})
                mdgKodeBaru.RefreshData()
            End If
        End If
    End Sub

    Private Sub CtrlMeDataGrid1_Grid_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles mdgList.Grid_SelectionChanged
        Dim bk As String = ""
        Dim pKode As String = mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Kode")
        If pKode = Nothing Then
            pKode = "gf8hfgjhfohnfdhklfdhmgfklhmfg"
        End If
        cmd = New SqlCommand("Select top 1 KdBuku as hasil from mstStkSup where Kode ='" & pKode & "'", kon)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            bk = rd.Item(0)
        End If
        rd.Close()

        Dim query As String = _
        "select Faktur,Tanggal,KdSupplier,Qty, Disc, Harga from vwPCR where Faktur <> '" & tFaktur.Text & "' and Right(faktur,11) < '" & Strings.Right(tFaktur.Text, 11) & "' and kdBuku ='" & bk & "' Order by Tanggal desc"
        mdgHistory.FirstInit(query, {1, 1, 1, 1, 1, 1})
        mdgHistory.RefreshData()


        'If cJenis.Text = "RETUR ADMIN GANTI SUPPLIER" Then
        '    Dim buku, splbaru As String
        '    If cKdSupplierBaru.Text = "" Then
        '        buku = "4566756"
        '        splbaru = "dfhfdhgfdhdfjd"
        '    Else
        '        buku = mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "KdBuku")
        '        splbaru = cKdSupplierBaru.Text
        '    End If
        '    Dim query2 As String = _
        '        "select Kode,Judul,KdBuku from vwStkSup where KdBuku='" & buku & "' and KdSupplier='" & splbaru & "'"
        '    mdgKodeBaru.FirstInit(query2, {1, 1, 1}, , , {"KdBuku"})
        '    mdgKodeBaru.RefreshData()
        'End If

        If cJenis.Text = "RETUR PENERIMAAN BARANG KONSINYASI" Then
            Dim sql As String = "exec spCreateIDFIFOBm '" & cKdSupplier.Text & "','" & pubUserEntry & "','" & pubKodeUnit & "','" & mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Kode") & "'"
            cmd = New SqlCommand(sql, kon)
            cmd.ExecuteNonQuery()

            Dim sql1 As String = "exec spCreateIDSale '" & cKdSupplier.Text & "','" & Format(Now, "yymmdd") & "','" & pubUserEntry & "','" & pubKodeUnit & "','" & mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Kode") & "'"
            cmd = New SqlCommand(sql1, kon)
            cmd.ExecuteNonQuery()

            Dim sql2 As String = "SELECT * FROM dbo.tblGetMaxReturTanggal('" & mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Kode") & "','" & cFakturBeli.Text & "',DATEADD(dd,1," & DTOC(Now, "/", False) & "))"
            cmd = New SqlCommand(sql2, kon)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                tQtyMax.Text = rd!MaxRetur
            Else
                tQtyMax.Text = 0
            End If
            rd.Close()
        End If
    End Sub

    Private Sub cJenis_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cJenis.SelectedIndexChanged
        mdgList.Grid_ClearDataAndColumns()
        mdgKodeBaru.Grid_ClearDataAndColumns()
        mdgHistory.Grid_ClearDataAndColumns()
        'mdgHistory.Grid_ClearData()
        'mdgKodeBaru.Grid_ClearData()
        'mdgList.Grid_ClearData()

        'cFakturBeli.Text = ""
        cKdSupplierBaru.Text = ""
        tNamaSupplier.Text = ""
        sDiscount.Text = "0"
        sPersPPn.Text = "0"
        sSubTotal.Text = "0"
        lciKodeBaru.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        LayoutControlItem16.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        'If cJenis.Text = "" Then
        '    cJenis.Text = "RETUR FISIK"
        'End If
        If cJenis.Text = "RETUR ADMIN GANTI JUDUL" Or cJenis.Text = "RETUR ADMIN ECER" Then
            mdgKodeBaru.Enabled = True
            cKdSupplierBaru.Enabled = False
            lciKodeBaru.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        ElseIf cJenis.Text = "RETUR ADMIN GANTI QTY" Then
            mdgKodeBaru.Enabled = False
            cKdSupplierBaru.Enabled = False
        ElseIf cJenis.Text = "RETUR ADMIN GANTI SUPPLIER" Then
            mdgKodeBaru.Enabled = True
            cKdSupplierBaru.Enabled = True
            lciKodeBaru.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always

        ElseIf cJenis.Text = "RETUR PENERIMAAN BARANG KONSINYASI" Then
            mdgKodeBaru.Enabled = False
            cKdSupplierBaru.Enabled = False
            SetTextReadOnly({tQtyMax})
            LayoutControlItem16.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        ElseIf cJenis.Text = "RETUR FISIK" Then
        End If
        selsup()
        'fakturoto()
        'If cJenis.Text.Length > 0 Then
        '    SetTextReadOnly({cKdSupplier, cFakturBeli}, False)
        'Else
        '    SetTextReadOnly({cKdSupplier, cFakturBeli}, True)
        'End If
    End Sub

    Private Sub CtrlMeDataGrid3_Grid_DoubleClick(sender As Object, e As EventArgs) Handles mdgKodeBaru.Grid_DoubleClick
        If cJenis.Text = "RETUR ADMIN GANTI JUDUL" Then
            mdgList.SetRowCellValue(mdgList.FocusedRowHandle, "KodeBaru", mdgKodeBaru.GetRowCellValue(mdgKodeBaru.FocusedRowHandle, "Kode"))
            mdgList.SetRowCellValue(mdgList.FocusedRowHandle, "JudulBaru", mdgKodeBaru.GetRowCellValue(mdgKodeBaru.FocusedRowHandle, "Judul"))

            Dim jmlfkt, disko As Double
            jmlfkt = CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "QtyFKT")) * CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Harga"))
            disko = jmlfkt * (CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Disc")) / 100)
            mdgList.SetRowCellValue(mdgList.FocusedRowHandle, "JumlahRetur", jmlfkt - disko)

            sSubTotal.Text = mdgList.GetSummaryColDB("JumlahRetur")

        ElseIf cJenis.Text = "RETUR ADMIN GANTI SUPPLIER" Then
            mdgList.SetRowCellValue(mdgList.FocusedRowHandle, "KodeBaru", mdgKodeBaru.GetRowCellValue(mdgKodeBaru.FocusedRowHandle, "Kode"))
            Dim jmlfkt, disko As Double
            jmlfkt = CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "QtyFKT")) * CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Harga"))
            disko = jmlfkt * (CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Disc")) / 100)
            mdgList.SetRowCellValue(mdgList.FocusedRowHandle, "JumlahRetur", jmlfkt - disko)

            sSubTotal.Text = mdgList.GetSummaryColDB("JumlahRetur")

        ElseIf cJenis.Text = "RETUR ADMIN ECER" Then
            If mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Saldo") = 0 Then
                mdgList.SetRowCellValue(mdgList.FocusedRowHandle, "KodeBaru", "")
                mdgList.SetRowCellValue(mdgList.FocusedRowHandle, "JudulBaru", "")
            Else
                mdgList.SetRowCellValue(mdgList.FocusedRowHandle, "KodeBaru", mdgKodeBaru.GetRowCellValue(mdgKodeBaru.FocusedRowHandle, "Kode"))
                mdgList.SetRowCellValue(mdgList.FocusedRowHandle, "JudulBaru", mdgKodeBaru.GetRowCellValue(mdgKodeBaru.FocusedRowHandle, "Judul"))
            End If
        End If

        mdgList.gvMain.UpdateCurrentRow()
    End Sub

    Private Sub CtrlMeDataGrid1_Grid_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles mdgList.Grid_ValidateRow
        If cJenis.Text = "RETUR ADMIN GANTI QTY" Then
            If IsDBNull(mdgList.GetRowCellValue(e.RowHandle, "QtyRetur")) Then
                mdgList.SetRowCellValue(mdgList.FocusedRowHandle, "QtyRetur", 0)
                Dim total, diskon As Double
                total = CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "QtyRetur")) * CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "HargaBaru"))
                diskon = total * (CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "DiscBaru")) / 100)
                mdgList.SetRowCellValue(mdgList.FocusedRowHandle, "JumlahRetur", total - diskon)

                sSubTotal.Text = mdgList.GetSummaryCol("JumlahRetur")
            ElseIf mdgList.GetRowCellValue(e.RowHandle, "QtyRetur") > mdgList.GetRowCellValue(e.RowHandle, "QtyFKT") Then
                mdgList.SetRowCellValue(mdgList.FocusedRowHandle, "QtyRetur", 0)
            Else
                Dim total2, diskon2 As Double
                total2 = CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "QtyFKT")) * CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Harga"))
                diskon2 = total2 * (CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Disc")) / 100)
                mdgList.SetRowCellValue(mdgList.FocusedRowHandle, "JumlahTerima", total2 - diskon2)

                Dim total As Double
                mdgList.SetRowCellValue(e.RowHandle, "DiscBaru", mdgList.GetRowCellValue(e.RowHandle, "Disc"))

                Dim hrgBaru As Double = (mdgList.GetRowCellValue(e.RowHandle, "Harga") * mdgList.GetRowCellValue(e.RowHandle, "QtyFKT")) / mdgList.GetRowCellValue(e.RowHandle, "QtyRetur")
                mdgList.SetRowCellValue(e.RowHandle, "HargaBaru", hrgBaru)
                'mdgList.SetRowCellValue(mdgList.FocusedRowHandle, "JumlahRetur", mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "JumlahTerima"))
                total = mdgList.GetRowCellValue(e.RowHandle, "QtyRetur") * (100 - mdgList.GetRowCellValue(e.RowHandle, "DiscBaru")) * mdgList.GetRowCellValue(e.RowHandle, "HargaBaru") / 100
                mdgList.SetRowCellValue(e.RowHandle, "JumlahRetur", total)

                sSubTotal.Text = mdgList.GetSummaryColDB("JumlahRetur")
            End If


        ElseIf cJenis.Text = "RETUR ADMIN GANTI JUDUL" Then
            sSubTotal.Text = mdgList.GetSummaryColDB("JumlahRetur")
        ElseIf cJenis.Text = "RETUR ADMIN ECER" Then
            Dim sld As Double
            If CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Saldo")) < CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "QtyFKT")) Then
                sld = CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Saldo"))
            Else
                sld = CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "QtyFKT")) - CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "QtyReturSebelumnya"))
            End If

            If mdgList.GetRowCellValue(e.RowHandle, "KodeBaru") = "" Then
                mdgList.SetRowCellValue(mdgList.FocusedRowHandle, "QtyRetur", 0)
                mdgList.SetRowCellValue(mdgList.FocusedRowHandle, "HargaBaru", 0)
                mdgList.SetRowCellValue(mdgList.FocusedRowHandle, "DiscBaru", 0)
                Pesan({"Untuk barang ini, Kode barunya masih kosong", "", "Pilih kode baru dari list sebelah kanan, kemudian double klik kode baru tersebut untuk memasukkan ke list sebelah kiri"})

            ElseIf IsDBNull(mdgList.GetRowCellValue(e.RowHandle, "QtyRetur")) Then
                mdgList.SetRowCellValue(mdgList.FocusedRowHandle, "QtyRetur", 0)
                Dim total, diskon As Double
                total = CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "QtyRetur")) * CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "HargaBaru"))
                diskon = total * (CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "DiscBaru")) / 100)
                mdgList.SetRowCellValue(mdgList.FocusedRowHandle, "JumlahRetur", total - diskon)
                sSubTotal.Text = mdgList.GetSummaryCol("JumlahRetur")

            ElseIf mdgList.GetRowCellValue(e.RowHandle, "QtyRetur") > sld Then
                mdgList.SetRowCellValue(mdgList.FocusedRowHandle, "QtyRetur", 0)

            Else
                Dim total, diskon As Double
                total = CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "QtyRetur")) * CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Harga"))
                diskon = total * (CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Disc")) / 100)
                mdgList.SetRowCellValue(mdgList.FocusedRowHandle, "JumlahRetur", total - diskon)

                If mdgList.GetRowCellValue(e.RowHandle, "QtyBaru") > 0 Then
                    Dim total1, diskon1 As Double
                    mdgList.SetRowCellValue(e.RowHandle, "DiscBaru", mdgList.GetRowCellValue(e.RowHandle, "Disc"))
                    Dim hrgBaru As Double = (mdgList.GetRowCellValue(e.RowHandle, "Harga") * mdgList.GetRowCellValue(e.RowHandle, "QtyRetur")) / mdgList.GetRowCellValue(e.RowHandle, "QtyBaru")
                    mdgList.SetRowCellValue(e.RowHandle, "HargaBaru", hrgBaru)

                    total1 = CDbl(mdgList.GetRowCellValue(e.RowHandle, "QtyBaru")) * CDbl(mdgList.GetRowCellValue(e.RowHandle, "HargaBaru"))
                    diskon1 = total * (CDbl(mdgList.GetRowCellValue(e.RowHandle, "DiscBaru")) / 100)
                    mdgList.SetRowCellValue(e.RowHandle, "JumlahTerima", total1 - diskon1)
                Else
                    mdgList.SetRowCellValue(e.RowHandle, "HargaBaru", 0)
                    mdgList.SetRowCellValue(e.RowHandle, "JumlahTerima", 0)
                End If

                sSubTotal.Text = mdgList.GetSummaryColDB("JumlahTerima")
            End If

        ElseIf cJenis.Text = "RETUR FISIK" Then
            Dim sld As Double
            If CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Saldo")) < CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "QtyFKT")) Then
                sld = CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Saldo"))
            Else
                sld = CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "QtyFKT")) - CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "QtyReturSebelumnya"))
            End If

            If IsDBNull(mdgList.GetRowCellValue(e.RowHandle, "QtyRetur")) Then
                mdgList.SetRowCellValue(mdgList.FocusedRowHandle, "QtyRetur", 0)
                Dim total, diskon As Double
                total = CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "QtyRetur")) * CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Harga"))
                diskon = total * (CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Disc")) / 100)
                mdgList.SetRowCellValue(mdgList.FocusedRowHandle, "JumlahRetur", total - diskon)
                sSubTotal.Text = mdgList.GetSummaryColDB("JumlahRetur")
            ElseIf mdgList.GetRowCellValue(e.RowHandle, "QtyRetur") > sld Then
                mdgList.SetRowCellValue(mdgList.FocusedRowHandle, "QtyRetur", 0)
            Else
                Dim total, diskon As Double
                total = CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "QtyRetur")) * CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Harga"))
                diskon = total * (CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Disc")) / 100)
                mdgList.SetRowCellValue(mdgList.FocusedRowHandle, "JumlahRetur", total - diskon)

                Dim total1, diskon1 As Double
                total1 = CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "QtyRetur")) * CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Harga"))
                diskon1 = total * (CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Disc")) / 100)
                mdgList.SetRowCellValue(mdgList.FocusedRowHandle, "JumlahRetur", total1 - diskon1)

                sSubTotal.Text = mdgList.GetSummaryColDB("JumlahRetur")
            End If
        ElseIf cJenis.Text = "RETUR PENERIMAAN BARANG KONSINYASI" Then
            Dim angka() As Integer = {CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Saldo")), CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "QtyFKT")), tQtyMax.Text}

            Dim hasil = Aggregate nilai In angka Into Min(nilai), Max(nilai)


            'If CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Saldo")) < CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "QtyFKT")) Then
            '    sld = CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Saldo"))
            'Else
            '    sld = CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "QtyFKT")) - CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "QtyReturSebelumnya"))
            'End If

            If IsDBNull(mdgList.GetRowCellValue(e.RowHandle, "QtyRetur")) Then
                mdgList.SetRowCellValue(mdgList.FocusedRowHandle, "QtyRetur", 0)
                Dim total, diskon As Double
                total = CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "QtyRetur")) * CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Harga"))
                diskon = total * (CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Disc")) / 100)
                mdgList.SetRowCellValue(mdgList.FocusedRowHandle, "JumlahRetur", total - diskon)
                sSubTotal.Text = mdgList.GetSummaryColDB("JumlahRetur")
            ElseIf mdgList.GetRowCellValue(e.RowHandle, "QtyRetur") > hasil.Min Then
                mdgList.SetRowCellValue(mdgList.FocusedRowHandle, "QtyRetur", 0)
            Else
                Dim total, diskon As Double
                total = CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "QtyRetur")) * CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Harga"))
                diskon = total * (CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Disc")) / 100)
                mdgList.SetRowCellValue(mdgList.FocusedRowHandle, "JumlahRetur", total - diskon)

                Dim total1, diskon1 As Double
                total1 = CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "QtyRetur")) * CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Harga"))
                diskon1 = total * (CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Disc")) / 100)
                mdgList.SetRowCellValue(mdgList.FocusedRowHandle, "JumlahRetur", total1 - diskon1)

                sSubTotal.Text = mdgList.GetSummaryColDB("JumlahRetur")
            End If
        End If
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If CheckBeforeSave({cJenis, cKdSupplier}) = False Then Exit Sub
        If mdgList.GetRowCount_dSource = 0 Then
            Pesan({"Daftar barang retur masih kosong"})
            Exit Sub
        End If

        Dim dTidakSamaJumlah() As DataRow = mdgList.DataSource.Select("KodeBaru = '' AND JumlahRetur <> JumlahTerima")
        Dim dTidakSamaJumlahQTY() As DataRow = mdgList.DataSource.Select("QtyRetur <> 0 AND JumlahRetur <> JumlahTerima")
        Dim dTIdakSamaQTY() As DataRow = mdgList.DataSource.Select("QtyRetur = 0")
        Dim colQty As String = "QtyFKT"
        Dim colQtyNew As String = "QtyFKT"
        Dim colKode As String = "Kode"
        Dim colHarga As String = "Harga"
        Dim colDisc As String = "Disc"
        Dim colKodeLama As String = "KodeLama"
        Dim colKdSupplier As String = cKdSupplier.Text

        Dim fakturaslibarux As String = ""
        If Not cJenis.Text = "RETUR PENERIMAAN BARANG KONSINYASI" Then
            If CheckBeforeSave({cFakturBeli}) = False Then Exit Sub
            Dim qex As String = _
                "select FakturAsli from trPCHeader where Faktur='" & cFakturBeli.Text & "'"
            cmd = New SqlCommand(qex, kon)
            rd = cmd.ExecuteReader
            rd.Read()
            fakturaslibarux = tFaktur.Text & "/" & rd.Item(0)
            rd.Close()
        End If

        Dim dRow() As DataRow = Nothing
        Select Case cJenis.Text
            Case "RETUR FISIK"
                If dTIdakSamaQTY.Length = mdgList.DataSource.Rows.Count Then
                    MsgBox("Tidak Ada yang Diretur", vbCritical + vbOKOnly, "Peringatan")
                    Exit Sub
                End If
                dRow = mdgList.DataSource.Select("QtyRetur <> 0")
                colKode = "Kode"
                colQty = "QtyRetur"
                colQtyNew = "QtyRetur"
                colHarga = "Harga"
                colDisc = "Disc"
                colKodeLama = "Kode"

            Case "RETUR ADMIN GANTI QTY"

                If dTidakSamaJumlahQTY.Length > 0 Then
                    MsgBox("Jumlah Retur Tidak Sama Dengan Jumlah Sebelumnya", vbCritical + vbOKOnly, "Peringatan")
                    Exit Sub
                End If
                dRow = mdgList.DataSource.Select("QtyRetur <> 0")
                colQtyNew = "QtyRetur"
                colDisc = "DiscBaru"
                colHarga = "HargaBaru"
                colKodeLama = "Kode"

            Case "RETUR ADMIN GANTI JUDUL"
                dRow = mdgList.DataSource.Select("KodeBaru <> ''")
                colKode = "KodeBaru"
                colKodeLama = "Kode"

            Case "RETUR ADMIN GANTI SUPPLIER"
                Dim dRowCek() As DataRow = mdgList.DataSource.Select("KodeBaru = ''")
                If dRowCek.Length > 0 Then
                    MsgBox("Kode Baru Belum Lengkap", vbCritical + vbOKOnly, "Peringatan")
                    Exit Sub
                End If
                dRow = mdgList.DataSource.Select("")
                colKode = "KodeBaru"
                colKdSupplier = cKdSupplierBaru.Text
                colKodeLama = "Kode"

            Case "RETUR ADMIN ECER"
                If dTidakSamaJumlah.Length > 0 Then
                    MsgBox("Jumlah Retur Tidak Sama Dengan Jumlah Sebelumnya", vbCritical + vbOKOnly, "Peringatan")
                    Exit Sub
                End If
                dRow = mdgList.DataSource.Select("KodeBaru <> ''")
                colQty = "QtyRetur"
                colKode = "KodeBaru"
                colQtyNew = "QtyBaru"
                colHarga = "HargaBaru"
                colDisc = "Discbaru"
                colKodeLama = "Kode"

            Case "RETUR PENERIMAAN BARANG KONSINYASI"
                If dTIdakSamaQTY.Length = mdgList.DataSource.Rows.Count Then
                    MsgBox("Tidak Ada yang Diretur", vbCritical + vbOKOnly, "Peringatan")
                    Exit Sub
                End If
                dRow = mdgList.DataSource.Select("QtyRetur <> 0")
                colKode = "Kode"
                colQty = "QtyRetur"
                colQtyNew = "QtyRetur"
                colHarga = "Harga"
                colDisc = "Disc"
                colKodeLama = "Kode"
        End Select

        Dim tabelheader As String = ""
        Dim tabeldetail As String = ""
        Dim faktur As String = ""
        If Not cJenis.Text = "RETUR PENERIMAAN BARANG KONSINYASI" Then
            tabelheader = "trPCRHeader"
            tabeldetail = "trPCRDetail"
            faktur = "FakturBeli"
        Else
            tabelheader = "trKonsRHeader"
            tabeldetail = "trKonsRDetail"
            faktur = "FakturKons"
        End If

        '-- Save Header PCR
        Dim que As String = _
            "Insert Into " & tabelheader & " (Status,Faktur,Tanggal,KdSupplier,KdGudang, " & _
            "       DiscFaktur," & faktur & ",Keterangan,PersPPN,SubTotal, " & _
            "       Discount,PPn,Total,UserEntry,DateTimeEntry,Jenis) " & _
            "Values ('1','" & tFaktur.Text & "','" & DTOC(Now, "/", True) & "','" & cKdSupplier.Text & "','" & tKdGudang.Text & "','" & _
            tDiscFaktur.Value & "','" & cFakturBeli.Text & "','" & tKeterangan.Text & "','" & sPersPPn.Value & "','" & sSubTotal.Value & "','" & _
            sDiscount.Value & "','" & sPPn.Value & "','" & sTotal.Value & "','" & pubUserEntry & "','" & DTOC(Now, "/", True) & "','" & cJenis.Text & "')"
        cmd = New SqlCommand(que, kon)
        cmd.ExecuteNonQuery()


        '-- Save Detail PCR
        Dim ur As Integer = 1
        For Each xx As DataRow In dRow
            Dim qq As String = _
                "Insert Into " & tabeldetail & _
                "   (Status,Faktur,Tanggal,KdGudang,Kode1," & _
                "   kode,KdBuku,Qty,Disc,Harga," & _
                "   Jumlah)  " & _
                "Values ('1','" & tFaktur.Text & "','" & DTOC(Now, "/", True) & "','" & tKdGudang.Text & "','" & xx!Kode & "','" & _
                        xx!Kode & "','" & xx!KdBuku & "','" & xx.Item(colQty) & "','" & xx!Disc & "','" & xx!Harga & "','" & _
                        xx!JumlahRetur & "')"
            cmd = New SqlCommand(qq, kon)
            cmd.ExecuteNonQuery()

            If cJenis.Text = "RETUR PENERIMAAN BARANG KONSINYASI" Then
                Dim sql As String = "exec spCreateIDRetSupplier '" & cKdSupplier.Text & "','" & pubUserEntry & "','" & pubKodeUnit & "','" & tFaktur.Text & "'"
                cmd = New SqlCommand(sql, kon)
                cmd.ExecuteNonQuery()
            End If


            If Not cJenis.Text = "RETUR PENERIMAAN BARANG KONSINYASI" Then

                'update header
                Dim totqty, totrec As Integer
                Dim qqtyquery As String = _
                    "select sum(qty) as TotQty,count(*) as TotRec from " & tabeldetail & " where faktur='" & tFaktur.Text & "'"
                cmd = New SqlCommand(qqtyquery, kon)
                rd = cmd.ExecuteReader
                rd.Read()
                If rd.HasRows Then
                    totqty = rd!TotQty
                    totrec = rd!TotRec
                End If
                rd.Close()

                Dim updheader As String = _
                    "update " & tabelheader & " set TotQty='" & totqty & "',TotRec='" & totrec & "'"
                cmd = New SqlCommand(updheader, kon)
                cmd.ExecuteNonQuery()


                Dim qPCgen As String = _
                    "INSERT INTO trPCRAdminGen(Status, Faktur, Tanggal, Kode, Qty, " & _
                    "       Keterangan, Urutan, Harga, Disc, " & _
                    "       FakturAsliBaru, KdGudang, PPn, KdSupplier, DiscFaktur, " & _
                    "       PersPPn,KodeLama) " & _
                    "VALUES (1, '" & tFaktur.Text & "', '" & DTOC(Now, "/", True) & "', '" & xx.Item(colKode) & "', '" & xx.Item(colQtyNew) & "', " & _
                    "       '" & tKeterangan.Text & "', " & ur & ", '" & xx.Item(colHarga) & "', '" & xx.Item(colDisc) & "', " & _
                    "       '" & fakturaslibarux & "', '" & tKdGudang.Text & "', '" & sPPn.Value & "', '" & colKdSupplier & "', '" & tDiscFaktur.Value & "', " & _
                    "       '" & sPersPPn.Value & "','" & xx.Item(colKodeLama) & "');"
                cmd = New SqlCommand(qPCgen, kon)
                cmd.ExecuteNonQuery()
            End If
            ur += 1
        Next


        '--stDUMP
        Using dbdump As New cMeDB
            Dim pTableName As String = "trKonsRDetail"
            If Not cJenis.Text = "RETUR PENERIMAAN BARANG KONSINYASI" Then pTableName = "trPCRDetail"

            Dim pQ As String = _
                "INSERT INTO stDump(Faktur, Tanggal, Kode, Status, Transaksi, BulanKe) " & _
                "select faktur, GETDATE(), kode, 0, '" & pTableName & "', MONTH(GETDATE()) from " & pTableName & " where faktur IN ('" & tFaktur.Text & "')"
            dbdump.ExecScalar(pQ)
        End Using


        MsgBox("Berhasil Tersimpan", vbInformation + vbOKOnly, "Informasi")
        Close()
        'btnbaru.PerformClick()
    End Sub

    Private Sub cKdSupplierBaru_EditValueChanged(sender As Object, e As EventArgs) Handles cKdSupplierBaru.EditValueChanged
        'If Not cKdSupplierBaru.Text = "" Then
        '    cmd = New SqlCommand("select Nama from mstSupplier where Kode='" & cKdSupplierBaru.Text & "'", kon)
        '    rd = cmd.ExecuteReader
        '    rd.Read()
        '    tNamaSupplier.Text = rd.Item(0)
        '    rd.Close()
        'End If


        If cJenis.Text = "RETUR ADMIN GANTI SUPPLIER" Then
            Dim buku, splbaru As String
            If cKdSupplierBaru.Text = "" Then
                buku = "4566756"
                splbaru = "dfhfdhgfdhdfjd"
            Else
                buku = mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "KdBuku")
                splbaru = cKdSupplierBaru.Text
            End If
            Dim query2 As String = _
                "select Kode,Judul,KdBuku from vwStkSup where KdBuku='" & buku & "' and KdSupplier='" & splbaru & "'"
            mdgKodeBaru.FirstInit(query2, {1, 1, 1}, , , {"KdBuku"})
            mdgKodeBaru.RefreshData()
        End If
    End Sub

    Private Sub tSubTotal_EditValueChanged_1(sender As Object, e As EventArgs) Handles sSubTotal.EditValueChanged
        refreshtot()
    End Sub
    Sub refreshtot()
        sSubTotal.Value = mdgList.GetSummaryColDB("JumlahRetur")
        sDiscount.Value = CDbl(sSubTotal.Value) * (CDbl(tDiscFaktur.Value) / 100)
        sTotal.Value = CDbl(sSubTotal.Value) - CDbl(sDiscount.Value)
        sPPn.Value = CDbl(sTotal.Value) * (CDbl(sPersPPn.Value) / 100)
    End Sub

    Private Sub mdgKodeBaru_Load(sender As Object, e As EventArgs) Handles mdgKodeBaru.Load

    End Sub

    Private Sub mdgList_Load(sender As Object, e As EventArgs) Handles mdgList.Load

    End Sub
End Class