using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD5
{
    public class ServerInfo
    {
        public string IP { get; set; }
        public string Link { get; set; }

        public Form1 Server_Info
        {
            get => default;
            set
            {
            }
        }

        public ServerInfo() { }

        public ServerInfo(string IP, string Link)
        {
            this.IP = IP;
            this.Link = Link;
        }

        public override string ToString()
        {
            return string.Format("| {0, 18} | {1, -50} |", IP, Link);
        }
    }
}