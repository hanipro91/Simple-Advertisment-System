<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of Advertisment.User)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete</h2>

    <h3>Are you sure you want to delete this?</h3>
    <fieldset>
        <legend>Fields</legend>
        
        <div class="flex">
            <div style="min-width:400px">
                <div class="display-field"> <span>ID</span> <%: Model.ID %></div>
                
                <div class="display-field"><span>Full Name</span> <%: Model.RealName %></div>
                
                <div class="display-field"><span>E-mail Address</span> <%: Model.Email %></div>
                
                <div class="display-field"><span>User Name</span> <%: Model.UserName %></div>
                
                <div class="display-field"><span>Password</span> ******** </div>
            </div>
            <div>
                <div class="display-field"><img src="<%: Model.Photo %>" class="max" /></div>
            </div>
        </div>
        
    </fieldset>
    <% Using Html.BeginForm() %>
        <p>
            <input type="submit" value="Delete" /> |
            <%: Html.ActionLink("Back to List", "Index") %>
        </p>
    <% End Using %>

</asp:Content>

