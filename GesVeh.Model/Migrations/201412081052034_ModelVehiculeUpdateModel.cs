namespace GesVeh.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelVehiculeUpdateModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Options", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Options", "Description", c => c.Int(nullable: false));
        }
    }
}
