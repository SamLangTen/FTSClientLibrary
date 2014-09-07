Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports FTSClientLibrary.Connection
Imports FTSClientLibrary.Authorization
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
End Class