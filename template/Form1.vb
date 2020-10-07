
Imports meCore

Public Class Form1
    Dim dbx As New cMeDB

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Try
            Dim pKode As String = ""
            Dim cLio As New cClosedXML
            Dim ds As DataSet = cLio.XLStoDataset_thisWorking("D:\cb\FORMAT LR NEWEST 2019.xlsx")
            CtrlMeDataGrid1.DataSource = ds.Tables(0)
            CtrlMeDataGrid1.colWidth = {2, 3, 4} '<-- gawe ukuran kolom
            'CtrlMeDataGrid1.colSum = {"qty", "jumlah", "dll"} '<-- gawe sum kolom
            CtrlMeDataGrid1.RefreshDataView()

        Catch ex As Exception
            Pesan({ex.Message.ToString})
            Exit Sub
        End Try


        'dbx.FillMe("select top 10 * from mststock")
        'CtrlMeDataGrid1.DataSource = dbx
        'CtrlMeDataGrid1.RefreshDataView()
    End Sub


    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        dbx.FillMe("select * from mstbarang limit 10")
        CtrlMeDataGrid1.DataSource = dbx
        CtrlMeDataGrid1.RefreshDataView()
    End Sub
End Class