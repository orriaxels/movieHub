using movieHub.Views.ListView;
using MovieHub.Models;
using MovieHub.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace movieHub.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TopRatedPage : ContentPage
    {
        private MovieService _api;
        private MovieListViewModel _movieListViewModel;
        private Tabbed _tabbed;

        public TopRatedPage(MovieService api)
        {            
            this._api = api;
            //this._tabbed = new Tabbed(_api);
            _movieListViewModel = new MovieListViewModel(this.Navigation, _api, "star wars");
            this.BindingContext = this._movieListViewModel;
            InitializeComponent();            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _movieListViewModel.FetchTopRated();
            //await _api.GetMovieByTitle("Thor");
            //await _api.getTopRatedMovies();
            //await this.Navigation.PushAsync(new MovieList(_api, "top rated"));
        }
    }
}