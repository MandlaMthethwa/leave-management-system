@ModelType Leave_Management.leavestatu
@Code
    ViewData("Title") = "Create"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Update status</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
    <hr />
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
    <div class="form-group">
        <label>Choose status</label>
        <div class="col-md-10">
            <select class="form-control" name="status_name">
                <option value="Approved">Approved</option>
                <option value="Rejected">Rejected</option>
            </select>
            @Html.ValidationMessageFor(Function(model) model.status_name, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
       <label>Reason for outcome</label>
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.comment, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.comment, "", New With {.class = "text-danger"})
        </div>
    </div>

    
     <div>
         @*@Html.EditorFor(Function(model) model.leave_id, New With {.Value = ViewBag.LeaveID})*@
         <input type="hidden" id="leave_id" name="leave_id" value="@ViewBag.LeaveID" />

     </div>
    <div class="form-group">
        <div class="col-md-offset-2 col-md-10">
            <input type="submit" value="Update Status" class="btn button-update" />
        </div>
    </div>

</div>

End Using



@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
