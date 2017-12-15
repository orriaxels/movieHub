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
        private List<MovieDetail> _movieList;
        private MovieList _movieListView;
        private MovieListViewModel _movieListViewModel;
        public MainPage(MovieService api)
        {
            _api = api;            
            _movieListViewModel = new MovieListViewModel(this.Navigation, _api, null);
            this.BindingContext = this._movieListViewModel;

            InitializeComponent();
        }

        
        private async void SearchButton_OnClicked(object sender, EventArgs e)
        {
            ActInd.IsRunning = true;
            _movieList = await _api.GetMovieByTitle(searchBar.Text);
            _movieListView = new MovieList(_api, searchBar.Text);            
            ActInd.IsRunning = false;
            this._movieListViewModel.FetchList();
            listView.ItemsSource = _movieList;
        }        
    }
}
