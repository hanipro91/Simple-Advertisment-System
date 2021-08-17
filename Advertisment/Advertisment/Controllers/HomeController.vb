<HandleError()>
Public Class HomeController
    Inherits System.Web.Mvc.Controller
    Dim Advers As New List(Of Advertisement)
    Dim ads As New AccessDataSource

    Function Index() As ActionResult
        
        'If LoginUser.LoggedUser IsNot Nothing Then
        '    If LoginUser.LoggedUser.Type = UserType.AdManager Then
        '        Return RedirectToAction("Index", "Advertisement")
        '    Else
        '        Return RedirectToAction("Index", "Customer")
        '    End If
        'End If
        ViewData("Message") = "Welcome to Advertisement System With ASP.NET MVC!"
        Return View(Advers)
    End Function

    Function Visit(ByVal id As Integer) As ActionResult
        Dim a = Advers.FirstOrDefault(Function(x) x.ID = id)

        a.Visited += 1
        If a.Visited >= 50 Then
            a.Rate = 5
        Else
            a.Rate = a.Visited / 10
        End If
        ads.UpdateCommand = "UPDATE [Ads] SET Visited = " & a.Visited & ", Rate = " & a.Rate & " WHERE ID = " & id
        Try
            ads.Update()
        Catch ex As Exception
            ModelState.AddModelError("", ex.Message)
            Return View(Advers)
        End Try
        Return Redirect(a.Link)
    End Function

    Function About() As ActionResult
        Return View()
    End Function

    Sub New()
        ads.DataFile = "~/App_Data/Advs.accdb"
        ads.SelectCommand = "Select * From Ads"
        Dim Data As DataView = ads.Select(New DataSourceSelectArguments())
        For Each R As DataRowView In Data
            Advers.Add(New Advertisement() With {
                       .ID = R("ID"),
                       .Adver = R("Adver"),
                       .Link = R("Linke"),
                       .Type = R("Type"),
                       .Category = R("Category"),
                       .Visited = R("Visited")
                   })
        Next
    End Sub
End Class
