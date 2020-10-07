Imports meCore
Public Class frmRetur

    Private Sub frmRetur_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        meCore.pubServerType = enServerType.enStSQLServer
        pubServer = "10.10.2.23"
        'pubServer = "DESKTOP-9DMUOAP"
        pubDatabase = "TM601KEDIRI"
        pubUserIdDB = "sa"
        'pubPass = "fafafa"
        pubPass = "gogogo"
        PubConnStr = CreateConnString(pubServer, pubDatabase, pubUserIdDB, pubPass, , enDBType.SQLServ, "appname")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Using xx As New frmReturPembelian
            xx.ShowDialog(Me)
        End Using
    End Sub
End Class