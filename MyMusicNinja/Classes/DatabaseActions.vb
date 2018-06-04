'Imports System.Data.SqlClient
'Imports MyMusicNinja

'Public Class DatabaseActions

'    Private Property _connectionstring As String

'    Public Sub New()
'        _connectionstring = ConfigurationManager.AppSettings.Item("DbConnection")
'    End Sub
'    Private Function BuildCommand() As SqlConnection
'        Return New SqlConnection(_connectionstring)
'    End Function
'    Public Function PartsList() As List(Of PiecesParts)
'        Dim Partslist1 As New List(Of PiecesParts)
'        Using Don As SqlConnection = BuildCommand()
'            Using SqlCMD As SqlCommand = Don.CreateCommand
'                SqlCMD.CommandText = "Select PartId, PartName from MusicParts"
'                Don.Open()
'                Using Reader1 As SqlDataReader = SqlCMD.ExecuteReader
'                    While Reader1.Read
'                        Dim Part As New PiecesParts
'                        Part.PartName = Reader1("PartName").ToString
'                        Part.PartID = Reader1("PartID")
'                        Partslist1.Add(Part)
'                    End While
'                End Using
'            End Using
'        End Using
'        Partslist1.Add(New PiecesParts With {.PartID = 0, .PartName = "Select a Part"})
'        Return Partslist1
'    End Function
'    Public Function AddtoPartsList(PartName As String) As Boolean

'        Using Don As SqlConnection = BuildCommand()
'            Using SqlCMD As SqlCommand = Don.CreateCommand
'                SqlCMD.CommandText = "Insert Into MusicParts (PartName) values (@1)"
'                SqlCMD.Parameters.AddWithValue("@1", PartName)
'                Don.Open()
'                Dim ResultCount = SqlCMD.ExecuteNonQuery()
'                If ResultCount = 1 Then
'                    Return True
'                Else
'                    Return False
'                End If
'            End Using
'        End Using
'    End Function
'    Friend Function addPiece(pieceTitle As String, subTitle As String, composer As String, lyricist As String, publisher As String, publisher_REF As String, ISBN As String, Owner As Int64, ptype As Int64) As Boolean

'        Using Don As SqlConnection = BuildCommand()
'            Using SqlCMD As SqlCommand = Don.CreateCommand
'                SqlCMD.CommandText = "Insert Into MusicPiece (Title,SubTitle,Composer,Lyricist,Publisher,Publisher_Ref,ISBN,Owner,BlobContainerID,PieceType) values (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10)"
'                SqlCMD.Parameters.AddWithValue("@1", pieceTitle)

