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
                    MessageBox.Show("Password or login is entered incorrectly");
                    break;
                case Messages.ERROR_CONNECTION_SERVER:
                    MessageBox.Show("Error connecting to server");
                    break;
                case Messages.PASSWORDS_DO_NOT_MATCH:
                    MessageBox.Show("Passwords do not match");
                    break;
                case Messages.EMPTY_LOGIN:
                    MessageBox.Show("Login field is empty");
                    break;
                case Messages.EMPTY_PASSWORD:
                    MessageBox.Show("Password field is empty");
                    break;
                case Messages.EMPTY_NAME:
                    MessageBox.Show("Name field is empty");
                    break;
            }
        }    
    }
}
