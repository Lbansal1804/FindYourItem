namespace FindYourItem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsToAdminDetails : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AdminDetails", "AdminName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.AdminDetails", "Username", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.AdminDetails", "Password", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.AdminDetails", "EmailAddress", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.AdminDetails", "Location", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AdminDetails", "Location", c => c.String());
            AlterColumn("dbo.AdminDetails", "EmailAddress", c => c.String());
            AlterColumn("dbo.AdminDetails", "Password", c => c.String());
            AlterColumn("dbo.AdminDetails", "Username", c => c.String());
            AlterColumn("dbo.AdminDetails", "AdminName", c => c.String());
        }
    }
}
