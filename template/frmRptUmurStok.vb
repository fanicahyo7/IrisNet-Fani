
Imports meCore

Public Class frmRptUmurStok
    Dim dbGrafik As New cMeDB

    Private Sub frmRptUmurStok_Load(sender As Object, e As EventArgs) Handles Me.Load
        initForm(Me, EnfrmSizeNotMax.efsnm0Default, DevExpress.XtraLayout.MoveFocusDirection.AcrossThenDown)

        'mbeSupplier.SetProperties(PubConnStr, "SELECT Kode, Nama FROM dbo.mstSupplier ", {"Kode", "Nama"}, _
        '                {1, 3}, {txtSupplier}, , , , "Kode")

        'mGolongan.SetProperties(PubConnStr, "SELECT Kode, Keterangan AS Nama FROM dbo.mstGolongan ", {"Kode", "Keterangan"}, _
        '                        {1, 3}, {txtGolongan}, , , , "Kode")

        'mbePenerbit.SetProperties(PubConnStr, "SELECT Kode, Nama FROM dbo.mstPenerbit ", {"Kode", "Nama"}, _
        '        {1, 3}, {txtPenerbit}, , , , "Kode")

        filterstock.setQueryAlias("a")

        SpinClearButton({spHariBeli, spHariJual})
        SpinFormatString({spHariBeli, spHariJual}, "n0")

        cmbUmurBeli.SelectedIndex = 0
        cmbUmurJual.SelectedIndex = 0


        'mGolongan.Focus()
        'mGolongan.Select()
    End Sub

    Private Sub cmbRefreshData_Click(sender As Object, e As EventArgs) Handles cmbRefreshData.Click

        Dim pQueWhereStok As String = IIf(filterstock.Text.Length > 0, " WHERE " & filterstock.Text, "")

        'pQueWhereStok = IIf(chkSaldo.Checked = False, "a.Saldo <> 0 AND", "")
        'If mbeSupplier.Text.Length > 0 Then pQueWhereStok &= " a.KdSupplier = '" & mbeSupplier.Text & "' AND"
        'If mGolongan.Text.Length > 0 Then pQueWhereStok &= " a.KdGolongan = '" & mGolongan.Text & "' AND"
        'If mbePenerbit.Text.Length > 0 Then pQueWhereStok &= " a.KdPenerbit = '" & mbePenerbit.Text & "' AND"
        'If tJudul.Text.Length > 0 Then pQueWhereStok &= " a.Judul like '%" & tJudul.Text & "%' AND"

        'If pQueWhereStok.Length > 0 Then pQueWhereStok = Mid(pQueWhereStok, 1, pQueWhereStok.Length - 3)

        Dim tglAc As String = DTOC(dTglAcuan.EditValue)
        Dim tgJual1 As String = DTOC(Now.AddDays(-1 * spJual.Value))
        Dim tgJual2 As String = DTOC(Now)

        Dim pQue As String = _
            "WITH    cteStock " & _
            "          AS ( SELECT   a.KdBuku, a.Judul, a.Penyusun, a.NamaPenerbit, " & _
            "        a.NamaGolongan, a.BukuATK, (HJual * (100 - Disc1)/100) as HargaNett, " & _
            "                        SUM(ISNULL(a.Saldo, 0)) AS Saldo " & _
            "               FROM     dbo.vwMstStock a " & _
            "        " & pQueWhereStok & " " & _
            "               GROUP BY a.KdBuku, a.Judul, (HJual * (100 - Disc1)/100), a.Penyusun, a.NamaPenerbit, " & _
            "                        a.KdGolongan, a.NamaGolongan, a.BukuATK " & _
            "               HAVING SUM(ISNULL(a.Saldo, 0)) > 0 ), " & _
            "        cteBeli " & _
            "          AS ( SELECT   x.KdBuku, MAX(x.Tanggal) AS TanggalBeli, " & _
            "                        ISNULL(CAST(CAST('" & tglAc & "'AS DATETIME)-MAX(x.Tanggal) AS INT), 0) AS UmurBeli " & _
            "               FROM     ( SELECT    a.KdBuku, MAX(a.Tanggal) AS Tanggal " & _
            "                          FROM      dbo.trPCDetail a " & _
            "                          INNER JOIN cteStock b ON a.KdBuku=b.KdBuku " & _
            "                          GROUP BY  a.KdBuku " & _
            "        UNION ALL " & _
            "                          SELECT    a.KdBuku, MAX(a.Tanggal) AS Tanggal " & _
            "                          FROM      dbo.trKonsDetail a " & _
            "                          INNER JOIN cteStock b ON a.KdBuku=b.KdBuku " & _
            "                          GROUP BY  a.KdBuku ) x " & _
            "               GROUP BY x.KdBuku), " & _
            "        cteJualU1 " & _
            "        AS ( SELECT   KdBuku, SUM(Qty) AS QtyJualU1, " & _
            "                       SUM(Jumlah) AS JumlahJualU1, " & _
            "                       SUM(Qty*HPP) AS JumlahHppJualU1 " & _
            "               FROM dbo.tblGetPenjualanNett('" & tgJual1 & "', '" & tgJual2 & "') " & _
            "               GROUP BY KdBuku), " & _
            "        cteJual " & _
            "          AS ( SELECT   a.KdBuku, MAX(a.Tanggal) AS TanggalJual, " & _
            "                        ISNULL(CAST(CAST('" & tglAc & "'AS DATETIME)-MAX(a.Tanggal) AS INT), 0) AS UmurTidakJual " & _
            "               FROM     dbo.trCSDetail a " & _
            "               INNER JOIN cteStock b ON a.KdBuku=b.KdBuku " & _
            "               WHERE    a.FlagRetur=0 " & _
            "               GROUP BY a.KdBuku) " & _
            "     SELECT a.KdBuku, a.Judul, a.HargaNett, a.Penyusun, a.NamaPenerbit, a.NamaGolongan, " & _
            "            a.BukuATK, a.Saldo, b.TanggalBeli, b.UmurBeli, c.TanggalJual, " & _
            "            c.UmurTidakJual, " & _
            "            (select avg(hpokok) from mststksup where kdbuku = a.KdBuku) as HppAvg, " & _
            "            isnull((select avg(hpokok) from mststksup where kdbuku = a.KdBuku),0) * a.Saldo as JmlHppAvg, " & _
            "            isnull(d.QtyJualU1, 0) as QtyJual " & _
            "     FROM   cteStock a " & _
            "     LEFT JOIN cteBeli b ON a.KdBuku=b.KdBuku " & _
            "     LEFT JOIN cteJual c ON a.KdBuku=c.KdBuku " & _
            "     LEFT JOIN cteJualU1 d ON a.KdBuku=d.KdBuku " & _
            "     WHERE  ( ( isnull(b.UmurBeli,0)>=" & spHariBeli.EditValue.ToString & " AND '" & cmbUmurBeli.Text & "'='>=' ) OR ( isnull(b.UmurBeli,0) <=" & spHariBeli.EditValue.ToString & " AND '" & cmbUmurBeli.Text & "'='<=' ) ) AND " & _
            "           ( ( isnull(c.UmurTidakJual,0)>=" & spHariJual.EditValue.ToString & " AND '" & cmbUmurJual.Text & "'='>=' ) OR ( isnull(c.UmurTidakJual,0) <=" & spHariJual.EditValue.ToString & " AND '" & cmbUmurJual.Text & "'='<=' ) ) " & _
            "     ORDER BY b.UmurBeli DESC "


        pQue = _
            "WITH    cteStock " & _
            "          AS ( SELECT   a.KdBuku, a.Judul, a.Penyusun, a.NamaPenerbit, " & _
            "        a.NamaGolongan, a.BukuATK, (HJual * (100 - Disc1)/100) as HargaNett, " & _
            "                        SUM(ISNULL(a.Saldo, 0)) AS Saldo, KdRak, NamaRak, Tahun " & _
            "               FROM     dbo.vwMstStock a " & _
            "        " & pQueWhereStok & " " & _
            "               GROUP BY a.KdBuku, a.Judul, (HJual * (100 - Disc1)/100), a.Penyusun, a.NamaPenerbit, " & _
            "                        a.KdGolongan, a.NamaGolongan, a.BukuATK, KdRak, NamaRak, Tahun " & _
            "               HAVING SUM(ISNULL(a.Saldo, 0)) > 0 ), " & _
            "       cteBeli " & _
            "          AS (SELECT    x.KdBuku, MAX(x.Tanggal) AS TanggalBeli, " & _
            "                        CAST(DATEDIFF(DAY,CAST( MAX(x.Tanggal) AS DATETIME),CAST('" & tglAc & "' AS DATETIME))  AS INT) " & _
            "                       AS UmurBeli " & _
            "              FROM      (SELECT a.KdBuku, MAX(a.Tanggal) AS Tanggal " & _
            "                         FROM   dbo.trPCDetail a " & _
            "                         INNER JOIN cteStock b ON a.KdBuku=b.KdBuku " & _
            "                         GROUP BY a.KdBuku " & _
            "                           UNION ALL " & _
            "                         SELECT a.KdBuku, MAX(a.Tanggal) AS Tanggal " & _
            "                         FROM   dbo.trKonsDetail a " & _
            "                         INNER JOIN cteStock b ON a.KdBuku=b.KdBuku " & _
            "                         GROUP BY a.KdBuku " & _
            "                         UNION ALL " & _
            "                         SELECT KdBuku,MAX(Tanggal) AS Tanggal FROM dbo.trSTKGudAwal  " & _
            "                         GROUP BY KdBuku " & _
            "                         ) x " & _
            "              GROUP BY  x.KdBuku), " & _
            "        cteJualU1 " & _
            "        AS ( SELECT   KdBuku, SUM(Qty) AS QtyJualU1, " & _
            "                       SUM(Jumlah) AS JumlahJualU1, " & _
            "                       SUM(Qty*HPP) AS JumlahHppJualU1 " & _
            "               FROM dbo.tblGetPenjualanNett('" & tgJual1 & "', '" & tgJual2 & "') where JENIS = 'KASIR' " & _
            "               GROUP BY KdBuku), " & _
            "        cteJual " & _
            "          AS ( SELECT   a.KdBuku, MAX(a.Tanggal) AS TanggalJual, " & _
            "                        DATEDIFF(DAY, MAX(a.Tanggal), CAST('" & tglAc & "' AS DATETIME) )  AS UmurTidakJual " & _
            "               FROM     dbo.trCSDetail a " & _
            "               INNER JOIN cteStock b ON a.KdBuku=b.KdBuku " & _
            "               WHERE    a.FlagRetur=0 " & _
            "               GROUP BY a.KdBuku) " & _
            "     SELECT a.KdBuku, a.Judul, a.HargaNett, a.Penyusun, a.NamaPenerbit, a.NamaGolongan, " & _
            "            a.BukuATK, a.Saldo, b.TanggalBeli, b.UmurBeli, c.TanggalJual, " & _
            "            isnull(c.UmurTidakJual, 999999) as UmurTidakJual, " & _
            "            (select SUM(hpokok * Saldo)/ SUM(Saldo) from mststksup where kdbuku = a.KdBuku and saldo > 0) as HppAvg, " & _
            "            isnull((select SUM(hpokok * Saldo)/ SUM(Saldo) from mststksup where kdbuku = a.KdBuku and saldo > 0),0) * a.Saldo as JmlHppAvg, " & _
            "            isnull(d.QtyJualU1, 0) as QtyJual, a.KdRak, a.NamaRak, a.Tahun " & _
            "     FROM   cteStock a " & _
            "     LEFT JOIN cteBeli b ON a.KdBuku=b.KdBuku " & _
            "     LEFT JOIN cteJual c ON a.KdBuku=c.KdBuku " & _
            "     LEFT JOIN cteJualU1 d ON a.KdBuku=d.KdBuku " & _
            "     WHERE  ( ( isnull(b.UmurBeli,0)>=" & spHariBeli.EditValue.ToString & " AND '" & cmbUmurBeli.Text & "'='>=' ) OR ( isnull(b.UmurBeli,0) <=" & spHariBeli.EditValue.ToString & " AND '" & cmbUmurBeli.Text & "'='<=' ) ) AND " & _
            "           ( ( isnull(c.UmurTidakJual,999999)>=" & spHariJual.EditValue.ToString & " AND '" & cmbUmurJual.Text & "'='>=' ) OR ( isnull(c.UmurTidakJual,999999) <=" & spHariJual.EditValue.ToString & " AND '" & cmbUmurJual.Text & "'='<=' ) ) " & _
            "     ORDER BY b.UmurBeli DESC "


        mdgList.FirstInit(pQue, {0.8, 2, 1, 1.5, 1.5, 1.5, 0.5, 0.8, 0.8, 0.8, 0.8, 0.7, 1, 1.1, 0.7, 0.7, 1.5, 0.7}, _
                          {"HppAvg", "Saldo", "JmlHppAvg", "QtyJual"}, , , , 40, False, , True)

        filterstock.Enabled = False
        cmbRefreshData.Enabled = False
        lcgF.Enabled = False
        mdgList.RefreshData()
    End Sub

    Private Sub mdgList_Grid_DoubleClick(sender As Object, e As EventArgs) Handles mdgList.Grid_DoubleClick
        'If mdgList.GetRowCount_Gridview > 0 Then
        '    Using ks As New frmuKartuStok
        '        ks.CallMe(mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Kode"))
        '    End Using
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
        filterstock.Enabled = True
        cmbRefreshData.Enabled = True
        lcgF.Enabled = True
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

    End Sub

    Private Sub filterstock_Load(sender As Object, e As EventArgs) Handles filterstock.Load

    End Sub

    Private Sub mdgList_Load(sender As Object, e As EventArgs) Handles mdgList.Load

    End Sub
End Class