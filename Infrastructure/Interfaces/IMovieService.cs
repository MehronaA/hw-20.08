using System;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IMovieService
{
    List<Movie> GetMovies();
    Movie GetMovieById(int id);
    int CreateMovie(Movie movie);
    int UpdateMovie(Movie movie);
    int DeleteMovie(int id);
}
