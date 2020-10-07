Public Class frmMstBuku 

    Private Sub frmMstBuku_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComboBox2.AutoCompleteSource = AutoCompleteSource.ListItems
    End Sub
End Class