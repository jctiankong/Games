namespace WebAPIGameTable.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebAPIGameTable.Models.WebAPIGameTableContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebAPIGameTable.Models.WebAPIGameTableContext context)
        {
            context.Genres.AddOrUpdate(new Models.Genre[] {
        new Models.Genre() { GenreId = 1, GenreName = "Action-adventure" , Description = "The action-adventure video game."}
        });


            context.Ratings.AddOrUpdate(new Models.Rating[] {
        new Models.Rating() { RatingId = 1, RatingValue = "Rating 94%", Description = "Good" },
        });


            context.Games.AddOrUpdate(new Models.Game[] {
        new Models.Game() { GameId = 1, Name = "God of War", ReleaseYear = "April 20, 2018",
        GenreId = 1, RatingId = 1 }
           });
        }
    }
}
