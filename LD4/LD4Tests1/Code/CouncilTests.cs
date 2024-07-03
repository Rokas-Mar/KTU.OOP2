using Microsoft.VisualStudio.TestTools.UnitTesting;
using LD4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD4.Tests
{
    [TestClass]
    public abstract class CouncilTests
    {
        [TestMethod]
        public void GetTest()
        {
            Council council = new Council();
            council.Add(this.SameQuestion());
            Question valueToSeek = council.Get(0);

            Assert.AreEqual(this.SameQuestion().Text, valueToSeek.Text);
        }

        protected abstract Question SameQuestion();

        protected abstract string difficulty();
        protected abstract string Topic();
        protected abstract string MostCommonAuth();
        protected abstract int AuthCount();

        [TestMethod()]
        public void GetDifficultyTest()
        {
            Council council = new Council();
            council.Add(new Question("topic1", "diff1", "author1", "abc", "abc", 20));
            council.Add(new Question("topic2", "diff2", "author2", "abc", "abc", 25));

            Council newCouncil = new Council();
            council.GetDifficulty(newCouncil, difficulty());

            for (int i = 0; i < newCouncil.Count(); i++)
            {
                Assert.AreEqual(newCouncil.Get(i).Difficulty, difficulty());
            }
        }

        [TestMethod()]
        public void GetMostCommonAuthorTest_True()
        {
            Council council = new Council();
            council.Add(new Question("topic1", "diff1", "common", "abc", "abc", 20));
            council.Add(new Question("topic2", "diff2", "common", "abc", "abc", 25));
            council.Add(new Question("topic1", "diff1", "ads", "abc", "abc", 20));
            council.Add(new Question("topic2", "diff2", "asd", "abc", "abc", 25));

            Council newCouncil = new Council();
            council.GetMostCommonAuthor(out int count);

            for (int i = 0; i < newCouncil.Count(); i++)
            {
                Assert.AreEqual(newCouncil.Get(i).Author, MostCommonAuth());
                Assert.AreEqual(count, AuthCount());
            }
        }

        [TestMethod()]
        public void GetMostCommonAuthorTest_False()
        {
            Council council = new Council();
            council.Add(new Question("topic1", "diff1", "common", "abc", "abc", 20));
            council.Add(new Question("topic2", "diff2", "ads", "abc", "abc", 25));
            council.Add(new Question("topic1", "diff1", "ads", "abc", "abc", 20));
            council.Add(new Question("topic2", "diff2", "asd", "abc", "abc", 25));

            Council newCouncil = new Council();
            council.GetMostCommonAuthor(out int count);

            for (int i = 0; i < newCouncil.Count(); i++)
            {
                Assert.AreNotEqual(newCouncil.Get(i).Author, MostCommonAuth());
                Assert.AreNotEqual(count, AuthCount());
            }
        }

        [TestMethod()]
        public void GetTypeTest()
        {
            Council council = new Council();
            Council newCouncil = new Council();
            council.Add(new MusicQuestion("topic1", "diff1", "common", "abc", "abc", 20, "file1"));
            council.Add(new MusicQuestion("topic2", "diff2", "ads", "abc", "abc", 25, "file1"));
            council.Add(new MusicQuestion("topic1", "diff1", "ads", "abc", "abc", 20, "file1"));
            council.Add(new MusicQuestion("topic2", "diff2", "asd", "abc", "abc", 25, "file1"));

            council.GetType(newCouncil, typeof(MusicQuestion));

            for (int i = 0; i < newCouncil.Count(); i++)
            {
                Assert.AreEqual(newCouncil.Get(i).GetType(), typeof(MusicQuestion));
            }
        }
    }

    [TestClass]
    public class CouncilGetTest : CouncilTests
    {
        protected override Question SameQuestion() => new Question("topic1", "diff1", "author1", "abc", "abc", 20);

        protected override string difficulty() => "diff1";
        protected override string Topic() => "Linksmasis";
        protected override string MostCommonAuth() => "Common";
        protected override int AuthCount() => 2;
    }

    [TestClass]
    public class CouncilGetTest2 : CouncilTests
    {
        protected override Question SameQuestion() => new Question("topic2", "diff2", "author1", "abc", "abc", 20);

        protected override string difficulty() => "diff2";
        protected override string Topic() => "Linksmasis";
        protected override string MostCommonAuth() => "Common";
        protected override int AuthCount() => 2;
    }

    [TestClass]
    public abstract class SortTest
    {
        [TestMethod]
        public void SortTest_ReturnsTrue()
        {

            Council council = new Council();
            council.Add(Biggest());
            council.Add(Medium());
            council.Add(Big());
            council.Add(Smallest());
            council.Add(Smaller());

            council.Sort();

            bool isEqual = false;
            if (council.Get(0).Equals(Smallest()))
            {
                if (council.Get(1).Equals(Smaller()))
                {
                    if (council.Get(2).Equals(Medium()))
                    {
                        if (council.Get(3).Equals(Big()))
                        {
                            if (council.Get(4).Equals(Biggest()))
                                isEqual = true;
                        }
                    }
                }
            }

            Assert.IsTrue(isEqual);
        }

        protected abstract MusicQuestion Smallest();
        protected abstract MusicQuestion Smaller();
        protected abstract MusicQuestion Medium();
        protected abstract MusicQuestion Big();
        protected abstract MusicQuestion Biggest();
    }

    [TestClass]
    public class SortTestInfo : SortTest
    {
        protected override MusicQuestion Big() => new MusicQuestion("topic2", "diff2", "asd", "abc", "abc", 25, "file5");

        protected override MusicQuestion Biggest() => new MusicQuestion("topic2", "diff2", "asd", "abc", "abc", 25, "file4");

        protected override MusicQuestion Medium() => new MusicQuestion("topic2", "diff2", "asd", "abc", "abc", 25, "file3");

        protected override MusicQuestion Smaller() => new MusicQuestion("topic2", "diff2", "asd", "abc", "abc", 25, "file2");

        protected override MusicQuestion Smallest() => new MusicQuestion("topic2", "diff2", "asd", "abc", "abc", 25, "file1");
    }
}

