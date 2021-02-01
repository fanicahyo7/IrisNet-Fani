Public Class frmPBYAdd 

    Private Sub cTransaksi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cTransaksi.SelectedIndexChanged
        Dim query As String = ""
        If cTransaksi.SelectedIndex = 0 Then
            query = "SELECT * FROM tblPengajuanBayarSupplier('0') ORDER BY 2, 1"
        ElseIf cTransaksi.SelectedIndex = 1 Then
            query = "SELECT * FROM tblPengajuanBayarSupplier('1') ORDER BY 2, 1"
        End If

        dgList.FirstInit(query, {0.8, 0.8, 1.2, 1, 1, 1, 1})
        dgList.RefreshData(False)
    End Sub

    Private Sub frmPBYAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cTransferKe.SelectedIndex = 0
        cTransaksi.SelectedIndex = 0
        cKategori.SelectedIndex = 0
    End Sub
End Class