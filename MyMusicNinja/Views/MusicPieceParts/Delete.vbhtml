@ModelType MyMusicNinja.MusicPiecePart
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>MusicPiecePart</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.MusicPiece.Title)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.MusicPiece.Title)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Part.MusicPartName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Part.MusicPartName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Page)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Page)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.FileName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.FileName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.FileMimeType)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.FileMimeType)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.AzureContainerID)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.AzureContainerID)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.AzureBLOBID)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.AzureBLOBID)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
