Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports MyMusicNinja

Namespace Controllers
    Public Class LibrariesController
        Inherits System.Web.Mvc.Controller

        Private db As New ApplicationDbContext

        ' GET: Libraries
        Function Index() As ActionResult
            Dim libraries = db.Libraries.Include(Function(l) l.School)
            Return View(libraries.ToList())
        End Function

        ' GET: Libraries/Details/5
        Function Details(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim library As Library = db.Libraries.Find(id)
            If IsNothing(library) Then
                Return HttpNotFound()
            End If
            Return View(library)
        End Function

        ' GET: Libraries/Create
        Function Create() As ActionResult
            ViewBag.SchoolID = New SelectList(db.SchoolModels, "ID", "SchoolName")
            Return View()
        End Function

        ' POST: Libraries/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,LibraryName,SchoolID")> ByVal library As Library) As ActionResult
            If ModelState.IsValid Then
                db.Libraries.Add(library)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.SchoolID = New SelectList(db.SchoolModels, "ID", "SchoolName", library.SchoolID)
            Return View(library)
        End Function

        ' GET: Libraries/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim library As Library = db.Libraries.Find(id)
            If IsNothing(library) Then
                Return HttpNotFound()
            End If
            ViewBag.SchoolID = New SelectList(db.SchoolModels, "ID", "SchoolName", library.SchoolID)
            Return View(library)
        End Function

        ' POST: Libraries/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,LibraryName,SchoolID")> ByVal library As Library) As ActionResult
            If ModelState.IsValid Then
                db.Entry(library).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.SchoolID = New SelectList(db.SchoolModels, "ID", "SchoolName", library.SchoolID)
            Return View(library)
        End Function

        ' GET: Libraries/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim library As Library = db.Libraries.Find(id)
            If IsNothing(library) Then
                Return HttpNotFound()
            End If
            Return View(library)
        End Function

        ' POST: Libraries/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim library As Library = db.Libraries.Find(id)
            db.Libraries.Remove(library)
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
