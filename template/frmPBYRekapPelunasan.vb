﻿Imports System.Data.SqlClient
Imports meCore
Public Class frmPBYRekapPelunasan
    Dim nopengajuan As String = ""
    Dim status As String = ""
    Dim valid As Boolean = False
    Dim kategori As String = ""
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(nopengajuan As String, status As String, valid As Boolean, kategori As String)
        InitializeComponent()
        Me.nopengajuan = nopengajuan
        Me.status = status
        Me.valid = valid
        Me.kategori = kategori
    End Sub

    Private Sub frmPBYRekapPelunasan_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim carihd As String = "select * from trPengajuanBayarHd where NoCtr='" & dgList.GetRowCellValue(dgList.FocusedRowHandle, "NoCtr") & "'"
        cmd = New SqlCommand(carihd, kon)
        rd = cmd.ExecuteReader
        rd.Read()

        If rd.HasRows Then
            Dim bank As String = rd!Bank
            Dim atasnama As String = rd!AtasNama
            Dim norek As String = rd!NoRek

            Dim queryupdate As String = _
                "Update trPengajuanBayarHD Set TransferKe = '" & dgList.GetRowCellValue(dgList.FocusedRowHandle, "TransferKe").ToString.ToUpper & "', Promo = '" & dgList.GetRowCellValue(dgList.FocusedRowHandle, "Promo") & "', Bank = '" & bank & "', AtasNama = '" & atasnama & "', NoRek = '" & norek & "' Where NoBTT = '" & dgList.GetRowCellValue(dgList.FocusedRowHandle, "NoBTT") & "'"
            rd.Close()
            cmd = New SqlCommand(queryupdate, kon)
            cmd.ExecuteNonQuery()
        End If
        rd.Close()
    End Sub
    Private Sub frmPBYRekapPelunasan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        refreshdata()
        sPengajuan.Properties.Mask.UseMaskAsDisplayFormat = True
    End Sub

    Sub refreshdata()
        koneksi()
        SetTextReadOnly({tNoPengajuan, tTanggal, tStatus, sSisa, sValid, sLunas, sPengajuan})

        tNoPengajuan.Text = nopengajuan

        If status.ToUpper = "KIRIM PUSAT" Then
            tStatus.Text = "KIRIM PENGAJUAN KE PUSAT"
        ElseIf status.ToUpper = "PENGAJUAN UNIT" Then
            tStatus.Text = "PENGAJUAN DI UNIT"
        End If

        Dim qtanggal As String = "Select top 1 TglPengajuan as hasil from trPengajuanBayarHD where NoPengajuan = '" & tNoPengajuan.Text & "'"
        cmd = New SqlCommand(qtanggal, kon)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            tTanggal.Text = rd!hasil
        End If
        rd.Close()

        Dim query As String = _
            "SELECT NoCtr, NoBTT, KdSupplier, NamaSupplier,  Kategori, TransferKe, Terjual, Transaksi, Valid, Tolak," & _
            "Promo, BiayaTrans, Pembulatan, Transfer, Bank, Norek, AtasNama , Retur, CashBack, LebihKurang," & _
            "Ongkir, FlagLunas, FlagSave, JnsPengajuan, Pengajuan, ROW_NUMBER() over(order by kdsupplier) as urut FROM trPengajuanBayarHD where NoPengajuan = '" & tNoPengajuan.Text & "' order by kdsupplier"
        dgList.FirstInit(query, {1, 1, 0.8, 1.3, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, _
                                0.8, 0.8, 0.8, 0.8, 1, 0.8, 1, 0.8, 0.8, 0.8, _
                                0.8}, {}, , {"FlagLunas", "FlagSave", "JnsPengajuan", "Pengajuan", "urut"}, , , False)
        dgList.RefreshData(False)

        sPengajuan.EditValue = dgList.GetSummaryColDB("Pengajuan")
        sValid.EditValue = dgList.GetSummaryColDB("Valid")

        Dim qlunas As String = "Select top 1 sum(Transfer) as hasil from trPengajuanBayarHD where NoPengajuan = '" & tNoPengajuan.Text & "' and FlagLunas = 1"
        cmd = New SqlCommand(qlunas, kon)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            sLunas.EditValue = rd!hasil
        End If
        rd.Close()

        Dim qsisa As String = "Select top 1 sum(Transfer) as hasil from trPengajuanBayarHD where NoPengajuan = '" & tNoPengajuan.Text & "' and FlagLunas = 0"
        cmd = New SqlCommand(qsisa, kon)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            sSisa.EditValue = rd!hasil
        End If
        rd.Close()


        If kategori.ToUpper = "REGULER" Then
            btnAddPerforma.Enabled = False
            btnSupplierAdd.Enabled = True
        Else
            btnAddPerforma.Enabled = True
            btnSupplierAdd.Enabled = False
        End If


        If valid = True Then
            btnSupplierAdd.Enabled = False
            btnAddPerforma.Enabled = False
        End If
    End Sub

    Private Sub dgList_Grid_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles dgList.Grid_CustomDrawCell
        'e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
        If dgList.GetRowCellValue(e.RowHandle, "FlagLunas") = True And tStatus.Text.ToUpper = "KIRIM PENGAJUAN KE PUSAT" Then
            e.Appearance.ForeColor = Color.Green
        ElseIf dgList.GetRowCellValue(e.RowHandle, "FlagLunas") = False And tStatus.Text.ToUpper = "KIRIM PENGAJUAN KE PUSAT" Then
            e.Appearance.ForeColor = Color.Red
        End If
    End Sub

    Private Sub btnSupplierAdd_Click(sender As Object, e As EventArgs) Handles btnSupplierAdd.Click
        Using xx As New frmPBYAdd(tNoPengajuan.Text, sPengajuan.EditValue, kategori, 99, "")
            xx.ShowDialog(Me)
            refreshdata()
        End Using
    End Sub

    Private Sub dgList_Grid_DoubleClick(sender As Object, e As EventArgs) Handles dgList.Grid_DoubleClick
        Dim ctr As String = ""
        Dim index As Integer = 0

        For a = 0 To dgList.gvMain.RowCount - 1
            ctr += dgList.GetRowCellValue(a, "NoCtr") & ","
        Next

        index = CInt(dgList.GetRowCellValue(dgList.FocusedRowHandle, "urut"))

        Using xx As New frmPBYDetail(ctr, index, tStatus.Text.ToUpper)
            xx.ShowDialog(Me)
            refreshdata()
        End Using
    End Sub

    Private Sub btnAddPerforma_Click(sender As Object, e As EventArgs) Handles btnAddPerforma.Click
        Using xx As New frmPBYaddPerforma(tNoPengajuan.Text)
            xx.ShowDialog(Me)
            refreshdata()
        End Using
    End Sub

    Private Sub btnCetakBtt_Click(sender As Object, e As EventArgs) Handles btnCetakBtt.Click
        Dim qu As String = "UPDATE a SET a.kdunit = '" & Mid(pubDatabase, 3, 20) & "' FROM dbo.trPengajuanBayarHd a where a.NoPengajuan = '" & tNoPengajuan.Text & "'"
        cmd = New SqlCommand(qu, kon)
        cmd.ExecuteNonQuery()

        Dim pQueRpt As String = "Select *, '' as Terbilang, convert(varchar, TglTrans, 103) as TglTrans2 from vwPengajuanBTTBayar where NoPengajuan = '" & tNoPengajuan.Text & "' order by NoCtr"
        Dim anu As New cMeDB
        anu.FillMe(pQueRpt)
        For a = 0 To anu.Rows.Count - 1
            anu.Rows(a)!Terbilang = Terbilang(anu.Rows(a)!Transfer)
        Next
        ShowReport(anu, "rptBTT")
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

    Private Sub dgList_Load(sender As Object, e As EventArgs) Handles dgList.Load

    End Sub
End Class


