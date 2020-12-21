Imports meCore
Imports System.Data.SqlClient

Public Class frmDepositCustomerSupplier

    Private Sub frmDepositCustomerSupplier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadData()
    End Sub

    Sub loadData()
        SetTextReadOnly({tFaktur, sSisa})
        dTanggal.EditValue = Now

        Dim kodeFaktur As String = ""
        Dim cussup As String = ""

        txtJudul.Text = Text

        Select Case txtJudul.Text.ToUpper
            Case "DEPOSIT CUSTOMER / UANG MUKA"
                kodeFaktur = "DP"
                cussup = "mstCustomer"
            Case "DEPOSIT SUPPLIER"
                kodeFaktur = "UM"
                cussup = "MstSupplier"
        End Select

        Dim querykdcussup As String = _
            "select a.Kode, a.Nama, a.Alamat, (sum(isnull(b.Masuk,0)) + sum(isnull(b.Lunas,0))) as Sisa from " & cussup & " a " & _
            "left join trDeposit b on a.Kode = b.KdCusSup " & _
            "group by a.Kode,a.Nama,a.Alamat order by a.Kode"

        tFaktur.Text = GetNewFakturTogamasSQLServ(PubConnStr, "trDeposit", FakturReset.Tahunan, "Faktur", pubKodeUnit & pubUserInit & "-" & kodeFaktur, DTOC(Now), 5, "")
        cKdCusSup.FirstInit(PubConnStr, querykdcussup, {tNama, tAlamat, sSisa}, , , , , , {0.5, 1, 1}, {"Sisa"})
    End Sub

    Private Sub btnBaru_Click(sender As Object, e As EventArgs) Handles btnBaru.Click
        ClearValue(Me)
        loadData()
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Me.Close()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If tNoBukti.Text = "" Or sJumlah.EditValue = 0 Or tKeterangan.Text = "" Then
            MsgBox("Data Belum Lengkap!", vbOKOnly + vbCritical, "Peringatan")
        Else
            Dim isSupplier As Boolean = True
            Select Case txtJudul.Text.ToUpper
                Case "DEPOSIT CUSTOMER / UANG MUKA"
                    isSupplier = False
                Case "DEPOSIT SUPPLIER"
                    isSupplier = True
            End Select

            Dim query As String = _
                "insert into trDeposit (Status,Faktur,Jenis,Tanggal,KdCusSup, " & _
                "Keterangan,Masuk,UserEntry, " & _
                "DateTimeEntry,NoBukti) values (" & _
                "'1','" & tFaktur.Text & "','" & isSupplier & "','" & DTOC(dTanggal.EditValue, "-", False) & "','" & cKdCusSup.Text & "'," & _
                "'" & tKeterangan.Text & "','" & sJumlah.EditValue & "','" & pubUserEntry & "'," & _
                "'" & DTOC(Now, "-", True) & "','" & tNoBukti.Text & "')"
            cmd = New SqlCommand(query, kon)
            cmd.ExecuteNonQuery()

            Dim sterbilang As String = Terbilang(sJumlah.EditValue)

            If Tanya({"Penyimpanan Transaksi SUKSES", "", "Cetak Faktur?"}) Then
                Dim pQueRpt As String = "select Faktur,convert(varchar(10),Tanggal,120) as Tanggal, Nama+' ('+KdCusSup+')' as Terima, Alamat, Keterangan, Masuk, UserEntry, Jenis, FktLunas, NoBukti,Lunas,Sisa,KdCusSup,Nama  from vwDeposit where Faktur='" & tFaktur.Text & "'"
                ShowReport(pQueRpt, "rptNotaDeposit", {compNama, compAlamat, compNoTlp, compNPWP, Strings.LTrim(sterbilang)})
            End If

            If Tanya({"Buat transaksi baru lagi?"}) Then
                btnBaru.PerformClick()
            Else
                Me.Close()
            End If
            End If
    End Sub

    Public Function Terbilang(ByVal nilai As Long) As String
        Dim bilangan As String() = {"", "Satu", "Dua", "Tiga", "Empat", "Lima", _
        "Enam", "Tujuh", "Delapan", "Sembilan", "Sepuluh", "Sebelas"}
        If nilai < 12 Then
            Return " " & bilangan(nilai)
        ElseIf nilai < 20 Then
            Return Terbilang(nilai - 10) & " Belas"
        ElseIf nilai < 100 Then
            Return (Terbilang(CInt((nilai \ 10))) & " Puluh") + Terbilang(nilai Mod 10)
        ElseIf nilai < 200 Then
            Return " Seratus" & Terbilang(nilai - 100)
        ElseIf nilai < 1000 Then
            Return (Terbilang(CInt((nilai \ 100))) & " Ratus") + Terbilang(nilai Mod 100)
        ElseIf nilai < 2000 Then
            Return " Seribu" & Terbilang(nilai - 1000)
        ElseIf nilai < 1000000 Then
            Return (Terbilang(CInt((nilai \ 1000))) & " Ribu") + Terbilang(nilai Mod 1000)
        ElseIf nilai < 1000000000 Then
            Return (Terbilang(CInt((nilai \ 1000000))) & " Juta") + Terbilang(nilai Mod 1000000)
        ElseIf nilai < 1000000000000 Then
            Return (Terbilang(CInt((nilai \ 1000000000))) & " Milyar") + Terbilang(nilai Mod 1000000000)
        ElseIf nilai < 1000000000000000 Then
            Return (Terbilang(CInt((nilai \ 1000000000000))) & " Trilyun") + Terbilang(nilai Mod 1000000000000)
        Else
            Return ""
        End If
    End Function
End Class