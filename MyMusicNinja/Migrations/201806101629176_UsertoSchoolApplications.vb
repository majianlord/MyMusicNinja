Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class UsertoSchoolApplications
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.SchoolApplications",
                Function(c) New With
                    {
                        .ID = c.Long(nullable := False, identity := True),
                        .Requestinfo = c.String(),
                        .RequestedRole = c.Int(nullable := False),
                        .Status = c.Int(nullable := False),
                        .StatusReason = c.String(),
                        .ApprovedbyID = c.Long(),
                        .ApplicationUserID = c.String(maxLength := 128),
                        .SchoolID = c.Long(),
                        .ApprovebyUser_Id = c.String(maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.ApplicationUserID) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.ApprovebyUser_Id) _
                .ForeignKey("dbo.SchoolModels", Function(t) t.SchoolID) _
                .Index(Function(t) t.ApplicationUserID) _
                .Index(Function(t) t.SchoolID) _
                .Index(Function(t) t.ApprovebyUser_Id)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.SchoolApplications", "SchoolID", "dbo.SchoolModels")
            DropForeignKey("dbo.SchoolApplications", "ApprovebyUser_Id", "dbo.AspNetUsers")
            DropForeignKey("dbo.SchoolApplications", "ApplicationUserID", "dbo.AspNetUsers")
            DropIndex("dbo.SchoolApplications", New String() { "ApprovebyUser_Id" })
            DropIndex("dbo.SchoolApplications", New String() { "SchoolID" })
            DropIndex("dbo.SchoolApplications", New String() { "ApplicationUserID" })
            DropTable("dbo.SchoolApplications")
        End Sub
    End Class
End Namespace
