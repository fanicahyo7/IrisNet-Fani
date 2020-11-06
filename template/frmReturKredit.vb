Imports meCore
Imports System.Data.SqlClient
Public Class frmReturKredit
    Dim tabel As New DataTable
    Dim ds2 As New DataSet
    Dim ds As New DataSet
    Private Sub frmReturKredit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CtrlFilterStock1.FilterTahunSaldo = False
        'vwpc

        If System.IO.File.Exists(Application.StartupPath + "\test_dt.xml") Then
            Dim question = MessageBox.Show("Ada Data Lama Belum Tersimpan. Pakai Data Lama?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If question = vbYes Then
                ds.ReadXml(Application.StartupPath + "\test_dt.xml")
                tabel = ds.Tables(0)
                CtrlMeDataGrid3.gcMain.DataSource = ds.Tables(0)
            Else
                nullstate()
                System.IO.File.Delete(Application.StartupPath + "\test_dt.xml")
                Dim tabel As New DataTable
                Dim ds As New DataSet


            End If
        Else
            nullstate()
        End If
    End Sub

    Sub nullstate()
        tabel.Columns.Add("Kode", GetType(System.String))
        tabel.Columns.Add("Qty", GetType(System.String))
        CtrlMeDataGrid3.gcMain.DataSource = tabel
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim query As String = _
        "select Kode, cast(0 as numeric(10)) as Qty from mstSupplier"

        CtrlMeDataGrid1.FirstInit(query, {1, 1}, , {"Qty"})
        CtrlMeDataGrid1.RefreshData(False)


    End Sub

    Private Sub CtrlMeDataGrid1_Grid_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles CtrlMeDataGrid1.Grid_ValidateRow
        If Not CtrlMeDataGrid1.GetRowCellValue(e.RowHandle, "Qty") = "0" Then
            If tabel.Select("Kode='" & CtrlMeDataGrid1.GetRowCellValue(e.RowHandle, "Kode") & "'").Count = 0 Then
                tabel.Rows.Add(CtrlMeDataGrid1.GetRowCellValue(e.RowHandle, "Kode"), CtrlMeDataGrid1.GetRowCellValue(e.RowHandle, "Qty"))
            Else
                Dim anu As Integer = FindRow(tabel, CtrlMeDataGrid1.GetRowCellValue(e.RowHandle, "Kode"))
                tabel.Rows(anu)("Qty") = CtrlMeDataGrid1.GetRowCellValue(e.RowHandle, "Qty")
            End If
        Else
            Dim anu As Integer = FindRow(tabel, CtrlMeDataGrid1.GetRowCellValue(e.RowHandle, "Kode"))
            tabel.Rows(anu).Delete()
        End If
        tabel.TableName = "MyDataTable"
        tabel.WriteXml(Application.StartupPath + "\test_dt.xml")
        CtrlMeDataGrid3.gcMain.DataSource = tabel
    End Sub

    Function FindRow(ByVal dt As DataTable, ByVal kode As String) As Integer
        For i As Integer = 0 To dt.Rows.Count
            If dt.Rows(i)("Kode") = kode Then Return i
        Next
        Return -1
    End Function
End Class