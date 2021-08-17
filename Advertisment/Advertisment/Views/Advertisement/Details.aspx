<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of Advertisment.Advertisement)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-field"><span>ID</span> <%: Model.ID %></div>
        
        <div class="display-field"><span>Title</span> <%: Model.Title %></div>
        
        <div class="display-field"><span>Customer ID</span> <%: Model.Customer %></div>
        
        <div class="display-field"><span>Customer Info</span> <%: Model.CustomerAlise %></div>
        
        <div class="display-field"><span>Link</span> <%: Model.Link %></div>
        
        <div class="display-field"><span>Category</span> <%: Model.Category %></div>
                
        <div class="display-field"><span>Visited</span> <%: Model.Visited %></div>
                
        <div class="display-field"><span>Rate</span> <%: Model.Rate %></div>

        <div class="display-field"><span>Advertisement Type</span> <%: [Enum].GetName(GetType(Advertisment.AdvType), Model.Type ) %></div>

        <div class="display-field"><span>Advertisement</span> 
            <%If Model.Type = Advertisment.AdvType.Text Then%>
                <p><%: Model.Adver %></p>
            <%ElseIf Model.Type = Advertisment.AdvType.Image Then%>
                <img src="<%: Model.Adver %>" style="width:100%" />
            <%ElseIf Model.Type = Advertisment.AdvType.video Then%>
                <video src="<%: Model.Adver %>" controls> </video>
            <%Else%>
                <div><%: Model.Adver %></div>
            <%End If%>
        </div>
        
    </fieldset>
    <p>
        <%--<%: Html.ActionLink("Edit", "Edit", New With {.id = Model.PrimaryKey})%> |--%>
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

