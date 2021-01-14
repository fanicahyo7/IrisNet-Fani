Imports meCore
Public Class frmLapPBY

    Private Sub frmLapPBY_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cKdSupplier.FirstInit(PubConnStr, "select Kode,Nama,Alamat from mstSupplier")
    End Sub
End Class