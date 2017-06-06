using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Net.Cache;

namespace Sapper.Src.Elements
{
    class VisualCell:UIElement
    {
        private enum onPress
        {
            nonePressed,
            pressedOnce,
            pressedTwice
        }

        private Image flag;
        private Image question;

        private Border vCell;
        private onPress press { get; set; }
        

        public VisualCell(double height, double width)
        {
            vCell = new Border();
            vCell.Height = height;//inc heigh
            vCell.Width = width;//inc width

            flag = new Image();
            flag.Source = new BitmapImage(new Uri("pack://application:,,,/Images/flag.png"), new RequestCachePolicy(RequestCacheLevel.Default));
            flag.Margin = new Thickness(7, 2, 2, 2);
            question = new Image();
            question.Source = new BitmapImage(new Uri("pack://application:,,,/Images/Question.png"), new RequestCachePolicy(RequestCacheLevel.Default));
            question.Margin = new Thickness(4, 2, 2, 2);

            vCell.BorderBrush = Brushes.Black;
            vCell.BorderThickness = new Thickness(2);
            vCell.Background = Brushes.Silver;

            vCell.MouseEnter += mouse_in;
            vCell.MouseLeave += mouse_leave;
            vCell.MouseLeftButtonDown += mouse_down;
            vCell.MouseRightButtonDown += mouse_Right_Down;

            press = onPress.nonePressed;
        }

        public VisualCell()
        {
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
            eventedR.BorderBrush = Brushes.Chocolate;
            eventedR.Background = Brushes.BlanchedAlmond;
            TextBlock cellData = new TextBlock();
            cellData.Text = "1"; // To Do : mine or number mines around
            cellData.Margin = new Thickness(8, 4, 2, 2);
            eventedR.Child = cellData;

            vCell.MouseEnter -= mouse_in;
            vCell.MouseLeave -= mouse_leave;
            vCell.MouseLeftButtonDown -= mouse_down;
        }

        private void mouse_Right_Down(object sender, EventArgs e)
        {
            Border eventedR = (Border)sender;
            if (press==onPress.nonePressed)
            {
                //Image img = new Image();
                //img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/flag.png"),new RequestCachePolicy(RequestCacheLevel.Default));
                // img.Margin = new Thickness(7, 2, 2, 2);
                eventedR.Child = flag;

                press = onPress.pressedOnce;
                vCell.MouseLeftButtonDown -= mouse_down;
                
            }else if(press == onPress.pressedOnce)
            {
                press = onPress.pressedTwice;
                //Image img = new Image();
                //img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/Question.png"), new RequestCachePolicy(RequestCacheLevel.Default));
                //img.Margin = new Thickness(4, 2, 2, 2);
                eventedR.Child = question;
            }else if(press == onPress.pressedTwice)
            {
                press = onPress.nonePressed;
                eventedR.Child = null;
                vCell.MouseLeftButtonDown += mouse_down;
            }
        }

        public void Draw(Canvas canvas, int posX, int posY)
        {   
            canvas.Children.Add(vCell);
            Canvas.SetLeft(canvas, posX);
            Canvas.SetTop(canvas, posY);
        }
    }
}
