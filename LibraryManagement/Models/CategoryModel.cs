using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class CategoryModel
    {
        private int id;
        private string name;
        private string description;

        [DisplayName("CATEGORY ID")]
        [Required(ErrorMessage = "Categoty id is requerid")]
        public int Id { 
            get => id;
            set => id = value; 
        }

        [DisplayName("CATEGORY NAME")]
        [Required(ErrorMessage = "Categoty name is requerid")]
        public string Name { 
            get => name; 
            set => name = value; 
        }

        public string Description { 
            get => description; 
            set => description = value; 
        }
    }
}
