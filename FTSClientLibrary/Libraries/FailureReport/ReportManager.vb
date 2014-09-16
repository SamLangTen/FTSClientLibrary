Imports Newtonsoft.Json
Imports System.IO
Imports System.Text
Imports System.Net
Imports FailureTroubleShooting.FTSClient.Dtos
Imports FailureTroubleShooting.FTSClient.Exceptions
Namespace Client
    ''' <summary>
    ''' 用于管理报表
    ''' </summary>
    Public Class ReportManager
        ''' <summary>
        ''' 用于保存操作的用户
        ''' </summary>
        Private actionAccount As Account

        ''' <summary>
        ''' 通过账号来创建报表管理器
        ''' </summary>
        ''' <param name="AuthorizationAccount">用于操作的账户</param>
        Sub New(AuthorizationAccount As Account)
            Me.actionAccount = AuthorizationAccount
        End Sub

        ''' <summary>
        ''' 获取所有提交的报表
        ''' </summary>
        Public Function GetSubmittedReports(Query As String) As FailureReport()
            If actionAccount.Roles Is Nothing AndAlso actionAccount.Roles.Contains("Reporter") = False Then Throw New UserException(My.Resources.UserException_NoPermission)
            Dim rr As RequestResponse = NetHelper.RequestToUrl("api/FailureReports/MyReports" + If(Query = "", "", "?") + Query, Me.actionAccount.cookies, "GET")
            If rr.StatusCode <> HttpStatusCode.OK Then Throw New ReportException(rr.StatusDescription)
            Dim reports As List(Of FailureReportDto) = JsonConvert.DeserializeObject(rr.Contents, GetType(List(Of FailureReportDto)))
            '获取所有的FailureTypes
            Dim ft As FailureType() = FailureType.GetFailureTypes(Me.actionAccount)
            '读取
            Dim repos = (From item In reports Select New FailureReport With {.Class = item.Class,
                                                                             .Grade = item.Grade,
                                                                             .Id = item.Id,
                                                                             .MaintenanceStaffName = item.MaintenanceStaffName,
                                                                             .MaintenanceStaffId = item.MaintenanceStaffId,
                                                                             .ReporterName = item.ReporterName,
                                                                             .State = [Enum].Parse(GetType(ReportStateEnum), item.State),
                                                                             .Time = item.Time,
                                                                             .Title = item.Title,
                                                                             .Feedback = (Function()
                                                                                              If item.FeedbackId Is Nothing Then Return Nothing
                                                                                              Dim rr2 As RequestResponse = NetHelper.RequestToUrl("api/FailureReports/" + item.Id.ToString() + "/Feedback", actionAccount.cookies, "GET")
                                                                                              Dim fbdto As FeedbackDto = JsonConvert.DeserializeObject(rr2.Contents, GetType(FeedbackDto))
                                                                                              Return New FeedbackItem() With {.Comment = fbdto.Comment, .IsFinished = fbdto.IsFinished, .Rate = fbdto.Rate}
                                                                                          End Function).Invoke(),
            .Items = (From i In item.Items Select New FailureItem With {.Count = i.Count, .Detail = i.Detail, .Type = ft.SingleOrDefault(Function(r) r.Id = i.TypeId)}).ToArray()
                                                                            })
            Return repos.ToArray()
        End Function

        ''' <summary>
        ''' 获取所有提交的报表
        ''' </summary>
        Public Function GetSubmittedReports() As FailureReport()
            Return Me.GetSubmittedReports("")
        End Function

        ''' <summary>
        ''' t提交一份
        ''' </summary>
        ''' <param name="Report"></param>
        ''' <remarks></remarks>
        Public Sub SubmitReport(Report As FailureReport)

        End Sub

    End Class
End Namespace