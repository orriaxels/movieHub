using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using DM.MovieApi;
using DM.MovieApi.MovieDb.Movies;
using DM.MovieApi.ApiResponse;
using System.Threading.Tasks;
using MovieHub.Models;
using DM.MovieApi.MovieDb.People;


namespace MovieHub.Services
{
    public class MovieService
    {
        public string apiKey = "807f816252d83b681cf3b2efe5ffe5b0";
        public string apiUrl = "https://api.themoviedb.org/3/";
        private string imageURI = "http://image.tmdb.org/t/p/original";

        private IApiMovieRequest _api;
        private IApiPeopleRequest _pApi;
        private List<MovieDetail> _movies;

        public MovieService()
        {
            MovieDbFactory.RegisterSettings(apiKey, apiUrl);
            _api = MovieDbFactory.Create<IApiMovieRequest>().Value;
            _pApi = MovieDbFactory.Create<IApiPeopleRequest>().Value;
            _movies = new List<MovieDetail>();
        }

        public async Task<List<MovieDetail>> GetMovieByTitle(string title)
        {
            if(title == string.Empty)
            {
                return _movies;
            }

            ApiSearchResponse<MovieInfo> response = await _api.SearchByTitleAsync(title);

            _movies = new List<MovieDetail>();

            if (response.Results == null)
            {
                return _movies;
            }

            if (response.Results != null)
            {
                foreach (MovieInfo info in response.Results)
                {
                    _movies.Add(new MovieDetail
                    {
                        id = info.Id,
                        title = info.Title,
                        imageUrl = imageURI + info.PosterPath,
                        releaseDate = "(" + info.ReleaseDate.Year.ToString() + ")",
                        voteAverage = info.VoteAverage,
                        voteCount = info.VoteCount,
                        posterFilePath = "",
                        runtime = "",
                        director = "",
                        writers = new List<String>(),
                        genres = "",
                        actors = new List<String>(),
                        characters = new List<String>(),
                        cast = new List<Cast>(),
                        backDrop = imageURI + info.BackdropPath
                    });
                }
            }

            return _movies;
        }

        public async Task GetCastMembers(MovieDetail movie)
        {
            for (int i = 0; i < movie.cast.Count; i++)
            {
                ApiQueryResponse<Person> castDetail = await _pApi.FindByIdAsync(movie.cast[i].id);
                if (castDetail.Item != null)
                {
                    movie.cast[i].posterPath = castDetail.Item.ProfilePath;
                }
            }
        }

        public async Task<String> GetActorsAndRoles(MovieDetail movie)
        {
            ApiQueryResponse<MovieCredit> cast = await _api.GetCreditsAsync(movie.id);
            var actors = "";
            if (cast.Item != null)
            {
                for (int i = 0; i < cast.Item.CastMembers.Count && i < 7; i++)
                {
                    if(i+1 == cast.Item.CastMembers.Count && i < 7)
                    {
                        actors += cast.Item.CastMembers[i].Name + " - " + cast.Item.CastMembers[i].Character;
                    }
                    else
                    {
                        actors += cast.Item.CastMembers[i].Name + " - " + cast.Item.CastMembers[i].Character + "\n";    
                    }
                }
            }
            return actors;
        }

        public async Task GetCreditList(MovieDetail movie)
        {
            ApiQueryResponse<MovieCredit> cast = await _api.GetCreditsAsync(movie.id);

            if (cast.Item != null)
            {
                for (int i = 0; i < cast.Item.CastMembers.Count && i < 7; i++)
                {
                    movie.actors.Add(cast.Item.CastMembers[i].Name);
                    movie.characters.Add(cast.Item.CastMembers[i].Character);

                    movie.cast.Add(new Models.Cast   
                    {
                        id = cast.Item.CastMembers[i].PersonId,
                        name = cast.Item.CastMembers[i].Name
                    });
                }
            }

            if (cast.Item != null)
            {
                var director = cast.Item.CrewMembers.FirstOrDefault(x => x.Job == "Director");
                if (director != null)
                {
                    if (director.Name != "")
                        movie.director = director.Name;
                }
                else
                {
                    movie.director = "Not defined";
                }

                var writers = cast.Item.CrewMembers.ToList();
                writers.Where(x => x.Job == "Screenplay").ToList();
                if (writers != null)
                {
                    for (int i = 0; i < writers.Count && i < 3; i++)
                    {
                        if (writers[i].Name != "")
                        {
                            movie.writers.Add(writers[i].Name);
                        }
                    }
                }
                else
                {
                    movie.writers.Add("Unknown");
                }
            }
        }

        public async Task<MovieDetail> GetMovieDetail(int id)
        {
            ApiQueryResponse<Movie> movieInfo = await _api.FindByIdAsync(id);
            MovieDetail movie = new MovieDetail();

            if (movieInfo.Item != null)
            {
                movie = new MovieDetail()
                {
                    title = movieInfo.Item.Title,
                    runtime = movieInfo.Item.Runtime.ToString(),
                    description = movieInfo.Item.Overview,
                    tagLine = movieInfo.Item.Tagline,
                    budget = movieInfo.Item.Budget.ToString(),
                };

                var movieGenre = "";

                for (int i = 0; i < movieInfo.Item.Genres.Count; i++)
                {
                    if (i + 1 == movieInfo.Item.Genres.Count)
                    {
                        movieGenre += movieInfo.Item.Genres[i];
                    }
                    else
                    {
                        movieGenre += movieInfo.Item.Genres[i] + ", ";
                    }
                }

                movie.genres = movieGenre;

                //for (int i = 0; i < movieInfo.Item.Genres.Count; i++)
                //{
                //    if(i == movieInfo.Item.Genres.Count())
                //    movie.genres.Add(movieInfo.Item.Genres[i].ToString());
                //}
            }
            return movie;
        }

        public async Task<List<MovieDetail>> getTopRatedMovies()
        {
            ApiSearchResponse<MovieInfo> response = await _api.GetTopRatedAsync();
            List<MovieDetail> movies = new List<MovieDetail>();

            if (response.Results == null)
            {
                return movies;
            }

            if (response.Results != null)
            {
                foreach (MovieInfo info in response.Results)
                {
                    movies.Add(new MovieDetail
                    {
                        id = info.Id,
                        title = info.Title,
                        imageUrl = imageURI + info.PosterPath,
                        releaseDate = "(" + info.ReleaseDate.Year.ToString() + ")",
                        voteAverage = info.VoteAverage,
                        voteCount = info.VoteCount,
                        posterFilePath = "",
                        runtime = "",
                        director = "",
                        writers = new List<String>(),
                        genres = "",
                        actors = new List<String>(),
                        characters = new List<String>(),
                        cast = new List<Cast>()
                    });
                }
            }

            return movies;
        }

        public List<MovieDetail> GetMovies()
        {
            return _movies;
        }

    }
}