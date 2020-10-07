Imports meCore
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class frmtrKirimEkspedisi
    Dim isNew As Boolean = True
    Dim db As New cMeDB
    Dim pKode As String = "asdjaksdjqi01298310owueqiowueakdh"
    Public tujuankirimekspedisi As String
    Public jenis As String
    Public date1 As DateTime
    Public date2 As DateTime
    Public nopengajuan As String
   
    Private Sub frmtrKirimEkspedisi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'initForm(Me, EnfrmSizeNotMax.efsnm3Big, DevExpress.XtraLayout.MoveFocusDirection.AcrossThenDown)
        'koneksi()

        If Me.jenis = 2 Then
            LayoutControlItem13.Text = "Amplop"

            tJenisBarang.Properties.Items.Add("DOKUMEN")
            tJenisBarang.Text = "DOKUMEN"
            cCaraKirim.Properties.Items.AddRange({"MELALUI EKSPEDISI", "DIANTAR SENDIRI", "DIAMBIL AM/SM"})
        Else
            LayoutControlItem13.Text = "Ikat"

            tJenisBarang.Properties.Items.AddRange({"BUKU", "ATK", "BUKU & ATK"})
            tJenisBarang.Text = "BUKU"

            If Me.jenis = 0 Then
                cCaraKirim.Properties.Items.AddRange({"MELALUI EKSPEDISI", "DIANTAR SENDIRI", "DIAMBIL SUPPLIER"})
            ElseIf Me.jenis = 1 Then
                cCaraKirim.Properties.Items.AddRange({"MELALUI EKSPEDISI", "DIANTAR SENDIRI", "DIAMBIL CUSTOMER"})
            End If
        End If

        cKodeEkspedisi.Enabled = False
        dTglNotaEkspedisi.Enabled = False
        tNoNotaEkspedisi.Enabled = False
        tPIC.Properties.CharacterCasing = CharacterCasing.Upper
        tNoNotaEkspedisi.Properties.CharacterCasing = CharacterCasing.Upper
        tNoResi.Properties.CharacterCasing = CharacterCasing.Upper
        tNoTracking.Properties.CharacterCasing = CharacterCasing.Upper
        SetTextReadOnly({tDikirimDari})

        If Me.Tag <> "" Then pKode = Me.Tag

        cKodeEkspedisi.FirstInit(PubConnStr, "Select Kode,Nama,Alamat,Kota from mstEkspedisi", {tNamaEkspedisi}, , , , , False, {0.5, 1.5, 2, 1})

        loadDetail()
    End Sub
    Sub loadDetail()
        Dim pQuery As String = _
            "Select Faktur, TglKirim, CaraKirim, KodeEkspedisi, NoNotaEkspedisi, TglNotaEkspedisi, PIC,TglResi, NoResi, NoTracking, DikirimDari, JenisBarang, JumlahBarang, BeratBarang, TotalBiaya,Tujuan, UserEntry, DateTimeEntry,Jenis from trKirimEkspedisi where Faktur = '" & pKode & "'"
        db.FillMe(pQuery, True)

        If db.Rows.Count > 0 Then
            isNew = False
            FillFormFromDataRow(Me, db.Rows(0))
            SetTextReadOnly({tFaktur, dTglKirim, tPIC, cCaraKirim, cKodeEkspedisi, tNamaEkspedisi, tDikirimDari, tJenisBarang, tBeratBarang, tJumlahBarangIkat, tJumlahBarangKoli, tNoNotaEkspedisi, dTglNotaEkspedisi})
            tJumlahBarangIkat.Text = Strings.Split(db.Rows(0)!JumlahBarang, " ")(2)
            tJumlahBarangKoli.Text = Strings.Split(db.Rows(0)!JumlahBarang, " ")(0)
            dgListFaktur.Grid_ClearData()
            isigridupdate()
        Else
            ClearValue(Me, {"tJenisBarang"})
            SetTextReadOnly({tFaktur}, True)
            isNew = True
            fakturotomatis()
            isigridcentang()
        End If
    End Sub

    Sub isigridcentang()
        Dim anu As New cMeDB
        If jenis = "2" Then
            Dim anu1 As String = "select NoPengajuan,TglPengajuan,0 as JumlahPengajuan from trPengajuanBayarHd " & _
                    "where NoPengajuan='" & pKode & "'"
            anu.FillMe(anu1, False)
            For a = 0 To pRow.Length - 1
                anu.Rows.Add(pRow(a).Item("NoPengajuan"), pRow(a).Item("TglPengajuan"), pRow(a).Item("JumlahPengajuan"))
            Next
            dgListFaktur.DataSource = anu
            dgListFaktur.colWidth = {1, 1, 1.3}
        Else
            Dim anu1 = String.Format("select FakturPCRKonsPby,FakturReferensi,Tujuan,Keterangan,Total from trKirimEkspedisiDetail where Faktur='" & pKode & "'")
            anu.FillMe(anu1, False)
            For a = 0 To pRow.Length - 1
                anu.Rows.Add(pRow(a).Item("Faktur"), pRow(a).Item("FakturRef"), tujuankirimekspedisi, pRow(a).Item("Keterangan"), pRow(a).Item("Total"))
            Next
            dgListFaktur.DataSource = anu
            dgListFaktur.colWidth = {1.4, 1.4, 0.6, 1.7, 1}
        End If
        dgListFaktur.RefreshDataView()
    End Sub

    Sub isigridupdate()
        Dim anu As New cMeDB
        If jenis = "2" Then
            '    Dim hsl As String = ""
            '    If Strings.Right(nopengajuan, 1) = "," Then
            '        For a = 0 To Strings.Split(nopengajuan, ",").Length - 2
            '            If a = Strings.Split(nopengajuan, ",").Length - 2 Then
            '                hsl += "'" & Strings.Split(nopengajuan, ",")(a) & "'"
            '            Else
            '                hsl += "'" & Strings.Split(nopengajuan, ",")(a) & "',"
            '            End If
            '        Next
            '    Else
            '        hsl = "'" & nopengajuan & "'"
            '    End If

            'Dim anu1 As String = "select NoPengajuan,TglPengajuan,TransferKe,KdSupplier,NamaSupplier,Kategori,NoCtr,NoBTT,Bank,NoRek,AtasNama,Pengajuan from trPengajuanBayarHd " & _
            '                   "where NoPengajuan in (" & hsl & ")"
            'Dim anu1 As String = _
            '    "with cteSum as(" & _
            '    "select cast(0 as bit) as Ambil, NoPengajuan,TglPengajuan,sum(Pengajuan) as JumlahPengajuan " & _
            '    "from trPengajuanBayarHd group by NoPengajuan,TglPengajuan) " & _
            '    "select a.*,isnull(b.NoPengajuan,'') as FakturEkspedisi from cteSum a " & _
            '    "left join trPengajuanBayarKR b on a.NoPengajuan = b.NoPengajuan " & _
            '    "where a.NoPengajuan in (" & hsl & ")"

            Dim anu1 As String = _
                "SELECT a.FakturPCRKonsPby as NoPengajuan,max(b.TglPengajuan) as TglPengajuan, a.Total as JumlahPengajuan " & _
                "FROM trKirimEkspedisiDetail a " & _
                "left join trPengajuanBayarHd b on a.FakturPCRKonsPby = b.NoPengajuan " & _
                "group by faktur,b.TglPengajuan,FakturPCRKonsPby,Total " & _
                "having a.Faktur='" & pKode & "'"

            anu.FillMe(anu1, False)
            dgListFaktur.DataSource = anu
            dgListFaktur.colWidth = {1, 1, 1.5}
        Else
            Dim anu1 = String.Format("select FakturPCRKonsPby,FakturReferensi,Tujuan,Keterangan,Total from trKirimEkspedisiDetail where Faktur='" & pKode & "'")
            anu.FillMe(anu1, False)
            dgListFaktur.DataSource = anu
            dgListFaktur.colWidth = {1.4, 1.4, 0.6, 1.7, 1}
        End If
        dgListFaktur.RefreshDataView()
    End Sub

    Sub fakturotomatis()
        tFaktur.Text = GetNewFakturSQLServ(PubConnStr, "trKirimEkspedisi", "Faktur", pubKodeUnit & pubUserInit & "-KE", Date.Now.ToString("yyMMdd"), 5, "")

        'Dim cari As String
        'cmd = New SqlCommand("select * from trKirimEkspedisi order by Faktur DESC", kon)
        'rd = cmd.ExecuteReader
        'rd.Read()
        'If Not rd.HasRows Then
        '    tFaktur.Text = kodekota & inisial & "-KE" & Date.Now.ToString("yyMMdd") & "00001"
        'Else
        '    If Microsoft.VisualBasic.Left(rd.Item("Faktur").ToString, 15) <> kodekota & inisial & "-KE" & Date.Now.ToString("yyMMdd") Then
        '        tFaktur.Text = kodekota & inisial & "-KE" & Date.Now.ToString("yyMMdd") & "00001"
        '    Else
        '        cari = Val(Microsoft.VisualBasic.Mid(rd.Item("Faktur").ToString, 16, 5)) + 1
        '        tFaktur.Text = kodekota & inisial & "-KE" & Date.Now.ToString("yyMMdd") + cari.PadLeft(5, "0")
        '        'If Len(cari) = 1 Then
        '        '    tFaktur.Text = kodekota & inisial & "-KE" & Date.Now.ToString("yyMMdd") + "0000" + cari
        '        'ElseIf Len(cari) = 2 Then
        '        '    tFaktur.Text = kodekota & inisial & "-KE" & Date.Now.ToString("yyMMdd") + "000" + cari
        '        'ElseIf Len(cari) = 3 Then
        '        '    tFaktur.Text = kodekota & inisial & "-KE" & Date.Now.ToString("yyMMdd") + "00" + cari
        '        'ElseIf Len(cari) = 4 Then
        '        '    tFaktur.Text = kodekota & inisial & "-KE" & Date.Now.ToString("yyMMdd") + "0" + cari
        '        'ElseIf Len(cari) = 5 Then
        '        '    tFaktur.Text = kodekota & inisial & "-KE" & Date.Now.ToString("yyMMdd") + cari
        '        'End If
        '    End If
        'End If
        'rd.Close()
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        If CheckBeforeSave({tFaktur, dTglKirim, cCaraKirim, tPIC, tJenisBarang}) = True Then
            Try
                Dim drow As DataRow
                If isNew = True Then
                    drow = db.NewRow
                Else
                    drow = db.Rows(0)
                End If

                drow!Faktur = tFaktur.Text
                drow!TglKirim = Format(dTglKirim.EditValue, "yyyy/MM/dd")
                drow!CaraKirim = cCaraKirim.Text
                drow!PIC = tPIC.Text
                If cCaraKirim.Text = "MELALUI EKSPEDISI" Then
                    drow!KodeEkspedisi = cKodeEkspedisi.Text
                    drow!NoNotaEkspedisi = tNoNotaEkspedisi.Text
                    drow!TglNotaEkspedisi = Format(CDate(dTglNotaEkspedisi.EditValue), "yyyy/MM/dd")
                End If
                drow!TglResi = Format(dTglResi.EditValue, "yyyy/MM/dd")
                drow!NoResi = tNoResi.Text
                drow!NoTracking = tNoTracking.Text
                drow!DikirimDari = tDikirimDari.Text
                drow!JenisBarang = tJenisBarang.Text
                drow!JumlahBarang = tJumlahBarangKoli.Text & " KOLI " & tJumlahBarangIkat.Text & " " & LayoutControlItem13.Text.ToUpper
                drow!BeratBarang = tBeratBarang.Value
                drow!TotalBiaya = tTotalBiaya.Value
                drow!Tujuan = tujuankirimekspedisi
                drow!UserEntry = pubUserEntry
                drow!DateTimeEntry = Now
                Dim data() As DataRow = dgListFaktur.DataSource.Select("")
                Dim jeniske As String = ""
                If Me.jenis = "0" Then
                    jeniske = "SUPPLIER"
                ElseIf Me.jenis = "1" Then
                    jeniske = "CUSTOMER"
                ElseIf Me.jenis = "2" Then
                    jeniske = "PENGAJUAN BAYAR SUPPLIER"
                End If
                drow!Jenis = jeniske

                If isNew Then db.Rows.Add(drow)
                db.UpdateMeToRealDBNoTry()

                If isNew = True Then
                    If jenis = "2" Then
                        For i = 0 To data.Length - 1
                            Dim pQue As String = _
                            "insert into trKirimEkspedisiDetail (Faktur,FakturPCRKonsPby,FakturReferensi,Tujuan,Keterangan,Total) values ('" & tFaktur.Text & "','" & data(i).Item("NoPengajuan") & "','','','','" & data(i).Item("JumlahPengajuan") & "')"
                            db.ExecScalar(pQue)
                        Next
                    Else
                        For i = 0 To data.Length - 1
                            Dim pQue As String = _
                            "insert into trKirimEkspedisiDetail (Faktur,FakturPCRKonsPby,FakturReferensi,Tujuan,Keterangan,Total) values ('" & tFaktur.Text & "','" & data(i).Item("FakturPCRKonsPby") & "','" & data(i).Item("FakturReferensi") & "','" & data(i).Item("Tujuan") & "','" & data(i).Item("Keterangan") & "','" & data(i).Item("Total") & "')"
                            db.ExecScalar(pQue)
                        Next
                    End If
                End If

                If jenis = "2" Then
                    Dim droww() As DataRow = dgListFaktur.DataSource.select("")
                    For Each dro As DataRow In droww
                        If isNew = True Then
                            Dim pQue As String = _
                                "insert into trPengajuanBayarKR (NoPengajuan,TglResi,NoResi) values ('" & dro!NoPengajuan & "','" & Format(dro!TglPengajuan, "yyyy/MM/dd") & "','" & tNoResi.Text & "')"
                            db.ExecScalar(pQue)
                        Else
                            Dim pQue As String = _
                                "update trPengajuanBayarKR set NoResi='" & tNoResi.Text & "' where NoPengajuan='" & dro!NoPengajuan & "'"
                            db.ExecScalar(pQue)
                        End If
                    Next
                End If

                Pesan({IIf(isNew = True, "Simpan", "Update") & " Data BERHASIL"})
                Dim jj As String = ""
                If jenis = "0" Then
                    jj = "mstSupplier"
                ElseIf jenis = "1" Then
                    jj = "mstCustomer"
                End If

                If (Not cKodeEkspedisi.Text = "" And tNoResi.Text = "") Or (cKodeEkspedisi.Text = "" And tNoResi.Text = "") And isNew = True Then
                    Dim question As String
                    question = MsgBox("Cetak Surat Jalan ?", vbYesNo, "Konfirmasi")
                    If question = vbYes Then
                        If Not jenis = "2" Then
                            Dim pQueRpt As String = _
                                "select b.*, a.Faktur,a.Faktur,a.FakturReferensi,a.Tujuan,(select Nama from " & jj & " where Kode=a.Tujuan) as NamaTujuan,(select Alamat from " & jj & " where Kode=a.Tujuan) as AlamatTujuan,a.Total," & _
                                "(select Nama from mstEkspedisi where Kode = b.KodeEkspedisi) as NamaEkspedisi from trKirimEkspedisiDetail a " & _
                                "inner join trKirimEkspedisi b on a.Faktur = b.Faktur " & _
                                "where b.faktur = '" & tFaktur.Text & "'"
                            ShowReport(pQueRpt, "rptSuratJalanEkspedisi", {compNama, compAlamat, compNoTlp, compNPWP})
                        Else
                            Dim pQueryRpt As String = _
                                "SELECT a.FakturPCRKonsPby as NoPengajuan, a.Total as JumlahPengajuan,c.*,(select top 1 TglPengajuan from trPengajuanBayarHd where NoPengajuan= a.FakturPCRKonsPby) as TglPengajuan," & _
                                "(select Nama from mstEkspedisi where Kode = c.KodeEkspedisi) as NamaEkspedisi " & _
                                "FROM trKirimEkspedisiDetail a " & _
                                "left join trKirimEkspedisi c on a.Faktur = c.Faktur " & _
                                "where a.Faktur='" & tFaktur.Text & "'"
                            ShowReport(pQueryRpt, "rptSuratJalanEkspedisiPengajuanBayar", {compNama, compAlamat, compNoTlp, compNPWP})
                        End If
                    End If
                End If
                Me.Close()
            Catch ex As Exception
                Pesan({"GAGAL SIMPAN DATA", "", "Err : " & ex.Message.ToString})
            End Try
        End If
    End Sub

    Private Sub btnbersih_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Close()
    End Sub

    Private Sub cCaraKirim_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cCaraKirim.SelectedIndexChanged
        If cCaraKirim.Text = "MELALUI EKSPEDISI" Then
            cKodeEkspedisi.Enabled = True
            dTglNotaEkspedisi.Enabled = True
            tNoNotaEkspedisi.Enabled = True
            dTglNotaEkspedisi.EditValue = Format(DateAdd(DateInterval.Day, 0, Now), "dd/MM/yyyy")
            tNoResi.Enabled = True
            tNoTracking.Enabled = True
        Else
            cKodeEkspedisi.Enabled = False
            dTglNotaEkspedisi.Enabled = False
            tNoNotaEkspedisi.Enabled = False
            tNoResi.Enabled = False
            tNoTracking.Enabled = False
            cKodeEkspedisi.Text = ""
            dTglNotaEkspedisi.Text = ""
            tNoNotaEkspedisi.Text = ""
            tNamaEkspedisi.Text = ""
            tNoResi.Text = ""
            tNoTracking.Text = ""
        End If
    End Sub

    Private Sub tJenisBarang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tJenisBarang.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Dim pRow() As DataRow
    Public Sub New(pRow() As DataRow)

        ' This call is required by the designer.
        InitializeComponent()
        Me.pRow = pRow
        ' Add any initialization after the InitializeComponent() call.
    End Sub
End Class