﻿using MovieHub.Models;
using MovieHub.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using movieHub.Views.ListView;

namespace movieHub
{
    public partial class MainPage : ContentPage
    {
        private MovieService _api;

        public MainPage(MovieService api)
        {
            _api = api;
            InitializeComponent();
        }

        private async void SearchButton_OnClicked(object sender, EventArgs e)
        {
            await _api.GetMovieByTitle(this.MovieTitle.Text);
            await this.Navigation.PushAsync(new MovieList(_api));
        }


    }
}
