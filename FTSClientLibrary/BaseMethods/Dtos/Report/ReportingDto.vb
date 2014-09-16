Namespace Dtos
    Friend Class ReportingDto
        Public Property Id As Integer
        Public Property Time As DateTime
        Public Property ItemsTypes As String
        Public Property Items As List(Of FailureItemDto)
        Public Property Title As String
        Public Property ReporterName As String
        Public Property MaintenanceStaffName As String
        Public Property State As String
        Public Property [Class] As Integer
        Public Property Grade As Integer
        Public Property IsFinished As Boolean
        Public Property FeedbackRate As Integer
        Public Property FeedbackComment As String
    End Class
End Namespace
