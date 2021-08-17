Namespace Advertisment
    <Authorize()>
    Public Class CustomerController
        Inherits System.Web.Mvc.Controller
        Dim Customers As New List(Of Customer)
        Dim ads As New AccessDataSource
        '
        ' GET: /Customer

        Function Index() As ActionResult
            Return View(Customers)
        End Function

        '
        ' GET: /Customer/Details/5

        Function Details(ByVal id As Integer) As ActionResult
            Dim c = Customers.FirstOrDefault(Function(cc) cc.ID = id)
            Return View(c)
        End Function

        '
        ' GET: /Customer/Create

        Function Create() As ActionResult
            Return View()
        End Function

        '
        ' POST: /Customer/Create

        <HttpPost()> _
        Function Create(ByVal customer As Customer) As ActionResult
            Try
                If ModelState.IsValid Then
                    ads.InsertCommand = "INSERT INTO [Customers] ([Type], [CustName], [Email], [Address], [Phone], [Photo]) VALUES (" +
                        "'" + customer.Type + "','" + customer.Name + "','" + customer.Email + "','" + customer.Address + "','" + customer.Phone + "','" + customer.Photo + "')"
                    ads.Insert()
                    Return RedirectToAction("Index")
                Else
                    Throw New Exception("Form Fields Error: Make sure that all field entered with correct value.")
                End If

            Catch ex As Exception
                ModelState.AddModelError("", ex.Message)
                Return View(customer)
            End Try
        End Function

        '
        ' GET: /Customer/Edit/5

        Function Edit(ByVal id As Integer) As ActionResult
            Dim c = Customers.FirstOrDefault(Function(cc) cc.ID = id)
            Return View(c)
        End Function

        '
        ' POST: /Customer/Edit/5

        <HttpPost()> _
        Function Edit(ByVal id As Integer, ByVal customer As Customer) As ActionResult
            Try
                If ModelState.IsValid Then
                    ads.UpdateCommand = "UPDATE [Customers] SET [Type]='" + customer.Type +
                        "', [CustName]='" + customer.Name + "', [Email]='" + customer.Email +
                        "', [Address]='" + customer.Address + "', [Phone]='" + customer.Phone +
                        "', [Photo]='" + customer.Photo + "' WHERE ID = " & id
                    ads.Update()
                    Return RedirectToAction("Index")
                Else
                    Throw New Exception("Form Fields Error: Make sure that all field entered with correct value.")
                End If
            Catch ex As Exception
                ModelState.AddModelError("", ex.Message)
                Return View(customer)
            End Try
        End Function

        '
        ' GET: /Customer/Delete/5

        Function Delete(ByVal id As Integer) As ActionResult
            Dim c = Customers.FirstOrDefault(Function(cc) cc.ID = id)
            Return View(c)
        End Function

        '
        ' POST: /Customer/Delete/5

        <HttpPost()> _
        Function Delete(ByVal id As Integer, ByVal customer As Customer) As ActionResult
            Try
                ads.DeleteCommand = "DELETE FROM [Customers] WHERE ID = " & id
                ads.Delete()

                Return RedirectToAction("Index")
            Catch ex As Exception
                ModelState.AddModelError("", ex.Message)
                Return View(customer)
            End Try
        End Function

        Sub New()
            ads.DataFile = "~/App_Data/Advs.accdb"
            ads.SelectCommand = "Select * From Customers"


            Dim Data As DataView = ads.Select(New DataSourceSelectArguments())
            For Each R As DataRowView In Data
                Customers.Add(New Customer() With {.ID = R("ID"),
                                           .Email = R("Email"),
                                           .Photo = R("Photo"),
                                           .Name = R("CustName"),
                                           .Type = R("Type"),
                                           .Address = R("Address"),
                                           .Phone = R("Phone")})
            Next
        End Sub
    End Class
End Namespace