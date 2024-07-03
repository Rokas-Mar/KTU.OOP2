using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;

namespace LD1
{
    public static class InOutUtils
    {
        /// <summary>
        /// Prints Grid to txt file
        /// </summary>
        /// <param name="txtFile">string file element</param>
        /// <param name="Grid">Grid to print</param>
        /// <param name="label">label to call the table</param>
        public static void PrintToTxt(string txtFile, Stain Grid, string label)
        {
            int Length = Grid.GetN();
            int count = Grid.GetM() * 3;
            string[] lines = new string[Length + 2];
            char[] chars = new char[Length];

            lines[0] = label;
            for (int i = 0; i < Length; i++)
            {
                chars = Grid.GetLine(i);
                lines[i + 1] = Grid.ToString(i);
            }
            File.AppendAllLines(txtFile, lines);
        }
    }
}