@ModelType MyMusicNinja.DistrictModel
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>DistrictModel</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.State.StateName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.State.StateName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DistrictName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DistrictName)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
