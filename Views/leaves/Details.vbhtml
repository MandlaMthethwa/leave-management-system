@ModelType Leave_Management.leave
@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Details</h2>

<div>
    <h4>leave</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.reason)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.reason)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.start_date)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.start_date)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.end_date)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.end_date)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.leave_id }) |
    @Html.ActionLink("Back to List", "Index")
</p>
