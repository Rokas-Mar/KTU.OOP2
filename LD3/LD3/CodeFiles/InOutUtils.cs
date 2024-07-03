using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI.WebControls;
using System.Collections;

namespace LD3
{
    /// <summary>
    /// Class of all printing and reading from files
    /// </summary>
    public static class InOutUtils
    {
        /// <summary>
        /// Reads Travelers from given file
        /// </summary>
        /// <param name="textFile">Stream element</param>
        /// <param name="List">LinkList element</param>
        public static void Read<type>(Stream textFile, LinkList<Traveler> List)
        {
            string surname;
            string name;
            string hotel;
            string roomType;
            int nightCount;

            string line;
            using (var file = new StreamReader(textFile))
            {
                while ((line = file.ReadLine()) != null)
                {
                    string[] words = line.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                    surname = words[0];
                    name = words[1];
                    hotel = words[2];
                    roomType = words[3];
                    nightCount = Convert.ToInt32(words[4]);

                    var traveler = new Traveler(surname, name, hotel, roomType, nightCount);

                    if (!List.Contains(traveler))
                        List.SetFifo(traveler);
                }
            }
        }

        /// <summary>
        /// Reads Hotels from given file
        /// </summary>
        /// <param name="textFile">Stream element</param>
        /// <param name="List">Hotel element</param>
        public static void Read<type>(Stream textFile, LinkList<Hotel> List)
        {
            string hotelName;
            string roomType;
            double price;

            string line;
            using (var file = new System.IO.StreamReader(textFile))
            {
                while ((line = file.ReadLine()) != null)
                {
                    string[] words = line.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                    hotelName = words[0];
                    roomType = words[1];
                    price = Convert.ToDouble(words[2]);

                    Hotel hotel = new Hotel(hotelName, roomType, price);
                    if (!List.Contains(hotel))
                        List.SetFifo(hotel);
                }
            }
        }

        /// <summary>
        /// Prints initial Traveler data to txt file
        /// </summary>
        /// <param name="fileName">file to print to</param>
        /// <param name="travelers">Traveler list element</param>
        /// <param name="label">label to print</param>
        public static void PrintInitial(string fileName, IEnumerable Data, string label)
        {
            using (var file = new StreamWriter(fileName, true))
            {
                file.WriteLine(string.Format(new String('-', 94)));
                file.WriteLine("| {0, -90} |", label);
                file.WriteLine(string.Format(new String('-', 94)));
                var enumerator = Data.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    object item = enumerator.Current;
                    file.WriteLine(item.ToString());
                }
                file.WriteLine(string.Format(new String('-', 94)));
                file.WriteLine();
            }
        }

        /// <summary>
        /// Prints given error to txt
        /// </summary>
        /// <param name="fileName">fileName</param>
        /// <param name="error">error to print to txt</param>
        public static void PrintError(string fileName, string error)
        {
            using (var file = new System.IO.StreamWriter(fileName, true))
            {
                file.WriteLine(error);
            }
        }
    }
}
