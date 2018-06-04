Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class country
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.CountryModels",
                Function(c) New With
                    {
                        .ID = c.Long(nullable := False, identity := True),
                        .CountryName = c.String()
                    }) _
                .PrimaryKey(Function(t) t.ID)

            AddColumn("dbo.StateModels", "CountryID", Function(c) c.Long())
            AddColumn("dbo.SchoolModels", "CountryID", Function(c) c.Long())
            CreateIndex("dbo.StateModels", "CountryID")
            CreateIndex("dbo.SchoolModels", "CountryID")
            AddForeignKey("dbo.StateModels", "CountryID", "dbo.CountryModels", "ID")
            AddForeignKey("dbo.SchoolModels", "CountryID", "dbo.CountryModels", "ID")
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.SchoolModels", "CountryID", "dbo.CountryModels")
            DropForeignKey("dbo.StateModels", "CountryID", "dbo.CountryModels")
            DropIndex("dbo.SchoolModels", New String() { "CountryID" })
            DropIndex("dbo.StateModels", New String() { "CountryID" })
            DropColumn("dbo.SchoolModels", "CountryID")
            DropColumn("dbo.StateModels", "CountryID")
            DropTable("dbo.CountryModels")
        End Sub
    End Class
End Namespace
