using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Sapper.Src;
using Sapper.Interfaces;
using Sapper.Models;
using Sapper.UI;

namespace Sapper
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   
        public MainWindow()
        {                    
            InitializeComponent();
            Authorize();
        }

        private void Authorize ()
        {
            Hide();
            AuthWindow authWindow = new AuthWindow();
            authWindow.ShowDialog();

            if (authWindow.authData == null)
                Close();
            else
            {
                Auth.id = authWindow.authData.userId;
                Auth.name = authWindow.authData.nickName;
                Auth.token = authWindow.authData.Token;
                lb_nickName.Content = Auth.name;
                Show();
            }
        }
    }
}
