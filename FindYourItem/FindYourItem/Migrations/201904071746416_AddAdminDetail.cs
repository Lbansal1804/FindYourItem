namespace FindYourItem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdminDetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreId = c.Int(nullable: false),
                        AdminName = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        EmailAddress = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ProductDetails", "AdminDetailStoreId", c => c.Int(nullable: false));
            AddColumn("dbo.ProductDetails", "AdminDetail_Id", c => c.Int());
            CreateIndex("dbo.ProductDetails", "AdminDetail_Id");
            AddForeignKey("dbo.ProductDetails", "AdminDetail_Id", "dbo.AdminDetails", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductDetails", "AdminDetail_Id", "dbo.AdminDetails");
            DropIndex("dbo.ProductDetails", new[] { "AdminDetail_Id" });
            DropColumn("dbo.ProductDetails", "AdminDetail_Id");
            DropColumn("dbo.ProductDetails", "AdminDetailStoreId");
            DropTable("dbo.AdminDetails");
        }
    }
}
