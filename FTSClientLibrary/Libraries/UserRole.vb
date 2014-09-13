Imports Newtonsoft.Json
Imports System.IO
Imports System.Text
Imports System.Net
Imports FailureTroubleShooting.FTSClient.Dtos
Imports FailureTroubleShooting.FTSClient.Exceptions
Namespace Client
    ''' <summary>
    ''' 表示一个待管理的用户角色
    ''' </summary>
    Public Class UserRole

        ''' <summary>
        ''' 获取所有可用的用户角色
        ''' </summary>
        ''' <param name="AuthorizationAccount">操作此动作的账户</param>
        Public Shared Function GetRoles(AuthorizationAccount As Account) As UserRole()
            Dim rr As RequestResponse = NetHelper.RequestToUrl("api/Identity/Roles", AuthorizationAccount.cookies, "GET")
            Dim roles As List(Of UserRoleDto) = JsonConvert.DeserializeObject(rr.Contents, GetType(List(Of UserRoleDto)))
            Dim list = (From item In roles Select New UserRole With {.Description = item.Description, .Name = item.Name})
            Return list.ToArray()
        End Function

        Public Property Name As String
        Public Property Description As String

    End Class
End Namespace