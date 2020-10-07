Imports meCore
Public Class frmPengunjungValidList

    Private Sub frmPengunjungValidList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        meCore.pubServerType = enServerType.enStSQLServer
    End Sub

    Private Sub btnRefreshData_Click(sender As Object, e As EventArgs) Handles btnRefreshData.Click
        Dim pQuery As String = _
          "SELECT P.[Tanggal],P.[NamaSecurity],P.[ShiftKerja],P.[Anak-Anak], P.[Remaja], P.[Dewasa], P.[Manula], P.[UserEntry], DateTimeEntry FROM trPengunjung D PIVOT(MAX(Nilai) FOR D.Kategori IN ([Anak-Anak], [Remaja], [Dewasa], [Manula])) P LEFT JOIN (select Tanggal, MAX(Status) as Status,ShiftKerja from LogValidPengunjung GROUP BY Tanggal,ShiftKerja) b on P.Tanggal = b.Tanggal and P.ShiftKerja = b.ShiftKerja where Status='0'"
            dgpengunjung.FirstInit(pQuery, {0.5, 1, 0.5, 1, 1, 1, 1, 0.5, 0.5})
            dgpengunjung.RefreshData()
    End Sub

    Private Sub dgpengunjung_Grid_DoubleClick(sender As Object, e As EventArgs) Handles dgpengunjung.Grid_DoubleClick
        If dgpengunjung.GetRowCount_Gridview > 0 Then
            Dim pTanggal As String = dgpengunjung.GetRowCellValue(dgpengunjung.FocusedRowHandle, "Tanggal")
            Dim pShift As String = dgpengunjung.GetRowCellValue(dgpengunjung.FocusedRowHandle, "ShiftKerja")
            Dim pNama As String = dgpengunjung.GetRowCellValue(dgpengunjung.FocusedRowHandle, "NamaSecurity")
            Dim pAnak As String = dgpengunjung.GetRowCellValue(dgpengunjung.FocusedRowHandle, "Anak-Anak")
            Dim pDewasa As String = dgpengunjung.GetRowCellValue(dgpengunjung.FocusedRowHandle, "Dewasa")
            Dim pRemaja As String = dgpengunjung.GetRowCellValue(dgpengunjung.FocusedRowHandle, "Remaja")
            Dim pManula As String = dgpengunjung.GetRowCellValue(dgpengunjung.FocusedRowHandle, "Manula")

            Using xx As New frmPengunjungValid
                xx.tgl = pTanggal
                xx.shiftkerja = pShift
                xx.namasecurity = pNama
                xx.anak = pAnak
                xx.dewasa = pDewasa
                xx.remaja = pRemaja
                xx.manula = pManula

                xx.ShowDialog(Me)
                btnRefreshData.PerformClick()
            End Using
        End If
    End Sub

    Private Sub dgpengunjung_Load(sender As Object, e As EventArgs) Handles dgpengunjung.Load

    End Sub
End Class