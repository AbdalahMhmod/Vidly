namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id, SingnUpFee, DurationInMonth, DiscountRate, Name) VALUES (1, 0, 0, 0, 'Pay as You Go')");
            Sql("INSERT INTO MembershipTypes (Id, SingnUpFee, DurationInMonth, DiscountRate, Name) VALUES (2, 3, 1, 10, 'Monthly')");
            Sql("INSERT INTO MembershipTypes (Id, SingnUpFee, DurationInMonth, DiscountRate, Name) VALUES (3, 90, 3, 15, 'Quarterly')");
            Sql("INSERT INTO MembershipTypes (Id, SingnUpFee, DurationInMonth, DiscountRate, Name) VALUES (4, 300, 12, 20, 'annually')");
        }
        
        public override void Down()
        {
        }
    }
}
