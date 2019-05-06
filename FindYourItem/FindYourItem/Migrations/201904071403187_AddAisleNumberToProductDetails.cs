namespace FindYourItem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAisleNumberToProductDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductDetails", "AisleNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductDetails", "AisleNumber");
        }
    }
}
