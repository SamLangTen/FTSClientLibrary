Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports FailureTroubleShooting.FTSClient.Client
<TestClass()> Public Class AuthorizationTest

    <TestMethod()> Public Sub TestAccountLoginAndLogoff()
        ConnectionSetting.DomainName = "http://failuretest.chinacloudsites.cn"
        Dim acc As New Account("sms")
        acc.Login("1111111", True)
        acc.Logoff()
    End Sub

    <TestMethod()> Public Sub TestAccountGetInfo()
        ConnectionSetting.DomainName = "http://failuretest.chinacloudsites.cn"
        Dim acc As New Account("sms")
        acc.Login("1111111", True)
        acc.GetUserInfo()
        Console.WriteLine(acc.DisplayName)
        Console.WriteLine(acc.Id)
        Console.WriteLine(acc.Grade)
        Console.WriteLine(acc.Class)
        Console.WriteLine(acc.UserName)
        acc.Roles.ToList().ForEach(Sub(r)
                                       Console.WriteLine(r)
                                   End Sub)
    End Sub

    <TestMethod()> Public Sub TestAccountChangePass()
        ConnectionSetting.DomainName = "http://failuretest.chinacloudsites.cn"
        Dim acc As New Account("sms")
        acc.Login("aaaaaaa", True)
        Console.WriteLine(acc.ChangePassword("aaaaaaa", "1111111"))
    End Sub
End Class