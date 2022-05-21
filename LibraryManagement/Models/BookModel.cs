using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LibraryManagement.Models
{
    public class BookModel
    {
        private int id;
        private string title;
        private int page;
        private DateTime publisdate;
        private string publisher;
        private int category_id;
        private string category_name;
        private string category_description;

        [DisplayName("ID")]
        public int Id { get => id; set => id = value; }

        [DisplayName("TITLE")]
        [Required(ErrorMessage = "Title is requerid")]
        public string Title { get => title; set => title = value; }

        [DisplayName("PAGE")]
        public int Page { get => page; set => page = value; }

        [DisplayName("PUBLISH DATE")]
        public DateTime Publisdate { get => publisdate; set => publisdate = value; }

        [DisplayName("PUBLISHER")]
        public string Publisher { get => publisher; set => publisher = value; }

        [DisplayName("CATEGORY ID")]
        [Required(ErrorMessage = "Categoty is requerid")]
        public int Category_id { get => category_id; set => category_id = value; }

        [DisplayName("CATEGORY")]
        public string Category_name { get => category_name; set => category_name = value; }

        [DisplayName("CATEGORY DESCRIPTION")]
        public string Category_description { get => category_description; set => category_description = value; }
    }
}
