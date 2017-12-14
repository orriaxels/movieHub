using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieHub.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace movieHub.Views.ListView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieList : ContentPage
    {
        private MovieService _api;
        private MovieListViewModel _movieListViewModel;
        public MovieList(MovieService api, string searchText)
        {
            NavigationPage.SetBackButtonTitle(this, "Back");
            this._api = api;
            _movieListViewModel = new MovieListViewModel(this.Navigation, _api, searchText);
            this.BindingContext = this._movieListViewModel;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this._movieListViewModel.FetchList();            
        }
    }
}
