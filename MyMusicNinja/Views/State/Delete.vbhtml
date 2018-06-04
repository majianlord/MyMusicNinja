@ModelType MyMusicNinja.StateModel
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
