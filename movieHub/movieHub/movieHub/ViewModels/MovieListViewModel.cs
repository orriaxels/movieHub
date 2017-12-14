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

namespace movieHub.Views.ListView
{
    public class MovieListViewModel : INotifyPropertyChanged
    {
        private INavigation _navigation;
        private MovieService _api;
        private List<MovieDetail> _movieListFromApi;
        public List<MovieDetail> _topRatedList;

        public MovieListViewModel(INavigation navigation, MovieService api)
        {
            _navigation = navigation;
            _api = api;
            _movieListFromApi = _api.GetMovies();
            _topRatedList = _api.GetMovies();
            FetchList(this._movieListFromApi);            
        }

        public List<MovieDetail> _movieList
        {
            get => _movieListFromApi;
        }

        public List<MovieDetail> _topList
        {
            get => _topRatedList;
        }

        private async void FetchList(List<MovieDetail> movies)
        {
            foreach(MovieDetail movie in movies)
            {
                movie.role = await _api.GetActorsAndRoles(movie);
            }
        }

        public async void FetchTopRated()
        {
            await _api.getTopRatedMovies();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
