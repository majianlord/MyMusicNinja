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

    Public Function GetFile(name As String)
        Dim folder = New DirectoryInfo(Server.MapPath("~/UploadedFiles/"))
        Dim file1 = folder.GetFiles(name).Single()
        Dim contentType = MimeMapping.GetMimeMapping(file1.Name)
        Return File(file1.FullName, contentType)

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
    Public Function UploadFiles(ByVal Optional Filenames As IEnumerable(Of String) = Nothing) As ActionResult
        Dim folder = New DirectoryInfo(Server.MapPath("~/UploadedFiles/"))
        Dim files = From file In folder.GetFiles().Where(Function(x) Not LCase(x.Name) = LCase("DONOTDELETE.txt"))
                    Where Filenames Is Nothing OrElse Filenames.Contains(file.Name, StringComparer.OrdinalIgnoreCase)
                    Select New With {.deleteType = "POST", .name = file.Name, .size = file.Length,
                    .url = Url.Action("GetFile", "Home", New With {file.Name}),
                    .deleteUrl = Url.Action("DeleteFile", "Home", New With {file.Name})}

        Return Json(New With {files}, JsonRequestBehavior.AllowGet)

    End Function



End Class
