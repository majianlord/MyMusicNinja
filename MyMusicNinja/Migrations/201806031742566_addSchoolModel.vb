Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class addSchoolModel
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.DistrictModels",
                Function(c) New With
                    {
                        .ID = c.Long(nullable := False, identity := True),
                        .DistrictName = c.String(),
                        .State_ID = c.Long()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.StateModels", Function(t) t.State_ID) _
                .Index(Function(t) t.State_ID)
            
            CreateTable(
                "dbo.StateModels",
                Function(c) New With
                    {
                        .ID = c.Long(nullable := False, identity := True),
                        .StateName = c.String(),
                        .StateShort = c.String()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            CreateTable(
                "dbo.SchoolModels",
                Function(c) New With
                    {
                        .ID = c.Long(nullable := False, identity := True),
                        .SchoolName = c.String(),
                        .Address1 = c.String(),
                        .Address2 = c.String(),
                        .City = c.String(),
                        .ZipCode = c.String(),
                        .CareOff = c.String(),
                        .District_ID = c.Long(),
                        .State_ID = c.Long()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.DistrictModels", Function(t) t.District_ID) _
                .ForeignKey("dbo.StateModels", Function(t) t.State_ID) _
                .Index(Function(t) t.District_ID) _
                .Index(Function(t) t.State_ID)
            
            DropColumn("dbo.AspNetUsers", "School")
            DropColumn("dbo.AspNetUsers", "District")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.AspNetUsers", "District", Function(c) c.Long(nullable := False))
            AddColumn("dbo.AspNetUsers", "School", Function(c) c.Long(nullable := False))
            DropForeignKey("dbo.SchoolModels", "State_ID", "dbo.StateModels")
            DropForeignKey("dbo.SchoolModels", "District_ID", "dbo.DistrictModels")
            DropForeignKey("dbo.DistrictModels", "State_ID", "dbo.StateModels")
            DropIndex("dbo.SchoolModels", New String() { "State_ID" })
            DropIndex("dbo.SchoolModels", New String() { "District_ID" })
            DropIndex("dbo.DistrictModels", New String() { "State_ID" })
            DropTable("dbo.SchoolModels")
            DropTable("dbo.StateModels")
            DropTable("dbo.DistrictModels")
        End Sub
    End Class
End Namespace
