Namespace Exceptions
    ''' <summary>
    ''' 表示用户操作时所触发的错误
    ''' </summary>
    Public Class UserException
        Inherits System.Exception
        Sub New(Message As String)
            MyBase.New(Message)
        End Sub
        Sub New()

        End Sub
    End Class
End Namespace
