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
    Public Class DistrictController
        Inherits System.Web.Mvc.Controller

        Private db As New ApplicationDbContext

        ' GET: District
        Function Index() As ActionResult
            Dim districtModels = db.DistrictModels.Include(Function(d) d.State)
            Return View(districtModels.ToList())
        End Function

        ' GET: District/Details/5
        Function Details(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim districtModel As DistrictModel = db.DistrictModels.Find(id)

            If IsNothing(districtModel) Then
                Return HttpNotFound()
            End If
            Return View(districtModel)
        End Function

        ' GET: District/Create
        Function Create() As ActionResult
            ViewBag.StateID = New SelectList(db.StateModels, "ID", "StateName")
            Return View()
        End Function

        ' POST: District/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,DistrictName,StateID")> ByVal districtModel As DistrictModel) As ActionResult
            If ModelState.IsValid Then
                db.DistrictModels.Add(districtModel)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.StateID = New SelectList(db.StateModels, "ID", "StateName", districtModel.StateID)
            Return View(districtModel)
        End Function

        ' GET: District/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim districtModel As DistrictModel = db.DistrictModels.Find(id)
            If IsNothing(districtModel) Then
                Return HttpNotFound()
            End If
            ViewBag.StateID = New SelectList(db.StateModels, "ID", "StateName", districtModel.StateID)
            Return View(districtModel)
        End Function

        ' POST: District/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,DistrictName,StateID")> ByVal districtModel As DistrictModel) As ActionResult
            If ModelState.IsValid Then
                db.Entry(districtModel).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.StateID = New SelectList(db.StateModels, "ID", "StateName", districtModel.StateID)
            Return View(districtModel)
        End Function

        ' GET: District/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim districtModel As DistrictModel = db.DistrictModels.Find(id)
            If IsNothing(districtModel) Then
                Return HttpNotFound()
            End If
            Return View(districtModel)
        End Function

        ' POST: District/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim districtModel As DistrictModel = db.DistrictModels.Find(id)
            db.DistrictModels.Remove(districtModel)
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
