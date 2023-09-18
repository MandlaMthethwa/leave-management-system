@ModelType Leave_Management.leavestatu
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>status</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.status_name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.status_name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.comment)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.comment)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.leave.reason)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.leave.reason)
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
