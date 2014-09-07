Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports FTSClientLibrary.Connection
Imports FTSClientLibrary.Authorization
<TestClass()> Public Class AuthorizationTest

    <TestMethod()> Public Sub TestAccountLogin()
        ConnectionSetting.DomainName = "http://failuretest.chinacloudsites.cn"
        Dim acc As New Account("sms")
        acc.Login("1111111", True)
    End Sub

End Class