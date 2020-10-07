Imports meCore
Imports System.Data.SqlClient
Public Class frmMstMarginList
    Sub refres()
        Dim sql As String = "Select " & _
            "Kode,Keterangan as Nama,MarginMin," & _
            "Min1,Max1,Margin1," & _
            "Min2,Max2,Margin2," & _
            "Min3,Max3,Margin3," & _
            "Min4,Max4,Margin4," & _
            "Min5,Margin5 " & _
            "from MstTypeDisc"
        dgList.FirstInit(sql, {1, 1, 1, _
                               0.8, 0.8, 0.8, _
                               0.8, 0.8, 0.8, _
                               0.8, 0.8, 0.8, _
                               0.8, 0.8, 0.8, _
                               0.8, 0.8})
        dgList.RefreshData()
    End Sub
    Private Sub frmMstMarginList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        refres()
    End Sub

    Private Sub btnRefreshData_Click(sender As Object, e As EventArgs) Handles btnRefreshData.Click
        refres()
    End Sub

    Private Sub btnBaru_Click(sender As Object, e As EventArgs) Handles btnBaru.Click
        Using xx As New frmMstMargin
            xx.ShowDialog(Me)
            btnRefreshData.PerformClick()
        End Using
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs)
        If dgList.GetRowCount_Gridview > 0 Then
            Dim pKode As String = dgList.GetRowCellValue(dgList.FocusedRowHandle, "Kode")
            Using xx As New frmMstMargin
                xx.Tag = pKode
                xx.ShowDialog(Me)
                btnRefreshData.PerformClick()
            End Using
        End If
    End Sub

    Private Sub dgList_Grid_DoubleClick(sender As Object, e As EventArgs) Handles dgList.Grid_DoubleClick
        If dgList.GetRowCount_Gridview > 0 Then
            Dim pKode As String = dgList.GetRowCellValue(dgList.FocusedRowHandle, "Kode")
            Using xx As New frmMstMargin
                xx.Tag = pKode
                xx.ShowDialog(Me)
                btnRefreshData.PerformClick()
            End Using
        End If
    End Sub

    Private Sub dgList_Load(sender As Object, e As EventArgs) Handles dgList.Load

    End Sub

    Private Sub btnUbah_Click(sender As Object, e As EventArgs) Handles btnUbah.Click
        If dgList.GetRowCount_Gridview > 0 Then
            Dim pKode As String = dgList.GetRowCellValue(dgList.FocusedRowHandle, "Kode")
            Using xx As New frmMstMargin
                xx.Tag = pKode
                xx.ShowDialog(Me)
                btnRefreshData.PerformClick()
            End Using
        End If
    End Sub
End Class