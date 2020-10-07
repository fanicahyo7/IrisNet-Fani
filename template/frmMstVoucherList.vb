Imports meCore
Imports System.Data.SqlClient
Public Class frmMstVoucherList
    Sub refres()
        Dim sql As String = "Select Kode, Keterangan, KdSupplier, Nominal, StartDate, ExpiredDate, StartNumber, EndNumber from mstVoucher"
        dgList.FirstInit(sql, {0.8, 1, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8})
        dgList.RefreshData()
    End Sub
    Private Sub frmMstVoucherList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        refres()
    End Sub

    Private Sub btnRefreshData_Click(sender As Object, e As EventArgs) Handles btnRefreshData.Click
        refres()
    End Sub

    Private Sub btnBaru_Click(sender As Object, e As EventArgs) Handles btnBaru.Click
        Using xx As New frmMstVoucher
            xx.ShowDialog(Me)
            btnRefreshData.PerformClick()
        End Using
    End Sub

    Private Sub dgList_Grid_DoubleClick(sender As Object, e As EventArgs) Handles dgList.Grid_DoubleClick
        'If dgList.GetRowCount_Gridview > 0 Then
        '    Dim pKode As String = dgList.GetRowCellValue(dgList.FocusedRowHandle, "Kode")
        '    Using xx As New frmMstVoucher
        '        xx.Tag = pKode
        '        xx.ShowDialog(Me)
        '        btnRefreshData.PerformClick()
        '    End Using
        'End If
    End Sub

    Private Sub dgList_Load(sender As Object, e As EventArgs) Handles dgList.Load

    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        If dgList.GetRowCellValue(dgList.FocusedRowHandle, "Kode") = Nothing Then
            Exit Sub
        Else
            Dim question, query As String
            question = MsgBox("Hapus " & dgList.GetRowCellValue(dgList.FocusedRowHandle, "Kode") & " ?", vbYesNo, "Konfirmasi")
            If question = vbYes Then
                query = "delete from mstVoucher where Kode='" & dgList.GetRowCellValue(dgList.FocusedRowHandle, "Kode") & "'"
                cmd = New SqlCommand(query, kon)
                cmd.ExecuteNonQuery()
                Pesan({"Data Berhasil Dihapus"}, "Informasi")
                btnRefreshData.PerformClick()
            End If
        End If
    End Sub
End Class