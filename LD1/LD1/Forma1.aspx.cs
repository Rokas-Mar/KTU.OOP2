using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace LD1
{
    public partial class Forma1 : System.Web.UI.Page
    {
        private Random rnd = new Random(new Random().Next(int.MinValue, int.MaxValue));

        protected void Page_Load(object sender, EventArgs e)
        {
            Table1.Visible = false;
            Table2.Visible = false;
            Label3.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string InitialData = Server.MapPath("~/Files/InitialData.txt"); // locates and initialises Initial data file
            File.WriteAllText(InitialData, ""); // clears InitialData

            // Validates if both text boxes are valid
            if (!ValidateNumber(TextBox1) || TextBox1.Text == "0")
            {
                return;
            }
            if (!ValidateNumber(TextBox2) || TextBox2.Text == "0")
            {
                return;
            }

            //Gets dimentions of rectangle
            int n = Convert.ToInt32(TextBox1.Text);
            int m = Convert.ToInt32(TextBox2.Text);
            int TopCount; // Count of biggest plot stain on top
            int BottomCount; // Count of biggest plot stain on bottom
            // tile that is the same color on both sides and is in the biggest stain coordinates
            int IntersectingX; 
            int IntersectingY;

            Table1.Visible = true;
            Table2.Visible = true;
            Label3.Visible = true;

            // Constructs new Grids
            Stain TopGrid = new Stain(n, m, rnd);
            Stain BottomGrid = new Stain(n, m, rnd);

            // Fills Grids in with random colors
            TopGrid.RandFillGrid();
            BottomGrid.RandFillGrid();

            // Prints Initial data to txt file
            InOutUtils.PrintToTxt(InitialData, TopGrid, "Pradinis viršus:");
            InOutUtils.PrintToTxt(InitialData, BottomGrid, "Pradinė apačia:");

            // Fills tables according to TopGrid and BottomGrid
            FillTable(Table1, TopGrid);
            FillTable(Table2, BottomGrid);

            // Gets the biggest stain on both sides
            TopGrid.GetBiggestPlot(BottomGrid, out TopCount, out BottomCount, out IntersectingX, out IntersectingY);

            // Marks the stain on tables
            TopGrid.MarkStain();
            BottomGrid.MarkStain();

            // Fills table stain with label
            PrintToTable(Table1, TopGrid, n, m);
            PrintToTable(Table2, BottomGrid, n, m);

            Label3.Text = $"Didžiausią plotą sudaro viršuje {TopCount} ir apačioje {BottomCount} langelių. ";
            if (IntersectingX >= 0 && IntersectingY >= 0)
                Label3.Text += $"Langelis: {IntersectingX + 1} eil., {IntersectingY + 1} st.";

            // Prints Stain to txt file
            InOutUtils.PrintToTxt(InitialData, TopGrid, "Užpildytas viršus:");
            InOutUtils.PrintToTxt(InitialData, BottomGrid, "Užpildyta apačia:");

            TextBox1.Text = "";
            TextBox2.Text = "";
        }
    }
}