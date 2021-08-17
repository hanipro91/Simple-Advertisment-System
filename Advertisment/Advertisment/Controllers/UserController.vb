Namespace Advertisment
    <Authorize()>
    Public Class UserController
        Inherits System.Web.Mvc.Controller
        Dim ads As New AccessDataSource
        Dim Users As New List(Of User)

        '
        ' GET: /User

        Function Index() As ActionResult
            Return View(Users)
        End Function

        '
        ' GET: /User/Details/5

        Function Details(ByVal id As Integer) As ActionResult
            Dim u = Users.FirstOrDefault(Function(e) e.ID = id)
            Return View(u)
        End Function

        '
        ' GET: /User/Create

        Function Create() As ActionResult
            Return View()
        End Function

        '
        ' POST: /User/Create

        <HttpPost()> _
        Function Create(ByVal user As User) As ActionResult
            Try
                If ModelState.IsValid Then
                    ads.InsertCommand = "INSERT INTO [Users] ([Type], [RealName], [Email], [UserName], [Password], [Photo]) VALUES (" +
                        CInt(user.Type).ToString() + ",'" + user.RealName + "','" + user.Email + "','" + user.UserName + "','" + user.Password + "','" + user.Photo + "')"
                    ads.Insert()
                    Return RedirectToAction("Index")
                Else
                    Throw New Exception("Form Fields Error: Make sure that all field entered with correct value.")
                End If

            Catch ex As Exception
                ModelState.AddModelError("", ex.Message)
                Return View(user)
            End Try
        End Function

        '
        ' GET: /User/Edit/5

        Function Edit(ByVal id As Integer) As ActionResult
            Dim u = Users.FirstOrDefault(Function(e) e.ID = id)
            Return View(u)
        End Function

        '
        ' POST: /User/Edit/5

        <HttpPost()> _
        Function Edit(ByVal id As Integer, ByVal user As User) As ActionResult
            Try
                If ModelState.IsValid Then
                    ads.UpdateCommand = "UPDATE [Users] SET [Type]=" + CInt(user.Type).ToString() +
                        ", [RealName]='" + user.RealName + "', [Email]='" + user.Email +
                        "', [UserName]='" + user.UserName + "', [Password]='" + user.Password +
                        "', [Photo]='" + user.Photo + "' WHERE ID = " & id
                    ads.Update()
                    Return RedirectToAction("Index")
                Else
                    Throw New Exception("Form Fields Error: Make sure that all field entered with correct value.")
                End If

                Return RedirectToAction("Index")
            Catch ex As Exception
                ModelState.AddModelError("", ex.Message)
                Return View(user)
            End Try
        End Function

        '
        ' GET: /User/Delete/5

        Function Delete(ByVal id As Integer) As ActionResult
            Dim u = Users.FirstOrDefault(Function(e) e.ID = id)
            Return View(u)
        End Function

        '
        ' POST: /User/Delete/5

        <HttpPost()> _
        Function Delete(ByVal id As Integer, ByVal user As User) As ActionResult
            Try
                ads.DeleteCommand = "DELETE FROM [Users] WHERE ID = " & id
                ads.Delete()

                Return RedirectToAction("Index")
            Catch ex As Exception
                ModelState.AddModelError("", ex.Message)
                Return View(user)
            End Try
        End Function

        Public Sub New()

            ads.DataFile = "~/App_Data/Advs.accdb"
            ads.SelectCommand = "Select * From Users"


            Dim Data As DataView = ads.Select(New DataSourceSelectArguments())
            For Each R As DataRowView In Data
                Users.Add(New User() With {.ID = R("ID"),
                                           .Email = R("Email"),
                                           .Photo = R("Photo"),
                                           .RealName = R("RealName"),
                                           .Type = R("Type"),
                                           .UserName = R("UserName")})
            Next

        End Sub
    End Class
End Namespace