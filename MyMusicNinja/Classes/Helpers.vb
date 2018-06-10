Imports System.Net.Mail

Public Class Helpers
    Public IsError As Boolean = False
    Public IsErrorString As String = ""
    Public Function sendEmail(MailTo As String, MailFrom As String, MailSubject As String, MailBody As String, Optional MailHTML As Boolean = False) As NinjaResults
        Dim Settings As New NinjaSettings
        Dim Results As New NinjaResults
        Dim msg As MailMessage = New MailMessage()
        msg.To.Add(New MailAddress(MailTo))
        msg.From = New MailAddress(MailFrom)
        msg.Subject = MailSubject
        msg.Body = MailBody
        msg.IsBodyHtml = True
        Dim client As SmtpClient = New SmtpClient()
        client.UseDefaultCredentials = False
        client.Credentials = New System.Net.NetworkCredential(Settings.EmailUserName, Settings.EmailPassword)
        client.Port = 587
        client.Host = "smtp.office365.com"
        client.DeliveryMethod = SmtpDeliveryMethod.Network
        client.EnableSsl = True

        Try
            client.Send(msg)
        Catch ex As Exception
            Results.Success = False
            Results.ErrorMessage = ex.ToString()
        End Try
        Return Results
    End Function


End Class

''' <summary>
''' 	This is the Generic Results Class Used to Send data around the system,  Defaults to Successful if the Calling Function Sets nothing.
''' </summary>
Public Class NinjaResults
    ''' <summary>
    ''' Gets or sets a value indicating whether this <see cref="NinjaResults"/> is success.
    ''' </summary>
    ''' ''' <returns></returns>
    ''' <value><c>true</c> if success; otherwise, <c>false</c>.</value>
    '''     ''' <remarks></remarks>
    Public Property Success As Boolean = True
    ''' <summary>
    ''' Gets or sets the error message.	
    ''' </summary>
    ''' <returns></returns>
    ''' <value>The error message to be returned to the Calling Function</value>
    ''' <remarks></remarks>
    Public Property ErrorMessage As String = ""
End Class
