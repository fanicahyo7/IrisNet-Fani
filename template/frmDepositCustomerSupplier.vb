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
                "Keterangan,Masuk,Lunas,UserEntry, " & _
                "DateTimeEntry,NoBukti,FlagPosted) values (" & _
                "'1','" & tFaktur.Text & "','" & isSupplier & "','" & DTOC(dTanggal.EditValue, "-", False) & "','" & cKdCusSup.Text & "'," & _
                "'" & tKeterangan.Text & "','" & sJumlah.EditValue & "','" & sJumlah.EditValue & "','" & pubUserEntry & "'," & _
                "'" & DTOC(Now, "-", True) & "','" & tNoBukti.Text & "','0')"
            cmd = New SqlCommand(query, kon)
            cmd.ExecuteNonQuery()


            'If Tanya({"Penyimpanan Transaksi SUKSES", "", "Cetak Faktur?"}) Then
            '    Dim pQueRpt As String = "Select * from vwSLR where faktur in ('" & tFaktur.Text & "') order by faktur, urutan"
            '    ShowReport(pQueRpt, "rptSL", {compNama, compAlamat, compNoTlp, compNPWP})
            'End If

            If Tanya({"Buat transaksi baru lagi?"}) Then
                btnBaru.PerformClick()
            Else
                Me.Close()
            End If
        End If
    End Sub
End Class