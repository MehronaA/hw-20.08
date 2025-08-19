using System;
using Domain.Entities;
using Infrastructure.Interfaces;
using Npgsql;

namespace Infrastructure.Services;

public class MovieService : IMovieService
{  
    public List<Movie> GetMovies()
    {
        List<Movie> movies = new List<Movie>();
        string connectionString = "Server=localhost;Database=home;Username=postgres;Password=m.613524";
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        var cmd = "select * from movie";
        var select = new NpgsqlCommand(cmd, connection);
        var reader = select.ExecuteReader();
        while (reader.Read())
        {
            var newMovie = new Movie()
            {
                Id = (int)reader["id"],
                Title = (string)reader["title"],
                Director = (string)reader["director"],
                Year = (int)reader["year"]
            };
            movies.Add(newMovie);
        }
        return movies;
    }
    public Movie GetMovieById(int id)
    {
        string connectionString = "Server=localhost;Database=home;Username=postgres;Password=m.613524";
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        var cmd = $"select * from movie where id={id}";
        var select = new NpgsqlCommand(cmd, connection);
        var reader = select.ExecuteReader();
        reader.Read();
        var getmovie = new Movie()
        {
            Id = (int)reader["id"],
            Title = (string)reader["title"],
            Director = (string)reader["director"],
            Year = (int)reader["year"]
        };
        return getmovie;

    }
    public int CreateMovie(Movie movie)
    {
        string connectionString = "Server=localhost;Database=home;Username=postgres;Password=m.613524";
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        var cmd = $"insert into movie(title,director,year) values('{movie.Title}','{movie.Director}',{movie.Year})";
        var insert = new NpgsqlCommand(cmd, connection);
        var result = insert.ExecuteNonQuery();
        return result;
    }
    public int UpdateMovie(Movie movie)
    {
        string connectionString = "Server=localhost;Database=home;Username=postgres;Password=m.613524";
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        var cmd = $"update movie set title='{movie.Title}',director='{movie.Director}',year={movie.Year} where id={movie.Id}";
        var update = new NpgsqlCommand(cmd, connection);
        var result = update.ExecuteNonQuery();
        return result;
    }
    public int DeleteMovie(int id)
    {
        string connectionString = "Server=localhost;Database=home;Username=postgres;Password=m.613524";
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        var cmd = $"delete from movie where id={id}";
        var delete = new NpgsqlCommand(cmd, connection);
        var result = delete.ExecuteNonQuery();
        return result;
    }

    
}
