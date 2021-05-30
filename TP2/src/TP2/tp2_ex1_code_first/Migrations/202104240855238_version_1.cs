namespace tp2_code_first.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version_1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.cinemas", "description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.cinemas", "description");
        }
    }
}
