Imports Newtonsoft.Json
Imports System.IO
Imports System.Text
Imports System.Net
Imports FailureTroubleShooting.FTSClient.Dtos
Imports FailureTroubleShooting.FTSClient.Exceptions
Namespace Client
    ''' <summary>
    ''' 表示一个待管理的用户
    ''' </summary>
    Public Class User

        ''' <summary>
        ''' 创建一个用户
        ''' </summary>
        ''' <param name="Info">保存新用户的信息</param>
        ''' <param name="AuthorizationAccount">操作的账户</param>
        ''' <param name="Password">密码</param>
        Public Shared Sub CreateUser(Info As User, Password As String, AuthorizationAccount As Account)
            Dim ucd As New UserCreationDto() With {.Class = Info.Class, .DisplayName = Info.DisplayName, .Grade = Info.Grade, .Password = Password, .Roles = Info.Roles, .UserName = Info.UserName}
            Dim rr As RequestResponse = NetHelper.SendToUrl("api/Identity/Users", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(ucd)), AuthorizationAccount.cookies, "POST")
            If rr.StatusCode <> HttpStatusCode.Accepted Then Throw New UserException(rr.StatusDescription)

        End Sub

        ''' <summary>
        ''' 获取所有的用户
        ''' </summary>
        Public Shared Function GetUsers(AuthorizationAccount As Account) As User()
            Dim rr As RequestResponse = NetHelper.RequestToUrl("api/Identity/Users", AuthorizationAccount.cookies, "GET")
            If rr.StatusCode <> HttpStatusCode.OK Then Throw New UserException(rr.StatusDescription)
            Dim list As List(Of UserInfoDto) = JsonConvert.DeserializeObject(rr.Contents, GetType(List(Of UserInfoDto)))
            Dim query = (From item In list Select New User() With {.Grade = item.Grade, .Class = item.Class, .DisplayName = item.DisplayName, .Id = item.Id, .IsEnabled = item.IsEnable, .Roles = item.Roles, .UserName = item.UserName, .AuthorizationAccount = AuthorizationAccount})
            Return query.ToArray()
        End Function

        ''' <summary>
        ''' 用于操作用户的账号
        ''' </summary>
        Public Property AuthorizationAccount As Account

        ''' <summary>
        ''' 设置一个用户的密码
        ''' </summary>
        ''' <param name="Password">新密码</param>
        ''' <remarks></remarks>
        Public Sub SetPassword(Password As String)
            Dim rr As RequestResponse = NetHelper.SendToUrl("api/Identity/Users/" + Me.Id.ToString() + "/SetPassword", Encoding.UTF8.GetBytes("{""password"": """ + Password + """,""confirmPassword"": """ + Password + """}"), Me.AuthorizationAccount.cookies, "PUT")
            If rr.StatusCode <> HttpStatusCode.Accepted Then Throw New UserException(rr.StatusDescription)
        End Sub

        ''' <summary>
        ''' 更新一个用户的信息
        ''' </summary>
        Public Sub SaveChanges()
            Dim uud As New UserUpdateDto() With {.Class = Me.Class, .DisplayName = Me.DisplayName, .Grade = Me.Grade, .Roles = Me.Roles, .UserName = Me.UserName, .Id = Me.Id, .IsEnabled = Me.IsEnabled}
            Dim rr As RequestResponse = NetHelper.SendToUrl("api/Identity/Users", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(uud)), Me.AuthorizationAccount.cookies, "PUT")
            If rr.StatusCode <> HttpStatusCode.Accepted Then Throw New UserException(rr.StatusDescription)
        End Sub

        Public Property Id As Integer
        Public Property UserName As String
        Public Property DisplayName As String
        Public Property Grade As Integer
        Public Property [Class] As Integer
        Public Property IsEnabled As Boolean
        Public Property Roles As String()


    End Class
End Namespace