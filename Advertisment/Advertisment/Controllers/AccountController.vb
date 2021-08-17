Imports System.Diagnostics.CodeAnalysis
Imports System.Security.Principal
Imports System.Web.Routing

<HandleError()> _
Public Class AccountController
    Inherits System.Web.Mvc.Controller

    Private formsServiceValue As IFormsAuthenticationService
    Private membershipServiceValue As IMembershipService

    Public Property FormsService() As IFormsAuthenticationService
        Get
            Return formsServiceValue
        End Get
        Set(ByVal value As IFormsAuthenticationService)
            formsServiceValue = value
        End Set
    End Property

    Public Property MembershipService() As IMembershipService
        Get
            Return membershipServiceValue
        End Get
        Set(ByVal value As IMembershipService)
            membershipServiceValue = value
        End Set
    End Property

    Protected Overrides Sub Initialize(ByVal requestContext As RequestContext)
        If FormsService Is Nothing Then FormsService = New FormsAuthenticationService()
        If MembershipService Is Nothing Then MembershipService = New AccessMembershipService()

        MyBase.Initialize(requestContext)
    End Sub

    ' **************************************
    ' URL: /Account/LogOn
    ' **************************************

    Public Function LogOn() As ActionResult
        If LoginUser.Login(Request("AdvUserId")) Then
            If LoginUser.LoggedUser.Type = UserType.AdManager  Then
                Return RedirectToAction("Index", "Advertisement")
            Else
                Return RedirectToAction("Index", "Customer")
            End If
        End If
        Return View()
    End Function

    <HttpPost()> _
    Public Function LogOn(ByVal model As LogOnModel, ByVal returnUrl As String) As ActionResult
        If ModelState.IsValid Then
            Dim ams As AccessMembershipService = MembershipService
            If MembershipService.ValidateUser(model.UserName, model.Password) Then

                FormsService.SignIn(LoginUser.LoggedUser.RealName, model.RememberMe)
                If model.RememberMe Then
                    Response.Cookies.Add(New HttpCookie("AdvUserId", LoginUser.LoggedUser.ID) With {.Expires = Now.AddMonths(1)})
                End If
                If LoginUser.LoggedUser.Type = UserType.AdManager Then
                    Return Redirect("~/Advertisement")
                Else
                    Return Redirect("~/User")
                End If
                'If Not String.IsNullOrEmpty(returnUrl) Then
                '    Return Redirect(returnUrl)
                'Else
                '    Return RedirectToAction("Index", "Home")
                'End If
            Else
                If ams.Exceptions.Count Then
                    ModelState.AddModelError("", ams.Exceptions(0).Message)
                Else
                    ModelState.AddModelError("", "The user name or password provided is incorrect.")
                End If

            End If
        End If

        ' If we got this far, something failed, redisplay form
        Return View(model)
    End Function

    ' **************************************
    ' URL: /Account/LogOff
    ' **************************************

    Public Function LogOff() As ActionResult
        FormsService.SignOut()
        Response.Cookies.Add(New HttpCookie("AdvUserId") With {.Expires = Now.AddDays(-1)})
        Return RedirectToAction("Index", "Home")
    End Function

    ' **************************************
    ' URL: /Account/Register
    ' **************************************

    Public Function Register() As ActionResult
        ViewData("PasswordLength") = MembershipService.MinPasswordLength
        Return View()
    End Function

    <HttpPost()> _
    Public Function Register(ByVal model As RegisterModel) As ActionResult
        If ModelState.IsValid Then
            ' Attempt to register the user
            Dim createStatus As MembershipCreateStatus = MembershipService.CreateUser(model.UserName, model.Password, model.Email)

            If createStatus = MembershipCreateStatus.Success Then
                FormsService.SignIn(model.UserName, False)
                Return RedirectToAction("Index", "Home")
            Else
                ModelState.AddModelError("", AccountValidation.ErrorCodeToString(createStatus))
            End If
        End If

        ' If we got this far, something failed, redisplay form
        ViewData("PasswordLength") = MembershipService.MinPasswordLength
        Return View(model)
    End Function

    ' **************************************
    ' URL: /Account/ChangePassword
    ' **************************************

    <Authorize()> _
    Public Function ChangePassword() As ActionResult
        ViewData("PasswordLength") = MembershipService.MinPasswordLength
        Return View()
    End Function

    <Authorize()> _
    <HttpPost()> _
    Public Function ChangePassword(ByVal model As ChangePasswordModel) As ActionResult
        If ModelState.IsValid Then
            If MembershipService.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword) Then
                Return RedirectToAction("ChangePasswordSuccess")
            Else
                ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.")
            End If
        End If

        ' If we got this far, something failed, redisplay form
        ViewData("PasswordLength") = MembershipService.MinPasswordLength
        Return View(model)
    End Function

    ' **************************************
    ' URL: /Account/ChangePasswordSuccess
    ' **************************************

    Public Function ChangePasswordSuccess() As ActionResult
        Return View()
    End Function
End Class
