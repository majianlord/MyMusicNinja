@ModelType MyMusicNinja.MusicPiece
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>MusicPiece</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.MusicType.MusicTypeName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.MusicType.MusicTypeName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.School.SchoolName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.School.SchoolName)
        </dd>

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
            @Html.DisplayNameFor(Function(model) model.AzureContainerID)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.AzureContainerID)
        </dd>

    </dl>
</div>

<div>
    <h4>Music Piece Parts</h4>
    <hr />
    <table>
        <thead>
            <tr>
                <th>
                    Piece Part
                </th>
                <th>
                    File Name
                </th>
            </tr>
        </thead>
        <tbody>
            @For Each PiecePart As MusicPiecePart In Model.Parts
                @<tr>
                    <td>
                        @PiecePart.Part.MusicPartName  
                    </td>
                    <td>
                        @PiecePart.FileName
                    </td>
                </tr>

            Next
        </tbody>
    </table>

</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.Id}) |
    @Html.ActionLink("Back to List", "Index")
</p>
