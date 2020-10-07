Imports System.Data.SqlClient
Imports meCore

Public Class frmMutasi
    Dim pFaktur As String = pKodeInit
    Dim dbH As cMeDB
    Dim isNew As Boolean = True
    Dim pubUserEntry As String = "FANI"

    Private Sub frmMutasi_Load(sender As Object, e As EventArgs) Handles Me.Load
        koneksi()
        initForm(Me, EnfrmSizeNotMax.efsnm0Default, DevExpress.XtraLayout.MoveFocusDirection.DownThenAcross)

        If Tag IsNot Nothing Then
            If Tag.ToString.Length > 0 Then
                pFaktur = Tag
            End If
        End If

        SetTextReadOnly({tFaktur, dTanggal})
        LoadDetail()
        Dim p As String = "SELECT Kode, Keterangan FROM mstGudang where FlagBlokir = 0 order by Kode "
        mDari.FirstInit(PubConnStr, p, {tDari}, , , , , , {0.5, 1.5})
        Dim p1 As String = "SELECT Kode, Keterangan FROM mstGudang where FlagBlokir = 0 order by Kode "
        mKe.FirstInit(PubConnStr, p1, {tKe}, , , , , , {0.5, 1.5})
        If rMode.SelectedIndex = 0 Then
            mDari.Text = "GUDANG"
            mKe.Text = "TOKO"
            mDari.ReadOnly = True
            mKe.ReadOnly = True
        ElseIf rMode.SelectedIndex = 1 Then
            mDari.ReadOnly = False
            mKe.ReadOnly = False
            Dim pQue As String = "SELECT Kode, Keterangan FROM mstGudang where FlagBlokir = 0 and Kode <> 'GUDANG' order by Kode "
            mDari.FirstInit(PubConnStr, pQue, {tDari}, , , , , , {0.5, 1.5})
            Dim pQ As String = "SELECT Kode, Keterangan FROM mstGudang where FlagBlokir = 0 and Kode <> 'GUDANG' and Kode <> '" & mDari.Text & "' order by Kode "
            mKe.FirstInit(PubConnStr, pQ, {tKe}, , , , , , {0.5, 1.5})
        End If

        rJenis_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Sub LoadDetail()
        Dim pQue As String = ""
        pQue = "SELECT Status, Faktur, Tanggal, Jenis, FakturAsli, " & _
                "        KdSupplier, Dari, Ke, UserEntry, DateTimeEntry, " & _
                "        UserUpdate, DateTimeUpdate " & _
                "        FROM trMTHeader " & _
                "where Faktur = '" & pFaktur & "'"

        dbH = New cMeDB
        dbH.FillMe(pQue, True)
        If dbH.Rows.Count > 0 Then
            isNew = False
            FillFormFromDataRow(Me, dbH.Rows(0))

            SetTextReadOnly({rMode, mDari, mKe, rJenis, mFakturAsli, tKdSupplier})
        End If

        pQue = "SELECT a.Faktur, a.Urutan, a.Kode, a.Judul, a.Penyusun, a.Jilid, a.KdSupplier, a.NamaPenerbit as Penerbit, " & _
                "       Qty as QtyFaktur, isnull(b.Saldo,0) as Saldo, isnull(c.pending,0) as QtyPending, a.Qty, a.Kode1, a.KdBuku, a.Tanggal, 0 as Fire " & _
                "FROM vwMT a " & _
                "left join (SELECT Kode, sum(Akhir) as Saldo FROM trSTKGud GROUP BY Kode) b on a.kode = b.kode " & _
                "left join (select  kode, sum(qty) as pending from trMTDetail " & _
                "						where Dari = '" & mDari.Text & "' and faktur <> '" & pFaktur & "' and Isnull(UserValid,'') = '' " & _
                "						group by kode) c on a.kode = c.kode " & _
                "where a.Faktur = '" & pFaktur & "' order by a.urutan"

        mdgList.FirstInit(pQue, {1.3, 0.5, 0.8, 2, 1.5, 0.5, 0.6, 1.5, 0.5, 0.5, 0.5, 0.5, 1, 1, 1}, _
                          {"QtyFaktur", "Saldo", "QtyPending", "Qty"}, {"Qty"}, _
                          {"Faktur", "Kode1", "KdBuku", "Tanggal"}, , 40)
        mdgList.RefreshData(False)
        mdgList.DataSource.SetPK({"Faktur", "Kode"})
    End Sub

    Private Sub rJenis_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rJenis.SelectedIndexChanged
        Dim pQue As String = ""
        mFakturAsli.Enabled = True
        SetTextReadOnly({tKdSupplier})
        mFakturAsli.Text = ""
        mdgList.Grid_ClearData()
        Select Case rJenis.SelectedIndex
            Case 0
                pQue = "SELECT * FROM ( " & _
                        "select distinct b.faktur, b.kdSupplier, b.FakturAsli, b.tanggal, b.Total " & _
                        "from trpcdetail a " & _
                        "left join trpcheader b on a.faktur = b.faktur " & _
                        "where a.qty > isnull(a.mutasi, a.qty) and FlagMutasi = 1 " & _
                        ") x "
            Case 1
                pQue = "SELECT * FROM ( " & _
                        "select distinct b.faktur, b.kdSupplier, b.FakturAsli, b.tanggal, b.Total " & _
                        "from trKonsDetail a " & _
                        "left join trKonsHeader b on a.faktur = b.faktur " & _
                        "where a.qty > isnull(a.mutasi, a.qty) and FlagMutasi = 1 and FlagHitung = 0 and isnull(b.fakturreinv, '') = '' " & _
                        ") x "
                'pQue = "select Kode, Judul from mststock"
        End Select

        If pQue.Length > 0 Then _
        mFakturAsli.SetProperties(PubConnStr, pQue, _
                                {"faktur", "FakturAsli"}, {1.3, 0.6, 1.3, 0.7, 1}, _
                                {tKdSupplier})
    End Sub

    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        If CheckBeforeSave({mDari, mKe}) Then
            Dim frmAdd As New Form
            Dim addx As New frmuAddItem(frmuAddItem.enMasukKeluar.enmkKeluar, "", "GUDANG", "", frmuAddItem.enPajak.en0All)
            addx.Dock = DockStyle.Fill
            frmAdd.Controls.Add(addx)
            frmAdd.StartPosition = FormStartPosition.CenterScreen
            frmAdd.Size = New Size(800, 500)
            'CenterForm(frmAdd, EnfrmSizeNotMax.efsnmGiant)
            frmAdd.ShowDialog()
            If addx.GetDataCount > 0 Then
                For i As Integer = 0 To addx.GetDataCount - 1
                    Dim drow As DataRow = mdgList.DataSource.Rows.Find({pFaktur, addx.GetDataRowCellValue(frmuAddItem.enColumn.Kode, i)})
                    If drow Is Nothing Then
                        '        pQue = "SELECT a.Faktur, a.Urutan, a.Kode, a.Judul, a.Penyusun, "
                        '        'a.Jilid, a.KdSupplier, a.NamaPenerbit as Penerbit, " & _
                        '"       Qty as QtyFaktur, isnull(b.Saldo,0) as Saldo, isnull(c.pending,0) as QtyPending, 
                        'a.Qty " & _"


                        drow = mdgList.DataSource.NewRow
                        drow("Faktur") = pFaktur
                        drow("Urutan") = 0
                        drow("Kode") = addx.GetDataRowCellValue(frmuAddItem.enColumn.Kode, i)
                        drow("Kode1") = drow!Kode
                        drow("Judul") = addx.GetDataRowCellValue(frmuAddItem.enColumn.Judul, i)
                        drow("Penyusun") = addx.GetDataRowCellValue(frmuAddItem.enColumn.Penyusun, i)
                        drow("Jilid") = addx.GetDataRowCellValue(frmuAddItem.enColumn.Jilid, i)
                        drow("Penerbit") = addx.GetDataRowCellValue(frmuAddItem.enColumn.NamaPenerbit, i)
                        drow("QtyFaktur") = addx.GetDataRowCellValue(frmuAddItem.enColumn.Qty, i)
                        drow("KdBuku") = addx.GetDataRowCellValue(frmuAddItem.enColumn.KdBuku, i)
                        drow("Saldo") = 0
                        drow("QtyPending") = 0
                        drow("Qty") = addx.GetDataRowCellValue(frmuAddItem.enColumn.Qty, i)
                        drow("Tanggal") = dTanggal.EditValue
                        drow("Fire") = 1
                        mdgList.DataSource.Rows.Add(drow)
                    Else
                        Dim pStr() As String = _
                            {"Judul " & addx.GetDataRowCellValue(frmuAddItem.enColumn.Judul, i) & " [" & addx.GetDataRowCellValue(frmuAddItem.enColumn.Kode, i) & "]", _
                             "sudah ada didalam list dengan Qty = " & drow("Qty").ToString & "", _
                             "Akumulasikan QtyFaktur ?"}
                        If Tanya(pStr) Then
                            drow("Qty") += addx.GetDataRowCellValue(frmuAddItem.enColumn.Qty, i)
                        End If
                    End If
                    If isNew = False Then mdgList.DataSource.UpdateMeToRealDatabase()
                Next
            End If
            addx.Dispose()
            frmAdd.Dispose()
        End If
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim jenis As String = ""
        Dim sa() As DataRow = Nothing
        If rMode.SelectedIndex = 0 Then
            sa = mdgList.DataSource.Select("Cek = True")
            jenis = rJenis.Properties.Items(rJenis.SelectedIndex).Description
        ElseIf rMode.SelectedIndex = 1 Then
            sa = mdgList.DataSource.Select("Kode <> ''")
            jenis = "Manual"
        End If

        If sa.Length = 0 Then
            MsgBox("Pilih Barang Dulu", vbCritical + vbOKOnly, "Peringatan")
            Exit Sub
        Else
            tFaktur.Text = GetNewFakturTogamasSQLServ(PubConnStr, "trMTHeader", FakturReset.Tahunan, "Faktur", pubKodeUnit & pubUserInit & "-MT", DTOC(Now), 5, "")
            Dim query As String = ""
            query = "Insert Into trMTHeader " & _
                "(Status,Faktur,Tanggal,Jenis,FakturAsli," & _
                "Dari,Ke,FlagMutasiAwal,UserEntry,DateTimeEntry,KdSupplier) Values(" & _
                "'1','" & tFaktur.Text & "','" & DTOC(Now, "/", True) & "','" & jenis & "','" & mFakturAsli.Text & "'," & _
                "'" & mDari.Text & "','" & mKe.Text & "','1','" & pubUserEntry & "','" & DTOC(Now, "/", True) & "','" & tKdSupplier.Text & "')"
            cmd = New SqlCommand(query, kon)
            cmd.ExecuteNonQuery()

            For i = 0 To sa.Length - 1
                query = "Insert Into trMTDetail (Status,Faktur,Kode1,Kode,Qty,Urutan,Dari,Ke) Values(" & _
                    "'1','" & tFaktur.Text & "','" & sa(i).Item("Kode") & "','" & sa(i).Item("Kode") & "','" & sa(i).Item("Qty") & "','" & i + 1 & "','" & mDari.Text & "','" & mKe.Text & "')"
                cmd = New SqlCommand(query, kon)
                cmd.ExecuteNonQuery()

                query = "Insert Into stDump (Faktur,Tanggal,Kode,Transaksi,Status) Values(" & _
                    "'" & tFaktur.Text & "','" & DTOC(Now, "/", True) & "','" & sa(i).Item("Kode") & "','trMTDetail','0')"
                cmd = New SqlCommand(query, kon)
                cmd.ExecuteNonQuery()
            Next
            MsgBox("Data Berhasil Terimpan", vbInformation + vbOKOnly, "Informasi")
        End If
    End Sub

    Private Sub rMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rMode.SelectedIndexChanged
        Dim p As String = "SELECT Kode, Keterangan FROM mstGudang where FlagBlokir = 0 order by Kode "
        mDari.FirstInit(PubConnStr, p, {tDari}, , , , , , {0.5, 1.5})
        Dim p1 As String = "SELECT Kode, Keterangan FROM mstGudang where FlagBlokir = 0 order by Kode "
        mKe.FirstInit(PubConnStr, p1, {tKe}, , , , , , {0.5, 1.5})
        mdgList.Grid_ClearDataAndColumns()
        If rMode.SelectedIndex = 0 Then
            mDari.Text = "GUDANG"
            mKe.Text = "TOKO"
            tDari.Text = "GUDANG"
            tKe.Text = "TOKO"
            mDari.ReadOnly = True
            mKe.ReadOnly = True
            LayoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            cmdAdd.Enabled = False
            cmdDel.Enabled = False
        ElseIf rMode.SelectedIndex = 1 Then
            LoadDetail()
            LayoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            tDari.Text = ""
            tKe.Text = ""
            mKe.Text = ""
            mDari.ReadOnly = False
            mKe.ReadOnly = False
            Dim pQue As String = "SELECT Kode, Keterangan FROM mstGudang where FlagBlokir = 0 and Kode <> 'GUDANG' order by Kode "
            mDari.FirstInit(PubConnStr, pQue, {tDari}, , , , , , {0.5, 1.5})
            Dim pQ As String = "SELECT Kode, Keterangan FROM mstGudang where FlagBlokir = 0 and Kode <> 'GUDANG' and Kode <> '" & mDari.Text & "' order by Kode "
            mKe.FirstInit(PubConnStr, pQ, {tKe}, , , , , , {0.5, 1.5})
            cmdAdd.Enabled = True
            cmdDel.Enabled = True
        End If
    End Sub

    Private Sub mDari_EditValueChanged(sender As Object, e As EventArgs) Handles mDari.EditValueChanged
        If rMode.SelectedIndex = 1 Then
            Dim pQ As String = "SELECT Kode, Keterangan FROM mstGudang where FlagBlokir = 0 and Kode <> 'GUDANG' and Kode <> '" & mDari.Text & "' order by Kode "
            mKe.FirstInit(PubConnStr, pQ, {tKe}, , , , , , {0.5, 1.5})
        End If
    End Sub

    Private Sub mFakturAsli_EditValueChanged(sender As Object, e As EventArgs) Handles mFakturAsli.EditValueChanged
        
    End Sub

    Private Sub mdgList_Grid_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles mdgList.Grid_CustomDrawCell
        If rMode.SelectedIndex = 0 Then
            If Not Trim(mdgList.GetRowCellValue(e.RowHandle, "ada").ToString) = "" Then
                e.Appearance.ForeColor = Color.Green
            End If
        End If
    End Sub

    Private Sub mdgList_Grid_CustomRowCellEditForEditing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles mdgList.Grid_CustomRowCellEditForEditing
        If e.Column.FieldName = "Cek" Then
            If Trim(mdgList.GetRowCellValue(e.RowHandle, "ada")) <> "" Then
                e.RepositoryItem.ReadOnly = True
            Else
                e.RepositoryItem.ReadOnly = False
            End If
        End If
    End Sub

    Private Sub mdgList_Load(sender As Object, e As EventArgs) Handles mdgList.Load

    End Sub

    Private Sub mFakturAsli_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mFakturAsli.KeyPress
        If (e.KeyChar = Chr(13)) Then
            Dim query As String = ""
            If rJenis.SelectedIndex = 0 Then
                query = "select a.Kode,a.Judul,a.Penyusun,a.Jilid,a.KdSupplier,a.NamaPenerbit,a.Qty,a.Saldo,cast(0 as bit) as Cek,ISNULL(c.Faktur,'') as ada from vwPC a " & _
                        "left join trMTHeader c on a.Faktur=c.FakturAsli " & _
                        "where a.Faktur = '" & mFakturAsli.Text & "'  Order by a.Urutan"
            ElseIf rJenis.SelectedIndex = 1 Then
                query = "select a.Kode,a.Judul,a.Penyusun,a.Jilid,a.KdSupplier,a.NamaPenerbit,a.Qty,a.Saldo,cast(0 as bit) as Cek,ISNULL(c.Faktur,'') as ada from vwKons a " & _
                        "left join trMTHeader c on a.Faktur=c.FakturAsli " & _
                        "where a.Faktur = '" & mFakturAsli.Text & "'  Order by a.Urutan"
            End If
            mdgList.FirstInit(query, {1, 1, 1, 1, 1, 1, 1, 1, 0.5, 1}, , {"Cek"}, {"ada"})
            mdgList.RefreshData()

            '"left join trMTDetail b on a.Kode = b.Kode
        End If
    End Sub
End Class