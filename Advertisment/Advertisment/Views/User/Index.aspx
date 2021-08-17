<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable (Of Advertisment.User))" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Index</h2>

    <p>
        <%: Html.ActionLink("Create New", "Create")%>
    </p>
    
    <table class="data">
        <tr>
            
            <th>
                ID
            </th>
            <th>
                Full Name
            </th>
            <th>
                Email
            </th>
            <th>
                User Name
            </th>
            <th>
                Photo
            </th>
            <th></th>
        </tr>

    <% For Each item In Model%>
    
        <tr>
            <td>
                <%: item.ID %>
            </td>
            <td>
                <%: item.RealName %>
            </td>
            <td>
                <%: item.Email %>
            </td>
            <td>
                <%: item.UserName %>
            </td>
            <td>
               <img src="<%: item.Photo %>" class="min" />
            </td>
            <td>
                <%: Html.ActionLink("Edit", "Edit", New With {.id = item.ID})%> |
                <%: Html.ActionLink("Details", "Details", New With {.id = item.ID})%> |
                <%: Html.ActionLink("Delete", "Delete", New With {.id = item.ID})%>
            </td>
        </tr>
    
    <% Next %>

    </table>

</asp:Content>

