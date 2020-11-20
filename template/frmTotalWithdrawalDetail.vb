Imports meCore
Public Class frmTotalWithdrawalDetail

    Private Sub frmTotalWithdrawalDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetTextReadOnly({tInvoice})
        tInvoice.Text = Me.Tag
        Dim query As String = _
            "select a.Faktur,a.Tanggal,a.KdCustomer,a.Keterangan, case when (sum(isnull(b.Jumlah,0))-sum(isnull(a.Total,0))) = 0 then sum(a.Total) end as TotalLunas " & _
            ",case when (sum(isnull(b.Jumlah,0))-sum(isnull(a.Total,0))) <> 0 then sum(a.Total) end as TotalBelumLunas " & _
            "from trSLHeader a " & _
            "left join trLPtgDetail b on a.Faktur = b.FakturAsli where Keterangan='" & Me.Tag & "' " & _
            "group by a.Faktur,a.Tanggal,a.KdCustomer,a.Keterangan "
        dgList.FirstInit(query, {1, 0.8, 0.7, 1, 1, 1}, {"TotalLunas", "TotalBelumLunas"})
        dgList.RefreshData(False)
    End Sub
End Class