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
        AuthData _authData;
        public MainWindow()
        {
            InitializeComponent();

            this.Hide();
            AuthWindow authWindow = new AuthWindow();          
            authWindow.ShowDialog();

            if (authWindow.authData == null)
                Close();
            else
            {
                _authData = authWindow.authData;
                this.Show();
            }
        }        
    }
}
