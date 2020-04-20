using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace My.Demo.Data
{
    public class Movie
    {
        public Movie() { }
        public Movie(string title, int year = 2000)
        {
            this.Title = title;
            this.Year = year;
        }
        public int Id { get; set; }
        [Required, MaxLength(255)]
        public string Title { get; set; }
        [Required, Range(1900, 2020)]
        public int Year { get; set; }
        public IEnumerable<MoviePrincipal> Principals { get; set; }
    }
}
