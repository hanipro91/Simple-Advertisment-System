Namespace Advertisment
    <Authorize()>
    Public Class AdvertisementController
        Inherits System.Web.Mvc.Controller
        Dim Advers As New List(Of Advertisement)
        Dim ads As New AccessDataSource
        Public Shared Property CustsAlises As New Dictionary(Of Integer, String)
        '
        ' GET: /Advertisement

        Function Index() As ActionResult
            Return View(Advers)
        End Function

        '
        ' GET: /Advertisement/Details/5

        Function Details(ByVal id As Integer) As ActionResult
            Dim ad = Advers.FirstOrDefault(Function(a) a.ID = id)
            Return View(ad)
        End Function

        '
        ' GET: /Advertisement/Create

        Function Create() As ActionResult
            Return View()
        End Function

        '
        ' POST: /Advertisement/Create

        <HttpPost()> _
        Function Create(ByVal ad As Advertisement) As ActionResult
            Try
                If ModelState.IsValid Then
                    ads.InsertCommand = "INSERT INTO [Ads] ([Title], [Type], [Customer], [Linke], [Category],[Adver], [Visited], [Rate]) VALUES (" +
                         "'" + ad.Title + "'," & CInt(ad.Type).ToString + "," & ad.Customer & ",'" + ad.Link + "','" + ad.Category + "','" + ad.Adver + "', 0, 0)"
                    ads.Insert()
                    Return RedirectToAction("Index")
                Else
                    Throw New Exception("Form Fields Error: Make sure that all field entered with correct value.")
                End If
            Catch ex As Exception
                ModelState.AddModelError("", ex.Message)
                Return View(ad)
            End Try
        End Function

        '
        ' GET: /Advertisement/Edit/5

        Function Edit(ByVal id As Integer) As ActionResult
            Dim ad = Advers.FirstOrDefault(Function(a) a.ID = id)
            Return View(ad)
        End Function

        '
        ' POST: /Advertisement/Edit/5

        <HttpPost()> _
        Function Edit(ByVal id As Integer, ByVal ad As Advertisement) As ActionResult
            Try
                If ModelState.IsValid Then
                    ads.UpdateCommand = "UPDATE [Ads] SET [Type]=" + CInt(ad.Type).ToString +
                        ", [Customer]=" & ad.Customer & ", [Adver]='" + ad.Adver +
                        "', [Linke]='" + ad.Link + "', [Category]='" + ad.Category +
                        "', [Visited]=" & ad.Visited & ",[Rate]=" & ad.Rate &
                        ", [Title]='" + ad.Title + "'   WHERE ID = " & id
                    ads.Update()
                Else
                    Throw New Exception("Form Fields Error: Make sure that all field entered with correct value.")
                End If

                Return RedirectToAction("Index")
            Catch ex As Exception
                ModelState.AddModelError("", ex.Message)
                Return View()
            End Try
        End Function

        '
        ' GET: /Advertisement/Delete/5

        Function Delete(ByVal id As Integer) As ActionResult
            Dim ad = Advers.FirstOrDefault(Function(a) a.ID = id)
            Return View(ad)
        End Function

        '
        ' POST: /Advertisement/Delete/5

        <HttpPost()> _
        Function Delete(ByVal id As Integer, ByVal ad As Advertisement) As ActionResult
            Try
                ads.DeleteCommand = "DELETE FROM [Ads] WHERE ID = " & id
                ads.Delete()

                Return RedirectToAction("Index")
            Catch ex As Exception
                ModelState.AddModelError("", ex.Message)
                Return View(ad)
            End Try
        End Function

        Sub New()
            ads.DataFile = "~/App_Data/Advs.accdb"
            ads.SelectCommand = "Select ID, CustName + ' (' + Type + ')' AS [Alis] FROM [Customers]"
            CustsAlises.Clear()
            Dim custData As DataView = ads.Select(New DataSourceSelectArguments())
            For Each R As DataRowView In custData
                CustsAlises.Add(R("ID"), R("Alis"))
            Next

            ads.SelectCommand = "Select * From Ads"
            Dim Data As DataView = ads.Select(New DataSourceSelectArguments())
            For Each R As DataRowView In Data
                Advers.Add(New Advertisement() With {
                           .ID = R("ID"),
                           .Title = R("Title"),
                           .Customer = R("Customer"),
                           .Adver = R("Adver"),
                           .Link = R("Linke"),
                           .Type = R("Type"),
                           .Category = R("Category"),
                           .Visited = R("Visited"),
                           .Rate = R("Rate"),
                           .CustomerAlise = CustsAlises(R("Customer"))
                       })
            Next
        End Sub
    End Class
End Namespace