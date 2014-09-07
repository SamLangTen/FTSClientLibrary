﻿Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports FTSClientLibrary.Connection
Imports FTSClientLibrary.Client
<TestClass()> Public Class UserManagerTest

    <TestMethod()> Public Sub TestUserCreation()
        ConnectionSetting.DomainName = "http://failuretest.chinacloudsites.cn"
        Dim acc As New Account("sms")
        acc.Login("1111111", True)
        Dim uc As New User()
        uc.DisplayName = "李婧怡"
        uc.UserName = "jylee"
        uc.Roles = {"Administrator", "Reporter"}
        uc.Grade = 1
        uc.Class = 23
        Dim um As New UserManger(acc)
        um.CreateUser(uc, "1111111")
    End Sub
    <TestMethod()> Public Sub TestUserUpdate()
        ConnectionSetting.DomainName = "http://failuretest.chinacloudsites.cn"
        Dim acc As New Account("sms")
        acc.Login("1111111", True)
        Dim uc As New User()
        uc.DisplayName = "李婧怡Hello"
        uc.UserName = "jylee"
        uc.Roles = {"Administrator", "Reporter", "Supervisor"}
        uc.Id = 21
        uc.Grade = 1
        uc.Class = 23
        Dim um As New UserManger(acc)
        um.UpdateUser(uc)
    End Sub
End Class