@ModelType IEnumerable(Of LeaveStatusViewModel)
@Imports Microsoft.AspNet.Identity
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Leaves</h2>

<div class="table-wrapper">

    <Table Class="table">
        <tr>
            <th>
                Reason for leave
            </th>
            <th>
                Leave date
            </th>
            <th>
                Return date
            </th>
            <th>Status</th>
            <th>Reason for outcome</th>
            @If User.IsInRole("Admin") Then
                @<th>Action</th>
            End If
        </tr>

        @For Each item In Model
            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Reason)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.StartDate)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.EndDate)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.StatusName)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Comment)
                </td>
                @If User.IsInRole("Admin") Then

                    @<td>
                        <a class="btn button-update" href="@Url.Action("create", "status", New With {.LeaveID = item.LeaveID})"><i class="fa-solid fa-plus"></i> Edit status</a>
                    </td>
                End If
            </tr>
        Next
    </Table>
</div>
