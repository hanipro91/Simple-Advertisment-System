<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of Advertisment.User)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>
    
    <% Using Html.BeginForm()%>
        <%: Html.ValidationSummary(True) %>
        <fieldset>
            <legend>New User Info</legend>

            <div class="editor-field">
                <%: Html.LabelFor(Function(model) model.Photo) %>
                <img src="../../Images/user.png" alt="" onclick="LoadImage(this)" onload="Photo.value=src" />
                <%: Html.HiddenFor(Function(model) model.Photo)%>
                <%: Html.ValidationMessageFor(Function(model) model.Photo) %>
            </div>

            <div class="editor-field">
                <%: Html.LabelFor(Function(model) model.RealName) %>
                <%: Html.TextBoxFor(Function(model) model.RealName) %>
                <%: Html.ValidationMessageFor(Function(model) model.RealName) %>
            </div>
            
            <div class="editor-field">
                <%: Html.LabelFor(Function(model) model.Email) %>
                <%: Html.TextBoxFor(Function(model) model.Email) %>
                <%: Html.ValidationMessageFor(Function(model) model.Email) %>
            </div>
            
            <div class="editor-field">
                <%: Html.LabelFor(Function(model) model.UserName) %>
                <%: Html.TextBoxFor(Function(model) model.UserName) %>
                <%: Html.ValidationMessageFor(Function(model) model.UserName) %>
            </div>

            <div class="editor-field">
                <%: Html.LabelFor(Function(model) model.Password) %>
                <%: Html.PasswordFor(Function(model) model.Password)%>
                <%: Html.ValidationMessageFor(Function(model) model.Password) %>
            </div>

            <div class="editor-field">
                <%: Html.LabelFor(Function(model) model.Type)%>
                <%: Html.DropDownListFor(Function(model) model.Type, {New SelectListItem() With {.Value = 0, .Text = "Ads Manager"}, New SelectListItem() With {.Value = 1, .Text = "System Manager"}})%>
                <%: Html.ValidationMessageFor(Function(model) model.Type) %>
            </div>

            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% End Using %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

