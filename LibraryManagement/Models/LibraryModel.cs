using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class LibraryModel
    {
        private int id;
        private string name;
        private string website;
        private string phone;
        private string email;
        private Byte logo;

        [DisplayName("ID")]
        [Required(ErrorMessage = "ID is requerid")]
        public int Id { 
            get => id; 
            set => id = value; 
        }

        [DisplayName("Library Name")]
        [Required(ErrorMessage = "Library name is requerid")]
        public string Name { 
            get => name; 
            set => name = value; 
        }

        public string Website { 
            get => website; 
            set => website = value; 
        }
        public string Phone { 
            get => phone; 
            set => phone = value; 
        }
        public string Email { 
            get => email; 
            set => email = value; 
        }
        public byte Logo { 
            get => logo; 
            set => logo = value; 
        }
    }
}
