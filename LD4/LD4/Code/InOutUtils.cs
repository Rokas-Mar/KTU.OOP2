using System.IO;
using System.Text;

namespace LD4
{
    public static class InOutUtils
    {
        /// <summary>
        /// Method for reading multiple files
        /// </summary>
        /// <param name="dir">directory of files</param>
        /// <param name="Councils">Council Array element</param>
        /// <param name="num">Number of councils</param>
        public static void ReadData(string dir, Council[] Councils, ref int num)
        {
            string[] filePaths = Directory.GetFiles(dir, "*.csv");
            if(filePaths.Length == 0)
            {
                throw (new FilesNotFound("Failai Nerasti"));
            }
            foreach (string path in filePaths)
            {
                ReadQuestionData(path, Councils, ref num);
            }
        }

        /// <summary>
        /// Reads single file data
        /// </summary>
        /// <param name="file">file to read</param>
        /// <param name="Councils">Council Array element</param>
        /// <param name="num">number of councils</param>
        public static void ReadQuestionData(string file, Council[] Councils, ref int num)
        {
            using (StreamReader reader = new StreamReader(@file, Encoding.GetEncoding(1257)))
            {
                string line = reader.ReadLine();
                Council council = TaskUtils.GetCouncilByTitle(Councils, ref num, line);
                while (null != (line = reader.ReadLine()))
                {
                    switch (line[0])
                    {
                        case 'M':
                            council.Add(new MusicQuestion(line));
                            break;
                        case 'T':
                            council.Add(new TestQuestion(line));
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Prints all data to file
        /// </summary>
        /// <param name="file">file to print to</param>
        /// <param name="branches">councils to print</param>
        /// <param name="number">number of councils</param>
        public static void PrintDataToFile(string file, Council[] branches, int number)
        {
            for (int ii = 0; ii < number; ii++)
            {
                PrintQuestionsToFile(file, branches[ii], branches[ii].Title);
            }
        }

        /// <summary>
        /// Prints single Council data to file
        /// </summary>
        /// <param name="file">file to print to</param>
        /// <param name="council">council to print</param>
        /// <param name="title">title of table printed</param>
        public static void PrintQuestionsToFile(string file, Council council, string title)
        {
            using (var writer = new StreamWriter(file, true))
            {
                try
                {
                    council.Get(0);
                } catch(ListIsEmptyException e)
                {
                    writer.WriteLine(title + " " + e.Message);
                    return;
                }
                string s = new string('-', council.Get(0).ToString().Length);
                writer.WriteLine(title);
                writer.WriteLine(s);
                for (int i = 0; i < council.Count(); i++)
                {
                    writer.WriteLine(council.Get(i));
                }
                writer.WriteLine(s);
            }
        }
    }
}