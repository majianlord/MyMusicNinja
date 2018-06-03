@Code
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<link rel="stylesheet" href="~/Content/jQuery.FileUpload/css/jquery.fileupload.css">
<link rel="stylesheet" href="~/Content/jQuery.FileUpload/css/jquery.fileupload-ui.css">
<br />
<br />
<h1>Drag and Drop Scanned Music to Upload or use add files Button.</h1>
<!-- The file upload form used as target for the file upload widget -->
<form id="fileupload" action="https://jquery-file-upload.appspot.com/" method="POST" enctype="multipart/form-data">
   <!-- The fileupload-buttonbar contains buttons to add/delete files and start/cancel the upload -->
    <div class="row fileupload-buttonbar">
        <div class="col-lg-7">
            <!-- The fileinput-button span is used to style the file input field as button -->
            <span class="btn btn-success fileinput-button">
                <i class="glyphicon glyphicon-plus"></i>
                <span>Add files...</span>
                <input type="file" name="files" multiple>
            </span>
    <!--
    <button type="submit" class="btn btn-primary start">
        <i class="glyphicon glyphicon-upload"></i>
        <span>Start upload</span>
    </button>
    <button type="reset" class="btn btn-warning cancel">
        <i class="glyphicon glyphicon-ban-circle"></i>
        <span>Cancel upload</span>
    </button>
    -->
            <button type="button" class="btn btn-danger delete">
                <i class="glyphicon glyphicon-trash"></i>
                <span>Delete</span>
            </button>
            <input type="checkbox" class="toggle">
            <!-- The global file processing state -->
            <span class="fileupload-process"></span>
        </div>
        <!-- The global progress state -->
        <div class="col-lg-5 fileupload-progress fade">
            <!-- The global progress bar -->
            <div class="progress progress-striped active" role="progressbar" aria-valuemin="0" aria-valuemax="100">
                <div class="progress-bar progress-bar-success" style="width:0%;"></div>
            </div>
            <!-- The extended global progress state -->
            <div class="progress-extended">&nbsp;</div>
        </div>
    </div>
    <!-- The table listing the files available for upload/download -->
    <table role="presentation" class="table table-striped"><thead>
           <tr>
               <td>File</td>
               <td>Size/Status</td>
               <td style="text-align:right;">Actions</td>
               <td style="text-align:center;">Mark for Delete</td>
           </tr>
           </thead><tbody class="files"></tbody></table>
</form>



@section Scripts
<script src="~/Scripts/tmpl.min.js"></script>
    <script src="~/Scripts/jQuery.FileUpload/jquery.fileupload.js"></script>
    <script src="~/Scripts/jQuery.FileUpload/jquery.fileupload-jquery-ui.js"></script>
    <script src="~/Scripts/jQuery.FileUpload/jquery.fileupload-process.js"></script>
    <script src="~/Scripts/jQuery.FileUpload/jquery.fileupload-ui.js"></script>
    <script src="~/Scripts/jQuery.FileUpload/jquery.fileupload-validate.js"></script>
    <script src="~/Scripts/jQuery.FileUpload/jquery.iframe-transport.js"></script>
    

    <script>
        var url = 'UploadFiles'
        $(document).ready(function () {
            'use strict';
            // Change this to the location of your server-side upload handler:
            
            $('#fileupload').fileupload({
                url: url,
                dataType: 'json',
                autoUpload: true,
                maxFileSize: 999000000,
            })

            $('#fileupload').addClass('fileupload-processing');
            $.ajax({
                // Uncomment the following to send cross-domain cookies:
                //xhrFields: {withCredentials: true},
                url: url,
                type: 'get',
                dataType: 'json',
                context: $('#fileupload')[0]
            }).always(function () {
                $(this).removeClass('fileupload-processing');
            }).done(function (result) {
                $(this).fileupload('option', 'done')
                    .call(this, $.Event('done'), { result: result });
            });



        });
        if ($.support.cors) {
            $.ajax({
                url: 'index',
                type: 'HEAD'
            }).fail(function () {
                $('<div class="alert alert-danger"/>')
                    .text('Upload server currently unavailable - ' +
                    new Date())
                    .appendTo('#fileupload');
            });
        };

        function showPleaseWait() {
            var modalLoading = '<div class="modal" id="pleaseWaitDialog" data-backdrop="static" data-keyboard="false role="dialog">\
        <div class="modal-dialog">\
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
    </div>';
            $(document.body).append(modalLoading);
            $("#pleaseWaitDialog").modal("show");
        }



    </script>
End Section


<!-- The template to display files available for upload -->
<script id="template-upload" type="text/x-tmpl">
    {% for (var i=0, file; file=o.files[i]; i++) { %}
    <tr class="template-upload fade">
        <td>
            <p class="name">{%=file.name%}</p>
            <strong class="error text-danger"></strong>
        </td>
        <td>
            <p class="size">Processing...</p>
            <div class="progress progress-striped active" role="progressbar" aria-valuemin="0" aria-valuemax="100" aria-valuenow="0"><div class="progress-bar progress-bar-success" style="width:0%;"></div></div>
        </td>
        <td>
            {% if (!i && !o.options.autoUpload) { %}
            <button class="btn btn-primary start" disabled>
                <i class="glyphicon glyphicon-upload"></i>
                <span>Start</span>
            </button>
            {% } %}
            {% if (!i) { %}
            <button class="btn btn-warning cancel">
                <i class="glyphicon glyphicon-ban-circle"></i>
                <span>Cancel</span>
            </button>
            {% } %}
        </td>
    </tr>
    {% } %}
</script>
<!-- The template to display files available for download -->
<script id="template-download" type="text/x-tmpl">
    {% for (var i=0, file; file=o.files[i]; i++) { %}
    <tr class="template-download fade">
        <td>
            <p class="name">
                {% if (file.url) { %}
                <a href="{%=file.url%}" title="{%=file.name%}" download="{%=file.name%}" {%=file.thumbnailUrl?'data-gallery':''%}>{%=file.name%}</a>
                {% } else { %}
                <span>{%=file.name%}</span>
                {% } %}
            </p>
            {% if (file.error) { %}
            <div><span class="label label-danger">Error</span> {%=file.error%}</div>
            {% } %}
        </td>
        <td>
            <span class="size">{%=o.formatFileSize(file.size)%}</span>
        </td>
        <td style="text-align:right;">
            {% if (file.deleteUrl) { %}
            <button class="btn btn-danger delete" data-type="{%=file.deleteType%}" data-url="{%=file.deleteUrl%}" {% if (file.deleteWithCredentials) { %} data-xhr-fields='{"withCredentials":true}' {% } %}>
                <i class="glyphicon glyphicon-trash"></i>
                <span>Delete</span>
            </button>
            {% } else { %}
            <button class="btn btn-warning cancel">
                <i class="glyphicon glyphicon-ban-circle"></i>
                <span>Cancel</span>
            </button>
            {% } %}
            {% if (file.processurl) { %}
            <button type="button" class="btn btn-success success" data-type="{%=file.processtype%}" data-url="{%=file.processurl%}" onclick="location.href='{%=file.processurl%}'"  >
                <i class="glyphicon glyphicon-book"></i>
                <span>Process</span>
            </button>
            {% } %}
        </td>
        <td style="text-align:center;">
            {% if (file.deleteUrl) { %}
            <input type="checkbox" name="delete" value="1" class="toggle">
            {% } %}
        </td>
    </tr>
    {% } %}
</script>