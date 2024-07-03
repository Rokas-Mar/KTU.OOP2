using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;

namespace LD1
{
    public static class TaskUtils
    {
        /// <summary>
        /// Clears table from labels
        /// </summary>
        /// <param name="table">Table to clear</param>
        /// <param name="n">Row dimention</param>
        /// <param name="m">Cell dimention</param>
        public static void ClearTable(Table table, int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    table.Rows[i].Cells[j].Text = "";
                }
            }
        }
    }
}