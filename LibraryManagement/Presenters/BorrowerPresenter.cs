using LibraryManagement.Models;
using LibraryManagement.Presenters.Commands;
using LibraryManagement.Views.BorrowBook.Dialog;
using LibraryManagement.Views.Borrower;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Presenters
{
    public class BorrowerPresenter
    {
        private ModelDataValidation validation;
        private IBorrowerView _view;
        private IBorrowerDialog _dialog;
        private IBorrowerRepository _repository;

        private BindingSource borrower_bindingsource;
        private IEnumerable<BorrowerModel> list;

        public BorrowerPresenter(IBorrowerView _view, IBorrowerDialog _dialog, IBorrowerRepository _repository)
        {
            borrower_bindingsource = new BindingSource();
            validation = new ModelDataValidation();

            this._view = _view;
            this._dialog = _dialog;
            this._repository = _repository;

            _view.Search += Search;

            SetUp();
            _view.SetListBindingSource(borrower_bindingsource);
        }

        private void SetUp()
        {
            try
            {
                list = _repository.GetAll();
                borrower_bindingsource.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ReloadList(object sender, EventArgs e)
        {
            try
            {
                list = _repository.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            borrower_bindingsource.DataSource = list;
        }

        private void Search(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.sValue);
            try
            {
                if (emptyValue == false)
                    list = _repository.GetByValue(_view.sValue);
                else
                    list = _repository.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            borrower_bindingsource.DataSource = list;
        }
    }
}
