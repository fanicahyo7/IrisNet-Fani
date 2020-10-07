Imports meCore
Public Class mstcobalist

    Private Sub cmdrefreshdata_Click(sender As Object, e As EventArgs) Handles cmdrefreshdata.Click
        Dim sql As String = "select Kodecst,Namacst,Alamat,Tanggal from tblatihan order by Kodecst"

        dglatihan.FirstInit(sql, {1, 1, 1, 1})
        dglatihan.RefreshData()


    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Using kk As New mstcoba
            kk.ShowDialog(Me)
        End Using
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dglatihan.GetRowCount_Gridview > 0 Then
            Dim pKode As String = dglatihan.GetRowCellValue(dglatihan.FocusedRowHandle, "Kodecst")
            Using xx As New mstcoba
                xx.Tag = pKode
                xx.ShowDialog(Me)
            End Using
        End If
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        If dglatihan.GetRowCount_Gridview > 0 Then
            Try
                Dim pKode As String = dglatihan.GetRowCellValue(dglatihan.FocusedRowHandle, "Kodecst")
                dglatihan.DataSource.ExecDelete("tblatihan", "Kodecst", pKode)

                Pesan({"Berhasil"})
                cmdrefreshdata.PerformClick()
            Catch ex As Exception
                Pesan({"Err : " & ex.Message.ToString})
            End Try
        End If
    End Sub

    Private Sub dglatihan_Load(sender As Object, e As EventArgs) Handles dglatihan.Load

    End Sub
End Class