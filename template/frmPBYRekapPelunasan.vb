﻿Imports System.Data.SqlClient
Imports meCore
Public Class frmPBYRekapPelunasan
    Dim nopengajuan As String = ""
    Dim status As String = ""
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(nopengajuan As String, status As String)
        InitializeComponent()
        Me.nopengajuan = nopengajuan
        Me.status = status
    End Sub
    Private Sub frmPBYRekapPelunasan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            "Ongkir, FlagLunas, FlagSave, JnsPengajuan, Pengajuan FROM trPengajuanBayarHD where NoPengajuan = '" & tNoPengajuan.Text & "' order by kdsupplier"
        dgList.FirstInit(query, {1, 1, 0.8, 1.3, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, _
                                0.8, 0.8, 0.8, 0.8, 1, 0.8, 1, 0.8, 0.8, 0.8, _
                                0.8}, {}, , {"FlagLunas", "FlagSave", "JnsPengajuan", "Pengajuan"}, , , False)
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

    End Sub

    Private Sub dgList_Grid_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles dgList.Grid_CustomDrawCell
        'If dgList.GetRowCellValue(e.RowHandle, "FlagLunas") = True Then
        '    e.Appearance.ForeColor = Color.Red
        'ElseIf dgList.GetRowCellValue(e.RowHandle, "FlagLunas") = False Then
        '    e.Appearance.ForeColor = Color.Green
        'End If
    End Sub
End Class

'Select top 1 FlagSave as hasil from trPengajuanBayarHD where NoPengajuan = '601PBY-200910' 

