Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class SchoolManager
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.SchoolModels", "ApplicationUser_Id", Function(c) c.String(maxLength := 128))
            CreateIndex("dbo.SchoolModels", "ApplicationUser_Id")
            AddForeignKey("dbo.SchoolModels", "ApplicationUser_Id", "dbo.AspNetUsers", "Id")
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.SchoolModels", "ApplicationUser_Id", "dbo.AspNetUsers")
            DropIndex("dbo.SchoolModels", New String() { "ApplicationUser_Id" })
            DropColumn("dbo.SchoolModels", "ApplicationUser_Id")
        End Sub
    End Class
End Namespace
