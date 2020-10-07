
Imports meCore

Public Class frmRptGolSupTerlaris
    Public pTgl1, pTgl2 As DateTime
    Public pTrans, pBukuATK, pJenis, pQuery, pFilter As String


    Private Sub frmRptGolSupTerlaris_Load(sender As Object, e As EventArgs) Handles Me.Load
        initForm(Me, EnfrmSizeNotMax.efsnm4Huge, DevExpress.XtraLayout.MoveFocusDirection.DownThenAcross, True)

        Text = "Golongan Supplier Terlaris"

        cTrans.SelectedIndex = 0
        cQuery.SelectedIndex = 0
        cBukuAtk.SelectedIndex = 0
        cJenis.SelectedIndex = 0
        refreshFilter()

        If pTrans IsNot Nothing Then
            d1.EditValue = pTgl1
            d2.EditValue = pTgl2
            cTrans.Text = pTrans
            cBukuAtk.Text = pBukuATK
            cJenis.Text = pJenis
            cQuery.Text = pQuery
            refreshFilter()
            mFilter.Text = pFilter
            mFilter.CompleteInfo()
            cRefresh.PerformClick()
        End If
    End Sub

    Sub refreshFilter()
        Dim pQue As String = ""
        Dim pColToSearch() As String = Nothing
        Select Case cQuery.Text.ToUpper
            Case "GOLONGAN"
                pQue = "SELECT Kode, Nama FROM dbo.mstSupplier"
                pColToSearch = {"Kode", "Nama"}
                lblTips.Text = "Double click pada " & cQuery.Text & " untuk masuk ke laporan Golongan Supplier Terlaris dengan Query " & cQuery.Properties.Items(0).ToString & " dengan filter yang sama"

            Case "SUPPLIER"
                pQue = "SELECT Kode, Keterangan AS Nama FROM dbo.mstGolongan"
                pColToSearch = {"Kode", "Keterangan"}
                lblTips.Text = "Double click pada " & cQuery.Text & " untuk masuk ke laporan Golongan Supplier Terlaris dengan Query " & cQuery.Properties.Items(1).ToString & " dengan filter yang sama"
        End Select
        mFilter.SetProperties(PubConnStr, pQue, pColToSearch, {1, 3}, {tFilterInf}, , , , "Kode")
    End Sub

    Private Sub cQuery_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cQuery.SelectedIndexChanged
        refreshFilter()
    End Sub

    Private Sub cRefresh_Click(sender As Object, e As EventArgs) Handles cRefresh.Click
        lcgHeader.Enabled = False

        With mdgList

            Dim pQue As String = ""
            pQue = "EXEC dbo.spGetRptGolSupTerlaris " & _
                            "	 @parTglAwal = '" & DTOC(d1.EditValue) & "', " & _
                            "    @parTglAkhir = '" & DTOC(d2.EditValue) & "', " & _
                            "    @parBukuAtk = '" & IIf(cBukuAtk.Text = "TOTAL", "", cBukuAtk.Text) & "', " & _
                            "    @parKons = '" & IIf(cJenis.Text = "TOTAL", "", IIf(cJenis.Text = "KONSI", 1, 0)) & "', " & _
                            "    @parJenis = '" & IIf(cTrans.Text = "TOTAL", "", cTrans.Text) & "', " & _
                            "    @parQuery = '" & cQuery.Text & "', " & _
                            "    @parFilter = '" & IIf(mFilter.Text.Length > 0, mFilter.Text, "") & "' "
            .colSum = {"OmzetHpp", "NilaiPersediaanSekarang", "% NilaiPersediaan", "QtyPersediaan", "QtyOmzet"}
            .colWidth = {1, 3, 0.8, 0.6, 1.1, 0.6, 1.1, 0.6}
            .Query = pQue
            .ColHeaderHeight = 60
            .RefreshData()
        End With
    End Sub

    Private Sub mdgList_Grid_CustomDrawFooterCell(sender As Object, e As DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs) Handles mdgList.Grid_CustomDrawFooterCell
        Dim gv As DevExpress.XtraGrid.Views.Grid.GridView = sender
        Select Case e.Column.FieldName.ToLower
            Case "% qtyomzet"
                e.Info.DisplayText = gv.Columns("% QtyOmzet").SummaryText & "%"
            Case "% qtypersediaan"
                e.Info.DisplayText = gv.Columns("% QtyPersediaan").SummaryText & "%"
            Case "% omzethpp"
                'Dim aa As Double = (CDbl(gv.Columns("GP").SummaryText) / CDbl(gv.Columns("Jumlah").SummaryText)) * 100
                e.Info.DisplayText = gv.Columns("% OmzetHpp").SummaryText & "%"
            Case "% nilaipersediaan"
                'Dim aa As Double = (CDbl(gv.Columns("GP").SummaryText) / CDbl(gv.Columns("Jumlah").SummaryText)) * 100
                e.Info.DisplayText = gv.Columns("% NilaiPersediaan").SummaryText & "%"
        End Select
    End Sub

    Private Sub mdgList_Grid_DoubleClick(sender As Object, e As EventArgs) Handles mdgList.Grid_DoubleClick
        Dim pformprnt As Form = Me
        pformprnt.Name = "frmMainTab"
        If Me.ParentForm IsNot Nothing Then pformprnt = Me.ParentForm
        If pformprnt.Name = "frmMainTab" Then
            If mdgList.GetRowCount_Gridview > 0 Then
                Using xx As New frmRptGolSupTerlaris
                    xx.pTgl1 = d1.EditValue
                    xx.pTgl1 = d1.EditValue
                    xx.pTgl2 = d2.EditValue
                    xx.pTrans = cTrans.Text
                    xx.pBukuATK = cBukuAtk.Text
                    xx.pJenis = cJenis.Text
                    xx.pQuery = IIf(cQuery.Text = "SUPPLIER", "GOLONGAN", "SUPPLIER")
                    xx.pFilter = mdgList.GetRowCellValue(mdgList.FocusedRowHandle, "Kode")
                    xx.ShowDialog(pformprnt)
                End Using
            End If
        End If
    End Sub

    Private Sub mdgList_OnPopRefreshClickEnd() Handles mdgList.OnPopRefreshClickEnd
        For i As Integer = 0 To mdgList.DataSource.Columns.Count - 1
            If mdgList.DataSource.Columns(i).ColumnName.Contains("%") = True Then
                mdgList.gvMain.Columns(i).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                mdgList.gvMain.Columns(i).DisplayFormat.FormatString = "{0:n2}%"
                SetFooterSummarySUMi(mdgList.gvMain, {i}, 2, True)
            End If
        Next

        'If mdgList.DataSource.Columns.Contains("%") = True Then
        '    mdgList.gvMain.Columns("PersOmzetHpp").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '    mdgList.gvMain.Columns("PersOmzetHpp").DisplayFormat.FormatString = "{0:n2}%"
        'End If
        'If mdgList.DataSource.Columns.Contains("PersOmzetHpp") = True Then
        '    mdgList.gvMain.Columns("PersOmzetHpp").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '    mdgList.gvMain.Columns("PersOmzetHpp").DisplayFormat.FormatString = "{0:n2}%"
        'End If
        'If mdgList.DataSource.Columns.Contains("PersQtyOmzet") = True Then
        '    mdgList.gvMain.Columns("PersQtyOmzet").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '    mdgList.gvMain.Columns("PersQtyOmzet").DisplayFormat.FormatString = "{0:n2}%"
        'End If
        'If mdgList.DataSource.Columns.Contains("PersQtyNP") = True Then
        '    mdgList.gvMain.Columns("PersQtyNP").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '    mdgList.gvMain.Columns("PersQtyNP").DisplayFormat.FormatString = "{0:n2}%"
        'End If
        'If mdgList.DataSource.Columns.Contains("PersNilaiPersediaan") = True Then
        '    mdgList.gvMain.Columns("PersNilaiPersediaan").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '    mdgList.gvMain.Columns("PersNilaiPersediaan").DisplayFormat.FormatString = "{0:n2}%"
        'End If

        'For i As Integer = 0 To mdgList.DataSource.Columns.Count - 1
        '    If mdgList.DataSource.Columns(i).ColumnName.ToLower.Contains("perselisih") = True Then
        '        mdgList.gvMain.Columns(i).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '        mdgList.gvMain.Columns(i).DisplayFormat.FormatString = "{0:n2}%"
        '    End If
        'Next

        'For i As Integer = 0 To mdgList.DataSource.Columns.Count - 1
        '    If mdgList.DataSource.Columns(i).ColumnName.ToLower.Contains("omzet") = True Then
        '        SetFooterSummarySUMi(mdgList.gvMain, {i}, 0)
        '    End If

        '    If mdgList.DataSource.Columns(i).ColumnName.ToLower.Contains("qty") = True Then
        '        SetFooterSummarySUMi(mdgList.gvMain, {i}, 0)
        '    End If

        '    If mdgList.DataSource.Columns(i).ColumnName.ToLower.Contains("selisih") = True And _
        '        mdgList.DataSource.Columns(i).ColumnName.ToLower.Contains("pers") = False Then
        '        SetFooterSummarySUMi(mdgList.gvMain, {i}, 0)
        '    End If
        'Next
        lcgHeader.Enabled = True
    End Sub

    Private Sub mdgList_Grid_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs)

    End Sub
End Class