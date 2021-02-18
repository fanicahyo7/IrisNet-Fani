Imports meCore
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.Repository.BaseRepositoryItemCheckEdit
Public Class frmPBYAdd
    Dim WithEvents _riEditor As New RepositoryItemCheckEdit
    Dim nonopengajuan As String = ""
    Dim topengajuan As Double = 0
    Dim kategori As String = ""

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(nopengajuan As String, pengajuan As Double, kategori As String)
        InitializeComponent()
        Me.nonopengajuan = nopengajuan
        Me.topengajuan = pengajuan
        Me.kategori = kategori
    End Sub

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
        dgTrans.Grid_ClearData()
    End Sub

    Private Sub frmPBYAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cTransferKe.SelectedIndex = 0
        cTransaksi.SelectedIndex = 0
        cKategori.SelectedIndex = 0

        SetTextReadOnly({tNoPengajuan, tNoBtt, sPengajuan})

        koneksi()

        If Not nonopengajuan = "" Then
            tNoPengajuan.Text = nonopengajuan
            sPengajuan.EditValue = topengajuan
            cTransaksi.Enabled = False
            cKategori.Enabled = False

            If kategori.ToUpper = "REGULER" Then
                cKategori.SelectedIndex = 0
            ElseIf kategori.ToUpper = "ISIDENTIL" Then
                cKategori.SelectedIndex = 1
            End If

            Dim query As String = "SELECT  DISTINCT CASE WHEN SUBSTRING(FakturLunas, 8, 2) = 'PH' THEN 'OPERASIONAL' Else 'SUPPLIER' END AS fakturlunas, case when c.Konsinyasi=0 Then 'PEMBELIAN' else 'PERHITUNGAN' end as JenisFaktur FROM    dbo.trPengajuanBayarDt a LEFT JOIN dbo.trPengajuanBayarHd b ON a.NoCTR = b.NoCTR inner join mstsupplier c on b.kdsupplier=c.kode WHERE   b.NoPengajuan = '" & nonopengajuan & "'"
            cmd = New SqlCommand(query, kon)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                If rd!fakturlunas.ToString.ToUpper = "SUPPLIER" Then
                    cTransferKe.SelectedIndex = 0
                Else
                    cTransferKe.SelectedIndex = 1
                End If


                If rd!JenisFaktur.ToString.ToUpper = "PEMBELIAN" Then
                    cTransaksi.SelectedIndex = 0
                Else
                    cTransaksi.SelectedIndex = 1
                End If
            End If
            rd.Close()
        End If

        Dim querysp As String = "exec spGenPengajuanStatus"
        cmd = New SqlCommand(querysp, kon)
        cmd.ExecuteNonQuery()
    End Sub

    Sub refreshdgtrans()
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

    Private Sub dgList_Grid_DoubleClick(sender As Object, e As EventArgs) Handles dgList.Grid_DoubleClick
        refreshdgtrans()
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

    Private Sub _riEditor_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles _riEditor.EditValueChanging
        If (sPengajuan.EditValue + dgTrans.GetRowCellValue(dgTrans.FocusedRowHandle, "Terjual")) < 0 Then
            e.Cancel = True
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
                    If IsDBNull(rd!BankCabang) Then
                        bankcabang = ""
                    Else
                        bankcabang = rd!BankCabang
                    End If
                    nama = rd!Nama
                End If
                rd.Close()
                Dim namabank As String = bank & " " & bankcabang

                Dim minggu As String = cariminggu(Now)

                Dim querysimpan As String = "begin try begin transaction "
                If tNoPengajuan.Text = "" Then
                    Dim pby As String = "" & pubKodeUnit & "PBY-" & Format(Now, "yyMM") & kodepby("'" & pubKodeUnit & "PBY-" & Format(Now, "yyMM") & "'")
                    Dim ctra As String = "" & pubKodeUnit & "CTR-" & Format(Now, "yyMM") & kodectr("'" & pubKodeUnit & "CTR-" & Format(Now, "yyMM") & "'")

                    Dim cekhd As String = "select Count(*) as Total from trPengajuanBayarHD where NoPengajuan = '" & pby & "' and NoCTR = '" & ctra & "'"
                    cmd = New SqlCommand(cekhd, kon)
                    rd = cmd.ExecuteReader
                    rd.Read()
                    Dim totalhd As Integer = rd!Total
                    rd.Close()
                    If totalhd > 0 Then
                        pby = "" & pubKodeUnit & "PBY-" & Format(Now, "yyMM") & kodepby("'" & pubKodeUnit & "PBY-" & Format(Now, "yyMM") & "'")
                        ctra = "" & pubKodeUnit & "CTR-" & Format(Now, "yyMM") & kodectr("'" & pubKodeUnit & "CTR-" & Format(Now, "yyMM") & "'")
                    End If
                    tNoPengajuan.Text = pby

                    querysimpan += _
                    "Insert Into trPengajuanBayarHD (" & _
                    "NoPengajuan,JnsPengajuan,KdUnit,TglPengajuan,TransferKe," & _
                    "KdSupplier,NamaSupplier,Kategori,NoCtr,Bank," & _
                    "kdBank,AtasNama,NoRek,MIngguKe) Values(" & _
                    "'" & pby & "','FAKTUR','" & pubKodeUnit & "','" & DTOC(Now, "-", True) & "','" & cTransferKe.Text.ToUpper & "'," & _
                    "'" & lNamaSupplier.Text & "','" & nama & "','" & cKategori.Text.ToUpper & "','" & ctra & "','" & namabank & "'," & _
                    "'" & bank & "','" & atasnama & "','" & noakun & "','" & minggu & "'); "


                    Dim cekdt As String = "select Count(*) as Total from trPengajuanBayarDt where Noctr = '" & ctra & "' and Faktur = '" & dgTrans.GetRowCellValue(dgTrans.FocusedRowHandle, "Faktur") & "'"
                    cmd = New SqlCommand(cekdt, kon)
                    rd = cmd.ExecuteReader
                    rd.Read()
                    Dim totaldt As String = rd!Total
                    rd.Close()
                    If totaldt > 0 Then
                        ctra = "" & pubKodeUnit & "CTR-" & Format(Now, "yyMM") & kodectr("'" & pubKodeUnit & "CTR-" & Format(Now, "yyMM") & "'")
                    End If

                    querysimpan += _
                        "Insert Into trPengajuanBayarDt (" & _
                        "NoCTR,Faktur,FakturAsli,TglFaktur,JthTmp," & _
                        "KdSupplier,NamaSupplier,Total,ReturFisik,ReturAdmin," & _
                        "Terjual,JenisFaktur,FakturReinv)  Values(" & _
                        "'" & ctra & "','" & dgTrans.GetRowCellValue(dgTrans.FocusedRowHandle, "Faktur") & "','" & dgTrans.GetRowCellValue(dgTrans.FocusedRowHandle, "FakturAsli") & "','" & DTOC(Now, "-") & "','" & DTOC(Now, "-") & "'," & _
                        "'" & lNamaSupplier.Text & "','" & nama & "','" & dgTrans.GetRowCellValue(dgTrans.FocusedRowHandle, "Terjual") & "','0','0'," & _
                        "'" & dgTrans.GetRowCellValue(dgTrans.FocusedRowHandle, "Terjual") & "','" & cTransaksi.Text.ToUpper & "',''); "

                Else
                    Dim querycarictr As String = "Select top 1 NoCtr as hasil from trPengajuanBayarHd where NoPengajuan = '" & tNoPengajuan.Text & "' and KdSupplier  = '" & lNamaSupplier.Text & "'"
                    cmd = New SqlCommand(querycarictr, kon)
                    rd = cmd.ExecuteReader
                    Dim hasilctr As String = ""
                    rd.Read()
                    If rd.HasRows Then
                        hasilctr = rd!hasil
                    End If
                    rd.Close()

                    Dim noctr As String = ""
                    If hasilctr = "" Then
                        noctr = "" & pubKodeUnit & "CTR-" & Format(Now, "yyMM") & kodectr("'" & pubKodeUnit & "CTR-" & Format(Now, "yyMM") & "'")
                    Else
                        noctr = hasilctr
                    End If

                    Dim caritanggal As String = "select TglPengajuan as Tanggal from trPengajuanBayarHd where NoPengajuan='" & tNoPengajuan.Text & "'"
                    Dim tanggal As Date
                    cmd = New SqlCommand(caritanggal, kon)
                    rd = cmd.ExecuteReader
                    rd.Read()
                    If rd.HasRows Then
                        tanggal = rd!Tanggal
                    End If
                    rd.Close()

                    If hasilctr = "" Then
                        querysimpan += _
                        "Insert Into trPengajuanBayarHD (" & _
                        "NoPengajuan,JnsPengajuan,KdUnit,TglPengajuan,TransferKe," & _
                        "KdSupplier,NamaSupplier,Kategori,NoCtr,Bank," & _
                        "kdBank,AtasNama,NoRek,MIngguKe) Values(" & _
                        "'" & tNoPengajuan.Text & "','FAKTUR','" & pubKodeUnit & "','" & DTOC(tanggal, "-", True) & "','" & cTransferKe.Text.ToUpper & "'," & _
                        "'" & lNamaSupplier.Text & "','" & nama & "','" & cKategori.Text.ToUpper & "','" & noctr & "','" & namabank & "'," & _
                        "'" & bank & "','" & atasnama & "','" & noakun & "','" & minggu & "'); "

                        querysimpan += _
                        "Insert Into trPengajuanBayarDt (" & _
                        "NoCTR,Faktur,FakturAsli,TglFaktur,JthTmp," & _
                        "KdSupplier,NamaSupplier,Total,ReturFisik,ReturAdmin," & _
                        "Terjual,JenisFaktur,FakturReinv)  Values(" & _
                        "'" & noctr & "','" & dgTrans.GetRowCellValue(dgTrans.FocusedRowHandle, "Faktur") & "','" & dgTrans.GetRowCellValue(dgTrans.FocusedRowHandle, "FakturAsli") & "','" & DTOC(tanggal, "-") & "','" & DTOC(tanggal, "-") & "'," & _
                        "'" & lNamaSupplier.Text & "','" & nama & "','" & dgTrans.GetRowCellValue(dgTrans.FocusedRowHandle, "Terjual") & "','0','0'," & _
                        "'" & dgTrans.GetRowCellValue(dgTrans.FocusedRowHandle, "Terjual") & "','" & cTransaksi.Text.ToUpper & "',''); "

                    Else
                        
                        'update
                        querysimpan += _
                            "Update trPengajuanBayarHD Set NoPengajuan = '" & tNoPengajuan.Text & "', JnsPengajuan = 'FAKTUR'," & _
                            "KdUnit = '" & pubKodeUnit & "', TglPengajuan = '" & DTOC(tanggal, "-", True) & "', TransferKe = '" & cTransferKe.Text.ToUpper & "'," & _
                            "KdSupplier = '" & lNamaSupplier.Text & "', NamaSupplier = '" & nama & "'," & _
                            "Kategori = 'REGULER', NoCtr = '" & noctr & "', Bank = '" & namabank & "'," & _
                            "kdBank = '" & bank & "', AtasNama = '" & atasnama & "', NoRek = '" & noakun & "', MIngguKe = '" & minggu & "' " & _
                            "Where NoPengajuan = '" & tNoPengajuan.Text & "' and NoCTR = '" & noctr & "'; "

                        'tambah ctr yg sama
                        querysimpan += _
                       "Insert Into trPengajuanBayarDt (" & _
                       "NoCTR,Faktur,FakturAsli,TglFaktur,JthTmp," & _
                       "KdSupplier,NamaSupplier,Total,ReturFisik,ReturAdmin," & _
                       "Terjual,JenisFaktur,FakturReinv)  Values(" & _
                       "'" & noctr & "','" & dgTrans.GetRowCellValue(dgTrans.FocusedRowHandle, "Faktur") & "','" & dgTrans.GetRowCellValue(dgTrans.FocusedRowHandle, "FakturAsli") & "','" & DTOC(tanggal, "-") & "','" & DTOC(tanggal, "-") & "'," & _
                       "'" & lNamaSupplier.Text & "','" & nama & "','" & dgTrans.GetRowCellValue(dgTrans.FocusedRowHandle, "Terjual") & "','0','0'," & _
                       "'" & dgTrans.GetRowCellValue(dgTrans.FocusedRowHandle, "Terjual") & "','" & cTransaksi.Text.ToUpper & "',''); "
                    End If
                End If

                querysimpan += "commit select 'sukses' as statusx end try begin catch rollback select 'gagal : ' + ERROR_MESSAGE() as statusx end catch"

                Dim db As New DataTable
                da = New SqlDataAdapter(querysimpan, kon)
                da.Fill(db)

                If db.Rows.Count > 0 Then
                    If (db.Rows(0)!statusx).ToString.Contains("gagal") Then
                        MsgBox("Penyimpanan Gagal" & vbCrLf & db.Rows(0)!statusx, vbCritical + vbOKOnly, "Peringatan")
                        e.NewValue = e.OldValue
                    Else
                        Dim carjumlah As String = "Select top 1 sum(Pengajuan) as hasil from trPengajuanBayarHD where NoPengajuan = '" & tNoPengajuan.Text & "'"
                        cmd = New SqlCommand(carjumlah, kon)
                        rd = cmd.ExecuteReader
                        rd.Read()
                        If rd.HasRows Then
                            sPengajuan.EditValue = rd!hasil
                        End If
                        rd.Close()
                        MsgBox("Penyimpanan Berhasil", vbInformation + vbOKOnly, "Informasi")
                        dgTrans.SetRowCellValue(dgTrans.FocusedRowHandle, "Status", "PENGAJUAN UNIT")
                        dgTrans.SetRowCellValue(dgTrans.FocusedRowHandle, "Kategori", cKategori.Text.ToUpper)
                        cTransaksi.Enabled = False
                        cKategori.Enabled = False
                    End If
                End If
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
        Loop While hari < totalhari
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

    Private Sub cTransferKe_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cTransferKe.SelectedIndexChanged
        dgTrans.Grid_ClearData()
    End Sub

    Private Sub dgTrans_Load(sender As Object, e As EventArgs) Handles dgTrans.Load

    End Sub
End Class