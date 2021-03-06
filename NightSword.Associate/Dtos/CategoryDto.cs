﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NightSword.Associate.Dtos
{
    public class CategoryDto:BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }      
        public int Sorting { get; set; }
    }
}
