﻿using System;
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

        public async Task FetchMovieDetail()
        {
            var fetchedMovie = await _api.GetMovieDetail(this._movie.id);
           
            _movie.runtime = fetchedMovie.runtime;
            _movie.description = fetchedMovie.description;
            _movie.tagLine = fetchedMovie.tagLine;
            _movie.budget = fetchedMovie.budget;
            _movie.genres = fetchedMovie.genres;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}