using System;
using System.Collections.Generic;
using MovieHub.Models;
using Xamarin.Forms;
using MovieHub.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace movieHub.Views.DetailView
{
    public partial class Detail : ContentPage
    {
        private DetailViewModel _detailViewModel;
        private MovieDetail _movie;
        private double _width;

        public Detail(MovieDetail movie, MovieService api)
        {
            this._movie = movie;
            _detailViewModel = new DetailViewModel(movie, api);
            this.BindingContext = this._detailViewModel;
            InitializeComponent();
       
            //BoxView posterBorder = new BoxView()
            //{
            //    Color = Color.White,
            //    HeightRequest = 246,
            //    WidthRequest = 166,

            //};

            //Image posterImage = new Image()
            //{
            //    Source = movie.imageUrl,
            //    HeightRequest = 240,
            //    WidthRequest = 160
            //};

            //Label rating = new Label()
            //{
            //    Text = "Rating: " + movie.voteAverage.ToString(),
            //    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
            //    TextColor = Color.FromHex("#555555"),
            //};

            //Label overView = new Label()
            //{
            //    Text = this._detailViewModel.Movie.overView,
            //    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
            //    WidthRequest = this._width
            //};


            //Label actors = new Label()
            //{
            //    Text = this._detailViewModel.Movie.role,
            //    FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
            //    WidthRequest = 200
            //};

            ////Label tag = new Label()
            ////{
            ////    Text = mov.tag,
            ////    FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
            ////    WidthRequest = 200
            ////};

            //Func<RelativeLayout, double> getBackDropImageHeight = (p) => this.backdropImage.Measure(this.detailLayout.Width, this.detailLayout.Height).Request.Height;
            //Func<RelativeLayout, double> getBackDropImageWidth= (p) => this.backdropImage.Measure(this.detailLayout.Width, this.detailLayout.Height).Request.Width;

            //this.detailLayout.Children.Add(posterBorder,
            //    Constraint.RelativeToParent((parent) =>
            //    {
            //        return 10;
            //    }),
            //    Constraint.RelativeToParent((parent) =>
            //    {
            //    return getBackDropImageHeight(parent) - 55;
            //    })
            //);

            //this.detailLayout.Children.Add(posterImage,
            //    Constraint.RelativeToParent((parent) =>
            //    {
            //        return 13;
            //    }),
            //    Constraint.RelativeToParent((parent) =>
            //    {
            //        return getBackDropImageHeight(parent) - 52;
            //    })
            //);

            //this.detailLayout.Children.Add(rating,
            //    Constraint.RelativeToParent((parent) =>
            //    {
            //        return 180;
            //    }),
            //    Constraint.RelativeToParent((parent) =>
            //    {
            //        return getBackDropImageHeight(parent) + 35;
            //    })
            //);

            //this.detailLayout.Children.Add(actors,
            //    Constraint.RelativeToParent((parent) =>
            //    {
            //        return 180;
            //    }),
            //    Constraint.RelativeToParent((parent) =>
            //    {
            //        return getBackDropImageHeight(parent) + 55;
            //    })
            //);

            //this.detailLayout.Children.Add(overView,
            //    Constraint.RelativeToParent((parent) =>
            //    {
            //        return 10;
            //    }),
            //    Constraint.RelativeToParent((parent) =>
            //    {
            //        return getBackDropImageHeight(parent) + 200;
            //    })
            //);

            ////this.detailLayout.Children.Add(tag,
            ////    Constraint.RelativeToParent((parent) =>
            ////    {
            ////        return 10;
            ////    }),
            ////    Constraint.RelativeToParent((parent) =>
            ////    {
            ////        return getBackDropImageHeight(parent) + 320;
            ////    })
            ////);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this._detailViewModel.FetchMovieDetail();
            this._width = this.Width;

            BoxView posterBorder = new BoxView()
            {
                Color = Color.White,
                HeightRequest = 246,
                WidthRequest = 166,

            };

            Image posterImage = new Image()
            {
                Source = _detailViewModel.Movie.imageUrl,
                HeightRequest = 240,
                WidthRequest = 160
            };

            Label rating = new Label()
            {
                Text = "Rating: " + _detailViewModel.Movie.voteAverage.ToString(),
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                TextColor = Color.FromHex("#555555"),
            };

            Label overView = new Label()
            {
                Text = this._detailViewModel.Movie.overView,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                WidthRequest = this._width - 10
            };


            Label actors = new Label()
            {
                Text = this._detailViewModel.Movie.role,
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                WidthRequest = 200
            };

            //Label tag = new Label()
            //{
            //    Text = mov.tag,
            //    FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
            //    WidthRequest = 200
            //};

            Func<RelativeLayout, double> getBackDropImageHeight = (p) => this.backdropImage.Measure(this.detailLayout.Width, this.detailLayout.Height).Request.Height;
            Func<RelativeLayout, double> getBackDropImageWidth = (p) => this.backdropImage.Measure(this.detailLayout.Width, this.detailLayout.Height).Request.Width;

            this.detailLayout.Children.Add(posterBorder,
                Constraint.RelativeToParent((parent) =>
                {
                    return 10;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return getBackDropImageHeight(parent) - 55;
                })
            );

            this.detailLayout.Children.Add(posterImage,
                Constraint.RelativeToParent((parent) =>
                {
                    return 13;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return getBackDropImageHeight(parent) - 52;
                })
            );

            this.detailLayout.Children.Add(rating,
                Constraint.RelativeToParent((parent) =>
                {
                    return 180;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return getBackDropImageHeight(parent) + 35;
                })
            );

            this.detailLayout.Children.Add(actors,
                Constraint.RelativeToParent((parent) =>
                {
                    return 180;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return getBackDropImageHeight(parent) + 55;
                })
            );

            this.detailLayout.Children.Add(overView,
                Constraint.RelativeToParent((parent) =>
                {
                    return 10;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return getBackDropImageHeight(parent) + 200;
                })
            );

            //this.detailLayout.Children.Add(tag,
            //    Constraint.RelativeToParent((parent) =>
            //    {
            //        return 10;
            //    }),
            //    Constraint.RelativeToParent((parent) =>
            //    {
            //        return getBackDropImageHeight(parent) + 320;
            //    })
            //);

            System.Diagnostics.Debug.WriteLine("height test: " + getBackDropImageHeight(this.detailLayout));
        }

    }
}
