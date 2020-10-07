
Imports meCore

Public Class frmRptBarangKeluarMasuk
    Dim dbGrafik As New cMeDB

    Private Sub frmRptBarangKeluarMasuk_Load(sender As Object, e As EventArgs) Handles Me.Load
        initForm(Me, EnfrmSizeNotMax.efsnm0Default, DevExpress.XtraLayout.MoveFocusDirection.AcrossThenDown)
        ceQuery.Text = "Supplier"

        filterstock.FilterTahunSaldo = False
        'filterstock.setQueryAlias("a")
        LayoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
    End Sub

    Private Sub cmbRefreshData_Click(sender As Object, e As EventArgs) Handles cmbRefreshData.Click

        Dim pQueWhereStok As String = IIf(filterstock.Text.Length > 0, " WHERE " & filterstock.Text, "")

        'pQueWhereStok = IIf(chkSaldo.Checked = False, "a.Saldo <> 0 AND", "")
        'If mbeSupplier.Text.Length > 0 Then pQueWhereStok &= " a.KdSupplier = '" & mbeSupplier.Text & "' AND"
        'If mGolongan.Text.Length > 0 Then pQueWhereStok &= " a.KdGolongan = '" & mGolongan.Text & "' AND"
        'If mbePenerbit.Text.Length > 0 Then pQueWhereStok &= " a.KdPenerbit = '" & mbePenerbit.Text & "' AND"
        'If tJudul.Text.Length > 0 Then pQueWhereStok &= " a.Judul like '%" & tJudul.Text & "%' AND"

        'If pQueWhereStok.Length > 0 Then pQueWhereStok = Mid(pQueWhereStok, 1, pQueWhereStok.Length - 3)

        'Dim tglAc As String = DTOC(Now)
        Dim tgAwal As String = DTOC(dTanggalAwal.EditValue)
        Dim tgAkhir As String = DTOC(dTanggalAkhir.EditValue)

        Dim pQue As String
        Dim kode As String = ""
        Dim queryplus As String = ""
        Dim kolawal As String = ""
        Select Case ceQuery.Text
            Case "Supplier"
                kode = "KdSupplier"
                queryplus = "a.KdSupplier,(select Nama from mstSupplier where Kode=a.KdSupplier) as NamaSupplier,(select case Konsinyasi when '1' then 'Konsinyasi' when '0' then 'Kredit' end from mstSupplier where Kode=a.KdSupplier) as Jenis"
                kolawal = "a.KdSupplier,a.NamaSupplier,a.Jenis,a.SaldoAwal"
            Case "Golongan"
                kode = "KdGolongan"
                queryplus = "a.KdGolongan,(select Keterangan from mstGolongan where Kode=a.KdGolongan) as NamaGolongan,'' as Jenis"
                kolawal = "a.KdGolongan,a.NamaGolongan,a.Jenis,a.SaldoAwal"
        End Select

        pQue = "declare @@TglAwal Varchar(8) " & _
                "declare @@TglAkhir Varchar(8) " & _
                "set @@TglAwal= '" & tgAwal & "'; " & _
                "set @@TglAkhir= '" & tgAkhir & "'; " & _
                    "with ctevwMstStock AS " & _
                    "(" & _
                    "select Kode,Judul,Konsinyasi,KdSupplier,KdGolongan from vwMstStock " & pQueWhereStok & " " & _
                    "group by Kode,Judul,Konsinyasi,KdSupplier,KdGolongan " & _
                    "), " & _
                    "cteTK AS (" & _
                    "select a.Kode,isnull(sum(a.Jumlah * (1-b.discfaktur*0.01)) ,0) as JumlahTK " & _
                    ",sum(isnull(Qty,0)) as QtyTK " & _
                    "from trKonsDetail a " & _
                    "left join trKonsHeader b on a.Faktur = b.Faktur " & _
                    "where CONVERT(VARCHAR(8),a.Tanggal,112) between @@TglAwal and @@TglAkhir " & _
                    "group by Kode " & _
                    "), " & _
                    "cteTKawal AS (" & _
                    "select a.Kode,isnull(sum(a.Jumlah * (1-b.discfaktur*0.01)) ,0) as JumlahTKawal " & _
                    ",sum(isnull(Qty,0)) as QtyTKawal " & _
                    "from trKonsDetail a " & _
                    "left join trKonsHeader b on a.Faktur = b.Faktur " & _
                    "where CONVERT(VARCHAR(8),a.Tanggal,112) < @@TglAwal " & _
                    "group by Kode " & _
                    "), " & _
                    "cteFB AS (" & _
                    "select a.Kode,isnull(sum(a.Jumlah * (1-b.discfaktur*0.01)) ,0) as JumlahFB " & _
                    ",sum(isnull(Qty,0)) as QtyFB " & _
                    "from trPCDetail a " & _
                    "left join trPCHeader b on a.Faktur = b.Faktur " & _
                    "where CONVERT(VARCHAR(8),a.Tanggal,112) between @@TglAwal and @@TglAkhir " & _
                    "group by Kode " & _
                    "), " & _
                    "cteFBawal AS (" & _
                    "select a.Kode,isnull(sum(a.Jumlah * (1-b.discfaktur*0.01)) ,0) as JumlahFBawal " & _
                    ",sum(isnull(Qty,0)) as QtyFBawal " & _
                    "from trPCDetail a " & _
                    "left join trPCHeader b on a.Faktur = b.Faktur " & _
                    "where CONVERT(VARCHAR(8),a.Tanggal,112) < @@TglAwal " & _
                    "group by Kode " & _
                    "), " & _
                    "cteRK AS (" & _
                    "select Kode,isnull(sum((HPP * Qty)),0) as JumlahRK " & _
                    ",sum(isnull(Qty,0)) as QtyRK " & _
                    "from trSKonsRDetail where CONVERT(VARCHAR(8),Tanggal,112) between @@TglAwal and @@TglAkhir " & _
                    "group by Kode,Faktur " & _
                    "), " & _
                    "cteRK2 AS (" & _
                    "select Kode,sum(JumlahRK) as JumlahRK " & _
                    ",sum(isnull(QtyRK,0)) as QtyRK from cteRK " & _
                    "group by Kode " & _
                    ")," & _
                    "cteRKawal AS (" & _
                    "select Kode,isnull(sum((HPP * Qty)),0) as JumlahRKawal " & _
                    ",sum(isnull(Qty,0)) as QtyRKawal from trSKonsRDetail where CONVERT(VARCHAR(8),Tanggal,112) < @@TglAwal " & _
                    "group by Kode,Faktur " & _
                    "), " & _
                    "cteRKawal2 AS (" & _
                    "select Kode,sum(JumlahRKawal) as JumlahRKawal " & _
                    ",sum(isnull(QtyRKawal,0)) as QtyRKawal from cteRKawal " & _
                    "group by Kode " & _
                    "), " & _
                    "cteCSR AS (" & _
                    "select Kode,isnull(sum((HPP * Qty)),0) as JumlahCSR " & _
                    ",sum(isnull(Qty,0)) as QtyCSR from trCSRDetail where CONVERT(VARCHAR(8),Tanggal,112) between @@TglAwal and @@TglAkhir " & _
                    "group by Kode,Faktur " & _
                    ")," & _
                    "cteCSR2 AS (" & _
                    "select Kode,sum(JumlahCSR) as JumlahCSR " & _
                    ",sum(isnull(QtyCSR,0)) as QtyCSR from cteCSR " & _
                    "group by Kode " & _
                    "), " & _
                    "cteCSRawal AS (" & _
                    "select kode,isnull(sum((HPP * Qty)),0) as JumlahCSRawal " & _
                    ",sum(isnull(Qty,0)) as QtySCRawal from trCSRDetail where CONVERT(VARCHAR(8),Tanggal,112) < @@TglAwal " & _
                    "group by Kode,Faktur " & _
                    "), " & _
                    "cteCSRawal2 AS (" & _
                    "select Kode,sum(JumlahCSRawal) as JumlahCSRawal " & _
                    ",sum(isnull(QtySCRawal,0)) as QtyCSRawal from cteCSRawal " & _
                    "group by Kode " & _
                    "), " & _
                    "cteBOR AS (" & _
                    "select Kode,isnull(sum((HPP * Qty)),0) as JumlahBOR " & _
                    ",sum(isnull(Qty,0)) as QtyBOR from trSLRDetail where CONVERT(VARCHAR(8),Tanggal,112) between @@TglAwal and @@TglAkhir " & _
                    "group by Kode,Faktur " & _
                    "), " & _
                    "cteBOR2 AS (" & _
                    "select Kode,sum(JumlahBOR) as JumlahBOR " & _
                    ",sum(isnull(QtyBOR,0)) as QtyBOR from cteBOR " & _
                    "group by Kode " & _
                    "), " & _
                    "cteBORawal AS (" & _
                    "select Kode,isnull(sum((HPP * Qty)),0) as JumlahBORawal " & _
                    ",sum(isnull(Qty,0)) as QtyBORawal from trSLRDetail where CONVERT(VARCHAR(8),Tanggal,112) < @@TglAwal " & _
                    "group by Kode,Faktur " & _
                    "), " & _
                    "cteBORawal2 AS (" & _
                    "select Kode,sum(JumlahBORawal) as JumlahBORawal " & _
                    ",sum(isnull(QtyBORawal,0)) as QtyBORawal from cteBORawal " & _
                    "group by Kode " & _
                    "), " & _
                    "cteOmzetKasir AS (" & _
                    "select Kode,isnull(sum((HPP * Qty)),0) as JumlahOmzetKasir " & _
                    ",sum(isnull(Qty,0)) as QtyOmzetKasir from trCSDetail where ISNULL(FlagRetur,0)=0 and CONVERT(VARCHAR(8),Tanggal,112) between @@TglAwal and @@TglAkhir " & _
                    "group by Kode,Faktur " & _
                    "), " & _
                    "cteOmzetKasir2 AS (" & _
                    "select Kode,sum(JumlahOmzetKasir) as JumlahOmzetKasir " & _
                    ",sum(isnull(QtyOmzetKasir,0)) as QtyOmzetKasir from cteOmzetKasir " & _
                    "group by Kode " & _
                    "), " & _
                    "cteOmzetKasirawal AS (" & _
                    "select Kode,isnull(sum((HPP * Qty)),0) as JumlahOmzetKasirawal " & _
                    ",sum(isnull(Qty,0)) as QtyOmzetKasirawal from trCSDetail where ISNULL(FlagRetur,0)=0 and CONVERT(VARCHAR(8),Tanggal,112) < @@TglAwal " & _
                    "group by Kode,Faktur " & _
                    "), " & _
                    "cteOmzetKasirawal2 AS (" & _
                    "select Kode,sum(JumlahOmzetKasirawal) as JumlahOmzetKasirawal " & _
                    ",sum(isnull(QtyOmzetKasirawal,0)) as QtyOmzetKasirawal from cteOmzetKasirawal " & _
                    "group by Kode " & _
                    "), " & _
                    "cteOmzetBO AS (" & _
                    "select Kode,isnull(sum((HPP * Qty)),0) as JumlahOmzetBO " & _
                    ",sum(isnull(Qty,0)) as QtyOmzetBO from trSLDetail where CONVERT(VARCHAR(8),Tanggal,112) between @@TglAwal and @@TglAkhir " & _
                    "group by Kode,Faktur " & _
                    "), " & _
                    "cteOmzetBO2 AS (" & _
                    "select Kode,sum(JumlahOmzetBO) as JumlahOmzetBO " & _
                    ",sum(isnull(QtyOmzetBO,0)) as QtyOmzetBO from cteOmzetBO " & _
                    "group by Kode " & _
                    "), " & _
                    "cteOmzetBOawal AS (" & _
                    "select Kode,isnull(sum((HPP *Qty)),0) as JumlahOmzetBOawal " & _
                    ",sum(isnull(Qty,0)) as QtyOmzetBOawal from trSLDetail where CONVERT(VARCHAR(8),Tanggal,112) < @@TglAwal " & _
                    "group by Kode,Faktur " & _
                    "), " & _
                    "cteOmzetBOawal2 AS (" & _
                    "select Kode,sum(JumlahOmzetBOawal) as JumlahOmzetBOawal " & _
                    ",sum(isnull(QtyOmzetBOawal,0)) as QtyOmzetBOawal from cteOmzetBOawal " & _
                    "group by Kode " & _
                    "), " & _
                    "cteRT AS (" & _
                    "select Kode,isnull(sum(Jumlah),0) as JumlahRT " & _
                    ",sum(isnull(Qty,0)) as QtyRT from trKonsRDetail where CONVERT(VARCHAR(8),Tanggal,112) between @@TglAwal and @@TglAkhir " & _
                    "group by Kode" & _
                    "), " & _
                    "cteRTawal AS (" & _
                    "select Kode,isnull(sum(Jumlah),0) as JumlahRTawal " & _
                    ",sum(isnull(Qty,0)) as QtyRTawal from trKonsRDetail where CONVERT(VARCHAR(8),Tanggal,112) < @@TglAwal " & _
                    "group by Kode" & _
                    "), " & _
                    "cteRB AS (" & _
                    "select Kode,isnull(sum(Jumlah),0) as JumlahRB " & _
                    ",sum(isnull(Qty,0)) as QtyRB from trPCRDetail where CONVERT(VARCHAR(8),Tanggal,112) between @@TglAwal and @@TglAkhir " & _
                    "group by Kode" & _
                    "), " & _
                    "cteRBawal AS (" & _
                    "select Kode,isnull(sum(Jumlah),0) as JumlahRBawal " & _
                    ",sum(isnull(Qty,0)) as QtyRBawal from trPCRDetail where CONVERT(VARCHAR(8),Tanggal,112) < @@TglAwal " & _
                    "group by Kode" & _
                    "), " & _
                    "cteKK AS (" & _
                    "select Kode,isnull(sum((HPP * Qty)),0) as JumlahKK " & _
                    ",sum(isnull(Qty,0)) as QtyKK from trsKonsDetail where CONVERT(VARCHAR(8),Tanggal,112) between @@TglAwal and @@TglAkhir " & _
                    "group by Kode,Faktur " & _
                    "), " & _
                    "cteKK2 AS (" & _
                    "select Kode,sum(JumlahKK) as JumlahKK " & _
                    ",sum(isnull(QtyKK,0)) as QtyKK from cteKK " & _
                    "group by Kode " & _
                    "), " & _
                    "cteKKawal AS (" & _
                   "select Kode,isnull(sum((HPP * Qty)),0) as JumlahKKawal " & _
                    ",sum(isnull(Qty,0)) as QtyKKawal from trsKonsDetail where CONVERT(VARCHAR(8),Tanggal,112) < @@TglAwal " & _
                    "group by Kode,Faktur " & _
                    "), " & _
                    "cteKKawal2 AS (" & _
                    "select Kode,sum(JumlahKKawal) as JumlahKKawal " & _
                    ",sum(isnull(QtyKKawal,0)) as QtyKKawal from cteKKawal " & _
                    "group by Kode " & _
                    ") ," & _
                    "ctePeny AS(" & _
                    "select Kode,isnull(sum(Qty * HPP),0) as JumlahPeny " & _
                    ",sum(isnull(Qty,0)) as QtyPeny from trPenyDetail where CONVERT(VARCHAR(8),Tanggal,112) between @@TglAwal and @@TglAkhir " & _
                    "group by Kode " & _
                    "), " & _
                    "ctePenyawal AS(" & _
                    "select Kode,isnull(sum(Qty * HPP),0) as JumlahPenyawal " & _
                    ",sum(isnull(Qty,0)) as QtyPenyawal from trPenyDetail where CONVERT(VARCHAR(8),Tanggal,112) < @@TglAwal " & _
                    "group by Kode " & _
                    "), " & _
                    "cteOPfinal AS(" & _
                    "select Kode,isnull(sum(Qty * HPP),0) as JumlahOPfinal " & _
                    ",sum(isnull(Qty,0)) as QtyOPFinal from trOPFinal where CONVERT(VARCHAR(8),TglAwal,112) between @@TglAwal and @@TglAkhir " & _
                    "group by Kode " & _
                    "), " & _
                    "cteOpfinalawal AS(" & _
                    "select Kode,isnull(sum(Qty * HPP),0) as JumlahOPfinalawal " & _
                    ",sum(isnull(Qty,0)) as QtyOpfinalawal from trOPFinal where CONVERT(VARCHAR(8),TglAwal,112) < @@TglAwal " & _
                    "group by Kode " & _
                    "), " & _
                    "cteSaldoAwal as(" & _
                    "select " & queryplus & "," & _
                    "((sum(isnull(b.JumlahTKawal,0))+sum(isnull(c.JumlahFBawal,0))+sum(isnull(d.JumlahCSRawal,0))+sum(isnull(e.JumlahBORawal,0))+sum(isnull(f.JumlahRKawal,0)))- " & _
                    "(sum(isnull(g.JumlahOmzetKasirawal,0))+sum(isnull(h.JumlahOmzetBOawal,0))+sum(isnull(i.JumlahRTawal,0))+sum(isnull(j.JumlahRBawal,0))+sum(isnull(k.JumlahKKawal,0)))+ " & _
                    "(sum(isnull(l.JumlahPenyawal,0))+sum(isnull(m.JumlahOPfinalawal,0))) " & _
                    ") as SaldoAwal, " & _
                    "((sum(isnull(b.QtyTKawal,0))+sum(isnull(c.QtyFBawal,0))+sum(isnull(d.QtyCSRawal,0))+sum(isnull(e.QtyBORawal,0))+sum(isnull(f.QtyRKawal,0)))- " & _
                    "(sum(isnull(g.QtyOmzetKasirawal,0))+sum(isnull(h.QtyOmzetBOawal,0))+sum(isnull(i.QtyRTawal,0))+sum(isnull(j.QtyRBawal,0))+sum(isnull(k.QtyKKawal,0)))+ " & _
                    "(sum(isnull(l.QtyPenyawal,0))+sum(isnull(m.QtyOpfinalawal,0))) " & _
                    ") as QTYSaldoAwal " & _
                    "from ctevwMstStock a " & _
                    "left join cteTKawal b on b.Kode = a.Kode " & _
                    "left join cteFBawal c on c.Kode = a.Kode " & _
                    "left join cteCSRawal2 d on d.Kode = a.Kode " & _
                    "left join cteBORawal2 e on e.Kode = a.Kode " & _
                    "left join cteRKawal2 f on f.Kode = a.Kode " & _
                    "left join cteOmzetKasirawal2 g on g.Kode = a.Kode " & _
                    "left join cteOmzetBOawal2 h on h.Kode= a.Kode " & _
                    "left join cteRTawal i on i.Kode =a.Kode " & _
                    "left join cteRBawal j on j.Kode=a.Kode " & _
                    "left join cteKKawal2 k on k.Kode=a.Kode " & _
                    "left join ctePenyawal l on l.Kode=a.Kode " & _
                    "left join cteOpfinalawal m on m.Kode=a.Kode " & _
                    "group by a." & kode & "" & _
                    "), " & _
                    "cteBarangMasuk as(" & _
                    "select " & queryplus & "," & _
                    "(sum(isnull(b.JumlahTK,0)) + sum(isnull(c.JumlahFB,0))) as TKFB, " & _
                    "(sum(isnull(d.JumlahCSR,0)) + sum(isnull(e.JumlahBOR,0)) + sum(isnull(f.JumlahRK,0))) as CSRBORRK, " & _
                    "(sum(isnull(b.JumlahTK,0)) + sum(isnull(c.JumlahFB,0)) + sum(isnull(d.JumlahCSR,0)) + " & _
                    "sum(isnull(e.JumlahBOR,0)) + sum(isnull(f.JumlahRK,0))) as BarangMasuk, " & _
                    "(sum(isnull(b.QtyTK,0)) + sum(isnull(c.QtyFB,0))) as QTYTKFB, " & _
                    "(sum(isnull(d.QtyCSR,0)) + sum(isnull(e.QtyBOR,0)) + sum(isnull(f.QtyRK,0))) as QTYCSRBORRK, " & _
                    "(sum(isnull(b.QtyTK,0)) + sum(isnull(c.QtyFB,0)) + sum(isnull(d.QtyCSR,0)) + " & _
                    "sum(isnull(e.QtyBOR,0)) + sum(isnull(f.QtyRK,0))) as QTYBarangMasuk " & _
                    "from ctevwMstStock a " & _
                    "left join cteTK b on b.Kode = a.Kode " & _
                    "left join cteFB c on c.Kode = a.Kode " & _
                    "left join cteCSR2 d on d.Kode = a.Kode " & _
                    "left join cteBOR2 e on e.Kode = a.Kode " & _
                    "left join cteRK2 f on f.Kode = a.Kode " & _
                    "group by a." & kode & "" & _
                    "), " & _
                    "cteBarangKeluar as(" & _
                    "select " & queryplus & "," & _
                    "(sum(isnull(b.JumlahOmzetKasir,0))) as OmzetKasir, " & _
                    "(sum(isnull(c.JumlahOmzetBO,0))) as OmzetBO, " & _
                    "(sum(isnull(d.JumlahRT,0))+sum(isnull(e.JumlahRB,0))) as RTRB, " & _
                    "(sum(isnull(f.JumlahKK,0))) as KK, " & _
                    "(sum(isnull(b.JumlahOmzetKasir,0))+sum(isnull(c.JumlahOmzetBO,0))+sum(isnull(d.JumlahRT,0))+ " & _
                    "sum(isnull(e.JumlahRB,0))+sum(isnull(f.JumlahKK,0))) as BarangKeluar, " & _
                    "(sum(isnull(b.QtyOmzetKasir,0))) as QTYOmzetKasir, " & _
                    "(sum(isnull(c.QtyOmzetBO,0))) as QTYOmzetBO, " & _
                    "(sum(isnull(d.QtyRT,0))+sum(isnull(e.QtyRB,0))) as QTYRTRB, " & _
                    "(sum(isnull(f.QtyKK,0))) as QTYKK, " & _
                    "(sum(isnull(b.QtyOmzetKasir,0))+sum(isnull(c.QtyOmzetBO,0))+sum(isnull(d.QtyRT,0))+ " & _
                    "sum(isnull(e.QtyRB,0))+sum(isnull(f.QtyKK,0))) as QTYBarangKeluar " & _
                    "from ctevwMstStock a " & _
                    "left join cteOmzetKasir2 b on b.Kode = a.Kode " & _
                    "left join cteOmzetBO2 c on c.Kode= a.Kode " & _
                    "left join cteRT d on d.Kode =a.Kode " & _
                    "left join cteRB e on e.Kode=a.Kode " & _
                    "left join cteKK2 f on f.Kode=a.Kode " & _
                    "group by a." & kode & "" & _
                    "), " & _
                    "cteSchSoDll as(" & _
                    "select " & queryplus & "," & _
                    "(sum(isnull(b.JumlahPeny,0)) + sum(isnull(c.JumlahOpFinal,0))) as SchSoDll,(sum(isnull(b.QtyPeny,0)) + sum(isnull(c.QtyOPFinal,0))) as QTYSchSoDll " & _
                    "from ctevwMstStock a " & _
                    "left join ctePeny b on b.Kode=a.Kode " & _
                    "left join cteOpfinal c on c.Kode=a.Kode " & _
                    "group by a." & kode & "" & _
                    ") " & _
                    "select " & kolawal & ",a.QTYSaldoAwal,b.TKFB,b.QTYTKFB,b.CSRBORRK,b.QTYCSRBORRK," & _
                    "c.OmzetKasir,c.QTYOmzetKasir,c.OmzetBO,c.QTYOmzetBO,c.KK,c.QTYKK,c.RTRB,c.QTYRTRB,d.SchSoDll,d.QTYSchSoDll," & _
                    "(a.SaldoAwal+b.barangmasuk-c.barangkeluar+d.schsodll) as SaldoAkhir, " & _
                    "(a.QTYSaldoAwal+b.QTYbarangmasuk-c.QTYbarangkeluar+d.QTYschsodll) as QtySaldoAkhir " & _
                    "from cteSaldoAwal a " & _
                    "left join cteBarangMasuk b on b." & kode & " = a." & kode & " " & _
                    "left join cteBarangKeluar c on c." & kode & " = a." & kode & " " & _
                    "left join cteSchSoDll d on d." & kode & " = a." & kode & " " & _
                    "order by a." & kode & " "
        mdgList.FirstInit(pQue, {1, 1, 0.8, 1.1, 1, 1, 1, 1, 1, _
                                1, 1, 1, 1, 1, 0.8, 1, 0.8, 1, 0.8, 1.1, 1}, _
                          {"SaldoAwal", "QTYSaldoAwal", "TKFB", "QTYTKFB", "CSRBORRK", "QTYCSRBORRK", _
                           "OmzetKasir", "QTYOmzetKasir", "OmzetBO", "QTYOmzetBO", "KK", "QTYKK", "RTRB", "QTYRTRB", "SchSoDll", "QTYSchSoDll", "SaldoAkhir", "QtySaldoAkhir"}, , , , 30, False)
        filterstock.Enabled = False
        cmbRefreshData.Enabled = False
        lcgF.Enabled = False
        mdgList.dSourceUsePK = False
        mdgList.RefreshData()
    End Sub

    Private Sub mdgList_Grid_CustomDrawFooterCell(sender As Object, e As DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs) Handles mdgList.Grid_CustomDrawFooterCell
        'Dim gv As DevExpress.XtraGrid.Views.Grid.GridView = sender

        'Select Case e.Column.FieldName
        '    Case "PersenthdNilaiPersediaan %"
        '        Dim a As Double = 0
        '        If gv.Columns("PersediaanSesuaiUmur").SummaryText = "" Then
        '            a = 0
        '        Else
        '            a = gv.Columns("PersediaanSesuaiUmur").SummaryText
        '        End If

        '        Dim b As Double = 0
        '        If gv.Columns("PersediaanSekarang").SummaryText = "" Then
        '            b = 0
        '        Else
        '            b = gv.Columns("PersediaanSekarang").SummaryText
        '        End If

        '        Dim aa As Double = 0
        '        If b = 0 Then
        '            aa = CDbl(a) * 100 / Math.Abs(a)
        '        Else
        '            aa = CDbl(a) * 100 / meDBNullnum(b)
        '        End If
        '        e.Info.DisplayText = FormatNumber(aa, 2)

        '    Case "PersenthdNilaiPersediaanQTY %"
        '        Dim a As Double = 0
        '        If gv.Columns("PersediaanSesuaiUmurQTY").SummaryText = "" Then
        '            a = 0
        '        Else
        '            a = gv.Columns("PersediaanSesuaiUmurQTY").SummaryText
        '        End If

        '        Dim b As Double = 0
        '        If gv.Columns("PersediaanSekarangQTY").SummaryText = "" Then
        '            b = 0
        '        Else
        '            b = gv.Columns("PersediaanSekarangQTY").SummaryText
        '        End If

        '        Dim aa As Double = 0
        '        If b = 0 Then
        '            aa = CDbl(a) * 100 / Math.Abs(a)
        '        Else
        '            aa = CDbl(a) * 100 / meDBNullnum(b)
        '        End If
        '        e.Info.DisplayText = FormatNumber(aa, 2)

        'End Select
    End Sub


    Sub RefreshGrafik(pKode As String)
        'Dim pQue As String = _
        '    "WITH cteSource AS ( " & _
        '    "		SELECT keterangan ,kode ,tanggal ,qty from dbo.vwKartuArusStockRow where kode IN (SELECT Kode FROM dbo.mstStkSup WHERE KdBuku = '" & pKode & "')  " & _
        '    "		), " & _
        '    "	cteThn AS (   " & _
        '    "		SELECT MIN(tanggal) AS Thn from cteSource " & _
        '    "		UNION ALL   " & _
        '    "		SELECT DATEADD(MONTH,1,Thn) FROM cteThn  WHERE CONVERT(VARCHAR(6),Thn,112) < CONVERT(VARCHAR(6),GETDATE(),112)  ),   " & _
        '    "	cteJenis AS (SELECT DISTINCT keterangan FROM cteSource),	 " & _
        '    "	cteAwal AS ( " & _
        '    "		SELECT CONVERT(varchar(6),a.Thn,112) as Tanggal,  " & _
        '    "				ISNULL((SELECT SUM(qty) FROM cteSource WHERE keterangan = 'PC' AND CONVERT(varchar(6),tanggal,112) < CONVERT(varchar(6),a.Thn,112) ),0)  " & _
        '    "				+ ISNULL((SELECT SUM(qty) FROM cteSource WHERE keterangan = 'TK' AND CONVERT(varchar(6),tanggal,112) < CONVERT(varchar(6),a.Thn,112) ),0) " & _
        '    "				- ISNULL((SELECT SUM(qty) FROM cteSource WHERE keterangan = 'CS' AND CONVERT(varchar(6),tanggal,112) < CONVERT(varchar(6),a.Thn,112) ),0)  " & _
        '    "				- ISNULL((SELECT SUM(qty) FROM cteSource WHERE keterangan = 'BO' AND CONVERT(varchar(6),tanggal,112) < CONVERT(varchar(6),a.Thn,112) ),0)  " & _
        '    "				- ISNULL((SELECT SUM(qty) FROM cteSource WHERE keterangan = 'RB' AND CONVERT(varchar(6),tanggal,112) < CONVERT(varchar(6),a.Thn,112) ),0)  " & _
        '    "				- ISNULL((SELECT SUM(qty) FROM cteSource WHERE keterangan = 'KK' AND CONVERT(varchar(6),tanggal,112) < CONVERT(varchar(6),a.Thn,112) ),0) AS QtyAwal " & _
        '    "		FROM ctethn a WHERE thn IS NOT NULL), " & _
        '    "	cteGabung as (select a.Keterangan, CONVERT(varchar(6),a.Thn,112) as Tanggal, '" & pKode & "' AS Kode, SUM(Qty) AS Qty       " & _
        '    "				FROM (SELECT a1.Thn, a2.keterangan FROM ctethn a1 CROSS JOIN cteJenis a2) a   " & _
        '    "				LEFT JOIN cteSource b ON convert(varchar(6),a.Thn,112) = convert(varchar(6),b.tanggal,112) AND a.keterangan = b.keterangan  " & _
        '    "				GROUP by a.Keterangan, b.Kode, CONVERT(varchar(6),a.Thn,112) " & _
        '    "	 			UNION ALL " & _
        '    "				SELECT 'AWAL' AS Keterangan, tanggal, '" & pKode & "' AS Kode, Qtyawal FROM cteawal " & _
        '    "           ) " & _
        '    "SELECT Kode, a.keterangan, SUBSTRING(Tanggal,3,2) + '-' + SUBSTRING(Tanggal,5,2) as Tanggal , ISNULL(a.Qty,0) AS Qty FROM cteGabung a ORDER BY a.Tanggal, a.keterangan DESC " & _
        '    "OPTION (MAXrecursion 0)"

        Dim pQue As String = _
            "WITH cteSource AS ( " & _
            "		SELECT keterangan ,kode ,tanggal ,qty from dbo.vwKartuArusStockRow where kode IN (SELECT Kode FROM dbo.mstStkSup WHERE KdBuku = '" & pKode & "') " & _
            "		), " & _
            "	cteThn AS (   " & _
            "		SELECT MIN(tanggal) AS Thn from cteSource " & _
            "		UNION ALL   " & _
            "		SELECT DATEADD(MONTH,1,Thn) FROM cteThn  WHERE CONVERT(VARCHAR(6),Thn,112) < CONVERT(VARCHAR(6),GETDATE(),112)  ),   " & _
            "	cteJenis AS (SELECT DISTINCT keterangan FROM cteSource),	 " & _
            "	cteTrans as (select a.Keterangan, CONVERT(varchar(6),a.Thn,112) as Tanggal, '" & pKode & "' AS Kode, SUM(Qty) AS Qty       " & _
            "				FROM (SELECT a1.Thn, a2.keterangan FROM ctethn a1 CROSS JOIN cteJenis a2) a   " & _
            "				LEFT JOIN cteSource b ON convert(varchar(6),a.Thn,112) = convert(varchar(6),b.tanggal,112) AND a.keterangan = b.keterangan  " & _
            "				GROUP by a.Keterangan, b.Kode, CONVERT(varchar(6),a.Thn,112) " & _
            "           ), " & _
            "   cteAwal AS ( " & _
            "			SELECT 'AWAL' AS Keterangan, CONVERT(varchar(6),Thn,112) as Tanggal, '" & pKode & "' AS Kode, " & _
            "				ISNULL((SELECT SUM(CASE WHEN keterangan IN ('PC','TK', 'CB', 'RJ', 'RK  ') THEN 1 ELSE -1 END * qty)  FROM cteTrans WHERE tanggal < CONVERT(varchar(6),a.Thn,112)),0) AS Qty " & _
            "			FROM cteThn a " & _
            "           ), " & _
            "	cteGabung AS ( " & _
            "			SELECT Keterangan, Tanggal, Kode, qty FROM cteTrans " & _
            "			UNION ALL " & _
            "           SELECT Keterangan, Tanggal, Kode, qty FROM cteAwal " & _
            "           ), " & _
            "   ctesum as ( " & _
            "           SELECT a.keterangan, Tanggal, sum(ISNULL(a.Qty,0)) AS Qty FROM cteGabung a Group by a.Tanggal, a.keterangan " & _
            "           ) " & _
            "SELECT a.keterangan, SUBSTRING(Tanggal,3,2) + '-' + SUBSTRING(Tanggal,5,2) as Tanggal , ISNULL(a.Qty,0) AS Qty FROM ctesum a ORDER BY a.Tanggal, a.keterangan DESC " & _
            "OPTION (MAXrecursion 0)"

        dbGrafik.FillMe(pQue, , , , 0)
        '--hapus yang tahun blnnya kosong
        Dim tgl = From row In dbGrafik.AsEnumerable()
            Select row.Field(Of String)("Tanggal") Distinct

        Dim th() As String = tgl.ToArray()

        For i As Integer = th.Length - 1 To 0 Step -1
            Dim dro() As DataRow = dbGrafik.Select("Tanggal = '" & th(i) & "' and Qty > 0 and keterangan <> 'AWAL'")
            If dro.Length > 0 Then
                Exit For
            Else
                dro = dbGrafik.Select("Tanggal = '" & th(i) & "' ")
                For j As Integer = dro.Length - 1 To 0 Step -1
                    dro(j).Delete()
                Next
            End If
        Next

        chart.DataSource = dbGrafik
        chart.SeriesDataMember = "keterangan"
        chart.SeriesTemplate.ArgumentDataMember = "Tanggal"
        chart.SeriesTemplate.ValueDataMembers.AddRange(New String() {"Qty"})
    End Sub

    Private Sub chart_DoubleClick(sender As Object, e As EventArgs) Handles chart.DoubleClick
        frmGrafikBig.callMe(dbGrafik, "keterangan", "Tanggal", "Qty")
    End Sub

    Private Sub chart_CustomDrawSeriesPoint(sender As Object, e As DevExpress.XtraCharts.CustomDrawSeriesPointEventArgs) Handles chart.CustomDrawSeriesPoint
        If e.SeriesPoint(0) < 1 Then
            e.LabelText = ""
        End If
    End Sub

    Private Sub chart_CustomDrawSeries(sender As Object, e As DevExpress.XtraCharts.CustomDrawSeriesEventArgs) Handles chart.CustomDrawSeries
        e.SeriesDrawOptions.Color = GetTransactionColor(e.Series.Name)
        e.LegendDrawOptions.Color = e.SeriesDrawOptions.Color
    End Sub

    Private Sub mdgList_Grid_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles mdgList.Grid_FocusedRowChanged
        RefreshGrafik(mdgList.GetRowCellValue(e.FocusedRowHandle, "KdBuku"))
    End Sub

    Private Sub mdgList_OnPopRefreshClickEnd() Handles mdgList.OnPopRefreshClickEnd
        filterstock.Enabled = True
        cmbRefreshData.Enabled = True
        lcgF.Enabled = True
    End Sub

    Private Sub ceQuery_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ceQuery.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub ceTransaksi_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.KeyChar = Chr(0)
    End Sub

    Private Sub mdgList_Load(sender As Object, e As EventArgs) Handles mdgList.Load

    End Sub

    Private Sub filterstock_Load(sender As Object, e As EventArgs) Handles filterstock.Load

    End Sub
End Class