Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports Leave_Management

Namespace Controllers
    Public Class statusController
        Inherits System.Web.Mvc.Controller

        Private db As New leaveEntities

        ' GET: status
        Function Index() As ActionResult
            Dim status = db.leavestatus.Include(Function(s) s.leave)
            Return View(status.ToList())
        End Function

        ' GET: status/Details/5
        Function Details(ByVal LeaveID As Integer?) As ActionResult
            If IsNothing(LeaveID) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim leavestatu As leavestatu = db.leavestatus.Find(LeaveID)
            If IsNothing(leavestatu) Then
                Return HttpNotFound()
            End If
            Return View(leavestatu)
        End Function

        ' GET: status/Create
        Function Create(ByVal LeaveID As Integer?) As ActionResult
            ViewBag.CurrentLeave = db.leaves.Where(Function(a) a.leave_id = LeaveID).FirstOrDefault()
            ViewBag.LeaveID = LeaveID
            Return View()
        End Function

        ' POST: status/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="status_id,status_name,comment,leave_id")> ByVal leavestatus As leavestatu) As ActionResult
            If ModelState.IsValid Then
                db.leavestatus.Add(leavestatus)
                db.SaveChanges()
                ViewBag.LeaveID = leavestatus.leave_id
                Return RedirectToAction("Index", "leaves", New With {.LeaveID = leavestatus.leave_id})
            End If
            Return View(leavestatus)
        End Function

        ' GET: status/Edit/5
        Function Edit(ByVal LeaveID As Integer?) As ActionResult
            If IsNothing(LeaveID) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim leavestatus As leavestatu = db.leavestatus.Find(LeaveID)
            If IsNothing(leavestatus) Then
                Return HttpNotFound()
            End If
            ViewBag.LeaveID = LeaveID
            Return View(leavestatus)
        End Function

        ' POST: status/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="status_id,status_name,comment,leave_id")> ByVal leavestatus As leavestatu) As ActionResult
            If ModelState.IsValid Then
                db.Entry(leavestatus).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Edit", New With {.LeaveID = leavestatus.leave_id})
            End If
            ViewBag.LeaveID = leavestatus.leave_id
            Return View(leavestatus)
        End Function

        ' GET: status/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim leavestatus As leavestatu = db.leavestatus.Find(id)
            If IsNothing(leavestatus) Then
                Return HttpNotFound()
            End If
            Return View(leavestatus)
        End Function

        ' POST: status/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim leavestatus As leavestatu = db.leavestatus.Find(id)
            db.leavestatus.Remove(leavestatus)
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
