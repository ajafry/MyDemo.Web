using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace My.Demo.Data
{
    public class Principal
    {
        public Principal()
        {

        }

        public Principal(string name)
        {
            this.Name = name;
        }
        public int Id { get; set; }
        [Required, MaxLength(255)]
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        IEnumerable<MoviePrincipal> Movies { get; set; }
    }
}
