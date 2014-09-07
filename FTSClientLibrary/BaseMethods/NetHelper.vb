Imports System.Net
Imports System.IO
Imports System.Text
Imports Newtonsoft.Json
Imports FTSClientLibrary.Connection
Friend Class NetHelper

    Friend Shared Function SendToUrl(Url As String, Data As Byte(), Cookies As CookieContainer, Method As String) As RequestResponse
        Dim rq As HttpWebRequest = HttpWebRequest.Create(ConnectionSetting.DomainName + "/" + Url)
        If Cookies IsNot Nothing Then
            rq.CookieContainer = Cookies
        Else
            rq.CookieContainer = New CookieContainer()
        End If
        rq.Method = Method
        rq.ContentType = "text/json"
        rq.ContentLength = Data.Length
        rq.GetRequestStream().Write(Data, 0, Data.Length)
        Dim rqq As HttpWebResponse = rq.GetResponse()
        Return New RequestResponse() With {.Contents = New StreamReader(rqq.GetResponseStream()).ReadToEnd(), .StatusCode = rqq.StatusCode, .StatusDescription = rqq.StatusDescription, .Cookies = rq.CookieContainer}
    End Function
    Friend Shared Function RequestToUrl(Url As String, Cookies As CookieContainer, Method As String) As RequestResponse
        Dim rq As HttpWebRequest = HttpWebRequest.Create(ConnectionSetting.DomainName + "/" + Url)
        rq.CookieContainer = Cookies
        rq.Method = Method
        If Method <> "GET" Then
            rq.ContentLength = 0
        End If
        Dim rqq As HttpWebResponse = rq.GetResponse()
        Return New RequestResponse() With {.Contents = New StreamReader(rqq.GetResponseStream()).ReadToEnd(), .StatusCode = rqq.StatusCode, .StatusDescription = rqq.StatusDescription, .Cookies = rq.CookieContainer}
    End Function

End Class

Friend Class RequestResponse
    Public Property Contents As String
    Public Property StatusCode As HttpStatusCode
    Public Property StatusDescription As String
    Public Property Cookies As CookieContainer
End Class