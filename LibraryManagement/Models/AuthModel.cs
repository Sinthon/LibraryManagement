using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class AuthModel
    {
        private int id;
        private string name;
        private string gender;
        private DateTime dob;
        private string address;
        private string phone;
        private string email;
        private string password;
        private Byte photo;

        public int Id { get => Id; set => Id = value; }
        public string Name { get => name; set => name = value; }
        public string Gender { get => gender; set => gender = value; }
        public DateTime Dob { get => dob; set => dob = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }

        [Required(ErrorMessage = "Email is requerid")]
        [EmailAddress(ErrorMessage = "An email address must be containa single @")]
        public string Email { get => email; set => email = value; }

        [Required(ErrorMessage = "Password is requerid")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Password is too short (minimum is 6 charactera)")]
        public string Password { get => password; set => password = value; }
        public byte Photo { get => photo; set => photo = value; }
    }
}
