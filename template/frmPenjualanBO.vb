Imports meCore
Imports System.Data.SqlClient
Public Class frmPenjualanBO
    Dim dbHead As New cMeDB
    Dim isNew As Boolean = True
    Dim pFaktur As String = pKodeInit
    Dim isFirstInit As Boolean = False
    Dim isSaving As Boolean = False
    Dim isBaruProsesAmbilDarifrmuAddItem = False
    'Dim pubKodeUnit As String = "601"
    'Dim pubUserInit As String = "FAN"
    'Dim pubUserEntry As String = "FANI"

    Private Sub frmPenjualanBO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isFirstInit = True
        initForm(Me, EnfrmSizeNotMax.efsnm0Default, DevExpress.XtraLayout.MoveFocusDirection.DownThenAcross)


        If Len(Me.Tag) > 0 Then
            pFaktur = Me.Tag
            isNew = False
        Else
            pFaktur = pKodeInit
            isNew = True
        End If
        cKdCustomer.FirstInit(PubConnStr, _
                              "select Kode,Nama,Alamat from mstCustomer " & _
                              "Where Left(kode,3) = '" & pubKodeUnit & "' and FlagActive = 1 Order by kode", _
                              {tNama, tAlamat}, , , , , False, {1, 1.5, 1})

        cKdSalesman.FirstInit(PubConnStr, _
                             "select Kode, Nama, Alamat from mstSalesman Order by kode,Nama", _
                             {tNamaSales}, , , , , , {1, 1, 1})


        SetTextReadOnly({tFaktur, tNama, tAlamat, tNamaSales, tTanggal, tKdGudang, tGrandTotal, tDiscount, tSubTotal, tPPn, sPersPPN, dTanggalTermin})
        SpinClearButton({tGrandTotal, tDiscFaktur, tDiscount, tSubTotal, tPPn, sPersPPN})
        SpinFormatString({tGrandTotal, tDiscFaktur, tDiscount, tSubTotal, tPPn, sPersPPN}, "n0")
        sPersPPN.Value = 10
        LoadDetail()
        isFirstInit = False
    End Sub

    Sub LoadDetail()
        Dim pQUe As String

        '--Header
        pQUe = "SELECT  Status, Faktur, FlagPajakFaktur, Tanggal,KdCustomer,FakturOrder, " & _
                "       Termin,DiscFaktur,KdGudang, KdSalesman,Keterangan,PersPPn, " & _
                "       SubTotal,Jenis,PPn, UserEntry, DateTimeEntry,  " & _
                "       UserUpdate, DateTimeUpdate, Fire " & _
                "FROM dbo.trSLHeader where Faktur = '" & pFaktur & "'"


        dbHead.FillMe(pQUe, True)
        isNew = Not ((dbHead.Rows.Count > 0))

        If isNew = False Then
            Dim drow As DataRow = dbHead.Rows(0)
            FillFormFromDataRow(Me, drow)
            SetTextReadOnly({cKdCustomer, cFakturOrder})
            btnSimpan.Enabled = False
        Else
            btnSimpan.Enabled = True
            tKeterangan.Text = "BARANG TELAH DITERIMA DENGAN BAIK DAN LENGKAP"
            tKdGudang.Text = "TOKO"
            SetTextReadOnly({cKdCustomer, cFakturOrder}, False)
        End If

        '--Detail
        pQUe = "select Faktur, Kode,KdBuku, Judul,Penyusun,Jilid,KdSupplier, " & _
                "       NamaPenerbit, 0 as QtySP, 0 as Saldo, Qty, Harga, Disc, " & _
                "       Jumlah, Status, FlagPajak, Tanggal, Kode1, Urutan " & _
                "FROM vwSL where Faktur = '" & pFaktur & "' order by Urutan, Kode"

        With dgList
            .FirstInit(pQUe, _
                    {1.3, 0.8, 0.8, 2, 1.5, 0.3, 0.6, _
                    1.5, 0.5, 0.5, 0.5, 1, 0.5, _
                     1, 1, 1, 1, 1, 1}, _
                    {"Qty", "Jumlah", "QtySP"}, {"Qty", "Harga", "Disc"}, _
                    {"Urutan", "Status", "Faktur", "FlagPajak", "Tanggal", "Kode1", "QtySP"}, , 40)
            .RefreshData(False)
            .DataSource.SetPK({"Faktur", "Kode"})
        End With

        sPersPPN.Value = 10
        RefreshTotal()

    End Sub

    Private Sub btnBaru_Click(sender As Object, e As EventArgs) Handles btnBaru.Click
        isFirstInit = True
        ClearValue(Me)
        pFaktur = pKodeInit
        LoadDetail()
        isFirstInit = False
    End Sub

    Private Sub cCustomer_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles cKdCustomer.EditValueChanging
        If isFirstInit = True Then Exit Sub
        If dgList.GetRowCount_dSource > 0 And isSaving = False Then
            If Tanya({"Jika anda ganti customer", "maka pekerjaan anda akan hilang.", "", "Ganti Customer?"}) = False Then
                e.Cancel = True
                Exit Sub
            Else
                btnBaru_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub cKdCustomer_EditValueChanged(sender As Object, e As EventArgs) Handles cKdCustomer.EditValueChanged
        cFakturOrder.FirstInit(PubConnStr, "select Faktur, Tanggal,NamaCustomer from vwSPHeader Where KdCustomer = '" & cKdCustomer.Text & "' Order by Tanggal", , , , , , , {0.8, 0.5, 1})
    End Sub

    Private Sub cFakturOrder_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles cFakturOrder.EditValueChanging
        If isFirstInit = True Then Exit Sub
        If dgList.GetRowCount_dSource > 0 And isSaving = False Then
            If Tanya({"Jika anda ganti Nomer Surat Penawaran", "maka pekerjaan anda akan hilang.", "", "Ganti Surat Penawaran?"}) = False Then
                e.Cancel = True
                Exit Sub
            End If
        End If
    End Sub

    Private Sub cSuratPenawaran_EditValueChanged(sender As Object, e As EventArgs) Handles cFakturOrder.EditValueChanged
        Dim q As String
        q = "select Kode,Judul,Penyusun,Jilid,KdSupplier," & _
            "NamaPenerbit,Saldo, Qty as QtySP,Harga,Disc," & _
            "Jumlah,FlagPajak, KdBuku from vwSP where Faktur = '" & cFakturOrder.Text & "' Order by Urutan"

        dgList.Grid_ClearData()
        Using dbt As New cMeDB
            dbt.FillMe(q)

            For i As Integer = 0 To dbt.Rows.Count - 1
                Dim dr As DataRow = dgList.DataSource.NewRow
                dr!Faktur = pKodeInit
                dr!Status = 1
                dr!Tanggal = Now
                dr!Kode1 = dbt.Rows(i)!Kode
                For col As Integer = 0 To dgList.DataSource.Columns.Count - 1
                    Dim NmCol As String = dgList.DataSource.Columns(col).ColumnName
                    If dbt.Columns.Contains(NmCol) = True Then
                        dr(NmCol) = dbt.Rows(i)(NmCol)
                    End If
                Next

                If dr!Saldo >= dr!QtySP Then
                    dr!Qty = dr!QtySP
                Else
                    dr!Qty = IIf(dr!Saldo < 0, 0, dr!Saldo)
                End If

                dr!Jumlah = dr!Qty * (dr!Harga * (100 - dr!Disc) / 100)

                dgList.DataSource.Rows.Add(dr)

                If i = dbt.Rows.Count - 1 Then
                    dgList.colDecimalDigitforNumCol = 2
                    dgList.RefreshDataView()
                End If
            Next
        End Using
        dgList.SetColumnVisible({"QtySP"}, True)
        RefreshTotal()


    End Sub

    Private Sub dgList_Grid_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles dgList.Grid_CustomDrawCell
        Select Case e.Column.FieldName
            Case "Saldo"
                If e.CellValue <= 0 Then
                    e.Appearance.BackColor = Color.Red
                    e.Appearance.ForeColor = Color.White
                End If
        End Select
    End Sub

    Private Sub dgList_Grid_DoubleClick(sender As Object, e As EventArgs) Handles dgList.Grid_DoubleClick

    End Sub

    'Private Sub tSubTotal_EditValueChanged(sender As Object, e As EventArgs)
    '    Dim diskon, jml As Double
    '    diskon = CDbl(tSubTotal.Text) * (CDbl(tDiscount.Text) / 100)
    '    jml = CDbl(tSubTotal.Text) - diskon
    '    tGrandTotal.Text = jml
    '    tPPn.Text = CDbl(tGrandTotal.Text) * (CDbl(sPersPPN.Text) / 100)
    'End Sub

    Private Sub dgList_Grid_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles dgList.Grid_FocusedRowChanged
        Dim pKode As String = dgList.GetRowCellValue(e.FocusedRowHandle, "Kode")
        Dim pQ As String = _
            "select Faktur,Tanggal as Tanggal,KdCustomer,Qty, Disc, Harga from vwSL  " & _
            "where Faktur <> '" & tFaktur.Text & "' and Right(faktur,11) < '" & Strings.Right(tFaktur.Text, 11) & "' and " & _
            "kdBuku in (Select KdBuku as hasil from mstStkSup where Kode ='" & pKode & "') Order by Tanggal desc"

        dglisthistory.FirstInit(pQ, {0.8, 0.5, 0.5, 0.5, 0.5, 0.8})
        dglisthistory.RefreshData(False)
    End Sub

    Private Sub dgList_Grid_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles dgList.Grid_ValidateRow

        If IsDBNull(dgList.GetRowCellValue(e.RowHandle, "Saldo")) Then
            dgList.SetRowCellValue(dgList.FocusedRowHandle, "Qty", 0)
        ElseIf dgList.GetRowCellValue(e.RowHandle, "Qty") > dgList.GetRowCellValue(e.RowHandle, "Saldo") Then
            dgList.SetRowCellValue(dgList.FocusedRowHandle, "Qty", 0)
        Else
        End If

        Dim total, diskon As Double
        total = CDbl(dgList.GetRowCellValue(dgList.FocusedRowHandle, "Qty")) * CDbl(dgList.GetRowCellValue(dgList.FocusedRowHandle, "Harga"))
        diskon = total * (CDbl(dgList.GetRowCellValue(dgList.FocusedRowHandle, "Disc")) / 100)
        dgList.SetRowCellValue(dgList.FocusedRowHandle, "Jumlah", total - diskon)
        RefreshTotal()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click

        If CheckBeforeSave({cKdCustomer, cKdSalesman}) = False Then Exit Sub
        If dgList.GetRowCount_dSource = 0 Then
            Pesan({"Belum ada detail yang di Input"})
            Exit Sub
        End If

        '--Cek yg Qty > saldo 
        Dim dro0 As DataRow() = dgList.DataSource.Select("Qty > Saldo and Qty > 0")
        If dro0.Length > 0 Then
            Pesan({"Masih ada Qty yang nilainya Lebih besar dari Saldo", "", "Silahkan Qty nya diisi sama dengan Saldo atau kurang dari Saldo"})
            Exit Sub
        End If


        '--Cek yg Qty nya masih 0
        dro0 = dgList.DataSource.Select("Qty = 0")
        If dro0.Length > 0 Then
            If dro0.Length = dgList.GetRowCount_dSource Then
                Pesan({"Belum ada Qty yang Diisi sama sekali"})
                Exit Sub
            Else
                If Tanya({"Masih ada Qty yang nilainya 0", "", "Jika lanjut save, maka yang Qty 0 tidak akan disimpan ke database", "", "", "Lanjutkan?"}) = False Then
                    Exit Sub
                End If
            End If
        End If

        '--Hapus yg Qtynya 0
        For Each dr As DataRow In dro0
            dr.Delete()
        Next


        Dim pFakturDTP As String = ""
        Dim pFakturBKP As String = ""
        Dim pFakt(1) As String
        pFakt(0) = ""
        pFakt(1) = ""

        Dim drBKP As DataRow() = dgList.DataSource.Select("FlagPajak = 1")
        Dim drDTP As DataRow() = dgList.DataSource.Select("FlagPajak = 0")

        If drDTP.Length > 0 Then
            pFakturDTP = GetNewFakturSQLServ(PubConnStr, "trSLHeader", "Faktur", pubKodeUnit & pubUserInit & "-FJ", Date.Now.ToString("yyMMdd"), 5, "")
            pFakt(0) = pFakturDTP
        End If

        If drBKP.Length > 0 Then
            If pFakt(0).Length = 0 Then
                pFakt(1) = GetNewFakturSQLServ(PubConnStr, "trSLHeader", "Faktur", pubKodeUnit & pubUserInit & "-FJ", Date.Now.ToString("yyMMdd"), 5, "")
            Else
                pFakt(1) = Strings.Left(pFakturDTP, 15) & (Strings.Right(pFakturDTP, 5) + 1).ToString.PadLeft(5, "0")
            End If
        End If

        For i As Integer = 0 To pFakt.Length - 1
            If pFakt(i).Length > 0 Then
                '----------------------------------Prepare Detail
                Dim pTotal As Double = 0, pBruto As Double = 0, pQty As Double = 0, pTotalPPN As Double = 0, nTotalPPn As Integer = 0, nSubTotal As Integer = 0, nTotalDisc As Integer = 0
                Dim urut As Integer = 1
                For j As Integer = 0 To dgList.GetRowCount_dSource - 1
                    If dgList.DataSource.Rows(j).RowState <> DataRowState.Deleted Then
                        If IIf(dgList.DataSource.Rows(j)!FlagPajak = True, 1, 0) = i Then
                            dgList.DataSource.Rows(j)!Faktur = pFakt(i)
                            dgList.DataSource.Rows(j)!Urutan = urut
                            pTotal = pTotal + dgList.DataSource.Rows(j)!Jumlah
                            pQty = pQty + dgList.DataSource.Rows(j)!Qty

                            pBruto = pBruto + (dgList.DataSource.Rows(j)!Qty * dgList.DataSource.Rows(j)!Harga)
                            If i = 1 Then
                                pTotalPPN = pTotalPPN + (dgList.DataSource.Rows(j)!Jumlah - (dgList.DataSource.Rows(j)!Jumlah * tDiscFaktur.Value))
                            End If
                            urut += 1
                        End If
                    End If
                Next
                If i = 1 Then
                    nTotalPPn = pTotalPPN - (pTotalPPN * (100 / 110))
                Else
                    nTotalPPn = 0
                End If
                nSubTotal = pTotal
                nTotalDisc = nSubTotal * (tDiscFaktur.Value * 0.01)


                '----------------------------------Prepare Header
                Dim dRow As DataRow
                dRow = dbHead.NewRow

                dRow("Status") = 1
                dRow("Faktur") = pFakt(i)
                dRow("FlagPajakFaktur") = i
                dRow("Tanggal") = IIf(isNew, DatetimeSetZeroTime(Now.Date), dRow("Tanggal"))
                dRow("KdCustomer") = cKdCustomer.Text
                dRow("FakturOrder") = cFakturOrder.Text
                dRow("Termin") = tTermin.Value
                dRow("DiscFaktur") = tDiscFaktur.Value
                dRow("KdGudang") = tKdGudang.Text
                dRow("KdSalesman") = cKdSalesman.Text
                dRow("Keterangan") = tKeterangan.Text
                dRow("PersPPn") = sPersPPN.Value
                dRow("SubTotal") = nSubTotal
                dRow("Jenis") = "KREDIT"
                dRow("PPn") = nTotalPPn
                dRow("UserEntry") = IIf(isNew, pubUserEntry, dRow("UserEntry"))
                dRow("DateTimeEntry") = IIf(isNew, Now, dRow("DateTimeEntry"))
                If Not (isNew) Then dRow("UserUpdate") = pubUserEntry
                If Not (isNew) Then dRow("DateTimeUpdate") = Now
                dRow("Fire") = 1

                dbHead.Rows.Add(dRow)
            End If
        Next



        '----------------------------------Save Data Header Detail
        Using trans As New cMeDBTransaction
            Dim dbtrans(1) As cMeDB
            dbtrans(0) = dbHead
            dbtrans(1) = dgList.DataSource

            Dim pQuez(1) As String
            pQuez(0) = ""
            pQuez(1) = "select Status, Faktur, Tanggal, Kode, Kode1, KdBuku, FlagPajak, Qty, Disc, Harga, Jumlah, Urutan from trSLDetail"

            If trans.StartTransactionSQLServ(dgList.DataSource.SQLConnection, dbtrans, pQuez, False) Then
                ''----------------------------------jalankan triger
                Dim pQue As String = "update a set fire=1, kode=kode, qty=qty, FlagPajak=FlagPajak FROM trSLDetail a where faktur IN ('" & pFakt(0) & "', '" & pFakt(1) & "')"
                dbHead.ExecScalar(pQue)


                ''----------------------------------insert stDump
                '''''''''''''''''''''''''''''''stDump("trSLDetail", {pFakt(0), pFakt(1)})

                If Tanya({"Penyimpanan Transaksi SUKSES", "", "Cetak Faktur?"}) Then
                    Dim pQueRpt As String = "Select * from vwSL where faktur in ('" & pFakt(0) & "','" & pFakt(1) & "') order by faktur, urutan"
                    If Tanya({"Langsung Cetak?"}) Then
                        ShowReport(pQueRpt, "rptSL", {compNama, compAlamat, compNoTlp, compNPWP}, printTo.o2Print)
                    Else
                        ShowReport(pQueRpt, "rptSL", {compNama, compAlamat, compNoTlp, compNPWP}, printTo.o1ShowPreview)
                    End If
                End If

                If Tanya({"Buat transaksi baru lagi?"}) Then
                    isSaving = True
                    btnBaru.PerformClick()
                    isSaving = False
                Else
                    Close()
                End If
            End If
        End Using

    End Sub

    Private Sub tDisc_EditValueChanged(sender As Object, e As EventArgs)
        If Not IsNumeric(tDiscFaktur.Text) Then
            tDiscFaktur.Text = "0"
        End If
    End Sub

    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        If CheckBeforeSave({cKdCustomer}) = False Then Exit Sub

        Dim frmAdd As New Form
        Dim addx As New frmuAddItem(frmuAddItem.enMasukKeluar.enmkKeluar, "", "TOKO")
        addx.Dock = DockStyle.Fill
        frmAdd.Controls.Add(addx)
        frmAdd.StartPosition = FormStartPosition.CenterScreen
        frmAdd.Size = New Size(800, 500)
        'CenterForm(frmAdd, EnfrmSizeNotMax.efsnmGiant)
        frmAdd.ShowDialog()
        If addx.GetDataCount > 0 Then
            isBaruProsesAmbilDarifrmuAddItem = True
            For i As Integer = 0 To addx.GetDataCount - 1
                Dim drow As DataRow = dgList.DataSource.Rows.Find({pFaktur, addx.GetDataRowCellValue(frmuAddItem.enColumn.Kode, i)})
                If drow Is Nothing Then
                    drow = dgList.DataSource.NewRow
                    drow("Status") = 1
                    drow("Faktur") = pFaktur
                    drow("Kode") = addx.GetDataRowCellValue(frmuAddItem.enColumn.Kode, i)
                    drow("Kode1") = addx.GetDataRowCellValue(frmuAddItem.enColumn.Kode, i)
                    drow("Judul") = addx.GetDataRowCellValue(frmuAddItem.enColumn.Judul, i)
                    drow("Jilid") = addx.GetDataRowCellValue(frmuAddItem.enColumn.Jilid, i)
                    drow("NamaPenerbit") = addx.GetDataRowCellValue(frmuAddItem.enColumn.NamaPenerbit, i)
                    ''''''''''''''''''''''''''drow("KdSupplier") = addx.GetDataRowCellValue(frmuAddItem.enColumn.KdSupplier, i)
                    drow("Penyusun") = addx.GetDataRowCellValue(frmuAddItem.enColumn.Penyusun, i)
                    'drow("KdProduksi") = addx.GetDataRowCellValue(frmuAddItem.enColumn.KdProduksi, i)
                    drow("QtySP") = 0
                    ''''''''''''''''''''''''drow("Saldo") = addx.GetDataRowCellValue(frmuAddItem.enColumn.Saldo, i)
                    drow("Qty") = addx.GetDataRowCellValue(frmuAddItem.enColumn.Qty, i)
                    drow("Harga") = addx.GetDataRowCellValue(frmuAddItem.enColumn.Harga, i)
                    drow("Disc") = addx.GetDataRowCellValue(frmuAddItem.enColumn.Disc, i)
                    drow("Jumlah") = addx.GetDataRowCellValue(frmuAddItem.enColumn.Jumlah, i)
                    drow("FlagPajak") = addx.GetDataRowCellValue(frmuAddItem.enColumn.FlagPajak, i)
                    drow("Urutan") = 0 'mdgList.DataSource.Rows.Count + 1
                    drow("KdBuku") = addx.GetDataRowCellValue(frmuAddItem.enColumn.KdBuku, i)
                    drow("Tanggal") = tTanggal.EditValue
                    dgList.DataSource.Rows.Add(drow)


                    'pQUe = "select Faktur, Kode,Judul,Penyusun,Jilid,KdSupplier, " & _
                    '        "       NamaPenerbit, 0 as Saldo, Qty, Harga, Disc, " & _
                    '        "       Jumlah, Status, FlagPajak, Tanggal, Kode1, KdBuku, Urutan " & _
                    '        "FROM vwSL where Faktur = '" & pFaktur & "' order by Urutan, Kode"
                Else
                    Dim pStr() As String = _
                        {"Judul " & addx.GetDataRowCellValue(frmuAddItem.enColumn.Judul, i) & " [" & addx.GetDataRowCellValue(frmuAddItem.enColumn.Kode, i) & "]", _
                         "sudah ada didalam list dengan Qty = " & drow("Qty").ToString & "", _
                         "Sedangkan QtyFaktur yg akan di masukkan adalah " & addx.GetDataRowCellValue(frmuAddItem.enColumn.Qty, i).ToString, _
                         "Akumulasikan QtyFaktur ?"}
                    If Tanya(pStr) Then
                        'drow.
                        drow("Qty") += addx.GetDataRowCellValue(frmuAddItem.enColumn.Qty, i)
                        drow("Harga") = addx.GetDataRowCellValue(frmuAddItem.enColumn.Harga, i)
                        drow("Disc") = addx.GetDataRowCellValue(frmuAddItem.enColumn.Disc, i)
                        drow("Jumlah") += drow("Qty") * ((100 - drow("Disc")) * drow("Harga") / 100)
                    End If
                End If
                'If isNew = False Then dgList.DataSource.UpdateMeToRealDatabase()
            Next
            RefreshTotal()
            isBaruProsesAmbilDarifrmuAddItem = False
        End If
        addx.Dispose()
        frmAdd.Dispose()
    End Sub

    Sub RefreshTotal()
        If isFirstInit Then Exit Sub
        dgList.gvMain.UpdateTotalSummary()
        Dim jml As Double = dgList.GetSummaryColDB("Jumlah")
        tSubTotal.Value = jml
        tDiscount.EditValue = jml * (tDiscFaktur.Value) / 100
        tGrandTotal.Value = jml - tDiscount.Value
        tPPn.Value = tGrandTotal.Value * sPersPPN.Value / 100
    End Sub

    Private Sub tDiscFaktur_EditValueChanged(sender As Object, e As EventArgs) Handles tDiscFaktur.EditValueChanged, sPersPPN.EditValueChanged
        RefreshTotal()
    End Sub

    Private Sub cmdDel_Click(sender As Object, e As EventArgs) Handles cmdDel.Click
        If dgList.DataSource.Rows.Count > 0 Then
            If dgList.GetSelectedRowsCount > 0 Then
                If Tanya({"Anda akan menghapus " & dgList.GetSelectedRowsCount.ToString & " Kode didalam list...", "", "Lanjutkan?"}) Then
                    dgList.DeleteSelectedRows()
                    RefreshTotal()
                End If
            Else
                Pesan({"Pilih dulu Kode nya yg akan di hapus"})
            End If
        End If
    End Sub

    Private Sub tTermin_EditValueChanged(sender As Object, e As EventArgs) Handles tTermin.EditValueChanged
        dTanggalTermin.EditValue = DateAdd(DateInterval.Day, tTermin.Value, tTanggal.EditValue)
    End Sub
End Class