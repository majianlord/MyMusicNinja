@ModelType MyMusicNinja.ProccessUploadModels
@Code
    ViewData("Title") = "Process"
End Code

<h2>Process Uploads</h2>

@Using (Html.BeginForm("Process", "Home", FormMethod.Post, New With {.id = "PiecePart_ADD"}))
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4>Please Select the Song/Piece Name and the Part and Hit save to Cataloge this Music</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        <div class="form-group">
            @Html.LabelFor(Function(model) model.PieceName, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownListFor(Function(model) model.PieceName, CType(ViewBag.PieceList, SelectList), New With {.class = "form-control"})
                <button type="button" class="btn btn-primary start" id="create-Peice" onclick=" $(function() {$('#dialog-form-Piece').modal()})">Add Piece</button>
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
            @Html.LabelFor(Function(model) model.PageNum, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.PageNum, New With {.class = "form-control", .min = "0", .max = "352", .value = "0"})
                <span class="glyphicon glyphicon-question-sign" data-toggle="tooltip" title="If this is a Book Enter the Page this scan is for.  Should not use this for Multiple Page sheet Music that should be in a Single PDF."></span>
                @Html.ValidationMessageFor(Function(model) model.PageNum, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Save" class="btn btn-success success" onclick="addpiecepart();" />
                <input type="button" value="Cancel" class="btn btn-danger danger" onclick="window.history.go(-1); return false;" />
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

<div id="dialog-form" class="modal fade" role="dialog" title="Create Part">
    <div class="modal-dialog modal-lg">

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
                <button type="button" class="btn btn-success" data-dismiss="modal" onclick="AddPart()">Add</button>
                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
            </div>
        </div>


    </div>
</div>

<div id="dialog-form-Piece" class="modal fade" role="dialog" title="Create Piece">
    <div class="modal-dialog">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title">Add New Piece</h4>
            </div>
            <div class="modal-body">
                <div class="form-group">
                    <label for="PieceTitle" class="col-form-label">Piece Title: </label><span class="glyphicon glyphicon-question-sign" data-toggle="tooltip" title="Name of the Book or Primary Name of the Score"></span>
                    <input type="text" id="PieceTitle" class="form-control" />
                </div>
                <div class="form-group">
                    <label for="SubTitle" class="col-form-label">Sub Title: </label><span class="glyphicon glyphicon-question-sign" data-toggle="tooltip" title="Book Part Number/Sub Title of the Score/Movement Part Name"></span>
                    <input type="text" id="SubTitle" class="form-control" />
                </div>
                <div class="form-group">
                    <label for="Composer" class="col-form-label">Composer: </label><span class="glyphicon glyphicon-question-sign" data-toggle="tooltip" title="Book Part Number/Sub Title of the Score/Movement Part Name"></span>
                    <input type="text" id="Composer" class="form-control" />
                </div>
                <div class="form-group">
                    <label for="Lyricist" class="col-form-label">Lyricist: </label><span class="glyphicon glyphicon-question-sign" data-toggle="tooltip" title="Book Part Number/Sub Title of the Score/Movement Part Name"></span>
                    <input type="text" id="Lyricist" class="form-control" />
                </div>
                <div class="form-group">
                    <label for="Publisher" class="col-form-label">Publisher: </label><span class="glyphicon glyphicon-question-sign" data-toggle="tooltip" title="Book Part Number/Sub Title of the Score/Movement Part Name"></span>
                    <input type="text" id="Publisher" class="form-control" />
                </div>
                <div class="form-group">
                    <label for="Publisher_REF" class="col-form-label">Publisher Refrence: </label><span class="glyphicon glyphicon-question-sign" data-toggle="tooltip" title="Book Part Number/Sub Title of the Score/Movement Part Name"></span>
                    <input type="text" id="Publisher_REF" class="form-control" />
                </div>
                <div class="form-group">
                    <label for="ISBN" class="col-form-label">ISBN: </label><span class="glyphicon glyphicon-question-sign" data-toggle="tooltip" title="Book Part Number/Sub Title of the Score/Movement Part Name"></span>
                    <input type="text" id="ISBN" class="form-control" />
                </div>
                <div class="form-group">
                    <label for="ptype" class="col-form-label">Piece Type: </label><span class="glyphicon glyphicon-question-sign" data-toggle="tooltip" title="Book Part Number/Sub Title of the Score/Movement Part Name"></span>
                    <select class="form-control" id="ptype"></select>
                </div>


            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-success" data-dismiss="modal" onclick="AddPiece()">Add</button>
                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
            </div>
        </div>
    </div>
</div>





@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
    <script type="text/javascript">

    // This is how you would add dynamic drop down box entrys on page load..  kind of cool
    $('#dialog-form-Piece').on('show.bs.modal', function (e) {
        $.ajax({
            type: "GET",
            /**/
            url: "@Url.Content("~/Home/PiecesTypes/")",
            /**/
            dataType: "json",
            success: function (result) {
                $("#ptype").empty();
                $("#ptype").append("<Option Value=0>Select a Type</option>");
                $.each(result, function (index, optiondata) {
                    $("#ptype").append("<Option Value='" + optiondata.TypeID + "'>" + optiondata.TypeName + "</option>");
                });
            },
            error: function (result) {
                alert('There was a problem please contact an Administrator');
            }
        })
    });


    function addpiecepart() {
        if ($("#PageNum").valid()) {
            showPleaseWait();
            PiecePartAddValid();
        } else {
            PiecePartAddFailed();
        }
    }

    function PiecePartAddFailed() {
        $("#pleaseWaitDialog").modal("hide");
        alert('There is an Error in your input please check before hitting save');
    }


        function PiecePartAddValid() {
        var PieceName = $("#PieceName").val();
        var Part = $("#Part").val();
        var PageNumber = $("#PageNum").val();
        $.ajax({
            type: "POST",
            /**/
            url: "@Url.Content("~/Home/AddPiecePart/")",
            /**/
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ pieceID: PieceName, partID: Part, pageNum: PageNumber,FileName: "@Model.FileName"}),
            dataType: "json",
            success: function (result) {
                $("#pleaseWaitDialog").modal("hide");
                window.history.go(-1);
            },
            error: function (result) {
                $("#pleaseWaitDialog").modal("hide");
                alert('There was a problem please contact an Administrator');
            }
        })
        }




