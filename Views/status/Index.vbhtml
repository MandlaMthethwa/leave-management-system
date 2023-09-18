@ModelType IEnumerable(Of Leave_Management.leavestatu)
@Code
ViewData("Title") = "Index"
Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.status_name)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.comment)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.leave.reason)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.status_name)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.comment)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.leave.reason)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.status_id }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.status_id }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.status_id })
        </td>
    </tr>
Next

</table>
