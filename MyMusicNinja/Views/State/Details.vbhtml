@ModelType MyMusicNinja.StateModel
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>StateModel</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Country.CountryName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Country.CountryName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.StateName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.StateName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.StateShort)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.StateShort)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
