using System;
using System.IO;
using System.Text;

namespace LD4.Individual
{
    static class InOutUtils
    {
        /// <summary>
        /// Read data of branches
        /// </summary>
        /// <param name="file">Directory name</param>
        /// <param name="branches">Branches storing data</param>
        /// <param name="number">Number of branches</param>
        public static void ReadData(string file, Branch[] branches, ref int number)
        {
            string[] filePaths = Directory.GetFiles(file, "*.csv");
            foreach (string path in filePaths)
            {
                ReadAnimalData(path, branches, ref number);
            }
        }
        /// <summary>
        /// Read data of branch
        /// </summary>
        /// <param name="file">Directory name</param>
        /// <param name="branches">Branches storing data</param>
        /// <param name="number">Number of branches</param>
        private static void ReadAnimalData(string file, Branch[] branches, ref int number)
        {
            using (StreamReader reader = new StreamReader(@file, Encoding.GetEncoding(1257)))
            {
                string line = reader.ReadLine();
                Branch branch = TaskUtils.GetBranchByTown(branches, ref number, line);
                while (null != (line = reader.ReadLine()))
                {
                    switch (line[0])
                    {
                        case 'D':
                            branch.AddAnimal(new Dog(line));
                            break;
                        case 'C':
                            branch.AddAnimal(new Cat(line));
                            break;
                        case 'G':
                            branch.AddAnimal(new GuineaPig(line));
                            break;
                    }
                }
            }
        }
        /// <summary>
        /// Display data from branches on screen
        /// </summary>
        /// <param name="branches">Branches</param>
        /// <param name="number">Number of branches</param>
        public static void PrintDataToConsole(Branch[] branches, int number)
        {
            for (int ii = 0; ii < number; ii++)
            {
                PrintAnimalsToConsole(branches[ii], branches[ii].Town);
            }
        }
        /// <summary>
        /// Display data from branch on screen
        /// </summary>
        /// <param name="ba">Branch</param>
        /// <param name="title">Title of table</param>
        public static void PrintAnimalsToConsole(Branch ba, string title)
        {
            string s = new string('-', ba.GetAnimal(0).ToString().Length);
            Console.WriteLine(title);
            Console.WriteLine(s);
            for (int i = 0; i < ba.Count; i++)
            {
                Console.WriteLine(ba.GetAnimal(i));
            }
            Console.WriteLine(s);
        }
    }
}
