Imports meCore
Imports System.Data.SqlClient
Imports DevExpress.XtraGrid.Views.Base
Public Class frmLapKartuPiutangCustomer
    Dim pKode As String = ""

    Private Sub frmLapKartuPiutangCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rJenis.SelectedIndex = 0
        Dim kode As String = ""
        If Me.Text.ToUpper = "KARTU PIUTANG" Then
            kode = "select Kode,Nama,Alamat from mstCustomer"
        ElseIf Me.Text.ToUpper = "KARTU HUTANG" Then
            kode = "select Kode,Nama,Alamat from mstSupplier"
        End If
        cKdCustomer.FirstInit(PubConnStr, kode, {tNama, tAlamat})

        dBulan.Properties.DisplayFormat.FormatString = "yyyy MMMM"
        dBulan.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        dBulan.Properties.EditMask = "yyyy MMMM"
        dBulan.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView
        dBulan.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView

        dBulan.EditValue = Now
        koneksi()

        If Me.Tag <> "" Then pKode = Me.Tag
        If pKode <> "" Then
            cKdCustomer.Text = pKode
            btnAmbilData.PerformClick()
            SetTextReadOnly({cKdCustomer})
        End If
    End Sub

    Private Sub btnAmbilData_Click(sender As Object, e As EventArgs) Handles btnAmbilData.Click
        If cKdCustomer.Text = "" Then
            MsgBox("Pilih Kode Customer Terlebih Dahulu!", vbOKOnly + vbCritical, "Peringatan")
        Else
            Dim jenis As String = ""
            Dim nama As String = ""
            Dim htgptg As String = ""
            If Me.Text.ToUpper = "KARTU PIUTANG" Then
                jenis = "vwKartuPiutang"
                nama = "KdCustomer"
                htgptg = "trLPtgDetail"
            ElseIf Me.Text.ToUpper = "KARTU HUTANG" Then
                jenis = "vwKartuHutang"
                nama = "KdSupplier"
                htgptg = "trLHtgDetail"
            End If

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
                    "sisa,urutan into ##tmpAwal from " & jenis & " where " & nama & "='" & cKdCustomer.Text & "'; " & _
                    "CREATE CLUSTERED INDEX ix_tmpAwal ON ##tmpAwal (Tanggal); " & _
                "with " & _
                "ctedebet as(" & _
                    "select 'x' as " & nama & ",sum(Debet) as Debet from ##tmpAwal " & _
                    "where convert(varchar(6),ISNULL(Tanggal,'1901-01-01'),112) < '" & Format(dBulan.EditValue, "yyyyMM") & "' " & _
                    ")," & _
                "ctekredit as(" & _
                    "select 'x' as " & nama & ",sum(Kredit) as Kredit from ##tmpAwal " & _
                    "where convert(varchar(6),ISNULL(Tanggal,'1901-01-01'),112) < '" & Format(dBulan.EditValue, "yyyyMM") & "' " & _
                    ")," & _
                "ctesaldoawal as (" & _
                    "select DATEADD(DAY,-1,'" & Format(dBulan.EditValue, "yyyy/MM") & "/01') as Tanggal,'' as Faktur, '' as FakturAsli, null as JthTmp,'' as NoBuktiKas, " & _
                    "'SALDO AWAL' as Keterangan,a.Debet,b.Kredit, a.Debet-b.Kredit as Saldo, 0 as sisa, 0 as urutan from ctedebet a " & _
                    "inner join ctekredit b on a." & nama & " = b." & nama & "" & _
                    ")," & _
                "cteunion as (" & _
                    "" & tambahquery & "" & _
                    "), " & _
                "ctefinal as (" & _
                    "select *,ROW_NUMBER() over(order by Tanggal,Faktur,Urutan) as urut from cteunion " & _
                    ") " & _
                    "select a.Tanggal,a.Faktur,a.FakturAsli,JthTmp,NoBuktiKas,Keterangan,Debet,Kredit,(select sum(debet-Kredit) " & _
                    "from ctefinal b " & _
                    "where b.Tanggal <= a.Tanggal and b.urut<=a.urut) as Saldo," & _
                    "sisa, a.urutan, urut, c.FakturAsli as FakturAsliPP " & _
                    "from ctefinal a " & _
                    "left join " & htgptg & " c on a.Faktur = c.FakturAsli " & _
                    "order by a.Tanggal,Faktur,a.urutan"

            dgLap.FirstInit(query, {0.8, 1, 1, 0.8, 1, 1, 0.8, 0.8, 0.8, 0.2, 0.2, 0.2, 0.2}, , , {"sisa", "urutan", "urut", "FakturAsliPP"})
            dgLap.dSourceUsePK = False
            dgLap.RefreshData(False)

            dgLap.gvMain.MoveLast()
        End If
    End Sub

    Private Sub rJenis_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rJenis.SelectedIndexChanged
        If rJenis.SelectedIndex = 0 Then
            LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        Else
            LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        End If
    End Sub

    Private Sub dgLap_DoubleClick(sender As Object, e As EventArgs) Handles dgLap.DoubleClick

    End Sub

    Private Sub dgLap_Grid_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles dgLap.Grid_CustomDrawCell
        Dim jenis As String = ""
        If Me.Text.ToUpper = "KARTU PIUTANG" Then
            jenis = "PP".ToUpper
        ElseIf Me.Text.ToUpper = "KARTU HUTANG" Then
            jenis = "PH".ToUpper

        End If

        If IsDBNull(dgLap.GetRowCellValue(e.RowHandle, "Faktur")) Then
            e.Appearance.ForeColor = Color.Black
        Else
            If Strings.Mid(dgLap.GetRowCellValue(e.RowHandle, "Faktur"), 8, 2).ToUpper = jenis And Not Strings.Trim(dgLap.GetRowCellValue(e.RowHandle, "Keterangan")).ToString.ToUpper = "PEMBULATAN" Then
                If e.Column.FieldName.ToUpper = "SALDO" Then
                    e.Appearance.ForeColor = Color.Black
                Else
                    e.Appearance.ForeColor = Color.Green
                End If
            End If
        End If

        If dgLap.GetRowCellValue(e.RowHandle, "FakturAsliPP").ToString.Length > 0 Then
            If e.Column.FieldName.ToUpper = "SALDO" Then
                e.Appearance.ForeColor = Color.Black
            Else
                e.Appearance.ForeColor = Color.Gray
            End If
        End If
    End Sub

    Private Sub dgLap_Grid_DoubleClick(sender As Object, e As EventArgs) Handles dgLap.Grid_DoubleClick
        If Strings.Mid(dgLap.GetRowCellValue(dgLap.FocusedRowHandle, "Faktur"), 8, 2).ToUpper = "PP" Or Strings.Mid(dgLap.GetRowCellValue(dgLap.FocusedRowHandle, "Faktur"), 8, 2).ToUpper = "PH" Then
            Using xx As New frmDetailPelunasan(dgLap.GetRowCellValue(dgLap.FocusedRowHandle, "Faktur"))
                If Strings.Mid(dgLap.GetRowCellValue(dgLap.FocusedRowHandle, "Faktur"), 8, 2).ToUpper = "PP" Then
                    xx.Text = "DETAIL PELUNASAN PIUTANG".ToUpper
                ElseIf Strings.Mid(dgLap.GetRowCellValue(dgLap.FocusedRowHandle, "Faktur"), 8, 2).ToUpper = "PH" Then
                    xx.Text = "DETAIL PELUNASAN HUTANG".ToUpper
                End If
                xx.ShowDialog(Me)
            End Using
        End If
    End Sub
End Class