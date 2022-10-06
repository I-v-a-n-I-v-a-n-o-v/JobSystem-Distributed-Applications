namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(nullable: false, maxLength: 50),
                    Description = c.String(nullable: true, maxLength: 280),
                    Type = c.String(maxLength: 20),
                    Publisher = c.String(nullable: false, maxLength: 50),
                    PublishedOn = c.DateTime(nullable: true),
                    Category = c.String(nullable: true, maxLength: 30),
                    OrganisationId = c.Int(nullable: false),
                    User_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organisations", t => t.OrganisationId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.OrganisationId)
                .Index(t => t.User_Id);

            CreateTable(
                "dbo.Organisations",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 50),
                    Email = c.String(nullable: false, maxLength: 90),
                    Password = c.String(nullable: false, maxLength: 40),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Users",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Email = c.String(nullable: false, maxLength: 90),
                    Username = c.String(maxLength: 50),
                    Password = c.String(nullable: false, maxLength: 40),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Jobs", "OrganisationId", "dbo.Organisations");
            DropIndex("dbo.Jobs", new[] { "User_Id" });
            DropIndex("dbo.Jobs", new[] { "OrganisationId" });
            DropTable("dbo.Users");
            DropTable("dbo.Organisations");
            DropTable("dbo.Jobs");
        }
    }
}
