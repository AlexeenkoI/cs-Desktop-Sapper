using Sapper.Enums;
using Sapper.Models;
using Sapper.Src;
using System.Windows;

namespace Sapper.UI
{
    /// <summary>
    /// Логика взаимодействия для ScoreWindow.xaml
    /// </summary>
    public partial class ScoreWindow : Window
    {
        GameData gameData;
        public ScoreWindow(GameData data)
        {
            InitializeComponent();
            gameData = data;
            InitializeLables(gameData);              
        }

        private void InitializeLables(GameData data)
        {
            lb_gamelvl.Content = data.cGameLvl;
            lb_gameTime.Content = data.cGameTime;
            lb_gameScore.Content = data.cGameScore;
        }

        private async void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if(await Http.saveGameData(gameData))
            {
                Close();
            }
            else
            {
                /* TODO 
                 * 1 -> Insert data into database
                 * 2 -> Show Error Message
                */
                Close();
            }
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
