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

        public MovieListViewModel(INavigation navigation, MovieService api)
        {
            _navigation = navigation;
            _api = api;
            _movieListFromApi = _api.GetMovies();
            FetchList();
        }

        public List<MovieDetail> _movieList
        {
            get => _movieListFromApi;
        }

        private async void FetchList()
        {
            foreach(MovieDetail movie in this._movieListFromApi)
            {
                await _api.GetCreditList(movie);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
