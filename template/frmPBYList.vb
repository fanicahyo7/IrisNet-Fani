Imports meCore
Imports System.Data.SqlClient
Public Class frmPBYList

    Private Sub frmPBYList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT CONVERT(VARCHAR(6),TglPengajuan,112) as Bulan, ABS(SUM(Pengajuan)) as Total FROM dbo.trPengajuanBayarHd GROUP BY CONVERT(VARCHAR(6),TglPengajuan,112) order by 1 desc"
        dgList.FirstInit(query, {0.7, 1})
        dgList.RefreshData(False)
    End Sub

    Private Sub dgList_Grid_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles dgList.Grid_CustomDrawCell
       
    End Sub

    Private Sub dgList_Grid_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles dgList.Grid_SelectionChanged
        Dim query As String = _
            "SELECT  NoPengajuan, MingguKe as M, JnsPengajuan, Kategori, Status = case when FlagSave = 1 then 'KIRIM PUSAT' else 'PENGAJUAN UNIT' END," & _
            "TglPengajuan as Tanggal, ABS(SUM(Pengajuan)) AS Total, sum(valid)AS Valid, sum(tolak) AS Tolak, Sum(BiayaTrans + Pembulatan) as Biaya, sum(transfer) AS [Transfer]," & _
            "sum(lunas) as Lunas, sum(sisa) as Sisa From vwPengajuanBayarHd WHERE CONVERT(VARCHAR(6), TglPengajuan, 112) = '" & dgList.GetRowCellValue(dgList.FocusedRowHandle, "Bulan") & "' GROUP BY NoPengajuan, MingguKe, TglPengajuan, JnsPengajuan, Kategori, FlagSave"
        dgListDetail.FirstInit(query, {0.9, 0.3, 0.6, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8})
        dgListDetail.RefreshData(False)

        sPengajuan.EditValue = dgListDetail.GetSummaryColDB("Total")
        sTotalValid.EditValue = dgListDetail.GetSummaryColDB("Valid")
        sTotalLunas.EditValue = dgListDetail.GetSummaryColDB("Lunas")
        sTotalSisa.EditValue = dgListDetail.GetSummaryColDB("Sisa")
    End Sub

    Private Sub dgListDetail_Grid_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles dgListDetail.Grid_CustomDrawCell

        If e.Column.FieldName.ToUpper = "KATEGORI" Then
            If dgListDetail.GetRowCellValue(e.RowHandle, "Kategori").ToString.ToUpper = "ISIDENTIL" Then
                e.Appearance.BackColor = Color.Red
                e.Appearance.ForeColor = Color.White
            End If
        End If


        Dim ttl As Double
        ttl = CDbl(dgListDetail.GetRowCellValue(e.RowHandle, "Transfer")) + CDbl(dgListDetail.GetRowCellValue(e.RowHandle, "Tolak")) + CDbl(Math.Abs(dgListDetail.GetRowCellValue(e.RowHandle, "Biaya"))) + CDbl(Math.Abs(dgListDetail.GetRowCellValue(e.RowHandle, "Sisa")))

        If CDbl(dgListDetail.GetRowCellValue(e.RowHandle, "Total")) = ttl Then
            If e.Column.FieldName.ToUpper = "TOTAL" Or e.Column.FieldName.ToUpper = "VALID" Then
                e.Appearance.BackColor = Color.LightGreen
            End If
        Else
            If e.Column.FieldName.ToUpper = "TOTAL" Or e.Column.FieldName.ToUpper = "VALID" Then
                e.Appearance.BackColor = Color.LightPink
            End If
        End If
    End Sub
End Class