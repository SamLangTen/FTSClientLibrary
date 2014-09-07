Imports Newtonsoft.Json
Imports System.IO
Imports System.Text
Imports System.Net
Imports FTSClientLibrary.Dtos
Imports FTSClientLibrary.Exceptions
Namespace Client
    ''' <summary>
    ''' 表示一个待管理的用户
    ''' </summary>
    Public Class User
        Public Property Id As Integer
        Public Property UserName As String
        Public Property DisplayName As String
        Public Property Grade As Integer
        Public Property [Class] As Integer
        Public Property IsEnabled As Boolean
        Public Property Roles As String()
    End Class
End Namespace