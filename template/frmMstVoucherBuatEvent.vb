Imports meCore
Public Class frmMstVoucherBuatEvent

    Private Sub btnBuatVoucherBaru_Click(sender As Object, e As EventArgs) Handles btnBuatVoucherBaru.Click
        Using xx As New frmMstVoucherBuatEventAdd
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub frmMstVoucherBuatEvent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cKdVoucher.FirstInit(PubConnStr, "select KdVoucher, Keterangan, ON_OFF = case FlagOn when 1 then 'ON' else 'OFF' end, Status = case when getdate() between tglAwal and tglAkhir then 'AKTIF' else 'NON-AKTIF' end from trEventVoucher order by FlagOn desc, KdVoucher")
    End Sub
End Class