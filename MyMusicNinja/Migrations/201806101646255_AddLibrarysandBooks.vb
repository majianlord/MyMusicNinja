Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class AddLibrarysandBooks
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Libraries",
                Function(c) New With
                    {
                        .ID = c.Long(nullable := False, identity := True),
                        .LibraryName = c.String(),
                        .SchoolID = c.Long()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.SchoolModels", Function(t) t.SchoolID) _
                .Index(Function(t) t.SchoolID)
            
            CreateTable(
                "dbo.MusicBooks",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .Title = c.String(nullable := False),
                        .SubTitle = c.String(),
                        .Composer = c.String(),
                        .Lyricist = c.String(),
                        .Publisher = c.String(),
                        .Publisher_Ref = c.String(),
                        .ISBN = c.String(),
                        .LibraryId = c.Long(),
                        .AzureContainerID = c.String(),
                        .MusicTypeID = c.Long(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Libraries", Function(t) t.LibraryId) _
                .ForeignKey("dbo.MusicTypes", Function(t) t.MusicTypeID, cascadeDelete := True) _
                .Index(Function(t) t.LibraryId) _
                .Index(Function(t) t.MusicTypeID)
            
            CreateTable(
                "dbo.MusicBookParts",
                Function(c) New With
                    {
                        .ID = c.Long(nullable := False, identity := True),
                        .MusicBooksID = c.Long(nullable := False),
                        .PartID = c.Long(),
                        .Page = c.Long(nullable := False),
                        .FileName = c.String(),
                        .FileMimeType = c.String(),
                        .AzureContainerID = c.String(),
                        .AzureBLOBID = c.String()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.MusicBooks", Function(t) t.MusicBooksID, cascadeDelete := True) _
                .ForeignKey("dbo.MusicParts", Function(t) t.PartID) _
                .Index(Function(t) t.MusicBooksID) _
                .Index(Function(t) t.PartID)
            
            AddColumn("dbo.MusicPieces", "Library_ID", Function(c) c.Long())
            CreateIndex("dbo.MusicPieces", "Library_ID")
            AddForeignKey("dbo.MusicPieces", "Library_ID", "dbo.Libraries", "ID")
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Libraries", "SchoolID", "dbo.SchoolModels")
            DropForeignKey("dbo.MusicPieces", "Library_ID", "dbo.Libraries")
            DropForeignKey("dbo.MusicBookParts", "PartID", "dbo.MusicParts")
            DropForeignKey("dbo.MusicBookParts", "MusicBooksID", "dbo.MusicBooks")
            DropForeignKey("dbo.MusicBooks", "MusicTypeID", "dbo.MusicTypes")
            DropForeignKey("dbo.MusicBooks", "LibraryId", "dbo.Libraries")
            DropIndex("dbo.MusicBookParts", New String() { "PartID" })
            DropIndex("dbo.MusicBookParts", New String() { "MusicBooksID" })
            DropIndex("dbo.MusicBooks", New String() { "MusicTypeID" })
            DropIndex("dbo.MusicBooks", New String() { "LibraryId" })
            DropIndex("dbo.Libraries", New String() { "SchoolID" })
            DropIndex("dbo.MusicPieces", New String() { "Library_ID" })
            DropColumn("dbo.MusicPieces", "Library_ID")
            DropTable("dbo.MusicBookParts")
            DropTable("dbo.MusicBooks")
            DropTable("dbo.Libraries")
        End Sub
    End Class
End Namespace
