'Imports Microsoft.AspNet.Identity
'Imports Microsoft.AspNet.Identity.EntityFramework
'Imports System.Data.Entity.Migrations

'Public Class UserSeeder
'    Inherits DbMigration

'    Public Overrides Sub Up()
'        ' Create a UserManager and RoleManager
'        Dim userManager As New UserManager(Of IdentityUser)(New UserStore(Of IdentityUser)(New ApplicationDbContext()))
'        Dim roleManager As New RoleManager(Of IdentityRole)(New RoleStore(Of IdentityRole)(New ApplicationDbContext()))

'        ' Create the "Admin" role if it doesn't exist
'        If Not roleManager.RoleExists("Admin") Then
'            roleManager.Create(New IdentityRole() With {
'                .Name = "Admin"
'            })
'        End If

'        ' Check if the user with the desired username exists
'        Dim adminUser = userManager.FindByName("admin@leavemanagement.com")

'        ' Create the user if it doesn't exist
'        If adminUser Is Nothing Then
'            adminUser = New IdentityUser() With {
'                .UserName = "admin", ' Set the desired username
'                .Email = "admin@leavemanagement.com",    ' Set the desired email address
'                .EmailConfirmed = True          ' You can set this as needed
'            }

'            ' Create the user with a password
'            Dim result = userManager.Create(adminUser, "admin@LeaveManagement")

'            ' Assign the "Admin" role to the user
'            If result.Succeeded Then
'                userManager.AddToRole(adminUser.Id, "Admin")
'            End If
'        End If
'    End Sub

'    Public Overrides Sub Down()
'        ' Remove the user and role if needed
'    End Sub
'End Class
