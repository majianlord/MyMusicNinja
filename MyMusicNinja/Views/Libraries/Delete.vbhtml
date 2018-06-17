@ModelType MyMusicNinja.Library
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Library</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.School.SchoolName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.School.SchoolName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.LibraryName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.LibraryName)
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
