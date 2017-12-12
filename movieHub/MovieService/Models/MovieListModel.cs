using System;
using System.Collections.Generic;
using Xamarin.Forms;
namespace MovieHub.MovieService.Models
{
    public class MovieListModel
    {
        public String title { get; set; }
        public String year { get; set; }
        public String posterPath { get; set; }
        public List<String> actors { get; set; }
        public String searchString { get; set; }
        public ImageSource ImageSource => ImageSource.FromResource("http://image.tmdb.org/t/p/original" + this.posterPath);
    }
}
