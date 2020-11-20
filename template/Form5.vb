Imports System.Net
Imports System.IO
'Imports Jayrock.Json
'Imports Jayrock.Json.Conversion
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Form5

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        ServicePointManager.Expect100Continue = True
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        'Dim remoteUri As String = "https://cdn.idntimes.com/content-images/post/20200917/"
        'Dim fileName As String = "109583333-699536190624107-3298774336813760778-n-f309ea18bd84b272d2b778dae85f22aa.jpg"
        Dim remoteUri As String = "https://file-examples-com.github.io/uploads/2017/02/"
        Dim fileName As String = "file_example_XLS_10.xls"
        Dim myStringWebResource As String = Nothing
        myStringWebResource = remoteUri + fileName
        'My.Computer.Network.DownloadFile(myStringWebResource, fileName)

        Dim myWebClient As New WebClient
        myWebClient.DownloadFile(myStringWebResource, fileName)
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Dim url As String = "http://foodmarketbwa.fanicahyo.id/api/food/"
        Dim req As HttpWebRequest
        Dim res As HttpWebResponse
        Dim reader As StreamReader
        Dim str As String

        req = WebRequest.Create(url)

        'req.Headers.Add("Authorization", "Bearer " + "AKSES TOKEN")

        res = req.GetResponse()
        If (res.StatusCode = 200) Then
            reader = New StreamReader(res.GetResponseStream())
            str = reader.ReadLine()

            'single user
            'Dim jsonObject = Newtonsoft.Json.Linq.JObject.Parse(str)
            'TextBox1.Text = jsonObject.SelectToken("data.email").ToString

            'list user
            'Dim jsonObject = Newtonsoft.Json.Linq.JObject.Parse(str)
            'For a = 0 To jsonObject.Count - 1
            '    TextBox1.Text += jsonObject.SelectToken("data[" & a & "].email").ToString + vbCrLf
            'Next

            'ke data tabel
            Dim Table1 As DataTable
            Table1 = New DataTable("TableUser")

            Dim id As DataColumn = New DataColumn("id")
            id.DataType = System.Type.GetType("System.String")
            Dim name As DataColumn = New DataColumn("name")
            name.DataType = System.Type.GetType("System.String")
            Dim description As DataColumn = New DataColumn("description")
            description.DataType = System.Type.GetType("System.String")
            Dim price As DataColumn = New DataColumn("price")
            price.DataType = System.Type.GetType("System.Int32")
            Table1.Columns.Add(id)
            Table1.Columns.Add(name)
            Table1.Columns.Add(description)
            Table1.Columns.Add(price)

            Dim jsonObject As JObject = Newtonsoft.Json.Linq.JObject.Parse(str)

            Dim objresult = jsonObject.SelectToken("data")("data")


            For a = 0 To objresult.Count - 1

                'Dim Row1 As DataRow
                'Row1 = Table1.NewRow
                'Row1.Item("id") = jsonObject.SelectToken("data[" & a & "].id").ToString
                'Row1.Item("email") = jsonObject.SelectToken("data[" & a & "].email").ToString
                'Row1.Item("first_name") = jsonObject.SelectToken("data[" & a & "].first_name").ToString

                'Table1.Rows.Add(Row1)

                'Table1.Rows.Add({jsonObject.SelectToken("data[data[" & a & "].id]"), jsonObject.SelectToken("data[" & a & "].name"), jsonObject.SelectToken("data[" & a & "].description"), jsonObject.SelectToken("data[" & a & "].price")})
                Table1.Rows.Add({objresult.SelectToken("[" & a & "].id"), objresult.SelectToken("[" & a & "].name"), objresult.SelectToken("[" & a & "].description"), objresult.SelectToken("[" & a & "].price")})
            Next

            CtrlMeDataGrid1.DataSource = Table1
            CtrlMeDataGrid1.RefreshDataView()
        Else
            MsgBox("Gagal Ambil Data", vbCritical + vbOKOnly, "Peringatan")
        End If
    End Sub
End Class