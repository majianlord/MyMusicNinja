@ModelType MyMusicNinja.Library
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

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

        @Model.MusicBooks.Count
        @Model.MusicPieces.Count

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.ID}) |
    @Html.ActionLink("Back to List", "Index") | @Html.ActionLink("Add Piece", "Create", "MusicPiece", New With {.Library = Model.ID, .School = Model.SchoolID})
</p>
