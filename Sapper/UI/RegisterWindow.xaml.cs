using Sapper.Enums;
using Sapper.Src;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Sapper.UI
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void btn_register_Click(object sender, RoutedEventArgs e)
        {          
            if(isFormValide())
            {
                //Generate JSON string and send to server. (Message OK and Close).
            }                                       
        }

        private bool isFormValide ()
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
            Close();
        }
    }
}
