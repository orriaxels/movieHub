using movieHub.Views.ListView;
using MovieHub.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace movieHub
{
    class Tabbed : TabbedPage
     {
        MovieService _api;
        MovieListViewModel _movieListViewModel;
        public Tabbed(MovieService api)
        {
            _api = api;
            _movieListViewModel = new MovieListViewModel(this.Navigation, _api, null);            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _movieListViewModel.FetchTopRated();
        }
    }
}
