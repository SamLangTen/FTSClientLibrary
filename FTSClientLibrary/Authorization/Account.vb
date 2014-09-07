Imports Newtonsoft.Json
Imports System.IO
Imports System.Text
Imports System.Net
Imports FTSClientLibrary.Dtos
Imports FTSClientLibrary.Exceptions
Namespace Authorization
    ''' <summary>
    ''' 表示一个FTS的用户
    ''' </summary>
    Public Class Account
#Region "Private Members"
        Private cookies As CookieContainer
#End Region
#Region "Public Members"

        ''' <summary>
        ''' 通过用户名创建一个FTS账户对象
        ''' </summary>
        ''' <param name="UserName">用户名</param>
        Sub New(UserName As String)
            Me.UserName = UserName
        End Sub

        ''' <summary>
        ''' 登录到FailureTroubleShooting
        ''' </summary>
        ''' <param name="Password">账户的密码</param>
        ''' <param name="RememberMe">是否保持登录状态</param>
        Public Sub Login(Password As String, RememberMe As Boolean)
            Dim ulo As New UserLoginDto() With {.UserName = Me.UserName, .Password = Password, .RememberMe = RememberMe}
            Dim rr As RequestResponse = NetHelper.SendToUrl("api/account/login", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(ulo)), Nothing, "POST")
            If Not rr.StatusCode = HttpStatusCode.NoContent Then
                Throw New UserException(rr.StatusDescription)
            Else
                Me.cookies = rr.Cookies
            End If
        End Sub

        ''' <summary>
        ''' 注销登录
        ''' </summary>
        Public Sub Logoff()
            Dim rr As RequestResponse = NetHelper.RequestToUrl("api/account/logoff", Me.cookies, "POST")
            If Not rr.StatusCode = HttpStatusCode.NoContent Then
                Throw New UserException(rr.StatusDescription)
            End If
        End Sub

        Public Property Id As Integer
        Public Property UserName As String
        Public Property DisplayName As String
        Public Property Grade As Integer
        Public Property [Class] As Integer
        Public Property Roles As String()


#End Region
    End Class
End Namespace