using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class AuthorModel
    {
        private int id;
        private string name;
        private string nation;
        private string skill;

        [DisplayName("ID")]
        [Required(ErrorMessage = "ID is requerid")]
        public int Id { 
            get => id; 
            set => id = value; 
        }

        [DisplayName("NAME")]
        [Required(ErrorMessage = "NAME is requerid")]
        public string Name { 
            get => name; 
            set => name = value; 
        }

        [DisplayName("NATION")]
        public string Nation { 
            get => nation; 
            set => nation = value; 
        }

        [DisplayName("SKILL")]
        public string Skill { 
            get => skill; 
            set => skill = value; 
        }
    }
}
