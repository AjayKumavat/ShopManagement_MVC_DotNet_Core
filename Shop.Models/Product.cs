using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Product : BaseEntity
    {
        [Display(Name="Product Name")]
        public string Name { get; set; }
    }
}
