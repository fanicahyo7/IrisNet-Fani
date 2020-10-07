Imports meCore
Imports System.Data.SqlClient
Public Class frmMstGudang

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        refreshgrid()
    End Sub
    Sub refreshgrid()
        Dim sql As String = ""
        If Text = "Master Gudang" Then
            sql = "Select Kode, Keterangan, FlagJual as AksesJual,FlagOpname as GudangMutasiOpname from mstGudang order by kode"
            dgGudang.FirstInit(sql, {0.8, 1, 0.5, 0.5})
        ElseIf Text = "Master Wilayah" Then
            sql = "Select Kode, Keterangan from mstWilayah order by kode"
            dgGudang.FirstInit(sql, {0.8, 1})
        ElseIf Text = "Master Rak" Then
            sql = "Select Kode, Keterangan from mstRak  order by kode"
            dgGudang.FirstInit(sql, {0.8, 1})
        ElseIf Text = "Master Type Customer Supplier" Then
            sql = "Select Kode, Keterangan from mstTypeCusSup order by kode"
            dgGudang.FirstInit(sql, {0.8, 1})
        ElseIf Text = "Master Golongan" Then
            sql = "Select Kode, Keterangan, Status from vwGolongan"
            dgGudang.FirstInit(sql, {0.8, 1, 0.5})
        ElseIf Text = "Master Card" Then
            sql = "Select Kode, Jenis = case Jenis when 'K' then 'CREDIT CARD' else 'DEBIT CARD' end , Keterangan , Charge from mstCard"
            dgGudang.FirstInit(sql, {0.8, 0.8, 1, 0.5})
        ElseIf Text = "Daftar Nomor Nota" Then
            sql = "Select Kode, Keterangan, StartNumber as NoAwal, EndNumber as NoAkhir, FlagAktif as FlagActive from mstDaftarNota"
            dgGudang.FirstInit(sql, {0.8, 1, 0.5, 0.5, 1}, , , {"FlagActive"})
        ElseIf Text = "Master Stock Non Profit" Then
            sql = "Select Kode, Keterangan from mstStockNonProfit"
            dgGudang.FirstInit(sql, {0.8, 1})
        End If
        dgGudang.RefreshData()
    End Sub
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgGudang.GetRowCount_Gridview > 0 Then
            Dim pKode As String = dgGudang.GetRowCellValue(dgGudang.FocusedRowHandle, "Kode")
            If Text = "Master Card" Then
                Using xx As New frmDetailCard
                    xx.Tag = pKode
                    xx.ShowDialog(Me)
                    btnRefresh.PerformClick()
                End Using
            ElseIf Text = "Daftar Nomor Nota" Then
                Using xx As New frmDetailNoNota
                    xx.Tag = pKode
                    xx.ShowDialog(Me)
                    btnRefresh.PerformClick()
                End Using
            ElseIf Text = "Master Stock Non Profit" Then
                Using xx As New frmDetailStockNonProfit
                    xx.Tag = pKode
                    xx.ShowDialog(Me)
                    btnRefresh.PerformClick()
                End Using
            Else
                Using xx As New frmDetailGudang
                    xx.Tag = pKode
                    xx.Text = Text
                    xx.ShowDialog(Me)
                    btnRefresh.PerformClick()
                End Using
            End If
        End If
    End Sub

    Private Sub btnBaru_Click(sender As Object, e As EventArgs) Handles btnBaru.Click
        If Text = "Master Card" Then
            Using xx As New frmDetailCard
                xx.ShowDialog(Me)
                btnRefresh.PerformClick()
            End Using
        ElseIf Text = "Daftar Nomor Nota" Then
            Using xx As New frmDetailNoNota
                xx.ShowDialog(Me)
                btnRefresh.PerformClick()
            End Using
        ElseIf Text = "Master Stock Non Profit" Then
            Using xx As New frmDetailStockNonProfit
                xx.ShowDialog(Me)
                btnRefresh.PerformClick()
            End Using
        Else
            Using xx As New frmDetailGudang
                xx.Text = Text
                xx.ShowDialog(Me)
                btnRefresh.PerformClick()
            End Using
        End If
    End Sub

    Private Sub dgGudang_Grid_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles dgGudang.Grid_CustomDrawCell
        If Text = "Daftar Nomor Nota" Then
            Dim aktif As Boolean = dgGudang.GetRowCellValue(e.RowHandle, "FlagActive")
            If aktif = False Then
                e.Appearance.ForeColor = Color.Green
            End If
        End If
    End Sub

    Private Sub dgGudang_Grid_DoubleClick(sender As Object, e As EventArgs) Handles dgGudang.Grid_DoubleClick
        If dgGudang.GetRowCount_Gridview > 0 Then
            Dim pKode As String = dgGudang.GetRowCellValue(dgGudang.FocusedRowHandle, "Kode")
            If Text = "Master Card" Then
                Using xx As New frmDetailCard
                    xx.Tag = pKode
                    xx.ShowDialog(Me)
                    btnRefresh.PerformClick()
                End Using
            ElseIf Text = "Daftar Nomor Nota" Then
                Using xx As New frmDetailNoNota
                    xx.Tag = pKode
                    xx.ShowDialog(Me)
                    btnRefresh.PerformClick()
                End Using
            ElseIf Text = "Master Stock Non Profit" Then
                Using xx As New frmDetailStockNonProfit
                    xx.Tag = pKode
                    xx.ShowDialog(Me)
                    btnRefresh.PerformClick()
                End Using
            Else
                Using xx As New frmDetailGudang
                    xx.Tag = pKode
                    xx.Text = Text
                    xx.ShowDialog(Me)
                    btnRefresh.PerformClick()
                End Using
            End If
        End If
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        If dgGudang.GetRowCellValue(dgGudang.FocusedRowHandle, "Kode") = Nothing Then
            Exit Sub
        Else
            Dim tbl As String = ""
            If Text = "Master Gudang" Then
                tbl = "mstGudang"
            ElseIf Text = "Master Wilayah" Then
                tbl = "mstWilayah"
            ElseIf Text = "Master Rak" Then
                tbl = "mstRak"
            ElseIf Text = "Master Type Customer Supplier" Then
                tbl = "mstTypeCusSup"
            ElseIf Text = "Master Card" Then
                tbl = "mstCard"
            ElseIf Text = "Daftar Nomor Nota" Then
                tbl = "mstDaftarNota"
            ElseIf Text = "Master Stock Non Profit" Then
                tbl = "mstStockNonProfit"
            End If
            Dim question, query As String
            question = MsgBox("Hapus " & dgGudang.GetRowCellValue(dgGudang.FocusedRowHandle, "Kode") & " ?", vbYesNo, "Konfirmasi")
            If question = vbYes Then
                query = "delete from " & tbl & " where Kode='" & dgGudang.GetRowCellValue(dgGudang.FocusedRowHandle, "Kode") & "'"
                cmd = New SqlCommand(query, kon)
                cmd.ExecuteNonQuery()
                Pesan({"Data Berhasil Dihapus"}, "Informasi")
                btnRefresh.PerformClick()
            End If
        End If
    End Sub

    Private Sub frmMstGudang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        If Text = "Master Golongan" Then
            LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        ElseIf Text = "Master Stock Non Profit" Then
            LayoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        ElseIf Text = "Daftar Nomor Nota" Then
            LayoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        Else
            LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        End If
        refreshgrid()
    End Sub
End Class