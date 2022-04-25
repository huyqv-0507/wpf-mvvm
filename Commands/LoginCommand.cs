using System;
using System.Windows;
using RequestModels = WpfAppLogin.Models.RequestModels;
using ResponseModels = WpfAppLogin.Models.ResponseModels;
using WpfAppLogin.Services;
using WpfAppLogin.ViewModels;

namespace WpfAppLogin.Commands
{
    public class LoginCommand : CommandBase
    {
        private AuthenticationService _authenticationService;
        private readonly LoginViewModel _loginViewModel;
        private string _commandName;
        public LoginCommand(LoginViewModel loginViewModel, string commandName)
        {
            _authenticationService = new AuthenticationService();
            _loginViewModel = loginViewModel;
            _commandName = commandName;
        }
        public override async void Execute(object parameter)
        {
            if (_commandName.Equals(nameof(LoginViewModel.LoginCommand)))
            {
                RequestModels.TokenModel requestTokenModel = new RequestModels.TokenModel()
                {
                    UserName = _loginViewModel.UserName,
                    Password = _loginViewModel.Password
                };
                ResponseModels.TokenModel responseTokenModel = await _authenticationService.GetToken(requestTokenModel);
                if (responseTokenModel.AccessToken != null)
                {
                    MessageBox.Show(responseTokenModel.AccessToken);
                } else
                {
                    MessageBox.Show("Đăng nhập thất bại");
                }
            }
        }
    }
}
