using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;

namespace My.Demo.Data
{
    public class Movie
    {
        public Movie()
        {
            this.Language = Language.English;
            this.Year = DateTime.Today.Year;
        }

        public Movie(string title, int year = 2000) : this()
        {
            this.Title = title;
            this.Year = year;
        }
        public int Id { get; set; }
        [Required, MaxLength(255)]
        public string Title { get; set; }
        [Required, Range(1900, 2020)]
        public int Year { get; set; }
        [Required]
        public Genre Genre { get; set; }
        [Required]
        public Language Language { get; set; }
        public IEnumerable<MoviePrincipal> Principals { get; set; }
    }
}
