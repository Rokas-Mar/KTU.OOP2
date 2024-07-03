using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD1
{
    public class Stain
    {
        private Random rnd; // Random element seed
        private List<char> colors = new List<char>() { 'r', 'y', 'g' }; // Available colors to randomise onto the grid
        public char label { get; private set; } = '*'; // label to mark stain

        public int InterX { get; private set; } // Intersecting X coord
        public int InterY { get; private set; }// Intersecting Y coord

        private char[,] Grid;
        readonly int n;
        readonly int m;
        private int[] CX, // Arrays containing stain coordinates
                      CY;
        public int count { get; private set; } // Count for CY and CY arrays

        public Stain(int n, int m, Random rnd)
        {
            Grid = new char[m, n];
            this.rnd = rnd;
            this.m = m;
            this.n = n;
            this.label = label;
            CX = new int[n * m];
            CY = new int[n * m];
            count = 0;
        }

        /// <summary>
        /// Fills Grid with random given colors
        /// </summary>
        public void RandFillGrid()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Grid[j, i] = colors[rnd.Next(0, 3)];
                }
            }
        }

        /// <summary>
        /// Checks if Stain Coordinates contain the given ones
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns>true if Stain Coordinates contain given ones, otherwise false</returns>
        public bool ContainsCoords(int x, int y)
        {
            for (int i = 0; i < count; i++)
            {
                if (CX[i] == x && CY[i] == y)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Adds given coordinates to Stain Coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public void AddStainCoordinates(int x, int y)
        {
            bool contains = false;
            for (int i = 0; i < count; i++)
            {
                if (CX[i] == x && CY[i] == y)
                {
                    contains = true; break;
                }
            }

            if (!contains)
            {
                CX[count] = x;
                CY[count] = y;
                count++;
            }
        }

        /// <summary>
        /// Gets the biggest Stain between two Stain class Grids
        /// </summary>
        /// <param name="OtherGrid">Stain class element</param>
        /// <param name="TopMaxCount">Stained cell count on top</param>
        /// <param name="BottomMaxCount">Stain cell count on bottom</param>
        /// <param name="IntersectX">Intersecting X coordinates</param>
        /// <param name="IntersectY">Intersecting Y coordinates</param>
        public void GetBiggestPlot(Stain OtherGrid, out int TopMaxCount, out int BottomMaxCount, out int IntersectX, out int IntersectY)
        {
            TopMaxCount = 0;
            BottomMaxCount = 0;
            IntersectX = -1;
            IntersectY = -1;

            int[] TopX = new int[n * m];
            int[] TopY = new int[n * m];
            int TopCount = 0;

            int[] BottomX = new int[n * m];
            int[] BottomY = new int[n * m];
            int BottomCount = 0;

            for (int c = 0; c < colors.Count; c++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (!ContainsCoords(j, i) && !OtherGrid.ContainsCoords(j, i))
                        {
                            this.ResetXCoors();
                            this.ResetYCoors();
                            OtherGrid.ResetXCoors();
                            OtherGrid.ResetYCoors();

                            count = 0;
                            OtherGrid.SetCoordLenght(0);

                            GetStain(j, i, colors[c], OtherGrid);

                            if (TopCount + BottomCount < count + OtherGrid.count)
                            {
                                TopX = CX;
                                TopY = CY;
                                TopCount = count;

                                BottomX = OtherGrid.GetXcoords();
                                BottomY = OtherGrid.GetYcoords();
                                BottomCount = OtherGrid.count;

                                if (this.Get(j, i) == OtherGrid.Get(j, i))
                                {
                                    IntersectX = InterX;
                                    IntersectY = InterY;
                                }
                            }
                        }
                    }
                }
            }

            TopMaxCount = TopCount;
            BottomMaxCount = BottomCount;

            this.SetCoordLenght(TopCount);
            OtherGrid.SetCoordLenght(BottomCount);
            this.SetCoords(TopX, TopY);
            OtherGrid.SetCoords(BottomX, BottomY);
        }

        /// <summary>
        /// Gets Stain on top and bottom
        /// </summary>
        /// <param name="x">Starting cell X coordinates</param>
        /// <param name="y">Starting cell Y coordinates</param>
        /// <param name="color">Color to check for</param>
        /// <param name="OtherGrid">Stain class Grid</param>
        /// <param name="Used">Passes on if the cell has already been checked</param>
        /// <param name="ind">Index of Stain Coordinates to check</param>
        public void GetStain(int x, int y, char color, Stain OtherGrid, bool Used = false, int ind = 0)
        {
            int[] Ax = { -1, 0, 1, 1, 1, 0, -1, -1 };
            int[] By = { -1, -1, -1, 0, 1, 1, 1, 0 };

            if (Grid[x, y] == color)
            {
                AddStainCoordinates(x, y);

                for (int i = 0; i < Ax.Length; i++)
                {
                    if ((x + Ax[i] >= 0 && x + Ax[i] < Grid.GetLength(0)) && (y + By[i] >= 0 && y + By[i] < Grid.GetLength(1)))
                    {
                        if (Grid[x + Ax[i], y + By[i]] == color)
                        {
                            AddStainCoordinates(x + Ax[i], y + By[i]);
                        }
                    }
                }
                if (Used == false)
                    if (OtherGrid.Get(x, y) == color && !OtherGrid.ContainsCoords(x, y))
                    {
                        InterX = x;
                        InterY = y;
                        OtherGrid.GetStain(x, y, color, this, true);
                    }
            }

            if (ind < count)
                GetStain(CX[ind], CY[ind], color, OtherGrid, false, ind + 1);
        }

        /// <summary>
        /// Marks the Grid Stain with label
        /// </summary>
        public void MarkStain()
        {
            for (int i = 0; i < this.count; i++)
            {
                Grid[CX[i], CY[i]] = label;
            }
        }

        /// <summary>
        /// Gets Grid[,]
        /// </summary>
        /// <returns>Grid elements in char[,]</returns>
        public char[,] GetGrid()
        {
            return Grid;
        }

        /// <summary>
        /// Gets element from Grid
        /// </summary>
        /// <param name="x">X coordinates on the Grid</param>
        /// <param name="y">Y coordinates on the Grid</param>
        /// <returns>char element of fount element</returns>
        public char Get(int x, int y)
        {
            return Grid[x, y];
        }

        /// <summary>
        /// Gets Grids n dimention
        /// </summary>
        /// <returns>int n dimention</returns>
        public int GetN()
        { return n; }

        /// <summary>
        /// Gets Grids m dimention
        /// </summary>
        /// <returns>int m dimention</returns>
        public int GetM()
        { return m; }

        /// <summary>
        /// Sets all coordinates in Stain Coordinates
        /// </summary>
        /// <param name="X">X coord array</param>
        /// <param name="Y">Y coord array</param>
        private void SetCoords(int[] X, int[] Y)
        {
            for (int i = 0; i < this.count; i++)
            {
                this.CX[i] = X[i];
                this.CY[i] = Y[i];
            }
        }

        /// <summary>
        /// Sets Stain Coordinates Length to given
        /// </summary>
        /// <param name="count">int element</param>
        private void SetCoordLenght(int count)
        {
            this.count = count;
        }

        /// <summary>
        /// Resets Stain X Coordinate array
        /// </summary>
        private void ResetXCoors()
        {
            CX = new int[n * m];
        }

        /// <summary>
        /// Resets Stain Y Coordinate array
        /// </summary>
        private void ResetYCoors()
        {
            CY = new int[n * m];
        }

        /// <summary>
        /// Gets X coordinates from Stin X Coordinate array
        /// </summary>
        /// <returns></returns>
        public int[] GetXcoords()
        {
            return CX;
        }

        /// <summary>
        /// Gets Y coordinates from Stin Y Coordinate array
        /// </summary>
        /// <returns></returns>
        public int[] GetYcoords()
        {
            return CY;
        }

        /// <summary>
        /// Gets Stain Coordinate array count
        /// </summary>
        /// <returns>int element</returns>
        public int GetCoordCount()
        {
            return count;
        }

        /// <summary>
        /// Gets indexed line from Grid
        /// </summary>
        /// <param name="index">index of which line to return</param>
        /// <returns>char[] array with Grid elements</returns>
        public char[] GetLine(int index)
        {
            char[] chars = new char[m];

            for (int i = 0; i < m; i++)
            {
                chars[i] = Grid[i, index];
            }

            return chars;
        }

        /// <summary>
        /// Formats String to print
        /// </summary>
        /// <param name="line">line to print</param>
        /// <returns>Formated line joined with "; "</returns>
        public string ToString(int line)
        {
            return "| " + string.Join("; ", GetLine(line)) + " |";
        }
    }
}