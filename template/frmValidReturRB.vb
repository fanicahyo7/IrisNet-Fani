Imports meCore
Imports System.Data.SqlClient
Public Class frmValidReturRB
    Dim db As New cMeDB
    'Dim pubKodeUnit As String = "601"
    'Dim pubUserInit As String = "FAN"
    'Dim pubUserEntry As String = "FANI"
    Public judul As String = ""

    Private Sub frmValidReturRB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initForm(Me, EnfrmSizeNotMax.efsnm0Default, DevExpress.XtraLayout.MoveFocusDirection.DownThenAcross)
        tLoginName.Properties.CharacterCasing = CharacterCasing.Upper
        tValidator.Properties.CharacterCasing = CharacterCasing.Upper
        tJenisValidasi.Properties.CharacterCasing = CharacterCasing.Upper
        tFaktur.Properties.CharacterCasing = CharacterCasing.Upper
        tJamValidasi.Properties.CharacterCasing = CharacterCasing.Upper
        tKeterangan.Properties.CharacterCasing = CharacterCasing.Upper
        tChecker.Properties.CharacterCasing = CharacterCasing.Upper
        tPassword.Properties.CharacterCasing = CharacterCasing.Upper

        koneksi()
        tFaktur.Text = Me.Tag
        tJamValidasi.Text = Now
        Dim pQuery As String = ""
        Dim tabel As String = ""
        tKeterangan.Text = "DETAIL BARANG SUDAH SESUAI DENGAN FAKTUR"

        Select Case Replace(judul, "Validasi ", "", , , CompareMethod.Text).ToLower
            Case "retur pembelian"
                tJenisValidasi.Text = "VALIDASI FAKTUR RETUR PEMBELIAN"
                tabel = "trPCRHeader"
            Case "pembelian"
                tJenisValidasi.Text = "VALIDASI FAKTUR PEMBELIAN"
                tabel = "trPCHeader"
            Case "penjualan"
                tJenisValidasi.Text = "VALIDASI FAKTUR PENJUALAN"
                tabel = "trSLHeader"
            Case "retur penjualan"
                tJenisValidasi.Text = "VALIDASI FAKTUR RETUR PENJUALAN"
                tabel = "trSLRHeader"
            Case "penerimaan konsinyasi"
                tJenisValidasi.Text = "VALIDASI FAKTUR PENERIMAAN KONSINYASI"
                tabel = "trKonsHeader"
            Case "retur penerimaan konsinyasi"
                tJenisValidasi.Text = "VALIDASI FAKTUR RETUR PENERIMAAN KONSINYASI"
                tabel = "trKonsRHeader"
            Case "mutasi gudang"
                tJenisValidasi.Text = "VALIDASI FAKTUR MUTASI GUDANG"
                tabel = "trMTHeader"
            Case "kirim konsinyasi"
                tJenisValidasi.Text = "VALIDASI FAKTUR KIRIM KONSINYASI"
                tabel = "trSKonsHeader"
            Case "retur kirim konsinyasi"
                tJenisValidasi.Text = "VALIDASI FAKTUR RETUR KIRIM KONSINYASI"
                tabel = "trSkonsRHeader"
            Case "terima ekspedisi"
                tJenisValidasi.Text = "VALIDASI FAKTUR TERIMA EKSPEDISI"
                tabel = "trTerimaEkspedisi"
            Case "kirim ekspedisi"
                tJenisValidasi.Text = "VALIDASI FAKTUR KIRIM EKSPEDISI"
                tabel = "trKirimEkspedisi"
        End Select
        pQuery = "select Keterangan from " & tabel & " where isnull(UserValid,'') = '' and Faktur='" & Me.Tag & "' Order by Faktur Desc"
        Try
            cmd = New SqlCommand(pQuery, kon)
            rd = cmd.ExecuteReader()
            rd.Read()
            If IsDBNull(rd!Keterangan) = False Then
                tKeterangan.Text = rd!Keterangan
            End If
            rd.Close()
        Catch ex As Exception

        End Try

        tLoginName.Text = pubUserEntry
        tValidator.Text = pubUserEntry
        SetTextReadOnly({tLoginName, tValidator, tJenisValidasi, tFaktur, tJamValidasi, tKeterangan})
    End Sub

    Private Sub btnValidasi_Click(sender As Object, e As EventArgs) Handles btnValidasi.Click
        If CheckBeforeSave({tChecker, tPassword}) = False Then Exit Sub

        If tLoginName.Text.ToLower = "qc" Or tLoginName.Text.ToLower = "superuser" Then GoTo xx


        Dim cloginpass As String
        cloginpass = "select * from UserLogin where UserName='" & tLoginName.Text & "'"
        cmd = New SqlCommand(cloginpass, kon)
        rd = cmd.ExecuteReader
        rd.Read()
        Dim pPasword As String = Replace(DecryptWithClipper(rd!Password, "password"), " ", "")
        rd.Close()

        If Not LCase(pPasword) = LCase(tPassword.Text) Then
            MsgBox("Login Gagal", vbCritical + vbOKOnly, "Peringatan")
        Else
