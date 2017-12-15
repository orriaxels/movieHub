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
        private MovieService _api;
        private MainPage _mainPage;
        private TopRatedPage _topRatedPage;
        private PopularMoviesPage _popularMoviesPage;        
        
        public App()
        {
            InitializeComponent();

            _api = new MovieService();

            _mainPage = new MainPage(_api);
            _topRatedPage = new TopRatedPage(_api);
            _popularMoviesPage = new PopularMoviesPage(_api);

            var tabbedPage = new Tabbed(_api, _mainPage, _topRatedPage, _popularMoviesPage);

            MainPage = tabbedPage;
        }        

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
