Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports FTSClientLibrary.Connection
Imports FTSClientLibrary.Client
<TestClass()> Public Class UserFunctionTest

    <TestMethod()> Public Sub TestUserCreation()
        ConnectionSetting.DomainName = "http://failuretest.chinacloudsites.cn"
        Dim acc As New Account("sms")
        acc.Login("1111111", True)
        Dim uc As New User()
        uc.DisplayName = "黄心琳"
        uc.UserName = "xlwong"
        uc.Roles = {"Administrator", "Reporter"}
        uc.Grade = 1
        uc.Class = 23
        User.CreateUser(uc, "1111111", acc)
    End Sub

    <TestMethod()> Public Sub TestAllFunctionInUserRef()
        ConnectionSetting.DomainName = "http://failuretest.chinacloudsites.cn"
        Dim acc As New Account("sms")
        acc.Login("1111111", True)
        Dim user As User = user.GetUsers(acc).SingleOrDefault(Function(r) r.DisplayName = "黄心琳Nice")
        user.DisplayName = "黄心琳Nice"
        user.IsEnabled = True
        user.Roles = {"Reporter", "Supervisor", "Administrator"}
        user.SaveChanges()
        user.SetPassword("aaaaaaa")
    End Sub
    <TestMethod()> Public Sub TestUserRolesGetting()
        ConnectionSetting.DomainName = "http://failuretest.chinacloudsites.cn"
        Dim acc As New Account("sms")
        acc.Login("1111111", True)
        UserRole.GetRoles(acc).ToList().ForEach(Sub(r)
                                                    Console.WriteLine("Name:{0},Description:{1}", r.Name, r.Description)
                                                End Sub)
    End Sub
End Class
