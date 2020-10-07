Imports meCore
Public Class frmReturPembelianUtm

    Private Sub frmReturPembelianUtm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateEdit2.EditValue = Now
        DateEdit1.EditValue = DateAdd(DateInterval.Day, -44, DateEdit2.EditValue)
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim pquery As String =
        "SELECT Faktur, Tanggal, KdSupplier, NamaSupplier, Konsinyasi, KdGudang, SubTotal, Discount, PPN, Total, UserEntry, DateTimeEntry, Keterangan " & _
        "FROM vwPCRHeader " & _
        "where CONVERT(VARCHAR,Tanggal,112) BETWEEN '" & Format(CDate(DateEdit1.Text), "yyyyMMdd") & "' AND '" & Format(CDate(DateEdit2.Text), "yyyyMMdd") & "' " & _
        "order by Tanggal"
        CtrlMeDataGrid1.FirstInit(pquery)
        CtrlMeDataGrid1.RefreshData(False)
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Using xx As New frmReturPembelian
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub CtrlMeDataGrid1_Grid_DoubleClick(sender As Object, e As EventArgs) Handles CtrlMeDataGrid1.Grid_DoubleClick
        Dim faktur As String
        faktur = CtrlMeDataGrid1.GetRowCellValue(CtrlMeDataGrid1.FocusedRowHandle, "Faktur")
        Using xx As New frmReturPembelian
            xx.Tag = faktur
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub CtrlMeDataGrid1_Load(sender As Object, e As EventArgs) Handles CtrlMeDataGrid1.Load

    End Sub
End Class