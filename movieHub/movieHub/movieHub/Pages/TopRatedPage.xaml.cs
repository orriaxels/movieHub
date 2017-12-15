using movieHub.Views.ListView;
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
        public readonly MovieListViewModel _movieListViewModel;

        public TopRatedPage(MovieService api)
        {            
            this._api = api;            
            _movieListViewModel = new MovieListViewModel(this.Navigation, _api, "Top Rated");
            this.BindingContext = this._movieListViewModel;

            InitializeComponent();            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if(this._movieListViewModel.SelectedMovie != null)
            {
                ListView.SelectedItem = null;
            }
           
        }
    }
}