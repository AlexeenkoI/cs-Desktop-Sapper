using Sapper.Enums;
using Sapper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Sapper.Src.Logic
{
    class Field:IField
    {
        private List<Cell> cellList;
        Random rand; 

        public Field()
        {
            cellList = new List<Cell>();
            rand = new Random();
        }

        private void generateMines(int mineCount, int sizeX, int sizeY)
        {
           int totalCount = mineCount;
            
           for(int i = 0; i<totalCount; i++)
            {
                int genX = rand.Next(0, sizeX);
                int genY = rand.Next(0, sizeY);

                Cell mineCell = cellList.Find(x => x.get_Position_X() == genX && x.get_Position_Y() == genY);

                if (mineCell.get_cellType()!=CellType.MINE) {
                    mineCell.set_cellType(CellType.MINE);
                    totalCount--;
                    checkNeighbours(mineCell, (sizeX-1), (sizeY-1));
                }else
                {
                    generateMines(totalCount, sizeX, sizeY);
                }
            }
        }

        public void generateField(int sizeX, int sizeY, int mineCount)
        {
            for(int y = 0; y<sizeY; y++)
            {
                for(int x = 0; x<sizeX; x++)
                {
                    Cell cell = new Cell();
                    cell.set_Positions(x, y);
                    cell.set_cellType(CellType.EMPTYFIELD);
                    cellList.Add(cell);
                }
            }
            generateMines(mineCount, sizeX, sizeY);
        }

        public void checkNeighbours(Cell mineCell, int sizeX, int sizeY)
        {
            if (mineCell.get_Position_X() != 0) {
                Cell leftCell = cellList.Find(x => x.get_Position_X() == (mineCell.get_Position_X() - 1) && x.get_Position_Y() == mineCell.get_Position_Y());
                leftCell.set_cellType(CellType.NUMERICFIELD);
                leftCell.increase_numberMinesAround();
            }
            if (mineCell.get_Position_X() != sizeX)
            {
                Cell rightCell = cellList.Find(x => x.get_Position_X() == (mineCell.get_Position_X() + 1) && x.get_Position_Y() == mineCell.get_Position_Y());
                rightCell.set_cellType(CellType.NUMERICFIELD);
                rightCell.increase_numberMinesAround();
            }
            
            if (mineCell.get_Position_Y() != 0)
            {
                Cell topCell = cellList.Find(x => x.get_Position_X() == mineCell.get_Position_X() && x.get_Position_Y() == (mineCell.get_Position_Y()-1));
                topCell.set_cellType(CellType.NUMERICFIELD);
                topCell.increase_numberMinesAround();
                if (topCell.get_Position_X()!=0)
                {
                    Cell topLeftCell = cellList.Find(x => x.get_Position_X() == (mineCell.get_Position_X() - 1) && x.get_Position_Y() == (mineCell.get_Position_Y()-1));
                    topLeftCell.set_cellType(CellType.NUMERICFIELD);
                    topLeftCell.increase_numberMinesAround();
                }
                if (topCell.get_Position_X() != sizeX)
                {
                    Cell topRightCell = cellList.Find(x => x.get_Position_X() == (mineCell.get_Position_X() + 1) && x.get_Position_Y() == (mineCell.get_Position_Y() - 1));
                    topRightCell.set_cellType(CellType.NUMERICFIELD);
                    topRightCell.increase_numberMinesAround();
                }
            }
            if (mineCell.get_Position_Y() != sizeY)
            {
                Cell bottomCell = cellList.Find(x => x.get_Position_X() == mineCell.get_Position_X() && x.get_Position_Y() == (mineCell.get_Position_Y()+1));
                bottomCell.set_cellType(CellType.NUMERICFIELD);
                bottomCell.increase_numberMinesAround();
                if (bottomCell.get_Position_X() != 0)
                {
                    Cell leftBottomCell = cellList.Find(x => x.get_Position_X() == (mineCell.get_Position_X()-1) && x.get_Position_Y() == (mineCell.get_Position_Y() + 1));
                    leftBottomCell.set_cellType(CellType.NUMERICFIELD);
                    leftBottomCell.increase_numberMinesAround();
                }
                if (bottomCell.get_Position_X() != sizeX)
                {
                    Cell rightBottomCell = cellList.Find(x => x.get_Position_X() == (mineCell.get_Position_X() + 1) && x.get_Position_Y() == (mineCell.get_Position_Y() + 1));
                    rightBottomCell.set_cellType(CellType.NUMERICFIELD);
                    rightBottomCell.increase_numberMinesAround();
                }
            }
        }
        private  void regenerateFirstCell()
        {

        }

        public void drawField(Canvas viewport, int posX, int posY)
        {
            foreach(Cell cell in cellList)
            {
                cell.drawMe(viewport, posX, posY);
            }
        }
    }
}
