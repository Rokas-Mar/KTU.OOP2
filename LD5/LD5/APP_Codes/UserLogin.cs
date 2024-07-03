using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using static LD5.Exceptions;
using static System.Net.Mime.MediaTypeNames;

namespace LD5
{
    public class UserLogin
    {
        public string loginTime {  get; set; }
        public string IPaddress { get; set; }
        public string WebLink { get; set; }

        public Server Logins
        {
            get => default;
            set
            {
            }
        }

        public UserLogin(string loginTime, string IPaddress, string WebLink)
        {
            this.loginTime = loginTime;
            this.IPaddress = IPaddress;
            this.WebLink = WebLink;
        }

        public UserLogin() 
        {
            loginTime = "0/0/0 00:00:00";
            IPaddress = "000.000.000.000";
            WebLink = string.Empty;
        }

        public UserLogin(string line)
        {
            SetData(line);
        }

        public virtual void SetData(string line)
        {
            try
            {
                string[] words = line.Split(';');
                if (!Regex.IsMatch(words[0], "[0-9]+:[0-9]+:[0-9]+"))
                    throw new WrongDataFile("neteisingi duomenys");
                if (!Regex.IsMatch(words[1], "[0-9]+.[0-9]+.[0-9]+.[0-9]+"))
                    throw new WrongDataFile("neteisingi duomenys");
                loginTime = words[0];
                IPaddress = words[1];
                WebLink = words[2];
            }
            catch
            {
                throw new WrongDataFile("Neteisingi duomenys");
            }

        }

        public override string ToString()
        {
            return string.Format("| {0, 10} | {1, 18} | {2, -50} |", loginTime, IPaddress, WebLink);
        }
    }
}