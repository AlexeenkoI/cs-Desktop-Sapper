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
namespace Sapper
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

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
             Http.AuthRequest(log, pass);

            AuthData data =Task.FromResult<AuthData>(Http.AuthRequest(log, pass));

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
