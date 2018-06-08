using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPIGameTable.Models
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }

        [Required]
        public string Name { get; set; }
        public string ReleaseYear { get; set; }

        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
        public int GenreId { get; set; }

        [ForeignKey("RatingId")]
        public Rating Rating { get; set; }
        public int RatingId { get; set; }
    }
}