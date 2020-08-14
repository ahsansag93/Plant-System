namespace WaterPlant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addplanttbl2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Plants", "LastWatered", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Plants", "LastWatered", c => c.DateTime(nullable: false));
        }
    }
}