'                If String.IsNullOrEmpty(subTitle.Trim) Then
'                    SqlCMD.Parameters.AddWithValue("@2", DBNull.Value)
'                Else
'                    SqlCMD.Parameters.AddWithValue("@2", subTitle)
'                End If
'                If String.IsNullOrEmpty(composer.Trim) Then
'                    SqlCMD.Parameters.AddWithValue("@3", DBNull.Value)
'                Else
'                    SqlCMD.Parameters.AddWithValue("@3", composer)
'                End If
'                If String.IsNullOrEmpty(lyricist.Trim) Then
'                    SqlCMD.Parameters.AddWithValue("@4", DBNull.Value)
'                Else
'                    SqlCMD.Parameters.AddWithValue("@4", lyricist)
'                End If
'                If String.IsNullOrEmpty(publisher.Trim) Then
'                    SqlCMD.Parameters.AddWithValue("@5", DBNull.Value)
'                Else
'                    SqlCMD.Parameters.AddWithValue("@5", publisher)
'                End If
'                If String.IsNullOrEmpty(publisher_REF.Trim) Then
'                    SqlCMD.Parameters.AddWithValue("@6", DBNull.Value)
'                Else
'                    SqlCMD.Parameters.AddWithValue("@6", publisher_REF)
'                End If
'                If String.IsNullOrEmpty(ISBN.Trim) Then
'                    SqlCMD.Parameters.AddWithValue("@7", DBNull.Value)
'                Else
'                    SqlCMD.Parameters.AddWithValue("@7", ISBN)
'                End If
'                SqlCMD.Parameters.AddWithValue("@8", Owner)
'                SqlCMD.Parameters.AddWithValue("@9", Guid.NewGuid().ToString)
'                SqlCMD.Parameters.AddWithValue("@10", ptype)
'                Don.Open()
'                Dim ResultCount = SqlCMD.ExecuteNonQuery()
'                If ResultCount = 1 Then
'                    Return True
'                Else
'                    Return False
'                End If
'            End Using
'        End Using
'    End Function
'    Public Function TypeList() As List(Of PiecesType)
'        Dim Typelist1 As New List(Of PiecesType)
'        Using Don As SqlConnection = BuildCommand()
'            Using SqlCMD As SqlCommand = Don.CreateCommand
'                SqlCMD.CommandText = "Select Typeid, TypeName from MusicType"
'                Don.Open()
'                Using Reader1 As SqlDataReader = SqlCMD.ExecuteReader
'                    While Reader1.Read
'                        Dim ptype As New PiecesType
'                        ptype.TypeName = Reader1("TypeName").ToString
'                        ptype.TypeID = Reader1("TypeID")
'                        Typelist1.Add(ptype)
'                    End While
'                End Using
'            End Using
'        End Using
'        Return Typelist1
'    End Function
'    Public Function PiecesListDropDown(Optional OwnerID As Int64 = 1) As List(Of MusicPieces)
'        Dim Partslist1 As New List(Of MusicPieces)
'        Using Don As SqlConnection = BuildCommand()
'            Using SqlCMD As SqlCommand = Don.CreateCommand
'                SqlCMD.CommandText = "Select MusicPieceId,Title,SubTitle from MusicPiece where owner = @1 Order by Title"
'                SqlCMD.Parameters.AddWithValue("@1", OwnerID)
'                Don.Open()
'                Using Reader1 As SqlDataReader = SqlCMD.ExecuteReader
'                    While Reader1.Read
'                        Dim Part As New MusicPieces
'                        If IsDBNull(Reader1("SubTitle")) OrElse String.IsNullOrEmpty(Reader1("SubTitle").ToString) Then
'                            Part.Title = Reader1("Title").ToString
'                        Else
'                            Part.Title = Reader1("Title").ToString & " (" & Reader1("SubTitle").ToString & ")"
'                        End If
'                        Part.MusicPieceId = Reader1("MusicPieceId")
'                        Partslist1.Add(Part)
'                    End While
'                End Using
'            End Using
'        End Using
'        Partslist1.Add(New MusicPieces With {.MusicPieceId = 0, .Title = "Select a Piece"})
'        Return Partslist1
'    End Function
'    Public Function AddPiecesParts(PieceID As Int64, Partid As Int64, PageNum As Int64, filename As String, BlobGUID As String, mimeType As String) As Int64
'        Using Don As SqlConnection = BuildCommand()
'            Using SqlCMD As SqlCommand = Don.CreateCommand
'                SqlCMD.CommandText = "INSERT INTO [dbo].[MusicPiece_Part] ([MusicPiece],[Part],[Page],[FileName],[BlobStorageID],[MimeType]) VALUES (@1,@2,@3,@4,@5,@6);select scope_identity()"
'                SqlCMD.Parameters.AddWithValue("@1", PieceID)
'                SqlCMD.Parameters.AddWithValue("@2", Partid)
'                SqlCMD.Parameters.AddWithValue("@3", PageNum)
'                SqlCMD.Parameters.AddWithValue("@4", filename)
'                SqlCMD.Parameters.AddWithValue("@5", BlobGUID)
'                SqlCMD.Parameters.AddWithValue("@6", BlobGUID)
'                Don.Open()
'                Dim ResultCount As Int64 = SqlCMD.ExecuteScalar
'                Return ResultCount
'            End Using
'        End Using
'    End Function
'    Public Function AzureStorageID(PiecePartID As Int64) As AzurePiecePart
'        Dim Azureids As New AzurePiecePart With {.PiecePartID = PiecePartID}
'        Using Don As SqlConnection = BuildCommand()
'            Using SqlCMD As SqlCommand = Don.CreateCommand
'                SqlCMD.CommandText = "Select FileName, BlobContainerID, BlobStorageID, MimeType from MusicPiece_Part a Left Join MusicPiece b on a.MusicPiece = b.MusicPieceId where a.MusicPiecePart_Id = @1"
'                SqlCMD.Parameters.AddWithValue("@1", PiecePartID)
'                Don.Open()
'                Using Reader1 As SqlDataReader = SqlCMD.ExecuteReader
'                    While Reader1.Read
'                        Azureids.Container = Reader1("BlobContainerID").ToString
'                        Azureids.FileID = Reader1("BlobStorageID").ToString
'                        Azureids.FileName = Reader1("FileName").ToString
'                        Azureids.MimeType = Reader1("FileName").ToString
'                    End While
'                End Using
'            End Using
'        End Using
'        Return Azureids
'    End Function


