using System.Data;
using System.Linq;
using System.Xml;
using System.Linq.Expressions;
using System.Xml.Linq;
using System.Net.Security;
using System.IO;
using System.Collections.Generic;
using static LD5.Exceptions;
using System.Text.RegularExpressions;

namespace LD5
{
    public class TaskUtils
    {
        public static Server GetServerByIP(List<Server> Servers, string line)
        {
            string[] words = line.Split(';');
            foreach (var server in from Server server in Servers
                                   where server.IPadress == words[1]
                                   select server)
            {
                return server;
            }

            Servers.Add(new Server(words[0], words[1]));
            return Servers[Servers.Count() - 1];
        }

        public static string GetIPfromLink(List<ServerInfo> Servers, string link)
        {
            if (link == "Pasirinkite svetainę")
            {
                throw new WrongDataFile("Nepasirinkta svetainė");
            }
            var servers = Servers.FirstOrDefault(n => n.Link == link).IP;

            return servers;
        }

        public static Server GetWebSites(List<Server> Servers, string ip)
        {
            List<UserLogin> websites = Servers 
                .SelectMany(s => s.GetLoginsForIP(ip))
                .Distinct(new UserLoginComparer())
                .ToList();

            Server ser = new Server();
            foreach(var website in websites)
            {
                ser.Add(website);
            }

            if (websites.Count == 0)
                throw new ListIsEmptyException("Puslapiu nerasta");
            return ser;
        }
    }
}