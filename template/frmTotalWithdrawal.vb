Imports meCore
Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class frmTotalWithdrawal

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        OpenFileDialog1.Filter = "(*.xlsx)|*.xlsx|(*.xls)|*.xls|All files (*.*)|*.*"
        Try
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

                Dim query As String = "select [Invoice],[Tanggal],[Total], 0 as [TotalFJ], 0 as [TotalFJSimpan], '' as [Keterangan],'' as [KeteranganLunas] from [Sheet1$]"
                daexcel = New OleDbDataAdapter(query, CONN)
                ds.Clear()
                daexcel.Fill(TabelExcel)

                dgList.DataSource = TabelExcel
                dgList.colFitGrid = True
                dgList.colWidth = {1, 0.5, 0.8, 0.8, 0.8, 0.8}
                dgList.RefreshDataView()

                Dim keterangan As Integer = 0
                Dim keteranganlunas As Integer = 0
                Dim keteranganFJ As Integer = 0
                Dim cashback As Double = 0
                Dim bypromosi As Double = 0
                Dim bykomisi As Double = 0
                Dim bykerugian As Double = 0
                Dim piutangongkir As Double = 0
                For a = 0 To dgList.gvMain.RowCount - 1

                    Dim iscashback As Boolean = False
                    If IsDBNull(dgList.GetRowCellValue(a, "Invoice")) Then
                        iscashback = True
                    ElseIf dgList.GetRowCellValue(a, "Invoice") = "#VALUE!" Then
                        iscashback = True
                    End If

                    If iscashback = True Then
                        dgList.SetRowCellValue(a, "Invoice", "CASHBACK")
                    End If

                    'Dim qcaritotalFJ As String = _
                    '    "with cteSL as(" & _
                    '        "select Faktur,sum(isnull(Total,0)) as Total from trSLHeader where Keterangan='" & dgList.GetRowCellValue(a, "Invoice") & "' " & _
                    '        "group by Faktur " & _
                    '        ")," & _
                    '        "cteSLR as (" & _
                    '        "select a.Faktur, sum(isnull(b.Total,0)) as TotalR from cteSL a " & _
                    '        "left join trSLRHeader b on a.Faktur = b.FakturJual " & _
                    '        "group by a.Faktur " & _
                    '        ") " & _
                    '        "select a.Total-b.TotalR as Total from cteSL a " & _
                    '        "left join cteSLR b " & _
                    '        "on a.Faktur = b.Faktur"

                    Dim qcaritotalFJ As String = _
                        "with cteSL as(" & _
                            "select Faktur,sum(isnull(Total,0)) as Total," & _
                            "sum(MarketPlaceByKerugian) as MarketPlaceByKerugian,sum(MarketPlaceByKomisi) as MarketPlaceByKomisi," & _
                            "sum(MarketPlaceByPromosi) as MarketPlaceByPromosi,sum(MarketPlacePiutangOngkir) as MarketPlacePiutangOngkir " & _
                            "from trSLHeader where Keterangan='" & dgList.GetRowCellValue(a, "Invoice") & "' " & _
                            "group by Faktur " & _
                            ")," & _
                            "cteSLR as (" & _
                            "select a.Faktur, sum(isnull(b.Total,0)) as TotalR from cteSL a " & _
                            "left join trSLRHeader b on a.Faktur = b.FakturJual " & _
                            "group by a.Faktur " & _
                            ") " & _
                            "select a.Total-b.TotalR as Total, (a.Total-b.TotalR-a.MarketPlaceByKerugian-a.MarketPlaceByKomisi-a.MarketPlaceByPromosi-a.MarketPlacePiutangOngkir) as TotalBanding," & _
                            "a.MarketPlaceByKerugian,a.MarketPlaceByKomisi,a.MarketPlaceByPromosi,a.MarketPlacePiutangOngkir from cteSL a " & _
                            "left join cteSLR b " & _
                            "on a.Faktur = b.Faktur"

                    cmd = New SqlCommand(qcaritotalFJ, kon)
                    rd = cmd.ExecuteReader
                    rd.Read()
                    If rd.HasRows Then
                        dgList.SetRowCellValue(a, "TotalFJ", rd!TotalBanding)
                        dgList.SetRowCellValue(a, "TotalFJSimpan", rd!Total)

                        bykerugian += CDbl(rd!MarketPlaceByKerugian)
                        bykomisi += CDbl(rd!MarketPlaceByKomisi)
                        bypromosi += CDbl(rd!MarketPlaceByPromosi)
                        piutangongkir += CDbl(rd!MarketPlacePiutangOngkir)
                    Else
                        dgList.SetRowCellValue(a, "TotalFJ", 0)
                        dgList.SetRowCellValue(a, "TotalFJSimpan", 0)

                        bykerugian += 0
                        bykomisi += 0
                        bypromosi += 0
                        piutangongkir += 0
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

                    Dim total As Double = 0
                    If IsDBNull(dgList.GetRowCellValue(a, "Total")) Then
                        total = 0
                        datanull = True
                    Else
                        total = dgList.GetRowCellValue(a, "Total")
                    End If

                    If IsDBNull(dgList.GetRowCellValue(a, "TotalFJSimpan")) Or dgList.GetRowCellValue(a, "TotalFJSimpan") = 0 Then
                        If dgList.GetRowCellValue(a, "Invoice").ToString.ToUpper = "CASHBACK" Then
                            dgList.SetRowCellValue(a, "TotalFJ", dgList.GetRowCellValue(a, "Total"))
                            dgList.SetRowCellValue(a, "TotalFJSimpan", dgList.GetRowCellValue(a, "Total"))
                            totalfj = dgList.GetRowCellValue(a, "TotalFJ")
                            cashback += CDbl(dgList.GetRowCellValue(a, "TotalFJSimpan"))
                            dgList.SetRowCellValue(a, "Tanggal", dgList.GetRowCellValue(a - 1, "Tanggal"))
                        Else
                            totalfj = 0
                            datanull = True
                        End If
                    Else
                        totalfj = dgList.GetRowCellValue(a, "TotalFJ")
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

                dgList.colSum = {"Total", "TotalFJ", "TotalFJSimpan"}
                dgList.RefreshDataView()
                Dim ttlfj4nilai As Double = dgList.GetSummaryColDB("TotalFJ")
                sTotal.EditValue = ttlfj4nilai
                sCashback.EditValue = cashback
                Dim ttl As Double = dgList.GetSummaryColDB("TotalFJSimpan")
                sTotalTunai.EditValue = ttl - cashback
                sTotalByKerugian.EditValue = bykerugian
                sTotalByKomisi.EditValue = bykomisi
                sTotalByPromosi.EditValue = bypromosi
                sTotalPiutangOngkir.EditValue = piutangongkir
            End If
        Catch ex As Exception
            MsgBox("Format Excel Salah!" & vbCrLf & "Silahkan cek Format Excel anda.", vbCritical + vbOKOnly, "Peringatan")
            dgList.Grid_ClearData()
            tLokasi.Text = ""
            btnPelunasan.Enabled = False
            sTotalByPromosi.EditValue = 0
            sTotalTunai.EditValue = 0
            tNoBukti.Text = ""
        End Try
        dgList.gvMain.LoadingPanelVisible = False
    End Sub

    Private Sub frmTotalWithdrawal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        SetTextReadOnly({tLokasi, sTotalByPromosi, sTotalTunai, sTotalByKerugian, sTotalByKomisi, sTotalPiutangOngkir, sTotal, sCashback})
        tNoBukti.Properties.CharacterCasing = CharacterCasing.Upper
        bersih()
        LayoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        LayoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        btnPelunasan.Enabled = False
    End Sub

    Private Sub dgList_Grid_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles dgList.Grid_CustomDrawCell
        If dgList.GetRowCellValue(e.RowHandle, "Keterangan").ToString = "False" Or dgList.GetRowCellValue(e.RowHandle, "KeteranganLunas").ToString = "Terdapat FJ Lunas" Then
            e.Appearance.ForeColor = Color.Red
        Else
            e.Appearance.ForeColor = Color.Green
        End If
    End Sub

    Private Sub dgList_Grid_DoubleClick(sender As Object, e As EventArgs) Handles dgList.Grid_DoubleClick
        If dgList.gvMain.RowCount >= 1 Then
            Using xx As New frmTotalWithdrawalDetail
                xx.Tag = dgList.GetRowCellValue(dgList.FocusedRowHandle, "Invoice")
                xx.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub btnPelunasan_Click(sender As Object, e As EventArgs) Handles btnPelunasan.Click
        'If tNoBukti.Text = "" Then
        '    MsgBox("No. Bukti Belum diisi!!", vbCritical + vbOKOnly, "Peringatan")
        'Else
        Dim konfirmasi As String = MsgBox("Apakah Anda Yakin Melakukan Pelunasan?", vbQuestion + vbYesNo, "Konfirmasi")
        If konfirmasi = vbYes Then

            Dim invoice As String = ""
            For a = 0 To dgList.gvMain.RowCount - 1
                If a = dgList.gvMain.RowCount - 1 Then
                    invoice += "'" & dgList.GetRowCellValue(a, "Invoice") & "'"
                Else
                    invoice += "'" & dgList.GetRowCellValue(a, "Invoice") & "',"
                End If
            Next

            If invoice = "" Then
                invoice = "''"
            End If

            Dim dtcustomer As New cMeDB
            Dim query As String = _
                "select kdcustomer,count(KdCustomer) from trSLHeader where Keterangan in (" & invoice & ") group by KdCustomer"
            dtcustomer.FillMe(query)

            Dim cstmr1 As Boolean = False
            If dtcustomer.Rows.Count > 1 Then
                cstmr1 = True
            End If

            Dim tgl1 As Boolean = False
            Dim disticttgl As DataTable = dgList.DataSource.DefaultView.ToTable(True, "Tanggal")
            If disticttgl.Rows.Count > 1 Then
                tgl1 = True
            End If

            If cstmr1 = True Then
                MsgBox("Data Memiliki KdCustomer Lebih dari Satu." + vbCrLf + "Mohon Periksa Kembali!!", vbCritical + vbOKOnly, "Peringatan")
            ElseIf tgl1 = True Then
                MsgBox("Data Memiliki Tanggal Berbeda." + vbCrLf + "Mohon Periksa Kembali!!", vbCritical + vbOKOnly, "Peringatan")
            Else
                Dim fakturpp As String = _
                    GetNewFakturTogamasSQLServ(PubConnStr, "trLPtgHeader", FakturReset.Tahunan, "Faktur", pubKodeUnit & pubUserInit & "-PP", DTOC(Now), 5, "")

                Dim fakturptgwithdrawal As String = _
                    GetNewFakturTogamasSQLServ(PubConnStr, "trLPtgWithdrawal", FakturReset.Tahunan, "Faktur", pubKodeUnit & pubUserInit & "-WD", DTOC(Now), 5, "")

                Dim carifj As String = _
                    "select * from trSLHeader where Keterangan in (" & invoice & ")"
                Dim dtfj As New cMeDB
                dtfj.FillMe(carifj)

                'Dim sumresult As Double = Convert.ToDouble(dtfj.Compute("SUM(Total)", String.Empty))

                Dim dtdisticnt As DataTable = dtfj.DefaultView.ToTable(True, "KdCustomer")

                Try
                    Dim q As String = "begin try begin transaction "
                    q += "insert into trLPtgHeader (Faktur,KdCustomer,Tanggal,TglLunas,SubTotal,Total,Tunai,UserEntry,DateTimeEntry,NoBukti,Pembulatan) values " & _
                        "('" & fakturpp & "','" & dtdisticnt.Rows(0)!KdCustomer & "','" & DTOC(disticttgl.Rows(0)!Tanggal, "-", False) & "','" & DTOC(disticttgl.Rows(0)!Tanggal, "-", False) & "'," & _
                        "'" & sTotalByPromosi.Text & "','" & sTotalByPromosi.Text & "','" & sTotalTunai.Text & "','" & pubUserEntry & "','" & DTOC(Now, "-", True) & "','" & fakturptgwithdrawal & "','0'); " & _
                        "update trLPtgHeader set Fire=1 where Faktur='" & fakturpp & "'; "

                    q += "insert into trLPtgWithdrawal (Faktur,FakturPP,UserEntry,DateTimeEntry) values " & _
                        "('" & fakturptgwithdrawal & "','" & fakturpp & "','" & pubUserEntry & "','" & DTOC(Now, "-", True) & "'); "

                    For a = 0 To dtfj.Rows.Count - 1
                        q += _
                       "insert into trLPtgDetail (Faktur,Tanggal,FakturAsli,Jumlah,Urutan) values (" & _
                       "'" & fakturpp & "','" & DTOC(disticttgl.Rows(0)!Tanggal, "-", False) & "','" & dtfj.Rows(a)!Faktur & "','" & dtfj.Rows(a)!Total & "','" & a & "'); " & _
                       "update trLPtgDetail set Fire=1,Jumlah=Jumlah,FakturAsli=FakturAsli where Faktur='" & fakturpp & "' ; "
                    Next

                    q += "commit select 'sukses' as statusx end try begin catch rollback select 'gagal : ' + ERROR_MESSAGE() as statusx end catch"

                    Dim db As New DataTable
                    da = New SqlDataAdapter(q, kon)
                    da.Fill(db)

                    If db.Rows.Count > 0 Then
                        If (db.Rows(0)!statusx).ToString.Contains("gagal") Then
                            Pesan({"Penyimpanan gagal", "", db.Rows(0)!statusx})
                        Else
                            MsgBox("Pelunasan Berhasil", vbInformation + vbOKOnly, "Informasi")
                        End If
                    End If

                    bersih()
                Catch ex As Exception
                    MsgBox(ex.Message, vbOKOnly + vbCritical, "Peringatan")
                End Try

                'MsgBox("Pelunasan Berhasil", vbInformation + vbOKOnly, "Informasi")
                'bersih()
            End If
        End If
    End Sub
    Sub bersih()
        sTotalByPromosi.EditValue = 0
        sTotalTunai.EditValue = 0
        tLokasi.Text = ""
        tNoBukti.Text = ""

        Dim query As String = _
            "select cast('' as varchar(225)) as Invoice,cast('' as varchar(225)) as Tanggal,cast(0 as numeric(10)) as Total, cast(0 as numeric(10)) as TotalFJ, cast('' as varchar(225)) as Keterangan,cast('' as varchar(225)) as KeteranganLunas from trSLHeader where Faktur='jdhfsjkdbg3465655sdgdfg'"
        dgList.FirstInit(query, {1, 0.5, 0.8, 0.8, 0.8}, , , , , , True)
        dgList.RefreshData(False)
    End Sub

    Private Sub dgList_Load(sender As Object, e As EventArgs) Handles dgList.Load

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        OpenFileDialog1.Filter = "Excel file |*.xls;*.xlsx"
        OpenFileDialog1.Multiselect = False
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            tLokasi.Text = OpenFileDialog1.FileName
            If Len(tLokasi.Text) > 0 Then
                Try
                    Dim pKode As String = ""
                    Dim cLio As New cClosedXML
                    Dim ds As DataSet = cLio.XLStoDataset_thisWorking(tLokasi.Text)
                    Dim db As New cMeDB
                    db.FillMe(ds.Tables(0))
                    'Dim db As DataTable = cLio.xlsxToDT(txtFileExcel.Text)
                    'For i As Integer = 0 To db.Rows.Count - 1
                    '    Try
                    '        If db.Rows(i).Item(1) > 0 Then
                    '            Dim drow As DataRow = dgList.DataSource.Rows.Find({Invoice, meDBNull(db.Rows(i).Item(0))})
                    '            If drow IsNot Nothing Then
                    '                drow!Qty = meDBNullnum(db.Rows(i).Item(1))
                    '            End If
                    '        End If
                    '    Catch ex As Exception

                    '    End Try
                    'Next

                    dgList.DataSource = db
                    dgList.RefreshDataView()
                Catch ex As Exception
                    Pesan({ex.Message.ToString})
                    Exit Sub
                End Try
            End If
        Else
            tLokasi.Text = ""
        End If
    End Sub

    Private Sub btnContohExcel_Click(sender As Object, e As EventArgs) Handles btnContohExcel.Click
        Using xx As New frmFormatExcel
            xx.ShowDialog(Me)
        End Using
    End Sub
End Class