'    Public Function PiecesListFull(Optional OwnerID As Int64 = 1) As List(Of MusicPieces)
'        Dim Partslist1 As New List(Of MusicPieces)
'        Using Don As SqlConnection = BuildCommand()
'            Using SqlCMD As SqlCommand = Don.CreateCommand
'                SqlCMD.CommandText = "Select * from MusicPiece a left join MusicType b on a.PieceType = b.Typeid where owner = @1 Order by Title"
'                SqlCMD.Parameters.AddWithValue("@1", OwnerID)
'                Don.Open()
'                Using Reader1 As SqlDataReader = SqlCMD.ExecuteReader
'                    While Reader1.Read
'                        Dim Part As New MusicPieces
'                        Part.MusicPieceId = Reader1("MusicPieceId")
'                        Part.Title = Reader1("Title").ToString
'                        Part.SubTitle = Reader1("SubTitle").ToString
'                        Part.Composer = Reader1("Composer").ToString
'                        Part.Lyricist = Reader1("Lyricist").ToString
'                        Part.Publisher = Reader1("Publisher").ToString
'                        Part.Publisher_Ref = Reader1("Publisher_Ref").ToString
'                        Part.ISBN = Reader1("ISBN").ToString
'                        Part.Owner = Reader1("owner")
'                        Part.GUID = Reader1("BlobContainerID").ToString
'                        Part.PieceType = New MusicType With {.TypeId = Reader1("Typeid"), .TypeName = Reader1("TypeName").ToString}
'                        Partslist1.Add(PiecesListFullParts(Part))
'                    End While
'                End Using
'            End Using
'        End Using
'        Return Partslist1
'    End Function

'    Private Function PiecesListFullParts(partslist1 As MusicPieces) As MusicPieces
'        Using Don As SqlConnection = BuildCommand()
'            Using SqlCMD As SqlCommand = Don.CreateCommand
'                SqlCMD.CommandText = "Select * from MusicPiece_part a left join MusicParts b on a.part = b.partid where MusicPiece = @1"
'                SqlCMD.Parameters.AddWithValue("@1", partslist1.MusicPieceId)
'                Don.Open()
'                Using Reader1 As SqlDataReader = SqlCMD.ExecuteReader
'                    While Reader1.Read
'                        Dim Part As New MusicPieces_Parts
'                        Part.MusicPiecePartID = Reader1("MusicPiecePart_Id").ToString
'                        Part.MusicPiece = Reader1("MusicPiece")
'                        Part.Part = New MusicPart With {.ID = Reader1("Partid"), .PartName = Reader1("PartName").ToString}
'                        Part.Page = Reader1("Page")
'                        Part.FileName = Reader1("FileName").ToString
'                        Part.PiecePartGUID = Reader1("BlobStorageID").ToString
'                        If partslist1.Parts Is Nothing Then
'                            partslist1.Parts = New List(Of MusicPieces_Parts)
'                        End If
'                        partslist1.Parts.Add(Part)
'                    End While
'                End Using
'            End Using
'        End Using

'        Return partslist1
'    End Function


'    Public Function PiecesDetails(PieceID As Int64) As MusicPieces
'        Dim Part As New MusicPieces
'        Using Don As SqlConnection = BuildCommand()
'            Using SqlCMD As SqlCommand = Don.CreateCommand
'                SqlCMD.CommandText = "Select * from MusicPiece a left join MusicType b on a.PieceType = b.Typeid where MusicPieceId = @1 Order by Title"
'                SqlCMD.Parameters.AddWithValue("@1", PieceID)
'                Don.Open()
'                Using Reader1 As SqlDataReader = SqlCMD.ExecuteReader
'                    While Reader1.Read
'                        Part.MusicPieceId = Reader1("MusicPieceId")
'                        Part.Title = Reader1("Title").ToString
'                        Part.SubTitle = Reader1("SubTitle").ToString
'                        Part.Composer = Reader1("Composer").ToString
'                        Part.Lyricist = Reader1("Lyricist").ToString
'                        Part.Publisher = Reader1("Publisher").ToString
'                        Part.Publisher_Ref = Reader1("Publisher_Ref").ToString
'                        Part.ISBN = Reader1("ISBN").ToString
'                        Part.Owner = Reader1("owner")
'                        Part.GUID = Reader1("BlobContainerID").ToString
'                        Part.PieceType = New MusicType With {.TypeId = Reader1("Typeid"), .TypeName = Reader1("TypeName").ToString}
'                        PiecesListFullParts(Part)
'                    End While
'                End Using
'            End Using
'        End Using
'        Return Part
'    End Function



'End Class
