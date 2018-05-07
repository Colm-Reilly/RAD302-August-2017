namespace Rad302Autumn2017.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        AttendanceID = c.Int(nullable: false, identity: true),
                        ModuleID = c.Int(nullable: false),
                        StudentID = c.String(),
                        AttendanceDateTime = c.DateTime(nullable: false),
                        Present = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AttendanceID);
            
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        ModuleID = c.Int(nullable: false, identity: true),
                        ModuleName = c.String(),
                    })
                .PrimaryKey(t => t.ModuleID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        SecondName = c.String(),
                    })
                .PrimaryKey(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
            DropTable("dbo.Modules");
            DropTable("dbo.Attendances");
        }
    }
}
