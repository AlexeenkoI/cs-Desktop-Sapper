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
        private AuthData _authData;
        Rectangle re = new Rectangle();
        Border bo = new Border();
       
        public MainWindow()
        {
           
            
            InitializeComponent();
            bo.Height = 30;
            bo.Width = 30;
            //re.Stroke = Brushes.Gray;
            //re.Name = "FieldCell";
            
            bo.BorderBrush = Brushes.Black;
            bo.BorderThickness = new Thickness(2);
            bo.Background = Brushes.Silver;
            //MouseIn = Brushes.Black;
            //re.Fill = Brushes.Silver;
            bo.MouseEnter += mouse_in;
            bo.MouseLeave += mouse_leave;
            bo.MouseLeftButtonDown += mouse_down;

            mainGrid.Children.Add(bo);
            

            

            //this.Hide();
            //AuthWindow authWindow = new AuthWindow();
            //authWindow.ShowDialog();
            //
            //if (authWindow.authData == null)
            //    Close();
            //else
            //{
            //    _authData = authWindow.authData;
            //    this.Show();
            //}
        }

        private void mouse_in(object sender, EventArgs e)
        {
            Border eventedR = (Border)sender;
            eventedR.BorderBrush = Brushes.Black;
            
            
        }

        private void mouse_leave(object sender, EventArgs e)
        {
            Border eventedR = (Border)sender;
            eventedR.BorderBrush = Brushes.Gray;
        }

        private void mouse_down(object sender, EventArgs e)
        {
            Border eventedR = (Border)sender;
            //eventedR.Fill = Brushes.LightCoral;
            eventedR.BorderBrush = Brushes.Chocolate;
            eventedR.Background = Brushes.BlanchedAlmond;
            TextBlock t = new TextBlock();
            t.Text = "1";
            t.Margin = new Thickness(8, 4, 2, 2);
            eventedR.Child = t;
            

            bo.MouseEnter -= mouse_in;
            bo.MouseLeave -= mouse_leave;
            bo.MouseDown -= mouse_down;



        }
    }
}
