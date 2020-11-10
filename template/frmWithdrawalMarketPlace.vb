Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports meCore

Public Class frmWithdrawalMarketPlace

    Private Function ImportExcelWithOleDB(Path As String) As DataTable
        Dim dtExcelSchema As DataTable
        Dim dt As New DataTable

        Dim SheetName As String = ""

        Dim ExcelconString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'"
        ExcelconString = String.Format(ExcelconString, Path)
        Dim connExcel As New OleDbConnection(ExcelconString)
        Dim cmdExcel As New OleDbCommand()
        Dim oda As New OleDbDataAdapter()
        cmdExcel.Connection = connExcel
        'Get the name of First Sheet

        Try
            connExcel.Open()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
        If dtExcelSchema.Rows.Count > 0 Then
            SheetName = dtExcelSchema.Rows(dtExcelSchema.Rows.Count - 1)("TABLE_NAME").ToString()
        End If
        connExcel.Close()

        'Read Data from First Sheet
        connExcel.Open()
        cmdExcel.CommandText = "SELECT * From [" & SheetName & "]"  'right(description,28) as NoInv,
        oda.SelectCommand = cmdExcel
        oda.Fill(dt)
        dt.TableName = SheetName.ToString().Replace("$", "")
        connExcel.Close()

        Return dt
        'MeDG.DataSource = dt
        'MeDG.RefreshDataView()
    End Function

    ''ada error di beberapa file excel
    'Private Sub ImportExcelWithClosedXml(Path As String)
    '    If Len(Path) > 0 Then
    '        Try
    '            Dim pKode As String = ""
    '            Dim cLio As New cClosedXML
    '            Dim ds As DataSet = cLio.XLStoDataset_thisWorking(Path)
    '            Dim db As DataTable = ds.Tables(0)
    '            MeDG.DataSource = db
    '            'For i As Integer = 0 To db.Rows.Count - 1
    '            '    Try
    '            '        If db.Rows(i).Item(1) > 0 Then
    '            '            Dim drow As DataRow = MeDG.DataSource.Rows.Find({pFaktur, meDBNull(db.Rows(i).Item(0))})
    '            '            If drow IsNot Nothing Then
    '            '                drow!Qty = meDBNullnum(db.Rows(i).Item(1))
    '            '            End If
    '            '        End If
    '            '    Catch ex As Exception

    '            '    End Try
    '            'Next
    '        Catch ex As Exception
    '            Pesan({ex.Message.ToString})
    '            Exit Sub
    '        End Try
    '    End If
    'End Sub

    Private Sub ImportExceltoSQL(path As String, strProc As String)
        Try
            Dim dtTabel As DataTable
            dtTabel = New DataTable
            dtTabel = ImportExcelWithOleDB(path)

            'Using dbtemp As New cMeDB
            '    dbtemp.ExecScalar("")
            '    dbtemp.FillMe("select * from table")
            'End Using

            Using dbtemp As New cMeDB
                dbtemp.ExecScalar("delete from trGoPayment")
            End Using

            Using sqlcon As New Data.SqlClient.SqlConnection(PubConnStr)
                sqlcon.Open()
                Dim sqlCmd = New Data.SqlClient.SqlCommand("spInserttrGoPaymentType", sqlcon)
                sqlCmd.CommandType = CommandType.StoredProcedure

                Dim SqlPar As New Data.SqlClient.SqlParameter
                SqlPar.SqlDbType = SqlDbType.Structured
                SqlPar = sqlCmd.Parameters.AddWithValue("@MyTableType", dtTabel)
                sqlCmd.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnOpenPaymentToped_Click(sender As Object, e As EventArgs) Handles btnOpenPaymentToped.Click
        ofdExcel.Filter = "Excel file |*.xls;*.xlsx"
        ofdExcel.Multiselect = False
        If ofdExcel.ShowDialog = DialogResult.OK Then
            ImportExceltoSQL(ofdExcel.FileName, "spInserttrGoPaymentType")

            'view by excel 
            Dim dtExcel As New DataTable

            Using sqlcon As New Data.SqlClient.SqlConnection(PubConnStr)
                sqlcon.Open()
                Dim sqlCmd = New Data.SqlClient.SqlCommand( _
                             "Select [Date],[Description],[Nominal (Rp)],[Balance (Rp)] from tblTopedExcel() order by date desc", _
                             sqlcon)
                Dim adp As New SqlDataAdapter(sqlCmd)
                adp.Fill(dtExcel)
            End Using
            gcExcel.DataSource = dtExcel

            FormatGridView(GridView2, , , True, , True)
            reFormatColumns(GridView2)
            ReArrangeColumnWidth(GridView2, {0.7, 3, 1, 1}, True, True)
            SetFooterSummarySUMs(GridView2, {"Nominal (Rp)", "Balance (Rp)"})

        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Application.Exit()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RadioGroup1.SelectedIndex = 0
        Using sqlcon As New Data.SqlClient.SqlConnection(PubConnStr)
            sqlcon.Open()
            Dim sqlCmd = New Data.SqlClient.SqlCommand( _
                         "delete from dbo.trGoPayment", _
                         sqlcon)
            sqlCmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub RptModel()
        Dim ds As New DataSet
        Dim dt1 As New DataTable
        Dim dt2 As New DataTable
        Dim strSQL As String = ""

        gcvIris.Columns.Clear()

        Select Case RadioGroup1.Properties.Items(RadioGroup1.SelectedIndex).Description.ToUpper
            Case "fj".ToUpper
                strSQL = _
                    "WITH cteExcelGoPay AS " & _
                    "( " & _
                        "SELECT " & _
                            "pvt.noInv, " & _
                            "ISNULL(pvt.[Transaksi],0) AS Transaksi, " & _
                            "ISNULL(pvt.[Potongan Ongkir],0) AS PotOngkir, " & _
                            "ISNULL(pvt.[Potongan Asuransi],0) AS PotAsuransi, " & _
                            "ISNULL(pvt.[Transaksi],0) + ISNULL(pvt.[Potongan Ongkir],0) + ISNULL(pvt.[Potongan Asuransi],0) AS TotalTrans, " & _
                            "ISNULL(pvt.[Potongan Merchant],0) AS PotMerchant " & _
                            "from " & _
                        "(SELECT nilai+NilaiMerchant AS NilaiTotal,Transaksi AS Trans,noInv FROM tblTopedExcel()) p " & _
                        "PIVOT " & _
                        "( " & _
                            "SUM(NilaiTotal) FOR Trans IN ([Transaksi],[Potongan Ongkir],[Potongan Asuransi],[Potongan Merchant]) " & _
                        ") AS pvt " & _
                        "WHERE pvt.noInv<>'' " & _
                    "), " & _
                    "cte2 as (SELECT a.noInv, a.[Transaksi], a.PotOngkir, a.PotAsuransi, a.TotalTrans, " & _
                    "               b.Tanggal, b.Faktur, b.KdCustomer, b.NamaCustomer, b.Total, b.Retur, b.Lunas, b.Sisa,a.PotMerchant, a.TotalTrans - isnull(b.Total,0) as Selisih " & _
                    "       FROM cteExcelGoPay a " & _
                    "       left JOIN dbo.vwSlHeader b ON b.Keterangan=a.noInv) " & _
                    "Select *, (select count(*) from cte2 where noInv = x.noInv) as urut " & _
                    "from cte2 x " & _
                    "ORDER BY noInv"

                Using sqlcon As New Data.SqlClient.SqlConnection(PubConnStr)
                    sqlcon.Open()
                    Dim sqlCmd = New Data.SqlClient.SqlCommand( _
                                 strSQL, _
                                 sqlcon)
                    Dim adp As New SqlDataAdapter(sqlCmd)
                    adp.Fill(dt1)
                End Using

                gcIris.DataSource = dt1
            Case "invoice".ToUpper
                strSQL = _
                    "WITH cteExcelGoPay AS " & _
                    "( " & _
                        "select noInv " & _
                        "from tblTopedExcel() " & _
                        "where noInv <> '' " & _
                        "GROUP BY noinv" & _
                    ") " & _
                    "SELECT b.noinv as noInv,a.Faktur,a.Total FROM dbo.trSLHeader a " & _
                    "INNER JOIN cteExcelGoPay b ON a.Keterangan=b.noinv "

                'Data1
                Using sqlcon As New Data.SqlClient.SqlConnection(PubConnStr)
                    sqlcon.Open()
                    Dim sqlCmd = New Data.SqlClient.SqlCommand( _
                                 "Select noInv,sum(Nilai) as Nilai,sum(NilaiMerchant) as NilaiMerchant from tblTopedExcel() where noInv<>'' group by noInv", _
                                 sqlcon)
                    Dim adp As New SqlDataAdapter(sqlCmd)
                    adp.Fill(dt1)
                End Using
                'add key1
                Dim primaryKey1(0) As DataColumn
                primaryKey1(0) = dt1.Columns("noInv")
                dt1.PrimaryKey = primaryKey1

                'Data2
                Using sqlcon As New Data.SqlClient.SqlConnection(PubConnStr)
                    sqlcon.Open()
                    Dim sqlCmd = New Data.SqlClient.SqlCommand(strSQL, sqlcon)
                    Dim adp As New SqlDataAdapter(sqlCmd)
                    adp.Fill(dt2)
                End Using

                ds.Tables.Add(dt1)
                ds.Tables.Add(dt2)
                ds.Relations.Add("FJ Online", dt1.Columns("noInv"), dt2.Columns("noInv"))

                gcIris.DataSource = ds.Tables("table1")
        End Select

        gcvIris.BestFitColumns()
        FormatGridView(gcvIris, , , True, , True)
        reFormatColumns(gcvIris)
        SetFooterSummarySUMs(gcvIris, {"Transaksi", "PotOngkir", "PotAsuransi", "TotalTrans", "Total", "Retur", "Lunas", "Sisa", "PotMerchant", "Selisih"})


        If gcvIris.Columns.Contains(gcvIris.Columns("urut")) Then gcvIris.Columns("urut").Visible = False
    End Sub

    Private Sub RadioGroup1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioGroup1.SelectedIndexChanged
        RptModel()
    End Sub

    Private Sub TabPane1_SelectedPageChanged(sender As Object, e As DevExpress.XtraBars.Navigation.SelectedPageChangedEventArgs) Handles TabPane1.SelectedPageChanged
        If e.Page.Caption.ToUpper = "view data iris".ToUpper Then
            RptModel()
        End If
    End Sub

    Private Sub gcvIris_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles gcvIris.CustomDrawCell
        If gcvIris.Columns.Contains(gcvIris.Columns("urut")) Then
            If gcvIris.GetRowCellValue(e.RowHandle, "urut") > 1 Then
                e.Appearance.ForeColor = Color.Blue
            End If
        End If

        If e.Column.FieldName = "Selisih" Then
            If gcvIris.GetRowCellValue(e.RowHandle, "Selisih") <> 0 Then
                e.Appearance.BackColor = Color.Red
                e.Appearance.ForeColor = Color.White
            End If
        End If
    End Sub
