using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManagement.Views.Login;
using LibraryManagement.Repositories;
using LibraryManagement.Models;
using LibraryManagement.Presenters.Commands;

namespace LibraryManagement.Presenters
{
    public class LoginPresenter 
    {
        private ILoginView _loginview;
        private IAuthRepository _repository;
        private ModelDataValidation validation;

        LoginPresenter(ILoginView loginview, IAuthRepository _repository)
        {
            _loginview = loginview;
            this._repository = _repository;
            Setup();
        }

        private void Setup()
        {
            validation = new ModelDataValidation();

            _loginview.ClickLogin += Login;
            _loginview.ClickExit += Exit;

            if (Properties.Settings.Default.RememberMe)
            {
                _loginview.Email = Properties.Settings.Default.Email;
                _loginview.Password = Properties.Settings.Default.Password;
            }
        }

        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login(object sender, EventArgs e)
        {
            var model = new AuthModel();
            model.Email = _loginview.Email;
            model.Password = _loginview.Password;
            try
            {
                validation.Validate(model);
                _repository.Login(model);
                _loginview.LoginSuccess = true;
                if (_loginview.RememberMe)
                {
                    Properties.Settings.Default.Email = _loginview.Email;
                    Properties.Settings.Default.Password = _loginview.Password;
                    Properties.Settings.Default.RememberMe = _loginview.RememberMe;
                    Properties.Settings.Default.Save();
                }
                _loginview.Hide();
            }
            catch (Exception ex)
            {
                _loginview.LoginSuccess = false;
                _loginview.ErrorMeaage = ex.Message;
            }
        }

        private static LoginPresenter instance;
        public static LoginPresenter GetInstance(ILoginView loginview, IAuthRepository _repository)
        {
            if (instance == null)
                instance = new LoginPresenter(loginview,_repository);
            return instance;
        }
    }
}
