Imports meCore
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports DevExpress.Printing.ExportHelpers
Imports DevExpress.Export
Imports DevExpress.Export.Xl
Public Class frmPBYexportExcel
    Public Event CustomizeSheetHeader As CustomizeSheetHeaderEventHandler

    Dim nopengajuan As String = ""
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(nopengajuan As String)
        InitializeComponent()
        Me.nopengajuan = nopengajuan
    End Sub
    Private Sub frmPBYexportExcel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lNoPengajuan.Text = nopengajuan

        Dim query As String = "SELECT * FROM vwpengajuanBayarDt WHERE NoPengajuan = '" & nopengajuan & "' order by nopengajuan,nobtt"
        dgList.FirstInit(query, {1, 1.2, 1.2, 0.8, 0.8, 1.2, 1.2, 0.8, 0.8, 1, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 1}, , , , , , False)
        dgList.RefreshData(False)
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Dim saveFileDialog1 As New SaveFileDialog
        saveFileDialog1.Filter = "Excel File|*.xlsx"
        saveFileDialog1.Title = "Save an Excel File"
        saveFileDialog1.ShowDialog()

        DevExpress.Export.ExportSettings.DefaultExportType = ExportType.DataAware

        Dim options As New XlsxExportOptionsEx

        AddHandler options.CustomizeSheetHeader, AddressOf options_CustomizeSheetHeader


        dgList.gcMain.ExportToXlsx(saveFileDialog1.FileName, options)

        System.Diagnostics.Process.Start(saveFileDialog1.FileName)
    End Sub

    Private Sub options_CustomizeSheetHeader(e As DevExpress.Export.ContextEventArgs)
        ' Create a new row.
        Dim row As New CellObject()
        Dim row2 As New CellObject()
        ' Specify row values.
        row.Value = "PENGAJUAN PEMBAYARAN SUPPLIER"
        row2.Value = "No. Pengajuan: " & nopengajuan
        ' Specify row formatting.
        Dim rowFormatting As New XlFormattingObject()
        rowFormatting.Font = New XlCellFont() With { _
            .Bold = True, _
            .Size = 14 _
        }
        Dim rowFormatting2 As New XlFormattingObject()
        rowFormatting2.Font = New XlCellFont() With { _
            .Bold = True, _
            .Size = 11 _
        }
        'rowFormatting.Alignment = New DevExpress.Export.Xl.XlCellAlignment() With { _
        '    .HorizontalAlignment = DevExpress.Export.Xl.XlHorizontalAlignment.Center, _
        '    .VerticalAlignment = DevExpress.Export.Xl.XlVerticalAlignment.Top _
        '}
        row.Formatting = rowFormatting
        row2.Formatting = rowFormatting2
        ' Add the created row to the output document.
        e.ExportContext.AddRow({row, row2})

        ' Add an empty row to the output document.
        e.ExportContext.AddRow()
        ' Merge cells of two new rows. 
        'e.ExportContext.MergeCells(New DevExpress.Export.Xl.XlCellRange(New DevExpress.Export.Xl.XlCellPosition(0, 0), New DevExpress.Export.Xl.XlCellPosition(27, 1)))
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Me.Close()
    End Sub
End Class