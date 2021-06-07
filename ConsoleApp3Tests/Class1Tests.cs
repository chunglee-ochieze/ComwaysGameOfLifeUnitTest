using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp3.Tests
{
    [TestClass]
    public class Class1Tests
    {
        private const int V = 0;

        [TestMethod]
        public void FiveByFiveGridMatrix()
        {
            var gameOfLife = new GameOfLife(5, 5);

            var gridGame = gameOfLife.Grid;
            
            Assert.AreEqual(5, gridGame.Count);
        }

        [TestMethod]
        public void CellLifeState()
        {
            var gameOfLife = new GameOfLife(5, 5);

            var gridGame = gameOfLife.Grid;

            Assert.AreEqual(1, gridGame.First().First());
        }

        [TestMethod]
        public void ArbitraryInitGridState()
        {
            var gameOfLife = new GameOfLife(1, 9);

            var gridGame = gameOfLife.Grid;

            Assert.AreEqual(0, gridGame.Last().Last());
        }

        [TestMethod]
        public void UnchangedGridState() //not sure I understand number 4.
        {

        }

        [TestMethod]
        public void KeepCellAlive()
        {
            var gameOfLife = new GameOfLife(5, 5);

            var gridGames = gameOfLife.OnesGrid;

            var keepAlive = false;

            for (var i = 0; i < gridGames.Count; i++)
            {
                for (var j = 0; j < gridGames[i].Count; j++)
                {
                    if (j == 0)
                        continue;

                    if (gridGames[i][j - 1] == 1 && gridGames[i][j] == 1 && (gridGames[i][j + 1] == 1 || gridGames[i + 1][j] == 1))
                    {
                        keepAlive = true;
                        break;
                    }
                }

                if (keepAlive)
                    break;
            }

            Assert.AreEqual(true, keepAlive);
        }

        [TestMethod]
        public void CellDiesOfOverpopulation()
        {
            var gameOfLife = new GameOfLife(5, 5);

            var gridGames = gameOfLife.OnesGrid;

            var cellDies = false;

            for (var i = 0; i < gridGames.Count; i++)
            {
                for (var j = 0; j < gridGames[i].Count; j++)
                {
                    if (i == 0 || j == 0)
                        continue;

                    if (gridGames[i][j - 1] == 1 && gridGames[i][j] == 1 && gridGames[i][j + 1] == 1 &&
                        gridGames[i - 1][j] == 1)
                    {
                        cellDies = true;
                        break;
                    }
                }

                if (cellDies)
                    break;
            }

            Assert.AreEqual(true, cellDies);
        }

        [TestMethod]
        public void CellDieOfUnderPopulation()
        {
            var gameOfLife = new GameOfLife(5, 5);

            var gridGames = gameOfLife.OnesGrid;

            var cellDies = false;

            for (var i = 0; i < gridGames.Count; i++)
            {
                for (var j = 0; j < gridGames[i].Count; j++)
                {
                    if (j == 0)
                        continue;

                    if (gridGames[i][j - 1] == 0 && gridGames[i][j] == 1 && gridGames[i][j + 1] == 1 &&
                        gridGames[i + 1][j] == 0)
                    {
                        cellDies = true;
                        break;
                    }
                }

                if (cellDies)
                    break;
            }

            Assert.AreEqual(true, cellDies);
        }

        [TestMethod]
        public void CellReproduction()
        {
            var gameOfLife = new GameOfLife(5, 5);

            var gridGames = gameOfLife.OnesGrid;

            var comesAlive = false;

            for (var i = 0; i < gridGames.Count; i++)
            {
                for (var j = 0; j < gridGames[i].Count; j++)
                {
                    if(i == 0 || j == 0)
                        continue;

                    if (gridGames[i][j - 1] == 1 && gridGames[i][j] == 0 && gridGames[i][j + 1] == 1 &&
                        gridGames[i - 1][j] == 1)
                    {
                        comesAlive = true;
                        break;
                    }
                }

                if(comesAlive)
                    break;
            }

            Assert.AreEqual(true, comesAlive);
        }
    }
}