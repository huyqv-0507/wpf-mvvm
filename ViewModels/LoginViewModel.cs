using System.Windows.Input;
using WpfAppLogin.Commands;

namespace WpfAppLogin.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { 
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public ICommand LoginCommand { 
            get
            {
                return new LoginCommand(this, nameof(LoginCommand));
            } 
        }
    }
}
