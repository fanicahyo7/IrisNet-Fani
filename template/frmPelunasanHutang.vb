Imports meCore
Imports System.Data.SqlClient
Public Class frmPelunasanHutang

    Private Sub frmPelunasanHutang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        loadData()
    End Sub

    Sub loadData()
        SetTextReadOnly({tFaktur, sTotalHutang, sTotalBayar, sSisaHutang, sTotalTagihan, _
                         sTunaiGiro, sRetur, sDeposit, sBalance, sCekGiro, tKonsi})
        tFaktur.Text = GetNewFakturTogamasSQLServ(PubConnStr, "trLHtgHeader", FakturReset.Tahunan, "Faktur", pubKodeUnit & pubUserInit & "-PP", DTOC(Now), 5, "")

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
            "select Kode,Nama,Alamat,case when Konsinyasi='1' then 'Konsinyasi' else 'Non-Konsi' end as Konsiyasi from mstSupplier"
        cKdSupplier.FirstInit(PubConnStr, querycustomer, {tNama, tAlamat, tKonsi}, , , , , , {0.5, 1, 1, 0.5})
    End Sub

    Private Sub cKdSupplier_EditValueChanged(sender As Object, e As EventArgs) Handles cKdSupplier.EditValueChanged
        Dim querypiutang As String = _
            "select cast(0 as bit) as PilihBayar,Faktur,FakturAsli,Tanggal,Total,Lunas,Sisa," & _
            "cast(0 as numeric(18)) as Debet,cast(0 as numeric(18)) as Kredit,cast(0 as numeric(18)) as TotalBayar,JthTmp,FktAcuan,KdSupplier,urutan,Keterangan,'TIDAK' as Centang " & _
            "from vwHutang  where KdSupplier = '" & cKdSupplier.Text & "' and sisa <> 0  Order by substring(Faktur,10,6), urutan"

        dgList.FirstInit(querypiutang, {0.8, 1, 1, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 1, 1, 0.5, 0.8, 1}, , {"PilihBayar"}, {"FktAcuan", "KdSupplier", "urutan", "Keterangan", "JthTmp", "Centang"})
        dgList.RefreshData(False)
        bersih()
        sTotalHutang.EditValue = dgList.GetSummaryColDB("Sisa")
        sTotalBayar.EditValue = dgList.GetSummaryColDB("TotalBayar")

        If tKonsi.Text.ToUpper = "KONSINYASI" Then
            LayoutControlItem26.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        ElseIf tKonsi.Text.ToUpper = "NON-KONSI" Then
            LayoutControlItem26.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        End If
        rUrutan.SelectedIndex = 1
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
        sTotalTagihan.EditValue = dgList.GetSummaryColDB("Debet")
    End Sub

    Private Sub dgList_Grid_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles dgList.Grid_CellValueChanging
        Dim k1 As String = ""
        Dim k2 As String = ""
        Dim k3 As String = ""

        If tKonsi.Text.ToUpper = "KONSINYASI" Then
            k1 = "TK"
            k2 = "RK"
            k3 = "UM"
        ElseIf tKonsi.Text.ToUpper = "NON-KONSI" Then
            k1 = "FB"
            k2 = "RB"
            k3 = "DP"
        End If
        If dgList.GetRowCellValue(e.RowHandle, "Centang").ToString.ToUpper = "TIDAK" Then
            dgList.SetRowCellValue(e.RowHandle, "Centang", "YA")

            If Strings.Mid(dgList.GetRowCellValue(e.RowHandle, "Faktur"), 8, 2).ToString.ToUpper = k1.ToUpper Then
                dgList.SetRowCellValue(e.RowHandle, "Debet", dgList.GetRowCellValue(e.RowHandle, "Sisa"))
            Else
                If Strings.Mid(dgList.GetRowCellValue(e.RowHandle, "Faktur"), 8, 2).ToString.ToUpper = k2.ToUpper Then
                    sRetur.EditValue += Math.Abs(dgList.GetRowCellValue(e.RowHandle, "Sisa"))
                ElseIf Strings.Mid(dgList.GetRowCellValue(e.RowHandle, "Faktur"), 8, 2).ToString.ToUpper = k3.ToUpper Then
                    sDeposit.EditValue += Math.Abs(dgList.GetRowCellValue(e.RowHandle, "Sisa"))
                End If
                dgList.SetRowCellValue(e.RowHandle, "Kredit", Math.Abs(dgList.GetRowCellValue(e.RowHandle, "Sisa")))
            End If

            dgList.SetRowCellValue(e.RowHandle, "TotalBayar", dgList.GetRowCellValue(e.RowHandle, "Sisa"))

        ElseIf dgList.GetRowCellValue(e.RowHandle, "Centang").ToString.ToUpper = "YA" Then
            dgList.SetRowCellValue(e.RowHandle, "Centang", "TIDAK")

            If Strings.Mid(dgList.GetRowCellValue(e.RowHandle, "Faktur"), 8, 2).ToString.ToUpper = k1.ToUpper Then
                dgList.SetRowCellValue(e.RowHandle, "Debet", "0")
            Else
                If Strings.Mid(dgList.GetRowCellValue(e.RowHandle, "Faktur"), 8, 2).ToString.ToUpper = k2.ToUpper Then
                    sRetur.EditValue -= Math.Abs(dgList.GetRowCellValue(e.RowHandle, "Sisa"))
                ElseIf Strings.Mid(dgList.GetRowCellValue(e.RowHandle, "Faktur"), 8, 2).ToString.ToUpper = k3.ToUpper Then
                    sDeposit.EditValue -= Math.Abs(dgList.GetRowCellValue(e.RowHandle, "Sisa"))
                End If
                dgList.SetRowCellValue(e.RowHandle, "Kredit", "0")
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
                q += "Insert Into trLHtgHeader (Status,Faktur,KdSupplier,Tanggal,TglLunas," & _
                    "NoBukti,Tunai,CekGiro,Pembulatan,UserEntry,DateTimeEntry) Values (" & _
                    "'1','" & tFaktur.Text & "','" & cKdSupplier.Text & "','" & DTOC(Now, "-", False) & "','" & DTOC(dTglLunas.EditValue, "-", False) & "'," & _
                    "'" & tNoBukti.Text & "','" & sTunai.EditValue & "','" & sCekGiro.EditValue & "','" & sPembulatan.EditValue & "','" & pubUserEntry & "','" & DTOC(Now, "-", True) & "'); " & _
                    "Update trLPtgDetail Set Status = '0' Where Faktur = '" & tFaktur.Text & "' ;"

                Dim sa() As DataRow
                sa = dgList.DataSource.Select("PilihBayar = True")
                For a = 0 To sa.Length - 1
                    q += "Insert Into trLHtgDetail (Status,faktur,FakturAsli,Jumlah,Urutan,FakturHit) Values (" & _
                        "'1','" & tFaktur.Text & "', '" & sa(a).Item("Faktur") & "','" & sa(a).Item("TotalBayar") & "','" & sa(a).Item("Urutan") & "',''); "
                Next

                q += "update trLHtgDetail set Fire = 1 , Faktur= Faktur, Jumlah = Jumlah where Faktur = '" & tFaktur.Text & "' ;"

                If cCekGiro.Checked = True Then
                    q += "Insert Into trCekOut (Status,faktur,KdSupplier,NoCekBG,Jumlah,TglJthTmp,UserEntry,DateTimeEntry) Values (" & _
                        "'1','" & tFaktur.Text & "','" & cKdSupplier.Text & "','" & tNoTglCair.Text & "','" & sCekGiro.EditValue & "','" & DTOC(dJthTempo.EditValue, "-", False) & "','" & pubUserEntry & "','" & DTOC(Now, "-", True) & "') ;"
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

    Private Sub rUrutan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rUrutan.SelectedIndexChanged
        Dim orderby As String = ""
        If rUrutan.SelectedIndex = 0 Then
            orderby = "Sisa desc"
        ElseIf rUrutan.SelectedIndex = 1 Then
            orderby = "substring(Faktur,10,6)"
        End If

        Dim querypiutang As String = _
            "select cast(0 as bit) as PilihBayar,Faktur,FakturAsli,Tanggal,Total,Lunas,Sisa," & _
            "cast(0 as numeric(18)) as Debet,cast(0 as numeric(18)) as Kredit,cast(0 as numeric(18)) as TotalBayar,JthTmp,FktAcuan,KdSupplier,urutan,Keterangan,'TIDAK' as Centang " & _
            "from vwHutang  where KdSupplier = '" & cKdSupplier.Text & "' and sisa <> 0  Order by " & orderby & ", urutan"

        dgList.FirstInit(querypiutang, {0.8, 1, 1, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 1, 1, 0.5, 0.8, 1}, , {"PilihBayar"}, {"FktAcuan", "KdSupplier", "urutan", "Keterangan", "JthTmp", "Centang"})
        dgList.RefreshData(False)
        bersih()
        sTotalHutang.EditValue = dgList.GetSummaryColDB("Sisa")
        sTotalBayar.EditValue = dgList.GetSummaryColDB("TotalBayar")
    End Sub
End Class