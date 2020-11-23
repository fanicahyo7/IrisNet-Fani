﻿Imports meCore
Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class frmTotalWithdrawal

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        OpenFileDialog1.Filter = "(*.xlsx)|*.xlsx|(*.xls)|*.xls|All files (*.*)|*.*"
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        Else
            dgList.gvMain.LoadingPanelVisible = True
            tLokasi.Text = OpenFileDialog1.FileName
            Dim CONN As OleDbConnection
            Dim daexcel As OleDbDataAdapter
            Dim ds As New DataSet
            Dim TabelExcel As New cMeDB
            CONN = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" & _
                        "data source='" & OpenFileDialog1.FileName & "';Extended Properties=Excel 8.0;")

            Dim query As String = "select [Invoice],[Tanggal],[Total], 0 as [TotalFJ], '' as [Keterangan],'' as [KeteranganLunas] from [Sheet1$]"
            daexcel = New OleDbDataAdapter(query, CONN)
            ds.Clear()
            daexcel.Fill(TabelExcel)

            dgList.DataSource = TabelExcel
            dgList.colFitGrid = True
            dgList.colWidth = {1, 0.5, 0.8, 0.8, 0.8}
            dgList.RefreshDataView()

            Dim keterangan As Integer = 0
            Dim keteranganlunas As Integer = 0
            Dim keteranganFJ As Integer = 0
            For a = 0 To dgList.gvMain.RowCount - 1
                Dim qcaritotalFJ As String = _
                    "select sum(isnull(a.Total,0)) - sum(isnull(b.Total,0)) as Total from trSLHeader a " & _
                    "left join trSLRHeader b on a.Faktur=b.FakturJual " & _
                    "where a.Keterangan='" & dgList.GetRowCellValue(a, "Invoice") & "'"
                cmd = New SqlCommand(qcaritotalFJ, kon)
                rd = cmd.ExecuteReader
                rd.Read()
                If rd.HasRows Then
                    dgList.SetRowCellValue(a, "TotalFJ", rd!Total)
                Else
                    dgList.SetRowCellValue(a, "TotalFJ", 0)
                End If
                rd.Close()

                Dim qcaritotalFJlunas As String = _
                    "select case when sum(a.Total-b.Jumlah) = 0 then 'Terdapat FJ Lunas' else 'Belum Lunas' end as Lunas from trSLHeader a " & _
                    "left join trLPtgDetail b on a.Faktur = b.FakturAsli " & _
                    "where a.Keterangan='" & dgList.GetRowCellValue(a, "Invoice") & "'"
                cmd = New SqlCommand(qcaritotalFJlunas, kon)
                rd = cmd.ExecuteReader
                rd.Read()
                If rd.HasRows Then
                    dgList.SetRowCellValue(a, "KeteranganLunas", rd!Lunas)
                    If rd!Lunas = "Terdapat FJ Lunas" Then
                        keteranganlunas += 1
                    End If
                Else
                    dgList.SetRowCellValue(a, "KeteranganLunas", "unknown")
                End If
                rd.Close()

                Dim totalfj As Double = 0
                Dim datanull As Boolean = False
                If IsDBNull(dgList.GetRowCellValue(a, "TotalFJ")) Then
                    totalfj = 0
                    datanull = True
                Else
                    totalfj = dgList.GetRowCellValue(a, "TotalFJ")
                End If
                Dim total As Double = 0
                If IsDBNull(dgList.GetRowCellValue(a, "Total")) Then
                    total = 0
                    datanull = True
                Else
                    total = dgList.GetRowCellValue(a, "Total")
                End If

                If total = totalfj And datanull = False Then
                    dgList.SetRowCellValue(a, "Keterangan", True)
                Else
                    dgList.SetRowCellValue(a, "Keterangan", False)
                    keterangan += 1
                End If
            Next

            If keterangan > 0 Or keteranganlunas > 0 Then
                btnPelunasan.Enabled = False
            Else
                btnPelunasan.Enabled = True
            End If

            dgList.colSum = {"Total", "TotalFJ"}
            dgList.RefreshDataView()
            dgList.gvMain.LoadingPanelVisible = False
        End If
    End Sub

    Private Sub frmTotalWithdrawal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        SetTextReadOnly({tLokasi})
    End Sub

    Private Sub dgList_Grid_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles dgList.Grid_CustomDrawCell
        If dgList.GetRowCellValue(e.RowHandle, "Keterangan").ToString = "False" Or dgList.GetRowCellValue(e.RowHandle, "KeteranganLunas").ToString = "Terdapat FJ Lunas" Then
            e.Appearance.ForeColor = Color.Red
        Else
            e.Appearance.ForeColor = Color.Green
        End If
    End Sub

    Private Sub dgList_Grid_DoubleClick(sender As Object, e As EventArgs) Handles dgList.Grid_DoubleClick
        Using xx As New frmTotalWithdrawalDetail
            xx.Tag = dgList.GetRowCellValue(dgList.FocusedRowHandle, "Invoice")
            xx.ShowDialog()
        End Using
    End Sub

    Private Sub btnPelunasan_Click(sender As Object, e As EventArgs) Handles btnPelunasan.Click
        If tNoBukti.Text = "" Then
            MsgBox("No. Bukti Belum diisi!!", vbCritical + vbOKOnly, "Peringatan")
        Else
            Dim invoice As String = ""
            For a = 0 To dgList.gvMain.RowCount - 1
                invoice += "'" & dgList.GetRowCellValue(a, "Invoice") & "',"
                If a = dgList.gvMain.RowCount - 1 Then
                    invoice += "'" & dgList.GetRowCellValue(a, "Invoice") & "'"
                End If
            Next

            If invoice = "" Then
                invoice = "''"
            End If

            Dim dtcustomer As New cMeDB
            Dim query As String = _
                "select kdcustomer,count(KdCustomer) from trSLHeader where Keterangan in (" & invoice & ") group by KdCustomer"
            dtcustomer.FillMe(query)

            If dtcustomer.Rows.Count > 1 Then
                MsgBox("Data Memiliki KdCustomer Lebih dari Satu." + vbCrLf + "Mohon Periksa Kembali!!", vbCritical + vbOKOnly, "Peringatan")
            Else
                Dim fakturpp As String = _
                    GetNewFakturTogamasSQLServ(PubConnStr, "trLPtgHeader", FakturReset.Tahunan, "Faktur", pubKodeUnit & pubUserInit & "-PP", DTOC(Now), 5, "")

                Dim carifj As String = _
                    "select * from trSLHeader where Keterangan in (" & invoice & ")"
                Dim dtfj As New cMeDB
                dtfj.FillMe(carifj)

                Dim result As Double = Convert.ToDouble(dtfj.Compute("SUM(Total)", String.Empty))


                Dim simpanheader As String = _
                    "insert into trLPtgHeader (Faktur,KdCustomer,Tanggal,TglLunas,SubTotal,Total,Tunai,UserEntry,DateTimeEntry,NoBukti,Pembulatan) values " & _
                    "('" & fakturpp & "')"


                Dim simpandetail As String = _
                    "insert into trLPtgDetail (Faktur,Tanggal,FakturAsli,Jumlah) values ()"

            End If
        End If
    End Sub
End Class