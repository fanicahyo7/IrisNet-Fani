Imports meCore
Imports System.Data.SqlClient

Public Class frmSaldoPiutang

    Private Sub frmSaldoPiutang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        dTanggal.EditValue = Now
    End Sub

    Private Sub btnTampil_Click(sender As Object, e As EventArgs) Handles btnTampil.Click

        pubUserEntry = "FANI"

        Dim jenis As String = ""
        Dim instemp As String = ""
        Dim status As String = ""
        Dim nama As String = ""
        If Me.Text.ToUpper = "SALDO PIUTANG" Then
            jenis = "KartuPiutang"
            instemp = "select 'FANI' as UserID, a.KdCustomer, a.tanggal, Keterangan, isnull(a.debet - a.kredit,0) as Total , lunas = case Keterangan when 'PEMBULATAN' then isnull(a.debet - a.kredit,0)  else (select isnull(sum((aa.jumlah)),0) from trlptgdetail aa left join trlptgheader bb on aa.faktur = bb.faktur where aa.Fakturasli = a.faktur and bb.TglLunas  < '" & DTOC(dTanggal.EditValue, "", False) & "' ) end from vwKartuPiutang a where (keterangan <> 'PIUTANG AWAL' and keterangan <> 'PELUNASAN PIUTANG')"
            status = "''"
            nama = "Customer"
        ElseIf Me.Text.ToUpper = "SALDO HUTANG" Then
            jenis = "KartuHutang"
            instemp = "select * from dbo.tblSaldoHutang('" & pubUserEntry & "','" & DTOC(dTanggal.EditValue, "", False) & "') "
            status = "Konsi"
            nama = "Supplier"
        End If

        Dim cek As String = "select tanggal from tmp" & jenis & " where UserID = '" & pubUserEntry & "' and tanggal = '" & DTOC(dTanggal.EditValue, "", False) & "'"
        cmd = New SqlCommand(cek, kon)
        cmd.ExecuteNonQuery()

        Dim deltemp As String = "Delete from tmp" & jenis & " where UserID = '" & pubUserEntry & "'"
        cmd = New SqlCommand(deltemp, kon)
        cmd.ExecuteNonQuery()

        Dim instempa As String = _
            "Insert into tmp" & jenis & " " & instemp & ""
        cmd = New SqlCommand(instempa, kon)
        cmd.ExecuteNonQuery()


        Dim lap As String = _
            "WITH CTELAP AS(" & _
            "SELECT   Kode, " & status & " as Status, Nama as Nama" & nama & "," & _
            "Total = ( SELECT    ISNULL(SUM(debet - kredit), 0) " & _
                        "FROM vw" & jenis & " aa " & _
                        "WHERE aa.Kd" & nama & " = a.kode " & _
                        "AND aa.tanggal < DATEADD(day, 1, '" & DTOC(dTanggal.EditValue, "", False) & "')" & _
                        ")," & _
            "Deposit = ( SELECT  ISNULL(ABS(SUM(total - lunas)), 0) " & _
                        "FROM tmp" & jenis & " aa " & _
                        "WHERE aa.Kd" & nama & " = a.kode " & _
                        "AND UserID = '" & pubUserEntry & "' AND LEFT(Keterangan, 7) = 'DEPOSIT'" & _
                        ")," & _
            "[0-30] = ( SELECT  ISNULL(SUM(total - lunas), 0) " & _
                    "FROM    tmp" & jenis & " aa " & _
                    "WHERE aa.Kd" & nama & " = a.kode " & _
                    "AND UserID = '" & pubUserEntry & "' " & _
                    "AND LEFT(Keterangan, 7) <> 'DEPOSIT' " & _
                    "AND DATEADD(day, -30, '" & DTOC(dTanggal.EditValue, "", False) & "') <= aa.tanggal " & _
                    "AND aa.tanggal < DATEADD(day, 1, '" & DTOC(dTanggal.EditValue, "", False) & "') " & _
                    ")," & _
            "[31-60] = ( SELECT  ISNULL(SUM(total - lunas), 0) " & _
                    "FROM tmp" & jenis & " aa " & _
                    "WHERE aa.Kd" & nama & " = a.kode " & _
                    "AND UserID = '" & pubUserEntry & "' " & _
                    "AND LEFT(Keterangan, 7) <> 'DEPOSIT' " & _
                    "AND DATEADD(day, -60, '" & DTOC(dTanggal.EditValue, "", False) & "') <= aa.tanggal " & _
                    "AND aa.tanggal < DATEADD(day, -30, '" & DTOC(dTanggal.EditValue, "", False) & "') " & _
                    ")," & _
            "[61-90] = ( SELECT  ISNULL(SUM(total - lunas), 0) " & _
                    "FROM    tmp" & jenis & " aa " & _
                    "WHERE aa.Kd" & nama & " = a.kode " & _
                    "AND UserID = '" & pubUserEntry & "' " & _
                    "AND LEFT(Keterangan, 7) <> 'DEPOSIT' " & _
                    "AND aa.tanggal >= DATEADD(day, -90, '" & DTOC(dTanggal.EditValue, "", False) & "') " & _
                    "AND aa.tanggal < DATEADD(day, -60, '" & DTOC(dTanggal.EditValue, "", False) & "') " & _
                    ")," & _
            "[90-...] = ( SELECT  ISNULL(SUM(total - lunas), 0) " & _
                    "FROM    tmp" & jenis & " aa " & _
                    "WHERE aa.Kd" & nama & " = a.kode " & _
                    "AND UserID = '" & pubUserEntry & "' " & _
                    "AND LEFT(Keterangan, 7) <> 'DEPOSIT' " & _
                    "AND aa.tanggal < DATEADD(day, -90, '" & DTOC(dTanggal.EditValue, "", False) & "') " & _
                    "), 0 AS Selisih " & _
        "FROM vw" & nama & " a )" & _
        "select * from CTELAP where Total <> 0"

        dgList.FirstInit(lap, {0.7, 0.5, 1.5, 1, 0.8, 0.8, 0.8, 0.8, 0.8}, {"Total", "Deposit", "0-30", "31-60", "61-90", "90-..."}, , {"Selisih"})
        dgList.RefreshData(False)
    End Sub

    Private Sub dgList_Grid_DoubleClick(sender As Object, e As EventArgs) Handles dgList.Grid_DoubleClick
        If Me.Text.ToUpper = "SALDO PIUTANG" Then
            Using xx As New frmLapKartuPiutangCustomer
                xx.Text = "KARTU PIUTANG"
                xx.Tag = dgList.GetRowCellValue(dgList.FocusedRowHandle, "Kode")
                xx.ShowDialog(Me)
            End Using
        ElseIf Me.Text.ToUpper = "SALDO HUTANG" Then
            Using xx As New frmLapKartuPiutangCustomer
                xx.Text = "KARTU HUTANG"
                xx.Tag = dgList.GetRowCellValue(dgList.FocusedRowHandle, "Kode")
                xx.ShowDialog(Me)
            End Using
        End If
    End Sub
End Class