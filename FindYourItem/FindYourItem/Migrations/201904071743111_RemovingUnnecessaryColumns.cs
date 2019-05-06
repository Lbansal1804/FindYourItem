namespace FindYourItem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingUnnecessaryColumns : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProductDetails", "AdminDetails_AdminId");
            DropColumn("dbo.ProductDetails", "AdminDetails_StoreId");
            DropColumn("dbo.ProductDetails", "AdminDetailsStoreId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductDetails", "AdminDetailsStoreId", c => c.Int(nullable: false));
            AddColumn("dbo.ProductDetails", "AdminDetails_StoreId", c => c.Int(nullable: false));
            AddColumn("dbo.ProductDetails", "AdminDetails_AdminId", c => c.Int(nullable: false));
        }
    }
}
