Imports Newtonsoft.Json
Imports System.IO
Imports System.Text
Imports System.Net
Imports FailureTroubleShooting.FTSClient.Dtos
Imports FailureTroubleShooting.FTSClient.Exceptions
Namespace Client
    Public Class FailureItem
        Public Property Type As FailureType
        Public Property Detail As String
        Public Property Count As Integer
    End Class
End Namespace

