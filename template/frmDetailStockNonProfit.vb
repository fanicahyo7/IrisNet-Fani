Imports meCore
Imports System.Data.SqlClient
Public Class frmDetailStockNonProfit
    Dim isNew As Boolean = True
    Dim db As New cMeDB
    Dim pKode As String = "asdjaksdjqi01298310owueqiowueakdh"

    Sub loadDetail()
        Dim pQuery As String = ""
        pQuery = "Select Kode, Keterangan, UserEntry,DateTimeENtry,UserUpdate,DateTimeUpdate from mstStockNonProfit where Kode = '" & pKode & "'"
        db.FillMe(pQuery, True)

        If db.Rows.Count > 0 Then
            isNew = False
            FillFormFromDataRow(Me, db.Rows(0))
            SetTextReadOnly({cKode})
        Else
            ClearValue(Me)
            isNew = True
            SetTextReadOnly({cKode}, False)
        End If
    End Sub
    Private Sub frmDetailStockNonProfit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tKeterangan.Properties.CharacterCasing = CharacterCasing.Upper
        If Me.Tag <> "" Then pKode = Me.Tag
        koneksi()
        Dim qq As String = "select Kode,Judul,Penyusun from vwStkSup Order by Judul"
        cKode.FirstInit(PubConnStr, qq, {tKeterangan})
        loadDetail()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If CheckBeforeSave({cKode, tKeterangan}) = True Then
            Try
                Dim drow As DataRow
                If isNew = True Then
                    drow = db.NewRow
                Else
                    drow = db.Rows(0)
                End If

                drow!Kode = cKode.Text
                drow!Keterangan = tKeterangan.Text

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

    Private Sub tKode_Validated(sender As Object, e As EventArgs)
        pKode = cKode.Text
        Dim pQuery As String = ""
        pQuery = "Select Kode, Keterangan, UserEntry,DateTimeENtry,UserUpdate,DateTimeUpdate from mstStockNonProfit where Kode = '" & pKode & "'"
        db.FillMe(pQuery, True)

        If db.Rows.Count > 0 Then
            isNew = False
            FillFormFromDataRow(Me, db.Rows(0))
        Else
            ClearValue(Me, {"cKode"})
            isNew = True
        End If
    End Sub
End Class