﻿Imports Newtonsoft.Json
Imports System.IO
Imports System.Text
Imports System.Net
Imports FailureTroubleShooting.FTSClient.Dtos
Imports FailureTroubleShooting.FTSClient.Exceptions
Namespace Client
    ''' <summary>
    ''' 表示一个FTS的用户
    ''' </summary>
    Public Class Account
#Region "Private Members"
        Friend cookies As CookieContainer
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
        Public Function Login(Password As String, RememberMe As Boolean) As Boolean
            '判断是否登录
            If Me.IsLogin = True Then
                Throw New UserException(My.Resources.UserException_HasLogined)
            End If
            Dim ulo As New UserLoginDto() With {.UserName = Me.UserName, .Password = Password, .RememberMe = RememberMe}
            Dim rr As RequestResponse = NetHelper.SendToUrl("api/account/login", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(ulo)), Nothing, "POST")
            If rr.StatusCode = HttpStatusCode.Unauthorized Then
                Return False
            ElseIf rr.StatusCode = HttpStatusCode.NoContent Then
                Me.cookies = rr.Cookies
                Return True
            Else
                Throw New UserException(rr.StatusDescription)
            End If
        End Function

        ''' <summary>
        ''' 注销登录
        ''' </summary>
        Public Sub Logoff()
            '判断是否已经登录
            If Me.IsLogin = False Then
                Throw New UserException(My.Resources.UserException_HasLogoff)
            End If
            Dim rr As RequestResponse = NetHelper.RequestToUrl("api/account/logoff", Me.cookies, "POST")
            If Not rr.StatusCode = HttpStatusCode.NoContent Then
                Throw New UserException(rr.StatusDescription)
            End If
        End Sub

        ''' <summary>
        ''' 获取用户信息
        ''' </summary>
        Public Sub GetUserInfo()
            Dim rr As RequestResponse = NetHelper.RequestToUrl("api/account/myinfo", Me.cookies, "GET")
            If rr.StatusCode = HttpStatusCode.OK Then
                Dim info As UserInfoDto = JsonConvert.DeserializeObject(rr.Contents, GetType(UserInfoDto))
                Me.Id = info.Id
                Me.UserName = info.UserName
                Me.DisplayName = info.DisplayName
                Me.Grade = info.Grade
                Me.Class = info.Class
                Me.Roles = info.Roles
            Else
                Throw New UserException(rr.StatusDescription)
            End If
        End Sub

        ''' <summary>
        ''' 更换密码
        ''' </summary>
        ''' <param name="OldPassword">旧的密码</param>
        ''' <param name="NewPassword">新的密码</param>
        Public Function ChangePassword(OldPassword As String, NewPassword As String) As Boolean
            Dim ucp As New UserChangePasswordDto() With {.CurrentPassword = OldPassword, .NewPassword = NewPassword, .ConfirmPassword = NewPassword}
            Dim rr As RequestResponse = NetHelper.SendToUrl("api/account/ChangePassword", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(ucp)), Me.cookies, "POST")
            If rr.StatusCode = HttpStatusCode.Unauthorized Then
                Return False
            ElseIf rr.StatusCode = HttpStatusCode.Accepted Then
                Return True
            Else
                Throw New UserException(rr.StatusDescription)
            End If
        End Function

        ''' <summary>
        ''' 判断该用户是否已经登录
        ''' </summary>
        Public ReadOnly Property IsLogin As Boolean
            Get
                Try
                    Me.GetUserInfo()
                    Return True
                Catch ex As WebException
                    If ex.Status = WebExceptionStatus.ProtocolError Then Return False
                    Throw New UserException(ex.Message) '发生别的错误
                End Try
            End Get
        End Property
        Public Property Id As Integer
        Public Property UserName As String
        Public Property DisplayName As String
        Public Property Grade As Integer
        Public Property [Class] As Integer
        Public Property Roles As String()


#End Region
    End Class
End Namespace