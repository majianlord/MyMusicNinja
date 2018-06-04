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
    Public Class CountryController
        Inherits System.Web.Mvc.Controller

        Private db As New ApplicationDbContext

        ' GET: Country
        Function Index() As ActionResult
            Return View(db.CountryModels.ToList())
        End Function

        ' GET: Country/Details/5
        Function Details(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim countryModel As CountryModel = db.CountryModels.Find(id)
            If IsNothing(countryModel) Then
                Return HttpNotFound()
            End If
            Return View(countryModel)
        End Function

        ' GET: Country/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Country/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,CountryName")> ByVal countryModel As CountryModel) As ActionResult
            If ModelState.IsValid Then
                db.CountryModels.Add(countryModel)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(countryModel)
        End Function

        ' GET: Country/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim countryModel As CountryModel = db.CountryModels.Find(id)
            If IsNothing(countryModel) Then
                Return HttpNotFound()
            End If
            Return View(countryModel)
        End Function

        ' POST: Country/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,CountryName")> ByVal countryModel As CountryModel) As ActionResult
            If ModelState.IsValid Then
                db.Entry(countryModel).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(countryModel)
        End Function

        ' GET: Country/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim countryModel As CountryModel = db.CountryModels.Find(id)
            If IsNothing(countryModel) Then
                Return HttpNotFound()
            End If
            Return View(countryModel)
        End Function

        ' POST: Country/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim countryModel As CountryModel = db.CountryModels.Find(id)
            db.CountryModels.Remove(countryModel)
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
