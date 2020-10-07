Imports meCore
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors.Repository

Public Class frmValidKEPBY
    Dim WithEvents check As RepositoryItemCheckEdit = New RepositoryItemCheckEdit()
    Private Sub btnAmbilData_Click(sender As Object, e As EventArgs) Handles btnAmbilData.Click
        dgList.gvMain.LoadingPanelVisible = True
        Dim dtlist As New cMeDB
        Dim dtunit As New cMeDB

        dtlist.Columns.Add("Valid", GetType(Boolean))
        dtlist.Columns.Add("Constr", GetType(String))
        dtlist.Columns.Add("Kode", GetType(String))
        dtlist.Columns.Add("Unit", GetType(String))
        dtlist.Columns.Add("Faktur", GetType(String))
        dtlist.Columns.Add("TglKirim", GetType(Date))
        dtlist.Columns.Add("JumlahBarang", GetType(String))
        dtlist.Columns.Add("BeratBarang", GetType(Double))
        dtlist.Columns.Add("TotalBiaya", GetType(Integer))
        dtlist.Columns.Add("UserValid", GetType(String))
        dtlist.Columns.Add("DateTimeValid", GetType(Date))
        dtlist.Columns.Add("UserUpdateValid", GetType(String))
        dtlist.Columns.Add("DateTimeUpdateValid", GetType(Date))
        dtlist.Columns.Add("CekValid", GetType(String))

        Dim konstr As String = _
            "Data Source=10.10.2.4;Initial Catalog=IrisCorp;Persist Security Info=True;User ID=sa;Password=pancetgogogo;Connection Timeout=0"

        'Dim konstr As String = PubConnStr

        Dim connnn As SqlConnection
        connnn = New SqlConnection(konstr)
        If connnn.State = ConnectionState.Closed Then
            connnn.Open()
        Else
            MsgBox("Tidak Terkoneksi Dengan 10.10.2.4", vbCritical + vbOKOnly, "Peringatan")
            Exit Sub
        End If

        Dim ambilunit As String = _
            "select Unit,Jenis,ServerX,ConnStr,Kode from mstUnit order by ServerX"
        Dim dadap As New SqlDataAdapter(ambilunit, connnn)
        dadap.Fill(dtunit)

        'Dim ambilunit As String = _
        '    "select Unit,Jenis,ServerX,ConnStr,Kode from mstUnit order by ServerX"
        'dtunit.FillMe(ambilunit)

        For i = 0 To dtunit.Rows.Count - 1
            Dim unit As String = dtunit.Rows(i).Item("Unit")
            Dim constr As String = dtunit.Rows(i).Item("ConnStr")
            Dim kode As String = dtunit.Rows(i).Item("Kode")

            Dim conn As SqlConnection
            conn = New SqlConnection(constr)
            If conn.State = ConnectionState.Closed Then
                conn.Open()
                Dim dtKE As New DataTable
                Dim sqlambilKE As String = _
                    "select a.*,b.Faktur as FakturPBYKE,b.UserValid as UserValidPBY,b.DateTimeValid as DateTimeValidPBY,b.UserUpdate as UserUpdateValid,b.DateTimeUpdate as DateTimeUpdateValid,b.CekValid," & _
                    "Validasi = (case when b.cekvalid is null then 0 when b.cekvalid = 0 then 0 else 1 end) from trkirimekspedisi a " & _
                    "left join pValidKirimEkspedisiPBY b " & _
                    "on a.Faktur = b.Faktur " & _
                    "where a.Jenis='PENGAJUAN BAYAR SUPPLIER' and " & _
                    "TglKirim between '" & DTOC(dTanggal1.Text, "/", False) & "' and '" & DTOC(dTanggal2.Text, "/", False) & "'"
                Dim dada As New SqlDataAdapter(sqlambilKE, conn)
                dada.SelectCommand.CommandTimeout = 0
                dada.Fill(dtKE)

                For a = 0 To dtKE.Rows.Count - 1
                    dtlist.Rows.Add(dtKE.Rows(a).Item("Validasi"), constr, kode, unit, dtKE.Rows(a).Item("Faktur"), dtKE.Rows(a).Item("TglKirim"), _
                                    dtKE.Rows(a).Item("JumlahBarang"), dtKE.Rows(a).Item("BeratBarang"), dtKE.Rows(a).Item("TotalBiaya"), _
                                    dtKE.Rows(a).Item("UserValidPBY"), dtKE.Rows(a).Item("DateTimeValidPBY"), dtKE.Rows(a).Item("UserUpdateValid"), _
                                    dtKE.Rows(a).Item("DateTimeUpdateValid"), dtKE.Rows(a).Item("CekValid"))
                Next
                conn.Close()
            End If
        Next

        dgList.DataSource = dtlist
        dgList.colVisibleFalse = {"Constr", "CekValid"}
        dgList.colFitGrid = True
        dgList.colForEntry = {"Valid"}
        dgList.colWidth = {0.4, 0.1, 0.7, 0.8, 1.4, 1, 1, 1, 1, 1, 1, 1, 1.3, 0.1}
        dgList.RefreshDataView()

        dgList.gcMain.RepositoryItems.Add(check)
        dgList.gvMain.Columns(0).ColumnEdit = check

        dgList.gvMain.LoadingPanelVisible = False
    End Sub

    Private Sub check_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles check.EditValueChanging
        Dim konn As SqlConnection
        konn = New SqlConnection(dgList.GetRowCellValue(dgList.FocusedRowHandle, "Constr"))
        If konn.State = ConnectionState.Closed Then
            konn.Open()
        Else
            MsgBox("Koneksi Gagal", vbCritical + vbOKOnly, "Peringatan")
            Exit Sub
        End If

        Dim query As String = ""

        If e.NewValue = True Then
            Dim konfirmasi As String = MsgBox("Validasi ?", vbQuestion + vbYesNo, "Konfirmasi")
            If konfirmasi = vbYes Then
                'cek uservalid
                If IsDBNull(dgList.GetRowCellValue(dgList.FocusedRowHandle, "UserValid")) And IsDBNull(dgList.GetRowCellValue(dgList.FocusedRowHandle, "CekValid")) Then
                    'tambah user valid dan tambah di pValid
                    query = "insert into pValidKirimEkspedisiPBY (Faktur,UserValid,DateTimeValid,CekValid) values (" & _
                        "'" & dgList.GetRowCellValue(dgList.FocusedRowHandle, "Faktur") & "','" & pubUserEntry & "','" & DTOC(Now, "/", True) & "','1')"
                Else
                    'tambah user update dan tambah di pValid
                    query = "update pValidKirimEkspedisiPBY set UserUpdate='" & pubUserEntry & "',DateTimeUpdate='" & DTOC(Now, "/", True) & "',CekValid='1' where Faktur='" & dgList.GetRowCellValue(dgList.FocusedRowHandle, "Faktur") & "'"
                End If
            Else
                e.NewValue = e.OldValue
                konn.Close()
                Exit Sub
            End If
        Else
            Dim konfirmasi As String = MsgBox("Batal Validasi ?", vbQuestion + vbYesNo, "Konfirmasi")
            If konfirmasi = vbYes Then
                'kosongkan userupdate dan userUpdate di pValid
                If IsDBNull(dgList.GetRowCellValue(dgList.FocusedRowHandle, "UserUpdate")) And dgList.GetRowCellValue(dgList.FocusedRowHandle, "CekValid") = True Then
                    query = "update pValidKirimEkspedisiPBY set CekValid='0' where Faktur='" & dgList.GetRowCellValue(dgList.FocusedRowHandle, "Faktur") & "'"
                Else
                    query = "update pValidKirimEkspedisiPBY set CekValid='0',UserUpdate=Null,DateTimeUpdate=Null where Faktur='" & dgList.GetRowCellValue(dgList.FocusedRowHandle, "Faktur") & "'"
                End If
            Else
                e.NewValue = e.OldValue
                konn.Close()
                Exit Sub
            End If
        End If
        cmd = New SqlCommand(query, konn)
        cmd.ExecuteNonQuery()
        MsgBox("Berhasil", vbInformation + vbOKOnly, "Informasi")
        konn.Close()
        btnAmbilData.PerformClick()
    End Sub

    Private Sub frmValidKEPBY_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dTanggal2.EditValue = Now
        dTanggal1.EditValue = DateAdd(DateInterval.Day, -7, Now)
    End Sub

    Private Sub dgList_Grid_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles dgList.Grid_SelectionChanged
        Dim constr As String = dgList.GetRowCellValue(dgList.FocusedRowHandle, "Constr")
        Dim sql As String = _
            "with cteSum as(" & _
            "select NoPengajuan,TglPengajuan,sum(Pengajuan) as JumlahPengajuan " & _
            "from trPengajuanBayarHd group by NoPengajuan,TglPengajuan) " & _
            "select b.Faktur,b.FakturPCRKonsPby as NoPengajuan,c.TglPengajuan,c.JumlahPengajuan from trkirimekspedisidetail b " & _
            "left join ctesum c on b.FakturPCRKonsPby = c.nopengajuan " & _
            "left join trKirimEkspedisi a on a.Faktur = b.Faktur " & _
            "where a.Jenis='PENGAJUAN BAYAR SUPPLIER' and b.Faktur='" & dgList.GetRowCellValue(dgList.FocusedRowHandle, "Faktur") & "'"
        Dim dt As New cMeDB(constr)
        dt.FillMe(sql)

        dgPBY.DataSource = dt
        dgPBY.colWidth = {0.1, 0.8, 0.8, 1}
        dgPBY.colFitGrid = True
        dgPBY.colVisibleFalse = {"Faktur"}
        dgPBY.RefreshDataView()
    End Sub
End Class