Imports meCore
Public Class frmValidReturBeli

    Dim tabel As String = ""
    Dim tableDetail As String = ""
    Dim tablesupcus As String = ""
    Public judul As String = ""

    Private Sub frmValidReturBeli_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'txtJudul.Text = "Retur Pembelian"
        txtJudul.Text = Text

        dTanggal2.EditValue = Now
        dtanggal1.EditValue = DateAdd(DateInterval.Day, -44, dTanggal2.EditValue)

        Select Case Replace(txtJudul.Text.ToLower, "validasi ", "", , , CompareMethod.Text)
            Case "retur pembelian"
                tabel = "trPCRHeader"
                tableDetail = "trPCRDetail"
                tablesupcus = "mstsupplier"
            Case "pembelian"
                tabel = "trPCHeader"
                tableDetail = "trPCDetail"
                tablesupcus = "mstsupplier"
            Case "penjualan"
                tabel = "trSLHeader"
                tableDetail = "trSLDetail"
                tablesupcus = "mstcustomer"
            Case "retur penjualan"
                tabel = "trSLRHeader"
                tableDetail = "trSLRDetail"
                tablesupcus = "mstcustomer"
            Case "penerimaan konsinyasi"
                tabel = "trKonsHeader"
                tableDetail = "trKonsDetail"
                tablesupcus = "mstsupplier"
            Case "retur penerimaan konsinyasi"
                tabel = "trKonsRHeader"
                tableDetail = "trKonsRDetail"
                tablesupcus = "mstsupplier"
            Case "mutasi gudang"
                tabel = "trMTHeader"
                tableDetail = "trMTDetail"
            Case "kirim konsinyasi"
                tabel = "trSKonsHeader"
                tableDetail = "trSKonsDetail"
                tablesupcus = "mstcustomer"
            Case "retur kirim konsinyasi"
                tabel = "trSkonsRHeader"
                tableDetail = "trSKonsRDetail"
            Case "terima ekspedisi"
                tabel = "trTerimaEkspedisi"
            Case "kirim ekspedisi"
                tabel = "trKirimEkspedisi"
        End Select

        cData.Text = "Belum Validasi"
    End Sub

    Private Sub btnTampilData_Click(sender As Object, e As EventArgs) Handles btnTampilData.Click
        Dim squery As String = ""
        Dim kondisi As String = ""

        If cData.Text = "Belum Validasi" Then
            kondisi = kondisi & " and isnull(UserValid,'') = '' "
        ElseIf cData.Text = "Sudah Validasi" Then
            kondisi = kondisi & " and isnull(UserValid,'') <> '' "
        End If

        Dim tbl As String = ""
        Select Case txtJudul.Text.ToLower
            Case "validasi retur pembelian"
                squery = "select Faktur, FakturBeli, Tanggal, NamaSupplier, SubTotal, Discount, Total, Checker, UserValid, DateTimeValid " & _
                    "from vwPCRHeader where convert(varchar(8),Tanggal,112) between '" & Format(CDate(dtanggal1.Text), "yyyyMMdd") & "' and '" & Format(CDate(dTanggal2.Text), "yyyyMMdd") & "' " & kondisi & " Order by Faktur Desc"
                CtrlMeDataGrid1.FirstInit(squery, {1, 1, 0.5, 1.5, 0.8, 0.5, 0.8, 0.5, 0.5, 0.7})
            Case "validasi pembelian"
                squery = "select Faktur, FakturAsli, Tanggal, NamaSupplier, SubTotal, Discount, PPN, Total, Checker, UserValid, DateTimeValid " & _
                    "from vwPCHeader where convert(varchar(8),Tanggal,112) between '" & Format(CDate(dtanggal1.Text), "yyyyMMdd") & "' and '" & Format(CDate(dTanggal2.Text), "yyyyMMdd") & "' " & kondisi & " Order by Faktur Desc"
                CtrlMeDataGrid1.FirstInit(squery, {1, 1.5, 0.5, 1.5, 0.8, 0.5, 0.5, 0.5, 0.5, 0.5, 0.7})
            Case "validasi penerimaan konsinyasi"
                squery = "select Faktur, FakturAsli, Tanggal, NamaSupplier, SubTotal, Discount, Total, Checker, UserValid, DateTimeValid " & _
                    "from vwKonsHeader where convert(varchar(8),Tanggal,112) between '" & Format(CDate(dtanggal1.Text), "yyyyMMdd") & "' and '" & Format(CDate(dTanggal2.Text), "yyyyMMdd") & "' " & kondisi & " Order by Faktur Desc"
                CtrlMeDataGrid1.FirstInit(squery, {1, 1.5, 0.5, 1.5, 0.8, 0.5, 0.5, 0.5, 0.5, 0.7})
            Case "validasi retur penerimaan konsinyasi"
                squery = "select Faktur, FakturKons, Tanggal, NamaSupplier, SubTotal, Discount, Total, Checker, UserValid, DateTimeValid " & _
                    "from vwKonsRHeader where convert(varchar(8),Tanggal,112) between '" & Format(CDate(dtanggal1.Text), "yyyyMMdd") & "' and '" & Format(CDate(dTanggal2.Text), "yyyyMMdd") & "' " & kondisi & " Order by Faktur Desc"
                CtrlMeDataGrid1.FirstInit(squery, {1, 1, 0.5, 1.5, 0.5, 0.5, 0.5, 0.3, 0.3, 0.4})
            Case "validasi penjualan"
                squery = "select Faktur, Tanggal, NamaCustomer, SubTotal, Discount, Total, Checker, UserValid, DateTimeValid " & _
                    "from vwSLHeader where convert(varchar(8),Tanggal,112) between '" & Format(CDate(dtanggal1.Text), "yyyyMMdd") & "' and '" & Format(CDate(dTanggal2.Text), "yyyyMMdd") & "' " & kondisi & " Order by Faktur Desc"
                CtrlMeDataGrid1.FirstInit(squery, {0.6, 0.5, 1.5, 0.5, 0.5, 0.5, 0.3, 0.3, 0.4})
            Case "validasi retur penjualan"
                squery = "select Faktur, Tanggal, NamaCustomer, SubTotal, Discount, Total, Checker, UserValid, DateTimeValid " & _
                    "from vwSLRHeader where convert(varchar(8),Tanggal,112) between '" & Format(CDate(dtanggal1.Text), "yyyyMMdd") & "' and '" & Format(CDate(dTanggal2.Text), "yyyyMMdd") & "' " & kondisi & " Order by Faktur Desc"
                CtrlMeDataGrid1.FirstInit(squery, {0.6, 0.5, 1.5, 0.5, 0.5, 0.5, 0.3, 0.3, 0.4})
            Case "validasi mutasi gudang"
                squery = "select Faktur, FakturAsli, DateTimeEntry, Dari, Ke, Checker, UserValid, DateTimeValid " & _
                    "from vwMTHeader where convert(varchar(8),Tanggal,112) between '" & Format(CDate(dtanggal1.Text), "yyyyMMdd") & "' and '" & Format(CDate(dTanggal2.Text), "yyyyMMdd") & "' " & kondisi & " Order by Faktur Desc"
                CtrlMeDataGrid1.FirstInit(squery, {1, 1, 0.5, 0.4, 0.4, 0.3, 0.3, 0.4})
            Case "validasi kirim konsinyasi"
                squery = "select Faktur, Tanggal, NamaCustomer, SubTotal, Discount, Total, Checker, UserValid, DateTimeValid " & _
                    "from vwSKonsHeader where convert(varchar(8),Tanggal,112) between '" & Format(CDate(dtanggal1.Text), "yyyyMMdd") & "' and '" & Format(CDate(dTanggal2.Text), "yyyyMMdd") & "' " & kondisi & " Order by Faktur Desc"
                CtrlMeDataGrid1.FirstInit(squery, {0.6, 0.5, 1.5, 0.5, 0.5, 0.5, 0.3, 0.3, 0.4})
            Case "validasi retur kirim konsinyasi"
                squery = "select Faktur, Tanggal, NamaCustomer, SubTotal, Discount, Total, Checker, UserValid, DateTimeValid " & _
                    "from vwSKonsRHeader where convert(varchar(8),Tanggal,112) between '" & Format(CDate(dtanggal1.Text), "yyyyMMdd") & "' and '" & Format(CDate(dTanggal2.Text), "yyyyMMdd") & "' " & kondisi & " Order by Faktur Desc"
                CtrlMeDataGrid1.FirstInit(squery, {0.6, 0.5, 1.5, 0.5, 0.5, 0.5, 0.3, 0.3, 0.4})
            Case "validasi event pameran"
                If cData.Text = "Belum Validasi" Then
                    kondisi = " and isnull(UserValidate,'') = '' "
                ElseIf cData.Text = "Sudah Validasi" Then
                    kondisi = " and isnull(UserValidate,'') <> '' "
                Else
                    kondisi = ""
                End If
                squery = "select kode, datetimeentry as Tanggal, Keterangan, tglawal, tglakhir, Selisih = case when DateDiff(day, getdate(), tglakhir) > 0 then DateDiff(day, getdate(), tglakhir)  else 0 end , Jual, Retur," & _
                    "JenisEvent, Status = case FlagActive when 1 then 'ACTIVE' else 'NON-ACTIVE' end, OnOFf = case FlagOn when 1 then 'ON' else 'OFF' end, UserValidate, DateTimeValidate " & _
                    "from mstEvent " & _
                    "where convert(varchar(8), datetimeentry,112) between '" & Format(CDate(dtanggal1.Text), "yyyyMMdd") & "' and '" & Format(CDate(dTanggal2.Text), "yyyyMMdd") & "' " & kondisi & " " & _
                    "order by FlagActive desc, Kode"
                CtrlMeDataGrid1.FirstInit(squery, {0.7, 0.7, 2, 0.5, 0.5, 0.5, 0.5, 0.5, 1, 0.5, 0.3, 0.5, 0.4})
            Case "validasi terima ekspedisi"
                squery = "select Faktur, Tanggal, CaraKirim, Dari, TglTerima, NoNota, JenisBarang, Checker, UserValid, DateTimeValid " & _
                    "from vwTerimaEkspedisi where convert(varchar(8),Tanggal,112) between '" & Format(CDate(dtanggal1.Text), "yyyyMMdd") & "' and '" & Format(CDate(dTanggal2.Text), "yyyyMMdd") & "' " & kondisi & " Order by Faktur Desc"
                CtrlMeDataGrid1.FirstInit(squery, {0.6, 0.5, 0.5, 1, 0.5, 0.8, 0.7, 0.4, 0.4, 0.4})
            Case "validasi kirim ekspedisi"
                squery = "select Faktur, Jenis, Tanggal, CaraKirim, DikirimDari,TglKirim, KodeEkspedisi,NoNotaEkspedisi, JenisBarang,PIC, Checker, UserValid, DateTimeValid " & _
                    "from vwKirimEkspedisi where convert(varchar(8),Tanggal,112) between '" & Format(CDate(dtanggal1.Text), "yyyyMMdd") & "' and '" & Format(CDate(dTanggal2.Text), "yyyyMMdd") & "' " & kondisi & " Order by Faktur Desc"
                CtrlMeDataGrid1.FirstInit(squery, {0.8, 1.5, 0.5, 0.8, 0.8, 0.5, 0.5, 0.7, 0.5, 0.5, 0.4, 0.4, 0.4})
        End Select
        CtrlMeDataGrid1.RefreshData()
    End Sub

    Private Sub btnValidasi_Click(sender As Object, e As EventArgs) Handles btnValidasi.Click
        If CtrlMeDataGrid1.GetRowCount_Gridview = 0 Then Exit Sub

        If Not txtJudul.Text.ToLower = "validasi event pameran" Then
            If Not CtrlMeDataGrid1.GetRowCellValue(CtrlMeDataGrid1.FocusedRowHandle, "UserValid").ToString = "" Then
                Pesan({"Sudah Divalidasi"})
                Exit Sub
            End If
        Else
            If Not CtrlMeDataGrid1.GetRowCellValue(CtrlMeDataGrid1.FocusedRowHandle, "UserValidate").ToString = "" Then
                Pesan({"Sudah Divalidasi"})
                Exit Sub
            End If
        End If

        'If IsDBNull(CtrlMeDataGrid1.DataSource.Rows(CtrlMeDataGrid1.FocusedRowHandle).Item("Checker")) = False Or IsDBNull(CtrlMeDataGrid1.DataSource.Rows(CtrlMeDataGrid1.FocusedRowHandle).Item("UserValid")) = False Or IsDBNull(CtrlMeDataGrid1.DataSource.Rows(CtrlMeDataGrid1.FocusedRowHandle).Item("DateTimeValid")) = False Then
        '    MsgBox("Faktur " & CtrlMeDataGrid1.DataSource.Rows(CtrlMeDataGrid1.FocusedRowHandle).Item("Faktur") & " Sudah DiValidasi")
        If txtJudul.Text.ToLower = "validasi event pameran" Then
            Dim ques As String = MsgBox("Validasi Event?" + vbCrLf + "Data Event Tidak Bisa Diubah", vbQuestion + vbYesNo, "Konfirmasi")
            If ques = vbYes Then
                Dim kode As String
                kode = CtrlMeDataGrid1.GetRowCellValue(CtrlMeDataGrid1.FocusedRowHandle, "kode")
                Using xx As New frmValidUser
                    xx.Tag = kode
                    xx.ShowDialog(Me)
                End Using
            End If
        Else
            Dim faktur As String
            faktur = CtrlMeDataGrid1.GetRowCellValue(CtrlMeDataGrid1.FocusedRowHandle, "Faktur")
            Using xx As New frmValidReturRB
                xx.Tag = faktur
                xx.judul = txtJudul.Text
                xx.ShowDialog(Me)
            End Using
        End If
        btnTampilData.PerformClick()
    End Sub

    Private Sub CtrlMeDataGrid1_Grid_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles CtrlMeDataGrid1.Grid_CustomDrawCell
        If Not txtJudul.Text.ToLower = "validasi event pameran" Then
            If Not CtrlMeDataGrid1.GetRowCellValue(e.RowHandle, "UserValid").ToString = "" Then
                e.Appearance.ForeColor = Color.Green
            End If
        Else
            If Not CtrlMeDataGrid1.GetRowCellValue(e.RowHandle, "UserValidate").ToString = "" Then
                e.Appearance.ForeColor = Color.Green
            End If
        End If
    End Sub

    Private Sub CtrlMeDataGrid1_Grid_DoubleClick(sender As Object, e As EventArgs) Handles CtrlMeDataGrid1.Grid_DoubleClick
        If CtrlMeDataGrid1.GetRowCount_Gridview = 0 Then Exit Sub
        If Not txtJudul.Text.ToLower = "validasi event pameran" _
            And Not txtJudul.Text.ToLower = "validasi terima ekspedisi" _
            And Not txtJudul.Text.ToLower = "validasi kirim ekspedisi" Then
            Dim faktur As String
            faktur = CtrlMeDataGrid1.GetRowCellValue(CtrlMeDataGrid1.FocusedRowHandle, "Faktur")
            Using xx As New frmValidReturBeliDetail
                xx.Tag = faktur
                xx.judul = txtJudul.Text
                xx.ShowDialog(Me)
            End Using
        End If
    End Sub

    Private Sub btnTampilDetail_Click(sender As Object, e As EventArgs) Handles btnTampilDetail.Click
        If CtrlMeDataGrid1.GetRowCount_Gridview > 0 Then
            If Not txtJudul.Text.ToLower = "validasi event pameran" _
                And Not txtJudul.Text.ToLower = "validasi terima ekspedisi" _
                And Not txtJudul.Text.ToLower = "validasi kirim ekspedisi" Then
                Dim faktur As String
                faktur = CtrlMeDataGrid1.GetRowCellValue(CtrlMeDataGrid1.FocusedRowHandle, "Faktur")
                Using xx As New frmValidReturBeliDetail
                    xx.Tag = faktur
                    xx.judul = txtJudul.Text
                    xx.ShowDialog(Me)
                End Using
            End If
        End If
    End Sub

    Private Sub cData_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cData.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub CtrlMeDataGrid1_Grid_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles CtrlMeDataGrid1.Grid_FocusedRowChanged
        btnValidasi.Enabled = False
        cmdCetakVal.Enabled = False
        If CtrlMeDataGrid1.GetRowCount_Gridview > 0 Then
            If Not txtJudul.Text.ToLower = "validasi event pameran" Then
                If CtrlMeDataGrid1.GetRowCellValue(CtrlMeDataGrid1.FocusedRowHandle, "UserValid").ToString = "" Then
                    btnValidasi.Enabled = True
                Else
                    cmdCetakVal.Enabled = True
                End If
            Else
                If CtrlMeDataGrid1.GetRowCellValue(CtrlMeDataGrid1.FocusedRowHandle, "UserValidate").ToString = "" Then
                    btnValidasi.Enabled = True
                    cmdCetakVal.Enabled = False
                Else
                    cmdCetakVal.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub CtrlMeDataGrid1_OnPopRefreshClickEnd() Handles CtrlMeDataGrid1.OnPopRefreshClickEnd
        CtrlMeDataGrid1_Grid_FocusedRowChanged(Nothing, Nothing)
    End Sub

    Private Sub CtrlMeDataGrid1_Load(sender As Object, e As EventArgs) Handles CtrlMeDataGrid1.Load

    End Sub

    Private Sub cmdCetakVal_Click(sender As Object, e As EventArgs) Handles cmdCetakVal.Click
        If CtrlMeDataGrid1.GetRowCount_Gridview > 0 Then
            If tablesupcus.Length > 0 Then
                Dim pFaktur As String = CtrlMeDataGrid1.GetRowCellValue(CtrlMeDataGrid1.FocusedRowHandle, "Faktur")
                Dim pQue As String = _
                        "SELECT top 1 '" & Replace(txtJudul.Text, "Validasi ", "", , , CompareMethod.Text).ToUpper & "' as trans, *, " & _
                        "			nama + ' (' + b.kode + ')' as namasupcus,  kota, noaccount, atasnama, bank, " & _
                        "			(select sum(Qty) from " & tableDetail & " where faktur = a.faktur) as TotQty " & _
                        "FROM " & tabel & " a  " & _
                        "left join " & tablesupcus & " b on a." & IIf(tablesupcus = "mstsupplier", "kdsupplier", "kdcustomer") & " = b.kode " & _
                        "left join trValidasi c on a.faktur = c.faktur " & _
                        "where a.faktur = '" & pFaktur & "'"

                If Tanya({"Langsung Cetak?"}) Then
                    ShowReport(pQue, "rptValidasi", , printTo.o2Print)
                Else
                    ShowReport(pQue, "rptValidasi", , printTo.o1ShowPreview)
                End If
            End If
        End If
    End Sub
End Class