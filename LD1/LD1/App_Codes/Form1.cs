using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.IO;

namespace LD1
{
    public partial class Forma1 : System.Web.UI.Page
    {
        // -------------Printing------------- //

        /// <summary>
        /// Prints Grid labels on table cells
        /// </summary>
        /// <param name="table">Table to which labels will be printed</param>
        /// <param name="Grid">Grid to get labels from</param>
        /// <param name="n">row dimention</param>
        /// <param name="m">cell dimention</param>
        public static void PrintToTable(Table table, Stain Grid, int n, int m)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    char c = Grid.Get(j - 1, i - 1);
                    if (c == Grid.label)
                    {
                        table.Rows[i].Cells[j].Text = Grid.Get(j - 1, i - 1).ToString();
                        table.Rows[i].Cells[j].ForeColor = System.Drawing.Color.Black;
                        table.Rows[i].Cells[j].Style.Add("font-family", "Segoe UI");
                        table.Rows[i].Cells[j].Style.Add("font-weight", "900");
                    }
                    else
                        table.Rows[i].Cells[j].Text = "";
                }
            }
        }

        /// <summary>
        /// Filles table with color
        /// </summary>
        /// <param name="table">Table to color</param>
        /// <param name="Grid">Grid to grab colors from</param>
        public static void FillTable(Table table, Stain Grid)
        {
            int n = Grid.GetN();
            int m = Grid.GetM();

            GenerateBlocks(table, n, m);

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    switch (Grid.Get(j - 1, i - 1))
                    {
                        case 'r':
                            table.Rows[i].Cells[j].BackColor = System.Drawing.Color.Red;
                            break;
                        case 'y':
                            table.Rows[i].Cells[j].BackColor = System.Drawing.Color.Yellow;
                            break;
                        case 'g':
                            table.Rows[i].Cells[j].BackColor = System.Drawing.Color.Green;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Generates Table cells and rows according to the typed in ones
        /// </summary>
        /// <param name="table">Table to format</param>
        /// <param name="n">row dimention</param>
        /// <param name="m">cell dimention</param>
        public static void GenerateBlocks(Table table, int n, int m)
        {
            TableRow numRow = GenerateNumRow(m);
            table.Rows.Add(numRow);

            for (int i = 0; i < n; i++)
            {
                TableRow row = new TableRow();

                for (int j = 0; j <= m; j++)
                {
                    TableCell cell = new TableCell();
                    cell.BorderWidth = 1;

                    if (j == 0)
                    {
                        cell.Text = $"{(i + 1).ToString()}";
                        cell.BorderWidth = 0;
                    }
                    row.Cells.Add(cell);
                }
                table.Rows.Add(row);
            }
        }

        /// <summary>
        /// Generates number row for Table
        /// </summary>
        /// <param name="m">Cell dimention</param>
        /// <returns>TableRow of generated number row</returns>
        public static TableRow GenerateNumRow(int m)
        {
            TableRow row = new TableRow();
            TableCell clearCell = new TableCell();
            clearCell.BorderWidth = 0;

            row.Cells.Add(clearCell);

            for (int i = 0; i < m; i++)
            {
                TableCell cell = new TableCell();
                cell.BorderWidth = 0;
                cell.Text = $"{(i + 1).ToString()}";
                row.Cells.Add(cell);
            }

            return row;
        }

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

        // -------------VALIDATION------------- //
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!ValidateNumber(TextBox1))
            {
                args.IsValid = false;
            }
            if (TextBox1.Text == "0")
            {
                CustomValidator1.ErrorMessage = "Stačiakampis nesusidaro";
                args.IsValid = false;
            }
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!ValidateNumber(TextBox2))
            {
                args.IsValid = false;
            }
            if (TextBox2.Text == "0")
            {
                CustomValidator2.ErrorMessage = "Stačiakampis nesusidaro";
                args.IsValid = false;
            }
        }

        /// <summary>
        /// Validates if textBox text is only digits
        /// </summary>
        /// <param name="textBox">TextBox element to analyse</param>
        /// <returns>true if text is made completely out of digits, otherwise false</returns>
        public bool ValidateNumber(TextBox textBox)
        {
            foreach(char c in textBox.Text)
            {
                if(Regex.IsMatch(c.ToString(), "[^0-9]"))
                {
                    return false;
                }
            }

            return true;
        }
    }
}