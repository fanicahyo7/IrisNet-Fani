Imports meCore
Imports System.Data.SqlClient
Public Class frmMstBuku

    Private Sub frmMstBuku_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        'LayoutControlItem11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        'LayoutControlItem17.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        cPenyusun1.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cPenyusun1.AutoCompleteSource = AutoCompleteSource.ListItems
        cPenyusun2.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cPenyusun2.AutoCompleteSource = AutoCompleteSource.ListItems
        cPenyusun3.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cPenyusun3.AutoCompleteSource = AutoCompleteSource.ListItems

        loaddata()
    End Sub

    Sub loaddata()
        rJudulIndo.Checked = True
        tKodeBuku.Text = "B"

        cJenisBuku.Items.AddRange({"LITERATUR", "REFERENSI", "PENGAYAAN", "BACAAN", "MAJALAH"})


        Dim qPenerbit As String = "select Kode,Nama,Alamat from mstPenerbit order by nama"
        cPenerbit.FirstInit(PubConnStr, qPenerbit, {tNamaPenerbit})

        Dim qGolongan As String = "select Kode,Keterangan from mstGolongan order by Kode"
        cGolongan.FirstInit(PubConnStr, qGolongan, {tKeterangan})

        Dim qCover As String = "select Kode, Keterangan from mstCover order by Keterangan"
        cCover.FirstInit(PubConnStr, qCover, {tCover})

        Dim qKertas As String = "select Kode, Keterangan from mstJenisKertas order by Keterangan"
        cKertas.FirstInit(PubConnStr, qKertas, {tKertas})

        dThnBln.Properties.DisplayFormat.FormatString = "yyyy MMMM"
        dThnBln.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        dThnBln.Properties.EditMask = "yyyy MMMM"
        dThnBln.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView
        dThnBln.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView

        dThnBln.EditValue = Now

        tJudul.ReadOnly = True
        tNamaPenerbit.ReadOnly = True
        'SetTextReadOnly({tJudul, tNamaPenerbit})

        Dim qPenyusun As String = "select Keterangan from mstPenyusun order by keterangan"
        da = New SqlDataAdapter(qPenyusun, kon)
        Dim dtpenyusun As New DataTable
        da.Fill(dtpenyusun)

        cPenyusun1.DataSource = dtpenyusun
        cPenyusun1.DisplayMember = "Keterangan"
        cPenyusun1.ValueMember = "Keterangan"
        cPenyusun2.DataSource = dtpenyusun
        cPenyusun2.DisplayMember = "Keterangan"
        cPenyusun2.ValueMember = "Keterangan"
        cPenyusun3.DataSource = dtpenyusun
        cPenyusun3.DisplayMember = "Keterangan"
        cPenyusun3.ValueMember = "Keterangan"
        cPenyusun1.Text = ""
        cPenyusun2.Text = ""
        cPenyusun3.Text = ""
    End Sub

    'Sub judulruleindoeng()
    '    If rJudulIndo.Checked = True Then
    '        If tJudulIndo.Text = "" Then
    '            If tJudulEng.Text = "" Then
    '                tJudul.Text = ""
    '            Else
    '                tJudul.Text = tJudulEng.Text
    '            End If
    '        Else
    '            If tJudulEng.Text = "" Then
    '                tJudul.Text = tJudulIndo.Text
    '            Else
    '                tJudul.Text = tJudulIndo.Text & " (" & tJudulEng.Text & ")"
    '            End If
    '        End If
    '    ElseIf rJudulEng.Checked = True Then
    '        If tJudulEng.Text = "" Then
    '            If tJudulIndo.Text = "" Then
    '                tJudul.Text = ""
    '            Else
    '                tJudul.Text = tJudulIndo.Text
    '            End If
    '        Else
    '            If tJudulIndo.Text = "" Then
    '                tJudul.Text = tJudulEng.Text
    '            Else
    '                tJudul.Text = tJudulEng.Text & " (" & tJudulIndo.Text & ")"
    '            End If
    '        End If
    '    End If
    'End Sub

    Function judulruleindoeng(ByVal aktif As Boolean) As String
        Dim judul As String = ""
        'If rJudulIndo.Checked = True Then
        If aktif = True Then
            If tJudulIndo.Text = "" Then
                If tJudulEng.Text = "" Then
                    judul = ""
                Else
                    judul = tJudulEng.Text
                End If
            Else
                If tJudulEng.Text = "" Then
                    judul = tJudulIndo.Text
                Else
                    judul = tJudulIndo.Text & " (" & tJudulEng.Text & ")"
                End If
            End If
            'ElseIf rJudulEng.Checked = True Then
        ElseIf aktif = False Then
            If tJudulEng.Text = "" Then
                If tJudulIndo.Text = "" Then
                    judul = ""
                Else
                    judul = tJudulIndo.Text
                End If
            Else
                If tJudulIndo.Text = "" Then
                    judul = tJudulEng.Text
                Else
                    judul = tJudulEng.Text & " (" & tJudulIndo.Text & ")"
                End If
            End If
        End If
        Return judul
    End Function

    Function judulrulefisik(ByVal cover As Boolean, ByVal kertas As Boolean) As String
        Dim judul As String
        Dim judulcover As String
        Dim judulkertas As String

        If cCover.Text = "" Or cCover.Text.ToUpper = "NN" Then
            judulcover = ""
        Else
            judulcover = cCover.Text
        End If
        If cKertas.Text = "" Or cKertas.Text.ToUpper = "NN" Then
            judulkertas = ""
        Else
            judulkertas = cKertas.Text
        End If

        If cover = True And kertas = True Then
            If (cCover.Text = "" Or cCover.Text.ToUpper = "NN") And (cKertas.Text = "" Or cKertas.Text.ToUpper = "NN") Then
                judul = ""
            ElseIf cCover.Text = "" Or cCover.Text.ToUpper = "NN" Then
                judul = "[" & judulkertas & "]"
            ElseIf cKertas.Text = "" Or cKertas.Text.ToUpper = "NN" Then
                judul = "[" & judulcover & "]"
            Else
                judul = "[" & judulcover & "/" & judulkertas & "]"
            End If
        ElseIf cover = True And kertas = False Then
            If cCover.Text = "" Or cCover.Text.ToUpper = "NN" Then
                judul = ""
            Else
                judul = "[" & judulcover & "]"
            End If
        ElseIf cover = False And kertas = True Then
            If cKertas.Text = "" Or cKertas.Text.ToUpper = "NN" Then
                judul = ""
            Else
                judul = "[" & judulkertas & "]"
            End If
        Else
            judul = ""
        End If

        Return judul
    End Function

    Function judulrulebupel(ByVal jenjang As String, ByVal kelas As String, ByVal jilidsem As String, ByVal program As String, ByVal lain As String) As String
        Dim judul As String
        Dim sjenjang As String = jenjang
        Dim skelas As String = kelas

        Dim sjilidsem As String = ""
        If cJilidSem.Text.ToUpper = " " Then
            sjilidsem = ""
            tJilidSem.Text = ""
        ElseIf cJilidSem.Text.ToUpper = "JILID" Then
            If tJilidSem.Text = "" Then
                sjilidsem = ""
            Else
                sjilidsem = "JL" & tJilidSem.Text
            End If
        ElseIf cJilidSem.Text.ToUpper = "SEMESTER" Then
            If tJilidSem.Text = "" Then
                sjilidsem = ""
            Else
                sjilidsem = "SMT " & tJilidSem.Text
            End If
        End If
        tJilidSemKode.Text = sjilidsem

        Dim sprogram As String = ""
        If cProgram.Text.ToUpper = " " Then
            sprogram = ""
            tProgram.Text = ""
        ElseIf cProgram.Text.ToUpper = "JILID" Then
            If tProgram.Text = "" Then
                sprogram = ""
            Else
                sprogram = "JL" & tProgram.Text
            End If
        ElseIf cJilidSem.Text.ToUpper = "SEMESTER" Then
            If tProgram.Text = "" Then
                sprogram = ""
            Else
                sprogram = "SMT " & tProgram.Text
            End If
        End If
        tJilidSemKode.Text = sprogram


        Dim slain As String = lain

        judul = sjenjang & " " & skelas & " " & sjilidsem & " " & sprogram & " " & slain
        Return judul
    End Function

    Sub judulrule()
        Dim judulfinal As String
        Dim judultabmain As String
        Dim judultabfisik As String
        Dim judultabumum As String
        Dim judultabbupel As String

        'indo english
        Dim aktif As Boolean
        If rJudulIndo.Checked = True Then
            aktif = True
        ElseIf rJudulEng.Checked = True Then
            aktif = False
        End If
        judultabmain = judulruleindoeng(aktif)

        'fisik
        judultabfisik = judulrulefisik(IIf(ccCover.Checked, True, False), IIf(ccKertas.Checked, True, False))

        Dim indextab As Integer = XtraTabControl1.SelectedTabPageIndex
        If indextab = 0 Then
            'tab umum
            '--------------------------------------------------
            judultabumum = judulrulebupel(cJenjang.Text, tKelas.Text, cJilidSem.Text, cProgram.Text, tLain.Text)
            '--------------------------------------------------
        ElseIf indextab = 1 Then
            'tab bupel
            judultabbupel = judulrulebupel(cJenjang.Text, tKelas.Text, cJilidSem.Text, cProgram.Text, tLain.Text)
        End If

        judulfinal = judultabmain & " " & judultabbupel & " " & judultabfisik
        tJudul.Text = judulfinal
    End Sub

    Private Sub rJudulEng_CheckedChanged(sender As Object, e As EventArgs) Handles rJudulEng.CheckedChanged
        judulrule()
    End Sub

    Private Sub rJudulIndo_CheckedChanged(sender As Object, e As EventArgs) Handles rJudulIndo.CheckedChanged
        judulrule()
    End Sub

    Private Sub tJudulIndo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tJudulIndo.KeyPress
        If (Asc(e.KeyChar) = 32) Then
            history()
        End If
    End Sub
    Sub history()
        Dim query As String = _
                "select Judul, Jilid, Edisi, NamaPenerbit, Penyusun, Kode from vwBuku where Status = 1 and Left(kode,1) = '" & Strings.Left(tKodeBuku.Text, 1) & "'  and  Judul like '%" & tJudulIndo.Text & "%'  order by judul"
        dgHistory.FirstInit(query, {1, 0.5, 0.5, 1, 1, 1})
        dgHistory.RefreshData(False)
    End Sub
    Private Sub tJudulIndo_Validated(sender As Object, e As EventArgs) Handles tJudulIndo.Validated
        judulrule()
        If Not tJudulIndo.Text = "" Then
            history()
        End If
    End Sub

    'Private Sub tJudulEng_Enter(sender As Object, e As EventArgs) Handles tJudulEng.Enter

    'End Sub

    Private Sub tJudulEng_Validated(sender As Object, e As EventArgs) Handles tJudulEng.Validated
        judulrule()
    End Sub

    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        Dim index As Integer = XtraTabControl1.SelectedTabPageIndex

    End Sub

    Private Sub ccCover_CheckedChanged(sender As Object, e As EventArgs) Handles ccCover.CheckedChanged
        judulrule()
    End Sub

    Private Sub ccKertas_CheckedChanged(sender As Object, e As EventArgs) Handles ccKertas.CheckedChanged
        judulrule()
    End Sub

    Private Sub cCover_EditValueChanged(sender As Object, e As EventArgs) Handles cCover.EditValueChanged
        judulrule()
    End Sub

    Private Sub cKertas_EditValueChanged(sender As Object, e As EventArgs) Handles cKertas.EditValueChanged
        judulrule()
    End Sub

    Private Sub cJenjang_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cJenjang.SelectedIndexChanged
        judulrule()
    End Sub

    Private Sub tKelas_Validated(sender As Object, e As EventArgs) Handles tKelas.Validated
        judulrule()
    End Sub

    Private Sub cJilidSem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cJilidSem.SelectedIndexChanged
        judulrule()
    End Sub

    Private Sub cProgram_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cProgram.SelectedIndexChanged
        judulrule()
    End Sub

    Private Sub tJilidSem_Validated(sender As Object, e As EventArgs) Handles tJilidSem.Validated
        judulrule()
    End Sub

    Private Sub tProgram_Validated(sender As Object, e As EventArgs) Handles tProgram.Validated
        judulrule()
    End Sub

    Private Sub tLain_Validated(sender As Object, e As EventArgs) Handles tLain.Validated
        judulrule()
    End Sub
End Class