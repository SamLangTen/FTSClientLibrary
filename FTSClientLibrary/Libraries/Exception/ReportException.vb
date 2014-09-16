Namespace Exceptions
    ''' <summary>
    ''' 表示在进行报表操作时遇到的错误
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ReportException
        Inherits Exception
        Sub New(Message As String)
            MyBase.New(Message)
        End Sub
        Sub New()

        End Sub
    End Class
End Namespace
