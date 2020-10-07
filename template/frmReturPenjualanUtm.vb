Imports meCore
Public Class frmReturPenjualanUtm

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim pquery As String =
        "SELECT Faktur, Tanggal, KdCustomer, NamaCustomer, Konsinyasi, KdGudang, SubTotal, Discount, PPN, Total, UserEntry, DateTimeEntry, Keterangan " & _
        "FROM vwSLRHeader " & _
        "where CONVERT(VARCHAR,Tanggal,112) BETWEEN '" & Format(CDate(DateEdit1.Text), "yyyyMMdd") & "' AND '" & Format(CDate(DateEdit2.Text), "yyyyMMdd") & "' " & _
        "order by Tanggal"
        CtrlMeDataGrid1.FirstInit(pquery, {0.9, 0.5, 0.7, 0.8, 0.5, 0.5, 0.8, 0.5, 0.5, 0.8, 0.5, 0.5, 0.8})
        CtrlMeDataGrid1.RefreshData(False)
    End Sub

    Private Sub frmReturPenjualanUtm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        meCore.pubServerType = enServerType.enStSQLServer
        'pubServer = "10.10.2.23"
        pubServer = "192.168.3.212"
        'pubServer = "DESKTOP-9DMUOAP"
        pubDatabase = "TM601KEDIRI"
        pubUserIdDB = "sa"
        'pubPass = "fafafa"
        pubPass = "gogogo"
        PubConnStr = CreateConnString(pubServer, pubDatabase, pubUserIdDB, pubPass, , enDBType.SQLServ, "appname")

        DateEdit2.EditValue = Now
        DateEdit1.EditValue = DateAdd(DateInterval.Day, -44, DateEdit2.EditValue)
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Using xx As New frmReturPenjualan
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub CtrlMeDataGrid1_Grid_DoubleClick(sender As Object, e As EventArgs) Handles CtrlMeDataGrid1.Grid_DoubleClick
        Dim faktur As String
        faktur = CtrlMeDataGrid1.GetRowCellValue(CtrlMeDataGrid1.FocusedRowHandle, "Faktur")
        Using xx As New frmReturPenjualan
            xx.Tag = faktur
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub CtrlMeDataGrid1_Load(sender As Object, e As EventArgs) Handles CtrlMeDataGrid1.Load

    End Sub
End Class