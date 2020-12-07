Imports System.IO
Public Class frmFormatExcel

    Private Sub frmFormatExcel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim id As String = "formatexcel withdrawal"
        Dim folder As String = Directory.GetCurrentDirectory() & "\"
        Dim filename As String = System.IO.Path.Combine(folder, id & ".png")
        PictureBox1.Image = Image.FromFile(filename)

        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub
End Class