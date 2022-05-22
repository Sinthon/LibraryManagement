using LibraryManagement.Views.Library_Preferent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Presenters
{
    public class PreferencePresenter
    {
        private readonly string connectionString;
        ILiraryPreferentView _preferenceview;
        PreferencePresenter(ILiraryPreferentView _preferenceview, string connectionString)
        {
            this._preferenceview = _preferenceview;
            this.connectionString = connectionString;
        }

        private static PreferencePresenter instance;
        public static PreferencePresenter GetInstance(ILiraryPreferentView _preferenceview, string connectionString)
        {
            if (instance == null)
                instance = new PreferencePresenter(_preferenceview, connectionString);
            return instance;
        }
    }
}
