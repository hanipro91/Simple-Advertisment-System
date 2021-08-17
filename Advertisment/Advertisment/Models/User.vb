Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel

Public Enum UserType As Integer
    AdManager = 0
    SystemManager = 1
End Enum

Public Class User
    Public Property ID As Integer

    <Required(ErrorMessage:="This Field is Required")>
    <DisplayName("User Type")>
    Public Property Type As UserType

    <Required()>
    <DisplayName("Full Name")>
    Public Property RealName As String

    <Required()>
    <DisplayName("E-Mail")>
    <DataType(DataType.EmailAddress)>
    Public Property Email As String

    <Required()>
    <DisplayName("User Name")>
    Public Property UserName As String

    <Required()>
    <DataType(DataType.Password)>
    Public Property Password As String

    <DisplayName("User Photo")>
    Public Property Photo As String
End Class

Public Class LoginUser
    Public Property ID As Integer
    Public Property Type As UserType
    Public Property RealName As String
    Public Property Photo As String

    Public Shared Property LoggedUser As LoginUser

    Public Shared Function Login(ByVal id As String) As Boolean
        If id Is Nothing Then Return False
        Dim ads As New AccessDataSource("~/App_Data/Advs.accdb", "SELECT * FROM [Users] WHERE ID = " + id)

        Dim Dv As DataView = ads.Select(New DataSourceSelectArguments())

        If Dv.Count = 0 Then Return False

        LoggedUser = New LoginUser() With {.ID = Dv(0)("ID"),
                                           .Photo = Dv(0)("Photo"),
                                           .RealName = Dv(0)("RealName"),
                                           .Type = Dv(0)("Type")}
        Return True
    End Function
End Class
