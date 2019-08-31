namespace ExpenseTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategoryTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (Id, Name) VALUES (1, 'Food')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (2, 'Tools')");

        }
        
        public override void Down()
        {
        }
    }
}
