Imports System.Data.SqlClient
Imports meCore
Public Class frmPengunjung
    Dim db As New cMeDB
    Dim db1 As New cMeDB
    Dim pKode As Date = "2000-01-01"
    Dim pShift As String = "jkgbd"
    Dim isNew As Boolean = True
    Dim kategori() As String = {"Anak-Anak", "Remaja", "Dewasa", "Manula"}
    Private Sub frmPengunjung_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        tNamaSecurity.Properties.CharacterCasing = CharacterCasing.Upper
        If Me.Tag <> "" Then pKode = Me.Tag
        loadDetail()
        dTanggal.EditValue = Now
    End Sub
    Sub loadDetail()
        Dim pQuery As String = _
            "Select Tanggal, NamaSecurity, ShiftKerja, Kategori, Nilai, UserEntry, DateTimeEntry from trPengunjung where Tanggal = '" & Format(pKode, "yyyy/MM/dd") & "'"
        db.FillMe(pQuery, True)

        Dim querylog As String = _
            "select ID,Tanggal,ShiftKerja,Status from LogValidPengunjung where Tanggal='" & Format(CDate(pKode), "yyyy/MM/dd") & "' and ShiftKerja='" & pShift & "'"
        db1.FillMe(querylog, True)
        isNew = True
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If CheckBeforeSave({dTanggal, cShift, tNamaSecurity}) = True Then
            Try
                Dim scek As String
                scek = "select TOP 1 * from trPengunjung where Tanggal='" & Format(CDate(dTanggal.Text), "yyyy/MM/dd") & "' AND SHiftKerja='" & cShift.Text & "'"
                cmd = New SqlCommand(scek, kon)
                rd = cmd.ExecuteReader
                rd.Read()
                If rd.HasRows Then
                    MsgBox("DUPLICATE DATA", vbCritical + vbOKOnly, "Peringatan")
                    rd.Close()
                Else
                    Dim tanggalsimpan As Date = Now
                    For a = 0 To 3
                        Dim drow As DataRow
                        If isNew = True Then
                            drow = db.NewRow
                        Else
                            drow = db.Rows(0)
                        End If

                        drow!Tanggal = dTanggal.Text
                        drow!NamaSecurity = tNamaSecurity.Text
                        drow!ShiftKerja = cShift.Text
                        drow!Kategori = kategori(a)
                        If a = 0 Then
                            drow!Nilai = CInt(tAnak.Value.ToString)
                        ElseIf a = 1 Then
                            drow!Nilai = CInt(tRemaja.Value.ToString)
                        ElseIf a = 2 Then
                            drow!Nilai = CInt(tDewasa.Value.ToString)
                        ElseIf a = 3 Then
                            drow!Nilai = CInt(tManula.Value.ToString)
                        End If
                        drow!UserEntry = pubUserEntry
                        drow!DateTimeEntry = tanggalsimpan

                        If isNew Then db.Rows.Add(drow)
                        db.UpdateMeToRealDBNoTry()
                    Next

                    Dim drow1 As DataRow
                    If isNew = True Then
                        drow1 = db1.NewRow
                    Else
                        drow1 = db1.Rows(0)
                    End If

                    drow1!Tanggal = dTanggal.Text
                    drow1!ShiftKerja = cShift.Text
                    drow1!Status = 0
                    If isNew Then db1.Rows.Add(drow1)
                    db1.UpdateMeToRealDBNoTry()
                    'Dim query As String = _
                    '    "insert into LogValidPengunjung (Tanggal,Shiftkerja,Status) values ('" & dTanggal.Text & "','" & cShift.Text & "','0')"
                    'cmd = New SqlCommand(query, kon)
                    'cmd.ExecuteNonQuery()
                    Pesan({IIf(isNew = True, "Simpan", "Update") & " Data BERHASIL"})
                    rd.Close()
                    Me.Close()
                End If
            Catch ex As Exception
                Pesan({"GAGAL SIMPAN DATA", "", "Err : " & ex.Message.ToString})
            End Try
        End If
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Me.Close()
    End Sub
End Class