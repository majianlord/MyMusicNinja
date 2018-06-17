Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema


Public Class SchoolApplication
    Public Property ID As Long
    Public Property Requestinfo As String
    Public Property RequestedRole As NinjaEnums.SchoolRole
    Public Property Status As NinjaEnums.SchoolApplicationStatus
    Public Property StatusReason As String
    Public Property ApprovedbyID As Long?
    Public Overridable Property ApprovebyUser As ApplicationUser
    Public Property ApplicationUserID As String
    Public Overridable Property ApplicationUser As ApplicationUser
    Public Property SchoolID As Long?
    Public Overridable Property School As SchoolModel



End Class

Public Class Library
    Public Property ID As Long
    Public Property LibraryName As String

    Public Property SchoolID As Long?
    Public Overridable Property School As SchoolModel

    Public Overridable Property MusicPieces As List(Of MusicPiece)

    Public Overridable Property MusicBooks As List(Of MusicBooks)
End Class





Public Class SchoolModel
    Public Sub New()
        Me.AssignedUsers = New HashSet(Of ApplicationUser)()
        Me.ManagingUsers = New HashSet(Of ApplicationUser)()
        Me.PendingApplications = New HashSet(Of SchoolApplication)()
    End Sub
    <Key(), DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Long
    <Index(IsUnique:=True)>
    <Required>
    <StringLength(200)>
    Public Property SchoolName As String
    Public Property DistrictID As Long?
    Public Overridable Property District As DistrictModel
    Public Property Address1 As String
    Public Property Address2 As String
    Public Property City As String
    Public Property StateID As Long?
    Public Overridable Property State As StateModel
    Public Property ZipCode As String
    Public Property CountryID As Long?
    Public Overridable Property Country As CountryModel
    Public Property CareOff As String
    <InverseProperty("Schools")>
    Public Overridable Property AssignedUsers As ICollection(Of ApplicationUser)
    <InverseProperty("ManagedSchools")>
    Public Overridable Property ManagingUsers As ICollection(Of ApplicationUser)
    Public Overridable Property PendingApplications As ICollection(Of SchoolApplication)

    Public Overridable Property Libraries As ICollection(Of Library)
End Class
Public Class DistrictModel
    <Key(), DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Long
    <Index(IsUnique:=True)>
    <Required>
    <StringLength(150)>
    Public Property DistrictName As String
    Public Property StateID As Long?
    Public Overridable Property State As StateModel

End Class

Public Class StateModel
    <Key(), DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Long
    Public Property StateName As String
    Public Property StateShort As String

    Public Property CountryID As Long?
    Public Overridable Property Country As CountryModel

End Class

Public Class CountryModel
    <Key(), DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Long
    <Required>
    <StringLength(150)>
    <Index(IsUnique:=True)>
    Public Property CountryName As String

End Class
