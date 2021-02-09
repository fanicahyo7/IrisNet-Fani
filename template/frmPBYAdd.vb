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

        koneksi()
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
        Else
            Dim ques = MsgBox("Yakin akan menambah?", vbQuestion + vbYesNo, "Konfirmasi")
            If ques = vbYes Then

                Dim noakun As String = ""
                Dim atasnama As String = ""
                Dim bank As String = ""
                Dim bankcabang As String = ""
                Dim nama As String = ""
                Dim caribank As String = "select NoAccount,AtasNama,Bank,BankCabang,Nama from mstSupplier where Kode='" & lNamaSupplier.Text & "'"
                cmd = New SqlCommand(caribank, kon)
                rd = cmd.ExecuteReader
                rd.Read()
                If rd.HasRows Then
                    noakun = rd!NoAccount
                    atasnama = rd!AtasNama
                    bank = rd!Bank
                    bankcabang = rd!BankCabang
                    nama = rd!Nama
                End If
                rd.Close()
                Dim namabank As String = bank & " " & bankcabang

                Dim minggu As String = cariminggu(Now)

                Dim querysimpanHD As String = ""
                Dim querysimpanDT As String = ""
                If tNoPengajuan.Text = "" Then
                    Dim angka As String = kodepby("'" & pubKodeUnit & "PBY-" & Format(Now, "yyMM") & "'")
                    Dim pby As String = "" & pubKodeUnit & "PBY-" & Format(Now, "yyMM") & "" & angka
                    Dim ctra As String = "" & pubKodeUnit & "CTR-" & Format(Now, "yyMM") & kodectr("'" & pubKodeUnit & "CTR-" & Format(Now, "yyMM") & "'")


                    If cTransaksi.SelectedIndex = 0 Then
                        querysimpanHD = _
                        "Insert Into trPengajuanBayarHD (" & _
                        "NoPengajuan,JnsPengajuan,KdUnit,TglPengajuan,TransferKe," & _
                        "KdSupplier,NamaSupplier,Kategori,NoCtr,Bank," & _
                        "kdBank,AtasNama,NoRek,MIngguKe) Values(" & _
                        "'" & pby & "','FAKTUR','" & pubKodeUnit & "','" & DTOC(Now, "-", True) & "','" & cTransferKe.Text.ToUpper & "'," & _
                        "'" & lNamaSupplier.Text & "','" & nama & "','" & cKategori.Text.ToUpper & "','" & ctra & "','" & namabank & "'," & _
                        "'" & bank & "','" & atasnama & "','" & noakun & "','" & minggu & "')"
                    ElseIf cTransaksi.SelectedIndex = 1 Then

                    End If
                Else
                    Dim querycarictr As String = "Select top 1 NoCtr as hasil from trPengajuanBayarHd where NoPengajuan = '" & tNoPengajuan.Text & "' and KdSupplier  = '" & lNamaSupplier.Text & "'"


                    If cTransaksi.SelectedIndex = 0 Then

                    ElseIf cTransaksi.SelectedIndex = 1 Then

                    End If
                End If

                'simpan
                Dim query As String = "Select top 1 NoCtr as hasil from trPengajuanBayarHd where NoPengajuan = '" & tNoPengajuan.Text & "' and KdSupplier  = '" & lNamaSupplier.Text & "'"
                cmd = New SqlCommand(query, kon)
                rd = cmd.ExecuteReader
                rd.Read()
                Dim ctr As String = ""
                Dim carictrbaru As Boolean = False
                If rd.HasRows Then
                    If rd!hasil = "" Then
                        carictrbaru = True
                    Else
                        carictrbaru = False
                    End If
                End If
                rd.Close()


                ''cari kode
                Dim baru As Boolean = False
                'Dim query2 As String = "select pengajuan from trPengajuanBayarHD where nopengajuan='" & tNoPengajuan.Text & "' and noCtr='" & ctr & "'"
                'cmd = New SqlCommand(query2, kon)
                'rd = cmd.ExecuteReader
                'rd.Read()
                'If rd.HasRows Then
                '    baru = False
                'Else
                '    baru = True
                'End If
                'rd.Close()

                Dim kodepengajuan As String = ""
                If baru = True Then
                    Dim query3 As String = _
                        "select max(SUBSTRING( NoPengajuan,12,2)) as max from trPengajuanBayarHd where left(nopengajuan,11) = '" & pubKodeUnit & "PBY-" & Format(Now, "yyMM") & "'"
                    cmd = New SqlCommand(query3, kon)
                    rd = cmd.ExecuteReader
                    rd.Read()
                    If rd.HasRows Then
                        If Len(rd!max) = 1 Then
                            If rd!max = "09" Then
                                kodepengajuan = rd!max + 1
                            Else
                                kodepengajuan = "0" & rd!max + 1
                            End If
                        ElseIf Len(rd!max) = 2 Then
                            kodepengajuan = rd!max + 1
                        End If
                    Else
                        kodepengajuan = "01"
                    End If
                    rd.Close()

                    'Select top 1 sum(Pengajuan) as hasil from trPengajuanBayarHD where NoPengajuan = '601PBY-210204' 

                    Dim queryctr As String = _
                        "Select top 1 NoCtr as hasil from trPengajuanBayarHd where NoPengajuan = '" & kodepengajuan & "' and KdSupplier  = '" & lNamaSupplier.Text & "'"
                    cmd = New SqlCommand(queryctr, kon)
                    rd = cmd.ExecuteReader
                    rd.Read()
                    If rd.HasRows Then
                        ctr = rd!hasil
                    End If
                    rd.Close()

                    If ctr = "" Then
                        Dim cari As String = _
                            "select max(SUBSTRING(NoCTR,12,3)) as max from trPengajuanBayarHd where left(noctr,11) = '" & pubKodeUnit & "PBY-" & Format(Now, "yyMM") & "'"
                        cmd = New SqlCommand(cari, kon)
                        rd = cmd.ExecuteReader
                        rd.Read()
                        If rd.HasRows Then
                            If Len(rd!max) = 1 Then
                                If rd!max = "09" Then
                                    ctr = "0" & rd!max + 1
                                Else
                                    ctr = "00" & rd!max + 1
                                End If
                            ElseIf Len(rd!max) = 2 Then
                                If rd!max = "099" Then
                                    ctr = rd!max + 1
                                Else
                                    ctr = "0" & rd!max + 1
                                End If
                            Else
                                ctr = rd!max + 1
                            End If
                        Else
                            ctr = "001"
                        End If
                        rd.Close()
                    End If
                    ctr = pubKodeUnit & "PBY-" & Format(Now, "yyMM") & ctr

                ElseIf baru = False Then
                    kodepengajuan = tNoPengajuan.Text

                    'Select top 1 TglPengajuan as hasil from trPengajuanBayarHD where NoPengajuan = '601PBY-210204' 

                    'Select top 1 NoCtr as hasil from trPengajuanBayarHd where NoPengajuan = '601PBY-210204' and KdSupplier  = '0DPH_'

                End If


                'select Count(*) as Total from trPengajuanBayarHD where NoPengajuan = '601PBY-210204' and NoCTR = '601CTR-2102005'

                Dim querHd As String = ""
                If baru = True Then
                    querHd = _
                        "Insert Into trPengajuanBayarHD (" & _
                        "NoPengajuan,JnsPengajuan,KdUnit,TglPengajuan,TransferKe," & _
                        "KdSupplier,NamaSupplier,Kategori,NoCtr,Bank," & _
                        "kdBank,AtasNama,NoRek,MIngguKe) Values(" & _
                        "'" & kodepengajuan & "','FAKTUR','" & pubKodeUnit & "','2021-02-03 08:54:28','SUPPLIER'," & _
                        "'" & lNamaSupplier.Text & "','" & nama & "','REGULER','601CTR-2102005','BCA KAWI MALANG'," & _
                        "'" & bank & "','" & atasnama & "','" & noakun & "','1')"
                ElseIf baru = False Then
                    querHd = "Update trPengajuanBayarHD Set " & _
                        "NoPengajuan = '" & kodepengajuan & "', JnsPengajuan = 'FAKTUR', KdUnit = '" & pubKodeUnit & "', " & _
                        "TglPengajuan = '2021-02-03 08:54:28', TransferKe = 'SUPPLIER', KdSupplier = '" & kodepengajuan & "', " & _
                        "NamaSupplier = '" & nama & "', Kategori = 'REGULER', NoCtr = '601CTR-2102005'," & _
                        "Bank = 'BCA KAWI MALANG', kdBank = '" & bank & "', AtasNama = '" & atasnama & "', " & _
                        "NoRek = '" & noakun & "', MIngguKe = '1' " & _
                        "Where NoPengajuan = '601PBY-210204' and NoCTR = '601CTR-2102005'"
                End If

                'select Count(*) as Total from trPengajuanBayarDt where Noctr = '601CTR-2102005' and Faktur = '601NIT-FB19080800241'

                'Insert Into trPengajuanBayarDt (NoCTR,Faktur,FakturAsli,TglFaktur,JthTmp,KdSupplier,NamaSupplier,Total,ReturFisik,ReturAdmin,Terjual,JenisFaktur,FakturReinv)  Values('601CTR-2102005','601NIT-FB19080800241','007TON-FJ19080600009 RO/DTP','2019-08-08 00:00:00','2019-09-05 00:00:00','0DPH_','DHARMASAVA PUTERA HARAPAN, PT (BARU)','2431140','0','0','2431140','PEMBELIAN','')

                'Select top 1 sum(Pengajuan) as hasil from trPengajuanBayarHD where NoPengajuan = '601PBY-210204' 

                'Select top 1 Kategori as hasil from trPengajuanBayarHD where NoPengajuan = '601PBY-210204' 

                'Select top 1 JENISFAKTUR as hasil from trPengajuanBayarDT where NoCTR = '601CTR-2102005'
            Else
                e.NewValue = e.OldValue
            End If
        End If
    End Sub

    Function cariminggu(ByVal tanggalnya As Date) As String
        Dim tanggal As Date = New Date(CInt(Format(tanggalnya, "yyyy")), CInt(Format(tanggalnya, "MM")), 1)
        Dim tanggal2 As Date = Format(tanggalnya, "yyyy/MM/dd")
        Dim totalhari As String = DateDiff(DateInterval.Day, tanggal, tanggal2) + 1
        Dim hari As Integer = 1
        Dim minggu As Integer = 1
        Do
            Dim hhari As String = DatePart(DateInterval.Weekday, tanggal).ToString
            tanggal = DateAdd(DateInterval.Day, 1, tanggal)
            If hhari = 7 Then
                minggu += 1
            End If
            hari += 1
        Loop While hari <= totalhari
        Return minggu
    End Function

    Function kodepby(ByVal kode As String) As String
        Dim carikode As String = _
            "select max(SUBSTRING( NoPengajuan,12,2)) as max from trPengajuanBayarHd where left(nopengajuan,11) = " & kode & ""
        cmd = New SqlCommand(carikode, kon)
        rd = cmd.ExecuteReader
        Dim angka As String = ""
        rd.Read()
        If rd.HasRows Then
            If IsDBNull(rd!max) Then
                angka = ""
            Else
                angka = rd!max
            End If

            If angka = "" Then
                angka = "01"
            Else
                angka = CInt(angka) + 1
                If Len(angka) = 1 Then
                    angka = "0" & angka
                End If
            End If
        End If
        rd.Close()
        Return angka
    End Function

    Function kodectr(ByVal kode As String) As String
        Dim carictr As String = _
        "select max(SUBSTRING( NoCtr,12,3)) as max from trPengajuanBayarHd where left(noctr,11) = " & kode & ""
        cmd = New SqlCommand(carictr, kon)
        rd = cmd.ExecuteReader
        Dim angkactr As String = ""
        rd.Read()
        If rd.HasRows Then
            If IsDBNull(rd!max) Then
                angkactr = ""
            Else
                angkactr = rd!max
            End If

            If angkactr = "" Then
                angkactr = "001"
            Else
                angkactr = CInt(angkactr) + 1
                If Len(angkactr) = 1 Then
                    angkactr = "00" & angkactr
                ElseIf Len(angkactr) = 2 Then
                    angkactr = "0" & angkactr
                End If
            End If
        End If
        rd.Close()
        Return angkactr
    End Function
End Class