@ModelType Leave_Management.leave
@Code
    ViewData("Title") = "Create"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Request Leave</h2>

@Using (Html.BeginForm()) 
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal ">
        <hr />
        @Html.ValidationSummary(True, "", New With { .class = "text-danger" })
        <div class="form-group">
        <label>What is your reason for leave</label>            
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.reason, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.reason, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
          <label>When do you leave?</label>          
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.start_date, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.start_date, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            <label>When are you returning?</label>
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.end_date, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.end_date, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Request" class="btn button-add" />
            </div>
        </div>
    </div>
End Using


@Section Scripts 
    @Scripts.Render("~/bundles/jqueryval")
End Section
