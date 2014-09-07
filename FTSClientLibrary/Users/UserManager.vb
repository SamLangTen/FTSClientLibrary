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
    Public Class UserManger
#Region "Private Members"
        Private actionAccount As Account
#End Region
#Region "Public Members"
        ''' <summary>
        ''' 从一个可用的账户里创建UserManager
        ''' </summary>
        ''' <param name="ActionAccount">可用的账户</param>
        Sub New(ActionAccount As Account)

        End Sub

#End Region
    End Class

End Namespace
