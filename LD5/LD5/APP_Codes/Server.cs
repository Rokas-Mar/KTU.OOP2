using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace LD5
{
    public class Server
    {
        public string Date { get; set; }
        public string IPadress { get; set; }

        public Form1 Servers
        {
            get => default;
            set
            {
            }
        }

        private readonly List<UserLogin> Logins;

        public Server()
        {
            Logins = new List<UserLogin>();
        }

        public Server(string date, string iPadress)
        {
            Date = date;
            IPadress = iPadress;
            Logins = new List<UserLogin>();
        }

        public void Add(UserLogin login)
        {
            Logins.Add(login);
        }

        public UserLogin GetLogin(int index)
        {
            return Logins[index];
        }

        public int Count()
        {
            return Logins.Count;
        }

        public List<UserLogin> GetLogins()
        {
            return Logins;
        }

        public List<UserLogin> GetLoginsForIP(string ipAddress)
        {
            return Logins
                .Where(l => l.IPaddress == ipAddress)
                .Distinct(new UserLoginComparer())
                .ToList();
        }

        public UserLogin GetUserLogin(string ipAddress)
        {
            return Logins.FirstOrDefault(l => l.IPaddress == ipAddress);
        }

        public void Sort()
        {
            Logins.OrderByDescending(u => u.IPaddress)
            .ThenBy(u => u.loginTime)
            .ToList();
        }
    }
}