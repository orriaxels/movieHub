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
        private PopularMoviesPage _mostPopularPage;
        

        public Tabbed(MovieService api, MainPage main, TopRatedPage topRated, PopularMoviesPage mostPopular)
        {
            _api = api;
            _mainPage = main;
            _topRatedPage = topRated;           
            _mostPopularPage = mostPopular;
            addChildren();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            _mostPopularPage._movieListViewModel.FetchPopularMovies();
            _topRatedPage._movieListViewModel.FetchTopRated();

        }

        private void addChildren()
        {
            this.Children.Add(setMainPage());
            this.Children.Add(setTopRatedPage());
            this.Children.Add(setMostPopularPage());
        }

        private NavigationPage setMainPage()
        {
            var page = new NavigationPage(this._mainPage);
            page.Title = "Search";
                       
            
            return page;
        }

        private NavigationPage setTopRatedPage()
        {
            var page = new NavigationPage(this._topRatedPage);
            page.Title = "Top Rated";            

            return page;
        }

        private NavigationPage setMostPopularPage()
        {
            var page = new NavigationPage(this._mostPopularPage);
            page.Title = "Popular";

            return page;
        }
    }
}
