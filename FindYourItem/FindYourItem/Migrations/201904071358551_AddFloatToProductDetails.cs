namespace FindYourItem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFloatToProductDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductDetails", "Price", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductDetails", "Price");
        }
    }
}
