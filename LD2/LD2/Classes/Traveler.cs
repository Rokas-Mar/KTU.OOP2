using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD2
{
    /// <summary>
    /// Traveler data class
    /// </summary>
    public class Traveler
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Hotel { get; set; }
        public string RoomType { get; set; }
        public int NightCount { get; set; }

        public Traveler(string surname, string name, string hotel, string roomType, int nightCount)
        {
            Surname = surname;
            Name = name;
            Hotel = hotel;
            RoomType = roomType;
            NightCount = nightCount;
        }

        public Traveler()
        {
        }

        /// <summary>
        /// ToString override
        /// </summary>
        /// <returns>A formated string line</returns>
        public override string ToString()
        {
            return String.Format("| {0, -20} | {1, -15} | {2, -20} | {3, -15} | {4, 8} |", Surname, Name, Hotel, RoomType, NightCount);
        }

        /// <summary>
        /// operator < override 
        /// </summary>
        /// <param name="lhs">Traveler element</param>
        /// <param name="rhs">Traveler element</param>
        /// <returns>true if lhs surname is alphabetically more than rhs surname or lhs name is more than rhs, else false</returns>
        public static bool operator <(Traveler lhs, Traveler rhs)
        {
            int SurId = String.Compare(lhs.Surname, rhs.Surname, StringComparison.CurrentCulture);
            int NamId = String.Compare(lhs.Name, rhs.Name, StringComparison.CurrentCulture);

            return SurId > 0 || SurId == 0 && NamId > 0; 
        }

        /// <summary>
        /// operator > override 
        /// </summary>
        /// <param name="lhs">Traveler element</param>
        /// <param name="rhs">Traveler element</param>
        /// <returns>true if lhs surname is alphabetically less than rhs surname or lhs name is less than rhs, else false</returns>
        public static bool operator >(Traveler lhs, Traveler rhs)
        {
            return !(lhs < rhs);
        }

        /// <summary>
        /// Equals override for comparing
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return this.Surname == ((Traveler)obj).Surname && this.Name == ((Traveler)obj).Name;
        }

        /// <summary>
        /// GetHashCode override
        /// </summary>
        /// <returns>base hash code</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}