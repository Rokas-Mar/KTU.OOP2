using System;
using System.Collections.Generic;

namespace LD4
{
    public class TestQuestion : Question, IEquatable<TestQuestion>, IComparable<object>
    {
        private List<string> Variants;

        public TestQuestion(string topic, string difficulty, string author, string text, string answer, int points, List<string> variants)
            : base(topic, difficulty, author, text, answer, points)
        {
            Variants = new List<string>();
            foreach (string variant in variants)
            {
                this.Variants.Add(variant);
            }
        }

        public TestQuestion(string line) : base(line)
        {
            SetData(line);
        }

        /// <summary>
        /// Override of main class SetData to get Variants property
        /// </summary>
        /// <param name="line"></param>
        public override void SetData(string line)
        {
            base.SetData(line);
            string[] words = line.Split(';');
            string[] variants = words[7].Split(',');
            Variants = new List<string>();
            foreach (string variant in variants)
            {
                Variants.Add(variant);
            }
        }

        /// <summary>
        /// Gets question variants
        /// </summary>
        /// <returns>string List of variants</returns>
        public List<string> GetVariants()
        {
            return Variants;
        }

        /// <summary>
        /// ToString override to print all data
        /// </summary>
        /// <returns>Formated string of all data</returns>
        public override string ToString()
        {
            return string.Format("| {0, -10} | {1, -8} | {2, -25} | {3, -80} | {4, -20} | {5, 8} | {6, -20} | {7, -80} |", Topic, Difficulty, Author, Text, Answer, Points, "", string.Join(", ", Variants));
        }

        /// <summary>
        /// Declaration of Equals for sorting
        /// </summary>
        /// <param name="other">TestQuestion element</param>
        /// <returns></returns>
        public bool Equals(TestQuestion other)
        {
            return this.Equals(other as TestQuestion);
        }

        /// <summary>
        /// Declaration of CompareTo for sorting
        /// </summary>
        /// <param name="lhs">object to compare t</param>
        /// <returns>1 if this element follows lhs, 0 if they are equal, -1 if this precedes lhs</returns>
        public override int CompareTo(object lhs)
        {
            if (lhs is TestQuestion)
                if (String.Compare(Topic, (lhs as TestQuestion).Topic, StringComparison.CurrentCulture) > 0)
                    return 1;
                else
                if (String.Compare(Topic, (lhs as TestQuestion).Topic, StringComparison.CurrentCulture) == 0)
                    return String.Compare(Difficulty, (lhs as TestQuestion).Difficulty, StringComparison.CurrentCulture);
                else
                    return -1;
            else
                return -1;
        }
    }
}