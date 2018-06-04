@ModelType IEnumerable(Of MyMusicNinja.SchoolModel)
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
            @Html.DisplayNameFor(Function(model) model.Country.CountryName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.District.DistrictName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.State.StateName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.SchoolName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Address1)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Address2)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.City)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.ZipCode)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CareOff)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Country.CountryName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.District.DistrictName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.State.StateName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.SchoolName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Address1)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Address2)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.City)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ZipCode)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CareOff)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ID })
        </td>
    </tr>
Next

</table>
