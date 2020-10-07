
Imports meCore

Public Class frmRptUmurStokSupGolDetail
    Dim dbGrafik As New cMeDB
    Public kodesupgol As String = ""

    Private Sub frmRptUmurStokSupGolDetail_Load(sender As Object, e As EventArgs) Handles Me.Load
        'initForm(Me, EnfrmSizeNotMax.efsnm0Default, DevExpress.XtraLayout.MoveFocusDirection.AcrossThenDown)
        'ceQuery.Text = "Supplier"
        'ceTransaksi.Text = "SEMUA"
        ''mbeSupplier.SetProperties(PubConnStr, "SELECT Kode, Nama FROM dbo.mstSupplier ", {"Kode", "Nama"}, _
        ''                {1, 3}, {txtSupplier}, , , , "Kode")

        ''mGolongan.SetProperties(PubConnStr, "SELECT Kode, Keterangan AS Nama FROM dbo.mstGolongan ", {"Kode", "Keterangan"}, _
        ''                        {1, 3}, {txtGolongan}, , , , "Kode")

        ''mbePenerbit.SetProperties(PubConnStr, "SELECT Kode, Nama FROM dbo.mstPenerbit ", {"Kode", "Nama"}, _
        ''        {1, 3}, {txtPenerbit}, , , , "Kode")

        ''.setQueryAlias("a")

        'SpinClearButton({spHariBeli, spHariJual})
        'SpinFormatString({spHariBeli, spHariJual}, "n0")

        'cmbUmurBeli.SelectedIndex = 0
        'cmbUmurJual.SelectedIndex = 0

        filterstock.FilterTahunSaldo = False
        filterstock.setQueryAlias("a")
        LayoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        LayoutControlItem14.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        SetTextReadOnly({ceQuery, filterstock, ceTransaksi, cmbUmurBeli, cmbUmurJual, spHariBeli, spHariJual, spJual})
        'mGolongan.Focus()
        'mGolongan.Select()
        cmbRefreshData.PerformClick()
        cmbRefreshData.Enabled = False
    End Sub

    Private Sub cmbRefreshData_Click(sender As Object, e As EventArgs) Handles cmbRefreshData.Click

        Dim pQueWhereStok As String = IIf(filterstock.Text.Length > 0, " AND " & filterstock.Text, "")

        'pQueWhereStok = IIf(chkSaldo.Checked = False, "a.Saldo <> 0 AND", "")
        'If mbeSupplier.Text.Length > 0 Then pQueWhereStok &= " a.KdSupplier = '" & mbeSupplier.Text & "' AND"
        'If mGolongan.Text.Length > 0 Then pQueWhereStok &= " a.KdGolongan = '" & mGolongan.Text & "' AND"
        'If mbePenerbit.Text.Length > 0 Then pQueWhereStok &= " a.KdPenerbit = '" & mbePenerbit.Text & "' AND"
        'If tJudul.Text.Length > 0 Then pQueWhereStok &= " a.Judul like '%" & tJudul.Text & "%' AND"

        'If pQueWhereStok.Length > 0 Then pQueWhereStok = Mid(pQueWhereStok, 1, pQueWhereStok.Length - 3)

        Dim tglAc As String = DTOC(Now)
        Dim tgJual1 As String = DTOC(Now.AddDays(-1 * spJual.Value))
        Dim tgJual2 As String = DTOC(Now)


        Dim pQue As String
        Dim kode As String = ""
        Dim kode2 As String = ""
        Dim kode3 As String = ""
        Dim grpb As String = ""
        Dim grupby As String = ""
        Dim queryplus As String = ""
        Dim orderby As String = ""
        Dim trans As String = ""
        Dim wheretrans As String = ""
        Dim wheredetail1 As String = ""
        Dim wheredetail2 As String = ""

        Select Case ceQuery.Text
            Case "Supplier"
                kode = "KdSupplier"
                kode2 = "a.KdGolongan,a.NamaGolongan"
                kode3 = "KdGolongan"
                grpb = "a.KdGolongan,b.NamaGolongan"
                queryplus = "a.KdGolongan,a.NamaGolongan,'' as Jenis"
                wheredetail1 = "a.KdSupplier"
                wheredetail2 = "b.KdSupplier"
            Case "Golongan"
                kode = "KdGolongan"
                kode2 = "a.KdSupplier"
                kode3 = "KdSupplier"
                grpb = "b.KdSupplier"
                queryplus = "a.KdSupplier,(select Nama from mstSupplier where Kode=a.KdSupplier) as NamaSupplier,(select case Konsinyasi when '1' then 'Konsinyasi' when '0' then 'Kredit' end from mstSupplier where Kode=a.KdSupplier) as Konsinyasi"
                wheredetail1 = "a.KdGolongan"
                wheredetail2 = "a.KdGolongan"
        End Select

        If Not ceTransaksi.Text = "SEMUA" Then
            grupby += ",Transaksi"
            trans = ",Transaksi"
            wheretrans = "AND Transaksi='" & ceTransaksi.Text & "'"
        End If

        pQue = "IF OBJECT_ID('tempdb..#tmpPersediaan') IS NOT NULL DROP TABLE #tmpPersediaan " & _
                        "Select " & grpb & ",sum(b.Total) as PersediaanSekarang,sum(b.Saldo) as PersediaanSekarangQTY into #tmpPersediaan from tblGetPersediaan('" & tglAc & "') b " & _
                        "left join vwStkSup a on a.kode = b.kode where " & wheredetail2 & "='" & kodesupgol & "' " & pQueWhereStok & " group by " & grpb & "; " & _
                        "CREATE CLUSTERED INDEX ix_tmpPersediaan ON #tmpPersediaan (" & kode3 & "); " & _
                        "IF OBJECT_ID('tempdb..#tmpOmzet') IS NOT NULL DROP TABLE #tmpOmzet " & _
                        "select KdBuku,sum(Qty) as QtyJual,sum(Qty*HPP) as OmzetHPP into #tmpOmzet from tblGetPenjualanNett('" & tgJual1 & "','" & tgJual2 & "') group by KdBuku; " & _
                        "CREATE CLUSTERED INDEX ix_tmpOmzet ON #tmpOmzet (KdBuku); " & _
                        "with " & _
                    "ctevwMstStock AS (" & _
                        "SELECT a.KdBuku, a.KdSupplier,a.NamaSupplier,a.Konsinyasi,a.KdGolongan,a.NamaGolongan,a.HPokok,a.BukuATK," & _
                        "SUM(ISNULL(a.Saldo, 0)) AS Saldo, KdRak, NamaRak, Tahun FROM dbo.vwMstStock a  " & pQueWhereStok & " " & _
                        "GROUP BY a.KdBuku, a.KdSupplier,a.KdSupplier,a.NamaSupplier,a.Konsinyasi,a.KdGolongan,a.NamaGolongan,a.HPokok,a.BukuATK, KdRak, NamaRak," & _
                        "Tahun HAVING SUM(ISNULL(a.Saldo, 0)) > 0 and " & wheredetail1 & "='" & kodesupgol & "')," & _
                "cteBeli " & _
                    "AS (SELECT x.KdBuku, MAX(x.Tanggal) AS TanggalBeli, " & _
                    "CAST(DATEDIFF(DAY,CAST( MAX(x.Tanggal) AS DATETIME),CAST('" & tglAc & "' AS DATETIME))  AS INT) " & _
                    "AS UmurBeli " & _
                    "FROM (SELECT a.KdBuku, MAX(a.Tanggal) AS Tanggal " & _
                    "FROM dbo.trPCDetail a " & _
                    "INNER JOIN ctevwMstStock b ON a.KdBuku=b.KdBuku " & _
                    "GROUP BY a.KdBuku " & _
                    "UNION ALL " & _
                    "SELECT a.KdBuku, MAX(a.Tanggal) AS Tanggal " & _
                    "FROM dbo.trKonsDetail a " & _
                    "INNER JOIN ctevwMstStock b ON a.KdBuku=b.KdBuku " & _
                    "GROUP BY a.KdBuku " & _
                    "UNION ALL " & _
                    "SELECT KdBuku,MAX(Tanggal) AS Tanggal FROM dbo.trSTKGudAwal  " & _
                    "GROUP BY KdBuku " & _
                    ") x " & _
                    "GROUP BY  x.KdBuku), " & _
                "cteJualU1 " & _
                    "AS ( SELECT KdBuku, SUM(Qty) AS QtyJualU1, " & _
                    "SUM(Jumlah) AS JumlahJualU1, " & _
                    "SUM(Qty*HPP) AS JumlahHppJualU1 " & _
                    "FROM dbo.tblGetPenjualanNett('" & tgJual1 & "', '" & tgJual2 & "') where JENIS = 'KASIR' " & _
                    "GROUP BY KdBuku), " & _
                "cteJual " & _
                    "AS ( SELECT a.KdBuku, MAX(a.Tanggal) AS TanggalJual, " & _
                    "DATEDIFF(DAY, MAX(a.Tanggal), CAST('" & tglAc & "' AS DATETIME) )  AS UmurTidakJual " & _
                    "FROM dbo.trCSDetail a " & _
                    "INNER JOIN ctevwMstStock b ON a.KdBuku=b.KdBuku " & _
                    "WHERE a.FlagRetur=0 " & _
                    "GROUP BY a.KdBuku), " & _
                "cteStock AS (" & _
                    "select a.KdBuku,a.KdSupplier, a.NamaSupplier,a.Konsinyasi,a.KdGolongan,a.NamaGolongan," & _
                    "a.BukuATK, c.TanggalBeli, c.UmurBeli, d.TanggalJual," & _
                    "isnull(d.UmurTidakJual, 999999) as UmurTidakJual,isnull(f.QtyJualU1, 0) as QtyJual," & _
                    "a.KdRak, a.NamaRak, a.Tahun,e.OmzetHPP," & _
                    "isnull((select SUM(hpokok * Saldo)/ SUM(Saldo) from mststksup where kdbuku = a.KdBuku and saldo > 0),0) * a.Saldo as PersediaanSesuaiUmur," & _
                    "a.Saldo as PersediaanSesuaiUmurQTY " & _
                    "from ctevwMstStock a " & _
                    "left join cteBeli c on a.KdBuku=c.KdBuku " & _
                    "left join cteJual d on a.KdBuku=d.KdBuku " & _
                    "LEFT JOIN cteJualU1 f ON a.KdBuku=f.KdBuku " & _
                    "left join #tmpOmzet e on a.KdBuku=e.KdBuku " & _
                    "WHERE ((isnull(c.UmurBeli,0)>=" & spHariBeli.EditValue.ToString & " AND '" & cmbUmurBeli.Text & "'='>=' ) OR (isnull(c.UmurBeli,0) <=" & spHariBeli.EditValue.ToString & " AND '" & cmbUmurBeli.Text & "'='<=' )) AND " & _
                    "((isnull(d.UmurTidakJual,999999)>=" & spHariJual.EditValue.ToString & " AND '" & cmbUmurJual.Text & "'='>=' ) OR ( isnull(d.UmurTidakJual,999999) <=" & spHariJual.EditValue.ToString & " AND '" & cmbUmurJual.Text & "'='<=' ) and " & wheredetail1 & "='" & kodesupgol & "')" & wheretrans & "), " & _
                "cte2 AS(" & _
                    "select " & kode2 & "," & _
                    "sum(a.QtyJual) as QtyJual,sum(a.OmzetHPP) as OmzetHPP,sum(a.persediaansesuaiumur) as PersediaanSesuaiUmur," & _
                    "sum(a.PersediaanSesuaiUmurQTY) as PersediaanSesuaiUmurQTY " & _
                    "from cteStock a " & _
                    "left join #tmpPersediaan b " & _
                    "on b." & kode3 & "=a." & kode3 & " " & _
                    "group by " & kode2 & ") " & _
                "select " & queryplus & " " & _
                ",b.PersediaanSesuaiUmur,a.PersediaanSekarang,(b.PersediaanSesuaiUmur/nullif(a.PersediaanSekarang,0))*100 as [PersenthdNilaiPersediaan %]," & _
                "b.OmzetHPP,b.PersediaanSesuaiUmurQTY,a.PersediaanSekarangQTY," & _
                "(b.PersediaanSesuaiUmurQTY/nullif(a.PersediaanSekarangQTY,0))*100 as [PersenthdNilaiPersediaanQTY %],b.QtyJual " & _
                "from #tmpPersediaan a " & _
                "left join cte2 b " & _
                "on a." & kode3 & "=b." & kode3 & " " & _
                "order by b.PersediaanSesuaiUmur desc"
        If Not ceTransaksi.Text = "SEMUA" Then
            mdgList.FirstInit(pQue, {0.1, 2, 0.3, 1.5, 1.5, 0.5, 0.8, 1.5, 1.5, 0.5, 0.8}, _
                              , , , , , True, 2, True)
        Else
            mdgList.FirstInit(pQue, {0.8, 2, 0.8, 1.5, 1.5, 0.8, 1, 1, 1, 0.9, 0.8}, _
                              {"PersediaanSekarang", "PersediaanSesuaiUmur", "QtyJual", "Omzet", "OmzetHPP", "PersediaanSesuaiUmurQTY", "PersediaanSekarangQTY", "PersenthdNilaiPersediaan %", "PersenthdNilaiPersediaanQTY %"}, , , , 65, False, 2, True)
        End If

        filterstock.Enabled = False
        cmbRefreshData.Enabled = False
        lcgF.Enabled = False
        mdgList.dSourceUsePK = False
        mdgList.RefreshData()
    End Sub

    Private Sub mdgList_Grid_CustomDrawFooterCell(sender As Object, e As DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs) Handles mdgList.Grid_CustomDrawFooterCell
        Dim gv As DevExpress.XtraGrid.Views.Grid.GridView = sender

        Select Case e.Column.FieldName
            Case "PersenthdNilaiPersediaan %"
                Dim a As Double = 0
                If gv.Columns("PersediaanSesuaiUmur").SummaryText = "" Then
                    a = 0
                Else
                    a = gv.Columns("PersediaanSesuaiUmur").SummaryText
                End If

                Dim b As Double = 0
                If gv.Columns("PersediaanSekarang").SummaryText = "" Then
                    b = 0
                Else
                    b = gv.Columns("PersediaanSekarang").SummaryText
                End If

                Dim aa As Double = 0
                If b = 0 Then
                    aa = CDbl(a) * 100 / Math.Abs(a)
                Else
                    aa = CDbl(a) * 100 / meDBNullnum(b)
                End If
                e.Info.DisplayText = FormatNumber(aa, 2)

            Case "PersenthdNilaiPersediaanQTY %"
                Dim a As Double = 0
                If gv.Columns("PersediaanSesuaiUmurQTY").SummaryText = "" Then
                    a = 0
                Else
                    a = gv.Columns("PersediaanSesuaiUmurQTY").SummaryText
                End If

                Dim b As Double = 0
                If gv.Columns("PersediaanSekarangQTY").SummaryText = "" Then
                    b = 0
                Else
                    b = gv.Columns("PersediaanSekarangQTY").SummaryText
                End If

                Dim aa As Double = 0
                If b = 0 Then
                    aa = CDbl(a) * 100 / Math.Abs(a)
                Else
                    aa = CDbl(a) * 100 / meDBNullnum(b)
                End If
                e.Info.DisplayText = FormatNumber(aa, 2)

        End Select
    End Sub

    Private Sub mdgList_Grid_DoubleClick(sender As Object, e As EventArgs) Handles mdgList.Grid_DoubleClick
        'Dim pformprnt As Form = Me
        'pformprnt.Name = "frmMainTab"
        'If Me.ParentForm IsNot Nothing Then pformprnt = Me.ParentForm
        'If pformprnt.Name = "frmMainTab" Then
        '    If mdgList.GetRowCount_Gridview > 0 Then
        '        Using xx As New frmRptUmurStokSupGol
        '            'xx.pTgl1 = d1.EditValue
        '            'xx.pTgl1 = d1.EditValue
        '            'xx.pTgl2 = d2.EditValue
        '            'xx.pTrans = cTrans.Text
        '            'xx.pBukuATK = cBukuAtk.Text
        '            'xx.pJenis = cJenis.Text
        '            'xx.pQuery = IIf(cQuery.Text = "SUPPLIER", "GOLONGAN", "SUPPLIER")
        '            'xx.pFilter = mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Kode")
        '            xx.ShowDialog(pformprnt)
        '        End Using
        '    End If
        'End If
    End Sub

    Sub RefreshGrafik(pKode As String)
        'Dim pQue As String = _
        '    "WITH cteSource AS ( " & _
        '    "		SELECT keterangan ,kode ,tanggal ,qty from dbo.vwKartuArusStockRow where kode IN (SELECT Kode FROM dbo.mstStkSup WHERE KdBuku = '" & pKode & "')  " & _
        '    "		), " & _
        '    "	cteThn AS (   " & _
        '    "		SELECT MIN(tanggal) AS Thn from cteSource " & _
        '    "		UNION ALL   " & _
        '    "		SELECT DATEADD(MONTH,1,Thn) FROM cteThn  WHERE CONVERT(VARCHAR(6),Thn,112) < CONVERT(VARCHAR(6),GETDATE(),112)  ),   " & _
        '    "	cteJenis AS (SELECT DISTINCT keterangan FROM cteSource),	 " & _
        '    "	cteAwal AS ( " & _
        '    "		SELECT CONVERT(varchar(6),a.Thn,112) as Tanggal,  " & _
        '    "				ISNULL((SELECT SUM(qty) FROM cteSource WHERE keterangan = 'PC' AND CONVERT(varchar(6),tanggal,112) < CONVERT(varchar(6),a.Thn,112) ),0)  " & _
        '    "				+ ISNULL((SELECT SUM(qty) FROM cteSource WHERE keterangan = 'TK' AND CONVERT(varchar(6),tanggal,112) < CONVERT(varchar(6),a.Thn,112) ),0) " & _
        '    "				- ISNULL((SELECT SUM(qty) FROM cteSource WHERE keterangan = 'CS' AND CONVERT(varchar(6),tanggal,112) < CONVERT(varchar(6),a.Thn,112) ),0)  " & _
        '    "				- ISNULL((SELECT SUM(qty) FROM cteSource WHERE keterangan = 'BO' AND CONVERT(varchar(6),tanggal,112) < CONVERT(varchar(6),a.Thn,112) ),0)  " & _
        '    "				- ISNULL((SELECT SUM(qty) FROM cteSource WHERE keterangan = 'RB' AND CONVERT(varchar(6),tanggal,112) < CONVERT(varchar(6),a.Thn,112) ),0)  " & _
        '    "				- ISNULL((SELECT SUM(qty) FROM cteSource WHERE keterangan = 'KK' AND CONVERT(varchar(6),tanggal,112) < CONVERT(varchar(6),a.Thn,112) ),0) AS QtyAwal " & _
        '    "		FROM ctethn a WHERE thn IS NOT NULL), " & _
        '    "	cteGabung as (select a.Keterangan, CONVERT(varchar(6),a.Thn,112) as Tanggal, '" & pKode & "' AS Kode, SUM(Qty) AS Qty       " & _
        '    "				FROM (SELECT a1.Thn, a2.keterangan FROM ctethn a1 CROSS JOIN cteJenis a2) a   " & _
        '    "				LEFT JOIN cteSource b ON convert(varchar(6),a.Thn,112) = convert(varchar(6),b.tanggal,112) AND a.keterangan = b.keterangan  " & _
        '    "				GROUP by a.Keterangan, b.Kode, CONVERT(varchar(6),a.Thn,112) " & _
        '    "	 			UNION ALL " & _
        '    "				SELECT 'AWAL' AS Keterangan, tanggal, '" & pKode & "' AS Kode, Qtyawal FROM cteawal " & _
        '    "           ) " & _
        '    "SELECT Kode, a.keterangan, SUBSTRING(Tanggal,3,2) + '-' + SUBSTRING(Tanggal,5,2) as Tanggal , ISNULL(a.Qty,0) AS Qty FROM cteGabung a ORDER BY a.Tanggal, a.keterangan DESC " & _
        '    "OPTION (MAXrecursion 0)"


        Dim pQue As String = _
            "WITH cteSource AS ( " & _
            "		SELECT keterangan ,kode ,tanggal ,qty from dbo.vwKartuArusStockRow where kode IN (SELECT Kode FROM dbo.mstStkSup WHERE KdBuku = '" & pKode & "') " & _
            "		), " & _
            "	cteThn AS (   " & _
            "		SELECT MIN(tanggal) AS Thn from cteSource " & _
            "		UNION ALL   " & _
            "		SELECT DATEADD(MONTH,1,Thn) FROM cteThn  WHERE CONVERT(VARCHAR(6),Thn,112) < CONVERT(VARCHAR(6),GETDATE(),112)  ),   " & _
            "	cteJenis AS (SELECT DISTINCT keterangan FROM cteSource),	 " & _
            "	cteTrans as (select a.Keterangan, CONVERT(varchar(6),a.Thn,112) as Tanggal, '" & pKode & "' AS Kode, SUM(Qty) AS Qty       " & _
            "				FROM (SELECT a1.Thn, a2.keterangan FROM ctethn a1 CROSS JOIN cteJenis a2) a   " & _
            "				LEFT JOIN cteSource b ON convert(varchar(6),a.Thn,112) = convert(varchar(6),b.tanggal,112) AND a.keterangan = b.keterangan  " & _
            "				GROUP by a.Keterangan, b.Kode, CONVERT(varchar(6),a.Thn,112) " & _
            "           ), " & _
            "   cteAwal AS ( " & _
            "			SELECT 'AWAL' AS Keterangan, CONVERT(varchar(6),Thn,112) as Tanggal, '" & pKode & "' AS Kode, " & _
            "				ISNULL((SELECT SUM(CASE WHEN keterangan IN ('PC','TK', 'CB', 'RJ', 'RK  ') THEN 1 ELSE -1 END * qty)  FROM cteTrans WHERE tanggal < CONVERT(varchar(6),a.Thn,112)),0) AS Qty " & _
            "			FROM cteThn a " & _
            "           ), " & _
            "	cteGabung AS ( " & _
            "			SELECT Keterangan, Tanggal, Kode, qty FROM cteTrans " & _
            "			UNION ALL " & _
            "           SELECT Keterangan, Tanggal, Kode, qty FROM cteAwal " & _
            "           ), " & _
            "   ctesum as ( " & _
            "           SELECT a.keterangan, Tanggal, sum(ISNULL(a.Qty,0)) AS Qty FROM cteGabung a Group by a.Tanggal, a.keterangan " & _
            "           ) " & _
            "SELECT a.keterangan, SUBSTRING(Tanggal,3,2) + '-' + SUBSTRING(Tanggal,5,2) as Tanggal , ISNULL(a.Qty,0) AS Qty FROM ctesum a ORDER BY a.Tanggal, a.keterangan DESC " & _
            "OPTION (MAXrecursion 0)"

        dbGrafik.FillMe(pQue, , , , 0)
        '--hapus yang tahun blnnya kosong
        Dim tgl = From row In dbGrafik.AsEnumerable()
            Select row.Field(Of String)("Tanggal") Distinct

        Dim th() As String = tgl.ToArray()

        For i As Integer = th.Length - 1 To 0 Step -1
            Dim dro() As DataRow = dbGrafik.Select("Tanggal = '" & th(i) & "' and Qty > 0 and keterangan <> 'AWAL'")
            If dro.Length > 0 Then
                Exit For
            Else
                dro = dbGrafik.Select("Tanggal = '" & th(i) & "' ")
                For j As Integer = dro.Length - 1 To 0 Step -1
                    dro(j).Delete()
                Next
            End If
        Next

        chart.DataSource = dbGrafik
        chart.SeriesDataMember = "keterangan"
        chart.SeriesTemplate.ArgumentDataMember = "Tanggal"
        chart.SeriesTemplate.ValueDataMembers.AddRange(New String() {"Qty"})
    End Sub

    Private Sub chart_DoubleClick(sender As Object, e As EventArgs) Handles chart.DoubleClick
        frmGrafikBig.callMe(dbGrafik, "keterangan", "Tanggal", "Qty")
    End Sub

    Private Sub chart_CustomDrawSeriesPoint(sender As Object, e As DevExpress.XtraCharts.CustomDrawSeriesPointEventArgs) Handles chart.CustomDrawSeriesPoint
        If e.SeriesPoint(0) < 1 Then
            e.LabelText = ""
        End If
    End Sub

    Private Sub chart_CustomDrawSeries(sender As Object, e As DevExpress.XtraCharts.CustomDrawSeriesEventArgs) Handles chart.CustomDrawSeries
        e.SeriesDrawOptions.Color = GetTransactionColor(e.Series.Name)
        e.LegendDrawOptions.Color = e.SeriesDrawOptions.Color
    End Sub

    Private Sub mdgList_Grid_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles mdgList.Grid_FocusedRowChanged
        RefreshGrafik(mdgList.GetRowCellValue(e.FocusedRowHandle, "KdBuku"))
    End Sub

    Private Sub mdgList_OnPopRefreshClickEnd() Handles mdgList.OnPopRefreshClickEnd
        'filterstock.Enabled = True
        'cmbRefreshData.Enabled = True
        lcgF.Enabled = True
    End Sub

    Private Sub ceQuery_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ceQuery.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub ceTransaksi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ceTransaksi.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub mdgList_Load(sender As Object, e As EventArgs) Handles mdgList.Load

    End Sub
End Class