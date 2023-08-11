namespace SchoolSystem.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UserUpdate : DbMigration
    {
        public override void Up()
        {


            CreateTable(
                "dbo.UserAccounts",
                c => new
                {
                    UserID = c.Int(nullable: false, identity: true),
                    UserName = c.String(nullable: false),
                    Password = c.String(nullable: false),
                    ConfirmPassword = c.String(nullable: false),
                })
                .PrimaryKey(t => t.UserID);

        }

        public override void Down()
        {

            DropTable("dbo.UserAccounts");

        }
    }
}
