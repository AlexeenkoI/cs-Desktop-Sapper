using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sapper.Enums;
using Sapper.Interfaces;
using Sapper.Src.Elements;
using System.Windows.Controls;

namespace Sapper.Src
{
    class Cell : ICell
    {
        private CellType CellType;
        private State State = State.CLOSE;
        private int numberMinesAround = 0; //возможно удалить это и вынести счетчик мин в field
        private int posX, posY;
        private VisualCell vCell;

        public Cell()
        {

        }


        public Cell(CellType incType, int incX, int incY)
        {
            vCell = new VisualCell();
            this.CellType = incType;
            this.posX = incX;
            this.posY = incY;
        }

        public void increase_numberMinesAround()
        {
            this.numberMinesAround++;
            
        }

        public void decrease_numberMunesAround()
        {
            this.numberMinesAround--;
        }
        public int get_numberMinesAround() 
        {
            return this.numberMinesAround;
        }

        public void set_cellType(CellType incCellType)
        {
            
            this.CellType = incCellType;
        }
        public CellType get_cellType()
        {
            return this.CellType;
        }

        
        public void set_State(State incState)
        {
           
            this.State = incState;
        }
        public State get_State()
        {
            return this.State;
        }


        
        public void set_Positions(int x, int y)
        {
                this.posX = x;
                this.posY = y;
        }
        public int get_Position_X()
        {
            return posX;
        }
        public int get_Position_Y()
        {
            return posY;
        }

        public void drawMe(Canvas canvas, int posX, int poxY)
        {
            vCell.Draw(canvas, posX, posY);
        }
    }
}
