using System;

namespace LD4
{
    public class TaskUtils
    {
        /// <summary>
        /// Gets Council by title
        /// </summary>
        /// <param name="Councils">Councils Array</param>
        /// <param name="number">number of councils</param>
        /// <param name="title">Title to get</param>
        /// <returns>Gotten council by title</returns>
        public static Council GetCouncilByTitle(Council[] Councils, ref int number, string title)
        {
            for (int i = 0; i < number; i++)
            {
                if (Councils[i].Title == title)
                {
                    return Councils[i];
                }
            }
            Councils[number++] = new Council(title);
            return Councils[number - 1];
        }

        /// <summary>
        /// Gets questions by difficulty from all Councils
        /// </summary>
        /// <param name="councils">Councils Array</param>
        /// <param name="number">Number of councils</param>
        /// <param name="difficulty">Difficulty to get</param>
        /// <returns>Council of gotten difficulty</returns>
        public static Council GetQuestionsByDifficulty(Council[] councils, int number, string difficulty)
        {
            Council selected = new Council();

            foreach (Council council in councils)
            {
                council?.GetDifficulty(selected, difficulty);
            }

            return selected;
        }

        /// <summary>
        /// Gets Questions by their type
        /// </summary>
        /// <param name="council">Council to add to</param>
        /// <param name="type">Type of wanted questions</param>
        /// <returns>Council element of gotten Type of data</returns>
        public static Council GetQuestionsByType(Council council, Type type)
        {
            Council selected = new Council();

            council?.GetType(selected, type);

            return selected;
        }

        /// <summary>
        /// Gets most common author for all of the councils
        /// </summary>
        /// <param name="councils">Councils array</param>
        /// <param name="number">number of councils</param>
        /// <param name="count">count of written questions</param>
        /// <returns>Most common author between all councils in string line</returns>
        public static string GetMostCommonAuthorGlobal(Council[] councils, int number, out int count)
        {
            count = 0;
            string author;

            int currentCount = 0;
            string mostCommonAuth = null;

            for (int i = 0; i < number; i++)
            {
                Council c = councils[i];
                author = c.GetMostCommonAuthor(out currentCount);
                if (count < currentCount)
                {
                    count = currentCount;
                    mostCommonAuth = author;
                }
            }

            return mostCommonAuth;
        }

        /// <summary>
        /// Gets all questions marked as "Linksmasis"
        /// </summary>
        /// <param name="councils">Councils array</param>
        /// <param name="number">numebr of councils</param>
        /// <returns>Council of all marked Questions</returns>
        public static Council GetFunQuestions(Council[] councils, int number)
        {
            Council selected = new Council();

            for (int i = 0; i < number; i++)
            {
                Council c = councils[i];

                c?.GetFunQuestions(selected);
            }

            return selected;
        }
    }
}