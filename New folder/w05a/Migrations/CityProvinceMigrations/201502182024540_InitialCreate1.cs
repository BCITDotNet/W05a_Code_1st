namespace w05a.Migrations.CityProvinceMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Provinces", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Cities", "ProvinceId", "dbo.Provinces");
            DropIndex("dbo.Provinces", new[] { "CityId" });
            DropPrimaryKey("dbo.Provinces");
            AddColumn("dbo.Cities", "ProvinceId", c => c.Int(nullable: false));
            AddColumn("dbo.Provinces", "ProvinceId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Provinces", "ProvCode", c => c.String());
            AddPrimaryKey("dbo.Provinces", "ProvinceId");
            CreateIndex("dbo.Cities", "ProvinceId");
            AddForeignKey("dbo.Cities", "ProvinceId", "dbo.Provinces", "ProvinceId", cascadeDelete: true);
            DropColumn("dbo.Provinces", "CityId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Provinces", "CityId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Cities", "ProvinceId", "dbo.Provinces");
            DropIndex("dbo.Cities", new[] { "ProvinceId" });
            DropPrimaryKey("dbo.Provinces");
            AlterColumn("dbo.Provinces", "ProvCode", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Provinces", "ProvinceId");
            DropColumn("dbo.Cities", "ProvinceId");
            AddPrimaryKey("dbo.Provinces", "ProvCode");
            CreateIndex("dbo.Provinces", "CityId");
            AddForeignKey("dbo.Cities", "ProvinceId", "dbo.Provinces", "ProvinceId", cascadeDelete: true);
            AddForeignKey("dbo.Provinces", "CityId", "dbo.Cities", "CityId", cascadeDelete: true);
        }
    }
}
