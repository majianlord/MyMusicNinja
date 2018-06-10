Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class UsertoSchoolApplicationsV2
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.SchoolApplications", "ApplicationUser_Id", Function(c) c.String(maxLength := 128))
            CreateIndex("dbo.SchoolApplications", "ApplicationUser_Id")
            AddForeignKey("dbo.SchoolApplications", "ApplicationUser_Id", "dbo.AspNetUsers", "Id")
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.SchoolApplications", "ApplicationUser_Id", "dbo.AspNetUsers")
            DropIndex("dbo.SchoolApplications", New String() { "ApplicationUser_Id" })
            DropColumn("dbo.SchoolApplications", "ApplicationUser_Id")
        End Sub
    End Class
End Namespace
