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

        public MovieList()
        {
            InitializeComponent();
        }

        public MovieList(MovieService api)
        {
            this._api = api;

            this.BindingContext = new MovieListViewModel(this.Navigation, _api);
            
            InitializeComponent();
        }
    }
}
