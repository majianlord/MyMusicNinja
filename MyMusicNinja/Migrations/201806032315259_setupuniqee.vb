Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class setupuniqee
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AlterColumn("dbo.CountryModels", "CountryName", Function(c) c.String(nullable:=False, maxLength:=150))
            AlterColumn("dbo.DistrictModels", "DistrictName", Function(c) c.String(nullable:=False, maxLength:=150))
            AlterColumn("dbo.MusicParts", "MusicPartName", Function(c) c.String(nullable:=False, maxLength:=60))
            AlterColumn("dbo.MusicTypes", "MusicTypeName", Function(c) c.String(nullable:=False, maxLength:=150))
            AlterColumn("dbo.SchoolModels", "SchoolName", Function(c) c.String(nullable:=False, maxLength:=200))
            CreateIndex("dbo.CountryModels", "CountryName", unique:=True)
            CreateIndex("dbo.DistrictModels", "DistrictName", unique:=True)
            CreateIndex("dbo.MusicParts", "MusicPartName", unique:=True)
            CreateIndex("dbo.MusicTypes", "MusicTypeName", unique:=True)
            CreateIndex("dbo.SchoolModels", "SchoolName", unique:=True)
        End Sub

        Public Overrides Sub Down()
            DropIndex("dbo.SchoolModels", New String() {"SchoolName"})
            DropIndex("dbo.MusicTypes", New String() {"MusicTypeName"})
            DropIndex("dbo.MusicParts", New String() {"MusicPartName"})
            DropIndex("dbo.DistrictModels", New String() {"DistrictName"})
            DropIndex("dbo.CountryModels", New String() {"CountryName"})
            AlterColumn("dbo.SchoolModels", "SchoolName", Function(c) c.String())
            AlterColumn("dbo.MusicTypes", "MusicTypeName", Function(c) c.String(nullable:=False))
            AlterColumn("dbo.MusicParts", "MusicPartName", Function(c) c.String(nullable:=False))
            AlterColumn("dbo.DistrictModels", "DistrictName", Function(c) c.String())
            AlterColumn("dbo.CountryModels", "CountryName", Function(c) c.String())
        End Sub
    End Class
End Namespace
