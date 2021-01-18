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
        'cKdCompany.FirstInit(tJenis.Text, "Select KodeCompany,Nama from tbGNCompany", {tNama}, , , , , , {0.5, 1})
        Dim qucompany As String = "Select 0 as cek,KodeCompany,NamaAlias from tbGNCompany"
        da = New SqlDataAdapter(qucompany, kon)
        datatabel.Clear()
        da.Fill(datatabel)

        cCompany.Items.Clear()
        Dim dtTablename As DataTable = datatabel.DefaultView.ToTable(True, {"cek", "KodeCompany", "NamaAlias"})
        For i As Integer = 0 To dtTablename.Rows.Count - 1
            Dim kode As String = dtTablename.Rows(i)!NamaAlias & " - " & dtTablename.Rows(i)!KodeCompany
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
        ElseIf cBulan.CheckedItemsCount = 0 Then
            MsgBox("Pilih Bulan Terlebih Dahulu!", vbCritical + vbOKOnly, "Peringatan")
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

            Dim bulan As String = ""
            For j = 0 To cBulan.CheckedItemsCount - 1
                bulan += "" & cBulan.CheckedItems.Item(j).ToString & ","
            Next
            Dim jmlbulan As Integer = Strings.Split(bulan, ",").Length - 1

            Dim tahun As String = "" & Format(dTahun1.EditValue, "yyyy") & ","
            Dim tahunpivot As String = "[" & Format(dTahun1.EditValue, "yyyy") & "]"
            Dim ctepivotrealisasistring As String = "sum(isnull(p.[" & Format(dTahun1.EditValue, "yyyy") & "],0)) as Realisasi" & Format(dTahun1.EditValue, "yyyy") & ""
            Dim ctepivotratastring As String = "sum(isnull(p.[" & Format(dTahun1.EditValue, "yyyy") & "],0)) as Rata" & Format(dTahun1.EditValue, "yyyy") & ""
            Dim ctepivotpersenstring As String = "sum(isnull(p.[" & Format(dTahun1.EditValue, "yyyy") & "],0)) as Persen" & Format(dTahun1.EditValue, "yyyy") & ""
            Dim selecttahun As String = "a.Realisasi" & Format(dTahun1.EditValue, "yyyy") & ",b.Rata" & Format(dTahun1.EditValue, "yyyy") & ",c.Persen" & Format(dTahun1.EditValue, "yyyy") & ", 0 as Selisih"
            If cTahun2.Checked = True Then
                tahun += "" & Format(dTahun2.EditValue, "yyyy") & ","
                tahunpivot += ",[" & Format(dTahun2.EditValue, "yyyy") & "]"
                ctepivotrealisasistring += ",sum(isnull(p.[" & Format(dTahun2.EditValue, "yyyy") & "],0)) as Realisasi" & Format(dTahun2.EditValue, "yyyy") & ""
                ctepivotratastring += ",sum(isnull(p.[" & Format(dTahun2.EditValue, "yyyy") & "],0)) as Rata" & Format(dTahun2.EditValue, "yyyy") & ""
                ctepivotpersenstring += ",sum(isnull(p.[" & Format(dTahun2.EditValue, "yyyy") & "],0)) as Persen" & Format(dTahun2.EditValue, "yyyy") & ""
                selecttahun = _
                    "a.Realisasi" & Format(dTahun1.EditValue, "yyyy") & ",a.Realisasi" & Format(dTahun2.EditValue, "yyyy") & ",b.Rata" & Format(dTahun1.EditValue, "yyyy") & ",c.Persen" & Format(dTahun1.EditValue, "yyyy") & ",b.Rata" & Format(dTahun2.EditValue, "yyyy") & ",c.Persen" & Format(dTahun2.EditValue, "yyyy") & "," & _
                    "case when b.Rata" & Format(dTahun1.EditValue, "yyyy") & " = 0 or b.Rata" & Format(dTahun2.EditValue, "yyyy") & " = 0 then 0 else ((b.Rata" & Format(dTahun2.EditValue, "yyyy") & "-b.Rata" & Format(dTahun1.EditValue, "yyyy") & ") / b.Rata" & Format(dTahun1.EditValue, "yyyy") & "* 100) end as [Selisih" & Format(dTahun1.EditValue, "yyyy") & "-" & Format(dTahun2.EditValue, "yyyy") & "]"
            End If
            If cTahun3.Checked = True Then
                tahun += "" & Format(dTahun3.EditValue, "yyyy") & ","
                tahunpivot += ",[" & Format(dTahun3.EditValue, "yyyy") & "]"
                ctepivotrealisasistring += ",sum(isnull(p.[" & Format(dTahun3.EditValue, "yyyy") & "],0)) as Realisasi" & Format(dTahun3.EditValue, "yyyy") & ""
                ctepivotratastring += ",sum(isnull(p.[" & Format(dTahun3.EditValue, "yyyy") & "],0)) as Rata" & Format(dTahun3.EditValue, "yyyy") & ""
                ctepivotpersenstring += ",sum(isnull(p.[" & Format(dTahun3.EditValue, "yyyy") & "],0)) as Persen" & Format(dTahun3.EditValue, "yyyy") & ""
                selecttahun = _
                    "a.Realisasi" & Format(dTahun1.EditValue, "yyyy") & ",a.Realisasi" & Format(dTahun2.EditValue, "yyyy") & ",a.Realisasi" & Format(dTahun3.EditValue, "yyyy") & ",b.Rata" & Format(dTahun1.EditValue, "yyyy") & ",c.Persen" & Format(dTahun1.EditValue, "yyyy") & ",b.Rata" & Format(dTahun2.EditValue, "yyyy") & ",c.Persen" & Format(dTahun2.EditValue, "yyyy") & ",b.Rata" & Format(dTahun3.EditValue, "yyyy") & ",c.Persen" & Format(dTahun3.EditValue, "yyyy") & "," & _
                    "case when b.Rata" & Format(dTahun1.EditValue, "yyyy") & " = 0 or b.Rata" & Format(dTahun2.EditValue, "yyyy") & " = 0 then 0 else ((b.Rata" & Format(dTahun2.EditValue, "yyyy") & "-b.Rata" & Format(dTahun1.EditValue, "yyyy") & ") / b.Rata" & Format(dTahun1.EditValue, "yyyy") & "* 100) end as [Selisih" & Format(dTahun1.EditValue, "yyyy") & "-" & Format(dTahun2.EditValue, "yyyy") & "]," & _
                    "case when b.Rata" & Format(dTahun2.EditValue, "yyyy") & " = 0 or b.Rata" & Format(dTahun3.EditValue, "yyyy") & " = 0 then 0 else ((b.Rata" & Format(dTahun3.EditValue, "yyyy") & "-b.Rata" & Format(dTahun2.EditValue, "yyyy") & ") / b.Rata" & Format(dTahun2.EditValue, "yyyy") & "* 100) end as [Selisih" & Format(dTahun2.EditValue, "yyyy") & "-" & Format(dTahun3.EditValue, "yyyy") & "]"
            End If
            Dim tahunbulan As String = ""
            For a = 0 To Strings.Split(tahun, ",").Length - 2
                For b = 0 To Strings.Split(bulan, ",").Length - 2
                    tahunbulan += "'" & Strings.Split(tahun, ",")(a) & Strings.Split(bulan, ",")(b) & "',"
                Next
            Next

            'MsgBox(Strings.Left(tahunbulan, tahunbulan.Length - 1))
            'MsgBox(tahunpivot)
            'MsgBox(ctepivotrealisasistring)
            'MsgBox(ctepivotratastring)
            'MsgBox(ctepivotpersenstring)
            'MsgBox(selecttahun)

            Dim query As String = _
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
                        "aa.kodecompany+'.90.10.630'" & _
                        ")" & _
            "), " & _
            "ctegabung as(" & _
                "select TahunBulan,Aliasing, sum(JumlahNPM) as Jumlah,Grup from ctepvot a group by Aliasing,Grup,TahunBulan " & _
                "union all " & _
                "select a.TahunBulan,'PENDAPATAN BERSIH' as Aliasing,(" & _
                "select sum(x.JumlahNPM) from ctepvot x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='1.0')-" & _
                "(select sum(x.JumlahNPM) from ctepvot x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='2.0') " & _
                "as Jumlah, 2.1 as Grup from ctepvot a group by a.TahunBulan " & _
                "union all " & _
                "select a.TahunBulan,'TOTAL HPP BARANG DAGANG' as Aliasing,(" & _
                "select sum(x.JumlahNPM) from ctepvot x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='3.0') as Jumlah, 3.1 as Grup " & _
                "from ctepvot a group by a.TahunBulan " & _
                "union all " & _
                "select a.TahunBulan,'LABA-RUGI KOTOR' as Aliasing," & _
                "((select sum(x.JumlahNPM) from ctepvot x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='1.0')-" & _
                "(select sum(x.JumlahNPM) from ctepvot x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='2.0'))-" & _
                "(select sum(x.JumlahNPM) from ctepvot x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='3.0') as Jumlah, 3.2 as Grup " & _
                "from ctepvot a group by a.TahunBulan " & _
                "union all " & _
                "select a.TahunBulan,'TOTAL BEBAN USAHA' as Aliasing," & _
                "(select sum(x.JumlahNPM) from ctepvot x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='4.0') as Jumlah, 4.1 as Grup " & _
                "from ctepvot a group by a.TahunBulan " & _
                "union all " & _
                "select a.TahunBulan,'LABA-RUGI OPERASI' as Aliasing," & _
                "(select sum(x.JumlahNPM) from ctepvot x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='1.0')-" & _
                "(select sum(x.JumlahNPM) from ctepvot x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='2.0')-" & _
                "(select sum(x.JumlahNPM) from ctepvot x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='3.0')-" & _
                "(select sum(x.JumlahNPM) from ctepvot x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='4.0') as Jumlah, 4.2 as Grup " & _
                "from ctepvot a group by a.TahunBulan " & _
                "union all " & _
                "select a.TahunBulan,'TOTAL PENDAPATAN & BIAYA DILUAR USAHA' as Aliasing," & _
                "(select sum(x.JumlahNPM) from ctepvot x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='5.0')-" & _
                "(select sum(x.JumlahNPM) from ctepvot x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='6.0') as Jumlah, 6.1 as Grup " & _
                "from ctepvot a group by a.TahunBulan " & _
                "union all " & _
                "select a.TahunBulan,'LABA-RUGI SEBELUM PAJAK' as Aliasing," & _
                "((select sum(x.JumlahNPM) from ctepvot x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='1.0')-" & _
                "(select sum(x.JumlahNPM) from ctepvot x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='2.0')-" & _
                "(select sum(x.JumlahNPM) from ctepvot x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='3.0')-" & _
                "(select sum(x.JumlahNPM) from ctepvot x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='4.0'))+" & _
                "(select sum(x.JumlahNPM) from ctepvot x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='5.0')-" & _
                "(select sum(x.JumlahNPM) from ctepvot x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='6.0') " & _
                "as Jumlah, 6.2 as Grup " & _
                "from ctepvot a group by a.TahunBulan " & _
                "union all " & _
                "select a.TahunBulan,'LABA-RUGI SETELAH PAJAK' as Aliasing," & _
                "((select sum(x.JumlahNPM) from ctepvot x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='1.0')-" & _
                "(select sum(x.JumlahNPM) from ctepvot x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='2.0')- " & _
                "(select sum(x.JumlahNPM) from ctepvot x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='3.0')-" & _
                "(select sum(x.JumlahNPM) from ctepvot x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='4.0'))+" & _
                "(select sum(x.JumlahNPM) from ctepvot x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='5.0')-" & _
                "(select sum(x.JumlahNPM) from ctepvot x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='6.0')-" & _
                "(select sum(x.JumlahNPM) from ctepvot x group by x.TahunBulan,x.grup having x.TahunBulan=a.TahunBulan and x.Grup='7.0') " & _
                "as Jumlah, 7.1 as Grup " & _
                "from ctepvot a group by a.TahunBulan " & _
                ")," & _
                "ctejml as(" & _
                "select SUBSTRING(a.TahunBulan,1,4) as Tahun,a.Aliasing,sum(a.Jumlah) as Jumlah, sum(a.Jumlah)/" & jmlbulan & " as Rata, " & _
                "(sum(a.Jumlah)/" & jmlbulan & ") / (select sum(x.Jumlah)/" & jmlbulan & " from ctegabung x where SUBSTRING(x.TahunBulan,1,4)=SUBSTRING(a.TahunBulan,1,4) and x.Aliasing='PENDAPATAN BERSIH') * 100 as Persen" & _
                ",Grup from ctegabung a " & _
                "group by SUBSTRING(a.TahunBulan,1,4),a.Aliasing,a.Grup" & _
                ")," & _
                "ctepivotrealisasi as(" & _
                "select P.Aliasing," & ctepivotrealisasistring & ",Grup from ctejml D " & _
                "PIVOT(Sum(Jumlah) FOR D.Tahun IN (" & tahunpivot & ")) P " & _
                "group by Aliasing,Grup" & _
                ")," & _
                "cterata as(" & _
                "select P.Aliasing," & ctepivotratastring & ",Grup from ctejml D " & _
                "PIVOT(max(Rata) FOR D.Tahun IN (" & tahunpivot & ")) P " & _
                "group by Aliasing,Grup" & _
                ")," & _
                "ctepersen as(" & _
                "select P.Aliasing," & ctepivotpersenstring & ",Grup from ctejml D " & _
                "PIVOT(max(Persen) FOR D.Tahun IN (" & tahunpivot & ")) P " & _
                "group by Aliasing,Grup" & _
                ")" & _
                "select a.Aliasing as Keterangan," & selecttahun & "," & _
                "a.Grup from ctepivotrealisasi a " & _
                "left join cterata b on b.Aliasing = a.Aliasing and b.Grup = a.Grup " & _
                "left join ctepersen c on c.Aliasing = a.Aliasing and c.Grup = a.Grup " & _
                "order by a.Grup"
            'dgList.FirstInit(query, , , , {"Grup"}, , , False)
            'dgList.ConnString = tJenis.Text
            'dgList.RefreshData(False)

            Dim query2 As String = _
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
                        "aa.kodecompany+'.90.10.630'" & _
                        ") order by aa.kodecompany,aa.TahunBulan"

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
            ds.Relations.Add("Aliasing", dt1.Columns("Keterangan"), dt2.Columns("KeteranganAkun"))

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

            GridControl1.DataSource = ds.Tables("table1")
            GridView1.BestFitColumns()
            FormatGridView(GridView1, , , True)
            GridView1.Columns("Grup").Visible = False
            GridView1.Columns("Keterangan").Width = 500
            GridView1.Columns("Realisasi" & Format(dTahun1.EditValue, "yyyy") & "").Width = 200
            GridView1.Columns("Rata" & Format(dTahun1.EditValue, "yyyy") & "").Width = 200
            GridView1.Columns("Persen" & Format(dTahun1.EditValue, "yyyy") & "").Width = 100

            GridView1.OptionsView.ShowGroupPanel = False
            'reFormatColumns(GridView1)
            GridView1.Columns("Realisasi" & Format(dTahun1.EditValue, "yyyy") & "").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GridView1.Columns("Realisasi" & Format(dTahun1.EditValue, "yyyy") & "").DisplayFormat.FormatString = "c2"
            GridView1.Columns("Rata" & Format(dTahun1.EditValue, "yyyy") & "").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GridView1.Columns("Rata" & Format(dTahun1.EditValue, "yyyy") & "").DisplayFormat.FormatString = "c2"
            GridView1.Columns("Persen" & Format(dTahun1.EditValue, "yyyy") & "").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GridView1.Columns("Persen" & Format(dTahun1.EditValue, "yyyy") & "").DisplayFormat.FormatString = "n2"

            If cTahun2.Checked = True And cTahun3.Checked = True Then
                GridView1.Columns("Realisasi" & Format(dTahun2.EditValue, "yyyy") & "").Width = 200
                GridView1.Columns("Rata" & Format(dTahun2.EditValue, "yyyy") & "").Width = 200
                GridView1.Columns("Persen" & Format(dTahun2.EditValue, "yyyy") & "").Width = 100
                GridView1.Columns("Selisih" & Format(dTahun1.EditValue, "yyyy") & "-" & Format(dTahun2.EditValue, "yyyy") & "").Width = 200


                GridView1.OptionsView.ShowGroupPanel = False
                'reFormatColumns(GridView1)
                GridView1.Columns("Realisasi" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView1.Columns("Realisasi" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatString = "c2"
                GridView1.Columns("Rata" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView1.Columns("Rata" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatString = "c2"
                GridView1.Columns("Selisih" & Format(dTahun1.EditValue, "yyyy") & "-" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView1.Columns("Selisih" & Format(dTahun1.EditValue, "yyyy") & "-" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatString = "c2"
                GridView1.Columns("Persen" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView1.Columns("Persen" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatString = "n2"

                GridView1.Columns("Realisasi" & Format(dTahun3.EditValue, "yyyy") & "").Width = 300
                GridView1.Columns("Rata" & Format(dTahun3.EditValue, "yyyy") & "").Width = 200
                GridView1.Columns("Persen" & Format(dTahun3.EditValue, "yyyy") & "").Width = 100
                GridView1.Columns("Selisih" & Format(dTahun2.EditValue, "yyyy") & "-" & Format(dTahun3.EditValue, "yyyy") & "").Width = 200

                GridView1.OptionsView.ShowGroupPanel = False
                'reFormatColumns(GridView1)
                GridView1.Columns("Realisasi" & Format(dTahun3.EditValue, "yyyy") & "").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView1.Columns("Realisasi" & Format(dTahun3.EditValue, "yyyy") & "").DisplayFormat.FormatString = "c2"
                GridView1.Columns("Rata" & Format(dTahun3.EditValue, "yyyy") & "").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView1.Columns("Rata" & Format(dTahun3.EditValue, "yyyy") & "").DisplayFormat.FormatString = "c2"
                GridView1.Columns("Persen" & Format(dTahun3.EditValue, "yyyy") & "").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView1.Columns("Persen" & Format(dTahun3.EditValue, "yyyy") & "").DisplayFormat.FormatString = "n2"
                GridView1.Columns("Selisih" & Format(dTahun2.EditValue, "yyyy") & "-" & Format(dTahun3.EditValue, "yyyy") & "").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView1.Columns("Selisih" & Format(dTahun2.EditValue, "yyyy") & "-" & Format(dTahun3.EditValue, "yyyy") & "").DisplayFormat.FormatString = "c2"

            ElseIf cTahun2.Checked = True And cTahun3.Checked = False Then
                GridView1.Columns("Realisasi" & Format(dTahun2.EditValue, "yyyy") & "").Width = 300
                GridView1.Columns("Rata" & Format(dTahun2.EditValue, "yyyy") & "").Width = 200
                GridView1.Columns("Persen" & Format(dTahun2.EditValue, "yyyy") & "").Width = 100
                GridView1.Columns("Selisih" & Format(dTahun1.EditValue, "yyyy") & "-" & Format(dTahun2.EditValue, "yyyy") & "").Width = 200
                GridView1.OptionsView.ShowGroupPanel = False
                'reFormatColumns(GridView1)
                GridView1.Columns("Realisasi" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView1.Columns("Realisasi" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatString = "c2"
                GridView1.Columns("Rata" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView1.Columns("Rata" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatString = "c2"
                GridView1.Columns("Selisih" & Format(dTahun1.EditValue, "yyyy") & "-" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView1.Columns("Selisih" & Format(dTahun1.EditValue, "yyyy") & "-" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatString = "c2"
                GridView1.Columns("Persen" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView1.Columns("Persen" & Format(dTahun2.EditValue, "yyyy") & "").DisplayFormat.FormatString = "n2"

            Else
                GridView1.Columns("Selisih").Width = 200
                GridView1.Columns("Selisih").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView1.Columns("Selisih").DisplayFormat.FormatString = "c2"
            End If
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
        Dim nmtable As String = Strings.Right(cCompany.SelectedItem.ToString, 2)

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

    Private Sub cCheckAll_CheckedChanged(sender As Object, e As EventArgs) Handles cCheckAll.CheckedChanged
        'Dim datacompany As DataTable = TryCast(cCompany.DataSource, DataTable)
        Dim centang As Boolean = False
        If cCheckAll.Checked = False Then
            centang = False
        Else
            centang = True
        End If

        For i = 0 To datatabel.Rows.Count - 1
            cCompany.SetItemChecked(i, centang)
            Dim drow() As DataRow = datatabel.Select("KodeCompany = '" & Strings.Right(datatabel.Rows(i).Item("KodeCompany"), 2) & "'")
            drow(0)!cek = centang
        Next
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
End Class