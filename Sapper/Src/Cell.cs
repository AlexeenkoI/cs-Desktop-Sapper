using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sapper.Enums;
using Sapper.Interfaces;

namespace Sapper.Src
{
    class Cell : ICell
    {
        private CellType CellType;
        private State State = State.Close;
        private int numberMinesAround = 0; //возможно удалить это и вынести счетчик мин в field
        private int posX, posY;
        
        public Cell()
        {

        }

        public Cell(CellType incType, int incX, int incY)
        {
            this.CellType = incType;
            this.posX = incX;
            this.posY = incY;
        }

        public void set_numberMinesAround(int mineCount)
        {
            if(this.get_cellType().Equals(CellType.NumericField) )
            {
                this.numberMinesAround = mineCount;
            }
        }
        public int get_numberMinesAround()
        {
            return this.numberMinesAround;
        }


        public void set_cellType(CellType incCellType)
        {
            if(incCellType!=0)
            this.CellType = incCellType;
        }
        public CellType get_cellType()
        {
            return this.CellType;
        }

        
        
        public void set_State(State incState)
        {
            if(incState!=0)
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
            return this.posX;
        }
        public int get_Position_Y()
        {
            return this.posY;
        }


    }
}
