using MovieHub.Models;
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
<<<<<<< HEAD
            if(this.MovieTitle.Text != "")
            {
                await _api.GetMovieByTitle(this.MovieTitle.Text);
                await this.Navigation.PushAsync(new MovieList(_api));    
            }
=======
            ActInd.IsRunning = true;
            await _api.GetMovieByTitle(this.MovieTitle.Text);
            await this.Navigation.PushAsync(new MovieList(_api));
            ActInd.IsRunning = false;
        }

        void OnButtonClicked(object sender, EventArgs args)
        {
            ActInd.Color = Color.Green;
>>>>>>> 09369c692ed5a9d6ee46cb9fb5f0da563118e726
        }


    }
}
