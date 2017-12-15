using System;
using System.Collections.Generic;
using MovieHub.Models;
using Xamarin.Forms;
using MovieHub.Services;

namespace movieHub.Views.DetailView
{
    public partial class Detail : ContentPage
    {
        private DetailViewModel _detailViewModel;
        public Detail(MovieDetail movie, MovieService api)
        {
            _detailViewModel = new DetailViewModel(movie, api);
            this.BindingContext = this._detailViewModel;
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await this._detailViewModel.FetchMovieDetail();
        }
    }
}
