using System;

namespace LD4
{
    /// <summary>
    /// Parent class of all questions
    /// </summary>
    public class Question : IEquatable<Question>, IComparable<object>
    {
        public string Topic { get; set; }
        public string Difficulty { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public string Answer { get; set; }
        public int Points { get; set; }

        public Council Council
        {
            get => default;
            set
            {
            }
        }

        public Question() { }
        public Question(string topic, string difficulty, string author, string text, string answer, int points)
        {
            Topic = topic;
            Difficulty = difficulty;
            Author = author;
            Text = text;
            Answer = answer;
            Points = points;
        }

        public Question(string line)
        {
            SetData(line);
        }

        /// <summary>
        /// Sets data from a line
        /// </summary>
        /// <param name="line">string element</param>
        public virtual void SetData(string line)
        {
            string[] words = line.Split(';');
            Topic = words[1];
            Difficulty = words[2];
            Author = words[3];
            Text = words[4];
            Answer = words[5];
            Points = Convert.ToInt32(words[6]);
        }

        /// <summary>
        /// Declaration of Equals for sorting
        /// </summary>
        /// <param name="other">other element to compare</param>
        /// <returns>true if equals, else false</returns>
        public bool Equals(Question other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (this.GetType() != other.GetType())
            {
                return false;
            }
            return (Text == other.Text);
        }

        /// <summary>
        /// Declaration of CompareTo for sorting
        /// </summary>
        /// <param name="other">object to compare to</param>
        /// <returns>1 if this element follows lhs, 0 if they are equal, -1 if this precedes lhs</returns>
        public virtual int CompareTo(object other)
        {
            if (Topic == (other as Question).Topic)
                return 0;
            else if (Topic.CompareTo((other as Question).Topic) < 0)
                return -1;
            else
                return 1;
        }

        /// <summary>
        /// Override of GetHashCode
        /// </summary>
        /// <returns>returns Author hash code</returns>
        public override int GetHashCode()
        {
            return this.Author.GetHashCode();
        }
    }
}