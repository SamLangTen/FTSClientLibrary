Imports Newtonsoft.Json
Imports System.IO
Imports System.Text
Imports System.Net
Imports FailureTroubleShooting.FTSClient.Dtos
Imports FailureTroubleShooting.FTSClient.Exceptions
Namespace Client
    Public Class FailureReport
        Public Property Id As Integer
        Public Property Time As DateTime
        Public Property Title As String
        Public Property ReporterName As String
        Public Property MaintenanceStaffId As Integer?
        Public Property MaintenanceStaffName As String
        Public Property State As ReportStateEnum
        Public Property Grade As Integer
        Public Property [Class] As Integer
        Public Property Feedback As FeedbackItem
        Public Property Items As FailureItem()

    End Class
End Namespace