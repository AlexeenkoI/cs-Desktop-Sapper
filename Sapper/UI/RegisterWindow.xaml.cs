using Sapper.Enums;
using Sapper.Models;
using Sapper.Src;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Sapper.UI
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public bool succsessReg = false;
        private RegData regData = new RegData();
        private DispatcherTimer timer;

        public RegisterWindow()
        {
            InitializeComponent();

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            tb_login.Text = "Login:";
            tb_login.Foreground = Brushes.Black;
        }

        private void btn_register_Click(object sender, RoutedEventArgs e)
        {
            if (isFormValide())
            {
                //MessageBox.Show(regData.Password);
                Reg(regData);
                //Generate JSON string and send to server. (Message OK and Close).
            }
        }

        private async void Reg(RegData regData)
        {
            succsessReg = await Http.RegRequest(regData);
            //to do progress bar
            if (succsessReg)
            {
                MessageBox.Show("Success");
                Close();
                Owner.Show();
            }
            else
            {
                tb_login.Text = "User already exsists";
                tb_login.Foreground = Brushes.Red;

                timer = new DispatcherTimer();
                timer.Tick += new EventHandler(timer_Tick);
                timer.Interval = new TimeSpan(0, 0, 3);
                timer.Start();
   
            }
        }

        private bool isFormValide()
        {
            if (string.IsNullOrWhiteSpace(tb_password.Password) ||
                string.IsNullOrWhiteSpace(tb_password_repeat.Password))
            {
                Message.show((int)Messages.EMPTY_PASSWORD);
                return false;
            }

            if (tb_password.Password != tb_password_repeat.Password)
            {
                Message.show((int)Messages.PASSWORDS_DO_NOT_MATCH);
                return false;
            }

            foreach (var textBox in control.Children.OfType<TextBox>())
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    Message.show(int.Parse(textBox.Tag.ToString()));
                    return false;
                }
            }

            return true;
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
            this.Owner.Show();
        }

        private void login_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox log = (TextBox)sender;
            regData.Name = log.Text;
        }

        private void password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox pass = (PasswordBox)sender;
            string nonHash = pass.Password;
            if (string.IsNullOrWhiteSpace(nonHash))
            {
                regData.Password = null;
            }
            else
            {
                string hash = ComputeMD5(nonHash);
                regData.Password = hash;
            }
        }

        private string ComputeMD5(string pass)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] checkSum = md5.ComputeHash(Encoding.UTF8.GetBytes(pass));
            string result = BitConverter.ToString(checkSum).Replace("-", String.Empty);
            return result;
        }

        private void nickName_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox log = (TextBox)sender;
            regData.Nickname = log.Text;
        }
    }
}
