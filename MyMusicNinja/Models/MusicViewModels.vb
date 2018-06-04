Imports System.ComponentModel.DataAnnotations

''' <summary>
''' 	The Model used to Send the file to the browser for processing of data into the Model
''' </summary>
Public Class ProccessUploadModels
    Public Property FileName As String
    <Required>
    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=6)>
    <DataType(DataType.Text)>
    <Display(Name:="Piece Name/Song Name")>
    Public Property PieceName As String
    <Required>
    <DataType(DataType.Text)>
    <Display(Name:="Part for this Piece/Song")>
    Public Property Part As String

    <Required(ErrorMessage:="Page Number is Required"), Range(0, 352, ErrorMessage:="The Page Number must by 0 to 352")>
    <Display(Name:="Page Number for Book")>
    Public Property PageNum As Int64

End Class

'Public Class PiecesParts
'    Public Property PartID As Int64
'    Public Property PartName As String
'End Class

'Public Class PiecesType
'    Public Property TypeID As Int64
'    Public Property TypeName As String
'End Class


'Public Class MusicPieces
'    Public Property MusicPieceId As Int64
'    Public Property Title As String
'    Public Property SubTitle As String
'    Public Property Composer As String
'    Public Property Lyricist As String
'    Public Property Publisher As String
'    Public Property Publisher_Ref As String
'    Public Property ISBN As String
'    Public Property Owner As String
'    Public Property GUID As String
'    Public Property Parts As List(Of MusicPieces_Parts)
'    Public Property PieceType As MusicType
'End Class

'Public Class MusicPieces_Parts
'    Public Property MusicPiecePartID As Int64
'    Public Property MusicPiece As Int64
'    Public Property Part As MusicPart
'    Public Property Page As Int64
'    Public Property FileName As String
'    Public Property PiecePartGUID As String
'End Class




'Public Class MusicPiecesParts
'    Public Property MusicPiecePartID As Int64
'    Public Property MusicPiece As Int64
'    Public Property Part As Int64
'    Public Property PieceGUID As String
'    Public Property PiecePartGUID As String
'End Class

Public Class AzurePiecePart
    Public Property PiecePartID As String
    Public Property Container As String
    Public Property FileID As String
    Public Property FileName As String

    Public Property MimeType As String
End Class