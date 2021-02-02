Imports meCore
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.Repository.BaseRepositoryItemCheckEdit
Public Class frmPBYAdd
    Dim WithEvents _riEditor As New RepositoryItemCheckEdit

    Private Sub cTransaksi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cTransaksi.SelectedIndexChanged
        Dim query As String = ""
        If cTransaksi.SelectedIndex = 0 Then
            query = "SELECT * FROM tblPengajuanBayarSupplier('0') ORDER BY 2, 1"
        ElseIf cTransaksi.SelectedIndex = 1 Then
            query = "SELECT * FROM tblPengajuanBayarSupplier('1') ORDER BY 2, 1"
        End If

        dgList.FirstInit(query, {0.8, 0.8, 1.2, 1, 1, 1, 1})
        dgList.RefreshData(False)

        cKategori.SelectedIndex = 0
    End Sub

    Private Sub frmPBYAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cTransferKe.SelectedIndex = 0
        cTransaksi.SelectedIndex = 0
        cKategori.SelectedIndex = 0
    End Sub

    Private Sub dgList_Grid_DoubleClick(sender As Object, e As EventArgs) Handles dgList.Grid_DoubleClick
        lNamaSupplier.Text = dgList.GetRowCellValue(dgList.FocusedRowHandle, "Kode")

        Dim tgl1 As Date = DateAdd(DateInterval.Day, -7, Now)
        Dim tgl2 As Date = Now

        Dim query As String = ""
        If cTransferKe.SelectedIndex = 0 Then
            Dim transaksi As String = ""
            If cTransaksi.SelectedIndex = 0 Then
                transaksi = "PEMBELIAN"
            ElseIf cTransaksi.SelectedIndex = 1 Then
                transaksi = "PERHITUNGAN"
            End If
            query = "select cast(Chk as bit) as Chk, Kategori, KdSupplier, Faktur, FakturAsli, Tanggal, JthTmp, Terjual, Status, Total," & _
                "ReturFisik, ReturAdmin, JenisFaktur, FakturReinv, NamaSupplier, FlagLock from tblPengajuanPCKons('" & DTOC(tgl1, , False) & "','" & DTOC(tgl2, , False) & "','') " & _
                "where kdSupplier='" & lNamaSupplier.Text.ToUpper & "' and Terjual <> 0 and JenisFaktur in ('" & transaksi.ToUpper & "','RETUR BELI','DEPOSIT')  order by KdSupplier, Tanggal "
        ElseIf cTransferKe.SelectedIndex = 1 Then
            Dim konsi As String = ""
            If cTransaksi.SelectedIndex = 0 Then
                konsi = "NON KONSI"
            ElseIf cTransaksi.SelectedIndex = 1 Then
                konsi = "KONSI"
            End If
            query = "select cast(Chk as bit) as Chk, Kategori, KdSupplier, Faktur, FakturAsli, Tanggal, JthTmp, Terjual, Status, Total," & _
                "ReturFisik, ReturAdmin, JenisFaktur, FakturReinv, NamaSupplier, FlagLock from tblPengajuanPCKons('" & DTOC(tgl1, , False) & "','" & DTOC(tgl2, , False) & "','') " & _
                "where JenisFaktur = 'OPERASIONAL'  and Terjual <> 0 and fakturAsli like '%' AND kdSupplier='" & lNamaSupplier.Text.ToUpper & "' and Konsinyasi='" & konsi.ToUpper & "' order by KdSupplier, Tanggal "
        End If
        dgTrans.FirstInit(query, {0.4, 0.8, 0.8, 1.4, 1.7, 0.7, 0.7, 1, 1.8, 1, 1, 1}, , {"Chk"}, {"JenisFaktur", "FakturReinv", "NamaSupplier", "FlagLock"}, , , False)
        dgTrans.RefreshData(False)

        dgTrans.gcMain.ForceInitialize()
        dgTrans.gvMain.Columns(0).ColumnEdit = _riEditor
    End Sub

    Private Sub dgTrans_Grid_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles dgTrans.Grid_CustomDrawCell
        If dgTrans.GetRowCellValue(e.RowHandle, "Terjual") < 0 Then
            e.Appearance.ForeColor = Color.Red
        End If

        If dgTrans.GetRowCellValue(e.RowHandle, "Chk") = True Then
            e.Appearance.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub dgTrans_Grid_CustomRowCellEditForEditing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles dgTrans.Grid_CustomRowCellEditForEditing
        If e.Column.FieldName = "Chk" Then
            If dgTrans.GetRowCellValue(e.RowHandle, "Chk") = True Then
                e.RepositoryItem.ReadOnly = True
            Else
                e.RepositoryItem.ReadOnly = False
            End If
        End If
    End Sub

    Private Sub dgTrans_Load(sender As Object, e As EventArgs) Handles dgTrans.Load

    End Sub

    Private Sub _riEditor_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles _riEditor.EditValueChanging
        If dgTrans.GetRowCellValue(dgTrans.FocusedRowHandle, "Terjual") < 0 Then
            e.NewValue = e.OldValue
            MsgBox("Nilai Pengajuan Bayar Hutang Supplier Tidak Boleh Minus.", vbCritical + vbOKOnly, "Peringatan")
        End If
    End Sub
End Class