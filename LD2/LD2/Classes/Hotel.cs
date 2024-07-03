using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace LD2
{
    /// <summary>
    /// Hotel Data class
    /// </summary>
    public class Hotel
    {
        public string HotelName { get; set; }
        public string RoomType { get; set; }
        public double Price { get; set; }

        public Hotel(string hotelName, string roomType, double price)
        {
            HotelName = hotelName;
            RoomType = roomType;
            Price = price;
        }

        public Hotel()
        { }

        /// <summary>
        /// ToString override
        /// </summary>
        /// <returns>returns a formated string</returns>
        public override string ToString()
        {
            return String.Format("| {0, -20} | {1, -15} | {2, 8:F2} |", HotelName, RoomType, Price);
        }

        /// <summary>
        /// Equals override for comparing
        /// </summary>
        /// <param name="obj">object to compare</param>
        /// <returns>true, if hotel names match, esle false</returns>
        public override bool Equals(object obj)
        {
            return this.HotelName == ((Hotel)obj).HotelName;
        }

        /// <summary>
        /// GetHashCode ovveride
        /// </summary>
        /// <returns>returns base hash code</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}