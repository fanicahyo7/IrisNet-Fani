Public Class Form4
    ' Declare DataTable
    Dim Table1 As New DataTable
    Dim ds As New DataSet

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If System.IO.File.Exists(Application.StartupPath + "\test_dt.xml") Then

            Dim question = MessageBox.Show("Pakai Data Lama", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If question = vbYes Then
                ds.ReadXml(Application.StartupPath + "\test_dt.xml")
                Table1 = ds.Tables(0)
                CtrlMeDataGrid1.gcMain.DataSource = ds.Tables(0)
            Else
                nullstate()
                System.IO.File.Delete(Application.StartupPath + "\test_dt.xml")
                Dim Table1 As New DataTable
                Dim ds As New DataSet
            End If
        Else
            nullstate()
        End If
    End Sub

    Sub nullstate()
        Table1.Columns.Add("Column1", GetType(System.String))
        CtrlMeDataGrid1.gcMain.DataSource = Table1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Table1.Rows.Add(TextEdit1.Text)
        Table1.TableName = "MyDataTable"
        Table1.WriteXml(Application.StartupPath + "\test_dt.xml")

        CtrlMeDataGrid1.gcMain.DataSource = Table1
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

    End Sub
End Class