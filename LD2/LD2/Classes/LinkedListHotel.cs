using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD2
{
    /// <summary>
    /// Hotel custom LinkList
    /// </summary>
    public class LinkedListHotel
    {
        private HotelNode Head;
        private HotelNode Tail;
        private HotelNode HeadFifo;
        private HotelNode d;

        public LinkedListHotel()
        {
            Tail = new HotelNode(null, null);
            Head = new HotelNode(new Hotel(), Tail);
            HeadFifo = Head;
            d = null;
        }

        public HotelNode HotelNode
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Sets first element of list
        /// </summary>
        /// <param name="hotel">Hotel class element</param>
        public void SetLifo(Hotel hotel)
        {
            Head.Link = new HotelNode(hotel, Head.Link);
        }

        /// <summary>
        /// Sets end element of list
        /// </summary>
        /// <param name="hotel">Hotel class element</param>
        public void SetFifo(Hotel hotel)
        {
            HeadFifo.Link = new HotelNode(hotel, Tail);
            HeadFifo = HeadFifo.Link;
        }

        /// <summary>
        /// Starts list
        /// </summary>
        public void Begin()
        {
            d = Head.Link;
        }

        /// <summary>
        /// continues to the next element in list
        /// </summary>
        public void Next()
        {
            d = d.Link;
        }

        /// <summary>
        /// Checks if element is not null
        /// </summary>
        /// <returns>true if element is not null, else false</returns>
        public bool Exists()
        {
            return d.Data != null;
        }

        /// <summary>
        /// Gets Hotel element
        /// </summary>
        /// <returns>Hotel LinkedListHotel element</returns>
        public Hotel Get()
        {
            return d.Data;
        }

        /// <summary>
        /// Checks if List is empty
        /// </summary>
        /// <returns>true if empty, else false</returns>
        public bool IsEmpty()
        {
            return Head.Link == Tail;
        }

        /// <summary>
        /// Gets hotel price by name
        /// </summary>
        /// <param name="HotelName">String element of hotel name</param>
        /// <returns>double of Hotels price per night</returns>
        public double GetHotelPrice(string HotelName)
        {
            for(this.Begin(); this.Exists(); this.Next())
            {
                Hotel hotel = this.Get();
                if(hotel.HotelName == HotelName)
                {
                    return hotel.Price;
                }
            }

            return 0;
        }

        /// <summary>
        /// Checks if List contains Hotel
        /// </summary>
        /// <param name="hotel">Hotel class element</param>
        /// <returns>true if List contains element, else false</returns>
        public bool Contains(Hotel hotel)
        {
            for(this.Begin(); this.Exists(); this.Next())
            {
                Hotel Thodel = this.Get();
                if(Thodel.Equals(hotel))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Gets all picked hotels by travelers
        /// </summary>
        /// <param name="travelers">LinkList element</param>
        /// <returns>LinkedListHotel of picked hotels</returns>
        public LinkedListHotel GetPickedHotels(LinkList travelers)
        {
            LinkedListHotel ResultHotels = new LinkedListHotel();

            for (this.Begin(); this.Exists(); this.Next())
            {
                Hotel hotel = this.Get();
                if (travelers.ContainsHotel(hotel) && !ResultHotels.Contains(hotel))
                {
                    ResultHotels.SetFifo(hotel);
                }
            }

            return ResultHotels;
        }

        /// <summary>
        /// Gets all NOT picked hotels by travelers
        /// </summary>
        /// <param name="travelers">LinkList element</param>
        /// <returns>LinkedListHotel of NOT picked hotels</returns>
        public LinkedListHotel GetNotChosen(LinkList travelers)
        {
            LinkedListHotel ResultHotels = new LinkedListHotel();

            for (this.Begin(); this.Exists(); this.Next())
            {
                Hotel hotel = this.Get();
                if (!travelers.ContainsHotel(hotel) && !ResultHotels.Contains(hotel))
                {
                    ResultHotels.SetFifo(hotel);
                }
            }

            return ResultHotels;
        }
    }
}