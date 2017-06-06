using Sapper.Enums;
using Sapper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                }else
                {
                    generateMines(totalCount, sizeX, sizeY);
                }
            }
        }

        public void generateField(int sizeX, int sizeY, int mineCount)
        {
            for(int x = 0; x<sizeX; x++)
            {
                for(int y = 0; y<sizeY; y++)
                {
                    Cell cell = new Cell();
                    cell.set_Positions(x, y);
                    cell.set_cellType(CellType.EMPTYFIELD);
                    cellList.Add(cell);
                }
            }
            generateMines(mineCount, sizeX, sizeY);

        }

        public void checkNeighbours(Cell checkCell)
        {

        }
    }
}
