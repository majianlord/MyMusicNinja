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


    <HttpPost>
    Public Function UploadFiles(ByVal files As IEnumerable(Of HttpPostedFileBase)) As ActionResult
        For Each File As HttpPostedFileBase In files
            Dim filePath As String = Guid.NewGuid().ToString + Path.GetExtension(File.FileName)
            File.SaveAs(Path.Combine(Server.MapPath("~/UploadedFiles"), filePath))
        Next

        Return Json("file uploaded successfully")
    End Function



End Class
