namespace FindYourItem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateProductNames : DbMigration
    {
        public override void Up()
        {

            Sql("SET IDENTITY_INSERT ProductNames ON");
            
            Sql("INSERT INTO ProductNames (Id, Name) VALUES (2, 'Mango')");
            Sql("INSERT INTO ProductNames (Id, Name) VALUES (3, 'Banana')");
            Sql("INSERT INTO ProductNames (Id, Name) VALUES (4, 'Avocado')");
            Sql("INSERT INTO ProductNames (Id, Name) VALUES (5, 'Grapes')");
            Sql("INSERT INTO ProductNames (Id, Name) VALUES (6, 'Cucumber')");
            Sql("INSERT INTO ProductNames (Id, Name) VALUES (7, 'Kiwi')");
        }
        
        public override void Down()
        {
        }
    }
}
