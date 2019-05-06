namespace FindYourItem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductName : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductNames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ProductDetails", "ProductNameId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductDetails", "ProductNameId");
            AddForeignKey("dbo.ProductDetails", "ProductNameId", "dbo.ProductNames", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductDetails", "ProductNameId", "dbo.ProductNames");
            DropIndex("dbo.ProductDetails", new[] { "ProductNameId" });
            DropColumn("dbo.ProductDetails", "ProductNameId");
            DropTable("dbo.ProductNames");
        }
    }
}
