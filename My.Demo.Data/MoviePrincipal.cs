using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace My.Demo.Data
{
    public class MoviePrincipal
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int PersonId { get; set; }
        //public Movie Movie { get; set; }
        //public Person Principal { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
