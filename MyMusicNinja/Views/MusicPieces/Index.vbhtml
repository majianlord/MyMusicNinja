@ModelType IEnumerable(Of MyMusicNinja.MusicPiece)
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
            @Html.DisplayNameFor(Function(model) model.MusicType.MusicTypeName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.School.SchoolName)
        </th>
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
        <th>
            @Html.DisplayNameFor(Function(model) model.Publisher_Ref)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.ISBN)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.AzureContainerID)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.MusicType.MusicTypeName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.School.SchoolName)
        </td>
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
            @Html.DisplayFor(Function(modelItem) item.Publisher_Ref)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ISBN)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.AzureContainerID)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.Id }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.Id }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.Id })
        </td>
    </tr>
Next

</table>
