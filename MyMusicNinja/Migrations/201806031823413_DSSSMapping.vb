Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class DSSSMapping
        Inherits DbMigration
    
        Public Overrides Sub Up()
            RenameColumn(table := "dbo.DistrictModels", name := "State_ID", newName := "StateID")
            RenameColumn(table := "dbo.SchoolModels", name := "District_ID", newName := "DistrictID")
            RenameColumn(table := "dbo.SchoolModels", name := "State_ID", newName := "StateID")
            RenameIndex(table := "dbo.DistrictModels", name := "IX_State_ID", newName := "IX_StateID")
            RenameIndex(table := "dbo.SchoolModels", name := "IX_District_ID", newName := "IX_DistrictID")
            RenameIndex(table := "dbo.SchoolModels", name := "IX_State_ID", newName := "IX_StateID")
        End Sub
        
        Public Overrides Sub Down()
            RenameIndex(table := "dbo.SchoolModels", name := "IX_StateID", newName := "IX_State_ID")
            RenameIndex(table := "dbo.SchoolModels", name := "IX_DistrictID", newName := "IX_District_ID")
            RenameIndex(table := "dbo.DistrictModels", name := "IX_StateID", newName := "IX_State_ID")
            RenameColumn(table := "dbo.SchoolModels", name := "StateID", newName := "State_ID")
            RenameColumn(table := "dbo.SchoolModels", name := "DistrictID", newName := "District_ID")
            RenameColumn(table := "dbo.DistrictModels", name := "StateID", newName := "State_ID")
        End Sub
    End Class
End Namespace
