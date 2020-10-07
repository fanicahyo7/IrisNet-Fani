Imports meCore
Imports System.Data.SqlClient
Public Class frmLapKartuPiutangCustomer

    Private Sub frmLapKartuPiutangCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rJenis.SelectedIndex = 0
        cKdCustomer.FirstInit(PubConnStr, "select Kode,Nama,Alamat from mstCustomer", {tNama, tAlamat})

        dBulan.Properties.DisplayFormat.FormatString = "yyyy MMMM"
        dBulan.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        dBulan.Properties.EditMask = "yyyy MMMM"
        dBulan.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView
        dBulan.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView

        dBulan.EditValue = Now
        koneksi()
    End Sub

    Private Sub btnAmbilData_Click(sender As Object, e As EventArgs) Handles btnAmbilData.Click
        If cKdCustomer.Text = "" Then
            MsgBox("Pilih Kode Customer Terlebih Dahulu!", vbOKOnly + vbCritical, "Peringatan")
        Else
            Dim query As String = ""
            Dim tambahquery As String = ""
            If rJenis.SelectedIndex = 0 Then
                tambahquery = _
                    "select * from ##tmpAwal "
            Else
                tambahquery = _
                    "select * from ctesaldoawal " & _
                    "union all " & _
                    "select * from ##tmpAwal " & _
                    "where convert(varchar(6),ISNULL(Tanggal,'1901-01-01'),112) = '" & Format(dBulan.EditValue, "yyyyMM") & "' "
            End If

            query = _
                "IF OBJECT_ID('tempdb..##tmpAwal') IS NOT NULL DROP TABLE ##tmpAwal " & _
                    "select Tanggal,Faktur,FakturAsli,JthTmp,NoBuktiKas,Keterangan,Debet,Kredit,debet-Kredit as saldo," & _
                    "sisa,urutan into ##tmpAwal from vwKartuPiutang where kdcustomer='" & cKdCustomer.Text & "'; " & _
                    "CREATE CLUSTERED INDEX ix_tmpAwal ON ##tmpAwal (Tanggal); " & _
                "with " & _
                "ctedebet as(" & _
                    "select 'x' as KdCustomer,sum(Debet) as Debet from ##tmpAwal " & _
                    "where convert(varchar(6),ISNULL(Tanggal,'1901-01-01'),112) < '" & Format(dBulan.EditValue, "yyyyMM") & "' " & _
                    ")," & _
                "ctekredit as(" & _
                    "select 'x' as KdCustomer,sum(Kredit) as Kredit from ##tmpAwal " & _
                    "where convert(varchar(6),ISNULL(Tanggal,'1901-01-01'),112) < '" & Format(dBulan.EditValue, "yyyyMM") & "' " & _
                    ")," & _
                "ctesaldoawal as (" & _
                    "select DATEADD(DAY,-1,'" & Format(dBulan.EditValue, "yyyy/MM") & "/01') as Tanggal,'' as Faktur, '' as FakturAsli, null as JthTmp,'' as NoBuktiKas, " & _
                    "'SALDO AWAL' as Keterangan,a.Debet,b.Kredit, a.Debet-b.Kredit as Saldo, 0 as sisa, 0 as urutan from ctedebet a " & _
                    "inner join ctekredit b on a.KdCustomer = b.KdCustomer" & _
                    ")," & _
                "cteunion as (" & _
                    "" & tambahquery & "" & _
                    "), " & _
                "ctefinal as (" & _
                    "select *,ROW_NUMBER() over(order by Tanggal,Faktur,Urutan) as urut from cteunion " & _
                    ") " & _
                    "select Tanggal,Faktur,FakturAsli,JthTmp,NoBuktiKas,Keterangan,Debet,Kredit,(select sum(debet-Kredit) " & _
                    "from ctefinal b " & _
                    "where b.Tanggal <= a.Tanggal and b.urut<=a.urut) as Saldo," & _
                    "sisa, urutan, urut " & _
                    "from ctefinal a " & _
                    "order by Tanggal,Faktur,urutan"

            'Dim dt As New DataTable
            'da = New SqlDataAdapter(query, kon)
            'da.Fill(dt)

            'dgLap.DataSource = dt
            'dgLap.colWidth = {0.8, 1, 1, 0.8, 1, 1, 0.8, 0.8, 0.8, 0.2, 0.2, 0.2}
            'dgLap.colSum = {"Debet", "Kredit"}
            'dgLap.colVisibleFalse = {"sisa", "urutan", "urut"}
            'dgLap.colWidth = {0.8, 1, 1, 0.8, 1, 1, 0.8, 0.8, 0.8, 0.2, 0.2, 0.2}
            'dgLap.RefreshDataView()

            dgLap.FirstInit(query, {0.8, 1, 1, 0.8, 1, 1, 0.8, 0.8, 0.8, 0.2, 0.2, 0.2}, {"Debet", "Kredit"}, , {"sisa", "urutan", "urut"})
            dgLap.dSourceUsePK = False
            dgLap.RefreshData(False)
        End If
    End Sub

    Private Sub rJenis_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rJenis.SelectedIndexChanged
        If rJenis.SelectedIndex = 0 Then
            LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        Else
            LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        End If
    End Sub
End Class