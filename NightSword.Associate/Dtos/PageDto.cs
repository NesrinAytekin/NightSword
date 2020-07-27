using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NightSword.Associate.Dtos
{
    public class PageDto:BaseDto
    {
        [Required]
        public string Title { get; set; }
        public string Slug { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public int Sorting { get; set; }
    }
}
