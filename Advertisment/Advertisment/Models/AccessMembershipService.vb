Public Interface IAccessMemberShipService
    Inherits IMembershipService
    Shadows Function CreateUser(ByVal type As UserType, ByVal realName As String, ByVal userName As String, ByVal password As String, ByVal email As String, ByVal photo As String) As System.Web.Security.MembershipCreateStatus

End Interface

Public Class AccessMembershipService
    Implements IAccessMemberShipService

    Dim ads As New AccessDataSource("~/App_Data/Advs.accdb", "")

    Public Property Exceptions As New List(Of Exception)

    Public Function ChangePassword(ByVal userName As String, ByVal oldPassword As String, ByVal newPassword As String) As Boolean Implements IAccessMemberShipService.ChangePassword
        ads.UpdateCommand = "UPDATE [Users] SET Password='" + newPassword + "'" +
                             "WHERE (UserName='" + userName + "' OR Email='" + userName + "') AND Password = '" + oldPassword + "'"
        Try
            Return ads.Update() > 0
        Catch ex As Exception
            Exceptions.Add(ex)
            Return False
        End Try
    End Function

    Public Function CreateUser(ByVal type As UserType, ByVal realName As String, ByVal userName As String, ByVal password As String, ByVal email As String, ByVal photo As String) As System.Web.Security.MembershipCreateStatus Implements IAccessMemberShipService.CreateUser
        Try
            ads.InsertCommand = "INSERT INTO [Users] ([Type], [RealName], [Email], [UserName], [Password], [Photo]) VALUES (" +
                        CInt(type).ToString() + ",'" + realName + "','" + email + "','" + userName + "','" + password + "','" + photo + "')"
            ads.Insert()
            Return MembershipCreateStatus.Success
        Catch ex As Exception
            Exceptions.Add(ex)
            Return MembershipCreateStatus.UserRejected
        End Try
    End Function

    Public ReadOnly Property MinPasswordLength As Integer Implements IAccessMemberShipService.MinPasswordLength
        Get
            Return 3
        End Get
    End Property

    Public Function ValidateUser(ByVal userName As String, ByVal password As String) As Boolean Implements IAccessMemberShipService.ValidateUser
        ads.SelectCommand = "SELECT * FROM [Users] " +
            "WHERE UserName='" + userName + "' OR Email='" + userName + "'"
        Try
            Dim Dv As DataView = ads.Select(New DataSourceSelectArguments())
            If Dv.Count = 0 Then Return False
            If String.Equals(password, Dv.Item(0)("Password"), StringComparison.CurrentCulture) Then
                LoginUser.LoggedUser = New LoginUser() With {.ID = Dv(0)("ID"),
                                                    .Photo = Dv(0)("Photo"),
                                                    .RealName = Dv(0)("RealName"),
                                                    .Type = Dv(0)("Type")}
                Return True
            End If
            Return False
        Catch ex As Exception
            Exceptions.Add(ex)
            Return False
        End Try
    End Function

    Private Function CreateUser1(ByVal userName As String, ByVal password As String, ByVal email As String) As System.Web.Security.MembershipCreateStatus Implements IMembershipService.CreateUser
        Return Nothing
    End Function

End Class
