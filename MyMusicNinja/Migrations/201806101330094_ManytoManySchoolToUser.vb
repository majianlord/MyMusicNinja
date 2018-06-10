Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class ManytoManySchoolToUser
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.UserToSchools", "School_ID", "dbo.SchoolModels")
            DropForeignKey("dbo.SchoolModels", "ApplicationUser_Id", "dbo.AspNetUsers")
            DropForeignKey("dbo.UserToSchools", "User_Id", "dbo.AspNetUsers")
            DropIndex("dbo.SchoolModels", New String() {"ApplicationUser_Id"})
            DropIndex("dbo.UserToSchools", New String() {"School_ID"})
            DropIndex("dbo.UserToSchools", New String() {"User_Id"})
            CreateTable(
                "dbo.ApplicationUserSchoolModels",
                Function(c) New With
                    {
                        .ApplicationUser_Id = c.String(nullable:=False, maxLength:=128),
                        .SchoolModel_ID = c.Long(nullable:=False)
                    }) _
                .PrimaryKey(Function(t) New With {t.ApplicationUser_Id, t.SchoolModel_ID}) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.ApplicationUser_Id, cascadeDelete:=True) _
                .ForeignKey("dbo.SchoolModels", Function(t) t.SchoolModel_ID, cascadeDelete:=True) _
                .Index(Function(t) t.ApplicationUser_Id) _
                .Index(Function(t) t.SchoolModel_ID)

            AddColumn("dbo.AspNetUsers", "EmailAddress", Function(c) c.String())
            DropColumn("dbo.SchoolModels", "ApplicationUser_Id")
            DropTable("dbo.UserToSchools")
        End Sub

        Public Overrides Sub Down()
            CreateTable(
                "dbo.UserToSchools",
                Function(c) New With
                    {
                        .id = c.Long(nullable:=False, identity:=True),
                        .School_ID = c.Long(),
                        .User_Id = c.String(maxLength:=128)
                    }) _
                .PrimaryKey(Function(t) t.id)

            AddColumn("dbo.SchoolModels", "ApplicationUser_Id", Function(c) c.String(maxLength:=128))
            DropForeignKey("dbo.ApplicationUserSchoolModels", "SchoolModel_ID", "dbo.SchoolModels")
            DropForeignKey("dbo.ApplicationUserSchoolModels", "ApplicationUser_Id", "dbo.AspNetUsers")
            DropIndex("dbo.ApplicationUserSchoolModels", New String() {"SchoolModel_ID"})
            DropIndex("dbo.ApplicationUserSchoolModels", New String() {"ApplicationUser_Id"})
            DropColumn("dbo.AspNetUsers", "EmailAddress")
            DropTable("dbo.ApplicationUserSchoolModels")
            CreateIndex("dbo.UserToSchools", "User_Id")
            CreateIndex("dbo.UserToSchools", "School_ID")
            CreateIndex("dbo.SchoolModels", "ApplicationUser_Id")
            AddForeignKey("dbo.UserToSchools", "User_Id", "dbo.AspNetUsers", "Id")
            AddForeignKey("dbo.SchoolModels", "ApplicationUser_Id", "dbo.AspNetUsers", "Id")
            AddForeignKey("dbo.UserToSchools", "School_ID", "dbo.SchoolModels", "ID")
        End Sub
    End Class
End Namespace
