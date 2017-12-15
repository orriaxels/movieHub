using movieHub.Pages;
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
        private MovieService _api;
        private MainPage _mainPage;
        private TopRatedPage _topRatedPage;
        private PopularMoviesPage _popularMoviesPage;

        public Tabbed(MovieService api, MainPage main, TopRatedPage topRated, PopularMoviesPage popularMovies)
        {
            _api = api;
            _mainPage = main;
            _topRatedPage = topRated;
            _popularMoviesPage = popularMovies;
            addChildren();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            _topRatedPage._movieListViewModel.FetchTopRated();
            _popularMoviesPage._movieListViewModel.FetchPopularMovies();

        }

        private void addChildren()
        {
            this.Children.Add(mainPage());            
            this.Children.Add(topRatedPage());
            this.Children.Add(popularMovies());
        }

        private NavigationPage mainPage()
        {
            var page = new NavigationPage(this._mainPage);
            page.Title = "Search";
                       
            return page;
        }

        private NavigationPage topRatedPage()
        {
            var page = new NavigationPage(this._topRatedPage);
            page.Title = "Top Rated";

            return page;
        }

        private NavigationPage popularMovies()
        {
            var page = new NavigationPage(this._popularMoviesPage);
            page.Title = "Popular";
            return page;
        }
    }
}
