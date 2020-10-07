Imports System.Data.SqlClient
Imports meCore
Public Class frmDetailBarang

    Private Sub frmDetailBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tgl As Date = Format(Now, "dd/MM/yyyy")
        tTanggal.Text = tgl

        Dim sp As String = Me.Tag
        dglistpenawaran.FirstInit("select Kode,Judul,Penyusun,Jilid,KdSupplier,NamaPenerbit,Saldo,QTY,Harga,Disc,cast(0 as numeric(10)) as Jumlah from vwSP where Faktur = '" & Me.Tag & "' Order by Urutan", {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, , , {"Saldo", "KdSupplier", "NamaPenerbit"})
        dglistpenawaran.RefreshData(False)

        Dim jmlrow As Integer
        jmlrow = dglistpenawaran.DataSource.Rows.Count
        For a = 0 To jmlrow - 1
            If dglistpenawaran.GetRowCellValue(a, "Saldo") = 0 Then
                dglistpenawaran.SetRowCellValue(a, "QTY", 0)
            End If
            Dim jml, diskon, jml2 As Double
            jml = CDbl(dglistpenawaran.GetRowCellValue(a, "QTY")) * CDbl(dglistpenawaran.GetRowCellValue(a, "Harga"))
            diskon = jml * (CDbl(dglistpenawaran.GetRowCellValue(a, "Disc")) / 100)
            jml2 = jml - diskon
            dglistpenawaran.SetRowCellValue(a, "Jumlah", jml2)
        Next
    End Sub

    Private Sub dglistpenawaran_Grid_DoubleClick(sender As Object, e As EventArgs) Handles dglistpenawaran.Grid_DoubleClick
        koneksi()
        tKode.Text = dglistpenawaran.GetRowCellValue(dglistpenawaran.FocusedRowHandle, "Kode")
        cmd = New SqlCommand("select Kode, Judul,Penyusun,NamaPenerbit, Jilid, KdGolongan, Halaman, HBeli, SHBeli, DiscBeli, KdSupplier,  HJual, SDiscBeli, LockBeli, KdBuku, DiscMax, LockJual, FlagPajak from vwStkSup where Kode = '" & tKode.Text & "'", kon)
        rd = cmd.ExecuteReader
        rd.Read()
        tNama.Text = rd!Judul
        tNamaD.Text = rd!Judul
        tPenyusunD.Text = rd!Penyusun
        tPenerbitD.Text = rd!NamaPenerbit
        tJilidD.Text = rd!Jilid
        tStatus.Text = rd!FlagPajak
        If tStatus.Text = "1" Then
            tStatus.Text = "Kena Pajak"
        Else
            tStatus.Text = "Bebas Pajak"
        End If
        tQTY.Text = dglistpenawaran.GetRowCellValue(dglistpenawaran.FocusedRowHandle, "QTY")
        tQTYMax.Text = dglistpenawaran.GetRowCellValue(dglistpenawaran.FocusedRowHandle, "Saldo")
        tQSP.Text = dglistpenawaran.GetRowCellValue(dglistpenawaran.FocusedRowHandle, "Saldo")
        tSaldo.Text = dglistpenawaran.GetRowCellValue(dglistpenawaran.FocusedRowHandle, "Saldo")
        tDisc.Text = dglistpenawaran.GetRowCellValue(dglistpenawaran.FocusedRowHandle, "Disc")
        tDiscMax.Text = rd!DiscMax
        tHarga.Text = dglistpenawaran.GetRowCellValue(dglistpenawaran.FocusedRowHandle, "Harga")
        rd.Close()

        Dim qq As String = "select KdGudang as Gudang, sum(akhir) as Qty from trStkGud where kode = '" & tKode.Text & "' group by Kdgudang having sum(akhir) <> 0 order by KdGudang"
        dgsaldo.FirstInit(qq, {1, 1})
        dgsaldo.RefreshData(False)

        Dim jml, diskon, jml2 As Double
        jml = CDbl(tQTY.Text) * CDbl(tHarga.Text)
        diskon = jml * (CDbl(tDisc.Text) / 100)
        jml2 = jml - diskon
        tJumlah.Text = jml2
    End Sub

    Sub itung(ByVal harga As Double, ByVal qty As Double, ByVal disc As Double)
        Dim jml, diskon, jml2 As Double
        jml = CDbl(qty) * CDbl(harga)
        diskon = jml * (CDbl(disc) / 100)
        jml2 = jml - diskon
        tJumlah.Text = jml2
    End Sub

    Private Sub tHarga_EditValueChanged(sender As Object, e As EventArgs) Handles tHarga.EditValueChanged
        If tHarga.Text = "" Then
            tHarga.Text = "0"
        End If
        If tQTY.Text = "" Then
            tQTY.Text = "0"
        End If
        If tDisc.Text = "" Then
            tDisc.Text = "0"
        End If

        itung(tHarga.Text, tQTY.Text, tDisc.Text)
    End Sub

    Private Sub tQTY_EditValueChanged(sender As Object, e As EventArgs) Handles tQTY.EditValueChanged
        If Not IsNumeric(tQTY.Text) Or tQTY.Text = "" Then
            tQTY.Text = "0"
        End If

        If tQTY.Text > tQTYMax.Text Then
            tQTY.Text = "0"
        End If

        If tHarga.Text = "" Then
            tHarga.Text = "0"
        End If
        If tQTY.Text = "" Then
            tQTY.Text = "0"
        End If
        If tDisc.Text = "" Then
            tDisc.Text = "0"
        End If

        itung(tHarga.Text, tQTY.Text, tDisc.Text)
    End Sub

    Private Sub tDisc_EditValueChanged(sender As Object, e As EventArgs) Handles tDisc.EditValueChanged
        If tHarga.Text = "" Then
            tHarga.Text = "0"
        End If
        If tQTY.Text = "" Then
            tQTY.Text = "0"
        End If
        If tDisc.Text = "" Then
            tDisc.Text = "0"
        End If

        If tDisc.Text > tDiscMax.Text Then
            tDisc.Text = "0"
        End If

        itung(tHarga.Text, tQTY.Text, tDisc.Text)
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        If tHarga.Text = "" Then
            tHarga.Text = "0"
        End If
        If tQTY.Text = "" Then
            tQTY.Text = "0"
        End If
        If tDisc.Text = "" Then
            tDisc.Text = "0"
        End If

        itung(tHarga.Text, tQTY.Text, tDisc.Text)

        dglistpenawaran.SetRowCellValue(dglistpenawaran.FocusedRowHandle, "QTY", tQTY.Text)
        dglistpenawaran.SetRowCellValue(dglistpenawaran.FocusedRowHandle, "Harga", tHarga.Text)
        dglistpenawaran.SetRowCellValue(dglistpenawaran.FocusedRowHandle, "Disc", tDisc.Text)
        dglistpenawaran.SetRowCellValue(dglistpenawaran.FocusedRowHandle, "Jumlah", tJumlah.Text)
    End Sub


    Public Result() As DataRow
    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        Dim dRow() As DataRow = Nothing
        dRow = dglistpenawaran.DataSource.Select("QTY <> 0")
        Result = dRow
        'Using xx As New frmPenjualanBO
        '    For Each aa As DataRow In dRow
        '        xx.dgList.SetRowCellValue("", "QTY", aa!QTY)
        '    Next
        'End Using
        Me.Close()
    End Sub
End Class