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
    Public Class StateController
        Inherits System.Web.Mvc.Controller

        Private db As New ApplicationDbContext

        ' GET: State
        Function Index() As ActionResult
            Dim stateModels = db.StateModels.Include(Function(s) s.Country)
            Return View(stateModels.ToList())
        End Function

        ' GET: State/Details/5
        Function Details(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim stateModel As StateModel = db.StateModels.Find(id)
            If IsNothing(stateModel) Then
                Return HttpNotFound()
            End If
            Return View(stateModel)
        End Function

        ' GET: State/Create
        Function Create() As ActionResult
            ViewBag.CountryID = New SelectList(db.CountryModels, "ID", "CountryName")
            Return View()
        End Function

        ' POST: State/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,StateName,StateShort,CountryID")> ByVal stateModel As StateModel) As ActionResult
            If ModelState.IsValid Then
                db.StateModels.Add(stateModel)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.CountryID = New SelectList(db.CountryModels, "ID", "CountryName", stateModel.CountryID)
            Return View(stateModel)
        End Function

        ' GET: State/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim stateModel As StateModel = db.StateModels.Find(id)
            If IsNothing(stateModel) Then
                Return HttpNotFound()
            End If
            ViewBag.CountryID = New SelectList(db.CountryModels, "ID", "CountryName", stateModel.CountryID)
            Return View(stateModel)
        End Function

        ' POST: State/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,StateName,StateShort,CountryID")> ByVal stateModel As StateModel) As ActionResult
            If ModelState.IsValid Then
                db.Entry(stateModel).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.CountryID = New SelectList(db.CountryModels, "ID", "CountryName", stateModel.CountryID)
            Return View(stateModel)
        End Function

        ' GET: State/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim stateModel As StateModel = db.StateModels.Find(id)
            If IsNothing(stateModel) Then
                Return HttpNotFound()
            End If
            Return View(stateModel)
        End Function

        ' POST: State/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim stateModel As StateModel = db.StateModels.Find(id)
            db.StateModels.Remove(stateModel)
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
