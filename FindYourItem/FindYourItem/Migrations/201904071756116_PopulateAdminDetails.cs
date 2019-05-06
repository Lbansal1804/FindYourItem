namespace FindYourItem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateAdminDetails : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT AdminDetails ON");

            Sql("INSERT INTO AdminDetails (Id, StoreId, AdminName, Username, Password, EmailAddress, Location) VALUES (1, 258, 'Lakhu', 'Lakhu123', 'LakhuPass', 'lakhu@gmail.com', 'Kitchener')");
            Sql("INSERT INTO AdminDetails (Id, StoreId, AdminName, Username, Password, EmailAddress, Location) VALUES (2, 258, 'Drash', 'Drash123', 'DrashPass', 'Drash@gmail.com', 'Waterloo')");

            Sql("INSERT INTO AdminDetails (Id, StoreId, AdminName, Username, Password, EmailAddress, Location) VALUES (3, 112, 'Sahil', 'Sahil123', 'SahilPass', 'Sahil@gmail.com', 'Cambridge')");
        }
        
        public override void Down()
        {
        }
    }
}
