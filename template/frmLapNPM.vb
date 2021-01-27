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

        dTahun1.Properties.DisplayFormat.FormatString = "yyyy"
        dTahun1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        dTahun1.Properties.EditMask = "yyyy"
        dTahun1.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearsGroupView
        dTahun1.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView

        dTahun2.Properties.DisplayFormat.FormatString = "yyyy"
        dTahun2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        dTahun2.Properties.EditMask = "yyyy"
        dTahun2.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearsGroupView
        dTahun2.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView
        dTahun3.Properties.DisplayFormat.FormatString = "yyyy"
        dTahun3.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        dTahun3.Properties.EditMask = "yyyy"
        dTahun3.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearsGroupView
        dTahun3.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView

        dTahun1.EditValue = Now
        dTahun2.Enabled = False
        dTahun3.Enabled = False
        cbKodeCompany.Enabled = False
        cJenisLaporan.SelectedIndex = 0
        cTampilan.SelectedIndex = 0
    End Sub

    Private Sub cJenis_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cJenis.SelectedIndexChanged
        Dim lokasi As String = ""
        If cJenis.Text = "10.10.2.2 (UE)" Then
            lokasi = "10.10.2.2\bukbes"
        ElseIf cJenis.Text = "10.10.2.13 (UM)" Then
            lokasi = "10.10.2.13\bukbes"
        End If

        tJenis.Text = "Data Source=" & lokasi & ";Initial Catalog=BukbesAcc;Persist Security Info=True;User ID=sa;Password=pancetgogogo;Connection Timeout=0"

        koneksi(tJenis.Text)
        Dim qucompany As String = "select KodeCompany,NamaAlias + ' - ' + KodeCompany as Nama from tbGNCompany"
        da = New SqlDataAdapter(qucompany, kon)
        datatabel.Clear()
        da.Fill(datatabel)

        cbKodeCompany.Enabled = True
        cbKodeCompany.Properties.DataSource = datatabel
        cbKodeCompany.Properties.DisplayMember = "Nama"
        cbKodeCompany.Properties.ValueMember = "KodeCompany"

    End Sub

    Private Sub btnAmbilData_Click(sender As Object, e As EventArgs) Handles btnAmbilData.Click
        GridView1.ShowLoadingPanel()
        Dim aa As Integer = cbKodeCompany.Properties.GetItems.GetCheckedValues.Count
        If cJenis.Text = "" Then
            MsgBox("Pilih Jenis Terlebih Dahulu!", vbCritical + vbOKOnly, "Peringatan")
        ElseIf aa < 1 Then
            MsgBox("Pilih Kode Company Terlebih Dahulu!", vbCritical + vbOKOnly, "Peringatan")
        ElseIf cBulan.CheckedItemsCount = 0 Then
            MsgBox("Pilih Bulan Terlebih Dahulu!", vbCritical + vbOKOnly, "Peringatan")
        ElseIf cTampilan.Text = "" Then
            MsgBox("Pilih Tampilan Terlebih Dahulu!", vbCritical + vbOKOnly, "Peringatan")
        Else
            GridView1.Columns.Clear()
            GridView2.Columns.Clear()
            GridView4.Columns.Clear()
            Dim ds As New DataSet
            'Dim ds3 As New DataSet
            Dim dt1 As New DataTable
            Dim dt2 As New DataTable
            Dim dt3 As New DataTable

            Dim kdcompany As String = ""
            For i = 0 To cbKodeCompany.Properties.GetItems.GetCheckedValues.Count - 1
                If i = cbKodeCompany.Properties.GetItems.GetCheckedValues.Count - 1 Then
                    kdcompany += "'" & cbKodeCompany.Properties.GetItems.GetCheckedValues(i).ToString & "'"
                Else
                    kdcompany += "'" & cbKodeCompany.Properties.GetItems.GetCheckedValues(i).ToString & "',"
                End If
            Next

            Dim bulan As String = ""
            For j = 0 To cBulan.CheckedItemsCount - 1
                bulan += "" & cBulan.CheckedItems.Item(j).ToString & ","
            Next
            Dim jmlbulan As Integer = Strings.Split(bulan, ",").Length - 1

            Dim tahun As String = "" & Format(dTahun1.EditValue, "yyyy") & ","
            Dim tahunbudget As String = "'" & Format(dTahun1.EditValue, "yyyy") & "'"
            Dim tahunpivot As String = "[" & Format(dTahun1.EditValue, "yyyy") & "]"
            Dim ctepivotrealisasistring As String = "sum(isnull(p.[" & Format(dTahun1.EditValue, "yyyy") & "],0)) as Realisasi" & Format(dTahun1.EditValue, "yyyy") & ""
            Dim ctepivotratastring As String = "sum(isnull(p.[" & Format(dTahun1.EditValue, "yyyy") & "],0)) as Rata" & Format(dTahun1.EditValue, "yyyy") & ""
            Dim ctepivotpersenstring As String = "sum(isnull(p.[" & Format(dTahun1.EditValue, "yyyy") & "],0)) as Persen" & Format(dTahun1.EditValue, "yyyy") & ""
            Dim ctepivotbudgetstring As String = "sum(isnull(p.[" & Format(dTahun1.EditValue, "yyyy") & "],0)) as Budget" & Format(dTahun1.EditValue, "yyyy") & ""
            Dim selecttahun As String = "a.Realisasi" & Format(dTahun1.EditValue, "yyyy") & ",b.Rata" & Format(dTahun1.EditValue, "yyyy") & ",c.Persen" & Format(dTahun1.EditValue, "yyyy") & ", 0 as Selisih"
            Dim selectbudget As String = "a.Realisasi" & Format(dTahun1.EditValue, "yyyy") & ",b.Budget" & Format(dTahun1.EditValue, "yyyy") & "," & _
                "case when b.Budget" & Format(dTahun1.EditValue, "yyyy") & " = 0 then 0 else ((a.Realisasi" & Format(dTahun1.EditValue, "yyyy") & "-b.Budget" & Format(dTahun1.EditValue, "yyyy") & ")/b.Budget" & Format(dTahun1.EditValue, "yyyy") & "*100) end as [%RealisasiVsBudget" & Format(dTahun1.EditValue, "yyyy") & "]"
            If cTahun2.Checked = True Then
                tahun += "" & Format(dTahun2.EditValue, "yyyy") & ","
                tahunbudget += ",'" & Format(dTahun2.EditValue, "yyyy") & "'"
                tahunpivot += ",[" & Format(dTahun2.EditValue, "yyyy") & "]"
                ctepivotrealisasistring += ",sum(isnull(p.[" & Format(dTahun2.EditValue, "yyyy") & "],0)) as Realisasi" & Format(dTahun2.EditValue, "yyyy") & ""
                ctepivotratastring += ",sum(isnull(p.[" & Format(dTahun2.EditValue, "yyyy") & "],0)) as Rata" & Format(dTahun2.EditValue, "yyyy") & ""
                ctepivotpersenstring += ",sum(isnull(p.[" & Format(dTahun2.EditValue, "yyyy") & "],0)) as Persen" & Format(dTahun2.EditValue, "yyyy") & ""
                ctepivotbudgetstring += ",sum(isnull(p.[" & Format(dTahun2.EditValue, "yyyy") & "],0)) as Budget" & Format(dTahun2.EditValue, "yyyy") & ""
                selecttahun = _
                    "a.Realisasi" & Format(dTahun1.EditValue, "yyyy") & ",a.Realisasi" & Format(dTahun2.EditValue, "yyyy") & ",b.Rata" & Format(dTahun1.EditValue, "yyyy") & ",c.Persen" & Format(dTahun1.EditValue, "yyyy") & ",b.Rata" & Format(dTahun2.EditValue, "yyyy") & ",c.Persen" & Format(dTahun2.EditValue, "yyyy") & "," & _
                    "case when b.Rata" & Format(dTahun1.EditValue, "yyyy") & " = 0 or b.Rata" & Format(dTahun2.EditValue, "yyyy") & " = 0 then 0 else ((b.Rata" & Format(dTahun2.EditValue, "yyyy") & "-b.Rata" & Format(dTahun1.EditValue, "yyyy") & ") / b.Rata" & Format(dTahun1.EditValue, "yyyy") & "* 100) end as [Selisih" & Format(dTahun1.EditValue, "yyyy") & "-" & Format(dTahun2.EditValue, "yyyy") & "]"
                selectbudget = _
                    "a.Realisasi" & Format(dTahun1.EditValue, "yyyy") & ",b.Budget" & Format(dTahun1.EditValue, "yyyy") & ",a.Realisasi" & Format(dTahun2.EditValue, "yyyy") & ",b.Budget" & Format(dTahun2.EditValue, "yyyy") & "," & _
                    "case when b.Budget" & Format(dTahun1.EditValue, "yyyy") & " = 0 then 0 else ((a.Realisasi" & Format(dTahun1.EditValue, "yyyy") & "-b.Budget" & Format(dTahun1.EditValue, "yyyy") & ")/b.Budget" & Format(dTahun1.EditValue, "yyyy") & "*100) end as [%RealisasiVsBudget" & Format(dTahun1.EditValue, "yyyy") & "]," & _
                    "case when b.Budget" & Format(dTahun2.EditValue, "yyyy") & " = 0 then 0 else ((a.Realisasi" & Format(dTahun2.EditValue, "yyyy") & "-b.Budget" & Format(dTahun2.EditValue, "yyyy") & ")/b.Budget" & Format(dTahun2.EditValue, "yyyy") & "*100) end as [%RealisasiVsBudget" & Format(dTahun2.EditValue, "yyyy") & "]"
            End If
            If cTahun3.Checked = True Then
                tahun += "" & Format(dTahun3.EditValue, "yyyy") & ","
                tahunbudget += ",'" & Format(dTahun3.EditValue, "yyyy") & "'"
                tahunpivot += ",[" & Format(dTahun3.EditValue, "yyyy") & "]"
                ctepivotrealisasistring += ",sum(isnull(p.[" & Format(dTahun3.EditValue, "yyyy") & "],0)) as Realisasi" & Format(dTahun3.EditValue, "yyyy") & ""
                ctepivotratastring += ",sum(isnull(p.[" & Format(dTahun3.EditValue, "yyyy") & "],0)) as Rata" & Format(dTahun3.EditValue, "yyyy") & ""
                ctepivotpersenstring += ",sum(isnull(p.[" & Format(dTahun3.EditValue, "yyyy") & "],0)) as Persen" & Format(dTahun3.EditValue, "yyyy") & ""
                ctepivotbudgetstring += ",sum(isnull(p.[" & Format(dTahun3.EditValue, "yyyy") & "],0)) as Budget" & Format(dTahun3.EditValue, "yyyy") & ""
                selecttahun = _
                    "a.Realisasi" & Format(dTahun1.EditValue, "yyyy") & ",a.Realisasi" & Format(dTahun2.EditValue, "yyyy") & ",a.Realisasi" & Format(dTahun3.EditValue, "yyyy") & ",b.Rata" & Format(dTahun1.EditValue, "yyyy") & ",c.Persen" & Format(dTahun1.EditValue, "yyyy") & ",b.Rata" & Format(dTahun2.EditValue, "yyyy") & ",c.Persen" & Format(dTahun2.EditValue, "yyyy") & ",b.Rata" & Format(dTahun3.EditValue, "yyyy") & ",c.Persen" & Format(dTahun3.EditValue, "yyyy") & "," & _
                    "case when b.Rata" & Format(dTahun1.EditValue, "yyyy") & " = 0 or b.Rata" & Format(dTahun2.EditValue, "yyyy") & " = 0 then 0 else ((b.Rata" & Format(dTahun2.EditValue, "yyyy") & "-b.Rata" & Format(dTahun1.EditValue, "yyyy") & ") / b.Rata" & Format(dTahun1.EditValue, "yyyy") & "* 100) end as [Selisih" & Format(dTahun1.EditValue, "yyyy") & "-" & Format(dTahun2.EditValue, "yyyy") & "]," & _
                    "case when b.Rata" & Format(dTahun2.EditValue, "yyyy") & " = 0 or b.Rata" & Format(dTahun3.EditValue, "yyyy") & " = 0 then 0 else ((b.Rata" & Format(dTahun3.EditValue, "yyyy") & "-b.Rata" & Format(dTahun2.EditValue, "yyyy") & ") / b.Rata" & Format(dTahun2.EditValue, "yyyy") & "* 100) end as [Selisih" & Format(dTahun2.EditValue, "yyyy") & "-" & Format(dTahun3.EditValue, "yyyy") & "]"
                selectbudget = _
                    "a.Realisasi" & Format(dTahun1.EditValue, "yyyy") & ",b.Budget" & Format(dTahun1.EditValue, "yyyy") & ",a.Realisasi" & Format(dTahun2.EditValue, "yyyy") & ",b.Budget" & Format(dTahun2.EditValue, "yyyy") & ",a.Realisasi" & Format(dTahun3.EditValue, "yyyy") & ",b.Budget" & Format(dTahun3.EditValue, "yyyy") & "," & _
                    "case when b.Budget" & Format(dTahun1.EditValue, "yyyy") & " = 0 then 0 else ((a.Realisasi" & Format(dTahun1.EditValue, "yyyy") & "-b.Budget" & Format(dTahun1.EditValue, "yyyy") & ")/b.Budget" & Format(dTahun1.EditValue, "yyyy") & "*100) end as [%RealisasiVsBudget" & Format(dTahun1.EditValue, "yyyy") & "]," & _
                    "case when b.Budget" & Format(dTahun2.EditValue, "yyyy") & " = 0 then 0 else ((a.Realisasi" & Format(dTahun2.EditValue, "yyyy") & "-b.Budget" & Format(dTahun2.EditValue, "yyyy") & ")/b.Budget" & Format(dTahun2.EditValue, "yyyy") & "*100) end as [%RealisasiVsBudget" & Format(dTahun2.EditValue, "yyyy") & "]," & _
                    "case when b.Budget" & Format(dTahun3.EditValue, "yyyy") & " = 0 then 0 else ((a.Realisasi" & Format(dTahun3.EditValue, "yyyy") & "-b.Budget" & Format(dTahun3.EditValue, "yyyy") & ")/b.Budget" & Format(dTahun3.EditValue, "yyyy") & "*100) end as [%RealisasiVsBudget" & Format(dTahun3.EditValue, "yyyy") & "]"
            End If
            Dim tahunbulan As String = ""
            Dim uniontanggal As String = ""
            Dim uniontanggal2 As String = ""
            For a = 0 To Strings.Split(tahun, ",").Length - 2
                For b = 0 To Strings.Split(bulan, ",").Length - 2
                    tahunbulan += "'" & Strings.Split(tahun, ",")(a) & Strings.Split(bulan, ",")(b) & "',"

                    If a = 0 And b = 0 Then
                        uniontanggal += "select '" & Strings.Split(tahun, ",")(a) & Strings.Split(bulan, ",")(b) & "' as TahunBulan, Aliasing,Grup from tbACKategoriNPM group by Aliasing,Grup "
                    Else
                        uniontanggal += "union all select '" & Strings.Split(tahun, ",")(a) & Strings.Split(bulan, ",")(b) & "' as TahunBulan, Aliasing,Grup from tbACKategoriNPM group by Aliasing,Grup "
                    End If

                    If a = 0 And b = 0 Then
                        uniontanggal2 += "select SUBSTRING(KodeAkun,1,2) as KodeCompany, '" & Strings.Split(tahun, ",")(a) & Strings.Split(bulan, ",")(b) & "' as TahunBulan, Aliasing,Grup from tbACKategoriNPM group by Aliasing,Grup,SUBSTRING(KodeAkun,1,2) having SUBSTRING(KodeAkun,1,2) in (" & kdcompany & ") "
                    Else
                        uniontanggal2 += "union all select SUBSTRING(KodeAkun,1,2) as KodeCompany, '" & Strings.Split(tahun, ",")(a) & Strings.Split(bulan, ",")(b) & "' as TahunBulan, Aliasing,Grup from tbACKategoriNPM group by Aliasing,Grup,SUBSTRING(KodeAkun,1,2) having SUBSTRING(KodeAkun,1,2) in (" & kdcompany & ") "
                    End If
                Next
            Next

            Dim query As String = ""
            Dim query2 As String = ""

            If cTampilan.SelectedIndex = 0 Then
                If cJenisLaporan.SelectedIndex = 0 Then
                    query = _
               "IF OBJECT_ID('tempdb..#tmptable') IS NOT NULL DROP TABLE #tmptable;" & _
               "WITH cteLR AS " & _
               "(" & _
                   "SELECT " & _
                   "CONVERT(VARCHAR(6),a.TanggalBukti,112) as TahunBulan,a.KodeCompany," & _
                   "a.KodeAkun,b.Keterangan,SUM(CASE WHEN a.DebetOrKredit<>b.DebetOrKredit THEN -a.Jumlah ELSE a.Jumlah END) AS Jumlah," & _
                   "b.DebetOrKredit AS DoK " & _
                   "FROM dbo.tbACJurnal a " & _
                   "LEFT JOIN dbo.tbACKodeAkun b ON b.KodeAkun=a.KodeAkun " & _
                   "WHERE " & _
                   "CONVERT(VARCHAR(6),a.TanggalBukti,112) in (" & Strings.Left(tahunbulan, tahunbulan.Length - 1) & ") AND " & _
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
                           "aa.KodeCompany+'.60.01.100'," & _
                           "aa.kodecompany+'.90.10.630'" & _
                           ")" & _
               "), " & _
               "cteall as(" & _
                   "" & uniontanggal & ")," & _
               "cteall2 as(" & _
                   "select a.TahunBulan,a.Aliasing, sum(isnull(b.JumlahNPM,0)) as JumlahNPM,a.Grup from cteall a " & _
                   "left join ctepvot b on b.Aliasing = a.Aliasing and b.TahunBulan = a.TahunBulan " & _
                   "group by a.Aliasing,a.Grup,a.TahunBulan " & _
                   ")," & _
               "ctegabung as(" & _
                   "select * from cteall2 " & _
                   "union all " & _
                   "select a.TahunBulan,'PENDAPATAN BERSIH' as Aliasing,(" & _
                   "select isnull ((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='1.0'),0))-" & _
                   "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='2.0'),0)) " & _
                   "as Jumlah, 2.1 as Grup from ctepvot a group by a.TahunBulan " & _
                   "union all " & _
                   "select a.TahunBulan,'TOTAL HPP BARANG DAGANG' as Aliasing,(" & _
                   "select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='3.0'),0)) as Jumlah, 3.1 as Grup " & _
                   "from ctepvot a group by a.TahunBulan " & _
                   "union all " & _
                   "select a.TahunBulan,'LABA-RUGI KOTOR' as Aliasing," & _
                   "((select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='1.0'),0))-" & _
                   "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='2.0'),0)))-" & _
                   "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='3.0'),0)) as Jumlah, 3.2 as Grup " & _
                   "from ctepvot a group by a.TahunBulan " & _
                   "union all " & _
                   "select a.TahunBulan,'TOTAL BEBAN USAHA' as Aliasing," & _
                   "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='4.0'),0)) as Jumlah, 4.1 as Grup " & _
                   "from ctepvot a group by a.TahunBulan " & _
                   "union all " & _
                   "select a.TahunBulan,'LABA-RUGI OPERASI' as Aliasing," & _
                   "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='1.0'),0))-" & _
                   "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='2.0'),0))-" & _
                   "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='3.0'),0))-" & _
                   "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='4.0'),0)) as Jumlah, 4.2 as Grup " & _
                   "from ctepvot a group by a.TahunBulan " & _
                   "union all " & _
                   "select a.TahunBulan,'TOTAL PENDAPATAN & BIAYA DILUAR USAHA' as Aliasing," & _
                   "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='5.0'),0))-" & _
                   "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='6.0'),0)) as Jumlah, 6.1 as Grup " & _
                   "from ctepvot a group by a.TahunBulan " & _
                   "union all " & _
                   "select a.TahunBulan,'LABA-RUGI SEBELUM PAJAK' as Aliasing," & _
                   "((select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='1.0'),0))-" & _
                   "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='2.0'),0))-" & _
                   "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='3.0'),0))-" & _
                   "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='4.0'),0)))+" & _
                   "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='5.0'),0))-" & _
                   "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='6.0'),0)) " & _
                   "as Jumlah, 6.2 as Grup " & _
                   "from ctepvot a group by a.TahunBulan " & _
                   "union all " & _
                   "select a.TahunBulan,'LABA-RUGI SETELAH PAJAK' as Aliasing," & _
                   "((select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='1.0'),0))-" & _
                   "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='2.0'),0))- " & _
                   "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='3.0'),0))-" & _
                   "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='4.0'),0)))+" & _
                   "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='5.0'),0))-" & _
                   "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='6.0'),0))-" & _
                   "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='7.0'),0)) " & _
                   "as Jumlah, 7.1 as Grup " & _
                   "from ctepvot a group by a.TahunBulan " & _
                   ")," & _
                   "ctejml as(" & _
                   "select SUBSTRING(a.TahunBulan,1,4) as Tahun,a.Aliasing,sum(a.JumlahNPM) as Jumlah, sum(a.JumlahNPM)/" & jmlbulan & " as Rata, " & _
                   "(sum(a.JumlahNPM)/" & jmlbulan & ") / (select sum(x.JumlahNPM)/" & jmlbulan & " from ctegabung x where SUBSTRING(x.TahunBulan,1,4)=SUBSTRING(a.TahunBulan,1,4) and x.Aliasing='PENDAPATAN BERSIH') * 100 as Persen" & _
                   ",Grup from ctegabung a " & _
                   "group by SUBSTRING(a.TahunBulan,1,4),a.Aliasing,a.Grup" & _
                   ") select * into #tmptable from ctejml; " & _
                   "with ctepivotrealisasi as(" & _
                   "select P.Aliasing," & ctepivotrealisasistring & ",Grup from #tmptable D " & _
                   "PIVOT(Sum(Jumlah) FOR D.Tahun IN (" & tahunpivot & ")) P " & _
                   "group by Aliasing,Grup" & _
                   ")," & _
                   "cterata as(" & _
                   "select P.Aliasing," & ctepivotratastring & ",Grup from #tmptable D " & _
                   "PIVOT(max(Rata) FOR D.Tahun IN (" & tahunpivot & ")) P " & _
                   "group by Aliasing,Grup" & _
                   ")," & _
                   "ctepersen as(" & _
                   "select P.Aliasing," & ctepivotpersenstring & ",Grup from #tmptable D " & _
                   "PIVOT(max(Persen) FOR D.Tahun IN (" & tahunpivot & ")) P " & _
                   "group by Aliasing,Grup" & _
                   ")" & _
                   "select a.Aliasing as Keterangan," & selecttahun & "," & _
                   "a.Grup from ctepivotrealisasi a " & _
                   "left join cterata b on b.Aliasing = a.Aliasing and b.Grup = a.Grup " & _
                   "left join ctepersen c on c.Aliasing = a.Aliasing and c.Grup = a.Grup " & _
                   "order by a.Grup"

                    query2 = _
                "WITH cteLR AS " & _
                "(" & _
                    "SELECT " & _
                    "CONVERT(VARCHAR(6),a.TanggalBukti,112) as TahunBulan,a.KodeCompany," & _
                    "a.KodeAkun,b.Keterangan,SUM(CASE WHEN a.DebetOrKredit<>b.DebetOrKredit THEN -a.Jumlah ELSE a.Jumlah END) AS Jumlah," & _
                    "b.DebetOrKredit AS DoK " & _
                    "FROM dbo.tbACJurnal a " & _
                    "LEFT JOIN dbo.tbACKodeAkun b ON b.KodeAkun=a.KodeAkun " & _
                    "WHERE " & _
                    "CONVERT(VARCHAR(6),a.TanggalBukti,112) in (" & Strings.Left(tahunbulan, tahunbulan.Length - 1) & ") AND " & _
                    "a.KodeCompany in (" & kdcompany & ") " & _
                    "AND b.IdKategori IN (SELECT IdKategori FROM dbo.tbACKategori WHERE StatusLaporan='LR') " & _
                    "GROUP BY " & _
                    "CONVERT(VARCHAR(6),a.TanggalBukti,112)," & _
                    "a.KodeCompany," & _
                    "a.KodeAkun, b.Keterangan, b.DebetOrKredit" & _
                ") " & _
                "SELECT " & _
                        "aa.TahunBulan, aa.KodeCompany,dd.Aliasing as KeteranganAkun, aa.KodeAkun, aa.Keterangan,  aa.Dok, " & _
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
                            "aa.KodeCompany+'.60.01.100'," & _
                            "aa.kodecompany+'.90.10.630'" & _
                            ") order by aa.kodecompany,aa.TahunBulan"
                ElseIf cJenisLaporan.SelectedIndex = 1 Then
                    query = _
                "IF OBJECT_ID('tempdb..#tmptmp') IS NOT NULL DROP TABLE #tmptmp; " & _
                "DECLARE @BulanArr VARCHAR(50) " & _
                "SET @BulanArr = '" & Strings.Left(bulan, bulan.Length - 1) & "'; " & _
                "WITH cteLR AS (" & _
                "SELECT CONVERT(VARCHAR(6),a.TanggalBukti,112) as TahunBulan,a.KodeCompany,a.KodeAkun,b.Keterangan," & _
                "SUM(CASE WHEN a.DebetOrKredit<>b.DebetOrKredit THEN -a.Jumlah ELSE a.Jumlah END) AS Jumlah,b.DebetOrKredit AS DoK " & _
                "FROM dbo.tbACJurnal a " & _
                "LEFT JOIN dbo.tbACKodeAkun b ON b.KodeAkun=a.KodeAkun " & _
                "WHERE CONVERT(VARCHAR(6),a.TanggalBukti,112) in (" & Strings.Left(tahunbulan, tahunbulan.Length - 1) & "" & _
                ") AND a.KodeCompany in (" & kdcompany & ") AND b.IdKategori " & _
                "IN (SELECT IdKategori FROM dbo.tbACKategori WHERE StatusLaporan='LR') " & _
                "GROUP BY CONVERT(VARCHAR(6),a.TanggalBukti,112),a.KodeCompany,a.KodeAkun, b.Keterangan, b.DebetOrKredit), " & _
                "ctepvot as(" & _
                "SELECT aa.TahunBulan, aa.KODECOMPANY,dd.Aliasing, aa.KODEAKUN, aa.KETERANGAN,  aa.DOK, aa.Jumlah AS JumlahNPM, dd.grup " & _
                "FROM cteLR AS aa " & _
                "LEFT JOIN dbo.tbACKodeAkun cc ON aa.KodeAkun=cc.KodeAkun " & _
                "LEFT JOIN dbo.tbACKategoriNPM dd ON cc.KodeAkun=dd.KodeAkun " & _
                "WHERE NOT aa.KodeAkun IN " & _
                "(aa.kodecompany+'.90.20.210',aa.kodecompany+'.90.20.971',aa.kodecompany+'.90.20.972',aa.kodecompany+'.90.20.973'," & _
                "aa.kodecompany+'.90.20.974',aa.kodecompany+'.90.10.610',aa.kodecompany+'.90.10.620',aa.kodecompany+'.90.10.630',aa.kodecompany+'.60.01.100'))," & _
                "cteall as(" & _
                    "" & uniontanggal & ")," & _
                "cteall2 as(" & _
                    "select a.TahunBulan,a.Aliasing, sum(isnull(b.JumlahNPM,0)) as JumlahNPM,a.Grup from cteall a " & _
                    "left join ctepvot b on b.Aliasing = a.Aliasing and b.TahunBulan = a.TahunBulan " & _
                    "group by a.Aliasing,a.Grup,a.TahunBulan " & _
                    ")," & _
                "ctegabung as(" & _
                "select TahunBulan,Aliasing, sum(JumlahNPM) as Jumlah,Grup " & _
                "from cteall2 a group by Aliasing,Grup,TahunBulan " & _
                "union all " & _
                    "select a.TahunBulan,'PENDAPATAN BERSIH' as Aliasing,(" & _
                    "select isnull ((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='1.0'),0))-" & _
                    "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='2.0'),0)) " & _
                    "as Jumlah, 2.1 as Grup from cteall2 a group by a.TahunBulan " & _
                    "union all " & _
                    "select a.TahunBulan,'TOTAL HPP BARANG DAGANG' as Aliasing,(" & _
                    "select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='3.0'),0)) as Jumlah, 3.1 as Grup " & _
                    "from cteall2 a group by a.TahunBulan " & _
                    "union all " & _
                    "select a.TahunBulan,'LABA-RUGI KOTOR' as Aliasing," & _
                    "((select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='1.0'),0))-" & _
                    "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='2.0'),0)))-" & _
                    "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='3.0'),0)) as Jumlah, 3.2 as Grup " & _
                    "from cteall2 a group by a.TahunBulan " & _
                    "union all " & _
                    "select a.TahunBulan,'TOTAL BEBAN USAHA' as Aliasing," & _
                    "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='4.0'),0)) as Jumlah, 4.1 as Grup " & _
                    "from cteall2 a group by a.TahunBulan " & _
                    "union all " & _
                    "select a.TahunBulan,'LABA-RUGI OPERASI' as Aliasing," & _
                    "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='1.0'),0))-" & _
                    "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='2.0'),0))-" & _
                    "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='3.0'),0))-" & _
                    "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='4.0'),0)) as Jumlah, 4.2 as Grup " & _
                    "from cteall2 a group by a.TahunBulan " & _
                    "union all " & _
                    "select a.TahunBulan,'TOTAL PENDAPATAN & BIAYA DILUAR USAHA' as Aliasing," & _
                    "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='5.0'),0))-" & _
                    "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='6.0'),0)) as Jumlah, 6.1 as Grup " & _
                    "from cteall2 a group by a.TahunBulan " & _
                    "union all " & _
                    "select a.TahunBulan,'LABA-RUGI SEBELUM PAJAK' as Aliasing," & _
                    "((select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='1.0'),0))-" & _
                    "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='2.0'),0))-" & _
                    "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='3.0'),0))-" & _
                    "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='4.0'),0)))+" & _
                    "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='5.0'),0))-" & _
                    "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='6.0'),0)) " & _
                    "as Jumlah, 6.2 as Grup " & _
                    "from cteall2 a group by a.TahunBulan " & _
                    "union all " & _
                    "select a.TahunBulan,'LABA-RUGI SETELAH PAJAK' as Aliasing," & _
                    "((select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='1.0'),0))-" & _
                    "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='2.0'),0))- " & _
                    "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='3.0'),0))-" & _
                    "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='4.0'),0)))+" & _
                    "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='5.0'),0))-" & _
                    "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='6.0'),0))-" & _
                    "(select isnull((select sum(x.JumlahNPM) from cteall2 x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='7.0'),0)) " & _
                    "as Jumlah, 7.1 as Grup " & _
                    "from cteall2 a group by a.TahunBulan) select * into #tmptmp from ctegabung; " & _
                "with ctejml as(" & _
                "select SUBSTRING(a.TahunBulan,1,4) as Tahun,a.Aliasing,sum(a.Jumlah) as Jumlah, Grup from #tmptmp a " & _
                "group by SUBSTRING(a.TahunBulan,1,4),a.Aliasing,a.Grup)," & _
                "ctebudget as(" & _
                "SELECT tahun,KodeCompany,b.Aliasing," & _
                "sum(CASE WHEN CHARINDEX( ',' + '01' + ',', ',' + @BulanArr + ',' )>0 then jan ELSE 0 end+" & _
                "CASE WHEN CHARINDEX( ',' + '02' + ',', ',' + @BulanArr + ',' )>0 then peb ELSE 0 end+" & _
                "CASE WHEN CHARINDEX( ',' + '03' + ',', ',' + @BulanArr + ',' )>0 then mar ELSE 0 end+" & _
                "CASE WHEN CHARINDEX( ',' + '04' + ',', ',' + @BulanArr + ',' )>0 then apr ELSE 0 end+" & _
                "CASE WHEN CHARINDEX( ',' + '05' + ',', ',' + @BulanArr + ',' )>0 then mei ELSE 0 end+" & _
                "CASE WHEN CHARINDEX( ',' + '06' + ',', ',' + @BulanArr + ',' )>0 then jun ELSE 0 end+" & _
                "CASE WHEN CHARINDEX( ',' + '07' + ',', ',' + @BulanArr + ',' )>0 then jul ELSE 0 end+" & _
                "CASE WHEN CHARINDEX( ',' + '08' + ',', ',' + @BulanArr + ',' )>0 then agt ELSE 0 end+" & _
                "CASE WHEN CHARINDEX( ',' + '09' + ',', ',' + @BulanArr + ',' )>0 then sep ELSE 0 end+" & _
                "CASE WHEN CHARINDEX( ',' + '10' + ',', ',' + @BulanArr + ',' )>0 then okt ELSE 0 end+" & _
                "CASE WHEN CHARINDEX( ',' + '11' + ',', ',' + @BulanArr + ',' )>0 then nop ELSE 0 end+" & _
                "CASE WHEN CHARINDEX( ',' + '12' + ',', ',' + @BulanArr + ',' )>0 then [des] ELSE 0 END) AS TotBudget, Grup " & _
                "FROM dbo.tbACBudget a " & _
                "INNER JOIN dbo.tbACKategoriNPM b ON a.KodeAkun=b.KodeAkun " & _
                "WHERE tahun IN (" & tahunbudget & ") AND KodeCompany in (" & kdcompany & ") " & _
                "GROUP BY b.Aliasing,b.Grup,a.Tahun,a.KodeCompany)," & _
                "cteunion as(" & _
                "select Tahun,Aliasing,TotBudget,Grup from ctebudget " & _
                "union all " & _
                "select Tahun,'PENDAPATAN BERSIH' as Aliasing, (" & _
                "(select isnull((select sum(x.TotBudget) from ctebudget x group by x.Tahun,x.grup having x.Tahun=a.Tahun and x.Grup='1.0'),0))-" & _
                "(select isnull((select sum(x.TotBudget) from ctebudget x group by x.Tahun,x.grup having x.Tahun=a.Tahun and x.Grup='2.0'),0))" & _
                ") as TotBudget, 2.1 as Grup from ctebudget a group by Tahun " & _
                "union all " & _
                "select Tahun,'TOTAL HPP BARANG DAGANG' as Aliasing, (" & _
                "(select isnull((select sum(x.TotBudget) from ctebudget x group by x.Tahun,x.grup having x.Tahun=a.Tahun and x.Grup='3.0'),0))" & _
                ") as TotBudget, 3.1 as Grup from ctebudget a group by Tahun " & _
                "union all " & _
                "select Tahun,'LABA-RUGI KOTOR' as Aliasing,(" & _
                "(select isnull((select sum(x.TotBudget) from ctebudget x group by x.Tahun,x.grup having x.Tahun=a.Tahun and x.Grup='1.0'),0))-" & _
                "(select isnull((select sum(x.TotBudget) from ctebudget x group by x.Tahun,x.grup having x.Tahun=a.Tahun and x.Grup='2.0'),0))" & _
                "-(select isnull((select sum(x.TotBudget) from ctebudget x group by x.Tahun,x.grup having x.Tahun=a.Tahun and x.Grup='3.0'),0))" & _
                ") as TotBudget, 3.2 as Grup from ctebudget a group by Tahun " & _
                "union all " & _
                "select Tahun,'TOTAL BEBAN USAHA' as Aliasing, (" & _
                "(select isnull((select sum(x.TotBudget) from ctebudget x group by x.Tahun,x.grup having x.Tahun=a.Tahun and x.Grup='4.0'),0))" & _
                ") as TotBudget, 4.1 as Grup from ctebudget a group by Tahun " & _
                "union all " & _
                "select Tahun,'LABA-RUGI OPERASI' as Aliasing, (" & _
                "((select isnull((select sum(x.TotBudget) from ctebudget x group by x.Tahun,x.grup having x.Tahun=a.Tahun and x.Grup='1.0'),0))-" & _
                "(select isnull((select sum(x.TotBudget) from ctebudget x group by x.Tahun,x.grup having x.Tahun=a.Tahun and x.Grup='2.0'),0))" & _
                "-(select isnull((select sum(x.TotBudget) from ctebudget x group by x.Tahun,x.grup having x.Tahun=a.Tahun and x.Grup='3.0'),0)))" & _
                "-(select isnull((select sum(x.TotBudget) from ctebudget x group by x.Tahun,x.grup having x.Tahun=a.Tahun and x.Grup='4.0'),0))" & _
                ") as TotBudget, 4.2 as Grup from ctebudget a group by Tahun " & _
                "union all " & _
                "select Tahun,'TOTAL PENDAPATAN & BIAYA DILUAR USAHA' as Aliasing, (" & _
                "(select isnull((select sum(x.TotBudget) from ctebudget x group by x.Tahun,x.grup having x.Tahun=a.Tahun and x.Grup='5.0'),0))-" & _
                "(select isnull((select sum(x.TotBudget) from ctebudget x group by x.Tahun,x.grup having x.Tahun=a.Tahun and x.Grup='6.0'),0))" & _
                ") as TotBudget, 6.1 as Grup from ctebudget a group by Tahun " & _
                "union all " & _
                "select Tahun,'LABA-RUGI SEBELUM PAJAK' as Aliasing, (" & _
                "(((select isnull((select sum(x.TotBudget) from ctebudget x group by x.Tahun,x.grup having x.Tahun=a.Tahun and x.Grup='1.0'),0))-" & _
                "(select isnull((select sum(x.TotBudget) from ctebudget x group by x.Tahun,x.grup having x.Tahun=a.Tahun and x.Grup='2.0'),0))" & _
                "-(select isnull((select sum(x.TotBudget) from ctebudget x group by x.Tahun,x.grup having x.Tahun=a.Tahun and x.Grup='3.0'),0)))" & _
                "-(select isnull((select sum(x.TotBudget) from ctebudget x group by x.Tahun,x.grup having x.Tahun=a.Tahun and x.Grup='4.0'),0))+" & _
                "((select isnull((select sum(x.TotBudget) from ctebudget x group by x.Tahun,x.grup having x.Tahun=a.Tahun and x.Grup='5.0'),0))-" & _
                "(select isnull((select sum(x.TotBudget) from ctebudget x group by x.Tahun,x.grup having x.Tahun=a.Tahun and x.Grup='6.0'),0))))" & _
                ") as TotBudget, 6.2 as Grup from ctebudget a group by Tahun " & _
                "union all " & _
                "select Tahun,'LABA-RUGI SETELAH PAJAK' as Aliasing, (" & _
                "((((select isnull((select sum(x.TotBudget) from ctebudget x group by x.Tahun,x.grup having x.Tahun=a.Tahun and x.Grup='1.0'),0))-" & _
                "(select isnull((select sum(x.TotBudget) from ctebudget x group by x.Tahun,x.grup having x.Tahun=a.Tahun and x.Grup='2.0'),0))" & _
                "-(select isnull((select sum(x.TotBudget) from ctebudget x group by x.Tahun,x.grup having x.Tahun=a.Tahun and x.Grup='3.0'),0)))" & _
                "-(select isnull((select sum(x.TotBudget) from ctebudget x group by x.Tahun,x.grup having x.Tahun=a.Tahun and x.Grup='4.0'),0))+" & _
                "((select isnull((select sum(x.TotBudget) from ctebudget x group by x.Tahun,x.grup having x.Tahun=a.Tahun and x.Grup='5.0'),0))-" & _
                "(select isnull((select sum(x.TotBudget) from ctebudget x group by x.Tahun,x.grup having x.Tahun=a.Tahun and x.Grup='6.0'),0))))-" & _
                "(select isnull((select sum(x.TotBudget) from ctebudget x group by x.Tahun,x.grup having x.Tahun=a.Tahun and x.Grup='7.0'),0)))" & _
                ") as TotBudget, 7.1 as Grup from ctebudget a group by Tahun)," & _
                "cterealbudget as (" & _
                "select a.Tahun,a.Aliasing,a.Jumlah as Realisasi, b.TotBudget as Budget, a.Grup from ctejml a " & _
                "left join cteunion b on b.Tahun = a.Tahun and b.Aliasing = a.Aliasing)," & _
                "ctepivotrealisasi as(" & _
                "select P.Aliasing," & ctepivotrealisasistring & ",Grup from cterealbudget D " & _
                "PIVOT(Sum(Realisasi) FOR D.Tahun IN (" & tahunpivot & ")) P " & _
                "group by Aliasing,Grup)," & _
                "ctepivotbudget as(" & _
                "select P.Aliasing," & ctepivotbudgetstring & ",Grup from cterealbudget D " & _
                "PIVOT(Sum(Budget) FOR D.Tahun IN (" & tahunpivot & ")) P " & _
                "group by Aliasing,Grup)" & _
                "select a.Aliasing as Keterangan," & selectbudget & "," & _
                "a.Grup from ctepivotrealisasi a " & _
                "left join ctepivotbudget b on b.Aliasing = a.Aliasing and b.Grup = a.Grup order by Grup"

                    query2 = _
                    "IF OBJECT_ID('tempdb..#tmptmp') IS NOT NULL DROP TABLE #tmptmp; " & _
                    "DECLARE @BulanArr VARCHAR(50) " & _
                    "SET @BulanArr = '" & Strings.Left(bulan, bulan.Length - 1) & "'; " & _
                    "WITH cteLR AS (" & _
                    "SELECT CONVERT(VARCHAR(6),a.TanggalBukti,112) as TahunBulan,a.KodeCompany,a.KodeAkun,b.Keterangan," & _
                    "SUM(CASE WHEN a.DebetOrKredit<>b.DebetOrKredit THEN -a.Jumlah ELSE a.Jumlah END) AS Jumlah,b.DebetOrKredit AS DoK " & _
                    "FROM dbo.tbACJurnal a " & _
                    "LEFT JOIN dbo.tbACKodeAkun b ON b.KodeAkun=a.KodeAkun " & _
                    "WHERE CONVERT(VARCHAR(6),a.TanggalBukti,112) in (" & Strings.Left(tahunbulan, tahunbulan.Length - 1) & "" & _
                    ") AND a.KodeCompany in (" & kdcompany & ") AND b.IdKategori " & _
                    "IN (SELECT IdKategori FROM dbo.tbACKategori WHERE StatusLaporan='LR') " & _
                    "GROUP BY CONVERT(VARCHAR(6),a.TanggalBukti,112),a.KodeCompany,a.KodeAkun, b.Keterangan, b.DebetOrKredit), " & _
                    "ctepvot as(" & _
                    "SELECT aa.TahunBulan, aa.KodeCompany,dd.Aliasing as KeteranganAkun, aa.KodeAkun, aa.Keterangan,  aa.Dok, aa.Jumlah AS JumlahNPM, dd.grup " & _
                    "FROM cteLR AS aa " & _
                    "LEFT JOIN dbo.tbACKodeAkun cc ON aa.KodeAkun=cc.KodeAkun " & _
                    "LEFT JOIN dbo.tbACKategoriNPM dd ON cc.KodeAkun=dd.KodeAkun " & _
                    "WHERE NOT aa.KodeAkun IN " & _
                    "(aa.kodecompany+'.90.20.210',aa.kodecompany+'.90.20.971',aa.kodecompany+'.90.20.972',aa.kodecompany+'.90.20.973'," & _
                    "aa.kodecompany+'.90.20.974',aa.kodecompany+'.90.10.610',aa.kodecompany+'.90.10.620',aa.kodecompany+'.90.10.630',aa.kodecompany+'.60.01.100')) " & _
                    "select a.*, (" & _
                    "case when substring(TahunBulan,5,2) = '01' then b.Jan " & _
                    "when substring(TahunBulan,5,2) = '02' then b.Peb " & _
                    "when substring(TahunBulan,5,2) = '03' then b.Mar " & _
                    "when substring(TahunBulan,5,2) = '04' then b.Apr " & _
                    "when substring(TahunBulan,5,2) = '05' then b.Mei " & _
                    "when substring(TahunBulan,5,2) = '06' then b.Jun " & _
                    "when substring(TahunBulan,5,2) = '07' then b.Jul " & _
                    "when substring(TahunBulan,5,2) = '08' then b.Agt " & _
                    "when substring(TahunBulan,5,2) = '09' then b.Sep " & _
                    "when substring(TahunBulan,5,2) = '10' then b.Okt " & _
                    "when substring(TahunBulan,5,2) = '11' then b.Nop " & _
                    "when substring(TahunBulan,5,2) = '12' then b.Des " & _
                    "end) as Budget " & _
                    "from ctepvot a " & _
                    "left join tbACBudget b on a.KodeAkun = b.KodeAkun and substring(a.TahunBulan,1,4) = b.Tahun"
                End If
            ElseIf cTampilan.SelectedIndex = 1 Then
                If cJenisLaporan.SelectedIndex = 0 Then
                    query = _
              "IF OBJECT_ID('tempdb..#tmptable') IS NOT NULL DROP TABLE #tmptable;" & _
              "WITH cteLR AS " & _
              "(" & _
                  "SELECT " & _
                  "CONVERT(VARCHAR(6),a.TanggalBukti,112) as TahunBulan,a.KodeCompany," & _
                  "a.KodeAkun,b.Keterangan,SUM(CASE WHEN a.DebetOrKredit<>b.DebetOrKredit THEN -a.Jumlah ELSE a.Jumlah END) AS Jumlah," & _
                  "b.DebetOrKredit AS DoK " & _
                  "FROM dbo.tbACJurnal a " & _
                  "LEFT JOIN dbo.tbACKodeAkun b ON b.KodeAkun=a.KodeAkun " & _
                  "WHERE " & _
                  "CONVERT(VARCHAR(6),a.TanggalBukti,112) in (" & Strings.Left(tahunbulan, tahunbulan.Length - 1) & ") AND " & _
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
                          "aa.KodeCompany+'.60.01.100'," & _
                          "aa.kodecompany+'.90.10.630'" & _
                          ")" & _
              "), " & _
              "cteall as(" & _
                  "" & uniontanggal2 & ")," & _
              "cteall2 as(" & _
                  "select a.KodeCompany,a.TahunBulan,a.Aliasing, sum(isnull(b.JumlahNPM,0)) as JumlahNPM,a.Grup from cteall a " & _
                  "left join ctepvot b on b.Aliasing = a.Aliasing and b.TahunBulan = a.TahunBulan and b.KodeCompany = a.KodeCompany " & _
                  "group by a.Aliasing,a.Grup,a.TahunBulan,a.KodeCompany " & _
                  ") select * into #tmptable from cteall2; " & _
              "with ctegabung as(" & _
                  "select * from #tmptable " & _
                  "union all " & _
                  "select a.KodeCompany,a.TahunBulan,'PENDAPATAN BERSIH' as Aliasing,(" & _
                  "select isnull ((select sum(x.JumlahNPM) from #tmptable x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='1.0'),0))-" & _
                  "(select isnull((select sum(x.JumlahNPM) from #tmptable x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='2.0'),0)) " & _
                  "as Jumlah, 2.1 as Grup from #tmptable a group by a.TahunBulan, a.KodeCompany " & _
                  "union all " & _
                  "select a.KodeCompany,a.TahunBulan,'TOTAL HPP BARANG DAGANG' as Aliasing,(" & _
                  "select isnull((select sum(x.JumlahNPM) from #tmptable x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='3.0'),0)) as Jumlah, 3.1 as Grup " & _
                  "from #tmptable a group by a.TahunBulan, a.KodeCompany " & _
                  "union all " & _
                  "select a.KodeCompany,a.TahunBulan,'LABA-RUGI KOTOR' as Aliasing," & _
                  "((select isnull((select sum(x.JumlahNPM) from #tmptable x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='1.0'),0))-" & _
                  "(select isnull((select sum(x.JumlahNPM) from #tmptable x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='2.0'),0)))-" & _
                  "(select isnull((select sum(x.JumlahNPM) from #tmptable x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='3.0'),0)) as Jumlah, 3.2 as Grup " & _
                  "from #tmptable a group by a.TahunBulan, a.KodeCompany " & _
                  "union all " & _
                  "select a.KodeCompany,a.TahunBulan,'TOTAL BEBAN USAHA' as Aliasing," & _
                  "(select isnull((select sum(x.JumlahNPM) from #tmptable x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='4.0'),0)) as Jumlah, 4.1 as Grup " & _
                  "from #tmptable a group by a.TahunBulan, a.KodeCompany " & _
                  "union all " & _
                  "select a.KodeCompany,a.TahunBulan,'LABA-RUGI OPERASI' as Aliasing," & _
                  "(select isnull((select sum(x.JumlahNPM) from #tmptable x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='1.0'),0))-" & _
                  "(select isnull((select sum(x.JumlahNPM) from #tmptable x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='2.0'),0))-" & _
                  "(select isnull((select sum(x.JumlahNPM) from #tmptable x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='3.0'),0))-" & _
                  "(select isnull((select sum(x.JumlahNPM) from #tmptable x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='4.0'),0)) as Jumlah, 4.2 as Grup " & _
                  "from #tmptable a group by a.TahunBulan, a.KodeCompany " & _
                  "union all " & _
                  "select a.KodeCompany,a.TahunBulan,'TOTAL PENDAPATAN & BIAYA DILUAR USAHA' as Aliasing," & _
                  "(select isnull((select sum(x.JumlahNPM) from #tmptable x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='5.0'),0))-" & _
                  "(select isnull((select sum(x.JumlahNPM) from #tmptable x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='6.0'),0)) as Jumlah, 6.1 as Grup " & _
                  "from #tmptable a group by a.TahunBulan, a.KodeCompany " & _
                  "union all " & _
                  "select a.KodeCompany,a.TahunBulan,'LABA-RUGI SEBELUM PAJAK' as Aliasing," & _
                  "((select isnull((select sum(x.JumlahNPM) from #tmptable x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='1.0'),0))-" & _
                  "(select isnull((select sum(x.JumlahNPM) from #tmptable x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='2.0'),0))-" & _
                  "(select isnull((select sum(x.JumlahNPM) from #tmptable x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='3.0'),0))-" & _
                  "(select isnull((select sum(x.JumlahNPM) from #tmptable x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='4.0'),0)))+" & _
                  "(select isnull((select sum(x.JumlahNPM) from #tmptable x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='5.0'),0))-" & _
                  "(select isnull((select sum(x.JumlahNPM) from #tmptable x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='6.0'),0)) " & _
                  "as Jumlah, 6.2 as Grup " & _
                  "from #tmptable a group by a.TahunBulan, a.KodeCompany " & _
                  "union all " & _
                  "select a.KodeCompany,a.TahunBulan,'LABA-RUGI SETELAH PAJAK' as Aliasing," & _
                  "((select isnull((select sum(x.JumlahNPM) from #tmptable x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='1.0'),0))-" & _
                  "(select isnull((select sum(x.JumlahNPM) from #tmptable x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='2.0'),0))- " & _
                  "(select isnull((select sum(x.JumlahNPM) from #tmptable x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='3.0'),0))-" & _
                  "(select isnull((select sum(x.JumlahNPM) from #tmptable x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='4.0'),0)))+" & _
                  "(select isnull((select sum(x.JumlahNPM) from #tmptable x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='5.0'),0))-" & _
                  "(select isnull((select sum(x.JumlahNPM) from #tmptable x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='6.0'),0))-" & _
                  "(select isnull((select sum(x.JumlahNPM) from #tmptable x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='7.0'),0)) " & _
                  "as Jumlah, 7.1 as Grup " & _
                  "from #tmptable a group by a.TahunBulan, a.KodeCompany " & _
                  ") " & _
                  "select a.KodeCompany," & _
                    "(select NamaAlias from tbGNCompany x where x.KodeCompany = a.KodeCompany) as NamaCompany " & _
                    ",a.TahunBulan,a.Aliasing as Keterangan,a.JumlahNPM,a.Grup " & _
                    "from ctegabung a " & _
                    "order by a.KodeCompany,a.Grup,a.Aliasing,a.TahunBulan"

                    query2 = _
                        "WITH cteLR AS " & _
                        "(" & _
                        "SELECT " & _
                        "CONVERT(VARCHAR(6),a.TanggalBukti,112) as TahunBulan,a.KodeCompany," & _
                        "a.KodeAkun,b.Keterangan,SUM(CASE WHEN a.DebetOrKredit<>b.DebetOrKredit THEN -a.Jumlah ELSE a.Jumlah END) AS Jumlah," & _
                        "b.DebetOrKredit AS DoK " & _
                        "FROM dbo.tbACJurnal a " & _
                        "LEFT JOIN dbo.tbACKodeAkun b ON b.KodeAkun=a.KodeAkun " & _
                        "WHERE " & _
                        "CONVERT(VARCHAR(6),a.TanggalBukti,112) in (" & Strings.Left(tahunbulan, tahunbulan.Length - 1) & ") AND " & _
                        "a.KodeCompany in (" & kdcompany & ") " & _
                        "AND b.IdKategori IN (SELECT IdKategori FROM dbo.tbACKategori WHERE StatusLaporan='LR') " & _
                        "GROUP BY " & _
                        "CONVERT(VARCHAR(6),a.TanggalBukti,112)," & _
                        "a.KodeCompany," & _
                        "a.KodeAkun, b.Keterangan, b.DebetOrKredit" & _
                        ") " & _
                        "SELECT " & _
                            "aa.KodeCompany,aa.TahunBulan," & _
                            "(select NamaAlias from tbGNCompany x where x.KodeCompany = aa.KodeCompany) as NamaCompany," & _
                            "aa.KodeCompany,dd.Aliasing as KeteranganAkun, aa.KodeAkun, aa.Keterangan,  aa.Dok, " & _
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
                                "aa.KodeCompany+'.60.01.100'," & _
                                "aa.kodecompany+'.90.10.630'" & _
                                ") order by aa.KodeCompany,dd.Grup,dd.Aliasing,aa.TahunBulan"
                ElseIf cJenisLaporan.SelectedIndex = 1 Then
                    query = _
                    "IF OBJECT_ID('tempdb..#tmptmp') IS NOT NULL DROP TABLE #tmptmp; " & _
                    "IF OBJECT_ID('tempdb..#tmpall2') IS NOT NULL DROP TABLE #tmpall2; " & _
                    "DECLARE @BulanArr VARCHAR(50) SET @BulanArr = '" & Strings.Left(bulan, bulan.Length - 1) & "'; " & _
                    "WITH cteLR AS " & _
                    "(" & _
                    "SELECT " & _
                    "CONVERT(VARCHAR(6),a.TanggalBukti,112) as TahunBulan,a.KodeCompany," & _
                    "a.KodeAkun,b.Keterangan,SUM(CASE WHEN a.DebetOrKredit<>b.DebetOrKredit THEN -a.Jumlah ELSE a.Jumlah END) AS Jumlah," & _
                    "b.DebetOrKredit AS DoK " & _
                    "FROM dbo.tbACJurnal a " & _
                    "LEFT JOIN dbo.tbACKodeAkun b ON b.KodeAkun=a.KodeAkun " & _
                    "WHERE " & _
                    "CONVERT(VARCHAR(6),a.TanggalBukti,112) in (" & Strings.Left(tahunbulan, tahunbulan.Length - 1) & ") AND " & _
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
                          "aa.KodeCompany+'.60.01.100'," & _
                          "aa.kodecompany+'.90.10.630'" & _
                          ")" & _
                    "), " & _
                    "cteall as(" & _
                    "" & uniontanggal2 & ")," & _
                    "cteall2 as(" & _
                    "select a.KodeCompany,a.TahunBulan,a.Aliasing, sum(isnull(b.JumlahNPM,0)) as JumlahNPM,a.Grup from cteall a " & _
                    "left join ctepvot b on b.Aliasing = a.Aliasing and b.TahunBulan = a.TahunBulan and b.KodeCompany = a.KodeCompany " & _
                    "group by a.Aliasing,a.Grup,a.TahunBulan,a.KodeCompany " & _
                    ")," & _
                    "cteambilbudget as(" & _
                    "select a.*, (" & _
                    "case when substring(TahunBulan,5,2) = '01' then b.Jan " & _
                    "when substring(TahunBulan,5,2) = '02' then b.Peb " & _
                    "when substring(TahunBulan,5,2) = '03' then b.Mar " & _
                    "when substring(TahunBulan,5,2) = '04' then b.Apr " & _
                    "when substring(TahunBulan,5,2) = '05' then b.Mei " & _
                    "when substring(TahunBulan,5,2) = '06' then b.Jun " & _
                    "when substring(TahunBulan,5,2) = '07' then b.Jul " & _
                    "when substring(TahunBulan,5,2) = '08' then b.Agt " & _
                    "when substring(TahunBulan,5,2) = '09' then b.Sep " & _
                    "when substring(TahunBulan,5,2) = '10' then b.Okt " & _
                    "when substring(TahunBulan,5,2) = '11' then b.Nop " & _
                    "when substring(TahunBulan,5,2) = '12' then b.Des " & _
                    "end) as Budget " & _
                    "from ctepvot a " & _
                    "left join tbACBudget b on a.KodeAkun = b.KodeAkun and substring(a.TahunBulan,1,4) = b.Tahun) " & _
                    "select * into #tmpall2 from cteambilbudget;" & _
                    "with ctegabung as(" & _
                    "select KodeCompany,TahunBulan,Aliasing, sum(JumlahNPM) as JumlahNPM,sum(Budget) as Budget,Grup from #tmpall2 a group by Aliasing,Grup,TahunBulan,KodeCompany " & _
                    "union all " & _
                    "select a.KodeCompany,a.TahunBulan,'PENDAPATAN BERSIH' as Aliasing,(" & _
                    "select isnull ((select sum(x.JumlahNPM) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='1.0'),0))-(" & _
                    "select isnull((select sum(x.JumlahNPM) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='2.0'),0)) as JumlahNPM,(" & _
                    "select isnull ((select sum(x.Budget) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='1.0'),0))-(" & _
                    "select isnull((select sum(x.Budget) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='2.0'),0)),2.1 as Grup " & _
                    "from #tmpall2 a group by a.TahunBulan,a.KodeCompany " & _
                    "union all " & _
                    "select a.KodeCompany,a.TahunBulan,'TOTAL HPP BARANG DAGANG' as Aliasing,(" & _
                    "select isnull((select sum(x.JumlahNPM) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='3.0'),0)) as JumlahNPM, " & _
                    "(select isnull((select sum(x.Budget) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='3.0'),0)),3.1 as Grup " & _
                    "from #tmpall2 a group by a.TahunBulan,a.KodeCompany " & _
                    "union all " & _
                    "select a.KodeCompany,a.TahunBulan,'LABA-RUGI KOTOR' as Aliasing,((" & _
                    "select isnull((select sum(x.JumlahNPM) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='1.0'),0))-(" & _
                    "select isnull((select sum(x.JumlahNPM) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='2.0'),0)))-(" & _
                    "select isnull((select sum(x.JumlahNPM) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='3.0'),0)) as JumlahNPM, ((" & _
                    "select isnull((select sum(x.Budget) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='1.0'),0))-(" & _
                    "select isnull((select sum(x.Budget) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='2.0'),0)))-(" & _
                    "select isnull((select sum(x.Budget) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='3.0'),0)),3.2 as Grup " & _
                    "from #tmpall2 a group by a.TahunBulan,a.KodeCompany " & _
                    "union all " & _
                    "select a.KodeCompany,a.TahunBulan,'TOTAL BEBAN USAHA' as Aliasing,(" & _
                    "select isnull((select sum(x.JumlahNPM) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany " & _
                    "and x.Grup='4.0'),0)) as JumlahNPM,(" & _
                    "select isnull((select sum(x.Budget) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany " & _
                    "and x.Grup='4.0'),0)),4.1 as Grup from #tmpall2 a group by a.TahunBulan,a.KodeCompany " & _
                    "union all " & _
                    "select a.KodeCompany,a.TahunBulan,'LABA-RUGI OPERASI' as Aliasing,(" & _
                    "select isnull((select sum(x.JumlahNPM) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='1.0'),0))-(" & _
                    "select isnull((select sum(x.JumlahNPM) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='2.0'),0))-(" & _
                    "select isnull((select sum(x.JumlahNPM) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='3.0'),0))-(" & _
                    "select isnull((select sum(x.JumlahNPM) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='4.0'),0)) as JumlahNPM, (" & _
                    "select isnull((select sum(x.Budget) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='1.0'),0))-(" & _
                    "select isnull((select sum(x.Budget) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='2.0'),0))-(" & _
                    "select isnull((select sum(x.Budget) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='3.0'),0))-(" & _
                    "select isnull((select sum(x.Budget) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='4.0'),0)),4.2 as Grup " & _
                    "from #tmpall2 a group by a.TahunBulan,a.KodeCompany " & _
                    "union all " & _
                    "select a.KodeCompany,a.TahunBulan,'TOTAL PENDAPATAN & BIAYA DILUAR USAHA' as Aliasing,(" & _
                    "select isnull((select sum(x.JumlahNPM) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='5.0'),0))-(" & _
                    "select isnull((select sum(x.JumlahNPM) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='6.0'),0)) as JumlahNPM, (" & _
                    "select isnull((select sum(x.Budget) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='5.0'),0))-(" & _
                    "select isnull((select sum(x.Budget) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='6.0'),0)),6.1 as Grup " & _
                    "from #tmpall2 a group by a.TahunBulan,a.KodeCompany " & _
                    "union all " & _
                    "select a.KodeCompany,a.TahunBulan,'LABA-RUGI SEBELUM PAJAK' as Aliasing,((" & _
                    "select isnull((select sum(x.JumlahNPM) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='1.0'),0))-(" & _
                    "select isnull((select sum(x.JumlahNPM) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='2.0'),0))-(" & _
                    "select isnull((select sum(x.JumlahNPM) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='3.0'),0))-(" & _
                    "select isnull((select sum(x.JumlahNPM) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='4.0'),0)))+(" & _
                    "select isnull((select sum(x.JumlahNPM) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='5.0'),0))-(" & _
                    "select isnull((select sum(x.JumlahNPM) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='6.0'),0)) as JumlahNPM, ((" & _
                    "select isnull((select sum(x.Budget) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='1.0'),0))-(" & _
                    "select isnull((select sum(x.Budget) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='2.0'),0))-(" & _
                    "select isnull((select sum(x.Budget) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='3.0'),0))-(" & _
                    "select isnull((select sum(x.Budget) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='4.0'),0)))+(" & _
                    "select isnull((select sum(x.Budget) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='5.0'),0))-(" & _
                    "select isnull((select sum(x.Budget) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='6.0'),0)),6.2 as Grup " & _
                    "from #tmpall2 a group by a.TahunBulan,a.KodeCompany " & _
                    "union all " & _
                    "select a.KodeCompany,a.TahunBulan,'LABA-RUGI SETELAH PAJAK' as Aliasing,((" & _
                    "select isnull((select sum(x.JumlahNPM) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='1.0'),0))-(" & _
                    "select isnull((select sum(x.JumlahNPM) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='2.0'),0))- (" & _
                    "select isnull((select sum(x.JumlahNPM) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='3.0'),0))-(" & _
                    "select isnull((select sum(x.JumlahNPM) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='4.0'),0)))+(" & _
                    "select isnull((select sum(x.JumlahNPM) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='5.0'),0))-(" & _
                    "select isnull((select sum(x.JumlahNPM) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='6.0'),0))-(" & _
                    "select isnull((select sum(x.JumlahNPM) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='7.0'),0)) as Jumlah, ((" & _
                    "select isnull((select sum(x.Budget) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='1.0'),0))-(" & _
                    "select isnull((select sum(x.Budget) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='2.0'),0))- (" & _
                    "select isnull((select sum(x.Budget) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='3.0'),0))-(" & _
                    "select isnull((select sum(x.Budget) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='4.0'),0)))+(" & _
                    "select isnull((select sum(x.Budget) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='5.0'),0))-(" & _
                    "select isnull((select sum(x.Budget) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='6.0'),0))-(" & _
                    "select isnull((select sum(x.Budget) from #tmpall2 x group by x.TahunBulan,x.grup,x.KodeCompany having x.TahunBulan=a.TahunBulan and x.KodeCompany = a.KodeCompany and x.Grup='7.0'),0)),7.1 as Grup " & _
                    "from #tmpall2 a group by a.TahunBulan,a.KodeCompany) " & _
                    "select * into #tmptmp from ctegabung; " & _
                    "select a.KodeCompany," & _
                    "(select NamaAlias from tbGNCompany x where x.KodeCompany = a.KodeCompany) as NamaCompany," & _
                    "a.TahunBulan,a.Aliasing as Keterangan,a.JumlahNPM,a.Budget,a.Grup " & _
                    "from #tmptmp a order by a.KodeCompany,a.Grup,a.Aliasing,a.TahunBulan"

                    query2 = _
                        "IF OBJECT_ID('tempdb..#tmpall2') IS NOT NULL DROP TABLE #tmpall2; " & _
                        "DECLARE @BulanArr VARCHAR(50) SET @BulanArr = '" & Strings.Left(bulan, bulan.Length - 1) & "'; " & _
                        "WITH cteLR AS " & _
                        "(" & _
                        "SELECT " & _
                        "CONVERT(VARCHAR(6),a.TanggalBukti,112) as TahunBulan,a.KodeCompany," & _
                        "a.KodeAkun,b.Keterangan,SUM(CASE WHEN a.DebetOrKredit<>b.DebetOrKredit THEN -a.Jumlah ELSE a.Jumlah END) AS Jumlah," & _
                        "b.DebetOrKredit AS DoK " & _
                        "FROM dbo.tbACJurnal a " & _
                        "LEFT JOIN dbo.tbACKodeAkun b ON b.KodeAkun=a.KodeAkun " & _
                        "WHERE " & _
                        "CONVERT(VARCHAR(6),a.TanggalBukti,112) in (" & Strings.Left(tahunbulan, tahunbulan.Length - 1) & ") AND " & _
                        "a.KodeCompany in (" & kdcompany & ") " & _
                        "AND b.IdKategori IN (SELECT IdKategori FROM dbo.tbACKategori WHERE StatusLaporan='LR') " & _
                        "GROUP BY " & _
                        "CONVERT(VARCHAR(6),a.TanggalBukti,112)," & _
                        "a.KodeCompany," & _
                        "a.KodeAkun, b.Keterangan, b.DebetOrKredit" & _
                        "), " & _
                        "ctepvot as(SELECT " & _
                            "aa.TahunBulan, aa.KodeCompany, dd.Aliasing, aa.KodeAkun, aa.Keterangan,  aa.Dok, " & _
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
                                "aa.KodeCompany+'.60.01.100'," & _
                                "aa.kodecompany+'.90.10.630'" & _
                                ")), " & _
                    "cteall as(" & _
                    "" & uniontanggal2 & ")," & _
                    "cteall2 as(" & _
                    "select a.KodeCompany,a.TahunBulan,a.Aliasing, sum(isnull(b.JumlahNPM,0)) as JumlahNPM,a.Grup from cteall a " & _
                    "left join ctepvot b on b.Aliasing = a.Aliasing and b.TahunBulan = a.TahunBulan and b.KodeCompany = a.KodeCompany " & _
                    "group by a.Aliasing,a.Grup,a.TahunBulan,a.KodeCompany" & _
                    ")," & _
                    "cteambilbudget as(" & _
                    "select a.*, (" & _
                    "case when substring(TahunBulan,5,2) = '01' then b.Jan " & _
                    "when substring(TahunBulan,5,2) = '02' then b.Peb " & _
                    "when substring(TahunBulan,5,2) = '03' then b.Mar " & _
                    "when substring(TahunBulan,5,2) = '04' then b.Apr " & _
                    "when substring(TahunBulan,5,2) = '05' then b.Mei " & _
                    "when substring(TahunBulan,5,2) = '06' then b.Jun " & _
                    "when substring(TahunBulan,5,2) = '07' then b.Jul " & _
                    "when substring(TahunBulan,5,2) = '08' then b.Agt " & _
                    "when substring(TahunBulan,5,2) = '09' then b.Sep " & _
                    "when substring(TahunBulan,5,2) = '10' then b.Okt " & _
                    "when substring(TahunBulan,5,2) = '11' then b.Nop " & _
                    "when substring(TahunBulan,5,2) = '12' then b.Des " & _
                    "end) as Budget " & _
                    "from ctepvot a " & _
                    "left join tbACBudget b on a.KodeAkun = b.KodeAkun and substring(a.TahunBulan,1,4) = b.Tahun) " & _
                    "select * into #tmpall2 from cteambilbudget; " & _
                    "select a.KodeCompany," & _
                    "(select NamaAlias from tbGNCompany x where x.KodeCompany = a.KodeCompany) as NamaCompany," & _
                    "a.TahunBulan,a.Aliasing as KeteranganAkun,a.KodeAkun,a.Keterangan,a.DoK,a.JumlahNPM,a.Budget,a.grup " & _
                    "from #tmpall2 a order by a.KodeCompany,a.Grup,a.Aliasing,a.TahunBulan"
                End If
            End If

            'Data1
            Using sqlcon As New Data.SqlClient.SqlConnection(tJenis.Text)
                sqlcon.Open()
                Dim sqlCmd = New Data.SqlClient.SqlCommand( _
                                query, _
                                sqlcon)
                sqlCmd.CommandTimeout = 0
                Dim adp As New SqlDataAdapter(sqlCmd)
                adp.Fill(dt1)
            End Using
            'add key1

            If cTampilan.SelectedIndex = 0 Then
                Dim primaryKey1(0) As DataColumn
                primaryKey1(0) = dt1.Columns("Keterangan")
                dt1.PrimaryKey = primaryKey1
            ElseIf cTampilan.SelectedIndex = 1 Then
                Dim primaryKey1(3) As DataColumn
                primaryKey1(0) = dt1.Columns("KodeCompany")
                primaryKey1(1) = dt1.Columns("TahunBulan")
                primaryKey1(2) = dt1.Columns("Keterangan")
            End If

            'Data2
            Using sqlcon As New Data.SqlClient.SqlConnection(tJenis.Text)
                sqlcon.Open()
                Dim sqlCmd = New Data.SqlClient.SqlCommand(query2, sqlcon)
                sqlCmd.CommandTimeout = 0
                Dim adp As New SqlDataAdapter(sqlCmd)
                adp.Fill(dt2)
            End Using

            ds.Tables.Add(dt1)
            ds.Tables.Add(dt2)

            If cTampilan.SelectedIndex = 0 Then
                ds.Relations.Add("Aliasing", dt1.Columns("Keterangan"), dt2.Columns("KeteranganAkun"))
            ElseIf cTampilan.SelectedIndex = 1 Then
                Dim dRelations As DataRelation = New DataRelation("Aliasing", _
                        {dt1.Columns("Keterangan"), dt1.Columns("KodeCompany"), dt1.Columns("TahunBulan")}, _
                        {dt2.Columns("KeteranganAkun"), dt2.Columns("KodeCompany"), dt2.Columns("TahunBulan")})
                ds.Relations.Add(dRelations)
            End If

            gcDetail.DataSource = ds.Tables(1)
            GridView4.BestFitColumns()
            FormatGridView(GridView4, , , True)
            GridView4.Columns("grup").Visible = False
            GridView4.Columns("KeteranganAkun").Width = 200
            GridView4.Columns("Keterangan").Width = 200
            GridView4.Columns("JumlahNPM").Width = 250
            GridView4.OptionsView.ShowGroupPanel = False
            'reFormatColumns(GridView4)
            SetFooterSummarySUMs(GridView4, {"JumlahNPM"})
            GridView4.Columns("JumlahNPM").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GridView4.Columns("JumlahNPM").DisplayFormat.FormatString = "c2"
            If cJenisLaporan.SelectedIndex = 1 Then
                SetFooterSummarySUMs(GridView4, {"JumlahNPM", "Budget"})
                GridView4.Columns("Budget").Width = 250
                GridView4.Columns("Budget").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView4.Columns("Budget").DisplayFormat.FormatString = "c2"
            End If

            GridControl1.DataSource = ds.Tables("table1")
            GridView1.BestFitColumns()
            FormatGridView(GridView1, , , True)
            GridView1.Columns("Grup").Visible = False
            GridView1.Columns("Keterangan").Width = 500

            If cTampilan.SelectedIndex = 0 Then
                GridView1.Columns("Realisasi" & Format(dTahun1.EditValue, "yyyy") & "").Width = 200
                GridView1.Columns("Realisasi" & Format(dTahun1.EditValue, "yyyy") & "").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView1.Columns("Realisasi" & Format(dTahun1.EditValue, "yyyy") & "").DisplayFormat.FormatString = "c2"

                If cJenisLaporan.SelectedIndex = 0 Then
                    GridView1.Columns("Rata" & Format(dTahun1.EditValue, "yyyy") & "").Width = 200
                    GridView1.Columns("Persen" & Format(dTahun1.EditValue, "yyyy") & "").Width = 100
                    GridView1.Columns("Rata" & Format(dTahun1.EditValue, "yyyy") & "").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GridView1.Columns("Rata" & Format(dTahun1.EditValue, "yyyy") & "").DisplayFormat.FormatString = "c2"
                    GridView1.Columns("Persen" & Format(dTahun1.EditValue, "yyyy") & "").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GridView1.Columns("Persen" & Format(dTahun1.EditValue, "yyyy") & "").DisplayFormat.FormatString = "n2"

                ElseIf cJenisLaporan.SelectedIndex = 1 Then
                    GridView1.Columns("Budget" & Format(dTahun1.EditValue, "yyyy") & "").Width = 200
                    GridView1.Columns("%RealisasiVsBudget" & Format(dTahun1.EditValue, "yyyy") & "").Width = 200
                    GridView1.Columns("Budget" & Format(dTahun1.EditValue, "yyyy") & "").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GridView1.Columns("Budget" & Format(dTahun1.EditValue, "yyyy") & "").DisplayFormat.FormatString = "c2"
                    GridView1.Columns("%RealisasiVsBudget" & Format(dTahun1.EditValue, "yyyy") & "").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GridView1.Columns("%RealisasiVsBudget" & Format(dTahun1.EditValue, "yyyy") & "").DisplayFormat.FormatString = "n2"
                End If

                If cTahun2.Checked = True And cTahun3.Checked = True Then
                    GridView1.Columns("Realisasi" & Format(dTahun2.EditValue, "yyyy") & "").Width = 200
                    GridView1.OptionsView.ShowGroupPanel = False
                    GridView1.Columns("Realisasi" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GridView1.Columns("Realisasi" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatString = "c2"

                    GridView1.Columns("Realisasi" & Format(dTahun3.EditValue, "yyyy") & "").Width = 300
                    GridView1.Columns("Realisasi" & Format(dTahun3.EditValue, "yyyy") & "").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GridView1.Columns("Realisasi" & Format(dTahun3.EditValue, "yyyy") & "").DisplayFormat.FormatString = "c2"

                    If cJenisLaporan.SelectedIndex = 0 Then
                        GridView1.Columns("Rata" & Format(dTahun2.EditValue, "yyyy") & "").Width = 200
                        GridView1.Columns("Persen" & Format(dTahun2.EditValue, "yyyy") & "").Width = 100
                        GridView1.Columns("Selisih" & Format(dTahun1.EditValue, "yyyy") & "-" & Format(dTahun2.EditValue, "yyyy") & "").Width = 200

                        GridView1.Columns("Rata" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridView1.Columns("Rata" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatString = "c2"
                        GridView1.Columns("Selisih" & Format(dTahun1.EditValue, "yyyy") & "-" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridView1.Columns("Selisih" & Format(dTahun1.EditValue, "yyyy") & "-" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatString = "c2"
                        GridView1.Columns("Persen" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridView1.Columns("Persen" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatString = "n2"

                        GridView1.Columns("Rata" & Format(dTahun3.EditValue, "yyyy") & "").Width = 200
                        GridView1.Columns("Persen" & Format(dTahun3.EditValue, "yyyy") & "").Width = 100
                        GridView1.Columns("Selisih" & Format(dTahun2.EditValue, "yyyy") & "-" & Format(dTahun3.EditValue, "yyyy") & "").Width = 200

                        GridView1.Columns("Rata" & Format(dTahun3.EditValue, "yyyy") & "").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridView1.Columns("Rata" & Format(dTahun3.EditValue, "yyyy") & "").DisplayFormat.FormatString = "c2"
                        GridView1.Columns("Persen" & Format(dTahun3.EditValue, "yyyy") & "").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridView1.Columns("Persen" & Format(dTahun3.EditValue, "yyyy") & "").DisplayFormat.FormatString = "n2"
                        GridView1.Columns("Selisih" & Format(dTahun2.EditValue, "yyyy") & "-" & Format(dTahun3.EditValue, "yyyy") & "").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridView1.Columns("Selisih" & Format(dTahun2.EditValue, "yyyy") & "-" & Format(dTahun3.EditValue, "yyyy") & "").DisplayFormat.FormatString = "c2"
                    ElseIf cJenisLaporan.SelectedIndex = 1 Then
                        GridView1.Columns("Budget" & Format(dTahun2.EditValue, "yyyy") & "").Width = 200
                        GridView1.Columns("%RealisasiVsBudget" & Format(dTahun2.EditValue, "yyyy") & "").Width = 200
                        GridView1.Columns("Budget" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridView1.Columns("Budget" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatString = "c2"
                        GridView1.Columns("%RealisasiVsBudget" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridView1.Columns("%RealisasiVsBudget" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatString = "n2"

                        GridView1.Columns("Budget" & Format(dTahun3.EditValue, "yyyy") & "").Width = 200
                        GridView1.Columns("%RealisasiVsBudget" & Format(dTahun3.EditValue, "yyyy") & "").Width = 200

                        GridView1.Columns("Budget" & Format(dTahun3.EditValue, "yyyy") & "").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridView1.Columns("Budget" & Format(dTahun3.EditValue, "yyyy") & "").DisplayFormat.FormatString = "c2"
                        GridView1.Columns("%RealisasiVsBudget" & Format(dTahun3.EditValue, "yyyy") & "").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridView1.Columns("%RealisasiVsBudget" & Format(dTahun3.EditValue, "yyyy") & "").DisplayFormat.FormatString = "n2"
                    End If

                ElseIf cTahun2.Checked = True And cTahun3.Checked = False Then
                    GridView1.Columns("Realisasi" & Format(dTahun2.EditValue, "yyyy") & "").Width = 300
                    GridView1.Columns("Realisasi" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GridView1.Columns("Realisasi" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatString = "c2"

                    If cJenisLaporan.SelectedIndex = 0 Then
                        GridView1.Columns("Rata" & Format(dTahun2.EditValue, "yyyy") & "").Width = 200
                        GridView1.Columns("Persen" & Format(dTahun2.EditValue, "yyyy") & "").Width = 100
                        GridView1.Columns("Selisih" & Format(dTahun1.EditValue, "yyyy") & "-" & Format(dTahun2.EditValue, "yyyy") & "").Width = 200
                        GridView1.Columns("Rata" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridView1.Columns("Rata" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatString = "c2"
                        GridView1.Columns("Selisih" & Format(dTahun1.EditValue, "yyyy") & "-" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridView1.Columns("Selisih" & Format(dTahun1.EditValue, "yyyy") & "-" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatString = "c2"
                        GridView1.Columns("Persen" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridView1.Columns("Persen" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatString = "n2"

                    ElseIf cJenisLaporan.SelectedIndex = 1 Then
                        GridView1.Columns("Budget" & Format(dTahun2.EditValue, "yyyy") & "").Width = 200
                        GridView1.Columns("%RealisasiVsBudget" & Format(dTahun2.EditValue, "yyyy") & "").Width = 200
                        GridView1.Columns("Budget" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridView1.Columns("Budget" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatString = "c2"
                        GridView1.Columns("%RealisasiVsBudget" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridView1.Columns("%RealisasiVsBudget" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatString = "n2"
                    End If
                Else
                    If cJenisLaporan.SelectedIndex = 0 Then
                        GridView1.Columns("Selisih").Width = 200
                        GridView1.Columns("Selisih").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridView1.Columns("Selisih").DisplayFormat.FormatString = "c2"
                    End If
                End If

            Else
                GridView1.Columns("NamaCompany").Width = 200
                GridView1.Columns("JumlahNPM").Width = 200
                GridView1.Columns("JumlahNPM").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView1.Columns("JumlahNPM").DisplayFormat.FormatString = "c2"
                If cJenisLaporan.SelectedIndex = 1 Then
                    GridView1.Columns("Budget").Width = 200
                    GridView1.Columns("Budget").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GridView1.Columns("Budget").DisplayFormat.FormatString = "c2"
                End If
            End If
            GridView1.OptionsView.ShowGroupPanel = False

            GridControl1.LevelTree.Nodes.Clear()
            GridControl1.LevelTree.Nodes.Add("Aliasing", GridView2)
            GridView2.PopulateColumns(ds.Tables("table2"))
            GridView2.BestFitColumns()
            FormatGridView(GridView2, , , True)
            GridView2.Columns("grup").Visible = False
            GridView2.Columns("KeteranganAkun").Width = 200
            GridView2.Columns("KeteranganAkun").Width = 200
            GridView2.Columns("JumlahNPM").Width = 250
            GridView2.OptionsView.ShowGroupPanel = False
            'reFormatColumns(GridView2)
            SetFooterSummarySUMs(GridView2, {"JumlahNPM"})
            GridView2.Columns("JumlahNPM").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GridView2.Columns("JumlahNPM").DisplayFormat.FormatString = "c2"

            If cJenisLaporan.SelectedIndex = 1 Then
                SetFooterSummarySUMs(GridView2, {"JumlahNPM", "Budget"})
                GridView2.Columns("Budget").Width = 250
                GridView2.Columns("Budget").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView2.Columns("Budget").DisplayFormat.FormatString = "c2"
            End If
        End If
        GridView1.HideLoadingPanel()
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridView1_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles GridView1.CustomDrawCell
        If Not Strings.Right(GridView1.GetRowCellValue(e.RowHandle, "Grup"), 1) = "0" Then
            e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
        End If
    End Sub

    Private Sub cCompany_ItemCheck(sender As Object, e As DevExpress.XtraEditors.Controls.ItemCheckEventArgs)
        'Dim nmtable As String = Strings.Right(cCompany.SelectedItem.ToString, 2)

        'Dim drow() As DataRow = datatabel.Select("KodeCompany = '" & nmtable & "'")
        'drow(0)!cek = e.State
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
            GridView1.OptionsPrint.PrintDetails = False

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
            GridView4.OptionsPrint.PrintDetails = True

            Dim options As New XlsxExportOptionsEx
            options.ExportType = ExportType.WYSIWYG

            GridView4.ExportToXlsx(saveFileDialog1.FileName, options)
        End If
    End Sub

    Private Sub cCheckAll_CheckedChanged(sender As Object, e As EventArgs)
        'Dim datacompany As DataTable = TryCast(cCompany.DataSource, DataTable)
        'Dim centang As Boolean = False
        'If cCheckAll.Checked = False Then
        '    centang = False
        'Else
        '    centang = True
        'End If

        'For i = 0 To datatabel.Rows.Count - 1
        '    cCompany.SetItemChecked(i, centang)
        '    Dim drow() As DataRow = datatabel.Select("KodeCompany = '" & Strings.Right(datatabel.Rows(i).Item("KodeCompany"), 2) & "'")
        '    drow(0)!cek = centang
        'Next
    End Sub

    'Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
    '    Dim a As Integer = cBulan.CheckedItemsCount
    '    a = a
    '    Dim anu As String = ""
    '    For j = 0 To a - 1
    '        anu += cBulan.CheckedItems.Item(j).ToString
    '    Next
    'End Sub

    Private Sub cCheckAllBulan_CheckedChanged(sender As Object, e As EventArgs) Handles cCheckAllBulan.CheckedChanged
        Dim centang As Boolean = False
        If cCheckAllBulan.Checked = False Then
            centang = False
        Else
            centang = True
        End If

        For i = 0 To cBulan.ItemCount - 1
            cBulan.SetItemChecked(i, centang)
        Next
    End Sub

    Private Sub cTahun2_CheckedChanged(sender As Object, e As EventArgs) Handles cTahun2.CheckedChanged
        If cTahun2.Checked = True Then
            dTahun2.Enabled = True
            dTahun2.EditValue = DateAdd(DateInterval.Year, 1, dTahun1.EditValue)
        Else
            cTahun3.Checked = False
            dTahun2.Enabled = False
        End If
    End Sub

    Private Sub cTahun3_CheckedChanged(sender As Object, e As EventArgs) Handles cTahun3.CheckedChanged
        If cTahun3.Checked = True Then
            If cTahun2.Checked = False Then
                MsgBox("Untuk Menggunakan Tahun3 maka Tahun 2 Harus digunakan!", vbCritical + vbOKOnly, "Peringatan")
                dTahun3.Enabled = False
                cTahun2.Checked = True
                cTahun3.Checked = False
            Else
                dTahun3.Enabled = True
                dTahun3.EditValue = DateAdd(DateInterval.Year, 1, dTahun2.EditValue)
            End If
        Else
            dTahun3.Enabled = False
        End If
    End Sub

    Private Sub dTahun1_EditValueChanged(sender As Object, e As EventArgs) Handles dTahun1.EditValueChanged
        If cTahun2.Checked = True Then
            If dTahun1.EditValue >= dTahun2.EditValue Then
                MsgBox("Tahun 1 Tidak Boleh Lebih dari Tahun 2!", vbCritical + vbOKOnly, "Peringatan")
                dTahun2.EditValue = DateAdd(DateInterval.Year, 1, dTahun1.EditValue)
            End If
        End If
    End Sub

    Private Sub dTahun2_EditValueChanged(sender As Object, e As EventArgs) Handles dTahun2.EditValueChanged
        If cTahun2.Checked = True Then
            If cTahun3.Checked = False Then
                If dTahun2.EditValue <= dTahun1.EditValue Then
                    MsgBox("Tahun 2 Tidak Boleh Kurang dari Tahun 1!", vbCritical + vbOKOnly, "Peringatan")
                    dTahun2.EditValue = DateAdd(DateInterval.Year, 1, dTahun1.EditValue)
                End If
            Else
                If Not dTahun2.EditValue >= dTahun3.EditValue And Not dTahun2.EditValue <= dTahun1.EditValue Then
                    MsgBox("Tahun 2 Tidak Boleh Kurang dari Tahun 1 dan Lebih dari Tahun 3!", vbCritical + vbOKOnly, "Peringatan")
                    dTahun2.EditValue = DateAdd(DateInterval.Year, 1, dTahun1.EditValue)
                ElseIf Not dTahun2.EditValue < dTahun3.EditValue Then
                    MsgBox("Tahun 2 Tidak Boleh Lebih dari Tahun 3!", vbCritical + vbOKOnly, "Peringatan")
                    dTahun2.EditValue = DateAdd(DateInterval.Year, -1, dTahun3.EditValue)
                ElseIf Not dTahun2.EditValue > dTahun1.EditValue Then
                    MsgBox("Tahun 2 Tidak Boleh Kurang dari Tahun 1!", vbCritical + vbOKOnly, "Peringatan")
                    dTahun2.EditValue = DateAdd(DateInterval.Year, 1, dTahun1.EditValue)
                End If
            End If
        End If
    End Sub

    Private Sub dTahun3_EditValueChanged(sender As Object, e As EventArgs) Handles dTahun3.EditValueChanged
        If cTahun3.Checked = True Then
            If dTahun3.EditValue <= dTahun2.EditValue Then
                MsgBox("Tahun 3 Tidak Boleh Kurang dari Tahun 2!", vbCritical + vbOKOnly, "Peringatan")
                dTahun3.EditValue = DateAdd(DateInterval.Year, 1, dTahun2.EditValue)
            End If
        End If
    End Sub

    Private Sub GridView5_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs)
        'If Not Strings.Right(GridView5.GetRowCellValue(e.RowHandle, "Grup"), 1) = "0" Then
        '    e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
        'End If
    End Sub
End Class