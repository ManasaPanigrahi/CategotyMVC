using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CategotyMVC.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }
        
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        
        
    }
}
