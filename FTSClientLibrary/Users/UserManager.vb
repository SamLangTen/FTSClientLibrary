Imports Newtonsoft.Json
Imports System.IO
Imports System.Text
Imports System.Net
Imports FTSClientLibrary.Dtos
Imports FTSClientLibrary.Exceptions
Namespace Client
    ''' <summary>
    ''' 表示一个用户管理器
    ''' </summary>
    Public Class UserManger
#Region "Private Members"
        Private actionAccount As Account
#End Region
#Region "Public Members"
        ''' <summary>
        ''' 从一个可用的账户里创建UserManager
        ''' </summary>
        ''' <param name="ActionAccount">可用的账户</param>
        Sub New(ActionAccount As Account)
            Me.actionAccount = ActionAccount
        End Sub

        ''' <summary>
        ''' 创建一个用户
        ''' </summary>
        ''' <param name="Info">保存新用户的信息</param>
        Public Sub CreateUser(Info As User, Password As String)
            Dim ucd As New UserCreationDto() With {.Class = Info.Class, .DisplayName = Info.DisplayName, .Grade = Info.Grade, .Password = Password, .Roles = Info.Roles, .UserName = Info.UserName}
            Dim rr As RequestResponse = NetHelper.SendToUrl("api/Identity/Users", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(ucd)), Me.actionAccount.cookies, "POST")
            If rr.StatusCode <> HttpStatusCode.Accepted Then Throw New UserException(rr.StatusDescription)

        End Sub

        ''' <summary>
        ''' 更新一个用户的信息
        ''' </summary>
        ''' <param name="Info">用户的信息</param>
        Public Sub UpdateUser(Info As User)
            Dim uud As New UserUpdateDto() With {.Class = Info.Class, .DisplayName = Info.DisplayName, .Grade = Info.Grade, .Roles = Info.Roles, .UserName = Info.UserName, .Id = Info.Id, .IsEnabled = Info.IsEnabled}
            Dim rr As RequestResponse = NetHelper.SendToUrl("api/Identity/Users", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(uud)), Me.actionAccount.cookies, "PUT")
            If rr.StatusCode <> HttpStatusCode.Accepted Then Throw New UserException(rr.StatusDescription)
        End Sub

#End Region
    End Class

End Namespace
