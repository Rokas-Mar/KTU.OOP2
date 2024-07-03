using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LD3
{
    /// <summary>
    /// Class for custom Linked List
    /// </summary>
    public class LinkList<type> : IEnumerable<type> where type : IComparable<type>, IEquatable<type>
    {
        private sealed class Node<nodeType> where nodeType : IComparable<nodeType>, IEquatable<nodeType>
        {
            public nodeType Data { get; set; }
            public Node<nodeType> Link { get; set; }

            public Node(nodeType data, Node<nodeType> link)
            {
                Data = data;
                Link = link;
            }

            public Node()
            {

            }
        }

        private Node<type> Head;
        private Node<type> Tail;
        private Node<type> headFifo;
        private Node<type> d;

        public LinkList()
        {
            Tail = null;
            Head = null;
        }

        public Hotel Hotel
        {
            get => default;
            set
            {
            }
        }

        public Traveler Traveler
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
        public void SetLifo(type data)
        {
            Head = new Node<type>(data, Head);
        }

        /// <summary>
        /// Sets end element of list
        /// </summary>
        /// <param name="traveler">Traveler class element</param>
        public void SetFifo(type data)
        {
            var dd = new Node<type>(data, null);
            if (Head != null)
            {
                Tail.Link = dd;
                Tail = dd;
            }
            else
            {
                Head = dd;
                Tail = dd;
            }
        }

        /// <summary>
        /// Starts list
        /// </summary>
        public void Begin()
        {
            d = Head;
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
            return d != null;
        }

        /// <summary>
        /// Gets Traveler element
        /// </summary>
        /// <returns>Traveler element marked by d</returns>
        public type Get()
        {
            return d.Data;
        }

        /// <summary>
        /// Checks if list is empty
        /// </summary>
        /// <returns>true if empty, else false</returns>
        public bool IsEmpty()
        {
            return Head == null;
        }

        public IEnumerator<type> GetEnumerator()
        {
            for (Node<type> s = Head; s != null; s = s.Link)
            {
                yield return s.Data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Bubble sorts LinkList
        /// </summary>
        public void Sort()
        {
            for (Node<type> d1 = Head; d1 != null; d1 = d1.Link)
            {
                Node<type> maxv = d1;
                for (Node<type> d2 = d1; d2 != null; d2 = d2.Link)
                    if (d2.Data.CompareTo(maxv.Data) == -1)
                        maxv = d2;
                type St = d1.Data;
                d1.Data = maxv.Data;
                maxv.Data = St;
            }

        }
    }
}