using MovieHub.Models;
using MovieHub.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using movieHub.Views.ListView;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace movieHub
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private MovieService _api;
        private List<MovieDetail> _movieList;
        private MovieListViewModel _movieListViewModel;
        public MainPage(MovieService api)
        {
            _api = api;
            _movieListViewModel = new MovieListViewModel(this.Navigation, _api, null);
            this.BindingContext = this._movieListViewModel;
            _movieList = new List<MovieDetail>();
            InitializeComponent();
        }

        
        private async void SearchButton_OnClicked(object sender, EventArgs e)
        {
            ActInd.IsRunning = true;
            this._movieList = await _api.GetMovieByTitle(searchBar.Text);
            ActInd.IsRunning = false;
            this.FetchList();
            listView.ItemsSource = movies;
        }

        public List<MovieDetail> movies
        {
            get => _movieList;

            set
            {
                this._movieList = value;
                OnPropertyChanged();
            }
        }

        public async void FetchList()
        {
            foreach (MovieDetail movie in this._movieList)
            {
                movie.role = await _api.GetActorsAndRoles(movie);
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (this._movieListViewModel.SelectedMovie != null)
            {
                listView.SelectedItem = null;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
