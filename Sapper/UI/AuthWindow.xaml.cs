using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Security.Cryptography;

namespace Sapper.UI
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        private DispatcherTimer timer;

        private string _authLog { get; set; }
        private string _authPass { get; set; }

        public AuthWindow()
        {
            InitializeComponent();         
        }
     
        private void timer_Tick(object sender, EventArgs e)
        {
            TextLogin.Text = "Логин:";
            TextLogin.Foreground = Brushes.Black;        
        }

        private bool check_params()
        {
            if (_authLog != null || _authPass != null)
            {
                return true;
            }
            else
            {
                TextLogin.Text = "Не все поля заполнены!";
                TextLogin.Foreground = Brushes.Red;
                
                timer = new DispatcherTimer();
                timer.Tick += new EventHandler(timer_Tick);
                timer.Interval = new TimeSpan(0, 0, 3);
                timer.Start();
                return false;
            }
        }

        private void submitLogin_Click(object sender, RoutedEventArgs e)
        {
            if (check_params())
            {
                //some logic with http class
                Close();
            }
            else
            {
                _authLog = null;
                _authPass = null;
                return;
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void siteRedirect_Click(object sender, RoutedEventArgs e)
        {

        }

        private void regWindowOpen_Click(object sender, RoutedEventArgs e)
        {

        }

        private void login_TextChanged(object sender, RoutedEventArgs e)
        {
            TextBox log = (TextBox)sender;
            _authLog = log.Text;
        
            //_logdata = log.ToString();     
        }

        private void password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox pass = (PasswordBox)sender;
            string nonHash = pass.Password;
            if (nonHash.Equals(""))
            {
                _authPass = null;
            }
            else
            {
                string hash = ComputeMD5(nonHash);
                _authPass = hash;
            }            
        }

        private string ComputeMD5(string pass)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] checkSum = md5.ComputeHash(Encoding.UTF8.GetBytes(pass));
            string result = BitConverter.ToString(checkSum).Replace("-", String.Empty);
            return result;
        }
    }
}
