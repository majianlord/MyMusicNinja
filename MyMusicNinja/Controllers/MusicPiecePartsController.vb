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
    Public Class MusicPiecePartsController
        Inherits System.Web.Mvc.Controller

        Private db As New ApplicationDbContext

        ' GET: MusicPieceParts
        Function Index() As ActionResult
            Dim musicPiecePartModels = db.MusicPiecePartModels.Include(Function(m) m.MusicPiece).Include(Function(m) m.Part)
            Return View(musicPiecePartModels.ToList())
        End Function

        ' GET: MusicPieceParts/Details/5
        Function Details(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim musicPiecePart As MusicPiecePart = db.MusicPiecePartModels.Find(id)
            If IsNothing(musicPiecePart) Then
                Return HttpNotFound()
            End If
            Return View(musicPiecePart)
        End Function

        ' GET: MusicPieceParts/Create
        Function Create() As ActionResult
            ViewBag.MusicPieceID = New SelectList(db.MusicPieceModels, "Id", "Title")
            ViewBag.PartID = New SelectList(db.MusicPartModels, "ID", "MusicPartName")
            Return View()
        End Function

        ' POST: MusicPieceParts/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,MusicPieceID,PartID,Page,FileName")> ByVal musicPiecePart As MusicPiecePart) As ActionResult
            musicPiecePart.AzureContainerID = db.MusicPieceModels.Find(musicPiecePart.MusicPieceID).AzureContainerID
            musicPiecePart.AzureBLOBID = Guid.NewGuid().ToString
            If ModelState.IsValid Then
                db.MusicPiecePartModels.Add(musicPiecePart)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.MusicPieceID = New SelectList(db.MusicPieceModels, "Id", "Title", musicPiecePart.MusicPieceID)
            ViewBag.PartID = New SelectList(db.MusicPartModels, "ID", "MusicPartName", musicPiecePart.PartID)
            Return View(musicPiecePart)
        End Function

        ' GET: MusicPieceParts/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim musicPiecePart As MusicPiecePart = db.MusicPiecePartModels.Find(id)
            If IsNothing(musicPiecePart) Then
                Return HttpNotFound()
            End If
            ViewBag.MusicPieceID = New SelectList(db.MusicPieceModels, "Id", "Title", musicPiecePart.MusicPieceID)
            ViewBag.PartID = New SelectList(db.MusicPartModels, "ID", "MusicPartName", musicPiecePart.PartID)
            Return View(musicPiecePart)
        End Function

        ' POST: MusicPieceParts/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,MusicPieceID,PartID,Page")> ByVal musicPiecePart As MusicPiecePart) As ActionResult
            Dim musicPiecePart1 As MusicPiecePart = db.MusicPiecePartModels.Find(musicPiecePart.ID)
            UpdateModel(musicPiecePart1, includeProperties:=New String() {"ID", "MusicPieceID", "PartID", "Page"})
            If ModelState.IsValid Then
                db.Entry(musicPiecePart1).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.MusicPieceID = New SelectList(db.MusicPieceModels, "Id", "Title", musicPiecePart.MusicPieceID)
            ViewBag.PartID = New SelectList(db.MusicPartModels, "ID", "MusicPartName", musicPiecePart.PartID)
            Return View(musicPiecePart)
        End Function

        ' GET: MusicPieceParts/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim musicPiecePart As MusicPiecePart = db.MusicPiecePartModels.Find(id)
            If IsNothing(musicPiecePart) Then
                Return HttpNotFound()
            End If
            Return View(musicPiecePart)
        End Function

        ' POST: MusicPieceParts/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim musicPiecePart As MusicPiecePart = db.MusicPiecePartModels.Find(id)
            db.MusicPiecePartModels.Remove(musicPiecePart)
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
