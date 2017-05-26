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


        public MainWindow()
        {



            //InitializeComponent();
            //RegData test = new RegData();
            //test.Name = "aaaaaassss";
            //test.Nickname = "bbb21312312";
            //test.Password = "123ggreg";
            //test.regTime = DateTime.Now;
            //
            //Http.RegRequest(test);

            string log = "Alex";
            string pass = "1234";


            //Task<AuthData> res = Http.AuthRequest(log, pass);
            //dateTask(log, pass);
            //Http.AuthRequest(log, pass);
            //AuthData d = dateTask(log, pass).Result;
            //string name = d.nickName;
            //int a = 1;
            //string t = "";
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


            //MessageBox.Show(d.nickName);


            //AuthData d = res.Result;

            //if (d != null)
            //{
            //    int id = d.userId;
            //    string nick = d.nickName;
            //    MessageBox.Show(id.ToString(), pass);
            //}else
            //{
            //    MessageBox.Show("NULL OBJECT");
            //}



        }



    }
}
