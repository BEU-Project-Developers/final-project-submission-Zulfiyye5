using System.Collections.Generic;

using Microsoft.Data.SqlClient;
using MyProject.Models;
namespace MyProject
{
    public class MovieService
    {
        private readonly string connectionString = "Data Source=DESKTOP-U5F3V0U\\SQLEXPRESS;Initial Catalog=moviesDatabase;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";


        public List<Movie> GetAllMovies()
        {
            var movies = new List<Movie>();
            string query = "SELECT * FROM Movie";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    movies.Add(new Movie
                    {
                        dbId = Convert.ToInt32(reader["dbId"]),
                        Title = reader["Title"].ToString(),
                        Overview = reader["Overview"].ToString(),
                        Image_path = reader["image_path"].ToString(),
                        Bg_image_path = reader["bg_image_path"].ToString(),
                        Imdb = Convert.ToDouble(reader["Imdb"]),
                        Origin_country = reader["Origin_country"].ToString(),
                        Origin_language = reader["Origin_language"].ToString(),
                        Director_name = reader["Director_name"].ToString(),
                        Runtime = Convert.ToInt32(reader["Runtime"]),
                        ReleaseDate = reader["release_date"].ToString(),




                    });
                }

            }
            return movies;
        }


        public List<Movie> GetAllMoviesOfPerson(int person_id)
        {
            var movies = new List<Movie>();
            string query = "SELECT m.dbId, m.title, m.image_path, m.bg_image_path, m.imdb, m.origin_language, m.runtime, m.release_date, " +
                           "m.overview, m.director_name " +
                           "FROM Movie m " +
                           "INNER JOIN MovieCast mc ON m.dbId = mc.movie_id " +
                           "INNER JOIN Person p ON mc.person_id = p.dbId " +
                           "WHERE p.dbId = @person_id;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@person_id", person_id);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    movies.Add(new Movie
                    {
                        dbId = Convert.ToInt32(reader["dbId"]),
                        Title = reader["title"].ToString(),
                        Overview = reader["overview"]?.ToString() ?? string.Empty,
                        Image_path = reader["image_path"]?.ToString() ?? string.Empty,
                        Bg_image_path = reader["bg_image_path"]?.ToString() ?? string.Empty,
                        Imdb = Convert.ToDouble(reader["imdb"]),

                        Origin_language = reader["origin_language"]?.ToString() ?? string.Empty,
                        Director_name = reader["director_name"]?.ToString() ?? string.Empty,
                        Runtime = Convert.ToInt32(reader["runtime"]),
                        ReleaseDate = reader["release_date"] != DBNull.Value ? Convert.ToDateTime(reader["release_date"]).ToString("yyyy-MM-dd") : null
                    });
                }
            }

            return movies;
        }
        public Movie FindMovieById(int movieId)
        {
            Movie movie = null;

            string query = "SELECT dbId, Title, PosterUrl FROM Movie WHERE dbId = @movieId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@movieId", movieId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            movie = new Movie
                            {
                                dbId = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                Image_path = reader.GetString(2)
                            };
                        }
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return movie;
        }




        public List<Genre> FindGenreByMovieId(int movieId)
        {
            List<Genre> genres = new List<Genre>();

            string query = @"
        SELECT g.dbId, g.name 
        FROM MovieGenre mg
        JOIN Genre g ON mg.genre_id = g.dbId
        WHERE mg.movie_id = @movieId;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@movieId", movieId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Genre genre = new Genre
                        {

                            Name = reader.GetString(reader.GetOrdinal("name"))
                        };

                        genres.Add(genre);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return genres;
        }

        public List<MovieCast> FindCastByMovieId(int movieId)
        {
            List<MovieCast> cast = new List<MovieCast>();

            string query = @"
SELECT p.image_path, mg.character_name, mg.person_id,p.person_name,p.biography
FROM MovieCast mg
JOIN Person p ON mg.person_id = p.dbId
JOIN Movie g ON mg.movie_id = g.dbId
WHERE g.dbId = @movieId;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@movieId", movieId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        MovieCast person = new MovieCast
                        {
                            Name = reader.GetString(reader.GetOrdinal("person_name")),
                            Person_id = reader.GetInt32(reader.GetOrdinal("person_id")),
                            Character_name = reader.GetString(reader.GetOrdinal("character_name")),
                            image_url = reader.GetString(reader.GetOrdinal("image_path")),
                            Biography = reader.GetString(reader.GetOrdinal("biography"))
                        };

                        cast.Add(person);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return cast;
        }


        public int? CheckUserFromTable(string email, string password)
        {
            int? userId = null;

            string query = "SELECT id FROM Users WHERE email = @Email AND password = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                   
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        userId = Convert.ToInt32(result); 
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return userId; 
        }

        public bool AddUser(string email,string userName, string password)
        {
          
            if (UserExists(email))
            {
                Console.WriteLine("User already exists.");
                return false;
            }

            string query = "INSERT INTO Users (userName,email, password) VALUES (@UserName,@Email, @Password)";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", userName);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Password", password);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("User successfully added.");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Failed to add the user.");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public bool UserExists(string email)
        {
            string query = "SELECT COUNT(*) FROM Users WHERE email = @Email";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        int userCount = (int)command.ExecuteScalar();

                        return userCount > 0; // If the count is greater than 0, the user exists.
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }



        public User GetUserById(int userId)
        {
            string query = "SELECT id, userName, email, password FROM Users WHERE id = @UserId";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) 
                            {
                                User user = new User
                                {
                                    id = (int)reader["id"],
                                    name = reader["userName"].ToString(),
                                    email = reader["email"].ToString(),
                                    password = reader["password"].ToString()
                                };

                                return user; 
                            }
                            else
                            { 
                                return null;
                                
                                }
                               
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }



        public void AddToFavorite(int movieId,int userId)
        {
            string query = "INSERT INTO FavoriteMovies (user_id, movie_id) VALUES (@UserId, @MovieId)";


            try
            {
         
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                    
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@MovieId", movieId);

                      
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Movie successfully added to favorites.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to add the movie to favorites.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        

    }


        public void AddReview(int movieId,int userId,string reviewText)
        {
            string query = "INSERT INTO MovieReviews (user_id, movie_id,reviewText) VALUES (@UserId, @MovieId,@ReviewText)";


            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@MovieId", movieId);
                        command.Parameters.AddWithValue("@ReviewText", reviewText);


                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Review successfully added.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to add the review.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }

        public void RemoveFromFavorite(int movieId, int userId)
        {
            string query = "DELETE FROM FavoriteMovies WHERE user_id = @UserId AND movie_id = @MovieId";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@MovieId", movieId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Movie successfully removed from favorites.");
                        }
                        else
                        {
                            Console.WriteLine("Movie not found in favorites.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        public bool IsFavorite(int movieId, int userId)
        {
            string query = "SELECT COUNT(*) FROM FavoriteMovies WHERE user_id = @UserId AND movie_id = @MovieId";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@MovieId", movieId);

                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public List<Movie> GetFavorities(int userId)
        {
            var movies = new List<Movie>();
            string query = "SELECT m.dbId,m.title,m.overview,m.image_path,m.bg_image_path,m.imdb,m.origin_country," +
                "   m.origin_language,m.director_name,m.runtime,m.release_date,f.movie_id,f.user_id  FROM Movie m Join FavoriteMovies f ON   m.dbId = f.movie_id  WHERE user_id = @UserId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", userId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    movies.Add(new Movie
                    {
                        dbId = Convert.ToInt32(reader["dbId"]),
                        Title = reader["title"].ToString(),
                        Overview = reader["overview"].ToString(),
                        Image_path = reader["image_path"].ToString(),
                        Bg_image_path = reader["bg_image_path"].ToString(),
                        Imdb = Convert.ToDouble(reader["imdb"]),
                        Origin_country = reader["origin_country"].ToString(),
                        Origin_language = reader["origin_language"].ToString(),
                        Director_name = reader["director_name"].ToString(),
                        Runtime = Convert.ToInt32(reader["runtime"]),
                        ReleaseDate = reader["release_date"].ToString(),




                    });
                }

            }
            return movies;
        }

        public List<Movie> HighestImdbMovies()
        {
            var movies = new List<Movie>();
            string query = "SELECT TOP 10 m.dbId, m.title, m.overview, m.image_path, m.bg_image_path, m.imdb, " +
                "m.origin_country, m.origin_language, m.director_name, m.runtime, m.release_date " +
                "FROM Movie m ORDER BY m.imdb DESC;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
              
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    movies.Add(new Movie
                    {
                        dbId = Convert.ToInt32(reader["dbId"]),
                        Title = reader["title"].ToString(),
                        Overview = reader["overview"].ToString(),
                        Image_path = reader["image_path"].ToString(),
                        Bg_image_path = reader["bg_image_path"].ToString(),
                        Imdb = Convert.ToDouble(reader["imdb"]),
                        Origin_country = reader["origin_country"].ToString(),
                        Origin_language = reader["origin_language"].ToString(),
                        Director_name = reader["director_name"].ToString(),
                        Runtime = Convert.ToInt32(reader["runtime"]),
                        ReleaseDate = reader["release_date"].ToString(),




                    });
                }

            }
            return movies;

        }



        public List<Movie> PopularMovies()
        {
            var movies = new List<Movie>();
            string query = "SELECT \r\n    m.dbId, \r\n    m.title, \r\n    m.overview, \r\n    m.image_path, \r\n    m.bg_image_path, \r\n    m.imdb, \r\n    m.origin_country, \r\n    m.origin_language, \r\n    m.director_name, \r\n    m.runtime, \r\n    m.release_date,\r\n    j.wcount\r\nFROM \r\n    Movie m\r\nJOIN \r\n    (SELECT\r\n        w.movie_id,\r\n        m.title AS MovieTitle,\r\n        COUNT(w.movie_id) AS wcount\r\n     FROM \r\n        WatchedMovies w\r\n     JOIN \r\n        Movie m ON w.movie_id = m.dbId\r\n     GROUP BY \r\n        w.movie_id, m.title\r\n     ORDER BY \r\n        wcount DESC\r\n     OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY) j  \r\nON \r\n    m.dbId = j.movie_id\r\nORDER BY \r\n    j.wcount DESC;\r\n";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    movies.Add(new Movie
                    {
                        dbId = Convert.ToInt32(reader["dbId"]),
                        Title = reader["title"].ToString(),
                        Overview = reader["overview"].ToString(),
                        Image_path = reader["image_path"].ToString(),
                        Bg_image_path = reader["bg_image_path"].ToString(),
                        Imdb = Convert.ToDouble(reader["imdb"]),
                        Origin_country = reader["origin_country"].ToString(),
                        Origin_language = reader["origin_language"].ToString(),
                        Director_name = reader["director_name"].ToString(),
                        Runtime = Convert.ToInt32(reader["runtime"]),
                        ReleaseDate = reader["release_date"].ToString(),
                    });
                }
            }
            return movies;
        }

        public List<Movie> GetWatchList(int userId)
        {
            var movies = new List<Movie>();
            string query = "SELECT m.dbId,m.title,m.overview,m.image_path,m.bg_image_path,m.imdb,m.origin_country," +
                "   m.origin_language,m.director_name,m.runtime,m.release_date,f.movie_id,f.user_id  FROM Movie m Join WatchListMovies f ON   m.dbId = f.movie_id  WHERE user_id = @UserId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", userId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    movies.Add(new Movie
                    {
                        dbId = Convert.ToInt32(reader["dbId"]),
                        Title = reader["title"].ToString(),
                        Overview = reader["overview"].ToString(),
                        Image_path = reader["image_path"].ToString(),
                        Bg_image_path = reader["bg_image_path"].ToString(),
                        Imdb = Convert.ToDouble(reader["imdb"]),
                        Origin_country = reader["origin_country"].ToString(),
                        Origin_language = reader["origin_language"].ToString(),
                        Director_name = reader["director_name"].ToString(),
                        Runtime = Convert.ToInt32(reader["runtime"]),
                        ReleaseDate = reader["release_date"].ToString(),




                    });
                }

            }
            return movies;
        }

        public List<Movie> GetWatchedMovies(int userId)
        {
            var movies = new List<Movie>();
            string query = "SELECT m.dbId,m.title,m.overview,m.image_path,m.bg_image_path,m.imdb,m.origin_country," +
                "   m.origin_language,m.director_name,m.runtime,m.release_date,f.movie_id,f.user_id  FROM Movie m Join WatchedMovies f ON   m.dbId = f.movie_id  WHERE user_id = @UserId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", userId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    movies.Add(new Movie
                    {
                        dbId = Convert.ToInt32(reader["dbId"]),
                        Title = reader["title"].ToString(),
                        Overview = reader["overview"].ToString(),
                        Image_path = reader["image_path"].ToString(),
                        Bg_image_path = reader["bg_image_path"].ToString(),
                        Imdb = Convert.ToDouble(reader["imdb"]),
                        Origin_country = reader["origin_country"].ToString(),
                        Origin_language = reader["origin_language"].ToString(),
                        Director_name = reader["director_name"].ToString(),
                        Runtime = Convert.ToInt32(reader["runtime"]),
                        ReleaseDate = reader["release_date"].ToString(),




                    });
                }

            }
            return movies;
        }
        public void AddToWatched(int movieId, int userId)
        {
            string query = "INSERT INTO WatchedMovies (user_id, movie_id) VALUES (@UserId, @MovieId)";


            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@MovieId", movieId);


                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Movie successfully added to WatchedMovies.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to add the movie to WatchedMovies.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }


        }
        public void RemoveFromWatched(int movieId, int userId)
        {
            string query = "DELETE FROM WatchedMovies WHERE user_id = @UserId AND movie_id = @MovieId";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@MovieId", movieId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Movie successfully removed from WatchedMovies.");
                        }
                        else
                        {
                            Console.WriteLine("Movie not found in WatchedMovies.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public bool IsWatched(int movieId, int userId)
        {
            string query = "SELECT COUNT(*) FROM WatchedMovies WHERE user_id = @UserId AND movie_id = @MovieId";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@MovieId", movieId);

                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        

        public void AddToWatchList(int movieId, int userId)
        {
            string query = "INSERT INTO WatchListMovies (user_id, movie_id) VALUES (@UserId, @MovieId)";


            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@MovieId", movieId);


                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Movie successfully added to WatchListMovies.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to add the movie to WatchListMovies.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }


        }


        public void RemoveFromWatchList(int movieId, int userId)
        {
            string query = "DELETE FROM WatchListMovies WHERE user_id = @UserId AND movie_id = @MovieId";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@MovieId", movieId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Movie successfully removed from WatchListMovies.");
                        }
                        else
                        {
                            Console.WriteLine("Movie not found in WatchListMovies.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public bool IsWatchList(int movieId, int userId)
        {
            string query = "SELECT COUNT(*) FROM WatchListMovies WHERE user_id = @UserId AND movie_id = @MovieId";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@MovieId", movieId);

                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }


        public List<Movie> SearchMovies(string searchTerm)
        {
            List<Movie> movies = new List<Movie>();

           
            string query = "SELECT * FROM Movie WHERE title LIKE @searchTerm";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%"); 

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Movie movie = new Movie
                        {
                            dbId = Convert.ToInt32(reader["dbId"]),
                            Title = reader["Title"].ToString(),
                            Overview = reader["Overview"].ToString(),
                            Image_path = reader["image_path"].ToString(),
                            Bg_image_path = reader["bg_image_path"].ToString(),
                            Imdb = Convert.ToDouble(reader["Imdb"]),
                            Origin_country = reader["Origin_country"].ToString(),
                            Origin_language = reader["Origin_language"].ToString(),
                            Director_name = reader["Director_name"].ToString(),
                            Runtime = Convert.ToInt32(reader["Runtime"]),
                            ReleaseDate = reader["release_date"].ToString(),
                        };
                        movies.Add(movie);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return movies;
        }
    }

}