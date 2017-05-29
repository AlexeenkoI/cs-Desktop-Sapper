using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Sapper.Src.Elements
{
    class VisualCell
    {
        Border border;
        bool lmPressed;
        bool rmPressed;

        public VisualCell(double height, double width)
        {
            border = new Border();
            border.Height = 30;//inc heigh
            border.Width = 30;//inc width

            border.BorderBrush = Brushes.Black;
            border.BorderThickness = new Thickness(2);
            border.Background = Brushes.Silver;

            border.MouseEnter += mouse_in;
            border.MouseLeave += mouse_leave;
            border.MouseLeftButtonDown += mouse_down;

            lmPressed = false;
            rmPressed = false;
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

            border.MouseEnter -= mouse_in;
            border.MouseLeave -= mouse_leave;
            border.MouseDown -= mouse_down;



        }
    }
}
