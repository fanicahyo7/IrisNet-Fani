Imports meCore
Public Class frmPengunjungValid
    Dim db As New cMeDB
    Dim isNew As Boolean = True
    Public shiftkerja, namasecurity As String
    Public tgl As Date
    Public anak, dewasa, manula, remaja As Integer

    Private Sub frmPengunjungValid_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dTanggal.Text = tgl
        tNamaSecurity.Text = namasecurity
        cShift.Text = shiftkerja
        tAnak.Text = anak
        tDewasa.Text = dewasa
        tManula.Text = manula
        tRemaja.Text = remaja
        SetTextReadOnly({dTanggal, tNamaSecurity, cShift, tAnak, tDewasa, tManula, tRemaja})
        tNamaSecurity.Properties.CharacterCasing = CharacterCasing.Upper
        loadDetail()
    End Sub

    Private Sub btnValidData_Click(sender As Object, e As EventArgs) Handles btnValidData.Click
        If CheckBeforeSave({dTanggal, cShift, tNamaSecurity}) = True Then
            Try
                Dim drow As DataRow
                If isNew = True Then
                    drow = db.NewRow
                Else
                    drow = db.Rows(0)
                End If

                drow!Tanggal = dTanggal.Text
                drow!ShiftKerja = cShift.Text
                drow!Status = 1
                drow!UserValid = pubUserEntry

                If isNew Then db.Rows.Add(drow)
                db.UpdateMeToRealDBNoTry()
                Pesan({IIf(isNew = True, "Simpan", "Update") & " Data BERHASIL"})
                Me.Close()
            Catch ex As Exception
                Pesan({"GAGAL SIMPAN DATA", "", "Err : " & ex.Message.ToString})
            End Try
        End If
    End Sub

    Sub loadDetail()
        Dim pQuery As String = _
            "select ID,Tanggal,ShiftKerja,Status from LogValidPengunjung where Tanggal='" & tgl & "' and ShiftKerja='" & shiftkerja & "'"
        db.FillMe(pQuery, True)
        isNew = True
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Me.Close()
    End Sub
End Class