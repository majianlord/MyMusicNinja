Public Class NinjaSettings
    Private _EFDatabaseConnection As String
    Private _DatabaseConnection As String

    Public Property EFDatabaseConnection As String
        Get
            If String.IsNullOrEmpty(_EFDatabaseConnection) Then
                _EFDatabaseConnection = ConfigurationManager.AppSettings.Item("EFDbConnection")
            End If
            Return _EFDatabaseConnection
        End Get
        Set
            _EFDatabaseConnection = Value
            ConfigurationManager.AppSettings.Item("EFDbConnection") = _EFDatabaseConnection
            ConfigurationManager.RefreshSection("appSettings")
        End Set
    End Property


    ''' <summary>
    ''' This is meant to Grab the EF DatabaseConnection details from the Configuration in a way that is always Accessible so its read only and does not set a local variable
    ''' </summary>
    ''' <returns></returns>
    ''' <value>The easy ef database connection.</value>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property EasyEFDatabaseConnection As String
        Get
            Return ConfigurationManager.AppSettings.Item("EFDbConnection")
        End Get
    End Property


    Public Property DatabaseConnection As String
        Get
            If String.IsNullOrEmpty(_DatabaseConnection) Then
                _DatabaseConnection = ConfigurationManager.AppSettings.Item("DBConnection")
            End If
            Return _DatabaseConnection
        End Get
        Set
            _EFDatabaseConnection = Value
            ConfigurationManager.AppSettings.Item("DBConnection") = _DatabaseConnection
            ConfigurationManager.RefreshSection("appSettings")
        End Set
    End Property

End Class
