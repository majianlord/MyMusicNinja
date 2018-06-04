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
    Public Class MusicPartsController
        Inherits System.Web.Mvc.Controller

        Private db As New ApplicationDbContext

        ' GET: MusicParts
        Function Index() As ActionResult
            Return View(db.MusicPartModels.ToList())
        End Function

        ' GET: MusicParts/Details/5
        Function Details(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim musicPart As MusicPart = db.MusicPartModels.Find(id)
            If IsNothing(musicPart) Then
                Return HttpNotFound()
            End If
            Return View(musicPart)
        End Function

        ' GET: MusicParts/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: MusicParts/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,MusicPartName")> ByVal musicPart As MusicPart) As ActionResult
            If ModelState.IsValid Then
                db.MusicPartModels.Add(musicPart)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(musicPart)
        End Function

        ' GET: MusicParts/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim musicPart As MusicPart = db.MusicPartModels.Find(id)
            If IsNothing(musicPart) Then
                Return HttpNotFound()
            End If
            Return View(musicPart)
        End Function

        ' POST: MusicParts/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,MusicPartName")> ByVal musicPart As MusicPart) As ActionResult
            If ModelState.IsValid Then
                db.Entry(musicPart).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(musicPart)
        End Function

        ' GET: MusicParts/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim musicPart As MusicPart = db.MusicPartModels.Find(id)
            If IsNothing(musicPart) Then
                Return HttpNotFound()
            End If
            Return View(musicPart)
        End Function

        ' POST: MusicParts/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim musicPart As MusicPart = db.MusicPartModels.Find(id)
            db.MusicPartModels.Remove(musicPart)
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
