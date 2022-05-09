using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Presenters
{
    public class CategoryPresenter
    {
        CategoryPresenter()
        {

        }

        private static CategoryPresenter instance;
        public static CategoryPresenter GetInstance()
        {
            if(instance == null)
            {
                instance = new CategoryPresenter();
            }
            return instance;
        }
    }
}
