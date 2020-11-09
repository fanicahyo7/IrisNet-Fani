Imports System.Net
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
End Class