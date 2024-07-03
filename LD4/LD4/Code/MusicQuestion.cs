using System;

namespace LD4
{
    /// <summary>
    /// Class for music questions
    /// </summary>
    public class MusicQuestion : Question, IEquatable<MusicQuestion>, IComparable<object>
    {
        public string FileName { get; set; }

        public MusicQuestion(string topic, string difficulty, string author, string text, string answer, int points, string fileName)
            : base(topic, difficulty, author, text, answer, points)
        {
            FileName = fileName;
        }

        public MusicQuestion(string line) : base(line)
        {
            SetData(line);
        }

        /// <summary>
        /// Override of main class SetData to get FileSize property
        /// </summary>
        /// <param name="line">string type element</param>
        public override void SetData(string line)
        {
            base.SetData(line);
            string[] words = line.Split(';');
            FileName = words[7];
        }

        /// <summary>
        /// Override to print all data
        /// </summary>
        /// <returns>Structured data to a line</returns>
        public override string ToString()
        {
            return string.Format("| {0, -10} | {1, -8} | {2, -25} | {3, -80} | {4, -20} | {5, 8} | {6, -20} | {7, -80} |", Topic, Difficulty, Author, Text, Answer, Points, FileName, "");
        }

        /// <summary>
        /// Declaration of Equals for sorting
        /// </summary>
        /// <param name="other">MusicQuestion element</param>
        /// <returns></returns>
        public bool Equals(MusicQuestion other)
        {
            return this.Equals(other as MusicQuestion);
        }

        /// <summary>
        /// Declaration of CompareTo for sorting
        /// </summary>
        /// <param name="lhs">object to compare to</param>
        /// <returns>1 if this element follows lhs, 0 if they are equal, -1 if this precedes lhs</returns>
        public override int CompareTo(object lhs)
        {
            if (lhs is MusicQuestion)
                if (String.Compare(FileName, (lhs as MusicQuestion).FileName, StringComparison.CurrentCulture) > 0)
                    return 1;
                else
                    return -1;
            else
                return 0;
        }
    }
}