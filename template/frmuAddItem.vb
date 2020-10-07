
Imports meCore

Public Class frmuAddItem
    Public Enum enMasukKeluar As Integer
        enmkMasuk = 0
        enmkKeluar = 1
    End Enum

    Public Enum enPajak As Integer
        en0All = 0
        en1DTP = 1
        en2BKP = 2
    End Enum

    Dim pKdSupCus As String
    Dim pKdGudang As String
    Dim pTransMasukKeluar As enMasukKeluar

    Dim dbList As New cMeDB

    Dim pQueStock As String = _
        "SELECT Kode, Judul,Penyusun,NamaPenerbit, " & _
        "       ISNULL(HJual,0) AS HargaKeluar, " & _
        "		CASE WHEN ISNULL(HBeli,0) = 0 THEN ISNULL(SHBeli,0) ELSE ISNULL(HBeli,0) END AS HargaMasuk, ISNULL(DiscBeli,0) AS DiscMasuk, " & _
        "		CASE WHEN ISNULL(FlagPajak,0) =0 THEN 'BEBAS PAJAK' ELSE 'KENA PAJAK' END AS FlagPajak , KdBuku, isnull(LockJual,0) as LockJual, LockBeli, DiscMax, KdTypeDisc, " & _
        "       KdProduksi, Jilid,ISBN, Halaman, KdSupplier, " & _
        "		Saldo, KdGolongan, Tahun " & _
        "FROM vwstksup "

    Dim pQueList As String = _
        "SELECT TOP 0 Kode, Judul, CAST(0 AS NUMERIC(10,0)) AS Qty, CAST(0 AS NUMERIC(10,0)) AS Harga, CAST(0 AS NUMERIC(10,2)) AS Disc, CAST(0 AS NUMERIC(10,2)) AS Jumlah, " & _
        "        Penyusun, NamaPenerbit, KdBuku, KdProduksi, FlagPajak, Jilid, CAST(0 AS NUMERIC(10,0)) AS HargaLama, CAST(0 AS NUMERIC(10,2)) AS DiscLama " & _
        "FROM vwstksup "

    Enum enColumn
        Kode = 0
        Judul = 1
        Qty = 2
        Harga = 3
        Disc = 4
        Jumlah = 5
        Penyusun = 6
        NamaPenerbit = 7
        KdBuku = 8
        KdProduksi = 9
        FlagPajak = 10
        Jilid = 11
        HargaLama = 12
        DiscLama = 13
    End Enum


    Public ReadOnly Property GetDataRowCellValue(ColIndex As enColumn, rowIndex As Integer) As Object
        Get
            Dim pRet As Object = Nothing
            If dbList IsNot Nothing Then
                If dbList.Rows.Count >= rowIndex Then
                    pRet = dbList.Rows(rowIndex).Item(ColIndex)
                End If
            End If
            Return pRet
        End Get
    End Property

    Public ReadOnly Property GetDataCount As Integer
        Get
            Return dbList.Rows.Count
        End Get
    End Property


    Public Sub New()
        InitializeComponent()
        pKdGudang = "GUDANG"
        pTransMasukKeluar = enMasukKeluar.enmkMasuk
        txtGudang.Text = pKdGudang
        InitValue()
    End Sub

    Public Sub New(xTransMasukKeluar As enMasukKeluar, xKdSupCus As String, xKdGudang As String,
                   Optional pFakturPO As String = "", Optional StatPajak As enPajak = enPajak.en0All)
        InitializeComponent()
        pKdSupCus = xKdSupCus
        pKdGudang = xKdGudang
        pTransMasukKeluar = xTransMasukKeluar

        Dim pWhereAdd As String = ""


        If xTransMasukKeluar = enMasukKeluar.enmkMasuk Then
            If Len(pFakturPO) > 0 Then
                pWhereAdd = "Kode in (select kode from trobdetail where Faktur = '" & pFakturPO & "') and "
            End If
        End If

        If xKdSupCus.Length > 0 Then pWhereAdd &= "KdSupplier = '" & xKdSupCus & "' and "
        If StatPajak <> enPajak.en0All Then pWhereAdd &= "ISNULL(FlagPajak,0) = " & IIf(StatPajak = enPajak.en1DTP, "0", "1") & " and "

        If pWhereAdd.Length > 0 Then pWhereAdd = " Where " & Mid(pWhereAdd, 1, pWhereAdd.Length - 4)

        pQueStock = "select * from (" & pQueStock & pWhereAdd & ") x "
        'pQueStock = "select * from (" & pQueStock & " Where KdSupplier = '" & xKdSupCus & "' " & pWhereAdd & ") x "

        InitValue()
    End Sub

    Sub InitValue()
        initForm(Me, EnfrmSizeNotMax.efsnm0Default, DevExpress.XtraLayout.MoveFocusDirection.AcrossThenDown)

        '--jika jenis masuk maka yg di hilangkan harga keluar
        'Dim invisCol() As Object = {4, 5, 6, 7, 8, 9, 15}
        Dim invisCol() As Object = {4, 7, 8, 9, 10, 11, 12}
        If pTransMasukKeluar = enMasukKeluar.enmkKeluar Then invisCol = {5, 6, 7, 8, 9, 10, 11, 12}


        mbeKode.SetProperties(PubConnStr, pQueStock, {"Judul", "Kode", "ISBN", "KdProduksi"}, _
                              {0.8, 2, 1.1, 1, _
                                0.6, 0.6, 0.3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, _
                            {txtNama, txtPenyusun1, txtPenerbit, txtTmp, txtTmp, txtTmp, _
                             txtStatus, txtKdBuku, chkLockJual, chkLockBeli, spDiscMax, txtKdTypeDisc, _
                             txtKdProd, txtJilid}, , , _
                            invisCol, "Kode", "Judul")

        SetTextReadOnly({txtGudang, spSaldo, spJumlah}, True)
        SpinClearButton({spQty, spDisc, spHarga})
        SpinFormatString({spQty}, "n0")
        SpinFormatString({spDisc}, "n2")
        SpinFormatString({spHarga, spJumlah}, "n2")
        txtGudang.Text = pKdGudang

        dbList.FillMe(pQueList)
        dbList.PrimaryKey = {dbList.Columns(0)}
        gcList.DataSource = dbList
    End Sub

    Private Sub ParentFormX_KeyDown(sender As Object, e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.Escape
                cmdCancel.PerformClick()
            Case Keys.F9
                cmdSave.PerformClick()
        End Select
    End Sub

    Private Sub cmdTambah_Click(sender As Object, e As EventArgs) Handles cmdTambah.Click
        cmdTambah.Enabled = False
        If pTransMasukKeluar = enMasukKeluar.enmkMasuk Then
            If chkLockBeli.Checked Then
                Pesan({"Kode ini tidak bisa dimasukkan ke dalam list karena sudah di Lock Beli"})
                GoTo clea
            End If
        Else
            If chkLockJual.Checked Then
                Pesan({"Kode ini tidak bisa dimasukkan ke dalam list karena sudah di Lock Jual"})
                GoTo clea
            End If
        End If

        If CheckBeforeSave({mbeKode, spQty}) Then
            Dim dRow As DataRow = dbList.Rows.Find({mbeKode.Text})
            If dRow Is Nothing Then
                dRow = dbList.NewRow
                dRow("Kode") = mbeKode.Text
                dRow("Judul") = txtNama.Text
                dRow("Qty") = spQty.Value
                dRow("Harga") = spHarga.Value
                dRow("Disc") = spDisc.Value
                dRow("Jumlah") = spJumlah.Value
                dRow("Penyusun") = txtPenyusun1.Text
                dRow("NamaPenerbit") = txtPenerbit.Text
                dRow("KdBuku") = txtKdBuku.Text
                dRow("KdProduksi") = txtKdProd.Text
                dRow("FlagPajak") = IIf(txtStatus.Text = "BEBAS PAJAK", 0, 1)
                dRow("Jilid") = txtJilid.Text
                dRow("HargaLama") = spHargaLama.Value
                dRow("DiscLama") = spDiscLama.Value
                dbList.Rows.Add(dRow)
            Else
                gvList.FocusedRowHandle = dbList.Rows.IndexOf(dRow)
                If Tanya({"Kode sudah ada di dalam daftar...", "Ganti qty nya dengan qty yg baru?"}) Then
                    dRow("Qty") = spQty.Value
                    dRow("Jumlah") = spJumlah.Value
                End If
            End If
clea:
            mbeKode.Text = ""
            mbeKode.Select()
        End If
        cmdTambah.Enabled = true
    End Sub

    Private Sub spQty_EditValueChanged(sender As Object, e As EventArgs) Handles spQty.EditValueChanged, spHarga.EditValueChanged, spDisc.EditValueChanged
        spJumlah.Value = spQty.Value * (100 - spDisc.Value) * spHarga.Value / 100
    End Sub

    Private Sub spDisc_KeyDown(sender As Object, e As KeyEventArgs) Handles spDisc.KeyDown, spQty.KeyDown, spHarga.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then e.Handled = True

        Select Case CType(sender, Control).Name
            Case "spQty"
                If e.KeyCode = Keys.Right Then spHarga.Select()
                If e.KeyCode = Keys.Down Then spDisc.Select()
            Case "spDisc"
                If e.KeyCode = Keys.Up Then spQty.Select()
            Case "spHarga"
                If e.KeyCode = Keys.Left Then spQty.Select()
        End Select
    End Sub

    Private Sub gvList_DataSourceChanged(sender As Object, e As EventArgs) Handles gvList.DataSourceChanged
        FormatGridView(gvList, , False, True)
        ReArrangeColumnWidth(gvList, {0.9, 2.5, 0.3, 0.6, 0.3, 0.7, 1.5, 1.5, 0.7, 1, 0.7, 0.6, 1, 1})
        SetFooterSummarySUMs(gvList, {"Qty", "Jumlah"})
        SetColumnVisibleS(gvList, {"HargaLama", "DiscLama"}, False)
        reFormatColumns(gvList, , 2)
    End Sub

    Dim isDoubleClick As Boolean = False
    Private Sub gvList_DoubleClick(sender As Object, e As EventArgs) Handles gvList.DoubleClick
        If gvList.RowCount > 0 Then
            isDoubleClick = True
            Dim pKodeX As String = gvList.GetFocusedRowCellValue("Kode")
            mbeKode.Text = pKodeX
            mbeKode.Select()
            SendKeys.Send("{Enter}")
        End If
    End Sub

    Private Sub mbeKode_On_ClearInfo() Handles mbeKode.On_ClearInfo
        GetInfoTambahan(Nothing)
    End Sub

    Private Sub mbeKode_gotTheChoice(valueChoice() As String, valueChoiceDrow As DataRow) Handles mbeKode.On_GotTheChoice
        GetInfoTambahan(valueChoice)
    End Sub

    Private Sub mbeKode_OnGrid_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles mbeKode.OnGrid_CustomDrawCell
        Dim pColName As String = IIf(pTransMasukKeluar = enMasukKeluar.enmkMasuk, "LockBeli", "LockJual")

        If CType(sender, DevExpress.XtraGrid.Views.Grid.GridView).GetRowCellValue(e.RowHandle, pColName) = True Then
            e.Appearance.ForeColor = Color.Red
        End If
    End Sub

    Sub GetInfoTambahan(valueChoiceX() As String)
        spHarga.Value = 0
        spDisc.Value = 0
        spHargaLama.Value = 0
        spDiscLama.Value = 0
        spSaldo.Value = 0
        spQty.Value = 0
        mdgSaldo.Query = "select top 0 KdGudang as Gudang, akhir as Qty from trStkGud "
        mdgSaldo.colWidth = {1.3, 0.7}
        mdgSaldo.colForRowCount = 0
        mdgSaldo.colSum = {"Qty"}
        mdgSaldo.colFitGrid = True

        If Len(mbeKode.Text) > 0 Then
            Using dbtmp As New cMeDB
                Dim pQue As String
                pQue = "select isnull(sum(isnull(Akhir,0)),0) as saldo from trSTKGUD where Kode = '" & mbeKode.Text & "' group by Kode"
                'If pKdGudang IsNot Nothing Then
                '    pQue = "select isnull(Akhir,0) as Saldo from trSTKGUD where Kode = '" & mbeKode.Text & "'  and kdGudang = '" & pKdGudang & "' "
                'Else
                '    pQue = "select isnull(sum(isnull(Akhir,0)),0) as saldo from trSTKGUD where Kode = '" & mbeKode.Text & "' group by Kode"
                'End If
                dbtmp.FillMe(pQue)
                If dbtmp.Rows.Count > 0 Then
                    spSaldo.Value = dbtmp.Rows(0)(0)
                    mdgSaldo.Query = "select KdGudang as Gudang, sum(akhir) as Qty from trStkGud where kode = '" & mbeKode.Text & "' " & _
                                    "group by Kdgudang having sum(akhir) <> 0 order by KdGudang"
                End If
            End Using

            If valueChoiceX IsNot Nothing Then
                If pTransMasukKeluar = enMasukKeluar.enmkMasuk Then
                    '--awal
                    'spHarga.Value = valueChoiceX(4)

                    '--gara2 margo
                    'spHarga.Value = valueChoiceX(3)

                    '--gara2 malang koran, jika harga jual 0, maka harga nya di jadikan 0 karena biar bisa perubahan harga
                    If valueChoiceX(3) = 0 Then
                        spHarga.Value = valueChoiceX(3)
                    Else
                        spHarga.Value = valueChoiceX(4)
                    End If

                    spDisc.Value = valueChoiceX(5)
                Else
                    spHarga.Value = valueChoiceX(3)
                    spDisc.Value = GetDiscJual(mbeKode.Text, spQty.Value)
                End If
            End If
            spHargaLama.Value = spHarga.Value
            spDiscLama.Value = spDisc.Value

            'Jika List Diatas di double click
            If isDoubleClick And valueChoiceX IsNot Nothing Then
                spQty.Value = gvList.GetFocusedRowCellValue("Qty")
                spHarga.Value = gvList.GetFocusedRowCellValue("Harga")
                spDisc.Value = gvList.GetFocusedRowCellValue("Disc")
                isDoubleClick = False
            End If
        End If
        mdgSaldo.RefreshData()
    End Sub

    Public Function GetDiscJual(pKode As String, pQty As Integer) As Double
        Dim pDiscJual As Double = 0
        Dim pQue As String
        Dim pLevelCst As String = "1"

        Using dbtmp As New cMeDB
            pQue = "SELECT RIGHT(DiscLevel,1) AS Level FROM dbo.mstCustomer WHERE kode = '" & pKdSupCus & "'"
            If dbtmp.Rows.Count > 0 Then pLevelCst = dbtmp.Rows(0)(0)
        End Using

        Using dbtmp As New cMeDB
            pQue = "SELECT a.Kode, a.KdBuku, b.Max1,b.Max2,b.Max3,b.Max4,b.Disc1,b.Disc2,b.Disc3,b.Disc4,b.Disc5,b.DiscMax FROM dbo.mstStkSup a " & _
                    "LEFT JOIN dbo.mstStock b ON a.KdBuku = b.Kode " & _
                    "WHERE a.Kode = '" & pKode & "'"
            dbtmp.FillMe(pQue)
            With dbtmp.Rows(0)
                If dbtmp.Rows.Count > 0 Then
                    If pQty <= !Max1 And pLevelCst <= 1 Then
                        pDiscJual = !Disc1
                    ElseIf pQty <= !Max2 And pLevelCst <= 2 Then
                        pDiscJual = !Disc2
                    ElseIf pQty <= !Max3 And pLevelCst <= 3 Then
                        pDiscJual = !Disc3
                    ElseIf pQty <= !Max4 And pLevelCst <= 4 Then
                        pDiscJual = !Disc4
                    ElseIf pQty > !Max4 And pLevelCst <= 5 Then
                        pDiscJual = !Disc5
                    End If
                    If !DiscMax <> 0 Then
                        If pDiscJual > !DiscMax Then
                            pDiscJual = Min(!DiscMax, !Disc5)
                        End If
                    End If
                Else
                    pDiscJual = 0
                End If
            End With
        End Using
        Return pDiscJual
    End Function

    Public Function Min(pNum1 As Double, pNum2 As Double, Optional AllowMinus As Boolean = True) As Double
        Dim pMin As Double
        pMin = pNum1
        If pNum1 > pNum2 Then
            pMin = pNum2
        End If
        Min = pMin
        If pMin < 0 And Not AllowMinus Then
            Min = 0
        End If
    End Function

    Private Sub frmuAddItem_ParentChanged(sender As Object, e As EventArgs) Handles Me.ParentChanged
        If ParentForm IsNot Nothing Then
            Me.ParentForm.KeyPreview = True
            'AddHandler ParentForm.KeyUp, AddressOf ParentFormX_KeyUp
            'AddHandler ParentForm.KeyPress, AddressOf ParentFormX_KeyPress
            AddHandler ParentForm.KeyDown, AddressOf ParentFormX_KeyDown
        End If
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        If dbList.Rows.Count > 0 Then
            If Tanya({"Daftar barang yg sudah ada akan hilang", "", "Lanjutkan?"}) Then
                dbList.Rows.Clear()
                ParentForm.Close()
            End If
        Else
            ParentForm.Close()
        End If
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        ParentForm.Close()
    End Sub

    Private Sub chkLockBeli_CheckedChanged(sender As Object, e As EventArgs) Handles chkLockBeli.CheckedChanged
        If pTransMasukKeluar = enMasukKeluar.enmkMasuk Then
            If chkLockBeli.Checked Then
                mbeKode.BackColor = Color.Red
            Else
                mbeKode.BackColor = Color.White
            End If
        End If
    End Sub

    Private Sub chkLockJual_CheckedChanged(sender As Object, e As EventArgs) Handles chkLockJual.CheckedChanged
        If pTransMasukKeluar = enMasukKeluar.enmkKeluar Then
            If chkLockJual.Checked Then
                mbeKode.BackColor = Color.Red
            Else
                mbeKode.BackColor = Color.White
            End If
        End If
    End Sub

    Private Sub mbeKode_EditValueChanged(sender As Object, e As EventArgs) Handles mbeKode.EditValueChanged
        If Len(mbeKode.Text) > 0 Then
            cmdKartuStok.Enabled = True
        Else
            cmdKartuStok.Enabled = False
        End If
    End Sub

    Private Sub cmdKartuStok_Click(sender As Object, e As EventArgs) Handles cmdKartuStok.Click
        'Using ks As New frmuKartuStok
        '    ks.CallMe(mbeKode.Text)
        'End Using
    End Sub

    Private Sub gcList_Click(sender As Object, e As EventArgs) Handles gcList.Click

    End Sub
End Class
