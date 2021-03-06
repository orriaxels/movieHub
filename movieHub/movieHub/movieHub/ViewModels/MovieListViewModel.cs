﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MovieHub.Models;
using MovieHub.Services;
using movieHub.Views.DetailView;

namespace movieHub.Views.ListView
{
    public class MovieListViewModel : INotifyPropertyChanged
    {
        private INavigation _navigation;
        private MovieService _api;
        private List<MovieDetail> _movieListFromApi;
        private List<MovieDetail> _topRatedList;
        private List<MovieDetail> _popularList;

        private MovieDetail _movie;
        private String _searchText;

        public MovieListViewModel(INavigation navigation, MovieService api, string searchText)
        {                                               
            this._navigation = navigation;
            this._api = api;
            this._searchText = searchText;
            this._movieListFromApi = _api.GetMovies();
            this._topRatedList = new List<MovieDetail>();
            this._popularList = new List<MovieDetail>();

        }

        public List<MovieDetail> _movieList
        {
            get => _movieListFromApi;

            set
            {
                this._movieListFromApi = value;
                OnPropertyChanged();
            }
        }

        public string searchTitle
        {
            get => "Results for \"" + this._searchText + "\"";
        }

        public List<MovieDetail> topList
        {
            get => _topRatedList;

            set
            {
                this._topRatedList = value;
                OnPropertyChanged();
            }
        }

        public List<MovieDetail> popList
        {
            get => _popularList;

            set
            {
                this._popularList = value;
                OnPropertyChanged();              
            }
        }

        public async void FetchList()
        {
            foreach(MovieDetail movie in this._movieListFromApi)
            {
                movie.role = await _api.GetActorsAndRoles(movie);
            }
        }

        public async void FetchTopRated()
        {
            topList = await _api.GetTopRatedMovies();
            foreach(MovieDetail movie in this.topList)
            {
                movie.role = await _api.GetActorsAndRoles(movie);
            }
        }

        public async void FetchPopularMovies()
        {
            popList = await _api.GetPopularMovies();
            foreach (MovieDetail movie in this.popList)
            {
                movie.role = await _api.GetActorsAndRoles(movie);
            }
        }

        public MovieDetail SelectedMovie
        {
            get => this._movie;

            set
            {
                if (value != null)
                {
                    this._movie = value;
                    this._navigation.PushAsync(new Detail(this._movie, this._api), true);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
