Imports Newtonsoft.Json
Imports System.IO
Imports System.Text
Imports System.Net
Imports FailureTroubleShooting.FTSClient.Dtos
Imports FailureTroubleShooting.FTSClient.Exceptions
Namespace Client
    Public Class FailureType

        ''' <summary>
        ''' 获取所有的故障类型
        ''' </summary>
        ''' <param name="AuthorizationAccount">进行此操作的账户</param>
        Public Shared Function GetFailureTypes(AuthorizationAccount As Account) As FailureType()
            Dim rr As RequestResponse = NetHelper.RequestToUrl("api/FailureTypes", AuthorizationAccount.cookies, "GET")
            If rr.StatusCode <> HttpStatusCode.OK Then Throw New UserException(rr.StatusDescription)
            Dim list As List(Of FailureTypeDto) = JsonConvert.DeserializeObject(rr.Contents, GetType(List(Of FailureTypeDto)))
            Dim query = (From item In list Select New FailureType() With {.AuthorizationAccount = AuthorizationAccount, .Description = item.Description, .Id = item.Id, .IsEnabled = item.IsEnabled, .Name = item.Name})
            Return query.ToArray()
        End Function

        ''' <summary>
        ''' 创建一个新的故障类型
        ''' </summary>
        ''' <param name="Info">保存着故障类型的FailureType类型</param>
        ''' <param name="AuthorizationAccount">进行操作的账户</param>
        Public Shared Sub CreateFailureType(Info As FailureType, AuthorizationAccount As Account)
            Dim ftd As New FailureTypeDto With {.Description = Info.Description, .Name = Info.Name, .Id = Info.Id, .IsEnabled = Info.IsEnabled}
            Dim rr As RequestResponse = NetHelper.SendToUrl("api/FailureTypes", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(ftd)), AuthorizationAccount.cookies, "POST")
            If rr.StatusCode <> HttpStatusCode.Created Then Throw New FailureTypeException(rr.StatusDescription)
        End Sub

        ''' <summary>
        ''' 保存故障类型的更改
        ''' </summary>
        Public Sub SaveChanges()
            Dim ftd As New FailureTypeDto With {.Description = Me.Description, .Name = Me.Name, .Id = Me.Id, .IsEnabled = Me.IsEnabled}
            Dim rr As RequestResponse = NetHelper.SendToUrl("api/FailureTypes", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(ftd)), Me.AuthorizationAccount.cookies, "PUT")
            If rr.StatusCode <> HttpStatusCode.Created Then Throw New FailureTypeException(rr.StatusDescription)
        End Sub

        ''' <summary>
        ''' 用于操作的账户
        ''' </summary>
        Public Property AuthorizationAccount As Account

        Public Property Id As String
        Public Property Name As String
        Public Property Description As String
        Public Property IsEnabled As String

    End Class
End Namespace