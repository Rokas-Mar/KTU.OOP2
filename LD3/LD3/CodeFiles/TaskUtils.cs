using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD3
{
    public static class TaskUtils
    {

        /// <summary>
        /// Checks if Traveler picked hotel exists in Hotel List
        /// </summary>
        /// <param name="hotel">LinkedListHotel element</param>
        /// <returns>true, if contains, else false</returns>
        public static bool ContainsHotel(LinkList<Traveler> travelers, Hotel hotel)
        {
            foreach (Traveler data in travelers)
            {
                if (hotel.HotelName == data.Hotel)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Gets Max ammount of nights stayed by a traveler
        /// </summary>
        /// <returns>intiger of max nights slept</returns>
        public static int GetMaxNights(LinkList<Traveler> travelers)
        {
            int maxCount = 0;
            foreach (Traveler data in travelers)
            {
                if ((data as Traveler).NightCount > maxCount)
                {
                    maxCount = (data as Traveler).NightCount;
                }
            }

            return maxCount;
        }

        /// <summary>
        /// Gets Travelets, who stayed the max nights
        /// </summary>
        /// <returns>Travelers LinkList</returns>
        public static LinkList<Traveler> GetMaxStayed(LinkList<Traveler> travelers)
        {
            LinkList<Traveler> ResultTravelers = new LinkList<Traveler>();

            int maxCount = GetMaxNights(travelers);

            foreach (Traveler data in travelers)
            {
                Traveler traveler = data as Traveler;
                if (traveler.NightCount == maxCount)
                {
                    ResultTravelers.SetFifo(data);
                }
            }

            return ResultTravelers;
        }

        /// <summary>
        /// Gets Travelers, who payed bellow the given price
        /// </summary>
        /// <param name="hotels">LinkedListHotel element</param>
        /// <param name="maxPayed">price given by user</param>
        /// <returns>LinkedList of travelers who payed bellow given price</returns>
        public static LinkList<Traveler> BellowPayedTravelers(LinkList<Traveler> travelers, LinkList<Hotel> hotels, double maxPayed)
        {
            LinkList<Traveler> ResultTravelers = new LinkList<Traveler>();

            foreach (Traveler data in travelers)
            {
                if (maxPayed >= (data as Traveler).NightCount * GetHotelPrice(hotels, data.Hotel))
                {
                    ResultTravelers.SetFifo(data);
                }
            }

            return ResultTravelers;
        }

        /// <summary>
        /// Gets hotel price by name
        /// </summary>
        /// <param name="HotelName">String element of hotel name</param>
        /// <returns>double of Hotels price per night</returns>
        public static double GetHotelPrice(LinkList<Hotel> hotels, string HotelName)
        {
            foreach (Hotel data in hotels)
            {
                if (data.HotelName == HotelName)
                {
                    return data.Price;
                }
            }

            return 0;
        }

        /// <summary>
        /// Gets all picked hotels by travelers
        /// </summary>
        /// <param name="travelers">LinkList element</param>
        /// <returns>LinkedListHotel of picked hotels</returns>
        public static LinkList<Hotel> GetPickedHotels(LinkList<Traveler> travelers, LinkList<Hotel> hotels)
        {
            LinkList<Hotel> ResultHotels = new LinkList<Hotel>();

            foreach (Hotel data in hotels)
            {
                if (ContainsHotel(travelers, data) && !ResultHotels.Contains(data))
                {
                    ResultHotels.SetFifo(data);
                }
            }

            return ResultHotels;
        }

        /// <summary>
        /// Gets all NOT picked hotels by travelers
        /// </summary>
        /// <param name="travelers">LinkList element</param>
        /// <returns>LinkedListHotel of NOT picked hotels</returns>
        public static LinkList<Hotel> GetNotChosen(LinkList<Hotel> hotels, LinkList<Traveler> travelers)
        {
            LinkList<Hotel> ResultHotels = new LinkList<Hotel>();

            foreach (Hotel data in hotels)
            {
                if (!ContainsHotel(travelers, data) && !ResultHotels.Contains(data))
                {
                    ResultHotels.SetFifo(data);
                }
            }

            return ResultHotels;
        }
    }
}