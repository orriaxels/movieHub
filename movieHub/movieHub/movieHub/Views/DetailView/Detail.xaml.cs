using System;
using System.Collections.Generic;
using MovieHub.Models;
using Xamarin.Forms;
using MovieHub.Services;

namespace movieHub.Views.DetailView
{
    public partial class Detail : ContentPage
    {
        private DetailViewModel _detailViewModel;
        private double _backdropHeight;
        public Detail(MovieDetail movie, MovieService api)
        {
            _detailViewModel = new DetailViewModel(movie, api);
            this.BindingContext = this._detailViewModel;
            InitializeComponent();

            //this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            Image backDrop = new Image()
            {
                Source = movie.backDrop,
                HorizontalOptions = LayoutOptions.StartAndExpand,
            };

            BoxView posterBorder = new BoxView()
            {
                Color = Color.White,
                HeightRequest = 246,
                WidthRequest = 166,

            };

            RelativeLayout relativeLayout = new RelativeLayout();

            Func<RelativeLayout, double> getBackDropImageHeight = (p) => backDrop.Measure(relativeLayout.Width, relativeLayout.Height).Request.Height;
            Func<RelativeLayout, double> getBackDropImageWidth= (p) => backDrop.Measure(relativeLayout.Width, relativeLayout.Height).Request.Width;

            relativeLayout.Children.Add(backDrop, Constraint.RelativeToParent((parent) => {
                return 0;
            }));

            relativeLayout.Children.Add(posterBorder,
                Constraint.RelativeToParent((parent) =>
                {
                    return 10;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                return getBackDropImageHeight(parent) - 30;
                })
            );

            Image posterImage = new Image()
            {
                Source = movie.imageUrl,
                HeightRequest = 240,
                WidthRequest = 160
            };

            relativeLayout.Children.Add(posterImage,
                Constraint.RelativeToParent((parent) =>
                {
                    return 13;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return getBackDropImageHeight(parent) - 27;
                })
            );
            
            this.Content = relativeLayout;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await this._detailViewModel.FetchMovieDetail();
        }
    }
}
