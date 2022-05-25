using System;
using System.Windows.Forms;
using LibraryManagement.Views.Login;
using LibraryManagement.Views.Main;
using LibraryManagement.Views.Layout;
using LibraryManagement.Views.Books;
using LibraryManagement.Views.Books.Dialog;
using LibraryManagement.Models;
using LibraryManagement.Repositories;
using LibraryManagement.Views.Dashboard;
using LibraryManagement.Views.Category;
using LibraryManagement.Views.Author;
using LibraryManagement.Views.Author.Dialog;
using LibraryManagement.Views.Librarian;
using LibraryManagement.Views.Category.Dialog;
using LibraryManagement.Views.Setting;
using LibraryManagement.Views.Library_Preferent;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using ReportService.Presenters;
using ReportService;
using System.Collections.Generic;

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
            _mainview.ShowMenuBar += ShowMenuBar;
        }

        private void ShowMenuBar(object sender, EventArgs e)
        {
            _sideBar.Visible((sender as ToolStripMenuItem).Checked);
        }

        private void ShowBorrowBook(object sender, EventArgs e)
        {

            ReportDocument report = new ReportDocument();
            DataTable table_report;
            DataTable table_header;
            IBorrowBookRepository borrowbook_repository = new BorrowBookRepository(connectionString);
            IAuthRepository auth_repository = new AuthRepository(connectionString);
            IPrintFormView printFormView = PrintFormView.GetInstace((Form)_mainview);
            try
            {
                table_report = borrowbook_repository.GetReprot(new string[] { "1" , "2"});
                table_report.WriteXml("Reporting/VIEW_BORROW_BOOK.xml", XmlWriteMode.WriteSchema);

                table_header = auth_repository.GetPreference();
                table_header.WriteXml("Reporting/REPORT_HEADER.xml", XmlWriteMode.WriteSchema);

                report.Load("Reporting/LibraryReprot.rpt");
                report.Database.Tables[0].SetDataSource(table_report);
                printFormView.reprotDocument = report;
                printFormView.Refresh();
                printFormView.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowLibrarian(object sender, EventArgs e)
        {
            ILibrarianView librarianview = LibrarianView.GetInstace((Form)_mainview);
            ILibrarianRepository repository = new LibrarianRepository(connectionString);
            librarianview.Show();
            LibrarianPrecenter.GetInstance(librarianview, repository);
        }

        private void SetUp(object sender, EventArgs e)
        {
            ILoginView loginview = LoginView.GetInstance();
            IAuthRepository repository = new AuthRepository(connectionString);
            _dashboard = DashboardView.GetInstace(_mainview as Form);

            LoginPresenter.GetInstance(loginview, repository);
            (loginview as Form).ShowDialog((Form)_mainview);

            if (loginview.LoginSuccess)
            {
                _mainview.IitialComponent();
                var preference = repository.GetPreference();
                //_dashboard.SetPreference((LibraryModel) repository.GetPreference());
                _mainview.FormTitle = preference.Rows[0][1].ToString();
                _dashboard.Company_name = preference.Rows[0][1].ToString();
                _dashboard.Company_address = preference.Rows[0][2].ToString();
                _dashboard.Company_website = preference.Rows[0][3].ToString();
                _dashboard.Company_email = preference.Rows[0][4].ToString();
                SubScriptEvent();
            }
        }

        private void SubScriptEvent()
        {
            _dashboard = DashboardView.GetInstace((Form)_mainview);
            _dashboard.Show();

            _dashboard.ShowBooks += ShowBook;
            _dashboard.ShowAuthor += ShowAuthor;

            _sideBar.ShowDahsBoard += ShowDashboard;
            _sideBar.ShowBooks += ShowBook;
            _sideBar.ShowAuthor += ShowAuthor;
            _sideBar.ShowCategory += ShowCategory;
            _sideBar.ShowLibrarian += ShowLibrarian;
            _sideBar.ShowBorrowBook += ShowBorrowBook;
            _sideBar.ShowSetting += ShowSetting;

            _mainview.ShowPreference += ShowPreference;
        }

        private void ShowPreference(object sender, EventArgs e)
        {
            ILiraryPreferentView libraryview = LiraryPreferentView.GetInstnace();
            PreferencePresenter.GetInstance(libraryview, connectionString);
            libraryview.Show((Form)_mainview);
        }

        private void ShowSetting(object sender, EventArgs e)
        {
            ISettingView settingview = SettingView.GetInstance((Form)_mainview);
            settingview.Show();
        }

        private void ShowAuthor(object sender, EventArgs e)
        {
            IAuthorView authorview = AuthorView.GetInstace((Form)_mainview);
            IAuthorRepository authorRepository = AuthorRepository.GetInstance(connectionString);
            IAuthorDialog authordialog = AuthorDialog.GetInstance();
            authorview.Show();
            AuthorPresenter.GetInstance(authorview, authordialog, authorRepository);
        }

        private void ShowBook(object sender, EventArgs e)
        {
            IBookView bookview = BookView.GetInstace((Form)_mainview);
            IBookDailog dailog = BookDialogView.GetInstance();

            ICategoryRepository categoryRepository = CategoryRepository.GetInstance(connectionString);
            IBookRepository repository = new BookRepository(connectionString);
            bookview.Show();
            BookPresenter.GetInstance(bookview,dailog,repository, categoryRepository);
        }

        private void ShowDashboard(object sender, EventArgs e)
        {
            _dashboard = DashboardView.GetInstace((Form)_mainview);
            _dashboard.Show();
        }

        private void ShowCategory(object sender, EventArgs e)
        {
            ICategoryView catview = CategoryView.GetInstace((Form)_mainview);
            ICategoryRepository categoryRepository = CategoryRepository.GetInstance(connectionString);
            ICategoryDialog dialog = CategoryDilogView.GetInstance();
            catview.Show();
            CategoryPresenter.GetInstance(catview, dialog, categoryRepository);
        }
    }
}
