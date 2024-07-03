using Microsoft.VisualStudio.TestTools.UnitTesting;
using LD3;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics.SymbolStore;
using System.Xml.Linq;
using System.Collections.Generic;
using System;

namespace LinkListTest
{
    [TestClass]
    public abstract class LinkListTest<T> where T : IComparable<T>, IEquatable<T>
    {
        [TestMethod]
        public void AddToEmptyLinkListFifo_ContainsTestWithSameValue_True()
        {
            T valueToAdd = this.SameValue();
            LinkList<T> list = new LinkList<T>();

            list.SetFifo(valueToAdd);
            T valueToSeek = this.SameValue();
            bool actualContains = list.Contains(valueToSeek);
            Assert.IsTrue(actualContains);
        }

        [TestMethod]
        public void AddToEmptyLinkListFifo_ContainsTestWithDiffValue_False()
        {
            T valueToAdd = this.SameValue();
            LinkList<T> list = new LinkList<T>();

            list.SetFifo(valueToAdd);
            T valueToSeek = this.DiffValue();
            bool actualContains = list.Contains(valueToSeek);
            Assert.IsFalse(actualContains);
        }

        [TestMethod]
        public void AddToEmptyLinkListLifo_ContainsTestWithSameValue_True()
        {
            T valueToAdd = this.SameValue();
            LinkList<T> list = new LinkList<T>();

            list.SetLifo(valueToAdd);
            T valueToSeek = this.SameValue();
            bool actualContains = list.Contains(valueToSeek);
            Assert.IsTrue(actualContains);
        }

        [TestMethod]
        public void AddToEmptyLinkListLifo_ContainsTestWithDiffValue_False()
        {
            T valueToAdd = this.SameValue();
            LinkList<T> list = new LinkList<T>();

            list.SetLifo(valueToAdd);
            T valueToSeek = this.DiffValue();
            bool actualContains = list.Contains(valueToSeek);
            Assert.IsFalse(actualContains);
        }

        protected abstract T SameValue();
        protected abstract T DiffValue();
    }

    [TestClass]
    public class LinkListTestWithInt : LinkListTest<int>
    {
        protected override int SameValue() => 3;
        protected override int DiffValue() => 6;
    }

    [TestClass]
    public class LinkListTestWithInt2 : LinkListTest<int>
    {
        protected override int SameValue() => 11;
        protected override int DiffValue() => 0;
    }

    [TestClass]
    public class LinkListTestWithString1 : LinkListTest<string>
    {
        protected override string SameValue() => "string1";
        protected override string DiffValue() => "123";
    }

    [TestClass]
    public class LinkListTestWithString2 : LinkListTest<string>
    {
        protected override string SameValue() => ",,,,,,,";
        protected override string DiffValue() => "      ";
    }

    [TestClass]
    public class LinkListTestWithString3 : LinkListTest<string>
    {
        protected override string SameValue() => "      ";
        protected override string DiffValue() => "&&^^";
    }

    [TestClass]
    public class LinkListTestWithTraveler : LinkListTest<Traveler>
    {
        protected override Traveler SameValue() => new Traveler("Pav1", "Var1", "Hotel1", "Tipas1", 2);
        protected override Traveler DiffValue() => new Traveler("Pav2", "Var2", "Hotel2", "Tipas2", 5);
    }

    public abstract class MyRefTests<T> : LinkListTest<T>
    where T : class, IComparable<T>, IEquatable<T>
    {
        [TestMethod]
        public void ValueAddedToEmptyList_ContainsInvokedWithNull_ReturnsFalse()
        {
            T valueToAdd = this.SameValue();

            LinkList<T> list = new LinkList<T>();
            list.SetFifo(valueToAdd);

            bool actualContains = list.Contains(null);

            Assert.IsFalse(actualContains);
        }
        [TestMethod]
        public void NullAddedToEmptyList_ContainsInvokedWithNonNull_ReturnsFalse()
        {
            LinkList<T> list = new LinkList<T>();
            list.SetFifo(null);

            T valueToSeek = this.SameValue();
            bool actualContains = list.Contains(valueToSeek);

            Assert.IsFalse(actualContains);
        }
    }

    [TestClass]
    public class RefTestWithTraveler : MyRefTests<Traveler>
    {
        protected override Traveler SameValue() => new Traveler("Pavarde1", "Vardas1", "Hotel3", "RoomType1", 5);
        protected override Traveler DiffValue() => new Traveler("Pavarde2", "Vardas2", "Hotel2", "RoomType2", 5);
    }

    [TestClass]
    public class RefTestWithHotel : MyRefTests<Hotel>
    {
        protected override Hotel SameValue() => new Hotel("Pav1", "Tipas1", 50.30);
        protected override Hotel DiffValue() => new Hotel("Pav2", "Tipas2", 150.30);
    }

