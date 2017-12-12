using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MovieHub.Models;
using MovieHub.Services;
using MovieHub.MovieService.Models;

namespace movieHub.Views.ListView
{
    public class MovieListViewModel : INotifyPropertyChanged
    {
        private INavigation _navigation;
        private MovieService _api;
        List<MovieListModel> _movieListModel;

        public MovieListViewModel(INavigation navigation, MovieService api)
        {
            _navigation = navigation;
            _api = api;
            _movieListModel = new List<MovieListModel>();
        }

        public List<MovieListModel> _movieList
        {
            get => GetList();
        }

        private List<MovieListModel> GetList()
        {
            var list = _api.GetMovies();

            foreach(MovieDetail movie in list)
            {
                _movieListModel.Add(new MovieListModel
                {
                    title = movie.title,
                    year = "(" + movie.releaseDate.Year.ToString() + ")",
                    posterPath = movie.imageUrl,
                    actors = movie.actors
                });

                //_movieListModel.Add(newMovie);

            }

            OnPropertyChanged();
            return _movieListModel;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
