using System;
using System.Collections.Generic;


namespace MovieHub.Models
{
    public class MovieDetail
    {
        public int id { get; set; }
        public String title { get; set; }
        public String imageUrl { get; set; }
        public DateTime releaseDate { get; set; }
        public List<String> actors { get; set; }
        public List<String> genres { get; set; }
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
        public int budget { get; set; }
    }
}