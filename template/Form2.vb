Imports meCore
Public Class Form2

    Dim sql As String = "select * from mstEkspedisi"
    Dim sql2 As String = "select * from mstCustomer"
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        meCore.pubServerType = enServerType.enStSQLServer
        pubServer = "10.10.2.23"
        'pubServer = "DESKTOP-9DMUOAP"
        pubDatabase = "TM601KEDIRI"
        pubUserIdDB = "sa"
        pubPass = "gogogo"
        'pubPass = "fafafa"
        PubConnStr = CreateConnString(pubServer, pubDatabase, pubUserIdDB, pubPass, , enDBType.SQLServ, "appname")

        CtrlMeDataGrid1.FirstInit(sql2)
        CtrlMeDataGrid1.RefreshData(False)
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        Using xx As New Form3
            xx.sqli = sql
            xx.ShowDialog(Me)
        End Using

    End Sub
End Class