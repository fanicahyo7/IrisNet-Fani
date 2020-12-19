Imports meCore
Imports System.Data.SqlClient
Public Class frmPelunasanPiutang

    Private Sub frmPelunasanPiutang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        loadData()
    End Sub

    Sub loadData()
        SetTextReadOnly({tFaktur, sTotalHutang, sTotalBayar, sSisaHutang, sTotalTagihan, _
                         sTunaiGiro, sRetur, sDeposit, sBalance, sCekGiro})
        tFaktur.Text = GetNewFakturTogamasSQLServ(PubConnStr, "trLPtgHeader", FakturReset.Tahunan, "Faktur", pubKodeUnit & pubUserInit & "-PP", DTOC(Now), 5, "")

        dTglLunas.EditValue = Now
        cCekGiro.Checked = False
        sCekGiro.EditValue = 0
        tNoTglCair.Enabled = False
        dJthTempo.Enabled = False
        sJmlCekbg.Enabled = False
        tNoTglCair.Text = ""
        dJthTempo.EditValue = Now
        sJmlCekbg.EditValue = 0

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
    End Sub

    Sub bersih()
        sPembulatan.EditValue = 0
        sRetur.EditValue = 0
        sDeposit.EditValue = 0
        sCekGiro.EditValue = 0
        sTunai.EditValue = 0
    End Sub

    Private Sub dgList_Grid_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles dgList.Grid_CellValueChanged
        sTotalBayar.EditValue = dgList.GetSummaryColDB("TotalBayar")
        sTotalTagihan.EditValue = dgList.GetSummaryColDB("Kredit")
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
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        ClearValue(Me)
        loadData()
    End Sub

    Sub perhitungan()
        sSisaHutang.EditValue = sTotalHutang.EditValue - sTotalBayar.EditValue

        Dim tunaigiro As Double = sTunai.EditValue + sCekGiro.EditValue
        Dim jmlreturdeposittunaigiro As Double = tunaigiro + Math.Abs(sRetur.EditValue) + Math.Abs(sDeposit.EditValue)
        Dim balance As Double = sTotalTagihan.EditValue - jmlreturdeposittunaigiro + sPembulatan.EditValue
        sBalance.EditValue = balance
    End Sub

    Private Sub sTotalHutang_EditValueChanged(sender As Object, e As EventArgs) Handles sTotalHutang.EditValueChanged
        perhitungan()
    End Sub

    Private Sub sTotalBayar_EditValueChanged(sender As Object, e As EventArgs) Handles sTotalBayar.EditValueChanged
        perhitungan()
    End Sub

    Private Sub sTunai_EditValueChanged(sender As Object, e As EventArgs) Handles sTunai.EditValueChanged
        sTunaiGiro.EditValue = sTunai.EditValue + sCekGiro.EditValue
        perhitungan()
    End Sub

    Private Sub sCekGiro_EditValueChanged(sender As Object, e As EventArgs) Handles sCekGiro.EditValueChanged
        sTunaiGiro.EditValue = sTunai.EditValue + sCekGiro.EditValue
        perhitungan()
    End Sub

    Private Sub sPembulatan_EditValueChanged(sender As Object, e As EventArgs) Handles sPembulatan.EditValueChanged
        perhitungan()
    End Sub

    Private Sub cCekGiro_CheckedChanged(sender As Object, e As EventArgs) Handles cCekGiro.CheckedChanged
        If cCekGiro.Checked = False Then
            sCekGiro.EditValue = 0
            tNoTglCair.Enabled = False
            dJthTempo.Enabled = False
            sJmlCekbg.Enabled = False
            tNoTglCair.Text = ""
            dJthTempo.EditValue = Now
            sJmlCekbg.EditValue = 0
        Else
            sCekGiro.EditValue = sJmlCekbg.EditValue
            tNoTglCair.Enabled = True
            dJthTempo.Enabled = True
            sJmlCekbg.Enabled = True
        End If
    End Sub

    Private Sub sJmlCekbg_EditValueChanged(sender As Object, e As EventArgs) Handles sJmlCekbg.EditValueChanged
        sCekGiro.EditValue = sJmlCekbg.EditValue
        perhitungan()
    End Sub

    Private Sub btnBayar_Click(sender As Object, e As EventArgs) Handles btnBayar.Click
        If Not sBalance.EditValue = 0 Then
            MsgBox("Pembayaran Tidak Mencukupi!", vbCritical + vbOKOnly, "Peringatan")
        ElseIf tNoBukti.Text = "" Then
            MsgBox("Data Belum Lengkap!", vbCritical + vbOKOnly, "Peringatan")
        Else
            Try
                Dim q As String = "begin try begin transaction "
                q += "Insert Into trLPtgHeader (Status,Faktur,KdCustomer,Tanggal,TglLunas," & _
                    "NoBukti,Tunai,CekGiro,Pembulatan,UserEntry,DateTimeEntry) Values (" & _
                    "'1','" & tFaktur.Text & "','" & cKdCustomer.Text & "','" & DTOC(Now, "-", False) & "','" & DTOC(dTglLunas.EditValue, "-", False) & "'," & _
                    "'" & tNoBukti.Text & "','" & sTunai.EditValue & "','" & sCekGiro.EditValue & "','" & sPembulatan.EditValue & "','" & pubUserEntry & "','" & DTOC(Now, "-", True) & "'); " & _
                    "Update trLPtgDetail Set Status = '0' Where Faktur = '" & tFaktur.Text & "' ;"

                Dim sa() As DataRow
                sa = dgList.DataSource.Select("PilihBayar = True")
                For a = 0 To sa.Length - 1
                    q += "Insert Into trLPtgDetail (Status,faktur,FakturAsli,Jumlah,Urutan) Values (" & _
                        "'1','" & tFaktur.Text & "', '" & sa(a).Item("Faktur") & "','" & sa(a).Item("TotalBayar") & "','" & sa(a).Item("Urutan") & "'); "
                Next

                q += "update trLPtgDetail set Fire = 1 , Faktur= Faktur, Jumlah = Jumlah where Faktur = '" & tFaktur.Text & "' ;"

                If cCekGiro.Checked = True Then
                    q += "Insert Into trCekin (Status,faktur,KdCustomer,NoCekBG,Jumlah,TglJthTmp,UserEntry,DateTimeEntry) Values (" & _
                        "'1','" & tFaktur.Text & "','" & cKdCustomer.Text & "','" & tNoTglCair.Text & "','" & sCekGiro.EditValue & "','" & DTOC(dJthTempo.EditValue, "-", False) & "','" & pubUserEntry & "','" & DTOC(Now, "-", True) & "') ;"
                End If

                q += "commit select 'sukses' as statusx end try begin catch rollback select 'gagal : ' + ERROR_MESSAGE() as statusx end catch"

                Dim db As New DataTable
                da = New SqlDataAdapter(q, kon)
                da.Fill(db)

                If db.Rows.Count > 0 Then
                    If (db.Rows(0)!statusx).ToString.Contains("gagal") Then
                        Pesan({"Pembayaran Gagal", "", db.Rows(0)!statusx})
                    Else
                        MsgBox("Pembayaran Berhasil", vbInformation + vbOKOnly, "Informasi")
                        btnReset.PerformClick()
                    End If
                End If

            Catch ex As Exception
                MsgBox(ex.Message, vbOKOnly + vbCritical, "Peringatan")
            End Try
        End If
    End Sub
End Class