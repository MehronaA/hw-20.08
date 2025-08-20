using System.Runtime.InteropServices;
using Domain.Entities;
using Infrastructure.Services;

while (true)
{
    Console.WriteLine("_________________________________________");
    var MovieService = new MovieService();
    Console.WriteLine("What would you do?");
    Console.WriteLine("1.Insert movie");
    Console.WriteLine("2.Get all movies");
    Console.WriteLine("3.Change movie's information");
    Console.WriteLine("4.Delete movie from list of movies");
    Console.WriteLine("5.find movie by id");
    Console.WriteLine("6.Finish programm");
    Console.Write("Choose operation you'd like to do: ");
    Console.WriteLine("_________________________________________");

    int choosed = Convert.ToInt32(Console.ReadLine());
    if (choosed == 1)
    {
        Console.Write("Movies title: ");
        var title = Console.ReadLine();
        Console.Write("Movies Director: ");
        var director = Console.ReadLine();
        Console.Write("Released year: ");
        var year = Convert.ToInt32(Console.ReadLine());
        var movie = new Movie()
        {
            Title = title,
            Director = director,
            Year = year
        };
        var created = MovieService.CreateMovie(movie);
        if (created > 0) Console.WriteLine("Your movie succesfully created");
    }
    else if (choosed == 2)
    {
        Console.WriteLine("Id\tTitle\tDirector\tYear");
        var allmovies = MovieService.GetMovies();
        foreach (var movie in allmovies)
        {
            Console.WriteLine($"{movie.Id}\t{movie.Title}\t{movie.Director}\t{movie.Year}");
        }
    }
    else if (choosed == 3)
    {
        Console.Write("Write movie's id: ");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.Write("Movies title: ");
        var title = Console.ReadLine();
        Console.Write("Movies Director: ");
        var director = Console.ReadLine();
        Console.Write("Released year: ");
        var year = Convert.ToInt32(Console.ReadLine());
        var uppdatedmovie = new Movie()
        {
            Id = id,
            Title = title,
            Director = director,
            Year = year
        };
        var updated = MovieService.UpdateMovie(uppdatedmovie);
        if (updated > 0)
        {
            Console.WriteLine("Movie updated");
        }
    }
    else if (choosed == 4)
    {
        Console.Write("Write movie's id that you want to delete:");
        var id = Convert.ToInt32(Console.ReadLine());
        var delete = MovieService.DeleteMovie(id);
        if (delete > 0) Console.WriteLine("Movie deleted");
    }
    else if (choosed == 5)
    {
        Console.Write("Write movie id:");
        var movieId = Convert.ToInt32(Console.ReadLine());
        var foundMovie = MovieService.GetMovieById(movieId);
        if (foundMovie != null) Console.WriteLine($"Title: {foundMovie.Title}\t Director: {foundMovie.Director}\tYear: {foundMovie.Year}");
        else Console.WriteLine("Movie with this id doesn't exist");
    }
    else if (choosed == 6)
    {
        Console.WriteLine("Finished programm");
        break;
    }

}