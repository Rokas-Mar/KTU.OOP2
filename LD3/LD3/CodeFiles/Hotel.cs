using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace LD3
{
    /// <summary>
    /// Hotel Data class
    /// </summary>
    public class Hotel : IComparable<Hotel>, IEquatable<Hotel>
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
            return String.Format("| {0, -38} | {1, -30} | {2, 16:F2} |", HotelName, RoomType, Price);
        }

        public int CompareTo(Hotel other)
        {
            if ((object)other == null) return 1;
            if (HotelName.CompareTo(other.HotelName) != 0)
            {
                return HotelName.CompareTo(other.HotelName);
            }
            else
            {
                return Price.CompareTo(other.Price);
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Hotel studObj = obj as Hotel;
            if (studObj == null)
                return false;
            else
                return Equals(studObj);
        }

        /// <summary>
        /// Equals override for comparing
        /// </summary>
        /// <param name="obj">object to compare</param>
        /// <returns>true, if hotel names match, esle false</returns>
        public bool Equals(Hotel other)
        {
            if ((object)other == null)
                return false;
            if (this.HotelName == other.HotelName)
                return true;
            else
                return false;

        }

        /// <summary>
        /// GetHashCode ovveride
        /// </summary>
        /// <returns>returns base hash code</returns>
        public override int GetHashCode()
        {
            return this.HotelName.GetHashCode();
        }
    }
}