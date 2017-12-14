using movieHub.Views.ListView;
using MovieHub.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace movieHub.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TopRatedPage : ContentPage
    {
        Tabbed _tabbed;
        MovieService _api;

        public TopRatedPage()
        {
            InitializeComponent();
        }

        public TopRatedPage(MovieService api)
        {
            _api = api;
            _tabbed = new Tabbed(_api);
          //  this.BindingContext = new MovieListViewModel(this.Navigation, _api);

            InitializeComponent();
        }
    }
}