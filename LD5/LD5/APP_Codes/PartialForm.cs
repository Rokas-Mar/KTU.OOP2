using LD5.APP_Codes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI.WebControls;

namespace LD5
{
    public partial class Form1 : System.Web.UI.Page
    {
        public void FillDropDownList(DropDownList ddl, List<ServerInfo> servers)
        {
            servers.Select(o => o.Link).Distinct().ToList();
            foreach(var server in servers)
            {
                ddl.Items.Add(server.Link);
            }
        }

        public void PrintToTable(Server websites, string label)
        {
            Table tb = new Table();
            tb.Caption = label;
            TableRow row = new TableRow
            {
                Cells = { new TableCell { Text = "Prisijungimo laikas" },
                    new TableCell { Text = "IP adresas" },
                    new TableCell { Text = "Puslapis" } }
            };

            row.Style.Add("background-color", "rgb(161, 76, 99)");

            tb.Controls.Add(row);
            for(int i = 0; i < websites.Count(); i++)
            {
                UserLogin website = websites.GetLogin(i);
                tb.Controls.Add(new TableRow { 
                    Cells = { new TableCell { Text = website.loginTime }, 
                        new TableCell { Text = website.IPaddress }, 
                        new TableCell { Text = website.WebLink } } });
            }

            tb.CssClass = "Table list";
            tb.GridLines = GridLines.Both;

            mainDiv.Controls.Add(tb);
        }

        public void PrintToServersTable(List<ServerInfo> servers, string label)
        {
            Table tb = new Table();
            tb.Caption = label;
            TableRow row = new TableRow
            {
                Cells = { new TableCell { Text = "IP adresas" },
                    new TableCell { Text = "Adresas" } }
            };

            row.Style.Add("background-color", "rgb(161, 76, 99)");

            tb.Controls.Add(row);
            for (int i = 0; i < servers.Count(); i++)
            {
                ServerInfo server = servers[i];
                tb.Controls.Add(new TableRow
                {
                    Cells = { new TableCell { Text = server.IP },
                        new TableCell { Text = server.Link } }
                });
            }

            tb.CssClass = "Table list";
            tb.GridLines = GridLines.Both;

            mainDiv.Controls.Add(tb);
        }
    }
}