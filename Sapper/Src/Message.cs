using Sapper.Enums;
using System.Windows;

namespace Sapper.Src
{
    public static class Message
    {
        public static void show (int value)
        {
            Messages msg = (Messages)value;

            switch(msg)
            {                
                case Messages.AUTH_DATA_ERROR:
                    MessageBox.Show("Пароль или Логин введен неверно.");
                    break;
                case Messages.ERROR_CONNECTION_SERVER:
                    MessageBox.Show("Ошибка соединения с сервером.");
                    break;
            }
        }    
    }
}
