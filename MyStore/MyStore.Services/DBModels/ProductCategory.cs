using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyStore.Services.DBModels
{
    public class ProductCategory
    {
        public int ID { get; set; }
        [Display(Name = "Category Name")]
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
