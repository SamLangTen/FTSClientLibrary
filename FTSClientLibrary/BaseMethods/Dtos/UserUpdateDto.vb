Namespace Dtos

    Friend Class UserUpdateDto
        Public Property Id As Integer
        Public Property UserName As String
        Public Property DisplayName As String
        Public Property Grade As Integer
        Public Property [Class] As Integer
        Public Property Roles As String()
        Public Property IsEnabled As Boolean
    End Class
End Namespace