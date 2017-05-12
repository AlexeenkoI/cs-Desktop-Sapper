using Sapper.Models;
using System.Windows;

namespace Sapper.UI
{
    /// <summary>
    /// Логика взаимодействия для ScoreWindow.xaml
    /// </summary>
    public partial class ScoreWindow : Window
    {
        public ScoreWindow(GameData data)
        {
            InitializeComponent();
            InitializeLables(data);              
        }

        private void InitializeLables(GameData data)
        {
            lb_gamelvl.Content = data.cGameLvl;
            lb_gameTime.Content = data.cGameTime;
            lb_gameScore.Content = data.cGameScore;
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            // 1 - Model 'GameData' Generate JSON string
            // 2 - JSON string to the server via HTTP POST 
                        
            Close();
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
