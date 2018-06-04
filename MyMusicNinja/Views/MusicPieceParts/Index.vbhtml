@ModelType IEnumerable(Of MyMusicNinja.MusicPiecePart)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.MusicPiece.Title)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Part.MusicPartName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Page)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.FileName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.FileMimeType)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.AzureContainerID)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.AzureBLOBID)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.MusicPiece.Title)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Part.MusicPartName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Page)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.FileName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.FileMimeType)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.AzureContainerID)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.AzureBLOBID)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ID })
        </td>
    </tr>
Next

</table>
