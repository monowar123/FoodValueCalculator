namespace DBAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FoodItems",
                c => new
                    {
                        FoodItemId = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        VitaminUnit = c.Double(nullable: false),
                        MineralUnit = c.Double(nullable: false),
                        ProteinUnit = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.FoodItemId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FoodItems");
        }
    }
}
