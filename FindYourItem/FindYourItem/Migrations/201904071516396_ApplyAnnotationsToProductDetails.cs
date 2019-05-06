namespace FindYourItem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsToProductDetails : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductDetails", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.ProductDetails", "AisleNumber", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.ProductDetails", "Location", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductDetails", "Location", c => c.String());
            AlterColumn("dbo.ProductDetails", "AisleNumber", c => c.String());
            AlterColumn("dbo.ProductDetails", "Name", c => c.String());
        }
    }
}
