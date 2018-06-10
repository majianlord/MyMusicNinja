Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class AddManagingUsers
        Inherits DbMigration
    
        Public Overrides Sub Up()
            RenameTable(name:="dbo.ApplicationUserSchoolModels", newName:="SchoolModelApplicationUsers")
            DropPrimaryKey("dbo.SchoolModelApplicationUsers")
            CreateTable(
                "dbo.SchoolModelApplicationUser1",
                Function(c) New With
                    {
                        .SchoolModel_ID = c.Long(nullable:=False),
                        .ApplicationUser_Id = c.String(nullable:=False, maxLength:=128)
                    }) _
                .PrimaryKey(Function(t) New With {t.SchoolModel_ID, t.ApplicationUser_Id}) _
                .ForeignKey("dbo.SchoolModels", Function(t) t.SchoolModel_ID, cascadeDelete:=True) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.ApplicationUser_Id, cascadeDelete:=True) _
                .Index(Function(t) t.SchoolModel_ID) _
                .Index(Function(t) t.ApplicationUser_Id)

            AddColumn("dbo.AspNetUsers", "ContactPhoneNumber", Function(c) c.String())
            AddPrimaryKey("dbo.SchoolModelApplicationUsers", New String() {"SchoolModel_ID", "ApplicationUser_Id"})
        End Sub

        Public Overrides Sub Down()
            DropForeignKey("dbo.SchoolModelApplicationUser1", "ApplicationUser_Id", "dbo.AspNetUsers")
            DropForeignKey("dbo.SchoolModelApplicationUser1", "SchoolModel_ID", "dbo.SchoolModels")
            DropIndex("dbo.SchoolModelApplicationUser1", New String() {"ApplicationUser_Id"})
            DropIndex("dbo.SchoolModelApplicationUser1", New String() {"SchoolModel_ID"})
            DropPrimaryKey("dbo.SchoolModelApplicationUsers")
            DropColumn("dbo.AspNetUsers", "ContactPhoneNumber")
            DropTable("dbo.SchoolModelApplicationUser1")
            AddPrimaryKey("dbo.SchoolModelApplicationUsers", New String() {"ApplicationUser_Id", "SchoolModel_ID"})
            RenameTable(name:="dbo.SchoolModelApplicationUsers", newName:="ApplicationUserSchoolModels")
        End Sub
    End Class
End Namespace
