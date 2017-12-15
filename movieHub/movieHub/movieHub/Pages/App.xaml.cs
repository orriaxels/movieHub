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
        private TopRatedPage _topRatedPage;
        
        public App()
        {
            InitializeComponent();
            _api = new MovieService();
            _topRatedPage = new TopRatedPage(_api);
            var mainPage = new MainPage(_api);
            
            var popularMoviesPage = new PopularMoviesPage();            

            var tabbedPage = new Tabbed(_api, mainPage, _topRatedPage, popularMoviesPage);
                        
            
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
