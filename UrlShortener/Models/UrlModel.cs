using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortener.Models
{
    public class UrlModel
    {
        [MaxLength(24, ErrorMessage = "A maximum length of the Custom URL field is 24.")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "The Custom URL field must be a mix of characters and numbers only.")]
        public string ShortUrl { get; set; }

        [MaxLength(1024, ErrorMessage = "A maximum length of the URL is 1024.")]
        [Required]
        [Url]
        public string Url { get; set; }

        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int Hits { get; set; }
    }
}
