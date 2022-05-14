using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class LibrarianModel
    {
        private int id;
        private string name;
        private string gender;
        private DateTime dob;
        private string address;
        private string phone;
        private byte photo;
        private string password;


        [DisplayName("ID")]
        [Required(ErrorMessage = "ID is requerid")]
        public int Id { 
            get => id; 
            set => id = value; 
        }

        [DisplayName("NAME")]
        [Required(ErrorMessage = "Name is requerid")]
        public string Name { 
            get => name; 
            set => name = value; 
        }

        [DisplayName("GENDER")]
        public string Gender { 
            get => gender; 
            set => gender = value; 
        }

        [DisplayName("DATE OF BIRTH")]
        public DateTime Dob { 
            get => dob; 
            set => dob = value; 
        }

        [DisplayName("ADDRESS")]
        public string Address { 
            get => address; 
            set => address = value; 
        }

        [DisplayName("PHONE")]
        public string Phone { 
            get => phone; 
            set => phone = value; 
        }

        [DisplayName("PHOTO")]
        public byte Photo { 
            get => photo; 
            set => photo = value; 
        }

        [DisplayName("PASSWORD")]
        public string Password { 
            get => password; 
            set => password = value; 
        }
    }
}
