Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class UserToSchool
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.UserToSchools",
                Function(c) New With
                    {
                        .id = c.Long(nullable := False, identity := True),
                        .School_ID = c.Long(),
                        .User_Id = c.String(maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.id) _
                .ForeignKey("dbo.SchoolModels", Function(t) t.School_ID) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.User_Id) _
                .Index(Function(t) t.School_ID) _
                .Index(Function(t) t.User_Id)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.UserToSchools", "User_Id", "dbo.AspNetUsers")
            DropForeignKey("dbo.UserToSchools", "School_ID", "dbo.SchoolModels")
            DropIndex("dbo.UserToSchools", New String() { "User_Id" })
            DropIndex("dbo.UserToSchools", New String() { "School_ID" })
            DropTable("dbo.UserToSchools")
        End Sub
    End Class
End Namespace
