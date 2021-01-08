Imports System.Data.Sql
Imports System.Data.SqlClient
Imports meCore
Module Module1
    Public cmd As SqlCommand
    Public kon As SqlConnection
    Public rd As SqlDataReader
    Public da As SqlDataAdapter
    Public ds As DataSet
    Public dt As DataTable

    Sub koneksi(Optional connstr As String = Nothing)
        If connstr Is Nothing Then connstr = meCore.PubConnStr
        'kon = New SqlConnection("data source=FANI; initial catalog=TM601KEDIRI; uid=sa; password=gogogo")
        kon = New SqlConnection(connstr)
        If kon.State = ConnectionState.Closed Then
            kon.Open()
        End If
    End Sub

    'Sub koneksi()
    '    'kon = New SqlConnection("data source=FANI; initial catalog=TM601KEDIRI; uid=sa; password=gogogo")
    '    kon = New SqlConnection(PubConnStr)
    '    If kon.State = ConnectionState.Closed Then
    '        kon.Open()
    '    End If
    'End Sub
End Module
