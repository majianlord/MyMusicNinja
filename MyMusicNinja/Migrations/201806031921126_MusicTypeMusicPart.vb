Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class MusicTypeMusicPart
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.MusicParts",
                Function(c) New With
                    {
                        .ID = c.Long(nullable := False, identity := True),
                        .MusicPartName = c.String(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            CreateTable(
                "dbo.MusicTypes",
                Function(c) New With
                    {
                        .ID = c.Long(nullable := False, identity := True),
                        .MusicTypeName = c.String(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropTable("dbo.MusicTypes")
            DropTable("dbo.MusicParts")
        End Sub
    End Class
End Namespace
