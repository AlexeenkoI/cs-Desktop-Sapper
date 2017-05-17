using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapper.Interfaces
{
    interface ICell
    {

        void set_Positions(int X,int Y);
        int get_Position_X();
        int get_Position_Y();

    }
}
