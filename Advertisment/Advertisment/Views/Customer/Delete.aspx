<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of Advertisment.Customer)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete</h2>

    <h3>Are you sure you want to delete this?</h3>
    <fieldset>
        <legend>Fields</legend>
        
         <div class="flex">
            <div>
                <div class="display-field"><span>ID</span> <%: Model.ID %></div>
        
                <div class="display-field"><span>Name</span> <%: Model.Name %></div>
        
                <div class="display-field"><span>Cutomer Type</span> <%: Model.Type %></div>
        
                <div class="display-field"><span>Location Address</span> <%: Model.Address %></div>
        
                <div class="display-field"><span>Email Address</span> <%: Model.Email %></div>
        
                <div class="display-field"><span>Phone</span> <%: Model.Phone %></div>
            </div>
            <div>
                <img src="<%: Model.Photo %>" class="max" alt="U/L"/>
            </div>
        
    </fieldset>
    <% Using Html.BeginForm() %>
        <p>
            <input type="submit" value="Delete" /> |
            <%: Html.ActionLink("Back to List", "Index") %>
        </p>
    <% End Using %>

</asp:Content>

