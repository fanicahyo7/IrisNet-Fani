Imports meCore

Public Class frmMstCustomerList

    Private Sub frmMstCustomerList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaddata()
    End Sub

    Sub loaddata()
        Dim query As String = _
            "Select Kode, Nama, Konsinyasi, Jenis, Alamat, Kota, Telepon1, Telepon2, FlagActive as Status from mstCustomer order by kode"
        dgList.FirstInit(query, {0.8, 1, 0.5, 0.8, 1, 0.8, 0.8, 0.8, 0.5})
        dgList.RefreshData(False)
    End Sub

    Private Sub btnBaru_Click(sender As Object, e As EventArgs) Handles btnBaru.Click
        Using xx As New frmMstCustomer
            xx.ShowDialog(Me)
            loaddata()
        End Using
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgList.GetRowCount_Gridview > 0 Then
            Dim pKode As String = dgList.GetRowCellValue(dgList.FocusedRowHandle, "Kode")
            Using xx As New frmMstCustomer
                xx.Tag = pKode
                xx.ShowDialog(Me)
                loaddata()
            End Using
        End If
    End Sub

    Private Sub dgList_Grid_DoubleClick(sender As Object, e As EventArgs) Handles dgList.Grid_DoubleClick
        If dgList.GetRowCount_Gridview > 0 Then
            Dim pKode As String = dgList.GetRowCellValue(dgList.FocusedRowHandle, "Kode")
            Using xx As New frmMstCustomer
                xx.Tag = pKode
                xx.ShowDialog(Me)
                loaddata()
            End Using
        End If
    End Sub
End Class