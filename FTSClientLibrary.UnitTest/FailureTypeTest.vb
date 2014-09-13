Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports FTSClientLibrary.Client
<TestClass()> Public Class FailureTypeTest

    <TestMethod()> Public Sub TestCreateFailureType()
        ConnectionSetting.DomainName = "http://failuretest.chinacloudsites.cn"
        Dim acc As New Account("sms")
        acc.Login("1111111", True)
        FailureType.CreateFailureType(New FailureType() With {.Description = "手机", .Name = "手机", .Id = "gun", .IsEnabled = True}, acc)
    End Sub

    <TestMethod()> Public Sub TestAllFunctionsInFailureType()
        ConnectionSetting.DomainName = "http://failuretest.chinacloudsites.cn"
        Dim acc As New Account("sms")
        acc.Login("1111111", True)
        Dim ft As FailureType = FailureType.GetFailureTypes(acc).SingleOrDefault(Function(r) r.Id = "gun")
        ft.Description = "鲁格P08"
        ft.SaveChanges()
    End Sub

End Class
