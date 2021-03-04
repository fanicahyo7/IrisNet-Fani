Imports meCore
Imports System.Data.SqlClient

Public Class frmPBYaddPerforma
    Dim nopengajuanpub As String = ""
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(nopengajuan As String)
        InitializeComponent()
        Me.nopengajuanpub = nopengajuan
    End Sub
    Private Sub frmPBYaddPerforma_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        Dim qkdsup As String = "select Kode, Nama, Bank, NoAccount, AtasNama from mstSupplier Order by Nama"
        'cKodeSupplier.FirstInit(PubConnStr, qkdsup, {tNama, tNamaBank, tNoRekening, tAtasNama}, False, , , , , {0.9, 2, 1, 1, 1})
        cKodeSupplier.FirstInit(PubConnStr, qkdsup, , False, , , , , {0.9, 2, 1, 1, 1})
        SetTextReadOnly({tNama, tKategori, tCtr, tPerforma, tNoPengajuan})
        sTotPengajuan.Properties.Mask.UseMaskAsDisplayFormat = True

        cTrans.SelectedIndex = 0
        tKategori.Text = "ISIDENTIL"

        If Not nopengajuanpub = "" Then
            tNoPengajuan.Text = nopengajuanpub
            SetTextReadOnly({tNoPengajuan})
        End If
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If CheckBeforeSave({tNamaBank, tAtasNama, tNoRekening, cKodeSupplier}) = True Then
            Try
                Dim question = MsgBox("Simpan performa Supplier?", vbQuestion + vbYesNo, "Konfirmasi")
                If question = vbYes Then
                    If nopengajuanpub = "" Then
                        Dim angka As String = kodepby("'" & pubKodeUnit & "PBY-" & Format(Now, "yyMM") & "'")
                        tNoPengajuan.Text = "" & pubKodeUnit & "PBY-" & Format(Now, "yyMM") & "" & angka
                    Else
                        tNoPengajuan.Text = nopengajuanpub
                        SetTextReadOnly({tNoPengajuan})
                    End If

                    Dim angkactr As String = kodectr("'" & pubKodeUnit & "CTR-" & Format(Now, "yyMM") & "'")
                    tCtr.Text = "" & pubKodeUnit & "CTR-" & Format(Now, "yyMM") & angkactr

                    Dim angkaperforma As String = kodeperforma("'" & pubKodeUnit & "PRF-" & cKodeSupplier.Text & "." & Format(Now, "yyMM") & "'")
                    tPerforma.Text = "" & pubKodeUnit & "PRF-" & cKodeSupplier.Text & "." & Format(Now, "yyMM") & angkaperforma


                    Dim query As String = "select Count(*) as Total from trPengajuanBayarHD where NoPengajuan = '" & tNoPengajuan.Text & "'"
                    cmd = New SqlCommand(query, kon)
                    rd = cmd.ExecuteReader
                    Dim total As Integer = 0
                    rd.Read()
                    total = CInt(rd!Total)
                    rd.Close()

                    Dim minggu As String = cariminggu(Now)

                    Dim queryhd As String = ""
                    Dim querydt As String = ""
                   
                    If total <= 0 And nopengajuanpub = "" Then
                        queryhd = _
                            "Insert Into trPengajuanBayarHD (" & _
                            "NoPengajuan,JnsPengajuan,KdUnit,TglPengajuan,TransferKe," & _
                            "KdSupplier,NamaSupplier,Kategori,NoCTR,Bank," & _
                            "AtasNama,NoRek,MingguKe)  Values(" & _
                            "'" & tNoPengajuan.Text & "','PERFORMA','" & pubKodeUnit & "','" & DTOC(Now, "-", True) & "','" & cTrans.Text.ToUpper & "'," & _
                            "'" & cKodeSupplier.Text & "','" & tNama.Text & "','" & tKategori.Text & "','" & tCtr.Text & "','" & tNamaBank.Text & "'," & _
                            "'" & tAtasNama.Text & "','" & tNoRekening.Text & "','" & minggu & "')"

                        querydt = _
                           "Insert Into trPengajuanBayarDt (" & _
                           "NoCTR,Faktur,FakturAsli,TglFaktur,JthTmp," & _
                           "KdSupplier,NamaSupplier,Total,ReturFisik,ReturAdmin," & _
                           "Terjual,JenisFaktur,FakturReinv)  Values(" & _
                           "'" & tCtr.Text & "','" & tPerforma.Text & "','','" & DTOC(Now, "-", True) & "','" & DTOC(Now, "-", True) & "'," & _
                           "'" & cKodeSupplier.Text & "','" & tNama.Text & "','" & sTotPengajuan.Value & "','0','0'," & _
                           "'" & sTotPengajuan.Value & "','DEPOSIT','')"

                    Else
                        'Dim angka As String = "" & pubKodeUnit & "PBY-" & Format(Now, "yyMM") & kodepby("'" & pubKodeUnit & "PBY-" & Format(Now, "yyMM") & "'")

                        'angkactr = "" & pubKodeUnit & "CTR-" & Format(Now, "yyMM") & kodectr("'" & pubKodeUnit & "CTR-" & Format(Now, "yyMM") & "'")
                        'queryhd = _
                        '    "Insert Into trPengajuanBayarHD (" & _
                        '    "NoPengajuan,JnsPengajuan,KdUnit,TglPengajuan,TransferKe," & _
                        '    "KdSupplier,NamaSupplier,Kategori,NoCTR,Bank," & _
                        '    "AtasNama,NoRek,MingguKe)  Values(" & _
                        '    "'" & angka & "','PERFORMA','" & pubKodeUnit & "','" & DTOC(Now, "-", True) & "','" & cTrans.Text.ToUpper & "'," & _
                        '    "'" & cKodeSupplier.Text & "','" & tNama.Text & "','" & tKategori.Text & "','" & angkactr & "','" & tNamaBank.Text & "'," & _
                        '    "'" & tAtasNama.Text & "','" & tNoRekening.Text & "','" & minggu & "')"

                        Dim query1 As String = "select Count(*) as Total from trPengajuanBayarHD where NoPengajuan = '" & tNoPengajuan.Text & "' and KdSupplier='" & cKodeSupplier.Text & "'"
                        cmd = New SqlCommand(query1, kon)
                        rd = cmd.ExecuteReader
                        Dim totalkd As Integer = 0
                        rd.Read()
                        totalkd = CInt(rd!Total)
                        rd.Close()


                        Dim carisi As String = "select top 1 * from trPengajuanBayarHD where NoPengajuan = '" & tNoPengajuan.Text & "'"
                        cmd = New SqlCommand(carisi, kon)
                        rd = cmd.ExecuteReader
                        rd.Read()
                        If totalkd <= 0 Then
                            queryhd = _
                            "Insert Into trPengajuanBayarHD (" & _
                            "NoPengajuan,JnsPengajuan,KdUnit,TglPengajuan,TransferKe," & _
                            "KdSupplier,NamaSupplier,Kategori,NoCTR,Bank," & _
                            "AtasNama,NoRek,MingguKe)  Values(" & _
                            "'" & tNoPengajuan.Text & "','PERFORMA','" & pubKodeUnit & "','" & DTOC(rd!TglPengajuan, "-", True) & "','" & cTrans.Text.ToUpper & "'," & _
                            "'" & cKodeSupplier.Text & "','" & tNama.Text & "','" & tKategori.Text & "','" & tCtr.Text & "','" & tNamaBank.Text & "'," & _
                            "'" & tAtasNama.Text & "','" & tNoRekening.Text & "','" & minggu & "')"
                        Else
                            queryhd = _
                            "Update trPengajuanBayarHD Set " & _
                            "NoPengajuan = '" & tNoPengajuan.Text & "', JnsPengajuan = 'PERFORMA', KdUnit = '" & pubKodeUnit & "'," & _
                            "TglPengajuan = '" & DTOC(rd!TglPengajuan, "-", True) & "', TransferKe = '" & cTrans.Text.ToUpper & "', KdSupplier = '" & cKodeSupplier.Text & "'," & _
                            "NamaSupplier = '" & tNama.Text & "', Kategori = '" & tKategori.Text & "', NoCTR = '" & tCtr.Text & "'," & _
                            "Bank = '" & tNamaBank.Text & "', AtasNama = '" & tAtasNama.Text & "', NoRek = '" & tNoRekening.Text & "', MingguKe = '" & minggu & "' " & _
                            "Where NoPengajuan = '" & tNoPengajuan.Text & "' and KdSupplier = '" & cKodeSupplier.Text & "'"

                        End If
                        
                        querydt = _
                           "Insert Into trPengajuanBayarDt (" & _
                           "NoCTR,Faktur,FakturAsli,TglFaktur,JthTmp," & _
                           "KdSupplier,NamaSupplier,Total,ReturFisik,ReturAdmin," & _
                           "Terjual,JenisFaktur,FakturReinv)  Values(" & _
                           "'" & tCtr.Text & "','" & tPerforma.Text & "','','" & DTOC(rd!TglPengajuan, "-", True) & "','" & DTOC(rd!TglPengajuan, "-", True) & "'," & _
                           "'" & cKodeSupplier.Text & "','" & tNama.Text & "','" & sTotPengajuan.Value & "','0','0'," & _
                           "'" & sTotPengajuan.Value & "','DEPOSIT','')"

                        rd.Close()
                    End If
                    cmd = New SqlCommand(queryhd, kon)
                    cmd.ExecuteNonQuery()

                    'Dim querydt As String = ""
                    'querydt = _
                    '    "Insert Into trPengajuanBayarDt (" & _
                    '    "NoCTR,Faktur,FakturAsli,TglFaktur,JthTmp," & _
                    '    "KdSupplier,NamaSupplier,Total,ReturFisik,ReturAdmin," & _
                    '    "Terjual,JenisFaktur,FakturReinv)  Values(" & _
                    '    "'" & tCtr.Text & "','" & tPerforma.Text & "','','" & DTOC(Now, "-", True) & "','" & DTOC(Now, "-", True) & "'," & _
                    '    "'" & cKodeSupplier.Text & "','" & tNama.Text & "','" & sTotPengajuan.Value & "','0','0'," & _
                    '    "'" & sTotPengajuan.Value & "','DEPOSIT','')"
                    'Dim query2 As String = _
                    '    "select Count(*) as Total from trPengajuanBayarDt where NoCTR = '" & tCtr.Text & "' and Faktur = '" & tPerforma.Text & "'"
                    'cmd = New SqlCommand(query2, kon)
                    'rd = cmd.ExecuteReader
                    'Dim totaln As Integer = 0
                    'rd.Read()
                    'totaln = rd!Total
                    'rd.Close()
                    'If totaln <= 0 Then
                    '    querydt = _
                    '        "Insert Into trPengajuanBayarDt (" & _
                    '        "NoCTR,Faktur,FakturAsli,TglFaktur,JthTmp," & _
                    '        "KdSupplier,NamaSupplier,Total,ReturFisik,ReturAdmin," & _
                    '        "Terjual,JenisFaktur,FakturReinv)  Values(" & _
                    '        "'" & tCtr.Text & "','" & tPerforma.Text & "','','" & DTOC(Now, "-", True) & "','" & DTOC(Now, "-", True) & "'," & _
                    '        "'" & cKodeSupplier.Text & "','" & tNama.Text & "','" & sTotPengajuan.Value & "','0','0'," & _
                    '        "'" & sTotPengajuan.Value & "','DEPOSIT','')"
                    'Else
                    '    'angkactr = "" & pubKodeUnit & "CTR-" & Format(Now, "yyMM") & kodectr("'" & pubKodeUnit & "CTR-" & Format(Now, "yyMM") & "'")
                    '    'angkaperforma = "" & pubKodeUnit & "PRF-" & cKodeSupplier.Text & "." & Format(Now, "yyMM") & kodeperforma("'" & pubKodeUnit & "PRF-" & cKodeSupplier.Text & "." & Format(Now, "yyMM") & "'")
                    '    querydt = _
                    '        "Insert Into trPengajuanBayarDt (" & _
                    '        "NoCTR,Faktur,FakturAsli,TglFaktur,JthTmp," & _
                    '        "KdSupplier,NamaSupplier,Total,ReturFisik,ReturAdmin," & _
                    '        "Terjual,JenisFaktur,FakturReinv)  Values(" & _
                    '        "'" & angkactr & "','" & angkaperforma & "','','" & DTOC(Now, "-", True) & "','" & DTOC(Now, "-", True) & "'," & _
                    '        "'" & cKodeSupplier.Text & "','" & tNama.Text & "','" & sTotPengajuan.Value & "','0','0'," & _
                    '        "'" & sTotPengajuan.Value & "','DEPOSIT','')"
                    'End If
                    cmd = New SqlCommand(querydt, kon)
                    cmd.ExecuteNonQuery()
                    Me.Close()
                End If
            Catch ex As Exception
            Pesan({"GAGAL SIMPAN DATA", "", "Err : " & ex.Message.ToString})
        End Try
        End If
    End Sub

    Private Sub cKodeSupplier_EditValueChanged(sender As Object, e As EventArgs) Handles cKodeSupplier.EditValueChanged
        Dim qkdsup As String = "select Kode, Nama, Bank, NoAccount, AtasNama from mstSupplier where Kode='" & cKodeSupplier.Text & "'"
        cmd = New SqlCommand(qkdsup, kon)
        rd = cmd.ExecuteReader
        rd.Read()
        Dim namasup As String = ""
        Dim namabank As String = ""
        Dim norekening As String = ""
        Dim atasnama As String = ""
        If rd.HasRows Then
            namasup = rd!Nama
            namabank = rd!Bank
            norekening = rd!NoAccount
            atasnama = rd!AtasNama
        End If
        rd.Close()

        tNama.Text = namasup
        If cTrans.Text.ToUpper = "SUPPLIER" Then
            tNamaBank.Text = namabank
            tNoRekening.Text = norekening
            tAtasNama.Text = atasnama
        Else
            tNamaBank.Text = "BCA"
            tAtasNama.Text = "***REK OPERASIONAL***"
            tNoRekening.Text = "***REK OPERASIONAL***"
        End If

        'If nopengajuanpub = "" Then
        '    Dim angka As String = kodepby("'" & pubKodeUnit & "PBY-" & Format(Now, "yyMM") & "'")
        '    tNoPengajuan.Text = "" & pubKodeUnit & "PBY-" & Format(Now, "yyMM") & "" & angka
        'Else
        '    tNoPengajuan.Text = nopengajuanpub
        '    SetTextReadOnly({tNoPengajuan})
        'End If

        'Dim angkactr As String = kodectr("'" & pubKodeUnit & "CTR-" & Format(Now, "yyMM") & "'")
        'tCtr.Text = "" & pubKodeUnit & "CTR-" & Format(Now, "yyMM") & angkactr

        'Dim angkaperforma As String = kodeperforma("'" & pubKodeUnit & "PRF-" & cKodeSupplier.Text & "." & Format(Now, "yyMM") & "'")
        'tPerforma.Text = "" & pubKodeUnit & "PRF-" & cKodeSupplier.Text & "." & Format(Now, "yyMM") & angkaperforma

    End Sub

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

    Function kodeperforma(ByVal kode As String) As String
        Dim cariperforma As String = _
            "select max(SUBSTRING( Faktur,18,2)) as max from trPengajuanBayarDt where left(Faktur,17) = " & kode & ""
        cmd = New SqlCommand(cariperforma, kon)
        rd = cmd.ExecuteReader
        Dim angkaperforma As String = ""
        rd.Read()
        If rd.HasRows Then
            If IsDBNull(rd!max) Then
                angkaperforma = ""
            Else
                angkaperforma = rd!max
            End If

            If angkaperforma = "" Then
                angkaperforma = "01"
            Else
                angkaperforma = CInt(angkaperforma) + 1
                If Len(angkaperforma) = 1 Then
                    angkaperforma = "0" & angkaperforma
                End If
            End If
        End If
        rd.Close()
        Return angkaperforma
    End Function

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

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Me.Close()
    End Sub

    Private Sub cTrans_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cTrans.SelectedIndexChanged
        If cTrans.Text.ToUpper = "SUPPLIER" Then
            Dim qkdsup As String = "select Kode, Nama, Bank, NoAccount, AtasNama from mstSupplier where Kode='" & cKodeSupplier.Text & "'"
            cmd = New SqlCommand(qkdsup, kon)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                tNamaBank.Text = rd!Bank
                tAtasNama.Text = rd!AtasNama
                tNoRekening.Text = rd!NoAccount
            Else
                tNamaBank.Text = ""
                tAtasNama.Text = ""
                tNoRekening.Text = ""
            End If
            rd.Close()
        Else
            tNamaBank.Text = "BCA"
            tAtasNama.Text = "***REK OPERASIONAL***"
            tNoRekening.Text = "***REK OPERASIONAL***"
        End If
    End Sub
End Class