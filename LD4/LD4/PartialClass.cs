using System;
using System.Web.UI.WebControls;

namespace LD4
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        /// <summary>
        /// Prints all data to a table element
        /// </summary>
        /// <param name="table">Table element</param>
        /// <param name="council">Council element to print</param>
        /// <param name="title">Caption of the table</param>
        public void PrintToTable(Council council, string title)
        {
            Table table = new Table();
            TableRow row = new TableRow();
            table.Caption = title;
            TableCell topic = new TableCell();
            topic.Text = "Tema";
            topic.BackColor = System.Drawing.Color.OrangeRed;
            row.Cells.Add(topic);

            TableCell Diff = new TableCell();
            Diff.Text = "Sudėtingumas";
            Diff.BackColor = System.Drawing.Color.OrangeRed;
            row.Cells.Add(Diff);

            TableCell Aut = new TableCell();
            Aut.Text = "Autorius";
            Aut.BackColor = System.Drawing.Color.OrangeRed;
            row.Cells.Add(Aut);

            TableCell Txt = new TableCell();
            Txt.Text = "Tekstas";
            Txt.BackColor = System.Drawing.Color.OrangeRed;
            row.Cells.Add(Txt);

            TableCell Ans = new TableCell();
            Ans.Text = "Atsakymas";
            Ans.BackColor = System.Drawing.Color.OrangeRed;
            row.Cells.Add(Ans);

            TableCell Pts = new TableCell();
            Pts.Text = "Taškai";
            Pts.BackColor = System.Drawing.Color.OrangeRed;
            row.Cells.Add(Pts);

            TableCell file = new TableCell();
            file.Text = "Failas";
            file.BackColor = System.Drawing.Color.OrangeRed;
            row.Cells.Add(file);

            TableCell variants = new TableCell();
            variants.Text = "Pasirinkami atsakymai";
            variants.BackColor = System.Drawing.Color.OrangeRed;
            row.Cells.Add(variants);

            row.Style.Add("font-weight", "600");

            table.Rows.Add(row);


            for (int i = 0; i < council.Count(); i++)
            {
                Question question = council.Get(i);

                row = new TableRow();
                topic = new TableCell();
                topic.Text = question.Topic;
                row.Cells.Add(topic);

                Diff = new TableCell();
                Diff.Text = question.Difficulty;
                row.Cells.Add(Diff);

                Aut = new TableCell();
                Aut.Text = question.Author;
                row.Cells.Add(Aut);

                Txt = new TableCell();
                Txt.Text = question.Text;
                row.Cells.Add(Txt);

                Ans = new TableCell();
                Ans.Text = question.Answer;
                row.Cells.Add(Ans);

                Pts = new TableCell();
                Pts.Text = question.Points.ToString();
                row.Cells.Add(Pts);

                if (question.GetType() == typeof(TestQuestion))
                {
                    file = new TableCell();
                    file.Text = "-";
                    row.Cells.Add(file);

                    variants = new TableCell();
                    variants.Text = string.Join(", ", (question as TestQuestion).GetVariants());
                    row.Cells.Add(variants);
                }
                else if (question.GetType() == typeof(MusicQuestion))
                {
                    file = new TableCell();
                    file.Text = (question as MusicQuestion).FileName;
                    row.Cells.Add(file);

                    variants = new TableCell();
                    variants.Text = "-";
                    row.Cells.Add(variants);
                }

                table.Rows.Add(row);
            }
            table.Style.Add("width", "80%");
            table.Style.Add("margin-top", "40px");
            table.GridLines = GridLines.Both;
            MainDiv.Controls.Add(table);
        }
    }
}