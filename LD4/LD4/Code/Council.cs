using System;
using System.Collections.Generic;

namespace LD4
{
    public class Council
    {
        public string Title { get; private set; } // Council title

        public WebForm1 WebForm1
        {
            get => default;
            set
            {
            }
        }

        private List<Question> Questions; // Council's questions

        public Council(string title = "")
        {
            Title = title;
            Questions = new List<Question>();
        }

        public Council(Question question)
        {
            Questions = new List<Question>();
            Questions.Add(question);
        }

        /// <summary>
        /// Add method to add to Question Array
        /// </summary>
        /// <param name="question">Question element to add</param>
        public void Add(Question question)
        {
            Questions.Add(question);
        }

        /// <summary>
        /// Add method to add Council to Question array
        /// </summary>
        /// <param name="questions">Council element</param>
        public void Add(Council questions)
        {
            for (int i = 0; i < questions.Count(); i++)
            {
                Questions.Add(questions.Get(i));
            }
        }

        /// <summary>
        /// Gets indexed element
        /// </summary>
        /// <param name="index">num of element to get</param>
        /// <returns>Question element</returns>
        public Question Get(int index)
        {
            if (Count() == 0)
            {
                throw (new ListIsEmptyException("Sąrašas yra tuščias"));
            }
            return Questions[index];
        }

        /// <summary>
        /// Count of Questions
        /// </summary>
        /// <returns>intiger of Quesions</returns>
        public int Count()
        {
            return Questions.Count;
        }

        /// <summary>
        /// checks if Questions array is empty
        /// </summary>
        /// <returns>true, if empty, else false</returns>
        public bool IsEmpty()
        {
            return Questions.Count == 0;
        }

        /// <summary>
        /// Gets all given difficulty questions from Questions array
        /// </summary>
        /// <param name="council">Council to add to</param>
        /// <param name="difficulty">difficulty to get</param>
        public void GetDifficulty(Council council, string difficulty)
        {
            foreach (Question question in Questions)
            {
                if (question.Difficulty.Equals(difficulty))
                {
                    council.Add(question);
                }
            }
        }

        /// <summary>
        /// Gets all given type questions from Questions array
        /// </summary>
        /// <param name="council">council to add to</param>
        /// <param name="type">Type element to get</param>
        public void GetType(Council council, Type type)
        {
            foreach (Question question in Questions)
            {
                if (type.Equals(question.GetType()))
                {
                    council.Add(question);
                }
            }
        }

        /// <summary>
        /// Gets most common author for Councils questions
        /// </summary>
        /// <param name="count">count of questions thought of</param>
        /// <returns>string line of author</returns>
        public string GetMostCommonAuthor(out int count)
        {
            string mostCommonAuth = null;
            count = 0;

            for (int i = 0; i < Questions.Count; i++)
            {
                string currentAuth = Questions[i].Author;
                int currentCount = 1;

                for (int j = i + 1; j < Questions.Count; j++)
                {
                    if (Questions[j].Author == currentAuth)
                    {
                        currentCount++;
                    }
                }

                if (currentCount > count)
                {
                    mostCommonAuth = currentAuth;
                    count = currentCount;
                }
            }

            return mostCommonAuth;
        }

        /// <summary>
        /// Gets all questions marked as "Linksmasis"
        /// </summary>
        /// <param name="council">council to add to</param>
        public void GetFunQuestions(Council council)
        {
            foreach (Question question in Questions)
            {
                if (question.Topic == "Linksmasis")
                {
                    council.Add(question);
                }
            }
        }

        /// <summary>
        /// Sorts Council Selectively
        /// </summary>
        public void Sort()
        {
            for (int i = 0; i < Count() - 1; i++)
            {
                int m = i;
                for (int j = i + 1; j < Count(); j++)
                    if (Questions[j].CompareTo(Questions[m]) == -1)
                        m = j;
                Question a = Questions[i];
                Questions[i] = Questions[m];
                Questions[m] = a;
            }
        }
    }
}