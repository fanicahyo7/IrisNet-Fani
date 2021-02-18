Imports meCore
Imports System.Data.SqlClient


Public Class frmPBYList

    'Const EM_SETPASSWORDCHAR = &HCC
    'Const NV_INPUTBOX As Long = &H5000&
    'Private Declare Function SetTimer& Lib "user32" (ByVal Hwnd&, ByVal nIDEvent&, ByVal uElapse&, ByVal lpTimerFunc&)
    Private Sub frmPBYList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim query As String = "SELECT CONVERT(VARCHAR(6),TglPengajuan,112) as Bulan, ABS(SUM(Pengajuan)) as Total FROM dbo.trPengajuanBayarHd GROUP BY CONVERT(VARCHAR(6),TglPengajuan,112) order by 1 desc"
        dgList.FirstInit(query, {0.7, 1})
        dgList.RefreshData(False)
    End Sub

    Private Sub dgList_Grid_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles dgList.Grid_CustomDrawCell
       
    End Sub

    Private Sub dgList_Grid_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles dgList.Grid_FocusedRowChanged
        ambildetail()
    End Sub

    Private Sub dgList_Grid_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles dgList.Grid_SelectionChanged
        'ambildetail()
    End Sub
    Sub ambildetail()
        Dim query As String = _
            "SELECT  NoPengajuan, MingguKe as M, JnsPengajuan, Kategori, Status = case when FlagSave = 1 then 'KIRIM PUSAT' else 'PENGAJUAN UNIT' END," & _
            "TglPengajuan as Tanggal, ABS(SUM(Pengajuan)) AS Total, sum(valid)AS Valid, sum(tolak) AS Tolak, Sum(BiayaTrans + Pembulatan) as Biaya, sum(transfer) AS [Transfer]," & _
            "sum(lunas) as Lunas, sum(sisa) as Sisa,FlagValid2,FlagValid3 From vwPengajuanBayarHd WHERE CONVERT(VARCHAR(6), TglPengajuan, 112) = '" & dgList.GetRowCellValue(dgList.FocusedRowHandle, "Bulan") & "' GROUP BY NoPengajuan, MingguKe, TglPengajuan, JnsPengajuan, Kategori, FlagSave, FlagValid2, FlagValid3"
        dgListDetail.FirstInit(query, {0.9, 0.3, 0.6, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8}, , , {"FlagValid2", "FlagValid3", "isValid"})
        dgListDetail.RefreshData(False)

        sPengajuan.EditValue = dgListDetail.GetSummaryColDB("Total")
        sTotalValid.EditValue = dgListDetail.GetSummaryColDB("Valid")
        sTotalLunas.EditValue = dgListDetail.GetSummaryColDB("Lunas")
        sTotalSisa.EditValue = dgListDetail.GetSummaryColDB("Sisa")
    End Sub

    Private Sub dgListDetail_Grid_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles dgListDetail.Grid_CustomDrawCell
        If dgListDetail.GetRowCellValue(e.RowHandle, "FlagValid2") = "1" And dgListDetail.GetRowCellValue(e.RowHandle, "FlagValid3") = "1" Then
            e.Appearance.BackColor = Color.LightGray
        End If

        If e.Column.FieldName.ToUpper = "KATEGORI" Then
            If dgListDetail.GetRowCellValue(e.RowHandle, "Kategori").ToString.ToUpper = "ISIDENTIL" Then
                e.Appearance.BackColor = Color.Red
                e.Appearance.ForeColor = Color.White
            End If
        End If

        Dim ttl As Double
        ttl = CDbl(dgListDetail.GetRowCellValue(e.RowHandle, "Lunas")) + CDbl(dgListDetail.GetRowCellValue(e.RowHandle, "Tolak")) + CDbl(Math.Abs(dgListDetail.GetRowCellValue(e.RowHandle, "Biaya"))) + CDbl(Math.Abs(dgListDetail.GetRowCellValue(e.RowHandle, "Sisa")))

        If CDbl(dgListDetail.GetRowCellValue(e.RowHandle, "Total")) = ttl Then
            If e.Column.FieldName.ToUpper = "TOTAL" Or e.Column.FieldName.ToUpper = "VALID" Then
                e.Appearance.BackColor = Color.LightGreen
            End If
        Else
            If e.Column.FieldName.ToUpper = "TOTAL" Or e.Column.FieldName.ToUpper = "VALID" Then
                e.Appearance.BackColor = Color.LightPink
            End If
        End If
    End Sub

    Private Sub dgListDetail_Grid_DoubleClick(sender As Object, e As EventArgs) Handles dgListDetail.Grid_DoubleClick
        'Dim valid As Boolean = False
        'If dgListDetail.GetRowCellValue(dgListDetail.FocusedRowHandle, "FlagValid2") = "1" And dgListDetail.GetRowCellValue(dgListDetail.FocusedRowHandle, "FlagValid3") = "1" Then
        '    valid = True
        'End If

        Dim valid As Boolean = dgListDetail.GetRowCellValue(dgListDetail.FocusedRowHandle, "FlagValid2") = "1" And dgListDetail.GetRowCellValue(dgListDetail.FocusedRowHandle, "FlagValid3") = "1"

        Using xx As New frmPBYRekapPelunasan(dgListDetail.GetRowCellValue(dgListDetail.FocusedRowHandle, "NoPengajuan"), dgListDetail.GetRowCellValue(dgListDetail.FocusedRowHandle, "Status"), valid, dgListDetail.GetRowCellValue(dgListDetail.FocusedRowHandle, "Kategori"))
            xx.ShowDialog(Me)
            ambildetail()
        End Using
    End Sub

    Private Sub dgListDetail_Grid_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles dgListDetail.Grid_SelectionChanged
        If dgListDetail.GetRowCellValue(dgListDetail.FocusedRowHandle, "FlagValid2") = "1" And dgListDetail.GetRowCellValue(dgListDetail.FocusedRowHandle, "FlagValid3") = "1" Then
            btnValidasi.Enabled = False
        Else
            btnValidasi.Enabled = True
        End If
    End Sub

    Private Sub btnPBYBaru_Click(sender As Object, e As EventArgs) Handles btnPBYBaru.Click
        Using xx As New frmPBYAdd
            xx.ShowDialog(Me)
            ambildetail()
        End Using
    End Sub

    Private Sub btnPerforma_Click(sender As Object, e As EventArgs) Handles btnPerforma.Click
        Using xx As New frmPBYaddPerforma
            xx.ShowDialog(Me)
            ambildetail()
        End Using
    End Sub

    Private Sub btnValidasi_Click(sender As Object, e As EventArgs) Handles btnValidasi.Click
        'Dim password = InputBox("Enter Password", "Konfirmasi", "*")
        'Dim n As Long
        'Dim strPws As String
        'strPws = InputBox("Enter Password")

        'If PubUserLevel = 0 Then
        'n = SetTimer(1, NV_INPUTBOX, 10, 1)
        'strPws = InputBox("Enter Password")

        '    If CekLogin(pubUserID, strPws) Then

        '        'cek rekening
        '        dbTmp = objData.SQL(GetDsn, "Select count(*) as no from trPengajuanBayarHD where noPengajuan ='" & ValidNull(dlPengajuanDt.Columns("NoPengajuan").Value) & "' and (isnull(Norek,'')='' or isnull(Bank,'')='' or isnull(AtasNAma,'')='')")
        '        If dbTmp.RecordCount > 0 Then
        '            If ValidNull(dbTmp!no) > 0 Then
        '                MsgBox("BANK,NOMOR REKENING DAN NAMA PEMILIK REKENING ADA YANG KOSONG, MOHON DIPERIKSA KEMBALI. VALIDASI GAGAL", vbInformation, "INFORMASI")
        '                Exit Sub
        '            End If
        '        End If

        '        If Tanya(Array("KIRIM PENGAJUAN KE PUSAT ?", "PENGAJUAN TIDAK BISA DI UBAH LAGI")) Then
        '        objData.Edit GetDsn, "trPengajuanBayarHD", "NoPengajuan = '" & ValidNull(dlPengajuanDt.Columns("NoPengajuan").Value) & "'", Array("FlagSave", "TglPengajuan"), Array(1, DTOC(Date, "-"))
        '            objData.SQL(GetDsn, "exec spGenBTT")
        '            dlPengajuan_RowChange()
        '        End If
        '    End If

        'Else
        '    MsgBox("VALIDASI PENGAJUAN HANYA UNTUK LEVEL KEPALA TOKO", vbInformation, "INFORMASI")
        'End If
    End Sub
End Class