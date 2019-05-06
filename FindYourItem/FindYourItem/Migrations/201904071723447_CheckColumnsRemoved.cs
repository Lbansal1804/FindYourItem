namespace FindYourItem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckColumnsRemoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProductDetails", "AdminDetails_AdminId");
            DropColumn("dbo.ProductDetails", "AdminDetails_StoreId");
            DropColumn("dbo.ProductDetails", "AdminDetails_AdminName");
            DropColumn("dbo.ProductDetails", "AdminDetails_Username");
            DropColumn("dbo.ProductDetails", "AdminDetails_Password");
            DropColumn("dbo.ProductDetails", "AdminDetails_EmailAddress");
            DropColumn("dbo.ProductDetails", "AdminDetails_Location");
            DropColumn("dbo.ProductDetails", "AdminDetailsStoreId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductDetails", "AdminDetailsStoreId", c => c.Int(nullable: false));
            AddColumn("dbo.ProductDetails", "AdminDetails_Location", c => c.String());
            AddColumn("dbo.ProductDetails", "AdminDetails_EmailAddress", c => c.String());
            AddColumn("dbo.ProductDetails", "AdminDetails_Password", c => c.String());
            AddColumn("dbo.ProductDetails", "AdminDetails_Username", c => c.String());
            AddColumn("dbo.ProductDetails", "AdminDetails_AdminName", c => c.String());
            AddColumn("dbo.ProductDetails", "AdminDetails_StoreId", c => c.Int(nullable: false));
            AddColumn("dbo.ProductDetails", "AdminDetails_AdminId", c => c.Int(nullable: false));
        }
    }
}
