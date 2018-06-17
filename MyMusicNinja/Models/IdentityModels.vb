Imports System.Security.Claims
Imports System.Threading.Tasks
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports System.ComponentModel.DataAnnotations.Schema

' You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
Public Class ApplicationUser
    Inherits IdentityUser
    Public Sub New()
        Me.Schools = New HashSet(Of SchoolModel)()
        Me.ManagedSchools = New HashSet(Of SchoolModel)()
        Me.PendingApplications = New HashSet(Of SchoolApplication)()
    End Sub
    Public Property FirstName As String
    Public Property LastName As String
    Public Property EmailAddress As String
    Public Property ContactPhoneNumber As String
    Public Overridable Property Schools As ICollection(Of SchoolModel)
    Public Overridable Property ManagedSchools As ICollection(Of SchoolModel)
    Public Overridable Property PendingApplications As ICollection(Of SchoolApplication)


    Public Async Function GenerateUserIdentityAsync(manager As UserManager(Of ApplicationUser)) As Task(Of ClaimsIdentity)
        ' Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        Dim userIdentity = Await manager.CreateIdentityAsync(Me, DefaultAuthenticationTypes.ApplicationCookie)
        ' Add custom user claims here
        Return userIdentity
    End Function
End Class

Public Class ApplicationDbContext
    Inherits IdentityDbContext(Of ApplicationUser)
    Public Sub New()
        MyBase.New(NinjaSettings.EasyEFDatabaseConnection, throwIfV1Schema:=False)
    End Sub

    Public Shared Function Create() As ApplicationDbContext
        Return New ApplicationDbContext()
    End Function

    Public Property SchoolModels As System.Data.Entity.DbSet(Of SchoolModel)
    Public Property DistrictModels As System.Data.Entity.DbSet(Of DistrictModel)
    Public Property StateModels As System.Data.Entity.DbSet(Of StateModel)
    Public Property CountryModels As System.Data.Entity.DbSet(Of CountryModel)
    Public Property MusicPartModels As System.Data.Entity.DbSet(Of MusicPart)
    Public Property MusicTypeModels As System.Data.Entity.DbSet(Of MusicType)
    Public Property MusicPieceModels As System.Data.Entity.DbSet(Of MusicPiece)
    Public Property MusicPiecePartModels As System.Data.Entity.DbSet(Of MusicPiecePart)

    Public Property SchoolApplications As System.Data.Entity.DbSet(Of SchoolApplication)
    Public Property Libraries As System.Data.Entity.DbSet(Of Library)
    ' Public Property ApplicationUsers As System.Data.Entity.DbSet(Of ApplicationUser)

End Class
