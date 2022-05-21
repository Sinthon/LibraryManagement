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
using LibraryManagement.Views.Category;
using LibraryManagement.Views.Author;
using LibraryManagement.Views.Author.Dialog;
using LibraryManagement.Views.Librarian;
using LibraryManagement.Views.Category.Dialog;
using ReportService.Presenters;
using LibraryManagement.Views.Setting;
using ReportService;
using CrystalDecisions.CrystalReports.Engine;

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
        }

        private void ShowBorrowBook(object sender, EventArgs e)
        {
            ReportDocument report = new ReportDocument();
            report.Load("Reporting/CrystalReport1.rpt");
            IPrintFormView printFormView = PrintFormView.GetInstace((Form)_mainview);
            printFormView.reprotDocument = report;
            printFormView.Show();

            //dtCompany = CSQBPreferences.GetPreference();
            //dsReport.Tables.Add(CSQBTransferInventories.GetVTransferInventory(txnid, templatefile));
            ////dsReport.Tables.Add(CSQBPrintFormOptions.GetPrintFormOption(eventtype, ""));
            //dtCompany.TableName = "ReportHeader";
            //dsReport.Tables[0].TableName = "VTransferInventory";
            ////dsReport.Tables[1].TableName = "PrintOption";
            //dtCompany.WriteXml(Path.GetDirectoryName(templatefile) + "\\ReportHeader.xml", XmlWriteMode.WriteSchema);
            //dsReport.WriteXml(Path.GetDirectoryName(templatefile) + "\\TransferInventory.xml", XmlWriteMode.WriteSchema);
            //report.Load(templatefile);
            //printFormView.Show();
            //PrintFormPresenter.GetInstance();
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

            _sideBar.ShowDahsBoard += ShowDashboard;
            _sideBar.ShowBooks += ShowBook;
            _sideBar.ShowAuthor += ShowAuthor;
            _sideBar.ShowCategory += ShowCategory;
            _sideBar.ShowLibrarian += ShowLibrarian;
            _sideBar.ShowBorrowBook += ShowBorrowBook;
            _sideBar.ShowSetting += ShowSetting;
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
