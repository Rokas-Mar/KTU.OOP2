using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace LD3
{
    public partial class Form1
    {
        public LinkList<int> LinkList
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Prints traveler LinkList elements
        /// </summary>
        /// <param name="table">Table to print to</param>
        /// <param name="travelers">LinkList element</param>
        /// <param name="label">label of table</param>
        public void PrintFullTable(Table table, LinkList<Traveler> travelers, string label)
        {
            if (travelers.IsEmpty())
            {
                table.Visible = true;
                table.Width = 500;
                table.ForeColor = System.Drawing.Color.Red;
                table.Caption = label;
                return;
            }
            table.ForeColor = System.Drawing.Color.Black;
            table.Style.Add("font-family", "Segoe UI");
            table.Style.Add("font-weight", "600");
            table.Caption = label;

            TableRow row = new TableRow();

            TableCell surname = new TableCell
            {
                Text = "Pavardė"
            };
            row.Cells.Add(surname);

            TableCell name = new TableCell
            {
                Text = "Vardas"
            };
            row.Cells.Add(name);

            TableCell hotel = new TableCell
            {
                Text = "Pasirinktas hotelis"
            };
            row.Cells.Add(hotel);

            TableCell type = new TableCell
            {
                Text = "Pasirinktas Kambario tipas"
            };
            row.Cells.Add(type);

            TableCell nights = new TableCell
            {
                Text = "Nakvynių skaičius"
            };

            row.Cells.Add(nights);
            table.Rows.Add(row);
            table.Rows[0].Style.Add("color", "White");
            table.Rows[0].Style.Add("background-color", "rgb(190, 74, 85)");

            foreach (Traveler traveler in travelers)
            {
                row = new TableRow();

                surname = new TableCell();
                surname.Text = traveler.Surname;
                row.Cells.Add(surname);
                name = new TableCell();
                name.Text = traveler.Name;
                row.Cells.Add(name);
                hotel = new TableCell();
                hotel.Text = traveler.Hotel;
                row.Cells.Add(hotel);
                type = new TableCell();
                type.Text = traveler.RoomType;
                row.Cells.Add(type);
                nights = new TableCell();
                nights.Text = traveler.NightCount.ToString();
                row.Cells.Add(nights);

                table.Rows.Add(row);
            }
        }

        /// <summary>
        /// Prints Partial data to table
        /// </summary>
        /// <param name="table">Table to print to</param>
        /// <param name="travelers">LinkList element</param>
        /// <param name="label">label to print</param>
        public void PrintPartialTable(Table table, LinkList<Traveler> travelers, string label)
        {
            if (travelers.IsEmpty())
            {
                table.Visible = true;
                table.Width = 500;
                table.ForeColor = System.Drawing.Color.Red;
                table.Caption = label;
                return;
            }
            table.ForeColor = System.Drawing.Color.Black;
            table.Style.Add("font-family", "Segoe UI");
            table.Style.Add("font-weight", "600");
            table.Caption = label;

            TableRow row = new TableRow();

            TableCell surname = new TableCell
            {
                Text = "Pavardė"
            };
            row.Cells.Add(surname);

            TableCell name = new TableCell
            {
                Text = "Vardas"
            };
            row.Cells.Add(name);

            TableCell nights = new TableCell
            {
                Text = "Nakvynių skaičius"
            };
            row.Cells.Add(nights);

            table.Rows.Add(row);
            table.Rows[0].Style.Add("color", "White");
            table.Rows[0].Style.Add("background-color", "rgb(190, 74, 85)");

            for (travelers.Begin(); travelers.Exists(); travelers.Next())
            {
                row = new TableRow();

                Traveler traveler = travelers.Get();

                surname = new TableCell();
                surname.Text = traveler.Surname;
                row.Cells.Add(surname);
                name = new TableCell();
                name.Text = traveler.Name;
                row.Cells.Add(name);
                nights = new TableCell();
                nights.Text = traveler.NightCount.ToString();
                row.Cells.Add(nights);

                table.Rows.Add(row);
            }
        }

        /// <summary>
        /// Prints Hotel LinkedListHotel elements
        /// </summary>
        /// <param name="table">Table to print to</param>
        /// <param name="hotels">LinkedListHotel element</param>
        /// <param name="label">label to print to table</param>
        public void PrintFullTable(Table table, LinkList<Hotel> hotels, string label)
        {
            if (hotels.IsEmpty())
            {
                table.Visible = true;
                table.Width = 500;
                table.ForeColor = System.Drawing.Color.Red;
                table.Caption = label;
                return;
            }

            table.Caption = label;

            TableRow row = new TableRow();

            table.Style.Add("font-family", "Segoe UI");
            table.Style.Add("font-weight", "600");

            TableCell name = new TableCell();
            name.Text = "Pavadinimas";
            row.Cells.Add(name);
            TableCell type = new TableCell();
            type.Text = "Kambario tipas";
            row.Cells.Add(type);
            TableCell price = new TableCell();
            price.Text = "Kaina, €";
            row.Cells.Add(price);

            table.Rows.Add(row);
            table.Rows[0].Style.Add("color", "White");
            table.Rows[0].Style.Add("background-color", "rgb(190, 74, 85)");

            for (hotels.Begin(); hotels.Exists(); hotels.Next())
            {
                row = new TableRow();

                Hotel hotel = hotels.Get();

                name = new TableCell();
                name.Text = hotel.HotelName;
                row.Cells.Add(name);
                type = new TableCell();
                type.Text = hotel.RoomType;
                row.Cells.Add(type);
                price = new TableCell();
                price.Text = string.Format("{0:N2}", hotel.Price);
                row.Cells.Add(price);

                table.Rows.Add(row);
            }
        }
    }
}