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
    Public Class MusicTypesController
        Inherits System.Web.Mvc.Controller

        Private db As New ApplicationDbContext

        ' GET: MusicTypes
        Function Index() As ActionResult
            Return View(db.MusicTypeModels.ToList())
        End Function

        ' GET: MusicTypes/Details/5
        Function Details(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim musicType As MusicType = db.MusicTypeModels.Find(id)
            If IsNothing(musicType) Then
                Return HttpNotFound()
            End If
            Return View(musicType)
        End Function

        ' GET: MusicTypes/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: MusicTypes/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,MusicTypeName")> ByVal musicType As MusicType) As ActionResult
            If ModelState.IsValid Then
                db.MusicTypeModels.Add(musicType)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(musicType)
        End Function

        ' GET: MusicTypes/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim musicType As MusicType = db.MusicTypeModels.Find(id)
            If IsNothing(musicType) Then
                Return HttpNotFound()
            End If
            Return View(musicType)
        End Function

        ' POST: MusicTypes/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,MusicTypeName")> ByVal musicType As MusicType) As ActionResult
            If ModelState.IsValid Then
                db.Entry(musicType).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(musicType)
        End Function

        ' GET: MusicTypes/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim musicType As MusicType = db.MusicTypeModels.Find(id)
            If IsNothing(musicType) Then
                Return HttpNotFound()
            End If
            Return View(musicType)
        End Function

        ' POST: MusicTypes/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim musicType As MusicType = db.MusicTypeModels.Find(id)
            db.MusicTypeModels.Remove(musicType)
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
