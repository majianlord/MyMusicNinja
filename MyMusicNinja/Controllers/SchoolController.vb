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
    Public Class SchoolController
        Inherits System.Web.Mvc.Controller

        Private db As New ApplicationDbContext

        ' GET: School
        Function Index() As ActionResult
            Dim schoolModels = db.SchoolModels.Include(Function(s) s.Country).Include(Function(s) s.District).Include(Function(s) s.State)
            Return View(schoolModels.ToList())
        End Function

        ' GET: School/Details/5
        Function Details(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim schoolModel As SchoolModel = db.SchoolModels.Find(id)
            If IsNothing(schoolModel) Then
                Return HttpNotFound()
            End If
            Return View(schoolModel)
        End Function

        ' GET: School/Create
        Function Create() As ActionResult
            ViewBag.CountryID = New SelectList(db.CountryModels, "ID", "CountryName")
            ViewBag.DistrictID = New SelectList(db.DistrictModels, "ID", "DistrictName")
            ViewBag.StateID = New SelectList(db.StateModels, "ID", "StateName")
            Return View()
        End Function

        ' POST: School/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,SchoolName,DistrictID,Address1,Address2,City,StateID,ZipCode,CountryID,CareOff")> ByVal schoolModel As SchoolModel) As ActionResult
            If ModelState.IsValid Then
                db.SchoolModels.Add(schoolModel)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.CountryID = New SelectList(db.CountryModels, "ID", "CountryName", schoolModel.CountryID)
            ViewBag.DistrictID = New SelectList(db.DistrictModels, "ID", "DistrictName", schoolModel.DistrictID)
            ViewBag.StateID = New SelectList(db.StateModels, "ID", "StateName", schoolModel.StateID)
            Return View(schoolModel)
        End Function

        ' GET: School/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim schoolModel As SchoolModel = db.SchoolModels.Find(id)
            If IsNothing(schoolModel) Then
                Return HttpNotFound()
            End If
            ViewBag.CountryID = New SelectList(db.CountryModels, "ID", "CountryName", schoolModel.CountryID)
            ViewBag.DistrictID = New SelectList(db.DistrictModels, "ID", "DistrictName", schoolModel.DistrictID)
            ViewBag.StateID = New SelectList(db.StateModels, "ID", "StateName", schoolModel.StateID)
            Return View(schoolModel)
        End Function

        ' POST: School/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,SchoolName,DistrictID,Address1,Address2,City,StateID,ZipCode,CountryID,CareOff")> ByVal schoolModel As SchoolModel) As ActionResult
            If ModelState.IsValid Then
                db.Entry(schoolModel).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.CountryID = New SelectList(db.CountryModels, "ID", "CountryName", schoolModel.CountryID)
            ViewBag.DistrictID = New SelectList(db.DistrictModels, "ID", "DistrictName", schoolModel.DistrictID)
            ViewBag.StateID = New SelectList(db.StateModels, "ID", "StateName", schoolModel.StateID)
            Return View(schoolModel)
        End Function

        ' GET: School/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim schoolModel As SchoolModel = db.SchoolModels.Find(id)
            If IsNothing(schoolModel) Then
                Return HttpNotFound()
            End If
            Return View(schoolModel)
        End Function

        ' POST: School/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim schoolModel As SchoolModel = db.SchoolModels.Find(id)
            db.SchoolModels.Remove(schoolModel)
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
