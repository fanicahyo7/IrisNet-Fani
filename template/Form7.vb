Imports meCore
Public Class Form7
    Dim dsds As New DataSet
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bw1.DoWork
        'proses()

        Dim query As String = "select top 1000 * from trcsheader"
        cmd = New SqlClient.SqlCommand(query, kon)
        cmd.CommandTimeout = 0
        da = New SqlClient.SqlDataAdapter(cmd)
        Dim dtdt As New DataTable
        da.Fill(dtdt)
        dsds = New DataSet
        dsds.Tables.Add(dtdt)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw1.RunWorkerCompleted
        GridControl1.DataSource = dsds.Tables(0)
        FormatGridView(GridView1, , , True)
        GridView1.HideLoadingPanel()
    End Sub

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GridView1.ShowLoadingPanel()
        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()

        bw1.RunWorkerAsync()
    End Sub
End Class