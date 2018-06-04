Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class MusicPiecesandParts
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.MusicPieces",
                Function(c) New With
                    {
                        .Id = c.Long(nullable:=False, identity:=True),
                        .Title = c.String(nullable:=False),
                        .SubTitle = c.String(),
                        .Composer = c.String(),
                        .Lyricist = c.String(),
                        .Publisher = c.String(),
                        .Publisher_Ref = c.String(),
                        .ISBN = c.String(),
                        .SchoolId = c.Long(),
                        .AzureContainerID = c.String(),
                        .MusicTypeID = c.Long(nullable:=False)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.MusicTypes", Function(t) t.MusicTypeID, cascadeDelete:=True) _
                .ForeignKey("dbo.SchoolModels", Function(t) t.SchoolId) _
                .Index(Function(t) t.SchoolId) _
                .Index(Function(t) t.MusicTypeID)

            CreateTable(
                "dbo.MusicPieceParts",
                Function(c) New With
                    {
                        .ID = c.Long(nullable:=False, identity:=True),
                        .MusicPieceID = c.Long(nullable:=False),
                        .PartID = c.Long(),
                        .Page = c.Long(nullable:=False),
                        .FileName = c.String(),
                        .FileMimeType = c.String(),
                        .AzureContainerID = c.String(),
                        .AzureBLOBID = c.String()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.MusicPieces", Function(t) t.MusicPieceID, cascadeDelete:=True) _
                .ForeignKey("dbo.MusicParts", Function(t) t.PartID) _
                .Index(Function(t) t.MusicPieceID) _
                .Index(Function(t) t.PartID)

        End Sub

        Public Overrides Sub Down()
            DropForeignKey("dbo.MusicPieces", "SchoolId", "dbo.SchoolModels")
            DropForeignKey("dbo.MusicPieceParts", "PartID", "dbo.MusicParts")
            DropForeignKey("dbo.MusicPieceParts", "MusicPieceID", "dbo.MusicPieces")
            DropForeignKey("dbo.MusicPieces", "MusicTypeID", "dbo.MusicTypes")
            DropIndex("dbo.MusicPieceParts", New String() {"PartID"})
            DropIndex("dbo.MusicPieceParts", New String() {"MusicPieceID"})
            DropIndex("dbo.MusicPieces", New String() {"MusicTypeID"})
            DropIndex("dbo.MusicPieces", New String() {"SchoolId"})
            DropTable("dbo.MusicPieceParts")
            DropTable("dbo.MusicPieces")
        End Sub
    End Class
End Namespace
