Imports meCore
Public Class frmPengunjungList

    Private Sub frmPengunjungList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        meCore.pubServerType = enServerType.enStSQLServer
    End Sub

    Private Sub btnRefreshData_Click(sender As Object, e As EventArgs) Handles btnRefreshData.Click
        Dim pQuery As String = _
           "SELECT P.Tanggal,P.[NamaSecurity],P.[ShiftKerja],P.[Anak-Anak], P.[Remaja], P.[Dewasa], P.[Manula], P.[UserEntry], CONVERT(CHAR(10), DateTimeEntry, 111) as DateTimeEntry FROM trPengunjung D PIVOT(MAX(Nilai) FOR D.Kategori IN ([Anak-Anak], [Remaja], [Dewasa], [Manula])) P"
        dgpengunjung.FirstInit(pQuery, {0.5, 1, 0.5, 1, 1, 1, 1, 0.5, 0.5})
        dgpengunjung.RefreshData()
    End Sub

    Private Sub btnTambahData_Click(sender As Object, e As EventArgs) Handles btnTambahData.Click
        Using xx As New frmPengunjung
            xx.ShowDialog(Me)
        End Using
        btnRefreshData.PerformClick()
    End Sub
End Class