<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable (Of Advertisment.Advertisement))" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index</asp:Content>

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
                Title
            </th>
            <th>
                Customer
            </th>
            <th>
                Category
            </th>
            <th>
                Type
            </th>
            <th>
                Visited
            </th>
            <th colspan="2">
                Rate
            </th>
            <th></th>
        </tr>

    <% For Each item In Model%>
    
        <tr>
            
            <td>
                <%: item.ID %>
            </td>
            <td>
                <%: item.Title %>
            </td>
            <td>
                <%: item.CustomerAlise %>
            </td>
            <td>
                <%: item.Category %>
            </td>
            <td>
                <%: [Enum].GetName(GetType(Advertisment.AdvType), item.Type)%>
            </td>
            <td>
                <%: item.Visited %>
            </td>
            <td>
                <div class="rate-bar" style="background-image: linear-gradient(to right, #ff6600,<%: item.Rate * 20 %>%, dimgray); background-size:100%">
                    <i class="fa fa-star"></i>
                    <i class="fa fa-star"></i>
                    <i class="fa fa-star"></i>
                    <i class="fa fa-star"></i>
                    <i class="fa fa-star"></i>
                </div>
            </td>
            <td>
                <b style="font-size:24px"><%: item.Rate %></b>
            </td>
            <td>
                <%: Html.ActionLink("Edit", "Edit", New With {.id = item.ID})%> |
                <%: Html.ActionLink("Details", "Details", New With {.id = item.ID})%> |
                <%: Html.ActionLink("Delete", "Delete", New With {.id = item.ID})%>
            </td>
        </tr>
    
    <% Next%>

    </table>

</asp:Content>

