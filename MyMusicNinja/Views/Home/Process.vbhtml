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
                <button type="button" class="btn btn-primary start" id="create-Peice">Add Peice</button>
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Part, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownListFor(Function(model) model.Part, CType(ViewBag.PartList, SelectList), New With {.class = "form-control"})
                <button type="button" class="btn btn-primary start" id="create-part" onclick=" $(function() {$('#dialog-form').modal()})">Add Part</button>
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

<div id="dialog-form" class="modal fade" role="dialog"  title="Create Part">
    <div class="modal-dialog">

        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title">Add New Part to Option List</h4>
            </div>
            <div class="modal-body">
                <p>This will add a new Part Type to the Master list used by all Customers.</p>
                <br />
                Part Name.  Example (Tuba 9)
                <input type="text" id="NewPart" class="form-control" />
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-success" data-dismiss="modal">Add</button>
                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
            </div>
        </div>

    
    </div>
</div>

@Section Scripts 
    @Scripts.Render("~/bundles/jqueryval")
<script type="text/javascript">
   
    </script>
End Section
