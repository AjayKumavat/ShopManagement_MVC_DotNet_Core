﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Category : BaseEntity
    {
        [Display(Name="Category Name")]
        public string Name { get; set; }
    }
}
