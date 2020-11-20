Imports System.Data.Sql
Imports System.Data.SqlClient
Imports meCore
Public Class frmAmbilFaktur
    Public query As String
    Dim dbTuj As New cMeDB

    Private Sub rJenis_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rJenis.SelectedIndexChanged
        Dim pQue As String = ""
        Dim dt = New DataTable
        cTujuan.Reset()
        dgfaktur.Grid_ClearDataAndColumns()
        dgDetail.Grid_ClearData()
        cTujuan.Text = ""
        tNamaTujuan.Text = ""
        If rJenis.SelectedIndex = 0 Then
            LayoutControlItem11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            cTujuan.FirstInit(PubConnStr, "Select Kode,Nama,Alamat,Kota,CASE Konsinyasi WHEN '0' THEN 'Kredit' WHEN '1' THEN 'Konsinyasi' END AS Status from mstSupplier where status='1'", {tNamaTujuan}, , , , , False, {0.8, 1.5, 2, 1, 0.7})
        ElseIf rJenis.SelectedIndex = 1 Then
            LayoutControlItem11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            cTujuan.FirstInit(PubConnStr, "Select Kode,Nama,Alamat,Kota from mstCustomer where status='1'", {tNamaTujuan}, , , , , False, {1, 1.5, 2, 1})
        Else
            LayoutControlItem11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            'cTujuan.FirstInit(PubConnStr, "select distinct NoPengajuan from trPengajuanBayarHd order by NoPengajuan", , , , , , False, {0.8})
        End If
    End Sub

    Private Sub frmAmbilFaktur_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'koneksi()
        initForm(Me, EnfrmSizeNotMax.efsnm2Medium, DevExpress.XtraLayout.MoveFocusDirection.DownThenAcross)
        
        date2.EditValue = Format(DateAdd(DateInterval.Day, 0, Now), "dd/MM/yyyy")
        date1.EditValue = Format(DateAdd(DateInterval.Day, -7, date2.EditValue), "dd/MM/yyyy")

        date2.EditValue = Now
        date1.EditValue = DateAdd(DateInterval.Day, -7, Now)
        tNamaTujuan.ReadOnly = True
        LayoutControlItem11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
    End Sub

    Private Sub btntampilkan_Click(sender As Object, e As EventArgs) Handles btntampilkan.Click
        If rJenis.SelectedIndex = 0 Then
            If cTujuan.Text = "" Then
                MsgBox("Pilih Supplier Terlebih Dahulu", MsgBoxStyle.Critical + vbOKOnly, "Peringatan")
                query = "select cast(0 as bit) as Ambil, a.Faktur As FakturRetur,a.FakturBeli As Faktur,b.FakturAsli, a.Tanggal, a.SubTotal,a.DiscFaktur,a.Total,a.Keterangan, ISNULL(c.NoBukti,'') as FakturEkspedisi from trPCRHeader a left join trPCHeader b on a.FakturBeli = b.Faktur left join trKirimEkspedisiDetail c on a.Faktur = c.Faktur where a.KdSupplier='dfdhfdghf' AND a.Tanggal between '2019/01/01' and '2019/01/01'"
            Else
                Dim drow As DataRowView = cTujuan.GetSelectedDataRow()
                Dim x As String = drow!Status

                If x = "Kredit" Then
                    query = String.Format("select cast(0 as bit) as Ambil, a.Faktur As Faktur,a.FakturBeli As FakturRef,b.FakturAsli, a.Tanggal, a.SubTotal,a.DiscFaktur,a.Total,a.Keterangan, ISNULL(c.Faktur,'') as FakturEkspedisi from trPCRHeader a left join trPCHeader b on a.FakturBeli = b.Faktur left join trKirimEkspedisiDetail c on a.Faktur = c.FakturPCRKonsPby where isnull(a.Jenis,'RETUR FISIK')='RETUR FISIK' and a.KdSupplier='{0}' AND a.Tanggal between '{1}' and '{2}'", cTujuan.Text, Format(CDate(date1.EditValue), "yyyy/MM/dd"), Format(CDate(date2.EditValue), "yyyy/MM/dd"))
                Else
                    query = String.Format("select cast(0 as bit) as Ambil, a.Faktur As Faktur,a.FakturKons As FakturRef,b.FakturAsli, a.Tanggal, a.SubTotal,a.DiscFaktur,a.Total,a.Keterangan, ISNULL(c.Faktur,'') as FakturEkspedisi from trKonsRHeader a left join trKonsHeader b on b.Faktur = a.FakturKons left join trKirimEkspedisiDetail c on c.FakturPCRKonsPby = a.Faktur where a.KdSupplier='{0}' AND a.Tanggal between '{1}' and '{2}'", cTujuan.Text, Format(CDate(date1.EditValue), "yyyy/MM/dd"), Format(CDate(date2.EditValue), "yyyy/MM/dd"))
                End If
            End If
        ElseIf rJenis.SelectedIndex = 1 Then
            If cTujuan.Text = "" Then
                MsgBox("Pilih Customer Terlebih Dahulu", MsgBoxStyle.Critical + vbOKOnly, "Peringatan")
                query = "select cast(0 as bit) as Ambil, x.Faktur, x.FakturRef, x.FakturAsli, x.Tanggal, x.SubTotal, x.DiscFaktur, x.Total, x.Keterangan, ISNULL(c.Faktur,'') as FakturEkspedisi from (select a.Faktur, '' As FakturRef,'' As FakturAsli,a.Tanggal,a.SubTotal,a.DiscFaktur,a.Total,a.Keterangan from trSLHeader a left join trKirimEkspedisiDetail d on a.Faktur = d.FakturPCRKonsPby where KdCustomer='jdfgndjfgdfgkj' AND Tanggal between '2019/01/01' and '2019/01/01' UNION all select n.Faktur, '' As FakturRef, n.FakturAsli,n.Tanggal,n.SubTotal,n.DiscFaktur,n.Total,n.Keterangan from trSKonsHeader n left join trKirimEkspedisiDetail o on n.Faktur = o.FakturPCRKonsPby where KdCustomer='jdfgndjfgdfgkj' AND Tanggal between '2019/01/01' and '2019/01/01' ) as x left join trKirimEkspedisiDetail c on x.Faktur = c.FakturPCRKonsPby"
            Else
                query = String.Format("select cast(0 as bit) as Ambil, x.Faktur, x.FakturRef, x.FakturAsli, x.Tanggal, x.SubTotal, x.DiscFaktur, x.Total, x.Keterangan, ISNULL(c.Faktur,'') as FakturEkspedisi from (select a.Faktur, '' As FakturRef,'' As FakturAsli,a.Tanggal,a.SubTotal,a.DiscFaktur,a.Total,a.Keterangan from trSLHeader a left join trKirimEkspedisiDetail d on a.Faktur = d.FakturPCRKonsPby where KdCustomer='{0}' AND Tanggal between '{1}' and '{2}' UNION all select n.Faktur As Faktur, '' As FakturRef, n.FakturAsli,n.Tanggal,n.SubTotal,n.DiscFaktur,n.Total,n.Keterangan from trSKonsHeader n left join trKirimEkspedisiDetail o on n.Faktur = o.FakturPCRKonsPby where KdCustomer='{0}' AND Tanggal between '{1}' and '{2}' ) as x left join trKirimEkspedisiDetail c on x.Faktur = c.FakturPCRKonsPby", cTujuan.Text, Format(CDate(date1.EditValue), "yyyy/MM/dd"), Format(CDate(date2.EditValue), "yyyy/MM/dd"))
            End If
        Else
            query = String.Format("with cteSum as(select cast(0 as bit) as Ambil, NoPengajuan,TglPengajuan,sum(Pengajuan) as JumlahPengajuan from trPengajuanBayarHd group by NoPengajuan,TglPengajuan having TglPengajuan between '{0}' and '{1}') " & _
                                  "select a.*,isnull(c.Faktur,'') as FakturEkspedisi from cteSum a left join trPengajuanBayarKR b on a.NoPengajuan = b.NoPengajuan left join trKirimEkspedisiDetail c on a.NoPengajuan = c.FakturPCRKonsPby", Format(CDate(date1.EditValue), "yyyy/MM/dd"), Format(CDate(date2.EditValue), "yyyy/MM/dd"))
        End If

        If rJenis.SelectedIndex = 2 Then
            dgfaktur.FirstInit(query, {0.3, 0.8, 1, 1, 0.8}, , {"Ambil"})
            Dim anu As String = "select NoPengajuan,TglPengajuan,TransferKe,KdSupplier,NamaSupplier,Kategori,NoCtr,NoBTT,Bank,NoRek,AtasNama,Pengajuan from trPengajuanBayarHd " & _
                                "where NoPengajuan='" & cTujuan.Text & "' and TglPengajuan between '" & Format(CDate(date1.EditValue), "yyyy/MM/dd") & "' and '" & Format(CDate(date2.EditValue), "yyyy/MM/dd") & "'"
            dgDetail.FirstInit(anu, {0.9, 0.9, 0.8, 0.8, 1.2, 0.7, 1, 1, 1, 1, 1.2, 1.2}, {"Pengajuan"}, , , , , False)
            dgDetail.RefreshData(False)
        Else
            dgfaktur.FirstInit(query, {0.5, 1, 1, 2.2, 1, 1, 0.8, 1, 1.5, 1}, , {"Ambil"})
        End If
        dgfaktur.RefreshData(False)
    End Sub

    Private Sub btnAmbil_Click(sender As Object, e As EventArgs) Handles btnAmbil.Click
        Dim sa() As DataRow
        sa = dgfaktur.DataSource.Select("Ambil = True")
        If sa.Length = 0 Then
            MsgBox("Pilih Faktur Dulu", vbCritical + vbOKOnly, "Peringatan")
        Else
            If Not rJenis.SelectedIndex = "2" Then
                Using xx As New frmtrKirimEkspedisi(sa)
                    xx.tujuankirimekspedisi = cTujuan.Text
                    xx.jenis = rJenis.SelectedIndex
                    xx.date1 = Format(CDate(date1.EditValue), "yyyy/MM/dd")
                    xx.date2 = Format(CDate(date2.EditValue), "yyyy/MM/dd")
                    'xx.Tag = rJenis.Text
                    xx.ShowDialog(Me)
                    btntampilkan.PerformClick()
                End Using
            Else
                Dim sadetail() As DataRow
                sadetail = dgfaktur.DataSource.select("Ambil = True")
                Dim a As Integer = sadetail.Length
                Using xx As New frmtrKirimEkspedisi(sadetail)
                    xx.tujuankirimekspedisi = cTujuan.Text
                    xx.jenis = rJenis.SelectedIndex
                    xx.date1 = Format(CDate(date1.EditValue), "yyyy/MM/dd")
                    xx.date2 = Format(CDate(date2.EditValue), "yyyy/MM/dd")
                    xx.Tag = rJenis.Text
                    xx.ShowDialog(Me)
                    btntampilkan.PerformClick()
                End Using
            End If
        End If
    End Sub

    Private Sub dgfaktur_Grid_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles dgfaktur.Grid_CustomDrawCell
        If dgfaktur.GetRowCellValue(e.RowHandle, "FakturEkspedisi").ToString.Length > 0 Then
            e.Appearance.ForeColor = Color.Green
        End If
    End Sub

    Private Sub dgfaktur_Grid_CustomRowCellEditForEditing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles dgfaktur.Grid_CustomRowCellEditForEditing
        If e.Column.FieldName = "Ambil" Then
            If dgfaktur.GetRowCellValue(e.RowHandle, "FakturEkspedisi") <> "" Then
                e.RepositoryItem.ReadOnly = True
            Else
                e.RepositoryItem.ReadOnly = False
            End If
        End If
    End Sub

    Private Sub date2_EditValueChanged(sender As Object, e As EventArgs)
        If Not IsDate(date2.EditValue) Then
            date2.EditValue = Format(Now, "dd/MM/yyyy")
        End If
    End Sub

    Private Sub date1_EditValueChanged(sender As Object, e As EventArgs)
        If Not IsDate(date1.EditValue) Then
            date1.EditValue = Format(DateAdd(DateInterval.Day, -7, date2.EditValue), "dd/MM/yyyy")
        End If
    End Sub

    Private Sub dgfaktur_Grid_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles dgfaktur.Grid_SelectionChanged
        If rJenis.SelectedIndex = 2 Then
            Dim anu As String = "select NoPengajuan,TglPengajuan,TransferKe,KdSupplier,NamaSupplier,Kategori,NoCtr,NoBTT,Bank,NoRek,AtasNama,Pengajuan from trPengajuanBayarHd " & _
                    "where NoPengajuan='" & dgfaktur.GetRowCellValue(dgfaktur.FocusedRowHandle, "NoPengajuan") & "' and TglPengajuan between '" & Format(CDate(date1.EditValue), "yyyy/MM/dd") & "' and '" & Format(CDate(date2.EditValue), "yyyy/MM/dd") & "'"
            dgDetail.FirstInit(anu, {0.9, 0.9, 0.8, 0.8, 1.2, 0.7, 1, 1, 1, 1, 1.2, 1.2}, {"Pengajuan"}, , , , , False)
            dgDetail.RefreshData(False)
        End If
    End Sub

    Private Sub dgfaktur_Load(sender As Object, e As EventArgs) Handles dgfaktur.Load

    End Sub
End Class