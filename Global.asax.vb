Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Optimization
Imports System.Web.Routing
Imports System.Data.Entity      ' Import for Database class
Imports System.Data.Entity.Migrations
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Leave_Management.Migrations

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Protected Sub Application_Start()
        AreaRegistration.RegisterAllAreas()
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)

        Database.SetInitializer(New MigrateDatabaseToLatestVersion(Of ApplicationDbContext, Configuration)())
        Dim context As New ApplicationDbContext()
        Dim roleManager As New RoleManager(Of IdentityRole)(New RoleStore(Of IdentityRole)(context))

        ' Create the "Admin" role if it doesn't exist
        If Not roleManager.RoleExists("Admin") Then
            roleManager.Create(New IdentityRole("Admin"))
        End If

        ' Create the default admin user if it doesn't exist
        Dim userManager As New UserManager(Of ApplicationUser)(New UserStore(Of ApplicationUser)(context))
        Dim adminUser = userManager.FindByName("admin")

        If adminUser Is Nothing Then
            adminUser = New ApplicationUser() With {
                .UserName = "admin",
                .Email = "admin@leavemanagement.com",
                .EmailConfirmed = True
            }

            Dim result = userManager.Create(adminUser, "Admin123@LeaveManagement")

            If result.Succeeded Then
                userManager.AddToRole(adminUser.Id, "Admin")
            End If
        End If
        context.Dispose()



    End Sub
End Class
