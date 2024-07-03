using System;
using System.IO;
using System.Web.UI;

namespace LD4
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public const int MaxCouncils = 10; // max available councils

        protected void Page_Load(object sender, EventArgs e)
        {
            //Sets all tables and labels to invisible and no text
            Label1.Visible = false;
            Label1.Text = string.Empty;
            Label2.Visible = false;
            Label2.Text = string.Empty;
            Label3.Visible = false;
            Label3.Text = string.Empty;
            Label4.Visible = false;
            Label4.Text = string.Empty;
            Label5.Visible = false;
            Label5.Text = string.Empty;
            Label6.Visible = false;
            Label6.Text = string.Empty;
            Label7.Text = string.Empty;
            Label7.Visible = false;
        }

        // Main Process
        protected void Button1_Click(object sender, EventArgs e)
        {
            Council[] Councils = new Council[MaxCouncils]; // Main Council Array
            int NumberOfBranches = 0; // Council count
            // Data and Result Data
            string DataDir = Server.MapPath("~/Data");
            string Res = Server.MapPath("~/Results/Res.txt");
            string Music = Server.MapPath("~/Results/SudetingiMuzikiniai.txt");
            string General = Server.MapPath("~/Results/SudetingiBendrai.txt");
            string Fun = Server.MapPath("~/Results/Linksmieji.txt");

            // Resets all Files to no text
            File.WriteAllText(Res, "");
            File.WriteAllText(Music, "");
            File.WriteAllText(General, "");
            File.WriteAllText(Fun, "");

            try
            {
                InOutUtils.ReadData(DataDir, Councils, ref NumberOfBranches);
            } catch (FilesNotFound ex)
            {
                Label7.Text = ex.Message;
                Label7.Visible = true;
                return;
            }

            // Prints initial data
            InOutUtils.PrintDataToFile(Res, Councils, NumberOfBranches);

            // Prints initial data to Tables
            for (int i = 0; i < NumberOfBranches; i++)
            {
                PrintToTable(Councils[i], Councils[i].Title);
            }

            Label2.Visible = true;
            Label2.Text = "Atstovybės:";

            // Gets all difficulties
            Council I = TaskUtils.GetQuestionsByDifficulty(Councils, NumberOfBranches, "I");
            Council II = TaskUtils.GetQuestionsByDifficulty(Councils, NumberOfBranches, "II");
            Council III = TaskUtils.GetQuestionsByDifficulty(Councils, NumberOfBranches, "III");

            // Gets difficulty count
            Label4.Text = "Lengviausių klausimų: " + I.Count().ToString();
            Label5.Text = "Vidutinio sudėtingumo klausimų: " + II.Count().ToString();
            Label6.Text = "Sunkiausių klausimų: " + III.Count().ToString();

            Label3.Visible = true;
            Label3.Text = "Klausimai:";
            Label4.Visible = true;
            Label5.Visible = true;
            Label6.Visible = true;

            string MostCommonAputhor = TaskUtils.GetMostCommonAuthorGlobal(Councils, NumberOfBranches, out int count);
            if (MostCommonAputhor != null)
                Label1.Text = $"Daugiausiai klausimų sukūrė ({count}): " + MostCommonAputhor;
            else Label1.Text = "Daugiausiai klausimų sukūrusio asmens nėra";
            Label1.Visible = true;

            Council MusicIII = TaskUtils.GetQuestionsByType(III, typeof(MusicQuestion));

            if (MusicIII.IsEmpty())
            {
                Label7.Text = "! Muzikinių sunkiausių klausimų sąrašas nesusidarė";
                Label7.Visible = true;
            }

            if (III.IsEmpty())
            {
                Label7.Text += "<br/>! Bendrai sunkiausių klausimų sąrašas nesusidarė";
                Label7.Visible = true;
            }

            InOutUtils.PrintQuestionsToFile(Music, MusicIII, "Muzikiniai sudėtingiausi klausimai:");
            InOutUtils.PrintQuestionsToFile(General, III, "Bendrai sudėtingiausi klausimai:");

            Council FunQuestions = TaskUtils.GetFunQuestions(Councils, NumberOfBranches);
            FunQuestions.Sort();
            InOutUtils.PrintQuestionsToFile(Fun, FunQuestions, "Linksmieji klausimai");

            if (FunQuestions.IsEmpty())
            {
                Label7.Text += "<br/>! Linksmųjų klausimų sąrašas nesusidarė";
                Label7.Visible = true;
            }

            if (Label7.Text == string.Empty)
            {
                Label7.Style.Add("color", "Green");
                Label7.Text += "✓ Sėkmingai įvykdyta";
                Label7.Visible = true;
            }
        }

        // Resets all labels and tables to none
        protected void Button2_Click(object sender, EventArgs e)
        {
            Page.Dispose();
            Label1.Visible = false;
            Label1.Text = string.Empty;
            Label2.Visible = false;
            Label2.Text = string.Empty;
            Label3.Visible = false;
            Label3.Text = string.Empty;
            Label4.Visible = false;
            Label4.Text = string.Empty;
            Label5.Visible = false;
            Label5.Text = string.Empty;
            Label6.Visible = false;
            Label6.Text = string.Empty;
        }
    }
}