End Class


'--script
'CREATE TYPE [dbo].[trGoPaymentType] AS TABLE(
'	[Date] DATETIME NOT NULL,
'	[Description] VARCHAR(255)DEFAULT (''),
'	[Nominal (Rp)] MONEY DEFAULT (0),
'	[Balance (Rp)] MONEY DEFAULT (0)
')
'GO

'CREATE TABLE [trGoPayment]
'(
'	[Date] DATETIME NOT NULL,
'	[Description] VARCHAR(255)DEFAULT (''),
'	[Nominal (Rp)] MONEY DEFAULT (0),
'	[Balance (Rp)] MONEY DEFAULT (0)
');
'GO

'CREATE PROCEDURE [dbo].[spInserttrGoPaymentType] (@MyTableType dbo.trGoPaymentType READONLY)
'AS
'BEGIN

'      INSERT    INTO dbo.trGoPayment ([Date], [Description], [Nominal (Rp)], [Balance (Rp)])
'                SELECT  [Date], [Description], [Nominal (Rp)], [Balance (Rp)]
'                FROM    @MyTableType;
'END;
'GO
'GO

'CREATE FUNCTION tblTopedExcel
'(	
') 
'RETURNS TABLE 
'AS
'RETURN 
'(
'	-- Add the SELECT statement with parameter references here
'SELECT  
'[Date], [Description], [Nominal (Rp)], [Balance (Rp)],
'CASE WHEN CHARINDEX('INV/',[Description]) = 0 THEN '' ELSE SUBSTRING([Description],CHARINDEX('INV/',[Description]),(LEN([Description])-CHARINDEX('INV/',[Description]))+1) END AS noInv,
'CASE WHEN [Description] LIKE '%Transaksi Penjualan%' THEN 'Transaksi' ELSE 
'CASE WHEN [Description] LIKE '%Pemotongan%Asurans%' THEN 'Potongan Asuransi' ELSE  
'CASE WHEN [Description] LIKE '%Pemotongan%Merchant%' THEN 'Potongan Merchant' ELSE  
'CASE WHEN [Description] LIKE '%Pemotongan%Ongkir%' THEN 'Potongan Ongkir' ELSE '' END END END END AS Transaksi,
'CASE WHEN [Description] LIKE '%Transaksi Penjualan%' THEN [Nominal (Rp)] ELSE 
'CASE WHEN [Description] LIKE '%Pemotongan%Asurans%' THEN -[Nominal (Rp)] ELSE 
'CASE WHEN [Description] LIKE '%Pemotongan%Ongkir%' THEN -[Nominal (Rp)] ELSE 0 END END END AS Nilai,
'CASE WHEN [Description] LIKE '%Pemotongan%Merchant%' THEN -[Nominal (Rp)] ELSE 0 END AS NilaiMerchant
'FROM dbo.trGoPayment
')

'GO