
Imports meCore

Public Class frmGrafikBig

    Public Sub callMe(db As cMeDB, SeriesDataMember As String, ArgumentDataMember As String, ValueDataMembers As String)
        chart.DataSource = db
        ' Specify data members to bind the chart's series template.
        chart.SeriesDataMember = SeriesDataMember
        chart.SeriesTemplate.ArgumentDataMember = ArgumentDataMember
        chart.SeriesTemplate.ValueDataMembers.AddRange(New String() {ValueDataMembers})
        chart.SeriesTemplate.LabelsVisibility = IIf(chkShowLabel.Checked = True, DevExpress.Utils.DefaultBoolean.True, DevExpress.Utils.DefaultBoolean.False)
        Me.ShowDialog()
        Me.Dispose()
    End Sub

    Private Sub chkShowLabel_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowLabel.CheckedChanged
        chart.SeriesTemplate.LabelsVisibility = IIf(chkShowLabel.Checked = True, DevExpress.Utils.DefaultBoolean.True, DevExpress.Utils.DefaultBoolean.False)
    End Sub

    Private Sub frmGrafikBig_Load(sender As Object, e As EventArgs) Handles Me.Load
        initForm(Me, EnfrmSizeNotMax.efsnm4Huge, DevExpress.XtraLayout.MoveFocusDirection.AcrossThenDown)
    End Sub

    Private Sub chart_CustomDrawSeries(sender As Object, e As DevExpress.XtraCharts.CustomDrawSeriesEventArgs) Handles chart.CustomDrawSeries
        e.SeriesDrawOptions.Color = GetTransactionColor(e.Series.Name)
        e.LegendDrawOptions.Color = e.SeriesDrawOptions.Color
    End Sub

    Private Sub chart_CustomDrawSeriesPoint(sender As Object, e As DevExpress.XtraCharts.CustomDrawSeriesPointEventArgs) Handles chart.CustomDrawSeriesPoint
        If e.SeriesPoint(0) < 1 Then
            e.LabelText = ""
        End If
    End Sub
End Class