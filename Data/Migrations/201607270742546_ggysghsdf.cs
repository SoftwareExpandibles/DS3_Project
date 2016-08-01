namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ggysghsdf : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "img");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "img", c => c.Binary());
        }
    }
}
