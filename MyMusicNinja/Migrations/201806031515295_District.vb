Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class District
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.AspNetUsers", "District", Function(c) c.Long(nullable := False))
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.AspNetUsers", "District")
        End Sub
    End Class
End Namespace
