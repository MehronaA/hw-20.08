using System.Runtime.InteropServices;
using Domain.Entities;
using Infrastructure.Services;

var MovieService = new MovieService();
var movie1 = new Movie()
{
    Title = "La La Land",
    Director = "Damien Chazelle",
    Year = 2016
};
var movie2 = new Movie()
{
    Title = "Call Me by Your Name",
    Director = "Luca Guadagnino",
    Year = 2017
};
var movie3 = new Movie()
{
    Title = "A Star Is Born",
    Director = "Bradley Cooper",
    Year = 2017
};
var movie4 = new Movie()
{
    Title = "Little Women",
    Director = "Greta Gerwig",
    Year = 2019
};
MovieService.CreateMovie(movie1);
MovieService.CreateMovie(movie2);
MovieService.CreateMovie(movie3);
MovieService.CreateMovie(movie4);
Console.WriteLine("Movies added");
Console.WriteLine("_______________");

Console.WriteLine("All movies");

var movies = MovieService.GetMovies();
foreach (var item in movies)
{
    Console.WriteLine($"{item.Id}\t{item.Title}\t{item.Director}\t{item.Year}");
}

var movie5 = new Movie()
{
    Title = "Purple Hearts",
    Director = "Elizabeth Allen Rosenbaum",
    Year = 2022
};
var crmv = MovieService.CreateMovie(movie5);
if(crmv>0)Console.WriteLine("Added 1 movies");

var updatemovie = new Movie()
{
    Id = 3,
    Title = "A Star Is Born",
    Director = "Bradley Cooper",
    Year = 2018
};
var upmv = MovieService.UpdateMovie(updatemovie);
if(upmv>0)Console.WriteLine("Movie updated");

 var dlmv=MovieService.DeleteMovie(2);
if (dlmv > 0) Console.WriteLine("Movie deleted");

var GetMovieById = MovieService.GetMovieById(1);
Console.WriteLine("find by id");
Console.WriteLine($"{GetMovieById.Id}\t {GetMovieById.Title}\t {GetMovieById.Director}\t{GetMovieById.Year}");

