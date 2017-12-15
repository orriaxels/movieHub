using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MovieHub.Models
{
    public class MovieDetail : INotifyPropertyChanged
    {
        public int id { get; set; }
        public String title { get; set; }
        public String imageUrl { get; set; }
        public String releaseDate { get; set; }
        public List<String> actors { get; set; }
        public String genres { get; set; }
        public List<String> characters { get; set; }
        public String director { get; set; }
        public List<String> writers { get; set; }
        public List<Cast> cast { get; set; }
        public String posterFilePath { get; set; }
        public String description { get; set; }
        public double voteAverage { get; set; }
        public int voteCount { get; set; }
        public String runtime { get; set; }
        public String tagLine { get; set; }
        public String budget { get; set; }
        private string actorsAndRoles;
        public String backDrop { get; set; }

        public String role
        {
            get => actorsAndRoles;

            set
            {
                this.actorsAndRoles = value;
                OnPropertyChanged();
            }
        }

        public String overView
        {
            get => description;

            set
            {
                this.description = value;
                OnPropertyChanged();
            }
        }

        public String runLength
        {
            get => runtime;

            set
            {
                this.runtime = value;
                OnPropertyChanged();
            }
        }

        public String tag
        {
            get => tagLine;

            set
            {
                this.tagLine = value;
                OnPropertyChanged();
            }
        }

        public String cashMoney
        {
            get => budget;

            set
            {
                this.budget = value;
                OnPropertyChanged();
            }
        }

        public String allGenres
        {
            get => genres;

            set
            {
                this.genres = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}