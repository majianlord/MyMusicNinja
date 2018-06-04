@ModelType MyMusicNinja.SchoolModel
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>SchoolModel</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Country.CountryName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Country.CountryName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.District.DistrictName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.District.DistrictName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.State.StateName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.State.StateName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.SchoolName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.SchoolName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Address1)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Address1)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Address2)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Address2)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.City)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.City)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ZipCode)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ZipCode)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.CareOff)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CareOff)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