    //---------------- SORT TEST ----------------//
    [TestClass]
    public abstract class LinkListSortTests<T> where T : IComparable<T>, IEquatable<T>
    {
        [TestMethod]
        public void SortTest_ReturnsTrue()
        {

            LinkList<T> testList = new LinkList<T>();
            testList.SetFifo(Biggest());
            testList.SetFifo(Medium());
            testList.SetFifo(Big());
            testList.SetFifo(Smallest());
            testList.SetFifo(Smaller());

            testList.Sort();

            bool isEqual = false;
            testList.Begin();
            if (testList.Get().Equals(Smallest()))
            {
                testList.Next();
                if (testList.Get().Equals(Smaller()))
                {
                    testList.Next();
                    if (testList.Get().Equals(Medium()))
                    {
                        testList.Next();
                        if (testList.Get().Equals(Big()))
                        {
                            testList.Next();
                            if (testList.Get().Equals(Biggest()))
                                isEqual = true;
                        }
                    }
                }
            }

            Assert.IsTrue(isEqual);
        }
        protected abstract T Smallest();
        protected abstract T Smaller();
        protected abstract T Medium();
        protected abstract T Big();
        protected abstract T Biggest();
    }

    [TestClass]
    public class MySortTestWithInt1 : LinkListSortTests<int>
    {
        protected override int Smallest() => 1;
        protected override int Smaller() => 2;
        protected override int Medium() => 5;
        protected override int Big() => 10;
        protected override int Biggest() => 15;
    }

    [TestClass]
    public class MySortTestWithInt2 : LinkListSortTests<int>
    {
        protected override int Smallest() => 5;
        protected override int Smaller() => 10;
        protected override int Medium() => 15;
        protected override int Big() => 20;
        protected override int Biggest() => 25;
    }

    [TestClass]
    public class MySortTestWithHotel1 : LinkListSortTests<Hotel>
    {
        protected override Hotel Smallest() => new Hotel("Pavadinimas1", "KambarioTipas1", 20);
        protected override Hotel Smaller() => new Hotel("Pavadinimas2", "KambarioTipas1", 25);
        protected override Hotel Medium() => new Hotel("Pavadinimas3", "KambarioTipas1", 22);
        protected override Hotel Big() => new Hotel("Pavadinimas4", "KambarioTipas1", 23);
        protected override Hotel Biggest() => new Hotel("Pavadinimas5", "KambarioTipas1", 24);
    }

    [TestClass]
    public class MySortTestWithHotel2 : LinkListSortTests<Hotel>
    {
        protected override Hotel Smallest() => new Hotel("Pavadinimas1", "KambarioTipas1", 20);
        protected override Hotel Smaller() => new Hotel("Pavadinimas2", "KambarioTipas1", 25);
        protected override Hotel Medium() => new Hotel("Pavadinimas4", "KambarioTipas1", 22);
        protected override Hotel Big() => new Hotel("Pavadinimas4", "KambarioTipas1", 23);
        protected override Hotel Biggest() => new Hotel("Pavadinimas4", "KambarioTipas1", 24);
    }

    [TestClass]
    public class MySortTestWithTraveler : LinkListSortTests<Traveler>
    {
        protected override Traveler Smallest() => new Traveler("Pavarde1", "Vardas1", "Hotel1", "KambarioTipas1", 5);
        protected override Traveler Smaller() => new Traveler("Pavarde2", "Vardas1", "Hotel1", "KambarioTipas1", 5);
        protected override Traveler Medium() => new Traveler("Pavarde3", "Vardas1", "Hotel1", "KambarioTipas1", 5);
        protected override Traveler Big() => new Traveler("Pavarde4", "Vardas1", "Hotel1", "KambarioTipas1", 5);
        protected override Traveler Biggest() => new Traveler("Pavarde4", "Vardas2", "Hotel1", "KambarioTipas1", 5);
    }

    [TestClass]
    public class IsEmptyTest
    {
        [TestMethod]
        public void EmptyList_True()
        {
            LinkList<Traveler> list = new LinkList<Traveler>();
            bool actualIsEqual = list.IsEmpty();
            Assert.IsTrue(actualIsEqual);
        }
        [TestMethod]
        public void ItemInList_False()
        {
            LinkList<Traveler> list = new LinkList<Traveler>();
            list.SetFifo(new Traveler("Pavarde", "Vardas", "Hotel", "KambarioTipas", 3));
            bool actualIsEqual = list.IsEmpty();
            Assert.IsFalse(actualIsEqual);
        }
        [TestMethod]
        public void FiveItemsInList_False()
        {
            LinkList<int> list = new LinkList<int>();
            list.SetFifo(1);
            list.SetFifo(2);
            list.SetFifo(3);
            list.SetFifo(4);
            list.SetFifo(5);
            bool actualIsEqual = list.IsEmpty();
            Assert.IsFalse(actualIsEqual);
        }
    }
}