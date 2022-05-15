using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Presenters
{
    public class PrintFormPresenter
    {
        
        PrintFormPresenter()
        {

        }
        
        private static PrintFormPresenter instance;
        public static PrintFormPresenter GetInstance()
        {
            if (instance == null)
                instance = new PrintFormPresenter();
            return instance;
        }
    }
}
