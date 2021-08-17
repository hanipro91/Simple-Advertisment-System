<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of Advertisment.Customer)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit Customer Information</h2>

    <% Using Html.BeginForm() %>
        <%: Html.ValidationSummary(True) %>
        <fieldset>
            <legend>Customer</legend>
            
            <div class="editor-field">
                <%: Html.LabelFor(Function(model) model.Photo) %>
                <img src="../../Images/user.png" class="max" onclick="LoadImage(this)" onload="Photo.value=src" />
                <%: Html.HiddenFor(Function(model) model.Photo)%>
                <%: Html.ValidationMessageFor(Function(model) model.Photo) %>
            </div>
            
            <div class="editor-field">
                <%: Html.LabelFor(Function(model) model.Name) %>
                <%: Html.TextBoxFor(Function(model) model.Name) %>
                <%: Html.ValidationMessageFor(Function(model) model.Name) %>
            </div>
            
            <div class="editor-field">
                <%: Html.LabelFor(Function(model) model.Type) %>
                <%: Html.DropDownListFor(Function(model) model.Type,
                                                   {New SelectListItem() With {.Text = "Male"},
                                                    New SelectListItem() With {.Text = "Femal"},
                                                    New SelectListItem() With {.Text = "Company"},
                                                    New SelectListItem() With {.Text = "Orgnization"},
                                                    New SelectListItem() With {.Text = "Foundation"},
                                                    New SelectListItem() With {.Text = "Government"}
                                                   })%>
                <%: Html.ValidationMessageFor(Function(model) model.Type) %>
            </div>
            
            <div class="editor-field">
                <%: Html.LabelFor(Function(model) model.Address) %>
                <%: Html.TextBoxFor(Function(model) model.Address) %>
                <%: Html.ValidationMessageFor(Function(model) model.Address) %>
            </div>
            
            <div class="editor-field">
                <%: Html.LabelFor(Function(model) model.Email) %>
                <%: Html.TextBoxFor(Function(model) model.Email) %>
                <%: Html.ValidationMessageFor(Function(model) model.Email) %>
            </div>
            
            <div class="editor-field">
                <%: Html.LabelFor(Function(model) model.Phone) %>
                <%: Html.TextBoxFor(Function(model) model.Phone) %>
                <%: Html.ValidationMessageFor(Function(model) model.Phone) %>
            </div>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% End Using %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

