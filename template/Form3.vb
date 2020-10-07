Public Class Form3
    Public sqli As String
    Private Sub Form3_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        'Dim sql1 As String = "select trPCRHeader.Faktur,trPCHeader.FakturAsli, trPCRHeader.Tanggal,trPCRHeader.Total,trPCRHeader.DiscFaktur from trPCRHeader left join trPCHeader on trPCRHeader.FakturBeli = trPCHeader.Faktur where trPCRHeader.KdSupplier='TGMA_' AND trPCRHeader.Tanggal between '2012/03/15' and '2012/05/20'"
        'Form2.CtrlMeDataGrid1.FirstInit(sqli)
        'Form2.CtrlMeDataGrid1.RefreshData(False)
        'Form2.CtrlMeDataGrid1.Grid_ClearData()
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'DateEdit1.Properties.DisplayFormat.FormatString = "yyyy/MM/dd"
        'DateEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        'DateEdit1.Properties.EditFormat.FormatString = "yyyy/MM/dd"
        'DateEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        'DateEdit1.Properties.Mask.EditMask = "yyyy/MM/dd"

        'DateEdit1.EditValue = Format(Now, "yyyy/MM/dd")

        'DateEdit1.EditValue = Format(DateAdd(DateInterval.Day, -7, Now), "yyyy/MM/dd")

        DateEdit2.EditValue = Now
        DateEdit2.Properties.MinValue = DateAdd(DateInterval.Day, -7, Now)
        DateEdit2.Properties.MaxValue = DateAdd(DateInterval.Day, 0, Now)

        CMeButtonBrowser1.FirstInit({"asd", "qwe", "123"})
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        CMeButtonBrowser1.Text = "asdasd"
    End Sub
End Class