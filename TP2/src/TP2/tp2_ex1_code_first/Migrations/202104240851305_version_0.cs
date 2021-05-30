namespace tp2_code_first.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version_0 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.cinemas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        opening_time = c.String(),
                        closing_time = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        global_rating = c.Int(nullable: false),
                        price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovieCinemas",
                c => new
                    {
                        Movie_Id = c.Int(nullable: false),
                        Cinema_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_Id, t.Cinema_Id })
                .ForeignKey("dbo.movies", t => t.Movie_Id, cascadeDelete: true)
                .ForeignKey("dbo.cinemas", t => t.Cinema_Id, cascadeDelete: true)
                .Index(t => t.Movie_Id)
                .Index(t => t.Cinema_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieCinemas", "Cinema_Id", "dbo.cinemas");
            DropForeignKey("dbo.MovieCinemas", "Movie_Id", "dbo.movies");
            DropIndex("dbo.MovieCinemas", new[] { "Cinema_Id" });
            DropIndex("dbo.MovieCinemas", new[] { "Movie_Id" });
            DropTable("dbo.MovieCinemas");
            DropTable("dbo.movies");
            DropTable("dbo.cinemas");
        }
    }
}
