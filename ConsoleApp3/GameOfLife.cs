using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class GameOfLife
    {
        public GameOfLife(int gridLength, int gridWidth)
        {
            Grid = new List<List<int>>();
            for (var i = 0; i < gridLength; i++)
            {
                var grid = new List<int>();

                for (var j = 0; j < gridWidth; j++)
                    grid.Add(i == j ? 1 : 0);

                Grid.Add(grid);
            }

            OnesGrid = new List<List<int>>();
            for (var i = 0; i < gridLength; i++)
            {
                var grid = new List<int>();

                for (var j = 0; j < gridWidth; j++)
                    grid.Add(i != j ? 1 : 0);

                OnesGrid.Add(grid);
            }

            ZerosGrid = new List<List<int>>();
            for (var i = 0; i < gridLength; i++)
            {
                var grid = new List<int>();

                for (var j = 0; j < gridWidth; j++)
                    grid.Add(i != j ? 0 : 1); //I'm aware that ZerosGrid is a replica of Grid

                ZerosGrid.Add(grid);
            }
        }

        public List<List<int>> Grid { get; set; }
        public List<List<int>> OnesGrid { get; set; }
        public List<List<int>> ZerosGrid { get; set; }
    }
}


//1 0 0 0 0
//0 1 0 0 0
//0 0 1 0 0
//0 0 0 1 0
//0 0 0 0 1