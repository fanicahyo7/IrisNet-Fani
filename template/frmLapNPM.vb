Imports meCore
Imports System.Data.SqlClient
Public Class frmLapNPM

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
        cKdCompany.FirstInit(tJenis.Text, "Select KodeCompany,Nama from tbGNCompany", {tNama}, , , , , , {0.5, 1})
    End Sub

    Private Sub btnAmbilData_Click(sender As Object, e As EventArgs) Handles btnAmbilData.Click
        If cJenis.Text = "" Then
            MsgBox("Pilih Jenis Terlebih Dahulu!", vbCritical + vbOKOnly, "Peringatan")
        ElseIf cKdCompany.Text = "" Then
            MsgBox("Pilih Kode Company Terlebih Dahulu!", vbCritical + vbOKOnly, "Peringatan")
        Else

            Dim kdcompany As String = cKdCompany.Text
            Dim periode As String = Format(dPeriode.EditValue, "yyyyMM")
            Dim query As String = _
            "DECLARE @tahunbulan AS VARCHAR(6) " & _
            "DECLARE @kdcompany AS VARCHAR(2) " & _
            "SET @tahunbulan='" & periode & "'; " & _
            "SET @kdcompany='" & kdcompany & "'; " & _
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
                "a.KodeCompany=@kdcompany " & _
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
            dgList.FirstInit(query, {2.5, 2}, , , {"Grup"}, , , False)
            dgList.ConnString = tJenis.Text
            dgList.RefreshData(False)
        End If
    End Sub

    Private Sub dgList_Grid_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles dgList.Grid_CustomDrawCell
        If Not Strings.Right(dgList.GetRowCellValue(e.RowHandle, "Grup"), 1) = "0" Then
            e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
        End If
    End Sub
End Class