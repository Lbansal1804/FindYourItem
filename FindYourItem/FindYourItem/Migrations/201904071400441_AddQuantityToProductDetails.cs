namespace FindYourItem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQuantityToProductDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductDetails", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductDetails", "Quantity");
        }
    }
}
