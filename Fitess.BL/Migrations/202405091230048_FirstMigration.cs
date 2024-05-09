namespace Fitess.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Eatings", "Food_Id", c => c.Int());
            CreateIndex("dbo.Eatings", "Food_Id");
            AddForeignKey("dbo.Eatings", "Food_Id", "dbo.Foods", "Id");
            DropColumn("dbo.Users", "Age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Age", c => c.Int(nullable: false));
            DropForeignKey("dbo.Eatings", "Food_Id", "dbo.Foods");
            DropIndex("dbo.Eatings", new[] { "Food_Id" });
            DropColumn("dbo.Eatings", "Food_Id");
        }
    }
}
