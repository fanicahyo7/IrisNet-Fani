Imports meCore
Imports System.Data.SqlClient

Public Class frmPBYList
    Dim index As Integer = 0
    Private Sub frmPBYList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetTextReadOnly({sPengajuan, sTotalValid, sTotalLunas, sTotalSisa})
        refreshlist()
        ambildetail()
    End Sub

    Sub refreshlist()
        Dim query As String = "SELECT CONVERT(VARCHAR(6),TglPengajuan,112) as Bulan, ABS(SUM(Pengajuan)) as Total FROM dbo.trPengajuanBayarHd GROUP BY CONVERT(VARCHAR(6),TglPengajuan,112) order by 1 desc"
        dgList.FirstInit(query, {0.7, 1})
        dgList.RefreshData(False)
        dgList.gvMain.MoveBy(index)
    End Sub

    Private Sub dgList_Grid_DoubleClick(sender As Object, e As EventArgs) Handles dgList.Grid_DoubleClick
        index = dgList.FocusedRowHandle
        ambildetail()
    End Sub

    Private Sub dgList_Grid_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles dgList.Grid_FocusedRowChanged
        'index = dgList.FocusedRowHandle
        'ambildetail()
    End Sub

    Private Sub dgList_Grid_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles dgList.Grid_SelectionChanged
        'ambildetail()
    End Sub
    Sub ambildetail()
        Dim query As String = _
            "SELECT  NoPengajuan, MingguKe as M, JnsPengajuan, Kategori, Status = case when FlagSave = 1 then 'KIRIM PUSAT' else 'PENGAJUAN UNIT' END," & _
            "TglPengajuan as Tanggal, ABS(SUM(Pengajuan)) AS Total, sum(valid)AS Valid, sum(tolak) AS Tolak, Sum(BiayaTrans + Pembulatan) as Biaya, sum(transfer) AS [Transfer]," & _
            "sum(lunas) as Lunas, sum(sisa) as Sisa,FlagValid2,FlagValid3 From vwPengajuanBayarHd WHERE CONVERT(VARCHAR(6), TglPengajuan, 112) = '" & dgList.GetRowCellValue(dgList.FocusedRowHandle, "Bulan") & "' GROUP BY NoPengajuan, MingguKe, TglPengajuan, JnsPengajuan, Kategori, FlagSave, FlagValid2, FlagValid3"
        dgListDetail.FirstInit(query, {0.9, 0.3, 0.6, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8}, , , {"FlagValid2", "FlagValid3", "isValid"})
        dgListDetail.RefreshData(False)

        sPengajuan.EditValue = dgListDetail.GetSummaryColDB("Total")
        sTotalValid.EditValue = dgListDetail.GetSummaryColDB("Valid")
        sTotalLunas.EditValue = dgListDetail.GetSummaryColDB("Lunas")
        sTotalSisa.EditValue = dgListDetail.GetSummaryColDB("Sisa")
    End Sub

    Private Sub dgListDetail_Grid_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles dgListDetail.Grid_CustomDrawCell
        'If dgListDetail.GetRowCellValue(e.RowHandle, "FlagValid2") = "1" And dgListDetail.GetRowCellValue(e.RowHandle, "FlagValid3") = "1" Then
        If dgListDetail.GetRowCellValue(e.RowHandle, "Status") = "KIRIM PUSAT" Then
            e.Appearance.BackColor = Color.LightGray
        End If

        If e.Column.FieldName.ToUpper = "KATEGORI" Then
            If dgListDetail.GetRowCellValue(e.RowHandle, "Kategori").ToString.ToUpper = "ISIDENTIL" Then
                e.Appearance.BackColor = Color.Red
                e.Appearance.ForeColor = Color.White
            End If
        End If

        'Dim ttl As Double
        'ttl = CDbl(dgListDetail.GetRowCellValue(e.RowHandle, "Lunas")) + CDbl(dgListDetail.GetRowCellValue(e.RowHandle, "Tolak")) + CDbl(Math.Abs(dgListDetail.GetRowCellValue(e.RowHandle, "Biaya"))) + CDbl(Math.Abs(dgListDetail.GetRowCellValue(e.RowHandle, "Sisa")))

        'If CDbl(dgListDetail.GetRowCellValue(e.RowHandle, "Total")) = ttl Then
        '    If e.Column.FieldName.ToUpper = "TOTAL" Or e.Column.FieldName.ToUpper = "VALID" Then
        '        e.Appearance.BackColor = Color.LightGreen
        '    End If
        'Else
        '    If e.Column.FieldName.ToUpper = "TOTAL" Or e.Column.FieldName.ToUpper = "VALID" Then
        '        e.Appearance.BackColor = Color.LightPink
        '    End If
        'End If

        If CDbl(dgListDetail.GetRowCellValue(e.RowHandle, "Total")) <> CDbl(dgListDetail.GetRowCellValue(e.RowHandle, "Valid")) + CDbl(dgListDetail.GetRowCellValue(e.RowHandle, "Tolak")) Then
            If e.Column.FieldName.ToUpper = "TOTAL" Or e.Column.FieldName.ToUpper = "VALID" Then
                e.Appearance.BackColor = Color.LightPink
            End If
        Else
            If e.Column.FieldName.ToUpper = "TOTAL" Or e.Column.FieldName.ToUpper = "VALID" Then
                e.Appearance.BackColor = Color.LightGreen
            End If
        End If


    End Sub

    Private Sub dgListDetail_Grid_DoubleClick(sender As Object, e As EventArgs) Handles dgListDetail.Grid_DoubleClick
        'Dim valid As Boolean = False
        'If dgListDetail.GetRowCellValue(dgListDetail.FocusedRowHandle, "FlagValid2") = "1" And dgListDetail.GetRowCellValue(dgListDetail.FocusedRowHandle, "FlagValid3") = "1" Then
        '    valid = True
        'End If

        'Dim valid As Boolean = dgListDetail.GetRowCellValue(dgListDetail.FocusedRowHandle, "FlagValid2") = "1" And dgListDetail.GetRowCellValue(dgListDetail.FocusedRowHandle, "FlagValid3") = "1"
        Dim valid As Boolean = dgListDetail.GetRowCellValue(dgListDetail.FocusedRowHandle, "Status") = "KIRIM PUSAT"

        Using xx As New frmPBYRekapPelunasan(dgListDetail.GetRowCellValue(dgListDetail.FocusedRowHandle, "NoPengajuan"), dgListDetail.GetRowCellValue(dgListDetail.FocusedRowHandle, "Status"), valid, dgListDetail.GetRowCellValue(dgListDetail.FocusedRowHandle, "Kategori"))
            xx.ShowDialog(Me)
            refreshlist()
        End Using
    End Sub

    Private Sub dgListDetail_Grid_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles dgListDetail.Grid_SelectionChanged
        'If dgListDetail.GetRowCellValue(dgListDetail.FocusedRowHandle, "FlagValid2") = "1" And dgListDetail.GetRowCellValue(dgListDetail.FocusedRowHandle, "FlagValid3") = "1" Then
        If dgListDetail.GetRowCellValue(dgListDetail.FocusedRowHandle, "Status") = "KIRIM PUSAT" Then
            btnValidasi.Enabled = False
        Else
            btnValidasi.Enabled = True
        End If
    End Sub

    Private Sub btnPBYBaru_Click(sender As Object, e As EventArgs) Handles btnPBYBaru.Click
        Using xx As New frmPBYAdd
            xx.ShowDialog(Me)
            refreshlist()
        End Using
    End Sub

    Private Sub btnPerforma_Click(sender As Object, e As EventArgs) Handles btnPerforma.Click
        Using xx As New frmPBYaddPerforma
            xx.ShowDialog(Me)
            refreshlist()
        End Using
    End Sub

    Private Sub btnValidasi_Click(sender As Object, e As EventArgs) Handles btnValidasi.Click
        Dim query As String = "select * from UserLogin where UserName='" & pubUserName & "' and Initial='" & pubUserInit & "'"
        cmd = New SqlCommand(query, kon)
        rd = cmd.ExecuteReader
        rd.Read()
        Dim level As String = ""
        If rd.HasRows Then
            level = rd!UserLevel
        End If
        rd.Close()

        If level = "00" Or pubUserEntry = "QC" Then
            Using xx As New frmPBYValid(dgListDetail.GetRowCellValue(dgListDetail.FocusedRowHandle, "NoPengajuan"), DTOC(CDate(dgListDetail.GetRowCellValue(dgListDetail.FocusedRowHandle, "Tanggal")), "-", False))
                xx.ShowDialog(Me)
            End Using
            ambildetail()
        Else
            MsgBox("VALIDASI PENGAJUAN HANYA UNTUK LEVEL KEPALA TOKO", vbCritical + vbOKOnly, "PERINGATAN")
        End If
    End Sub

    Private Sub btnLaporan_Click(sender As Object, e As EventArgs) Handles btnLaporan.Click
        Using xx As New frmLapPBY
            xx.ShowDialog(Me)
        End Using
    End Sub
End Class