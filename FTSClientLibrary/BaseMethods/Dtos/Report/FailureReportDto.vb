Namespace Dtos
    Friend Class FailureReportDto
        Public Property Id As Integer
        Public Property Time As DateTime
        Public Property Title As String
        Public Property ReporterName As String
        Public Property MaintenanceStaffId As Integer
        Public Property MaintenanceStaffName As String
        Public Property State As String
        Public Property Grade As Integer
        Public Property [Class] As Integer
        Public Property FeedbackId As Integer
        Public Property Items As List(Of FailureItemDto)
    End Class
End Namespace
