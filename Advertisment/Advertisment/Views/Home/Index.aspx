<%@ Page Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: ViewData("Message") %></h2>
    
    <p>ASP.NET is a free web framework for building websites and web applications on .NET Framework using HTML, CSS, and JavaScript.
ASP.NET MVC 5 is a web framework based on Mode-View-Controller (MVC) architecture. Developers can build dynamic web applications using ASP.NET MVC framework that enables a clean separation of concerns, fast development, and TDD friendly.
These tutorials are designed for beginners and professionals who want to learn ASP.NET MVC 5.</p>
    <p>
        To learn more about ASP.NET MVC visit <a href="http://asp.net/mvc" title="ASP.NET MVC Website">http://asp.net/mvc</a>.
    </p>

    <div class="adv-area"></div>

    <h2>ASP.NET MVC Architecture</h2>
    <p>The MVC architectural pattern has existed for a long time in software engineering. All most all the languages use MVC with slight variation, but conceptually it remains the same.

Let's understand the MVC architecture supported in ASP.NET.

MVC stands for Model, View, and Controller. MVC separates an application into three components - Model, View, and Controller.
</p><p>

<b>Model:</b> Model represents the shape of the data. A class in C# is used to describe a model. Model objects store data retrieved from the database.

<b>Model represents the data.</b>
</p><p>

<b>View:</b> View in MVC is a user interface. View display model data to the user and also enables them to modify them. View in ASP.NET MVC is HTML, CSS, and some special syntax (Razor syntax) that makes it easy to communicate with the model and the controller.

<b>View is the User Interface.</b>
</p><p>
<b>Controller:</b> The controller handles the user request. Typically, the user uses the view and raises an HTTP request, which will be handled by the controller. The controller processes the request and returns the appropriate view as a response.
<b>Controller is the request handler.</b></p>

<div class="adv-area"></div>

<p>As per the above figure, when a user enters a URL in the browser, it goes to the webserver and routed to a controller. A controller executes related view and models for that request and create the response and sends it back to the browser.</p>
 <p class="error" >
 <%:Html.ValidationSummary(False) %>
 </p>

<ul style="display:none" id="Advers">
<%  For Each item In Model %>
       <li>
            <a href="Visit/<%: item.ID%>" data-id="<%: item.ID%>" target="_blank">
            <%If item.Type = Advertisment.AdvType.Text Then%>
                <p><%: item.Adver%></p>
            <%ElseIf item.Type = Advertisment.AdvType.Image Then%>
                <img src="<%: item.Adver %>" style="width:100%" />
            <%ElseIf item.Type = Advertisment.AdvType.video Then%>
                <video src="<%: item.Adver %>" controls> </video>
            <%Else%>
                <div><%: item.Adver %></div>
            <%End If%>
            </a>
        </li>
<%  Next%> 
</ul>

<script>
    $(".adv-area").each(function (i, a) {
        a.innerHTML = Advers.children[i].innerHTML
        a.onclick = function(){
            //location = '/Visit/' + $(this.children[0]).attr('data-id') 
        }
    });
</script>
</asp:Content>
