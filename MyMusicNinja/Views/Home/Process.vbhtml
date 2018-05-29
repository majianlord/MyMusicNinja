@ModelType MyMusicNinja.ProccessUploadModels
@Code
    ViewData("Title") = "Process"
End Code

<h2>Process Uploads</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4>Please Select the Song/Piece Name and the Part and Hit save to Cataloge this Music</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        <div class="form-group">
            @Html.LabelFor(Function(model) model.PeiceName, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownListFor(Function(model) model.PeiceName, CType(ViewBag.PeiceList, SelectList), New With {.class = "form-control"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Part, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownListFor(Function(model) model.Part, CType(ViewBag.PartList, SelectList), New With {.class = "form-control"})
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Save" class="btn btn-default" />
            </div>
        </div>
    </div>
End Using
     <div>
         <embed src="~/UploadedFiles/@Model.FileName" width="1200" height="700" alt="pdf" pluginspage="http://www.adobe.com/products/acrobat/readstep2.html">
     </div>
<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@Section Scripts 
    @Scripts.Render("~/bundles/jqueryval")
End Section
