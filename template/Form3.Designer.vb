<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        Me.DateEdit1 = New DevExpress.XtraEditors.DateEdit()
        Me.CtrlMeDataGrid1 = New meCore.ctrlMeDataGrid()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DateEdit2 = New DevExpress.XtraEditors.DateEdit()
        Me.CMeButtonBrowser1 = New meCore.cMeButtonBrowser()
        Me.CMeButtonBrowser1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.DateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CMeButtonBrowser1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CMeButtonBrowser1View, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DateEdit1
        '
        Me.DateEdit1.EditValue = Nothing
        Me.DateEdit1.Location = New System.Drawing.Point(200, 68)
        Me.DateEdit1.Name = "DateEdit1"
        Me.DateEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit1.Size = New System.Drawing.Size(100, 20)
        Me.DateEdit1.TabIndex = 0
        '
        'CtrlMeDataGrid1
        '
        Me.CtrlMeDataGrid1.colSum = Nothing
        Me.CtrlMeDataGrid1.ConnString = Nothing
        Me.CtrlMeDataGrid1.dSourceUsePK = True
        Me.CtrlMeDataGrid1.FilterPopUpMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
        Me.CtrlMeDataGrid1.Location = New System.Drawing.Point(12, 106)
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
        Me.CtrlMeDataGrid1.Size = New System.Drawing.Size(663, 198)
        Me.CtrlMeDataGrid1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(212, 30)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DateEdit2
        '
        Me.DateEdit2.EditValue = Nothing
        Me.DateEdit2.Location = New System.Drawing.Point(88, 27)
        Me.DateEdit2.Name = "DateEdit2"
        Me.DateEdit2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit2.Size = New System.Drawing.Size(100, 20)
        Me.DateEdit2.TabIndex = 3
        '
        'CMeButtonBrowser1
        '
        Me.CMeButtonBrowser1.Location = New System.Drawing.Point(388, 68)
        Me.CMeButtonBrowser1.Name = "CMeButtonBrowser1"
        Me.CMeButtonBrowser1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CMeButtonBrowser1.Properties.NullText = ""
        Me.CMeButtonBrowser1.Properties.View = Me.CMeButtonBrowser1View
        Me.CMeButtonBrowser1.Size = New System.Drawing.Size(161, 20)
        Me.CMeButtonBrowser1.TabIndex = 4
        '
        'CMeButtonBrowser1View
        '
        Me.CMeButtonBrowser1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.CMeButtonBrowser1View.Name = "CMeButtonBrowser1View"
        Me.CMeButtonBrowser1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.CMeButtonBrowser1View.OptionsView.ShowGroupPanel = False
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(388, 24)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton1.TabIndex = 5
        Me.SimpleButton1.Text = "SimpleButton1"
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(687, 416)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.CMeButtonBrowser1)
        Me.Controls.Add(Me.DateEdit2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CtrlMeDataGrid1)
        Me.Controls.Add(Me.DateEdit1)
        Me.Name = "Form3"
        Me.Text = "Form3"
        CType(Me.DateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CMeButtonBrowser1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CMeButtonBrowser1View, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DateEdit1 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents CtrlMeDataGrid1 As meCore.ctrlMeDataGrid
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DateEdit2 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents CMeButtonBrowser1 As meCore.cMeButtonBrowser
    Friend WithEvents CMeButtonBrowser1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
End Class
