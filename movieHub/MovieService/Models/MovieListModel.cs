//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Runtime.CompilerServices;
//using System.Threading.Tasks;
//using MovieHub.Models;
//using Xamarin.Forms;
//using MovieHub.Services;

//namespace MovieHub.MovieService.Models
//{
//    public class MovieListModel : INotifyPropertyChanged
//    {
//        public String title { get; set; }
//        public String year { get; set; }
//        public String posterPath { get; set; }
//        public List<String> actors { get; set; }
//        public String searchString { get; set; }
//        public ImageSource ImageSource { get; set; }
//        public String actors2 { get; set; }

//        public  MovieListModel(MovieDetail movie)
//        {
//            this.title = movie.title;
//            this.year = "(" + movie.releaseDate.Year + ")";
//            this.actors = movie.actors;
//            FetchImage(movie.imageUrl);
//            FetchActors(movie);
//        }

//        public string actorList
//        {
//            get => this.actors2;

//            set
//            {
//                this.actors2 = value;
//                OnPropertyChanged();
//            }
//        }

//        public void FetchImage(string path)
//        {
//            this.ImageSource = new UriImageSource
//            {
//                Uri = new Uri("http://image.tmdb.org/t/p/original" + path),
//                CachingEnabled = true,
//                CacheValidity = new TimeSpan(5, 0, 0, 0)
//            };

//            //return source;
//        }

//        public void FetchActors(MovieDetail movie)
//        {
//            for (int i = 0; i < movie.actors.Count; i++)
//            {
//                if(i + 1 == movie.actors.Count)
//                {
//                    actors2 += movie.actors[i];
//                }
//                else
//                {
//                    actors2 += movie.actors[i] + ", ";    
//                }
//            }
//            OnPropertyChanged();
//        }

//        public event PropertyChangedEventHandler PropertyChanged;

//        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
//        {
//            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//        }
//    }
//}
