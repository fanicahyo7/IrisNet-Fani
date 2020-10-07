Imports meCore
Public Class frmMstBank
    Private Sub frmMstBank_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        meCore.pubServerType = enServerType.enStSQLServer
    End Sub

    Private Sub btnRefreshData_Click(sender As Object, e As EventArgs) Handles btnRefreshData.Click
        Dim pQuery As String = _
            "Select Status,KdBank, NamaBank, NoRekLength, TadaID, UserEntry, DateTimeEntry, UserUpdate, DateTimeUpdate from mstBank order by KdBank"

        dgBank.FirstInit(pQuery, {0.3, 1, 1.5, 0.8, 1, 1, 1, 1, 1})
        dgBank.RefreshData()
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        Using xx As New frmmstBankAdd
            xx.ShowDialog(Me)
            btnRefreshData.PerformClick()
        End Using
    End Sub

    Private Sub btnUbah_Click(sender As Object, e As EventArgs) Handles btnUbah.Click
        If dgBank.GetRowCount_Gridview > 0 Then
            Dim pKode As String = dgBank.GetRowCellValue(dgBank.FocusedRowHandle, "KdBank")
            Using xx As New frmmstBankAdd
                xx.Tag = pKode
                xx.ShowDialog(Me)
                btnRefreshData.PerformClick()
            End Using
        End If
    End Sub

    Private Sub dgBank_Load(sender As Object, e As EventArgs) Handles dgBank.Load

    End Sub
End Class