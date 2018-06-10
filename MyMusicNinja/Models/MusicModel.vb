Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class MusicType
    Public Property ID As Long
    <Required>
    <DataType(DataType.Text)>
    <Index(IsUnique:=True)>
    <StringLength(150)>
    <Display(Name:="Music Type")>
    Public Property MusicTypeName As String
End Class

Public Class MusicPart
    Public Property ID As Long
    <Required>
    <DataType(DataType.Text)>
    <Index(IsUnique:=True)>
    <StringLength(60)>
    <Display(Name:="Part Name")>
    Public Property MusicPartName As String

End Class


Public Class MusicPiece
    Public Property Id As Long
    <Required>
    Public Property Title As String
    Public Property SubTitle As String
    Public Property Composer As String
    Public Property Lyricist As String
    Public Property Publisher As String
    Public Property Publisher_Ref As String
    Public Property ISBN As String
    Public Property SchoolId As Long?
    Public Overridable Property School As SchoolModel
    Public Property AzureContainerID As String
    Public Overridable Property Parts As List(Of MusicPiecePart)
    <Required>
    <Display(Name:="Music Type")>
    Public Property MusicTypeID As Long?
    Public Overridable Property MusicType As MusicType
End Class

''' <summary>
''' 	
''' </summary>
Public Class MusicPiecePart
    Public Property ID As Long
    <Required>
    Public Property MusicPieceID As Long?
    Public Overridable Property MusicPiece As MusicPiece
    Public Property PartID As Long?
    Public Overridable Property Part As MusicPart
    Public Property Page As Long
    Public Property FileName As String
    Public Property FileMimeType As String
    Public Property AzureContainerID As String
    Public Property AzureBLOBID As String

End Class