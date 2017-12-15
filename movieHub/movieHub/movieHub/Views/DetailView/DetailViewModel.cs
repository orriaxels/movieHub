using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MovieHub.Models;
using MovieHub.Services;

namespace movieHub.Views.DetailView
{
    public class DetailViewModel : INotifyPropertyChanged 
    {
        private MovieDetail _movie;
        private MovieService _api;

        public DetailViewModel(MovieDetail movie, MovieService api)
        {
            this._movie = movie;
            this._api = api;

        }

        public MovieDetail Movie
        {
            get => _movie;

            set
            {
                this._movie = value;
                OnPropertyChanged();
            }
        }

        public async void FetchMovieDetail()
        {
            var fetchedMovie = await _api.GetMovieDetail(this._movie.id);
           
            _movie.runLength = fetchedMovie.runtime;
            _movie.tag = fetchedMovie.tagLine;
            _movie.cashMoney = fetchedMovie.budget;
            _movie.allGenres = fetchedMovie.genres;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
