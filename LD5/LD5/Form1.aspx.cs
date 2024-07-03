using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Reflection.Emit;
using static LD5.Exceptions;


namespace LD5
{
    public partial class Form1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            DropDownList1.Visible = false;
            Button2.Visible = false;
            Label1.Visible = false;
            Label1.Text = string.Empty;

            Session["DataDir"] = Server.MapPath("~/Data");
            Session["Res"] = Server.MapPath("~/Results/Res.txt");
            Session["ServerData"] = Server.MapPath("~/Server Data/Servers.txt");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DropDownList1.Items.Clear();
            DropDownList1.Items.Add("Pasirinkite svetainę");
            List<ServerInfo> Server_Info = new List<ServerInfo>();
            List<Server> Servers = new List<Server>();
            string DataDir = (string)Session["DataDir"];
            string Res = (string)Session["Res"];
            string ServerData = (string)Session["ServerData"];

            try
            {
                InOutUtils.ReadServerData(ServerData, Server_Info);
            } catch
            {
                Label1.Visible = true;
                Label1.Text += "Neteisingi duomenys";
                return;
            }
            Session["info"] = Server_Info;
            FillDropDownList(DropDownList1, Server_Info);

            File.WriteAllText(Res, "");
            Session["Server"] = Servers;
            try
            {
                InOutUtils.ReadData(DataDir, Servers);
            } catch (WrongDataFile ex)
            {
                Label1.Visible = true;
                Label1.Text += ex.Message;
                InOutUtils.PrintErrorToTxt(Res, ex.Message);
                return;
            }
            InOutUtils.PrintDataToFile(Res, Servers);
            InOutUtils.PrintServerInfoToTXT(Res, Server_Info, "Serveriai");
            foreach (Server server in Servers)
            {
                PrintToTable(server, server.Date + " " + server.IPadress);
            }
            PrintToServersTable(Server_Info, "Serveriai");

            DropDownList1.Visible = true;
            Button2.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string Res = (string)Session["Res"];

            List<ServerInfo> Servers_Info = (List<ServerInfo>)Session["info"];
            List<Server> Servers = (List<Server>)Session["Server"];

            DropDownList1.Visible = true;
            Button2.Visible = true;

            string ip;
            string selected = DropDownList1.SelectedValue;
            try
            {
                ip = TaskUtils.GetIPfromLink(Servers_Info, selected);
            } catch
            {
                Label1.Text += "Pasirinkite svetainę";
                Label1.Visible = true;
                return;
            }
            Server chosen = new LD5.Server();
            try
            {
                chosen = TaskUtils.GetWebSites(Servers, ip);
            }
            catch
            {
                Label1.Text += "Puslapių nerasta";
                Label1.Visible = true;
                InOutUtils.PrintErrorToTxt(Res, "!Puslapių nerasta");
                return;
            }
            chosen.Sort();
            PrintToTable(chosen, "Atrinkti puslapiai");
            InOutUtils.PrintLoginToTxt(Res, chosen, "Atrinkti puslapiai");
        }
    }
}