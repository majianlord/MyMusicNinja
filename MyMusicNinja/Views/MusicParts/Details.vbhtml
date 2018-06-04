@ModelType MyMusicNinja.MusicPart
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>MusicPart</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.MusicPartName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.MusicPartName)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
