Namespace Exceptions
    ''' <summary>
    ''' 表示进行故障类型操作时所触发的错误
    ''' </summary>
    Public Class FailureTypeException
        Inherits System.Exception
        Sub New(Message As String)
            MyBase.New(Message)
        End Sub
        Sub New()

        End Sub
    End Class
End Namespace
