
Imports meCore

Public Class mstCustomerList

    Private Sub cmdRefreshData_Click(sender As Object, e As EventArgs) Handles cmdRefreshData.Click
        Dim pQuery As String = _
            "Select Kode, Nama, Alamat, Kodepos from mstCustomer order by Kode"

        mdgList.FirstInit(pQuery, {1, 2, 4, 1})
        mdgList.RefreshData()
    End Sub

    Private Sub cmdNew_Click(sender As Object, e As EventArgs) Handles cmdNew.Click
        Using xx As New mstCustomer
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub cmdEdit_Click(sender As Object, e As EventArgs) Handles cmdEdit.Click
        If mdgList.GetRowCount_Gridview > 0 Then
            Dim pKode As String = mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Kode")
            Using xx As New mstCustomer
                xx.Tag = pKode
                xx.ShowDialog(Me)
            End Using
        End If
    End Sub

    Private Sub cmdDel_Click(sender As Object, e As EventArgs) Handles cmdDel.Click
        If mdgList.GetRowCount_Gridview > 0 Then
            Try
                Dim pKode As String = mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Kode")
                mdgList.DataSource.ExecDelete("mstcustomer", "kode", pKode)

                Pesan({"Berhasil"})
                cmdRefreshData.PerformClick()
            Catch ex As Exception
                Pesan({"Err : " & ex.Message.ToString})
            End Try
        End If
    End Sub

    Private Sub cmdDel2_Click(sender As Object, e As EventArgs) Handles cmdDel2.Click
        If mdgList.GetRowCount_Gridview > 0 Then
            Try
                mdgList.DeleteSelectedRows()
                mdgList.DataSource.UpdateMeToRealDBNoTry()

                Pesan({"Berhasil"})
                cmdRefreshData.PerformClick()
            Catch ex As Exception
                Pesan({"Err : " & ex.Message.ToString})
            End Try
        End If
    End Sub

    Private Sub mstCustomerList_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
End Class