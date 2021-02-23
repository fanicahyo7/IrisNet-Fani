
Imports meCore

Module modIris
    Public Enum infDefault
        infKodePers = 0
        infInitBarcode = 1
        infPPN = 2

        infKetPembelianOrder = 3
        infKetPembelian = 4
        infKetPembelianRetur = 5
        infKetTerimaKonsi = 6
        infKetTerimaKonsRetur = 7

        infKetSuratPenawaran = 8
        infKetPenjualan = 9
        infKetPenjualanRetur = 10
        infKetKirimKonsi = 11
        infKetKirimKonsiRetur = 12

        infMinStock = 13
        infMaxStock = 14

        infStruk1 = 15
        infStruk2 = 16
        infStruk3 = 17
        infStruk4 = 18
        infStruk5 = 19
        infKelipatan = 20
        infKupon1 = 21
        infKupon2 = 22
        infLeftMarginBarcode = 23
        infGudTokoDefault = 24
        infGudGudangDefault = 25
        infGudReturDefault = 26

        infOldDB = 27

        Drawer = 28

        KunciReturKonsinyasi = 29

        infKodeWilayah = 30

        infBPCQtyLimit = 31
        infBPCMarginDisc = 32
        infBPCDiscMax = 33

        infKuponKodeBuku = 34

        infHarusBarcode = 35
        infLevelSupervisor = 36
        infMutasiBebas = 37
        infFakturJualUnlock = 38
        infTglGaransi = 39
        infMembership = 40

        infNoBuktiPelunasan = 41
        infEmailOmzet = 42
        infEmailOmzetPws = 43

        infAutoCutter = 44
        infPrinterBarcode = 45
        infPrinterName = 46
        infPortPrinter = 47
        infPortKasir = 48
        infPortBarcode = 49
        infToFile = 50

        infPrintNpwp = 51
        infPrintGaris = 52

        infPrinterBarcodeTemplate = 53
    End Enum

    Public Function GetKeteranganStDefault(kode As infDefault) As String
        Dim pRet As String
        Dim pQue As String = "SELECT isnull(Keterangan,'') as Keterangan FROM dbo.stDefault WHERE Kode = '" & kode & "'"
        Using dbtmp As New cMeDB
            dbtmp.FillMe(pQue)
            pRet = dbtmp.Rows(0)(0)
        End Using
        Return pRet
    End Function

    Public Function GetUserIrisInitial(UserID As String) As String
        Dim pRet As String = Nothing
        Using db As New cMeDB
            Dim pQue As String = "SELECT [Initial] as Inisial FROM dbo.UserLogin WHERE UserName = '" & UserID & "'"
            db.FillMe(pQue)
            If db.Rows.Count > 0 Then
                pRet = db.Rows(0)(0)
            End If
        End Using
        Return pRet
    End Function

    Function CheckDigit_ean13(data As String) As String
        Dim TEST_DATA = data
        Dim strParts() As String
        Dim lngIndex As Long
        Dim intTotal As Integer
        Dim intCount As Integer
        Dim intUp As Integer

        ReDim strParts(data.Length)
        For i As Integer = 0 To data.Length
            strParts(i) = Mid(data, i + 1, 1)
        Next
        'strParts = Split(TEST_DATA, "")

        For lngIndex = UBound(strParts) - 1 To 0 Step -2
            For intCount = 1 To 3
                intTotal = intTotal + strParts(lngIndex)
            Next
        Next
        On Error Resume Next
        For lngIndex = UBound(strParts) To 0 Step -2
            intTotal = intTotal + strParts(lngIndex)
        Next
        On Error GoTo 0

        intUp = intTotal
        Do Until intUp Mod 10 = 0
            intUp = intUp + 1
        Loop

        strParts(UBound(strParts)) = intUp - intTotal

        Return (Join(strParts, ""))
    End Function

    Public Function GetTransactionColor(Jenis As String) As Color
        Dim pRet As Color
        Select Case Jenis
            Case "P1" : pRet = Color.LightSalmon
            Case "P2" : pRet = Color.CadetBlue
            Case "O1" : pRet = Color.Chartreuse
            Case "O2" : pRet = Color.Magenta
            Case "PC" : pRet = Color.Aquamarine
            Case "RB" : pRet = Color.Yellow
            Case "TK" : pRet = Color.Green
            Case "RT" : pRet = Color.Purple
            Case "CS", "cCS>0" : pRet = Color.Blue
            Case "CB" : pRet = Color.Brown
            Case "BO", "SL", "cBO>0" : pRet = Color.IndianRed
            Case "RJ" : pRet = Color.LimeGreen
            Case "KK" : pRet = Color.Silver
            Case "RK" : pRet = Color.Orange
            Case "NP", "JudulSaldo>0" : pRet = Color.Cyan
            Case "AWAL" : pRet = Color.Tomato
            Case "EfektivitasCS" : pRet = Color.Red
        End Select
        'JudulSaldo>0','CountCS>0','CountBO>0
        Return pRet
    End Function

    Public Function getSQLConIni(ByVal parPathNFileName As String) As String
        Dim FILE_NAME As String = parPathNFileName
        Dim TextLine As String = "File Does Not Exist"
        If System.IO.File.Exists(FILE_NAME) = True Then
            Using objReader As New System.IO.StreamReader(FILE_NAME)
                Do While objReader.Peek() <> -1
                    TextLine = objReader.ReadLine()
                Loop
            End Using
        End If
        Return DecryptWithClipper(TextLine, "dante")
    End Function

End Module