xx:
            Dim noregister As String
            Dim qq As String = "select max(SUBSTRING( Noregister,9,4)) as max from trValidasi where Left(Noregister,8) = '" & Date.Now.ToString("yyyyMMdd") & "'"
            cmd = New SqlCommand(qq, kon)
            rd = cmd.ExecuteReader
            rd.Read()
            If Not IsDBNull(rd!max) = True Then
                Dim belakang As String = rd!max
                belakang = Strings.Right(belakang, 4) + 1
                If Len(belakang) = 1 Then
                    belakang = Date.Now.ToString("yyyyMMdd") & "000" & belakang
                ElseIf Len(belakang) = 2 Then
                    belakang = Date.Now.ToString("yyyyMMdd") & "00" & belakang
                ElseIf Len(belakang) = 3 Then
                    belakang = Date.Now.ToString("yyyyMMdd") & "0" & belakang
                ElseIf Len(belakang) = 4 Then
                    belakang = Date.Now.ToString("yyyyMMdd") & belakang
                End If
                noregister = belakang
                rd.Close()
            Else
                rd.Close()
                noregister = Date.Now.ToString("yyyyMMdd") & "0001"
            End If

            Dim sqlvalidasi As String
            sqlvalidasi = "Insert Into trValidasi (NoRegister,Checker,UserEntry,DateTimeEntry,Faktur,Keterangan,Validated)" & _
                        "Values" & _
                        "('" & noregister & "','" & tChecker.Text & "','" & pubUserEntry & "','" & DTOC(Now, "-", True) & "','" & tFaktur.Text & "','" & tKeterangan.Text & "','1')"
            cmd = New SqlCommand(sqlvalidasi, kon)
            cmd.ExecuteNonQuery()

            Dim tabel As String = ""
            Dim tableDetail As String = ""
            Dim tablesupcus As String = ""
            Select Case Replace(judul, "Validasi ", "", , , CompareMethod.Text).ToLower
                Case "retur pembelian"
                    tabel = "trPCRHeader"
                    tableDetail = "trPCRDetail"
                    tablesupcus = "mstsupplier"

                    Dim updatepcrdetail As String
                    updatepcrdetail = "Update trPCRDetail set Fire = 1, Kode= kode where Faktur = '" & tFaktur.Text & "'"
                    cmd = New SqlCommand(updatepcrdetail, kon)
                    cmd.ExecuteNonQuery()

                    Dim faktur As String = GetNewFakturSQLServ(PubConnStr, "trPCHeader", "Faktur", pubKodeUnit & pubUserInit & "-FB", Date.Now.ToString("yyMMdd"), 5, "")
                    Dim query As String
                    query = "select d.FlagPajak,b.SubTotal,c.KdBuku,* from trPCRAdminGen a " & _
                            "inner join trPCRHeader b " & _
                            "on a.Faktur = b.Faktur " & _
                            "inner join mstStkSup c " & _
                            "on a.Kode = c.Kode " & _
                            "inner join trPCRDetail d " & _
                            "on a.Kode = d.Kode " & _
                            "where a.Faktur='" & tFaktur.Text & "'"
                    da = New SqlDataAdapter(query, kon)
                    ds = New DataSet
                    da.Fill(ds, "pcr")
                    dt = ds.Tables("pcr")

                    Dim query2 As String = _
                                "Insert Into trPCHeader (Status,Faktur,Tanggal,KdSupplier,FakturAsli," & _
                                "KdGudang,DiscFaktur,Keterangan,PersPPN,PPn,SubTotal,UserEntry,DateTimeEntry,FlagPajakFaktur)  Values " & _
                                "('1','" & faktur & "','" & DTOC(Now, "/", True) & "','" & dt.Rows(0).Item("KdSUpplier") & "','" & dt.Rows(0).Item("FakturAsliBaru") & "'," & _
                                "'" & dt.Rows(0).Item("KdGudang") & "','" & dt.Rows(0).Item("DiscFaktur") & "','" & dt.Rows(0).Item("Keterangan") & "','" & dt.Rows(0).Item("PersPPn") & "','" & dt.Rows(0).Item("PPn") & "','" & dt.Rows(0).Item("SubTotal") & "','" & pubUserEntry & "','" & DTOC(Now, "/", True) & "','" & dt.Rows(0).Item("FlagPajak") & "')"
                    cmd = New SqlCommand(query2, kon)
                    cmd.ExecuteNonQuery()

                    For a = 0 To dt.Rows.Count - 1
                        Dim que As String
                        que = "Insert Into trPCDetail (Status,Faktur,Tanggal,Kode1,kode," & _
                            "KdBuku,Qty,Disc,Harga,Urutan,KdGudang,FlagPajak)  Values " & _
                            "('1','" & faktur & "','" & DTOC(Now, "/", True) & "','" & dt.Rows(a).Item("Kode") & "','" & dt.Rows(a).Item("Kode") & "'," & _
                            "'" & dt.Rows(a).Item("KdBuku") & "','" & dt.Rows(a).Item("QTY") & "','" & dt.Rows(a).Item("Disc") & "','" & dt.Rows(a).Item("Harga") & "','" & a + 1 & "','" & dt.Rows(a).Item("KdGudang") & "','" & dt.Rows(a).Item("FlagPajak") & "')"
                        cmd = New SqlCommand(que, kon)
                        cmd.ExecuteNonQuery()
                    Next
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
            Dim update As String

            Using dbtmp As New cMeDB
                '--update header
                update = "Update " & tabel & " Set UserValid = '" & pubUserEntry & "', DateTimeValid = '" & DTOC(Now, "-", True) & "'," & _
                            "Fire = '1',NoValidated='" & noregister & "' Where Faktur = '" & tFaktur.Text & "'"
                dbtmp.ExecScalar(update)

                '--update detail
                If tableDetail.Length > 0 Then
                    update = "Update " & tableDetail & " Set UserValid = '" & pubUserEntry & "' Where Faktur = '" & tFaktur.Text & "'"
                    dbtmp.ExecScalar(update)
                End If
            End Using

            MsgBox("Data Berhasil Tersimpan", vbInformation + vbOKOnly, "Informasi")

            If tablesupcus.Length > 0 Then
                Dim pQue As String = _
                        "SELECT top 1 '" & Replace(judul, "Validasi ", "", , , CompareMethod.Text) & "' as trans, *, " & _
                        "			nama + ' (' + b.kode + ')' as namasupcus,  kota, noaccount, atasnama, bank, " & _
                        "			(select sum(Qty) from " & tableDetail & " where faktur = a.faktur) as TotQty " & _
                        "FROM " & tabel & " a  " & _
                        "left join " & tablesupcus & " b on a." & IIf(tablesupcus = "mstsupplier", "kdsupplier", "kdcustomer") & " = b.kode " & _
                        "left join trValidasi c on a.faktur = c.faktur " & _
                        "where a.faktur = '" & tFaktur.Text & "'"
                
                If Tanya({"Langsung Cetak?"}) Then
                    ShowReport(pQue, "rptValidasi", , printTo.o2Print)
                Else
                    ShowReport(pQue, "rptValidasi", , printTo.o1ShowPreview)
                End If
            End If
            Me.Close()
        End If
    End Sub
End Class