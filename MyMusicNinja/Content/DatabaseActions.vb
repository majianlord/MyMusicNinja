Imports System.Data.SqlClient

Public Class DatabaseActions

    Private Property _connectionstring As String

    Public Sub New()
        _connectionstring = ConfigurationManager.AppSettings.Item("DbConnection")
    End Sub

    Private Function BuildCommand() As SqlConnection
        Return New SqlConnection(_connectionstring)
    End Function

    Public Function PartsList() As List(Of PiecesParts)
        Dim Partslist1 As New List(Of PiecesParts)
        Using Don As SqlConnection = BuildCommand()
            Using SqlCMD As SqlCommand = Don.CreateCommand
                SqlCMD.CommandText = "Select Partid, PartName from Parts"
                Don.Open()
                Using Reader1 As SqlDataReader = SqlCMD.ExecuteReader
                    While Reader1.Read
                        Dim Part As New PiecesParts
                        Part.PartName = Reader1("PartName").ToString
                        Part.PartID = Reader1("PartID")
                        Partslist1.Add(Part)
                    End While
                End Using
            End Using
        End Using
        Return Partslist1
    End Function



    Public Function PeicesList() As List(Of MusicPieces)
        Dim Partslist1 As New List(Of MusicPieces)
        Using Don As SqlConnection = BuildCommand()
            Using SqlCMD As SqlCommand = Don.CreateCommand
                SqlCMD.CommandText = "Select * from MusicPiece Order by Title"
                Don.Open()
                Using Reader1 As SqlDataReader = SqlCMD.ExecuteReader
                    While Reader1.Read
                        Dim Part As New MusicPieces
                        Part.Title = Reader1("Title").ToString
                        Part.MusicPeiceId = Reader1("MusicPeiceId")
                        Partslist1.Add(Part)
                    End While
                End Using
            End Using
        End Using
        Return Partslist1
    End Function




End Class
