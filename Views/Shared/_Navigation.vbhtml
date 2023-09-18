@Imports Microsoft.AspNet.Identity

<header>
    <nav class="navbar">
        <div>
            <img class="logo" src="data:image/jpeg;base64,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" atl="logo" \>
        </div>
        <div class="content">
            <ul class="menu-list">
                <div class="icon cancel-btn">
                    <i class="fas fa-times"></i>
                </div>

                <li><a href=" @Url.Action("index", "leaves")">Home</a></li>

                <li><a href=" @Url.Action("create", "leaves")">Request Leave</a></li>
                <li>
                    @If User.IsInRole("Admin") Then
                        @<a  href="@Url.Action("LeaveStatistics", "leaves")"> View Statistics</a>
                    End If
                </li>

                @If Request.IsAuthenticated Then
                    @Using Html.BeginForm("LogOff", "Account", FormMethod.Post, New With {.id = "logoutForm", .Class = "menu navbar-right"})
                        @Html.AntiForgeryToken()
                        @<li><a href="javascript:document.getElementById('logoutForm').submit()"> Log off</a></li>

                    End Using
                Else

                    @<li>@Html.ActionLink("Register", "Register", "Account", routeValues:=Nothing, htmlAttributes:=New With {.id = "registerLink"})</li>
                    @<li>@Html.ActionLink("Log in", "Login", "Account", routeValues:=Nothing, htmlAttributes:=New With {.id = "loginLink"})</li>
                End If
            </ul>


            <div Class="icon menu-btn">
                <i Class="fas fa-bars"></i>
            </div>
        </div>
    </nav>
</header>