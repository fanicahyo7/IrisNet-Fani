Imports meCore
Imports System.Data.SqlClient
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports DevExpress.Printing.ExportHelpers
Imports DevExpress.Export
Imports DevExpress.Export.Xl

Public Class frmLapNPM
    Dim datatabel As New DataTable
    Private Sub frmLapNPM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

        dPeriode.Properties.DisplayFormat.FormatString = "yyyy MMMM"
        dPeriode.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        dPeriode.Properties.EditMask = "yyyy MMMM"
        dPeriode.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView
        dPeriode.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView

        dPeriode.EditValue = Now
    End Sub

    Private Sub cJenis_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cJenis.SelectedIndexChanged
        Dim lokasi As String = ""
        If cJenis.Text = "UE" Then
            lokasi = "10.10.2.2\bukbes"
        ElseIf cJenis.Text = "UM" Then
            lokasi = "10.10.2.13\bukbes"
        End If

        tJenis.Text = "Data Source=" & lokasi & ";Initial Catalog=BukbesAcc;Persist Security Info=True;User ID=sa;Password=pancetgogogo;Connection Timeout=0"

        koneksi(tJenis.Text)
        'cKdCompany.FirstInit(tJenis.Text, "Select KodeCompany,Nama from tbGNCompany", {tNama}, , , , , , {0.5, 1})
        Dim qucompany As String = "Select 0 as cek,KodeCompany,Nama from tbGNCompany"
        da = New SqlDataAdapter(qucompany, kon)
        datatabel.Clear()
        da.Fill(datatabel)

        cCompany.Items.Clear()
        Dim dtTablename As DataTable = datatabel.DefaultView.ToTable(True, {"cek", "KodeCompany", "Nama"})
        For i As Integer = 0 To dtTablename.Rows.Count - 1
            Dim kode As String = dtTablename.Rows(i)!KodeCompany & " - " & dtTablename.Rows(i)!Nama
            cCompany.Items.Add(kode)
        Next
    End Sub

    Private Sub btnAmbilData_Click(sender As Object, e As EventArgs) Handles btnAmbilData.Click
        Dim drow() As DataRow = datatabel.Select("cek='1'")
        Dim aa As Integer = drow.Length
        If cJenis.Text = "" Then
            MsgBox("Pilih Jenis Terlebih Dahulu!", vbCritical + vbOKOnly, "Peringatan")
        ElseIf aa < 1 Then
            MsgBox("Pilih Kode Company Terlebih Dahulu!", vbCritical + vbOKOnly, "Peringatan")
        Else
            GridView1.Columns.Clear()
            Dim ds As New DataSet
            Dim dt1 As New DataTable
            Dim dt2 As New DataTable
            'Dim kdcompany As String = cKdCompany.Text
            Dim kdcompany As String = ""
            For j = 0 To aa - 1
                If j = aa - 1 Then
                    kdcompany += "'" & drow(j)!KodeCompany & "'"
                Else
                    kdcompany += "'" & drow(j)!KodeCompany & "',"
                End If
            Next
            Dim periode As String = Format(dPeriode.EditValue, "yyyyMM")
            Dim query As String = _
            "DECLARE @tahunbulan AS VARCHAR(6) " & _
            "SET @tahunbulan='" & periode & "'; " & _
            "WITH cteLR AS " & _
            "(" & _
                "SELECT " & _
                "CONVERT(VARCHAR(6),a.TanggalBukti,112) as TahunBulan,a.KodeCompany," & _
                "a.KodeAkun,b.Keterangan,SUM(CASE WHEN a.DebetOrKredit<>b.DebetOrKredit THEN -a.Jumlah ELSE a.Jumlah END) AS Jumlah," & _
                "b.DebetOrKredit AS DoK " & _
                "FROM dbo.tbACJurnal a " & _
                "LEFT JOIN dbo.tbACKodeAkun b ON b.KodeAkun=a.KodeAkun " & _
                "WHERE " & _
                "CONVERT(VARCHAR(6),a.TanggalBukti,112)=@tahunbulan AND " & _
                "a.KodeCompany in (" & kdcompany & ") " & _
                "AND b.IdKategori IN (SELECT IdKategori FROM dbo.tbACKategori WHERE StatusLaporan='LR') " & _
                "GROUP BY " & _
                "CONVERT(VARCHAR(6),a.TanggalBukti,112)," & _
                "a.KodeCompany," & _
                "a.KodeAkun, b.Keterangan, b.DebetOrKredit" & _
            "), " & _
            "ctepvot as(" & _
                "SELECT " & _
                    "aa.TahunBulan, aa.KODECOMPANY,dd.Aliasing, aa.KODEAKUN, aa.KETERANGAN,  aa.DOK, " & _
                    "aa.Jumlah AS JumlahNPM, dd.grup " & _
                    "FROM cteLR AS aa " & _
                    "LEFT JOIN dbo.tbACKodeAkun cc ON aa.KodeAkun=cc.KodeAkun " & _
                    "LEFT JOIN dbo.tbACKategoriNPM dd ON cc.KodeAkun=dd.KodeAkun " & _
                    "WHERE NOT aa.KodeAkun IN " & _
                        "(aa.kodecompany+'.90.20.210'," & _
                        "aa.kodecompany+'.90.20.971'," & _
                        "aa.kodecompany+'.90.20.972'," & _
                        "aa.kodecompany+'.90.20.973'," & _
                        "aa.kodecompany+'.90.20.974'," & _
                        "aa.kodecompany+'.90.10.610'," & _
                        "aa.kodecompany+'.90.10.620'," & _
                        "aa.kodecompany+'.90.10.630'" & _
                        ")" & _
            "), " & _
            "ctegabung as(" & _
                "select Aliasing, sum(JumlahNPM) as Jumlah,Grup from ctepvot group by Aliasing,Grup " & _
                "union all " & _
                "select 'PENDAPATAN BERSIH' as Aliasing, (select sum(x.JumlahNPM) from ctepvot x group by grup having Grup='1.0') - (select sum(x.JumlahNPM) from ctepvot x group by grup having Grup='2.0') as Jumlah,2.1 as Grup " & _
                "union all " & _
                "select 'TOTAL HPP BARANG DAGANG' as Aliasing, sum(JumlahNPM) as Jumlah, 3.1 as Grup from ctepvot group by grup having Grup='3.0' " & _
                "union all " & _
                "select 'LABA-RUGI KOTOR' as Aliasing," & _
                "((select sum(x.JumlahNPM) from ctepvot x group by grup having Grup='1.0') - (select sum(x.JumlahNPM) from ctepvot x group by grup having Grup='2.0')) - (select sum(JumlahNPM) from ctepvot group by grup having Grup='3.0') as Jumlah,3.2 as Grup " & _
                "union all " & _
                "select 'TOTAL BEBAN USAHA' as Aliasing, sum(JumlahNPM) as Jumlah, 4.1 as Grup from ctepvot group by grup having Grup='4.0' " & _
                "union all " & _
                "select 'LABA-RUGI OPERASI' as Aliasing," & _
                "(((select sum(x.JumlahNPM) from ctepvot x group by grup having Grup='1.0') - (select sum(x.JumlahNPM) from ctepvot x group by grup having Grup='2.0')) - (select sum(JumlahNPM) from ctepvot group by grup having Grup='3.0')- " & _
                "(select sum(JumlahNPM) from ctepvot group by grup having Grup='4.0')) as Jumlah, 4.2 as Grup " & _
                "union all " & _
                "select 'TOTAL PENDAPATAN & BIAYA DILUAR USAHA' as Aliasing," & _
                "(select sum(x.JumlahNPM) from ctepvot x group by grup having Grup='5.0') - (select sum(x.JumlahNPM) from ctepvot x group by grup having Grup='6.0') as Jumlah,6.1 as Grup " & _
                "union all " & _
                "select 'LABA-RUGI SEBELUM PAJAK' as Aliasing," & _
                "(((select sum(x.JumlahNPM) from ctepvot x group by grup having Grup='1.0') - (select sum(x.JumlahNPM) from ctepvot x group by grup having Grup='2.0')) - (select sum(JumlahNPM) from ctepvot group by grup having Grup='3.0')- " & _
                "(select sum(JumlahNPM) from ctepvot group by grup having Grup='4.0')) + " & _
                "(select sum(x.JumlahNPM) from ctepvot x group by grup having Grup='5.0') - (select sum(x.JumlahNPM) from ctepvot x group by grup having Grup='6.0') as Jumlah, 6.2 as Grup " & _
                "union all " & _
                "select 'LABA-RUGI SETELAH PAJAK' as Aliasing," & _
                "((((select sum(x.JumlahNPM) from ctepvot x group by grup having Grup='1.0') - (select sum(x.JumlahNPM) from ctepvot x group by grup having Grup='2.0')) - (select sum(JumlahNPM) from ctepvot group by grup having Grup='3.0')- " & _
                "(select sum(JumlahNPM) from ctepvot group by grup having Grup='4.0')) + " & _
                "(select sum(x.JumlahNPM) from ctepvot x group by grup having Grup='5.0') - (select sum(x.JumlahNPM) from ctepvot x group by grup having Grup='6.0') - " & _
                "(select sum(JumlahNPM) from ctepvot group by grup having Grup='7.0')) as Jumlah, 7.1 as Grup " & _
                ")" & _
            "select Aliasing as Keterangan,Jumlah as JumlahNPM,Grup from ctegabung order by Grup"
            'dgList.FirstInit(query, {2.5, 2}, , , {"Grup"}, , , False)
            'dgList.ConnString = tJenis.Text
            'dgList.RefreshData(False)

            Dim query2 As String = _
            "DECLARE @tahunbulan AS VARCHAR(6) " & _
            "SET @tahunbulan='" & periode & "'; " & _
            "WITH cteLR AS " & _
            "(" & _
                "SELECT " & _
                "CONVERT(VARCHAR(6),a.TanggalBukti,112) as TahunBulan,a.KodeCompany," & _
                "a.KodeAkun,b.Keterangan,SUM(CASE WHEN a.DebetOrKredit<>b.DebetOrKredit THEN -a.Jumlah ELSE a.Jumlah END) AS Jumlah," & _
                "b.DebetOrKredit AS DoK " & _
                "FROM dbo.tbACJurnal a " & _
                "LEFT JOIN dbo.tbACKodeAkun b ON b.KodeAkun=a.KodeAkun " & _
                "WHERE " & _
                "CONVERT(VARCHAR(6),a.TanggalBukti,112)=@tahunbulan AND " & _
                "a.KodeCompany in (" & kdcompany & ") " & _
                "AND b.IdKategori IN (SELECT IdKategori FROM dbo.tbACKategori WHERE StatusLaporan='LR') " & _
                "GROUP BY " & _
                "CONVERT(VARCHAR(6),a.TanggalBukti,112)," & _
                "a.KodeCompany," & _
                "a.KodeAkun, b.Keterangan, b.DebetOrKredit" & _
            ") " & _
            "SELECT " & _
                    "aa.TahunBulan, aa.KodeCompany,dd.Aliasing, aa.KodeAkun, aa.Keterangan,  aa.Dok, " & _
                    "aa.Jumlah AS JumlahNPM, dd.grup " & _
                    "FROM cteLR AS aa " & _
                    "LEFT JOIN dbo.tbACKodeAkun cc ON aa.KodeAkun=cc.KodeAkun " & _
                    "LEFT JOIN dbo.tbACKategoriNPM dd ON cc.KodeAkun=dd.KodeAkun " & _
                    "WHERE NOT aa.KodeAkun IN " & _
                        "(aa.kodecompany+'.90.20.210'," & _
                        "aa.kodecompany+'.90.20.971'," & _
                        "aa.kodecompany+'.90.20.972'," & _
                        "aa.kodecompany+'.90.20.973'," & _
                        "aa.kodecompany+'.90.20.974'," & _
                        "aa.kodecompany+'.90.10.610'," & _
                        "aa.kodecompany+'.90.10.620'," & _
                        "aa.kodecompany+'.90.10.630'" & _
                        ") order by aa.kodecompany"

            'Data1
            Using sqlcon As New Data.SqlClient.SqlConnection(tJenis.Text)
                sqlcon.Open()
                Dim sqlCmd = New Data.SqlClient.SqlCommand( _
                             query, _
                             sqlcon)
                Dim adp As New SqlDataAdapter(sqlCmd)
                adp.Fill(dt1)
            End Using
            'add key1
            Dim primaryKey1(0) As DataColumn
            primaryKey1(0) = dt1.Columns("Keterangan")
            dt1.PrimaryKey = primaryKey1

            'Data2
            Using sqlcon As New Data.SqlClient.SqlConnection(tJenis.Text)
                sqlcon.Open()
                Dim sqlCmd = New Data.SqlClient.SqlCommand(query2, sqlcon)
                Dim adp As New SqlDataAdapter(sqlCmd)
                adp.Fill(dt2)
            End Using

            ds.Tables.Add(dt1)
            ds.Tables.Add(dt2)
            ds.Relations.Add("Aliasing", dt1.Columns("Keterangan"), dt2.Columns("Aliasing"))

            gcDetail.DataSource = ds.Tables(1)
            GridView4.BestFitColumns()
            FormatGridView(GridView4, , , True)
            GridView4.Columns("grup").Visible = False
            GridView4.Columns("Aliasing").Width = 200
            GridView4.Columns("Keterangan").Width = 200
            GridView4.Columns("JumlahNPM").Width = 250
            GridView4.OptionsView.ShowGroupPanel = False
            reFormatColumns(GridView4)
            SetFooterSummarySUMs(GridView4, {"JumlahNPM"})
            GridView4.Columns("JumlahNPM").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GridView4.Columns("JumlahNPM").DisplayFormat.FormatString = "c2"

            GridControl1.DataSource = ds.Tables("table1")
            GridView1.BestFitColumns()
            FormatGridView(GridView1, , , True)
            GridView1.Columns("Grup").Visible = False
            GridView1.Columns("Keterangan").Width = 500
            GridView1.Columns("JumlahNPM").Width = 300
            GridView1.OptionsView.ShowGroupPanel = False
            reFormatColumns(GridView1)
            GridView1.Columns("JumlahNPM").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GridView1.Columns("JumlahNPM").DisplayFormat.FormatString = "c2"

            GridControl1.LevelTree.Nodes.Clear()
            GridControl1.LevelTree.Nodes.Add("Aliasing", GridView2)
            GridView2.PopulateColumns(ds.Tables("table2"))
            GridView2.BestFitColumns()
            FormatGridView(GridView2, , , True)
            GridView2.Columns("grup").Visible = False
            GridView2.Columns("Aliasing").Width = 200
            GridView2.Columns("Keterangan").Width = 200
            GridView2.Columns("JumlahNPM").Width = 250
            GridView2.OptionsView.ShowGroupPanel = False
            reFormatColumns(GridView2)
            SetFooterSummarySUMs(GridView2, {"JumlahNPM"})
            GridView2.Columns("JumlahNPM").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GridView2.Columns("JumlahNPM").DisplayFormat.FormatString = "c2"
        End If
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridView1_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles GridView1.CustomDrawCell
        If Not Strings.Right(GridView1.GetRowCellValue(e.RowHandle, "Grup"), 1) = "0" Then
            e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
        End If
    End Sub

    Private Sub cCompany_ItemCheck(sender As Object, e As DevExpress.XtraEditors.Controls.ItemCheckEventArgs) Handles cCompany.ItemCheck
        Dim nmtable As String = Strings.Left(cCompany.SelectedItem.ToString, 2)

        Dim drow() As DataRow = datatabel.Select("KodeCompany = '" & nmtable & "'")
        drow(0)!cek = e.State
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        Dim saveFileDialog1 As New SaveFileDialog
        saveFileDialog1.Filter = "Excel File|*.xlsx"
        saveFileDialog1.Title = "Save an Excel File"
        saveFileDialog1.ShowDialog()

        If saveFileDialog1.FileName <> "" Then
            GridView1.OptionsPrint.PrintDetails = True
            GridView1.OptionsPrint.ExpandAllDetails = True

            GridView2.OptionsPrint.PrintDetails = True
            GridView2.OptionsPrint.ExpandAllDetails = True

            Dim options As New XlsxExportOptionsEx
            options.ExportType = ExportType.WYSIWYG

            GridView1.ExportToXlsx(saveFileDialog1.FileName, options)
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Dim saveFileDialog1 As New SaveFileDialog
        saveFileDialog1.Filter = "Excel File|*.xlsx"
        saveFileDialog1.Title = "Save an Excel File"
        saveFileDialog1.ShowDialog()

        If saveFileDialog1.FileName <> "" Then
            GridView1.OptionsPrint.PrintDetails = True

            Dim options As New XlsxExportOptionsEx
            options.ExportType = ExportType.WYSIWYG

            GridView1.ExportToXlsx(saveFileDialog1.FileName, options)
        End If
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Dim saveFileDialog1 As New SaveFileDialog
        saveFileDialog1.Filter = "Excel File|*.xlsx"
        saveFileDialog1.Title = "Save an Excel File"
        saveFileDialog1.ShowDialog()

        If saveFileDialog1.FileName <> "" Then
            'GridView1.OptionsPrint.PrintDetails = True
            'GridView1.OptionsPrint.ExpandAllDetails = True

            GridView4.OptionsPrint.PrintDetails = True
            'GridView2.OptionsPrint.ExpandAllDetails = True

            Dim options As New XlsxExportOptionsEx
            options.ExportType = ExportType.WYSIWYG

            GridView4.ExportToXlsx(saveFileDialog1.FileName, options)
        End If
    End Sub
End Class