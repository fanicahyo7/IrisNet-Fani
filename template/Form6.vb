Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports meCore
Public Class Form6

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        OpenFileDialog1.Filter = "(*.xlsx)|*.xlsx|(*.xls)|*.xls|All files (*.*)|*.*"
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        Else
            TextEdit1.Text = GetNewFakturTogamasSQLServ(PubConnStr, "trImportExcel", FakturReset.Tahunan, "NoPraPP", pubKodeUnit & pubUserInit & "-PPP", DTOC(Now), 5, "")
            Dim cari As String = "select top 1 * from trImportExcel where NoPraPP='" & TextEdit1.Text & "'"
            cmd = New SqlCommand(cari, kon)
            rd = cmd.ExecuteReader
            rd.Read()
            If Not rd.HasRows Then
                rd.Close()
                Dim CONN As OleDbConnection
                Dim daexcel As OleDbDataAdapter
                Dim ds As New DataSet
                Dim TabelExcel As New DataTable
                CONN = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" & _
                            "data source='" & OpenFileDialog1.FileName & "';Extended Properties=Excel 8.0;")

                Dim query As String = "select [Invoice],[Tanggal],[Total] from [Sheet1$]"
                daexcel = New OleDbDataAdapter(query, CONN)
                ds.Clear()
                daexcel.Fill(TabelExcel)

                For a = 0 To TabelExcel.Rows.Count - 1
                    Dim simpandb As String = _
                        "insert into trImportExcel (NoPraPP,Invoice,Tanggal,Total) values ('" & TextEdit1.Text & "','" & TabelExcel.Rows(a)!Invoice & "','" & Format(TabelExcel.Rows(a)!Tanggal, "yyyyMMdd") & "','" & TabelExcel.Rows(a)!Total & "')"
                    cmd = New SqlCommand(simpandb, kon)
                    cmd.ExecuteNonQuery()
                Next
            End If
            rd.Close()

            Dim q As String = _
                "select a.*,b.Faktur,b.Total," & _
                "case when a.Invoice = b.Keterangan and a.Total = b.Total then 'True' else 'False' end as Keterangan," & _
                "(select ('Invoice ' + Invoice + ' sudah dimasukkan pada file '+NoPraPP) from trImportExcel where Invoice=a.Invoice and NoPraPP<>'" & TextEdit1.Text & "') as Status " & _
                "from trImportExcel a " & _
                "left join trSLHeader b " & _
                "on a.Invoice = b.Keterangan " & _
                "where a.NoPraPP='" & TextEdit1.Text & "'"
            CtrlMeDataGrid2.FirstInit(q, {1, 1, 1, 1, 1, 1, 0.5, 1})
            CtrlMeDataGrid2.RefreshData(False)


            For a = 0 To CtrlMeDataGrid2.gvMain.RowCount - 1
                If Not IsDBNull(CtrlMeDataGrid2.GetRowCellValue(a, "Status")) Then
                    TextBox1.Text += CtrlMeDataGrid2.GetRowCellValue(a, "Status") + vbCrLf
                End If
            Next

            If TextBox1.Text = "" Then
                SimpleButton2.Enabled = True
            Else
                SimpleButton2.Enabled = False
                Dim queryhapus As String = _
                    "delete from trImportExcel where NoPraPP='" & TextEdit1.Text & "'"
                cmd = New SqlCommand(queryhapus, kon)
                cmd.ExecuteNonQuery()
            End If

            'Dim primaryKey1(0) As DataColumn
            'primaryKey1(0) = TabelExcel.Columns("Invoice")
            'TabelExcel.PrimaryKey = primaryKey1

            'Dim TabelServer As New DataTable

            'Dim queryserver As String = "select Keterangan, Tanggal, Total from trSLHeader where Keterangan like 'INV/%'"
            'da = New SqlDataAdapter(queryserver, kon)
            'da.Fill(TabelServer)

            'ds.Tables.Add(TabelExcel)
            'ds.Tables.Add(TabelServer)
            'ds.Relations.Add("Relasi", TabelExcel.Columns("Invoice"), TabelServer.Columns("Keterangan"), False)

            'CtrlMeDataGrid2.DataSource = ds.Tables(0)
            'CtrlMeDataGrid2.colWidth = {1, 0.5, 1}
            'CtrlMeDataGrid2.RefreshDataView()

            'For a = 0 To CtrlMeDataGrid2.gvMain.RowCount - 1
            '    Dim caripasangan As String = _
            '        "select Keterangan, Tanggal, Total from trSLHeader where Keterangan = '" & CtrlMeDataGrid2.GetRowCellValue(a, "Invoice") & "'"
            '    cmd = New SqlCommand(caripasangan, kon)
            '    rd = cmd.ExecuteReader
            '    rd.Read()
            '    If rd.HasRows Then
            '        CtrlMeDataGrid2.SetRowCellValue(a, "Keterangan", rd!Keterangan)
            '        CtrlMeDataGrid2.SetRowCellValue(a, "Tanggal", rd!Tanggal)
            '        CtrlMeDataGrid2.SetRowCellValue(a, "Total", rd!Total)
            '    End If
            '    rd.Close()
            'Next
        End If
    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
    End Sub
End Class