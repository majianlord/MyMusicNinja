@ModelType MyMusicNinja.MusicPiece
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>MusicPiece</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.MusicType.MusicTypeName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.MusicType.MusicTypeName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.School.SchoolName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.School.SchoolName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Title)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Title)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.SubTitle)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.SubTitle)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Composer)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Composer)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Lyricist)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Lyricist)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Publisher)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Publisher)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Publisher_Ref)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Publisher_Ref)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ISBN)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ISBN)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.AzureContainerID)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.AzureContainerID)
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
