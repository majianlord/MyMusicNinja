Imports System.IO


Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Return View()
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function

    Function BlobTest() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function

    Public Function GetFile(name As String) As ActionResult
        Dim folder = New DirectoryInfo(Server.MapPath("~/UploadedFiles/"))
        Dim file1 = folder.GetFiles(name).Single()
        Dim contentType = MimeMapping.GetMimeMapping(file1.Name)
        Return File(file1.FullName, contentType)
    End Function

    <HttpPost>
    Public Function AddPart(PartName As String) As ActionResult
        'Dim Dbconnect As New DatabaseActions()
        'If Dbconnect.AddtoPartsList(PartName) = False Then
        '    Return Json($"{PartName} we not added due to an error.  Please try again")
        'Else
        '    Dim Result As List(Of PiecesParts) = Dbconnect.PartsList
        '    Return Json(Result)
        'End If
    End Function

    Public Function AddPiecePart(pieceID As Int64, partID As Int64, pageNum As Int64, fileName As String) As ActionResult
        'Dim dBconnect As New DatabaseActions()
        'Dim mimeType As String = MimeMapping.GetMimeMapping(fileName)
        'Dim blobGuid As String = Guid.NewGuid().ToString + Path.GetExtension(fileName)
        'Dim piecePartID As Int64 = dBconnect.AddPiecesParts(pieceID, partID, pageNum, fileName, blobGuid, mimeType)
        'Dim azureInfo As AzurePiecePart = dBconnect.AzureStorageID(piecePartID)
        'Dim azz As New AzureBase
        'Dim folder = Server.MapPath("~/UploadedFiles/")
        'azz.CreateAzureBlob(azureinfo, folder)
        'Return Json("Success")
    End Function




    <HttpPost>
    Public Function AddPiece(PieceTitle As String, SubTitle As String, Composer As String, Lyricist As String, Publisher As String, Publisher_REF As String, ISBN As String, ptype As Int64) As ActionResult
        'Dim Dbconnect As New DatabaseActions()
        ''Need to get the right ownerID once we wire up proper ownership fo the system
        'If Dbconnect.addPiece(PieceTitle, SubTitle, Composer, Lyricist, Publisher, Publisher_REF, ISBN, 1, ptype) = True Then
        '    Dim Result As List(Of MusicPieces) = Dbconnect.PiecesListDropDown
        '    Return Json(Result)
        'Else
        '    Return Json("Error while trying to add new Piece Please try again")
        'End If
    End Function




    Public Function PiecesTypes() As ActionResult
        'Dim Dbconnect As New DatabaseActions()
        'Dim Result As List(Of PiecesType) = Dbconnect.TypeList
        'Return Json(Result, JsonRequestBehavior.AllowGet)
    End Function



    Public Function Process(name As String) As ActionResult
        'Dim Dbconnect As New DatabaseActions()
        'Dim Model As New ProccessUploadModels
        'Model.FileName = name
        'ViewBag.PieceList = New SelectList(Dbconnect.PiecesListDropDown, "MusicPieceId", "Title", "0")
        'ViewBag.PartList = New SelectList(Dbconnect.PartsList, "PartID", "PartName", "0")
        'Return View(Model)
    End Function

    Public Function DeleteFile(name As String)
        Dim folder = New DirectoryInfo(Server.MapPath("~/UploadedFiles/"))
        Dim file = folder.GetFiles(name).Single()
        file.Delete()
        Return Json($"{name} was deleted")
    End Function


    <HttpPost>
    Public Function UploadFiles(ByVal files As IEnumerable(Of HttpPostedFileBase)) As ActionResult
        Dim Filenames As New List(Of String)
        For Each File As HttpPostedFileBase In files
            Dim filePath As String = File.FileName  ' Guid.NewGuid().ToString + Path.GetExtension(File.FileName)
            File.SaveAs(Path.Combine(Server.MapPath("~/UploadedFiles"), filePath))
            Filenames.Add(File.FileName)
        Next
        Return UploadFiles(Filenames)
    End Function

    <HttpGet>
    Public Function UploadFiles(ByVal Optional filenames As IEnumerable(Of String) = Nothing) As ActionResult
        Dim folder = New DirectoryInfo(Server.MapPath("~/UploadedFiles/"))
        Dim files = From file In folder.GetFiles().Where(Function(x) Not LCase(x.Name) = LCase("DONOTDELETE.txt"))
                    Where filenames Is Nothing OrElse filenames.Contains(file.Name, StringComparer.OrdinalIgnoreCase)
                    Select New With {.deleteType = "POST", .name = file.Name, .size = file.Length, .processtype = "GET",
                    .url = Url.Action("GetFile", "Home", New With {file.Name}),
                    .processurl = Url.Action("Process", "Home", New With {file.Name}),
                    .deleteUrl = Url.Action("DeleteFile", "Home", New With {file.Name})}

        Return Json(New With {files}, JsonRequestBehavior.AllowGet)
    End Function


    Public Function ShowPieceList() As ActionResult
        'Dim Dbconnect As New DatabaseActions()
        'Dim result = Dbconnect.PiecesListFull(1)
        'Return View(result)
    End Function

    Public Function PieceDetails(pieceID As Int64) As ActionResult
        'Dim Dbconnect As New DatabaseActions()
        'Dim result = Dbconnect.PiecesDetails(pieceID)
        'Return View(result)
    End Function

    ''' <summary>
    ''' Gets the file information for the filename in question from the server.	
    ''' </summary>
    ''' <param name="fileName">Name of the file.</param>
    ''' <returns>FileInfo on the Object it Found Else Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetFileInfo(fileName As String) As FileInfo
        Dim folder = New DirectoryInfo(Server.MapPath("~/UploadedFiles/"))
        Dim file1 = folder.GetFiles(fileName).Single()
        Return file1
    End Function
End Class
