using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using static LD5.Exceptions;

namespace LD5
{
    public class InOutUtils
    {
        public static void ReadData(string dir, List<Server> Servers)
        {
            string[] filePaths = Directory.GetFiles(dir, "*.txt");
            foreach (string path in filePaths)
            {
                ReadUserData(path, Servers);
            }
        }

        public static void ReadUserData(string file, List<Server> Servers)
        {
            using (StreamReader reader = new StreamReader(@file, Encoding.GetEncoding(1257)))
            {
                int count = 2;
                string line = reader.ReadLine();
                Server server = TaskUtils.GetServerByIP(Servers, line);

                while (null != (line = reader.ReadLine()))
                {
                    try
                    {
                        server.Add(new UserLogin(line));
                        count++;
                    } catch
                    {
                        throw new WrongDataFile($"Neteisingi duomenys faile: </br> {file} </br> Eilutė: {count}");
                    }
                }
            }
        }

        public static void ReadServerData(string file, List<ServerInfo> Servers)
        {
            using (StreamReader reader = new StreamReader(@file, Encoding.GetEncoding(1257)))
            {
                string line;
                while (null != (line = reader.ReadLine()))
                {
                    string[] words = line.Split(';');
                    ServerInfo server = new ServerInfo(words[0], words[1]);
                    Servers.Add(server);
                }
            }
        }

        public static void PrintDataToFile(string file, List<Server> servers)
        {
            foreach (Server server in servers)
            {
                PrintLoginToTxt(file, server, server.Date + " " + server.IPadress);
            }
        }

        public static void PrintLoginToTxt(string file, Server council, string label)
        {
            using (var writer = new StreamWriter(file, true))
            {
                string s = new string('-', council.GetLogin(0).ToString().Length);
                writer.WriteLine(label);
                writer.WriteLine(s);
                writer.WriteLine(string.Format("| {0, -10} | {1, -18} | {2, -50} |", "Laikas", "IP", "Adresas"));
                writer.WriteLine(s);
                for (int i = 0; i < council.Count(); i++)
                {
                    writer.WriteLine(council.GetLogin(i));
                }
                writer.WriteLine(s);
                writer.WriteLine();
            }
        }

        public static void PrintServerInfoToTXT(string file, List<ServerInfo> serverInfo, string title)
        {
            using (var writer = new StreamWriter(file, true))
            {
                string s = new string('-', serverInfo[0].ToString().Length);
                writer.WriteLine(title);
                writer.WriteLine(s);
                writer.WriteLine(string.Format("| {0, -18} | {1, -50} |", "IP", "Adresas"));
                writer.WriteLine(s);
                for (int i = 0; i < serverInfo.Count(); i++)
                {
                    writer.WriteLine(serverInfo[i]);
                }
                writer.WriteLine(s);
                writer.WriteLine();
            }
        }

        public static void PrintErrorToTxt(string file, string title)
        {
            using (var writer = new StreamWriter(file, true))
            {
                writer.WriteLine($"Klaida: {title}");
            }
        }
    }
}