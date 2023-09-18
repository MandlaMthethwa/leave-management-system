Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports Leave_Management
Imports Microsoft.AspNet.Identity

Namespace Controllers
    Public Class leavesController
        Inherits System.Web.Mvc.Controller

        Private db As New leaveEntities

        ' GET: leaves
        Function Index() As ActionResult
            If User.Identity.IsAuthenticated Then
                ' Check if the currently logged-in user is in the "Admin" role
                If User.IsInRole("Admin") Then
                    ' Admins can view all leave requests
                    From l In db.leaves
                    Group Join s In db.leavestatus On l.leave_id Equals s.leave_id Into statusGroup = Group
                    From statusRecord In statusGroup.DefaultIfEmpty()
                    Select New LeaveStatusViewModel With {
                    .LeaveID = l.leave_id,
                    .Reason = l.reason,
                    .StartDate = l.start_date,
                    .EndDate = l.end_date,
                    .StatusName = If(statusRecord IsNot Nothing, statusRecord.status_name, "Pending"),
                    .Comment = If(statusRecord IsNot Nothing, statusRecord.comment, String.Empty)
                }
            ).ToList()

                    Return View(allLeavesWithStatus)
                Else
                    ' Users can only view their own leave requests
                    Dim currentUserId = User.Identity.GetUserId()
                    Dim userLeavesWithStatus = (
                From l In db.leaves
                Where l.user_id = currentUserId
                Group Join s In db.leavestatus On l.leave_id Equals s.leave_id Into statusGroup = Group
                From statusRecord In statusGroup.DefaultIfEmpty()
                Select New LeaveStatusViewModel With {
                    .LeaveID = l.leave_id,
                    .Reason = l.reason,
                    .StartDate = l.start_date,
                    .EndDate = l.end_date,
                    .StatusName = If(statusRecord IsNot Nothing, statusRecord.status_name, "Pending"),
                    .Comment = If(statusRecord IsNot Nothing, statusRecord.comment, String.Empty)
                }
            ).ToList()

                    Return View(userLeavesWithStatus)
                End If
            Else
                ' Unauthorized user - redirect to login or display a message
                Return RedirectToAction("Login", "Account") ' Redirect to the login page
                ' Or, return a View with a message indicating unauthorized access
            End If
        End Function



        Function LeaveStatistics() As ActionResult
            Dim viewModel As New LeaveStatisticsViewModel()

            ' Calculate statistics
            'viewModel.TotalPending = db.leavestatus.Count(Function(l) l.status_name = "Pending")
            viewModel.TotalApproved = db.leavestatus.Count(Function(l) l.status_name = "Approved")
            viewModel.TotalRejected = db.leavestatus.Count(Function(l) l.status_name = "Rejected")
            viewModel.TotalLeaves = db.leaves.Count(Function(l) l.leave_id)
            ' Pass the statistics data to the view
            Return View(viewModel)
        End Function



        ' GET: leaves/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim leave As leave = db.leaves.Find(id)
            If IsNothing(leave) Then
                Return HttpNotFound()
            End If
            Return View(leave)
        End Function

        ' GET: leaves/Create
        Function Create() As ActionResult

            ' Get the current user's ID
            Dim currentUserId = User.Identity.GetUserId()

            ' Create a new leave object and set its user_id to the current user's ID
            Dim leave As New leave()
            leave.user_id = currentUserId

            Return View(leave)
        End Function

        ' POST: leaves/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="leave_id,reason,start_date,end_date")> ByVal leave As leave) As ActionResult
            If User.Identity.IsAuthenticated Then

                If leave.start_date < DateTime.Now Then
                    ModelState.AddModelError("start_date", "Start sate must not be in the past")
                End If
                If leave.end_date < DateTime.Now Then
                    ModelState.AddModelError("end_date", "End date must not be in the past")
                End If
                If leave.start_date >= leave.end_date Then
                    ModelState.AddModelError("StartDate", "Start date must  be before the end date")
                End If
                If ModelState.IsValid Then
                    Dim currentUserId = User.Identity.GetUserId()
                    ' Set the user_id of the leave object to the current user's ID
                    leave.user_id = currentUserId

                    db.leaves.Add(leave)
                    db.SaveChanges()
                    Dim LeaveID = db.leaves.Where(Function(o) o.leave_id = leave.leave_id).Select(Function(o) o.leave_id).FirstOrDefault()

                    Return RedirectToAction("Index")
                    Return RedirectToAction("Create", "status", New With {.LeaveID = LeaveID})

                End If
                Return View(leave)
            Else
                Return RedirectToAction("Login", "Account") ' Redirect to the login page
            End If
        End Function

        ' GET: leaves/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim leave As leave = db.leaves.Find(id)
            If IsNothing(leave) Then
                Return HttpNotFound()
            End If
            Return View(leave)
        End Function

        ' POST: leaves/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="leave_id,reason,start_date,end_date")> ByVal leave As leave) As ActionResult
            If ModelState.IsValid Then
                db.Entry(leave).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(leave)
        End Function

        ' GET: leaves/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim leave As leave = db.leaves.Find(id)
            If IsNothing(leave) Then
                Return HttpNotFound()
            End If
            Return View(leave)
        End Function

        ' POST: leaves/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim leave As leave = db.leaves.Find(id)
            db.leaves.Remove(leave)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
