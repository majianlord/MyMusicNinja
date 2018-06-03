@ModelType IEnumerable(Of MyMusicNinja.MusicPieces)
@Code
    ViewData("Title") = "View"
End Code

<h2>View</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Title)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.SubTitle)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Composer)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Lyricist)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Publisher)
        </th>
        <th>Total Parts/Pages</th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
    <td>
        @Html.DisplayFor(Function(modelItem) item.Title)
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.SubTitle)
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.Composer)
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.Lyricist)
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.Publisher)
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.Parts.Count)
    </td>

    <td>
        @Html.ActionLink("PieceDetails", "PieceDetails", New With {.PieceID = item.MusicPieceId})
        @*@Html.ActionLink("Edit", "Edit", New With {.id = item.PrimaryKey}) |
        @Html.ActionLink("Delete", "Delete", New With {.id = item.PrimaryKey})*@
    </td>
</tr>
Next

</table>
