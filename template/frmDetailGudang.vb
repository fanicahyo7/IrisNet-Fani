Imports meCore
Imports System.Data.SqlClient
Public Class frmDetailGudang
    Dim isNew As Boolean = True
    Dim db As New cMeDB
    Dim pKode As String = "asdjaksdjqi01298310owueqiowueakdh"

    Sub loadDetail()
        Dim pQuery As String = ""
        If Text = "Master Gudang" Then
            pQuery = "Select Kode, Keterangan, FlagJual,FlagOpname,UserEntry,DateTimeENtry,UserUpdate,DateTimeUpdate from mstGudang where Kode = '" & pKode & "'"
        ElseIf Text = "Master Wilayah" Then
            pQuery = "Select Kode, Keterangan, UserEntry,DateTimeENtry,UserUpdate,DateTimeUpdate from mstWilayah where Kode = '" & pKode & "'"
        ElseIf Text = "Master Rak" Then
            pQuery = "Select Kode, Keterangan, UserEntry,DateTimeENtry,UserUpdate,DateTimeUpdate from mstRak where Kode = '" & pKode & "'"
        ElseIf Text = "Master Type Customer Supplier" Then
            pQuery = "Select Kode, Keterangan, UserEntry,DateTimeENtry,UserUpdate,DateTimeUpdate from mstTypeCusSup where Kode = '" & pKode & "'"
        End If
        db.FillMe(pQuery, True)

        If db.Rows.Count > 0 Then
            isNew = False
            FillFormFromDataRow(Me, db.Rows(0))
            SetTextReadOnly({tKode})

            If Text = "Master Gudang" Then
                If IsDBNull(db.Rows(0)!FlagJual) = True Then
                    cFlagJual.Checked = False
                ElseIf db.Rows(0)!FlagJual = 0 Then
                    cFlagJual.Checked = False
                Else
                    cFlagJual.Checked = True
                End If

                If IsDBNull(db.Rows(0)!FlagOpname) = True Then
                    cFlagOpname.Checked = False
                ElseIf db.Rows(0)!FlagOpname = 0 Then
                    cFlagOpname.Checked = False
                Else
                    cFlagOpname.Checked = True
                End If
            End If
        Else
            ClearValue(Me)
            isNew = True
            SetTextReadOnly({tKode}, False)
        End If
    End Sub
    Private Sub frmDetailGudang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tKode.Properties.CharacterCasing = CharacterCasing.Upper
        tKeterangan.Properties.CharacterCasing = CharacterCasing.Upper
        If Me.Tag <> "" Then pKode = Me.Tag
        koneksi()
        If Text = "Master Gudang" Then
            LayoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        Else
            LayoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If
        loadDetail()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        tKode.Text = Trim(tKode.Text)
        tKeterangan.Text = Trim(tKeterangan.Text)
        If CheckBeforeSave({tKode, tKeterangan}) = True Then
            Try
                Dim drow As DataRow
                If isNew = True Then
                    drow = db.NewRow
                Else
                    drow = db.Rows(0)
                End If

                drow!Kode = tKode.Text
                drow!Keterangan = tKeterangan.Text
                If Text = "Master Gudang" Then
                    drow!FlagJual = cFlagJual.Checked
                    drow!FlagOpname = cFlagOpname.Checked
                End If
                If isNew = True Then
                    drow!UserEntry = pubUserEntry
                    drow!DateTimeEntry = Now
                Else
                    drow!UserUpdate = pubUserEntry
                    drow!DateTimeUpdate = Now
                End If

                If isNew Then db.Rows.Add(drow)
                db.UpdateMeToRealDBNoTry()
                Pesan({IIf(isNew = True, "Simpan", "Update") & " Data BERHASIL"})
                Close()
            Catch ex As Exception
                Pesan({"GAGAL SIMPAN DATA", "", "Err : " & ex.Message.ToString})
            End Try
        End If
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Close()
    End Sub

    Private Sub tKode_Validated(sender As Object, e As EventArgs) Handles tKode.Validated
        pKode = tKode.Text
        Dim pQuery As String = ""
        If Text = "Master Gudang" Then
            pQuery = "Select Kode, Keterangan, FlagJual,FlagOpname,UserEntry,DateTimeENtry,UserUpdate,DateTimeUpdate from mstGudang where Kode = '" & pKode & "'"
        ElseIf Text = "Master Wilayah" Then
            pQuery = "Select Kode, Keterangan, UserEntry,DateTimeENtry,UserUpdate,DateTimeUpdate from mstWilayah where Kode = '" & pKode & "'"
        ElseIf Text = "Master Rak" Then
            pQuery = "Select Kode, Keterangan, UserEntry,DateTimeENtry,UserUpdate,DateTimeUpdate from mstRak where Kode = '" & pKode & "'"
        ElseIf Text = "Master Type Customer Supplier" Then
            pQuery = "Select Kode, Keterangan, UserEntry,DateTimeENtry,UserUpdate,DateTimeUpdate from mstTypeCusSup where Kode = '" & pKode & "'"
        End If
        db.FillMe(pQuery, True)

        If db.Rows.Count > 0 Then
            isNew = False
            FillFormFromDataRow(Me, db.Rows(0))

            If Text = "Master Gudang" Then
                If IsDBNull(db.Rows(0)!FlagJual) = True Then
                    cFlagJual.Checked = False
                ElseIf db.Rows(0)!FlagJual = 0 Then
                    cFlagJual.Checked = False
                Else
                    cFlagJual.Checked = True
                End If

                If IsDBNull(db.Rows(0)!FlagOpname) = True Then
                    cFlagOpname.Checked = False
                ElseIf db.Rows(0)!FlagOpname = 0 Then
                    cFlagOpname.Checked = False
                Else
                    cFlagOpname.Checked = True
                End If
            End If
        Else
            ClearValue(Me, {"tKode"})
            cFlagJual.Checked = False
            cFlagOpname.Checked = False
            isNew = True
        End If
    End Sub
End Class