namespace Rad302Autumn2017.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT into Students(StudentID, FirstName, SecondName) VALUES('S00123456', 'Paul', 'Powell')");
            Sql("INSERT into Students(StudentID, FirstName, SecondName) VALUES('S00156770', 'Colm', 'Reilly')");

            Sql("INSERT into Modules(ModuleName) VALUES('RAD302')");
            Sql("INSERT into Modules(ModuleName) VALUES('Database Development')");

            Sql("INSERT into Attendances(ModuleID, StudentID, AttendanceDateTime, Present) VALUES('1','1', GETDATE(),'True')");
            Sql("INSERT into Attendances(ModuleID, StudentID, AttendanceDateTime, Present) VALUES('2', '2', GETDATE(), 'False')");
            Sql("INSERT into Attendances(ModuleID, StudentID, AttendanceDateTime, Present) VALUES('1','2', GETDATE(),'True')");
            Sql("INSERT into Attendances(ModuleID, StudentID, AttendanceDateTime, Present) VALUES('2', '1', GETDATE(), 'True')");



        }
        
        public override void Down()
        {
        }
    }
}
