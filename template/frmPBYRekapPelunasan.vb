Imports System.Data.SqlClient
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
        SetTextReadOnly({tNoPengajuan, tTanggal, tStatus, sSisa, sValid, sLunas, sPengajuan})

        tNoPengajuan.Text = nopengajuan

        If status.ToUpper = "KIRIM PUSAT" Then
            tStatus.Text = "KIRIM PENGAJUAN KE PUSAT"
        ElseIf status.ToUpper = "PENGAJUAN UNIT" Then
            tStatus.Text = "PENGAJUAN DI UNIT"
        End If

        Dim query As String = _
            "SELECT NoCtr, NoBTT, KdSupplier, NamaSupplier,  Kategori, TransferKe, Terjual, Transaksi, Valid, Tolak," & _
            "Promo, BiayaTrans, Pembulatan, Transfer, Bank, Norek, AtasNama , Retur, CashBack, LebihKurang," & _
            "Ongkir, FlagLunas, FlagSave, JnsPengajuan FROM trPengajuanBayarHD where NoPengajuan = '" & tNoPengajuan.Text & "' order by kdsupplier"
        dgList.FirstInit(query, {0.8, 0.8, 0.8, 1, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8 _
                                }, {}, )
        dgList.RefreshData(False)


    End Sub
End Class

'SELECT NoCtr, NoBTT, KdSupplier, NamaSupplier,  Kategori, TransferKe, Terjual, Transaksi, Valid, Tolak, Promo, BiayaTrans, Pembulatan, Transfer, Bank, Norek, AtasNama , Retur, CashBack, LebihKurang, Ongkir, FlagLunas, FlagSave, JnsPengajuan FROM trPengajuanBayarHD where NoPengajuan = '601PBY-200910' order by kdsupplier 

'Select top 1 TglPengajuan as hasil from trPengajuanBayarHD where NoPengajuan = '601PBY-200910' 

'Select top 1 FlagSave as hasil from trPengajuanBayarHD where NoPengajuan = '601PBY-200910' 

