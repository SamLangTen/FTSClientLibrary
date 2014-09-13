﻿Imports Newtonsoft.Json
Imports System.IO
Imports System.Text
Imports System.Net
Imports FailureTroubleShooting.FTSClient.Dtos
Imports FailureTroubleShooting.FTSClient.Exceptions
Namespace Client
    ''' <summary>
    ''' 用于管理报表
    ''' </summary>
    Public Class ReportManager
        ''' <summary>
        ''' 用于保存操作的用户
        ''' </summary>
        Private actionAccount As Account

        ''' <summary>
        ''' 通过账号来创建报表管理器
        ''' </summary>
        ''' <param name="AuthorizationAccount">用于操作的账户</param>
        Sub New(AuthorizationAccount As Account)
            Me.actionAccount = AuthorizationAccount
        End Sub

        ''' <summary>
        ''' 获取所有提交的报表
        ''' </summary>
        Public Function GetSubmittedReports(Query As String) As FailureReport()

        End Function

        ''' <summary>
        ''' 获取所有提交的报表
        ''' </summary>
        Public Function GetSubmittedReports() As FailureReport()
            Return Me.GetSubmittedReports("")
        End Function

    End Class
End Namespace