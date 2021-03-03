Imports meCore
Imports System.Data.SqlClient
Public Class frmLapPBY

    Private Sub frmLapPBY_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        cKdSupplier.FirstInit(PubConnStr, "select Kode,Nama,Alamat from mstSupplier", {tNama})

        dDate2.EditValue = Now
        dDate1.EditValue = DateAdd(DateInterval.Day, -14, Now)
        cTotalDetail.SelectedIndex = 0
    End Sub

    Private Sub btnTampilData_Click(sender As Object, e As EventArgs) Handles btnTampilData.Click
        ambildata()
    End Sub

    Sub ambildata()
        Dim sup As String = ""
        If Not cKdSupplier.Text = "" Then
            sup = "and KdSupplier = '" & cKdSupplier.Text & "'"
        End If

        Dim query As String = ""
        If cTotalDetail.SelectedIndex = 0 Then
            query = "SELECT NoBTT,NoPengajuan,TglPengajuan,KdSupplier,NamaSupplier,terjual-retur AS Hutang,Retur," & _
                "Tolak, transaksi-retur AS Transaksi,BiayaTrans,Promo,Pembulatan," & _
                "((terjual-retur)+(transaksi-retur)+retur-tolak)+(BiayaTrans+Promo+Pembulatan) AS Pengajuan,TRANSFER," & _
                "(((terjual-retur)+(transaksi-retur)+retur-tolak)+(BiayaTrans+Promo+Pembulatan))-transfer as Sisa,ISNULL(TglTrans,'') AS TglTransfer,STATUS FROM vwPengajuanFakturStatusHD  " & _
                "Where '" & DTOC(dDate1.EditValue, "", False) & "' <= TglPengajuan and TglPengajuan < '" & DTOC(DateAdd(DateInterval.Day, 1, dDate2.EditValue)) & "' " & sup & " order by TglPengajuan"
            dgList.FirstInit(query, {1, 1, 1, 0.8, 1.5, _
                             0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 1.2}, {"Hutang", "Retur", "Tolak", "Transaksi", "BiayaTrans", "Promo", "Pembulatan", "Pengajuan", "TRANSFER", "Sisa"}, , , , , False)
        Else
            query = "SELECT NoBTT ,NoPengajuan ,TglPengajuan ,KdSupplier ,NamaSupplier ,Faktur ,FakturAsli ," & _
                "Terjual AS Hutang ,Retur,CashBack ,Ongkir ,Lebihkurang ,Lainlain , Tolak , Pengajuan, TglTransfer,STATUS FROM vwPengajuanBayarNTolakDt " & _
                "Where '" & DTOC(dDate1.EditValue, "", False) & "' <= TglPengajuan and TglPengajuan < '" & DTOC(DateAdd(DateInterval.Day, 1, dDate2.EditValue)) & "' " & sup & "  order by TglPengajuan"
            dgList.FirstInit(query, {1, 1, 1, 0.8, 1.5, 1.4, 1.4, _
                                     0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 1.2}, {"Hutang", "Retur", "CashBack", "Ongkir", "Lebihkurang", "Lainlain", "Tolak", "Pengajuan"}, , , False)
        End If
        dgList.RefreshData(False)
    End Sub

    Private Sub cTotalDetail_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cTotalDetail.SelectedIndexChanged
        ambildata()
    End Sub

    Private Sub dgList_Grid_DoubleClick(sender As Object, e As EventArgs) Handles dgList.Grid_DoubleClick
        If cTotalDetail.SelectedIndex = 0 Then
            Dim query As String = "select noctr,nopengajuan from trPengajuanBayarHd where nobtt='" & dgList.GetRowCellValue(dgList.FocusedRowHandle, "NoBTT") & "'"
            cmd = New SqlCommand(query, kon)
            rd = cmd.ExecuteReader
            rd.Read()
            Dim noctr As String = ""
            If rd.HasRows Then
                noctr = rd!noctr & ","
            End If
            rd.Close()

            Using xx As New frmPBYDetail(noctr, 1, "KIRIM PENGAJUAN KE PUSAT")
                xx.ShowDialog(Me)
            End Using
        End If
    End Sub
End Class


'SELECT *,
'convert(varchar, TglPengajuan, 103) as TglPengajuanConvert,
'convert(varchar, TglFaktur, 103) as TglFakturConvert
'FROM vwpengajuanBayarDtCetak
'WHERE   NoPengajuan = '621PBY-210217' 
'order by nopengajuan,nobtt,TglFaktur,faktur