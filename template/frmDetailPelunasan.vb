Imports meCore
Public Class frmDetailPelunasan
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Dim faktur As String
    Public Sub New(faktur As String)

        ' This call is required by the designer.
        InitializeComponent()
        Me.faktur = faktur
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Private Sub frmDetailPelunasan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetTextReadOnly({tFaktur, tPelunasan, tPembulatan, tTotalPelunasan})
        tPelunasan.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        tPelunasan.Properties.Appearance.Options.UseTextOptions = True
        tPembulatan.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        tPembulatan.Properties.Appearance.Options.UseTextOptions = True
        tTotalPelunasan.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        tTotalPelunasan.Properties.Appearance.Options.UseTextOptions = True

        tPelunasan.Properties.Mask.EditMask = "n0"
        tPelunasan.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        tPelunasan.Properties.Mask.UseMaskAsDisplayFormat = True
        tPembulatan.Properties.Mask.EditMask = "n0"
        tPembulatan.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        tPembulatan.Properties.Mask.UseMaskAsDisplayFormat = True
        tTotalPelunasan.Properties.Mask.EditMask = "n0"
        tTotalPelunasan.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        tTotalPelunasan.Properties.Mask.UseMaskAsDisplayFormat = True

        Dim query As String = _
            "select a.Faktur as FakturPP, a.FakturAsli as Faktur, b.FakturAsli,Keterangan," & _
            "case when SUBSTRING(a.FakturAsli,8,2) = 'FJ' then Jumlah else 0 end as Debet," & _
            "case when SUBSTRING(a.FakturAsli,8,2) <> 'FJ' then Jumlah * -1 else  0 end as Kredit," & _
            "Jumlah as Pelunasan " & _
            "from vwDetailPiutang a " & _
            "left join vwKartuPiutang b on a.FakturAsli = b.faktur " & _
            "where a.Faktur = '" & faktur & "' order by FktAcuan, a.Tanggal "
        dgList.FirstInit(query, {0.2, 1, 1, 1, 0.8, 0.8, 0.8}, , , {"FakturPP"})
        dgList.RefreshData(False)

        Dim db As New cMeDB
        Dim pQuery As String = _
            "select Faktur,Total as Pelunasan,Pembulatan,Total+Pembulatan as TotalPelunasan from trLPtgHeader where Faktur='" & faktur & "'"
        db.FillMe(pQuery, True)

        If db.Rows.Count > 0 Then
            FillFormFromDataRow(Me, db.Rows(0))
        End If
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Me.Close()
    End Sub
End Class