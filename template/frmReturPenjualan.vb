Imports System.Data.Sql
Imports System.Data.SqlClient
Imports meCore
Public Class frmReturPenjualan
    Dim db, db1 As New cMeDB
    Dim pubKodeUnit As String = "601"
    Dim pubUserInit As String = "FAN"
    Dim pubUserEntry As String = "FANI"
    Public kdkd, gdg As String
    Dim isNew As Boolean = True
    Dim pKode As String = "asdjaksdjqi01298310owueqiowueakdh"

    Dim dbHead As New cMeDB
    Dim pFaktur As String
    Dim pKdGudang As String


    Private Sub frmReturPembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LayoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

        initForm(Me, EnfrmSizeNotMax.efsnm0Default, DevExpress.XtraLayout.MoveFocusDirection.DownThenAcross)
        koneksi()
        tPersPPn.EditValue = 10

        If Me.Tag <> "" Then
            pFaktur = Me.Tag
        Else
            pFaktur = pKodeInit
        End If
        

        Dim p As String = "select Kode,Nama,Alamat from mstCustomer Where Left(kode,3) = '" & pubKodeUnit & "' Order by kode"
        cKdCustomer.FirstInit(PubConnStr, p, {tNama, tAlamat})

        cmd = New SqlCommand("select Keterangan from stDefault where Kode='26'", kon)
        rd = cmd.ExecuteReader
        rd.Read()
        pKdGudang = rd.Item(0)
        tKdGudang.Text = pKdGudang
        rd.Close()

        LoadDetail()
    End Sub

    Sub LoadDetail()
        Dim pQuery As String = _
            "Select Status,Faktur,Tanggal,KdCustomer,FakturJual, " & _
            "   KdGudang,DiscFaktur,Keterangan,PersPPn,SubTotal, " & _
            "   Discount,PPn,Total,UserEntry,DateTimeEntry, " & _
            "   UserValid,DateTimeValid,NoValidated,UserUpdate,DateTimeUpdate " & _
            "from trSLRHeader where Faktur = '" & pFaktur & "'"
        dbHead.FillMe(pQuery, True)

        isNew = True
        If dbHead.Rows.Count > 0 Then
            isNew = False
            FillFormFromDataRow(Me, dbHead.Rows(0))
            cFakturJual.Text = dbHead.Rows(0)!FakturJual


            Dim rr As String = "select * from trValidasi where Faktur='" & tFaktur.Text & "'"
            cmd = New SqlCommand(rr, kon)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                btnSimpan.Enabled = False
                LabelControl1.Text = "Tidak Bisa Disimpan. Faktur Sudah Divalidasi    "
            Else
                btnSimpan.Enabled = True
                LabelControl1.Text = ""
            End If
            rd.Close()
        End If

        SetTextReadOnly({tKdGudang, tFaktur, tTanggal})

        Dim q As String =
            "select Status, Faktur, Kode, KdBuku ,Judul, " & _
            "		Penyusun, KdSupplier, NamaPenerbit, 0 as QtyFkt, 0 as QtyRetur, " & _
            "       Qty, Harga, Disc, Jumlah, Urutan, " & _
            "       Tanggal, Kode1 " & _
            "from vwSLR where Faktur='" & pFaktur & "' " & _
            "order by Urutan"

        mdgList.FirstInit(q, {1, 0.8, 1, 0.8, 0.8, 0.8, 1, 0.8, 0.5, 0.8, 0.8, 0.5, 0.8, 0.5, 0.5}, _
                          , {"Qty"}, {"Faktur", "Urutan", "Status", "Tanggal", "Kode1", "KdBuku"}, , 40)
        mdgList.RefreshData(False)


        'tampilkan barang yg sudah tersimpan
        If isNew = False Then
            'fakjualdg()
            SetTextReadOnly({tKdGudang, tFaktur, tTanggal, cFakturJual, cKdCustomer})
            Dim qq As String = "select * from vwSL where Faktur='" & cFakturJual.Text & "' and Qty <> 0"
            cmd = New SqlCommand(qq, kon)
            dt = New DataTable
            dt.Load(cmd.ExecuteReader())
            DataGridView1.DataSource = dt

            For c = 0 To DataGridView1.RowCount - 2
                For a = 0 To mdgList.DataSource.Rows.Count - 1
                    If DataGridView1.Item(0, c).Value = mdgList.GetRowCellValue(a, "Kode") Then
                        mdgList.SetRowCellValue(a, "QtyFkt", DataGridView1.Item(1, c).Value)
                        mdgList.SetRowCellValue(a, "QtyRetur", DataGridView1.Item(57, c).Value)

                        Dim total, diskon As Double
                        total = CDbl(mdgList.GetRowCellValue(a, "Harga")) * CDbl(mdgList.GetRowCellValue(a, "Qty"))
                        diskon = total * (CDbl(mdgList.GetRowCellValue(a, "Disc")) / 100)
                        mdgList.SetRowCellValue(a, "Jumlah", total - diskon)
                    End If
                Next
            Next
        End If

    End Sub

    Private Sub btnbaru_Click(sender As Object, e As EventArgs) Handles btnbaru.Click
        ClearValue(Me)
        pFaktur = pKodeInit
        LoadDetail()
        tKdGudang.Text = pKdGudang
        cKdCustomer.Enabled = True
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
        "select Faktur,Tanggal,KdCustomer,Qty, Disc, Harga from vwSLR where Faktur <> '" & tFaktur.Text & "' and Right(faktur,11) < '" & Strings.Right(tFaktur.Text, 11) & "' and kdBuku ='" & bk & "' Order by Tanggal desc"
        mdgHistory.FirstInit(query, {1, 1, 1, 1, 1, 1})
        mdgHistory.RefreshData()
    End Sub

    Private Sub cKdCustomer_EditValueChanged(sender As Object, e As EventArgs) Handles cKdCustomer.EditValueChanged
        Dim q As String =
            "select Faktur, Tanggal,NamaCustomer from vwSLHeader Where KdCustomer = '" & cKdCustomer.Text & "' and substring(faktur,7,1) = '-' Order by Tanggal"
        cFakturJual.FirstInit(PubConnStr, q)
    End Sub
    Sub fakjualdg()
        Dim q As String =
            "select Status,Kode,Judul,Penyusun,KdSupplier,NamaPenerbit,Qty as QtyFkt,QtyRetur, 0 as Qty, Harga,Disc, 0 as Jumlah,case LockJual when '1' then 'Saldo Terkunci' when '0' then '' end as InfoSaldo,Urutan,Tanggal,Kode1,KdBuku from vwSL where Faktur='" & cFakturJual.Text & "'"

        Using dbt As New cMeDB
            dbt.FillMe(q)
            For i As Integer = 0 To dbt.Rows.Count - 1
                Dim dr As DataRow = mdgList.DataSource.NewRow
                dr!Faktur = pKodeInit
                For col As Integer = 0 To mdgList.DataSource.Columns.Count - 1
                    Dim NmCol As String = mdgList.DataSource.Columns(col).ColumnName
                    If dbt.Columns.Contains(NmCol) = True Then
                        dr(NmCol) = dbt.Rows(i)(NmCol)
                    End If
                Next
                mdgList.DataSource.Rows.Add(dr)
            Next
        End Using

        'mdgList.FirstInit(q, {1, 0.8, 1, 0.8, 0.8, 1, 0.8, 0.5, 0.8, 0.8, 0.5, 0.8, 0.8, 0.5, 0.5}, , {"QTY"}, {"Faktur", "Urutan", "Status", "Tanggal", "Kode1", "KdBuku"}, , 40)
        'mdgList.RefreshData(False)
    End Sub
    Private Sub cFakturJual_EditValueChanged(sender As Object, e As EventArgs) Handles cFakturJual.EditValueChanged
        mdgList.Grid_ClearData()
        fakjualdg()
        koneksi()
        cmd = New SqlCommand("select * from trslheader where faktur='" & cFakturJual.Text & "'", kon)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            tDiscFaktur.EditValue = rd!DiscFaktur
        End If
        rd.Close()
    End Sub

    Private Sub mdgList_Grid_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles mdgList.Grid_ValidateRow
        If Not mdgList.GetRowCellValue(e.RowHandle, "InfoSaldo") = "Saldo Terkunci" Then
            If IsDBNull(mdgList.GetRowCellValue(e.RowHandle, "Jumlah")) Then
                mdgList.SetRowCellValue(mdgList.FocusedRowHandle, "Jumlah", 0)
                Dim total, diskon As Double
                total = CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Harga")) * CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Qty"))
                diskon = total * (CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Disc")) / 100)
                mdgList.SetRowCellValue(mdgList.FocusedRowHandle, "Jumlah", total - diskon)

                tSubTotal.Text = mdgList.GetSummaryCol("Jumlah")
            ElseIf mdgList.GetRowCellValue(e.RowHandle, "Qty") > mdgList.GetRowCellValue(e.RowHandle, "QtyFkt") Then
                mdgList.SetRowCellValue(mdgList.FocusedRowHandle, "Qty", 0)

            Else
                Dim total, diskon As Double
                total = CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Harga")) * CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Qty"))
                diskon = total * (CDbl(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Disc")) / 100)
                mdgList.SetRowCellValue(mdgList.FocusedRowHandle, "Jumlah", total - diskon)

            End If
        Else
            mdgList.SetRowCellValue(mdgList.FocusedRowHandle, "Qty", 0)
        End If
        tSubTotal.Text = mdgList.GetSummaryColDB("Jumlah")
    End Sub

    Private Sub tSubTotal_EditValueChanged_1(sender As Object, e As EventArgs) Handles tSubTotal.EditValueChanged
        'If tDiscFaktur.Text = "" Then
        '    tDiscFaktur.Text = "0"
        'End If
        If tDiscount.Text = "" Then
            tDiscount.Text = "0"
        End If
        'If tSubTotal.Text = "" Then
        '    tSubTotal.Text = "0"
        'End If
        'If tPersPPn.Text = "" Then
        '    tPersPPn.EditValue = 0
        'End If
        tDiscount.Value = CDbl(tSubTotal.Value) * (CDbl(tDiscFaktur.Value) / 100)
        tTotal.Value = CDbl(tSubTotal.Value) - CDbl(tDiscount.Value)
        'tPPn.Text = CDbl(tTotal.Text) * (CDbl(tPersPPn.Text) / 100)
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If CheckBeforeSave({cKdCustomer}) = False Then Exit Sub
        Dim djumlah() As DataRow = mdgList.DataSource.Select("Jumlah <> 0")
        If djumlah.Length <= 0 Then
            Pesan({"Belum ada yang diretur"})
            Exit Sub
        End If

        Dim dRow As DataRow
        If isNew Then
            tFaktur.Text = GetNewFakturSQLServ(PubConnStr, "trSLRHeader", "Faktur", pubKodeUnit & pubUserInit & "-RJ", Date.Now.ToString("yyMMdd"), 5, "")
            dRow = dbHead.NewRow
        Else
            dRow = dbHead.Rows(0)
        End If

        dRow("Status") = 1
        dRow("Faktur") = tFaktur.Text
        dRow("Tanggal") = IIf(isNew, DatetimeSetZeroTime(Now.Date), dRow("Tanggal"))
        dRow("FakturJual") = cFakturJual.Text
        dRow("KdCustomer") = cKdCustomer.Text
        dRow("DiscFaktur") = tDiscFaktur.Value
        dRow("KdGudang") = tKdGudang.Text
        dRow("Keterangan") = mKeterangan.Text
        dRow("PersPPn") = tPersPPn.Value
        dRow("SubTotal") = tSubTotal.Value
        dRow("Discount") = tDiscount.Text
        dRow("Total") = tTotal.Text
        dRow("PPn") = tPPn.Value
        dRow("UserEntry") = IIf(isNew, pubUserEntry, dRow("UserEntry"))
        dRow("DateTimeEntry") = IIf(isNew, Now, dRow("DateTimeEntry"))
        If Not (isNew) Then dRow("UserUpdate") = pubUserEntry
        If Not (isNew) Then dRow("DateTimeUpdate") = Now

        If isNew Then dbHead.Rows.Add(dRow)
        isNew = False

        '----------------------------------Prepare Detail
        For j As Integer = mdgList.GetRowCount_dSource - 1 To 0 Step -1
            If mdgList.DataSource.Rows(j).RowState <> DataRowState.Deleted Then
                mdgList.DataSource.Rows(j)!Faktur = tFaktur.Text
                mdgList.DataSource.Rows(j)!Urutan = j + 1
            End If
        Next

        '----------------------------------Save Data Header Detail
        Using trans As New cMeDBTransaction
            Dim dbtrans(1) As cMeDB
            dbtrans(0) = dbHead
            dbtrans(1) = mdgList.DataSource

            Dim pQuez(1) As String
            pQuez(0) = ""
            pQuez(1) = "select Status, Faktur, Tanggal, Kode, Kode1, KdBuku, Qty, Disc, Harga, Jumlah, Urutan from trSLRDetail"

            If trans.StartTransactionSQLServ(mdgList.DataSource.SQLConnection, dbtrans, pQuez, False) Then
                ''----------------------------------insert stDump
                Using dbdump As New cMeDB
                    Dim pQ As String = _
                        "INSERT INTO stDump(Faktur, Tanggal, Kode, Status, Transaksi, BulanKe) " & _
                        "select faktur, GETDATE(), kode, 1, 'trSLRDetail', MONTH(GETDATE()) from trSLRDetail where faktur IN ('" & tFaktur.Text & "')"
                    dbdump.ExecScalar(pQ)
                End Using

                If Tanya({"Penyimpanan Transaksi SUKSES", "", "Cetak Faktur?"}) Then
                    Dim pQueRpt As String = "Select * from vwSLR where faktur in ('" & tFaktur.Text & "') order by faktur, urutan"
                    ShowReport(pQueRpt, "rptSL", {compNama, compAlamat, compNoTlp, compNPWP})
                End If

                If Tanya({"Buat transaksi baru lagi?"}) Then
                    btnbaru.PerformClick()
                Else
                    Close()
                End If
            End If
        End Using
    End Sub

    Private Sub mdgList_Load(sender As Object, e As EventArgs) Handles mdgList.Load

    End Sub
End Class