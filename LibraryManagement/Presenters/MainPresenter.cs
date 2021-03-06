using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManagement.Views.Login;
using LibraryManagement.Views.Main;
using LibraryManagement.Views.Layout;
using LibraryManagement.Views.Books;
using LibraryManagement.Views.Books.Dialog;
using LibraryManagement.Models;
using LibraryManagement.Repositories;
using LibraryManagement.Views.Dashboard;

namespace LibraryManagement.Presenters
{
    class MainPresenter
    {
        private readonly string connectionString;
        private IMainView _mainview;
        private ISideBarMenu _sideBar;
        private IDashboardView _dashboard;

        public IBookDailog BookDialog { get; private set; }

        public MainPresenter(IMainView mainview, ISideBarMenu sideBar,string connectionString)
        {
            _mainview = mainview;
            _sideBar = sideBar;
            this.connectionString = connectionString;
            _mainview.SetUp += SetUp;
            _sideBar.ShowDahsBoard += ShowDashboard;
            _sideBar.ShowBooks += ShowBook;
            _sideBar.ShowAuthor += ShowAuthor;
        }

        private void SetUp(object sender, EventArgs e)
        {
            ILoginView loginview = LoginView.GetInstance();
            IAuthRepository repository = new AuthRepository(connectionString);

            LoginPresenter.GetInstance(loginview, repository);
            (loginview as Form).ShowDialog((Form)_mainview);

            if (loginview.LoginSuccess)
            {
                _mainview.IitialComponent();

                SubScriptEvent();
            }
        }

        private void SubScriptEvent()
        {
            _dashboard = DashboardView.GetInstace((Form)_mainview);
            _dashboard.Show();

            _dashboard.ShowBooks += ShowBook;
            _dashboard.ShowAuthor += ShowAuthor;
        }


        private void ShowAuthor(object sender, EventArgs e)
        {
            MessageBox.Show("We are still working on it.");
        }

        private void ShowBook(object sender, EventArgs e)
        {
            IBookView bookview = BookView.GetInstace((Form)_mainview);
            IBookDailog dailog = BookDialogView.GetInstance();

            IBookRepository repository = new BookRepository(connectionString);
            ICategoryRepository categoryRepository = CategoryRepository.GetInstance(connectionString);

            BookPresenter.GetInstance(bookview,dailog,repository, categoryRepository);
            bookview.Show();
        }

        private void ShowDashboard(object sender, EventArgs e)
        {
            _dashboard = DashboardView.GetInstace((Form)_mainview);
            _dashboard.Show();
        }
    }
}
