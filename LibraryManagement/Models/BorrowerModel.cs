using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class BorrowerModel
    {
        private int id;
        private string name;
        private string gender;
        private DateTime dob;
        private string address;
        private string phone;
        private string email;

        [DisplayName("ID")]
        [Required(ErrorMessage = "Id is requerid")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DisplayName("NAME")]
        [Required(ErrorMessage = "Name is requerid")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DisplayName("GENDER")]
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        [DisplayName("DATE OF BIRTH")]
        public DateTime Dob
        {
            get { return dob; }
            set { dob = value; }
        }

        [DisplayName("ADDRESS")]
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        [DisplayName("PHONE")]
        [Required(ErrorMessage = "Phone is requerid")]
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        [DisplayName("EMAIL")]
        [EmailAddress(ErrorMessage = "An email address must be containa single @")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}
