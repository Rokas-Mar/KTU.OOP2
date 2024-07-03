using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace LD2
{
    public partial class Form1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Table1.Visible = false;
            Table2.Visible = false;
            Table3.Visible = false;
            Table4.Visible = false;
            Label2.Text = "";
            Label2.Visible = false;
            Label3.Text = "";
            Label3.Visible = false;
            Label7.Visible = false;
        }

        // Rezultatai button
        protected void Button1_Click(object sender, EventArgs e)
        {   
            // Declares new LinkLists
            LinkList Travelers = new LinkList();
            LinkedListHotel Hotels = new LinkedListHotel();

            // --------------Gets files from FileUpload-------------- //
            if (FileUpload1.HasFile && FileUpload1.FileName.EndsWith(".txt"))
            {
                InOutUtils.Read(FileUpload1.FileContent, Travelers);
            }
            else
            {
                Label7.Visible = true;
                return;
            }

            if(FileUpload2.HasFile && FileUpload2.FileName.EndsWith(".txt"))
            {
                InOutUtils.Read(FileUpload2.FileContent, Hotels);
            }
            else
            {
                Label7.Visible = true;
                return;
            }


            double Price = Convert.ToDouble(TextBox1.Text);

            // Getting all the required lists
            LinkedListHotel UnpickedHotels = Hotels.GetNotChosen(Travelers);
            LinkedListHotel PickedHotels = Hotels.GetPickedHotels(Travelers);
            LinkList MostStayedNights = Travelers.GetMaxStayed();
            MostStayedNights.Sort();
            LinkList MostPayed = Travelers.BellowPayedTravelers(Hotels, Price);
            MostPayed.Sort();

            // --------------Printing to Tables-------------- //
            string label;

            if(Travelers.IsEmpty())
            {
                Label2.Visible = true;
                Label2.Text = "Turistų sarašas tuščias";
                if(Hotels.IsEmpty())
                {
                    Label2.Text += ", Viešbučių sarašas tuščias";
                }
                return;
            }
            if (Hotels.IsEmpty())
            {
                Label2.Visible = true;
                Label2.Text = "Viešbučių sarašas tuščias";
                return;
            }

            if (PickedHotels.IsEmpty())
            {
                label = "Nei vienas viešbutis nebuvo pasirinktas";
            }
            else
            {
                label = "Pasirinkti viešbučiai";
            }
            PrintFullTable(Table1, PickedHotels, label);
            Table1.Visible = true;

            if(PickedHotels.IsEmpty())
            {
                return;
            }

            if(UnpickedHotels.IsEmpty())
            {
                label = "Visi viešbučiai buvo pasirinkti";
            }
            else
            {
                label = "Nepasitinkti viešbučiai";
            }
            PrintFullTable(Table2, UnpickedHotels, label);
            Table2.Visible = true;

            if(MostStayedNights.IsEmpty())
            {
                label = "Turistų sąrašas tuščias";
            }
            else
            {
                label = "Daugiausiai naktų nakvojantys asmenys";
            }
            PrintFullTable(Table3, MostStayedNights, label);
            Table3.Visible = true;

            if(MostPayed.IsEmpty())
            {
                label = "Sumokėjusių mažiau duotos sumos asmenų nerasta";
            }
            else
            {
                label = "Sumokėję mažiau duotos sumos asmenys";
            }
            PrintPartialTable(Table4, MostPayed, label);
            Table4.Visible = true;
        }

        // Pradiniai duomenys button
        protected void Button2_Click(object sender, EventArgs e)
        {
            // Declares new LinkLists
            LinkList Travelers = new LinkList();
            LinkedListHotel Hotels = new LinkedListHotel();

            // --------------Gets files from FileUpload-------------- //
            if (FileUpload1.HasFile && FileUpload1.FileName.EndsWith(".txt"))
            {
                InOutUtils.Read(FileUpload1.FileContent, Travelers);
            }
            else
            {
                Label7.Visible = true;
                return;
            }

            if (FileUpload2.HasFile && FileUpload2.FileName.EndsWith(".txt"))
            {
                InOutUtils.Read(FileUpload2.FileContent, Hotels);
            }
            else
            {
                Label7.Visible = true;
                return;
            }

            Table1.ForeColor = System.Drawing.Color.Black;
            Table2.ForeColor = System.Drawing.Color.Black;

            // --------------Printing to Tables-------------- //
            string label;

            if(Travelers.IsEmpty())
            {
                label = "Turistų sąrašas tuščias";
            }
            else
            {
                label = "Turistai";
            }
            PrintFullTable(Table1, Travelers, label);
            Table1.Visible = true;

            if(Hotels.IsEmpty())
            {
                label = "Hotelių sąrašas tuščias";
            }
            else
            {
                label = "Hoteliai";
            }
            PrintFullTable(Table2, Hotels, label);
            Table2.Visible = true;
        }

        // Atstatyti button
        protected void Button3_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            Page.Dispose();
        }

        // Issaugoti duomenis button
        protected void Button4_Click(object sender, EventArgs e)
        {
            string InitialData = Server.MapPath("~/Files/InitialData.txt");

            LinkList Travelers = new LinkList();
            LinkedListHotel Hotels = new LinkedListHotel();

            // --------------Gets files from FileUpload-------------- //
            if (FileUpload1.HasFile && FileUpload1.FileName.EndsWith(".txt"))
            {
                InOutUtils.Read(FileUpload1.FileContent, Travelers);
            }
            else
            {
                Label7.Visible = true;
                return;
            }

            if (FileUpload2.HasFile && FileUpload2.FileName.EndsWith(".txt"))
            {
                InOutUtils.Read(FileUpload2.FileContent, Hotels);
            }
            else
            {
                Label7.Visible = true;
                return;
            }

            if (Travelers.IsEmpty() )
            {
                InOutUtils.PrintError(InitialData, "Turistų sąrašas tuščias");
                if(Hotels.IsEmpty())
                {
                    InOutUtils.PrintError(InitialData, "Viešbičių sąrašas tuščias");
                }
                return;
            }

            if(Hotels.IsEmpty())
            {
                InOutUtils.PrintError(InitialData, "Viešbičių sąrašas tuščias");
                return;
            }

            FileInfo file = new FileInfo(InitialData);
            if (file.Exists)
            {
                file.Delete();
            }

            Label3.Visible = true;
            Label3.Text = "✓Sėkmingai išsaugota";

            // Getting all the required lists
            double Price = Convert.ToDouble(TextBox1.Text);

            LinkedListHotel UnpickedHotels = Hotels.GetNotChosen(Travelers);
            LinkedListHotel PickedHotels = Hotels.GetPickedHotels(Travelers);
            LinkList MostStayedNights = Travelers.GetMaxStayed();
            MostStayedNights.Sort();
            LinkList MostPayed = Travelers.BellowPayedTravelers(Hotels, Price);
            MostPayed.Sort();

            InOutUtils.PrintInitial(InitialData, Travelers, "Pradiniai Turistai");
            InOutUtils.PrintInitial(InitialData, Hotels, "Pradiniai Viešbučiai");

            // --------------Printing to Tables-------------- //
            if (PickedHotels.IsEmpty())
            {
                InOutUtils.PrintError(InitialData, "Nei vienas viešbutis nebuvo pasirinktas");
                return;
            }
            else
            {
                InOutUtils.PrintInitial(InitialData, PickedHotels, "Pasirinkti Viešbučiai");
            }

            if (UnpickedHotels.IsEmpty() )
            {
                InOutUtils.PrintError(InitialData, "Visi viešbučiai buvo pasirinkti");
            }
            else
            {
                InOutUtils.PrintInitial(InitialData, UnpickedHotels, "Nepasirinkti Viešbučiai");
            }
            
            InOutUtils.PrintInitial(InitialData, MostStayedNights, "Ilgiausiai naktų likę asmenys");

            if(MostPayed.IsEmpty())
            {
                InOutUtils.PrintError(InitialData, $"Mažiau duotos sumos ({Price:N2}€), nei vienas turistas nesumokėjo");
            }
            else
            {
                InOutUtils.PrintInitial(InitialData, MostPayed, $"Sumokėjo mažiau duotos sumos({Price:N2}€)");
            }
        }
    }
}