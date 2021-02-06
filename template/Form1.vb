
Imports meCore

Public Class Form1
    Dim dbx As New cMeDB

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Try
            Dim pKode As String = ""
            Dim cLio As New cClosedXML
            Dim ds As DataSet = cLio.XLStoDataset_thisWorking("D:\cb\FORMAT LR NEWEST 2019.xlsx")
            CtrlMeDataGrid1.DataSource = ds.Tables(0)
            CtrlMeDataGrid1.colWidth = {2, 3, 4} '<-- gawe ukuran kolom
            'CtrlMeDataGrid1.colSum = {"qty", "jumlah", "dll"} '<-- gawe sum kolom
            CtrlMeDataGrid1.RefreshDataView()

        Catch ex As Exception
            Pesan({ex.Message.ToString})
            Exit Sub
        End Try


        'dbx.FillMe("select top 10 * from mststock")
        'CtrlMeDataGrid1.DataSource = dbx
        'CtrlMeDataGrid1.RefreshDataView()
    End Sub


    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        dbx.FillMe("select * from mstbarang limit 10")
        CtrlMeDataGrid1.DataSource = dbx
        CtrlMeDataGrid1.RefreshDataView()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        For I = 0 To 80 'Telling the program to count from 0 - 200
            TextBox1.Text = I
            BackgroundWorker1.ReportProgress(I)
            System.Threading.Thread.Sleep(100)
        Next
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        'DateEdit1.EditValue = Now

        'Dim tanggal As Date = New Date(CInt(Format(DateEdit1.EditValue, "yyyy")), CInt(Format(DateEdit1.EditValue, "MM")), 1)
        'Dim tanggal2 As Date = Format(DateEdit1.EditValue, "yyyy/MM/dd")
        'Dim tanggal As Date = New Date(CInt(Format(Now, "yyyy")), CInt(Format(Now, "MM")), 1)
        'Dim tanggal2 As Date = Format(Now, "yyyy/MM/dd")
        'Dim totalhari As String = DateDiff(DateInterval.Day, tanggal, tanggal2) + 1
        'Dim hari As Integer = 1
        'Dim tampung As String = ""
        'Dim minggu As Integer = 1
        'Do
        '    Dim hhari As String = DatePart(DateInterval.Weekday, tanggal).ToString

        '    tampung = "Tanggal " & hari & " adalah Minggu ke " & minggu & vbCrLf
        '    tanggal = DateAdd(DateInterval.Day, 1, tanggal)
        '    If hhari = 7 Then
        '        minggu += 1
        '    End If
        '    hari += 1
        'Loop While hari <= totalhari
        'MsgBox(tampung)

        MsgBox(cariminggu(DateEdit1.EditValue))

    End Sub

    Function cariminggu(ByVal tanggalnya As Date) As String
        Dim tanggal As Date = New Date(CInt(Format(tanggalnya, "yyyy")), CInt(Format(tanggalnya, "MM")), 1)
        Dim tanggal2 As Date = Format(tanggalnya, "yyyy/MM/dd")
        Dim totalhari As String = DateDiff(DateInterval.Day, tanggal, tanggal2) + 1
        Dim hari As Integer = 1
        Dim tampung As String = ""
        Dim minggu As Integer = 1
        Do
            Dim hhari As String = DatePart(DateInterval.Weekday, tanggal).ToString
            tampung = "Tanggal " & hari & " adalah Minggu ke " & minggu & vbCrLf
            tanggal = DateAdd(DateInterval.Day, 1, tanggal)
            If hhari = 7 Then
                minggu += 1
            End If
            hari += 1
        Loop While hari <= totalhari
        Return tampung
    End Function

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        Dim anu As String = TextEdit1.Text
        If Len(anu) = 1 Then
            If anu = "9" Then
                anu = "0" & CInt(anu) + 1
            Else
                anu = "00" & CInt(anu) + 1
            End If
        ElseIf Len(anu) = 2 Then
            If anu = "99" Then
                anu = CInt(anu) + 1
            Else
                anu = "0" & CInt(anu) + 1
            End If
        ElseIf Len(anu) = 3 Then
            anu = CInt(anu) + 1
        End If
        MsgBox(anu)
    End Sub
End Class