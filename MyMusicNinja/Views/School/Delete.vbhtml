@ModelType MyMusicNinja.SchoolModel
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
