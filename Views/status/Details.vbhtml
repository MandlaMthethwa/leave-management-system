@ModelType Leave_Management.leavestatu
@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Details</h2>

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
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With {.LeaveID = Model.status_id}) |
    @Html.ActionLink("Back to List", "Index")
</p>
