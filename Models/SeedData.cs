using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Create the database if it doesn't exist
            context.Database.EnsureCreated();

            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Rating = "R",
                    Price = 7.99M
                },
                new Movie
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Rating = "PG",
                    Price = 8.99M
                },
                new Movie
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Rating = "PG",
                    Price = 9.99M
                },
                new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Rating = "PG-13",
                    Price = 3.99M
                },
                new Movie
                {
                    Title = "The Social Network",
                    ReleaseDate = DateTime.Parse("2010-1-10"),
                    Genre = "Drama / Biography",
                    Rating = "PG-13",
                    Price = 8.99M
                },
                new Movie
                {
                    Title = "Coach Carter",
                    ReleaseDate = DateTime.Parse("2005-1-14"),
                    Genre = "Sports / Drama",
                    Rating = "PG-13",
                    Price = 6.99M
                },
                new Movie
                {
                    Title = "The Usual Suspects",
                    ReleaseDate = DateTime.Parse("1995-8-16"),
                    Genre = "Crime / Mystery / Thriller",
                    Rating = "R",
                    Price = 7.49M
                }
            );
            context.SaveChanges();
        }
    }
}