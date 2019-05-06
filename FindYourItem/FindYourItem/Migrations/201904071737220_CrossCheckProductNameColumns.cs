namespace FindYourItem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrossCheckProductNameColumns : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductDetails", "AdminDetail_Id", "dbo.AdminDetails");
            DropIndex("dbo.ProductDetails", new[] { "AdminDetail_Id" });
            CreateTable(
                "dbo.ProductNames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.ProductDetails", "ProductNameId");
            AddForeignKey("dbo.ProductDetails", "ProductNameId", "dbo.ProductNames", "Id", cascadeDelete: true);
            DropColumn("dbo.ProductDetails", "ProductName_AdminId");
            DropColumn("dbo.ProductDetails", "ProductName_Name");
            DropColumn("dbo.ProductDetails", "AdminDetailStoreId");
            DropColumn("dbo.ProductDetails", "AdminDetail_Id");
            DropTable("dbo.AdminDetails");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AdminDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ProductDetails", "AdminDetail_Id", c => c.Int());
            AddColumn("dbo.ProductDetails", "AdminDetailStoreId", c => c.Int(nullable: false));
            AddColumn("dbo.ProductDetails", "ProductName_Name", c => c.String());
            AddColumn("dbo.ProductDetails", "ProductName_AdminId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ProductDetails", "ProductNameId", "dbo.ProductNames");
            DropIndex("dbo.ProductDetails", new[] { "ProductNameId" });
            DropTable("dbo.ProductNames");
            CreateIndex("dbo.ProductDetails", "AdminDetail_Id");
            AddForeignKey("dbo.ProductDetails", "AdminDetail_Id", "dbo.AdminDetails", "Id");
        }
    }
}
