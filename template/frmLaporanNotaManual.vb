Imports meCore
Public Class frmLaporanNotaManual

    Private Sub frmLaporanNotaManual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tTahun.Properties.MaxLength = 4
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Dim query As String = "SELECT Tahun, convert(varchar,Nomor) as NomorNota, Faktur as Keterangan, case when FlagBlokir=1 then 'BLOKIR' else '' end as Status " & _
            "FROM dbo.mstDaftarNotaDetail WHERE Tahun='" & tTahun.Text & "' ORDER BY Nomor"
        dgList.FirstInit(query, {0.8, 0.8, 1, 0.8})
        dgList.RefreshData()
    End Sub

    Private Sub tTahun_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tTahun.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Close()
    End Sub
End Class