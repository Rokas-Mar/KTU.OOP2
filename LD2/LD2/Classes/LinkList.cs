using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace LD2
{
    /// <summary>
    /// Class for custom Linked List
    /// </summary>
    public sealed class LinkList
    {
        private sealed class Node
        {
            public Traveler Data { get; set; }
            public Node Link { get; set; }

            public Node(Traveler data, Node link)
            {
                Data = data;
                Link = link;
            }

            public Node()
            { }
        }


        private Node Head;
        private Node Tail;
        private Node headFifo;
        private Node d;

        public LinkList()
        {
            Tail = new Node(null, null);
            Head = new Node(new Traveler(), Tail);
            headFifo = Head;
            d = null;
        }

        public Traveler Data
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Sets first element of list
        /// </summary>
        /// <param name="traveler">Traveler class element</param>
        public void SetLifo(Traveler traveler)
        {
            Head.Link = new Node(traveler, Head.Link);
        }

        /// <summary>
        /// Sets end element of list
        /// </summary>
        /// <param name="traveler">Traveler class element</param>
        public void SetFifo(Traveler traveler)
        {
            headFifo.Link = new Node(traveler, Tail);
            headFifo = headFifo.Link;
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
            return d.Link != null;
        }

        /// <summary>
        /// Gets Traveler element
        /// </summary>
        /// <returns>Traveler element marked by d</returns>
        public Traveler Get()
        {
            return d.Data;
        }

        /// <summary>
        /// Checks if list is empty
        /// </summary>
        /// <returns>true if empty, else false</returns>
        public bool IsEmpty()
        {
            return Head.Link == Tail;
        }

        /// <summary>
        /// Checks if list contains Traveler element
        /// </summary>
        /// <param name="traveler">Traveler element</param>
        /// <returns>true, if list contains traveler, else false</returns>
        public bool Contains(Traveler traveler)
        {
            for (Begin(); Exists(); Next())
            {
                if (d.Data.Equals(traveler))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if Traveler picked hotel exists in Hotel List
        /// </summary>
        /// <param name="hotel">LinkedListHotel element</param>
        /// <returns>true, if contains, else false</returns>
        public bool ContainsHotel(Hotel hotel)
        {
            for (this.Begin(); this.Exists(); this.Next())
            {
                if (hotel.HotelName == this.Get().Hotel)
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
        public int GetMaxNights()
        {
            int maxCount = 0;
            for(this.Begin(); this.Exists(); this.Next())
            {
                if(this.Get().NightCount > maxCount)
                {
                    maxCount = this.Get().NightCount;
                }
            }

            return maxCount;
        }

        /// <summary>
        /// Gets Travelets, who stayed the max nights
        /// </summary>
        /// <returns>Travelers LinkList</returns>
        public LinkList GetMaxStayed()
        {
            LinkList ResultTravelers = new LinkList();

            int maxCount = this.GetMaxNights();

            for(this.Begin(); this.Exists(); this.Next())
            {
                Traveler traveler = this.Get();
                if(traveler.NightCount == maxCount)
                {
                    ResultTravelers.SetFifo(traveler);
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
        public LinkList BellowPayedTravelers(LinkedListHotel hotels, double maxPayed)
        {
            LinkList ResultTravelers = new LinkList();

            for(this.Begin(); this.Exists(); this.Next())
            {
                if(maxPayed >= this.Get().NightCount * hotels.GetHotelPrice(this.Get().Hotel))
                {
                    ResultTravelers.SetFifo(this.Get());
                }
            }

            return ResultTravelers;
        }

        /// <summary>
        /// Bubble sorts LinkList
        /// </summary>
        public void Sort()
        {
            if(Head.Link.Link == null)
            { return; }

            bool done = true;
            while(done)
            {
                done = false;
                var head = Head.Link;
                while(head.Link.Link != null)
                {
                    if(head.Data < head.Link.Data)
                    {
                        Traveler temp = head.Data;
                        head.Data = head.Link.Data;
                        head.Link.Data = temp;
                        done = true;
                    }
                    head = head.Link;
                }
            }
        }
    }
}