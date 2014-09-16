Imports Newtonsoft.Json
Imports System.IO
Imports System.Text
Imports System.Net
Imports FailureTroubleShooting.FTSClient.Dtos
Imports FailureTroubleShooting.FTSClient.Exceptions
Namespace Client
    Public Class FeedbackItem
        Public Property IsFinished As Boolean
        Public Property Comment As String
        Public Property Rate As Integer
    End Class
End Namespace