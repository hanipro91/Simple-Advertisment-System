<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of Advertisment.Advertisement)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <%-- The following line works around an ASP.NET compiler warning --%>
    <%: ""%>
    <% Using Html.BeginForm()%>
        <%: Html.ValidationSummary(True) %>
        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-field">
                <%: Html.LabelFor(Function(model) model.Title) %>
                <%: Html.TextBoxFor(Function(model) model.Title) %>
                <%: Html.ValidationMessageFor(Function(model) model.Title) %>
            </div>
                        
            <div class="editor-field">
                <%: Html.LabelFor(Function(model) model.Customer) %>
                <%: Html.DropDownListFor(Function(model) model.Customer, 
                               New SelectList(Advertisment.Advertisment.AdvertisementController.CustsAlises,"Key","Value"))%>
                <%: Html.ValidationMessageFor(Function(model) model.Customer) %>
            </div>
                                    
            <div class="editor-field">
                <%: Html.LabelFor(Function(model) model.Link) %>
                <%: Html.TextBoxFor(Function(model) model.Link) %>
                <%: Html.ValidationMessageFor(Function(model) model.Link) %>
            </div>
            
            <div class="editor-field">
                <%: Html.LabelFor(Function(model) model.Category) %>
                <%: Html.TextBoxFor(Function(model) model.Category) %>
                <%: Html.ValidationMessageFor(Function(model) model.Category) %>
            </div>
            
            <div class="editor-field">
                <%: Html.LabelFor(Function(model) model.Type)%>
                <%: Html.DropDownListFor(Function(model) model.Type,
                                                    New SelectList(Advertisment.Advertisement.AdvTypeToDict(), "Key", "Value"))%>
                <%: Html.ValidationMessageFor(Function(model) model.Type)%>
            </div>
                                  
            <div class="editor-field">
                <%: Html.LabelFor(Function(model) model.Adver) %>

                <div id="AdvLayout" style="display:inline-block">
                    <textarea class="adv" onchange="Adver.value=value"></textarea>
                    <img src="../../Images/digital-advertising-icon.png" class="adv" onclick="LoadImage(this); this.newValue=true " onload="if(this.newValue)Adver.value=src" />
                    <div class="adv">
                        <video id="AdvVideo" style="width:100%; height:calc(100% - 20px); display:block" controls preload="metadata" poster="../../Images/loadvideo.gif">
                        </video>
                        <input type="file" name="videoFile" id="videoFile" accept="video/*"
                                onchange="LoadFile(this, 'base64', AdvVideo, 'src').then(content=>{Adver.value=content})" 
                                style="background:black; border:none;border-radius:0; width:calc(100% - 8px)"/>
                    </div>
                    
                    <div class="adv">
                        <div id="advOther">
                        </div>
                        <input type="file" 
                               onchange="LoadFile(this, 'text', advOther,'innerHTML').then(content=>{Adver.value=content})"
                               style="background:none; border:none;border-radius:0; width:calc(100% - 8px)"/>
                    </div>
                </div>
                
                <%: Html.HiddenFor(Function(model) model.Adver)%>
                <%: Html.ValidationMessageFor(Function(model) model.Adver) %>
            </div>

            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% End Using %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

    <script>
    $("#AdvLayout > *").css("display","none")
    $(AdvLayout.children[0]).css("display","inline-block")
    Type.onchange= e => {
        var t = Type.value,
            view = AdvLayout.children[t]
         $("#AdvLayout > *").css("display","none")
         $(view).css("display","inline-block")

         if(view.tagName == 'DIV')
            view = view.children[0];
         
         Adver.value = view.tagName === 'VIDEO' || view.tagName === 'IMG'? view.src:
                       view.tagName === 'DIV'? view.innerHTML : view.value;
    }
    </script>
</asp:Content>

