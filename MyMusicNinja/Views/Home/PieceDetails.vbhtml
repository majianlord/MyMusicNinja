@ModelType MyMusicNinja.MusicPieces
@Code
    ViewData("Title") = "PieceDetails"
End Code

<h2>PieceDetails</h2>

<div>
    <h4>MusicPieces</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Title)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Title)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.SubTitle)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.SubTitle)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Composer)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Composer)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Lyricist)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Lyricist)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Publisher)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Publisher)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Publisher_Ref)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Publisher_Ref)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ISBN)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ISBN)
        </dd>
        <dt>
            Part Count
        </dt>
        <dd>@Html.DisplayFor(Function(model) model.Parts.Count) </dd>

    </dl>
</div>
<p>
    @*@Html.ActionLink("Edit", "Edit", New With {.id = Model.PrimaryKey}) |*@
    @Html.ActionLink("Back to List", "Index")
</p>
