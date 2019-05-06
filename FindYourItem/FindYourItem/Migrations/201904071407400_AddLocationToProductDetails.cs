namespace FindYourItem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLocationToProductDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductDetails", "Location", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductDetails", "Location");
        }
    }
}
