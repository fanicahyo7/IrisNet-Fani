Imports meCore
Public Class frmTerimaEkspedisiList

    Private Sub frmTerimaEkspedisiList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initForm(Me, EnfrmSizeNotMax.efsnm2Medium, DevExpress.XtraLayout.MoveFocusDirection.DownThenAcross)
        meCore.pubServerType = enServerType.enStSQLServer
    End Sub

    Private Sub btnRefreshData_Click(sender As Object, e As EventArgs) Handles btnRefreshData.Click
        Dim p As String =
            "Select Faktur,Dari,CaraKirim,KdEkspedisi,TglTerima,NoNota,JenisBarang,JumlahBrg,SatuanJum," & _
            "BeratBrg,SatuanBrt,Total,Pembawa,Penerima,Keterangan,UserEntry,DateTimeEntry from trTerimaEkspedisi"
        dgList.FirstInit(p, {1.5, 1.2, 1.2, 0.8, 0.8, 1, 0.8, 0.5, 0.5,
                             0.5, 0.5, 0.8, 0.8, 0.8, 0.8, 0.5, 0.8},
                         , , , , 50, False)
        dgList.RefreshData(False)
    End Sub

    Private Sub btnBaru_Click(sender As Object, e As EventArgs) Handles btnBaru.Click
        Using xx As New frmTerimaEkspedisi
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub dgList_Grid_DoubleClick(sender As Object, e As EventArgs) Handles dgList.Grid_DoubleClick
        Dim faktur As String
        faktur = dgList.GetRowCellValue(dgList.FocusedRowHandle, "Faktur")
        Using xx As New frmTerimaEkspedisi
            xx.Tag = faktur
            xx.ShowDialog(Me)
        End Using
    End Sub

    Private Sub dgList_Load(sender As Object, e As EventArgs) Handles dgList.Load

    End Sub
End Class