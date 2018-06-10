Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

''' <summary>
''' 	User to School Mapping Could be 1 to Many
''' </summary>
Public Class UserToSchool
    Public Property id As Long
    Public Property School As SchoolModel
    Public Property User As ApplicationUser
End Class


Public Class SchoolModel
    Public Sub New()
        Me.AssignedUsers = New HashSet(Of ApplicationUser)()
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
    Public Overridable Property AssignedUsers As ICollection(Of ApplicationUser)

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
