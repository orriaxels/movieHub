using movieHub.Pages;
using MovieHub.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace movieHub
{
    public partial class App : Application
    {
        MovieService _api = new MovieService();
        public App()
        {
            InitializeComponent();

            var mainPage = new MainPage(_api);
            var mainNavigationPage = new NavigationPage(mainPage);
            mainNavigationPage.Title = "Search";

            var topRatedPage = new TopRatedPage(_api);
            var topRatedNavigationPage = new NavigationPage(topRatedPage);
            topRatedNavigationPage.Title = "Top rated";

            var popularMoviesPage = new PopularMoviesPage();
            var popularMoviesNavigationPage = new NavigationPage(popularMoviesPage);
            popularMoviesNavigationPage.Title = "Popular";

            var tabbedPage = new Tabbed(_api);
            tabbedPage.Children.Add(topRatedNavigationPage);
            tabbedPage.Children.Add(mainNavigationPage);            
            tabbedPage.Children.Add(popularMoviesNavigationPage);
            
            MainPage = tabbedPage;
        }

        //private async void get()
        //{
        //    await _api.GetMovieByTitle("thor");
        //}

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
