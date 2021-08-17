<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl" %>
<%-- The following line works around an ASP.NET compiler warning --%>
<%: ""%>
<%
    If Request.IsAuthenticated Then
    %>
        <div style="display:inline-block">
            Welcome <b><%: Page.User.Identity.Name %></b>! <br />
            [ <%: Html.ActionLink("Log Off", "LogOff", "Account")%> ]
        </div>
        
        <img src="<%: Advertisment.LoginUser.LoggedUser.Photo%>" alt="" class="min" /> 
    <%
    Else
    %>
        [ <%: Html.ActionLink("Log On", "LogOn", "Account")%> ]
    <%        
    End If
%>