Imports Newtonsoft.Json
Imports System.IO
Imports System.Text
Imports System.Net

Namespace Authorization
    ''' <summary>
    ''' 表示一个FTS的用户
    ''' </summary>
    Public Class Account
#Region "Private Members"

#End Region
#Region "Public Members"

        ''' <summary>
        ''' 登录到FailureTroubleShooting
        ''' </summary>
        ''' <param name="Password"></param>
        ''' <param name="RememberMe"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Login(Password As String, RememberMe As Boolean)

        End Function

        Public Property Id As Integer
        Public Property UserName As String
        Public Property DisplayName As String
        Public Property Grade As Integer
        Public Property [Class] As Integer
        Public Property Roles As String()


#End Region
    End Class
End Namespace