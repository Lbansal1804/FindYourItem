namespace FindYourItem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsToProductName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductNames", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductNames", "Name", c => c.String());
        }
    }
}
