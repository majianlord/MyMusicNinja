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
    Public Class MusicPiecesController
        Inherits System.Web.Mvc.Controller

        Private db As New ApplicationDbContext

        ' GET: MusicPieces
        Function Index() As ActionResult
            Dim musicPieceModels = db.MusicPieceModels.Include(Function(m) m.MusicType).Include(Function(m) m.School)
            Return View(musicPieceModels.ToList())
        End Function

        ' GET: MusicPieces/Details/5
        Function Details(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim musicPiece As MusicPiece = db.MusicPieceModels.Find(id)
            If IsNothing(musicPiece) Then
                Return HttpNotFound()
            End If
            Return View(musicPiece)
        End Function

        ' GET: MusicPieces/Create
        Function Create() As ActionResult
            ViewBag.MusicTypeID = New SelectList(db.MusicTypeModels, "ID", "MusicTypeName")
            ViewBag.SchoolId = New SelectList(db.SchoolModels, "ID", "SchoolName")
            Return View()
        End Function

        ' POST: MusicPieces/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Title,SubTitle,Composer,Lyricist,Publisher,Publisher_Ref,ISBN,SchoolId,MusicTypeID")> ByVal musicPiece As MusicPiece) As ActionResult
            musicPiece.AzureContainerID = Guid.NewGuid().ToString
            If ModelState.IsValid Then
                db.MusicPieceModels.Add(musicPiece)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.MusicTypeID = New SelectList(db.MusicTypeModels, "ID", "MusicTypeName", musicPiece.MusicTypeID)
            ViewBag.SchoolId = New SelectList(db.SchoolModels, "ID", "SchoolName", musicPiece.SchoolId)
            Return View(musicPiece)
        End Function

        ' GET: MusicPieces/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim musicPiece As MusicPiece = db.MusicPieceModels.Find(id)
            If IsNothing(musicPiece) Then
                Return HttpNotFound()
            End If
            ViewBag.MusicTypeID = New SelectList(db.MusicTypeModels, "ID", "MusicTypeName", musicPiece.MusicTypeID)
            ViewBag.SchoolId = New SelectList(db.SchoolModels, "ID", "SchoolName", musicPiece.SchoolId)
            Return View(musicPiece)
        End Function

        ' POST: MusicPieces/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,Title,SubTitle,Composer,Lyricist,Publisher,Publisher_Ref,ISBN,SchoolId,MusicTypeID")> ByVal musicPiece As MusicPiece) As ActionResult
            Dim musicPiece1 As MusicPiece = db.MusicPieceModels.Find(musicPiece.Id)
            UpdateModel(musicPiece1, includeProperties:=New String() {"ID", "Title", "SubTitle", "Composer", "Lyricist", "Publisher", "Publisher_Ref", "ISBN", "SchoolId", "MusicTypeID"})
            If ModelState.IsValid Then
                db.Entry(musicPiece1).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.MusicTypeID = New SelectList(db.MusicTypeModels, "ID", "MusicTypeName", musicPiece.MusicTypeID)
            ViewBag.SchoolId = New SelectList(db.SchoolModels, "ID", "SchoolName", musicPiece.SchoolId)
            Return View(musicPiece1)
        End Function

        ' GET: MusicPieces/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim musicPiece As MusicPiece = db.MusicPieceModels.Find(id)
            If IsNothing(musicPiece) Then
                Return HttpNotFound()
            End If
            Return View(musicPiece)
        End Function

        ' POST: MusicPieces/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim musicPiece As MusicPiece = db.MusicPieceModels.Find(id)
            db.MusicPieceModels.Remove(musicPiece)
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
