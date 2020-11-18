namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            // pay as you go
            Sql("INSERT INTO Membershiptypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (1, 0, 0, 0)");
            // monthly
            Sql("INSERT INTO Membershiptypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (2, 30, 1, 10)");
            // quarterly
            Sql("INSERT INTO Membershiptypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (3, 90, 3, 15)");
            // yearly
            Sql("INSERT INTO Membershiptypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (4, 300, 12, 20)");
        }
        
        public override void Down()
        {
        }
    }
}
