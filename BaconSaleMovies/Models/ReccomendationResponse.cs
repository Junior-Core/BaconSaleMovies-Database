using System;
using System.ComponentModel.DataAnnotations;

namespace BaconSaleMovies.Models
{
    public class ReccomendationResponse
    {
        [Key]
        public int ReccomendationId { get; set; }

        [Required(ErrorMessage = "Please Enter Category Type")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Please Enter A Movie Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please Enter the Year Released")]
        public string Year { get; set; }

        [Required(ErrorMessage = "Please Enter Directors Name")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Please Enter the Movies Official Rating")]
        public string Rating { get; set; }

        public bool? Edited { get; set; }

        public string LentTo { get; set; }

        [StringLength(25)]
        public string Notes { get; set; }
    }
}
