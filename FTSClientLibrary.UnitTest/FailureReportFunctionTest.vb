Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports FailureTroubleShooting.FTSClient.Client
<TestClass> Public Class FailureReportFunctionTest

    <TestMethod> Public Sub GetSubmittedReportTest()
        ConnectionSetting.DomainName = "http://failuretest.chinacloudsites.cn"
        Dim acc As New Account("sms")
        acc.Login("1111111", True)
        acc.GetUserInfo()
        Dim rm As New ReportManager(acc)
        rm.GetSubmittedReports().ToList().ForEach(Sub(r)
                                                      Console.WriteLine(r.Title)
                                                  End Sub)
    End Sub

    <TestMethod> Public Sub TestSubmitAReport()
        ConnectionSetting.DomainName = "http://failuretest.chinacloudsites.cn"
        Dim acc As New Account("sms")
        acc.Login("1111111", True)
        acc.GetUserInfo()
        Dim rm As New ReportManager(acc)
        rm.SubmitReport({New FailureItem() With {.Count = 2, .Detail = "就是他", .Type = New FailureType() With {.Id = "door", .Name = "门"}}}, "窗不行了")
    End Sub
End Class
