using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD2
{
    public class HotelNode
    {
        public Hotel Data { get; private set; }
        public HotelNode Link { get; set; }

        public HotelNode(Hotel data, HotelNode link)
        {
            Data = data;
            Link = link;
        }
    }
}