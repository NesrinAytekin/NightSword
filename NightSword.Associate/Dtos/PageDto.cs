using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NightSword.Associate.Dtos
{
    public class PageDto:BaseDto
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }     
        public int Sorting { get; set; }
    }
}
