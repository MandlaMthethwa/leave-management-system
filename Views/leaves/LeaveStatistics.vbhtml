@ModelType LeaveStatisticsViewModel

@Code
    ViewData("Title") = "Leave Request Statistics"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Leave Request Statistics</h2>

<table>
    <tr>
        <th>Status</th>
        <th>Total</th>
    </tr>

    <tr>
        <td>Approved</td>
        <td>@Model.TotalApproved</td>
    </tr>
    <tr>
        <td>Rejected</td>
        <td>@Model.TotalRejected</td>
    </tr>
    <tr>
        <td>Total leaves</td>
        <td>@Model.TotalLeaves</td>
    </tr>
</table>
