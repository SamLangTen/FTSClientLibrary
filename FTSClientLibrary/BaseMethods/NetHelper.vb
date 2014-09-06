Imports System.Net
Imports System.IO
Imports System.Text
Imports Newtonsoft.Json
Imports FTSClientLibrary.Connection
Friend Class NetHelper

    Friend Shared Function PostToUrl(Url As String, Data As Byte(), Cookies As CookieContainer) As RequestResponse
        Dim rq As HttpWebRequest = HttpWebRequest.Create(ConnectionSetting.DomainName + "/" + Url)
        rq.CookieContainer = Cookies
        rq.Method = "POST"
        rq.ContentType = "text/json"
        rq.ContentLength = Data.Length
        rq.GetRequestStream().Write(Data, 0, Data.Length)
        Dim rqq As HttpWebResponse = rq.GetResponse()
        Return New RequestResponse() With {.Contents = New StreamReader(rqq.GetResponseStream()).ReadToEnd(), .StatusCode = rqq.StatusCode, .StatusDescription = rqq.StatusDescription, .Cookies = rq.CookieContainer}
    End Function
    Friend Shared Function GetToUrl(Url As String, Cookies As CookieContainer) As RequestResponse
        Dim rq As HttpWebRequest = HttpWebRequest.Create(ConnectionSetting.DomainName + "\" + Url)
        rq.CookieContainer = Cookies
        rq.Method = "GET"
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