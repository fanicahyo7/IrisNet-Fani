<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.CtrlMeDataGrid1 = New meCore.ctrlMeDataGrid()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.DateEdit1 = New DevExpress.XtraEditors.DateEdit()
        Me.SimpleButton4 = New DevExpress.XtraEditors.SimpleButton()
        Me.TextEdit1 = New DevExpress.XtraEditors.TextEdit()
        Me.SimpleButton5 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.DateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(79, 83)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton1.TabIndex = 1
        Me.SimpleButton1.Text = "SimpleButton1"
        '
        'CtrlMeDataGrid1
        '
        Me.CtrlMeDataGrid1.colSum = Nothing
        Me.CtrlMeDataGrid1.ConnString = Nothing
        Me.CtrlMeDataGrid1.dSourceUsePK = True
        Me.CtrlMeDataGrid1.FilterPopUpMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
        Me.CtrlMeDataGrid1.Location = New System.Drawing.Point(25, 194)
        Me.CtrlMeDataGrid1.Name = "CtrlMeDataGrid1"
        Me.CtrlMeDataGrid1.PopDeleteShow = False
        Me.CtrlMeDataGrid1.PopExportShow = True
        Me.CtrlMeDataGrid1.PopNewShow = False
        Me.CtrlMeDataGrid1.PopOpenShow = False
        Me.CtrlMeDataGrid1.PopPrintShow = False
        Me.CtrlMeDataGrid1.PopRefreshShow = False
        Me.CtrlMeDataGrid1.Query = Nothing
        Me.CtrlMeDataGrid1.QueryTime = Nothing
        Me.CtrlMeDataGrid1.ShowFooter = True
        Me.CtrlMeDataGrid1.Size = New System.Drawing.Size(846, 337)
        Me.CtrlMeDataGrid1.TabIndex = 0
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Location = New System.Drawing.Point(196, 83)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton2.TabIndex = 2
        Me.SimpleButton2.Text = "SimpleButton2"
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Location = New System.Drawing.Point(485, 72)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton3.TabIndex = 3
        Me.SimpleButton3.Text = "SimpleButton3"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(485, 41)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 4
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(485, 102)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(248, 23)
        Me.ProgressBar1.TabIndex = 5
        '
        'DateEdit1
        '
        Me.DateEdit1.EditValue = Nothing
        Me.DateEdit1.Location = New System.Drawing.Point(79, 28)
        Me.DateEdit1.Name = "DateEdit1"
        Me.DateEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit1.Size = New System.Drawing.Size(100, 20)
        Me.DateEdit1.TabIndex = 6
        '
        'SimpleButton4
        '
        Me.SimpleButton4.Location = New System.Drawing.Point(196, 26)
        Me.SimpleButton4.Name = "SimpleButton4"
        Me.SimpleButton4.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton4.TabIndex = 7
        Me.SimpleButton4.Text = "SimpleButton4"
        '
        'TextEdit1
        '
        Me.TextEdit1.Location = New System.Drawing.Point(79, 141)
        Me.TextEdit1.Name = "TextEdit1"
        Me.TextEdit1.Size = New System.Drawing.Size(100, 20)
        Me.TextEdit1.TabIndex = 8
        '
        'SimpleButton5
        '
        Me.SimpleButton5.Location = New System.Drawing.Point(196, 138)
        Me.SimpleButton5.Name = "SimpleButton5"
        Me.SimpleButton5.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton5.TabIndex = 9
        Me.SimpleButton5.Text = "SimpleButton5"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(901, 565)
        Me.Controls.Add(Me.SimpleButton5)
        Me.Controls.Add(Me.TextEdit1)
        Me.Controls.Add(Me.SimpleButton4)
        Me.Controls.Add(Me.DateEdit1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.SimpleButton3)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.CtrlMeDataGrid1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.DateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CtrlMeDataGrid1 As meCore.ctrlMeDataGrid
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents DateEdit1 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents SimpleButton4 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TextEdit1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SimpleButton5 As DevExpress.XtraEditors.SimpleButton
End Class