function AddPiece() {
var PieceTitle = $("#PieceTitle").val();
var SubTitle = $("#SubTitle").val();
var Composer = $("#Composer").val();
var Lyricist = $("#Lyricist").val();
var Publisher = $("#Publisher").val();
var Publisher_REF = $("#Publisher_REF").val();
var ISBN = $("#ISBN").val();
var ptype = $("#ptype").val();

$.ajax({
    type: "POST",
    /**/
    url: "@Url.Content("~/Home/AddPiece/")",
    /**/
    contentType: "application/json; charset=utf-8",
    data: JSON.stringify({ PieceTitle: PieceTitle, SubTitle: SubTitle, Composer: Composer, Lyricist: Lyricist, Publisher: Publisher, Publisher_REF: Publisher_REF, ISBN: ISBN, ptype: ptype }),
    dataType: "json",
    success: function (result) {
        $("#PieceName").empty();
        //$("#PieceName").append("<Option Value=0>Select a Peice</option>");
        $.each(result, function (index, optiondata) {
            $("#PieceName").append("<Option Value='" + optiondata.MusicPieceId + "'>" + optiondata.Title + "</option>");
        });
        $("#PieceTitle").val("");
        $("#SubTitle").val("");
        $("#Composer").val("");
        $("#Lyricist").val("");
        $("#Publisher").val("");
        $("#Publisher_REF").val("");
        $("#ISBN").val("");
        $("#ptype").val("");
    },
    error: function (result) {
        alert('There was a problem please contact an Administrator');
    }
})
}

function AddPart() {
    var partname = $("#NewPart").val();
$.ajax({
    type: "POST",
    /**/
    url: "@Url.Content("~/Home/AddPart/")",
    /**/
    contentType: "application/json; charset=utf-8",
    data: JSON.stringify({ PartName: partname }),
    dataType: "json",
    success: function (result) {
        $("#Part").empty();
        //$("#Part").append("<Option Value=0>Select a Part</option>");
        $.each(result, function (index, optiondata) {
            $("#Part").append("<Option Value='" + optiondata.PartID + "'>" + optiondata.PartName + "</option>");
        });
        $("#NewPart").val("")
    },
    error: function (result) {
        alert('There was a problem please contact an Administrator');
    }
})
}

function showPleaseWait() {
var modalLoading = '<div class="modal fade" id="pleaseWaitDialog" data-backdrop="static" data-keyboard="false" role="dialog">\
    <div class="vertical-alignment-helper">\
        <div class="modal-dialog vertical-align-center" >\
    <div class="modal-content">\
        <div class="modal-header">\
            <h4 class="modal-title">Please wait...</h4>\
        </div>\
        <div class="modal-body">\
            <div class="progress">\
              <div class="progress-bar progress-bar-success progress-bar-striped active" role="progressbar"\
              aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width:100%; height: 40px">\
              </div>\
            </div>\
        </div>\
    </div>\
   </div>\
</div>\
</div>';
$(document.body).append(modalLoading);
$("#pleaseWaitDialog").modal();
}



    </script>
End Section

