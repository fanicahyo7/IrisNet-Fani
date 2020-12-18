Imports meCore
Imports System.Data.SqlClient
Public Class frmPelunasanPiutang

    Private Sub frmPelunasanPiutang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadData()

    End Sub

    Sub loadData()
        SetTextReadOnly({tFaktur, sTotalHutang, sTotalBayar, sSisaHutang, _
                         sTunai, sTunaiGiro, sRetur, sDeposit, sBalance, sTunai})
        tFaktur.Text = GetNewFakturTogamasSQLServ(PubConnStr, "trLPtgHeader", FakturReset.Tahunan, "Faktur", pubKodeUnit & pubUserInit & "-PP", DTOC(Now), 5, "")
        dTglLunas.EditValue = Now
        Dim querycustomer As String = _
            "select Kode,Nama,Alamat from mstCustomer"
        cKdCustomer.FirstInit(PubConnStr, querycustomer, {tNama, tAlamat}, , , , , , {0.5, 1, 1})
    End Sub

    Private Sub cKdCustomer_EditValueChanged(sender As Object, e As EventArgs) Handles cKdCustomer.EditValueChanged
        Dim querypiutang As String = _
            "select cast(0 as bit) as PilihBayar,Faktur,FakturAsli,Tanggal,Total,Lunas,Sisa," & _
            "cast(0 as numeric(18)) as Debet,cast(0 as numeric(18)) as Kredit,cast(0 as numeric(18)) as TotalBayar,JthTmp,FktAcuan,KdCustomer,urutan,Keterangan,'TIDAK' as Centang " & _
            "from vwPiutang  where KdCustomer = '" & cKdCustomer.Text & "' and sisa <> 0  Order by substring(FktAcuan,7,20), urutan, Tanggal"

        dgList.FirstInit(querypiutang, {0.8, 1, 1, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 1, 1, 0.5, 0.8, 1}, , {"PilihBayar"}, {"FktAcuan", "KdCustomer", "urutan", "Keterangan", "JthTmp", "Centang"})
        dgList.RefreshData(False)
        bersih()
        sTotalHutang.EditValue = dgList.GetSummaryColDB("Sisa")
        sTotalBayar.EditValue = dgList.GetSummaryColDB("TotalBayar")
        'sTunai.EditValue = dgList.GetSummaryColDB("TotalBayar")
    End Sub

    Sub bersih()
        sPembulatan.EditValue = 0
        sRetur.EditValue = 0
        sDeposit.EditValue = 0
        sCekGiro.EditValue = 0
        sTunai.EditValue = 0
    End Sub

    Private Sub dgList_Grid_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles dgList.Grid_CellValueChanging
        If dgList.GetRowCellValue(e.RowHandle, "Centang").ToString.ToUpper = "TIDAK" Then
            dgList.SetRowCellValue(e.RowHandle, "Centang", "YA")

            If Strings.Mid(dgList.GetRowCellValue(e.RowHandle, "Faktur"), 8, 2).ToString.ToUpper = "FJ" Then
                dgList.SetRowCellValue(e.RowHandle, "Kredit", dgList.GetRowCellValue(e.RowHandle, "Sisa"))
            Else
                If Strings.Mid(dgList.GetRowCellValue(e.RowHandle, "Faktur"), 8, 2).ToString.ToUpper = "RJ" Then
                    sRetur.EditValue += Math.Abs(dgList.GetRowCellValue(e.RowHandle, "Sisa"))
                ElseIf Strings.Mid(dgList.GetRowCellValue(e.RowHandle, "Faktur"), 8, 2).ToString.ToUpper = "DP" Then
                    sDeposit.EditValue += Math.Abs(dgList.GetRowCellValue(e.RowHandle, "Sisa"))
                End If
                dgList.SetRowCellValue(e.RowHandle, "Debet", Math.Abs(dgList.GetRowCellValue(e.RowHandle, "Sisa")))
            End If

            dgList.SetRowCellValue(e.RowHandle, "TotalBayar", dgList.GetRowCellValue(e.RowHandle, "Sisa"))

        ElseIf dgList.GetRowCellValue(e.RowHandle, "Centang").ToString.ToUpper = "YA" Then
            dgList.SetRowCellValue(e.RowHandle, "Centang", "TIDAK")

            If Strings.Mid(dgList.GetRowCellValue(e.RowHandle, "Faktur"), 8, 2).ToString.ToUpper = "FJ" Then
                dgList.SetRowCellValue(e.RowHandle, "Kredit", "0")
            Else
                If Strings.Mid(dgList.GetRowCellValue(e.RowHandle, "Faktur"), 8, 2).ToString.ToUpper = "RJ" Then
                    sRetur.EditValue -= Math.Abs(dgList.GetRowCellValue(e.RowHandle, "Sisa"))
                ElseIf Strings.Mid(dgList.GetRowCellValue(e.RowHandle, "Faktur"), 8, 2).ToString.ToUpper = "DP" Then
                    sDeposit.EditValue -= Math.Abs(dgList.GetRowCellValue(e.RowHandle, "Sisa"))
                End If
                dgList.SetRowCellValue(e.RowHandle, "Debet", "0")
            End If

            dgList.SetRowCellValue(e.RowHandle, "TotalBayar", "0")

        End If

        sTotalBayar.EditValue = dgList.GetSummaryColDB("TotalBayar")
        'sTunai.EditValue = dgList.GetSummaryColDB("TotalBayar")
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Dim sa() As DataRow
        sa = dgList.DataSource.Select("PilihBayar = True")
        MsgBox(sa.Length)
    End Sub

    Sub perhitungan()
        sSisaHutang.EditValue = sTotalHutang.EditValue - sTotalBayar.EditValue

        Dim tunaigiro As Double = sTunai.EditValue + sCekGiro.EditValue
        Dim jmlreturdeposittunaigiro As Double = tunaigiro + sRetur.EditValue + sDeposit.EditValue
        'Dim balance As Double = sTotalBayar.EditValue - jmlreturdeposittunaigiro
        sBalance.EditValue = jmlreturdeposittunaigiro
    End Sub

    Private Sub sTotalHutang_EditValueChanged(sender As Object, e As EventArgs) Handles sTotalHutang.EditValueChanged
        perhitungan()
    End Sub

    Private Sub sTotalBayar_EditValueChanged(sender As Object, e As EventArgs) Handles sTotalBayar.EditValueChanged
        perhitungan()
    End Sub

    Private Sub sTunai_EditValueChanged(sender As Object, e As EventArgs) Handles sTunai.EditValueChanged
        perhitungan()
    End Sub

    Private Sub sCekGiro_EditValueChanged(sender As Object, e As EventArgs) Handles sCekGiro.EditValueChanged
        perhitungan()
    End Sub

    Private Sub sPembulatan_EditValueChanged(sender As Object, e As EventArgs) Handles sPembulatan.EditValueChanged
        perhitungan()
    End Sub
End Class