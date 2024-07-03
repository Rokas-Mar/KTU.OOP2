using System;
using System.Collections.Generic;

namespace LD4.Individual
{
    static class TaskUtils
    {
        /// <summary>
        /// Find branch according to the title
        /// </summary>
        /// <param name="branches">Collection of branches</param>
        /// <param name="number">Number of branches</param>
        /// <param name="town">City name</param>
        /// <returns>Found or Branch object</returns>
        public static Branch GetBranchByTown(Branch[] branches, ref int number, string town)
        {
            for (int i = 0; i < number; i++)
            {
                if (branches[i].Town == town)
                {
                    return branches[i];
                }
            }
            branches[number++] = new Branch(town);
            return branches[number - 1];
        }
        /// <summary>
        /// Select the given type of the animals from the common list
        /// </summary>
        /// <param name="ba">Branch</param>
        /// <param name="forma">Name of new collection</param>
        /// <param name="type">System type</param>
        /// <returns>Branch object having animals of given type </returns>
        public static Branch GetAnimals(Branch ba, string forma, Type type)
        {
            Branch anima = new Branch(String.Format(forma, ba.Town));
            for (int i = 0; i < ba.Count; i++)
                if (ba.GetAnimal(i).GetType() == type)
                    anima.AddAnimal(ba.GetAnimal(i));
            return anima;
        }
        /// <summary>
        /// Form collection of breeds in the branch
        /// </summary>
        /// <param name="ba">Branch</param>
        private static List<string> GetBreeds(Branch ba)
        {
            List<string> breeds = new List<string>();
            for (int i = 0; i < ba.Count; i++)
            {
                if (!breeds.Contains(ba.GetAnimal(i).Breed))
                {
                    breeds.Add(ba.GetAnimal(i).Breed);
                }
            }
            return breeds;
        }
        /// <summary>
        /// Select animals of given breed
        /// </summary>
        /// <param name="ba">Branch</param>
        /// <param name="breed">Breed</param>
        /// <returns>Collection of given breed</returns>
        private static Branch FilterByBreed(Branch ba, string breed)
        {
            Branch filtered = new Branch(breed);
            for (int i = 0; i < ba.Count; i++)
                if (ba.GetAnimal(i).Breed == breed)
                    filtered.AddAnimal(ba.GetAnimal(i));
            return filtered;
        }
        /// <summary>
        /// Count number of aggressive dogs in the branch
        /// </summary>
        /// <param name="ba">Branch</param>
        /// <returns>Number of aggressive dogs</returns>
        public static int CountAggressive(Branch ba)
        {
            int counter = 0;
            for (int i = 0; i < ba.Count; i++)
                if ((ba.GetAnimal(i) is Dog) && (ba.GetAnimal(i) as Dog).Aggressive)
                    counter++;
            return counter;
        }
        /// <summary>
        /// Find the most popular breed in the branch
        /// </summary>
        /// <param name="ba">Branch</param>
        /// <returns>Breed</returns>
        public static string GetMostPopularBreed(Branch ba)
        {
            string popular = "not found";
            int count = 0;
            List<string> breeds = GetBreeds(ba);
            for (int i = 0; i < breeds.Count; i++)
            {
                Branch filtered = FilterByBreed(ba, breeds[i]);
                if (filtered.Count > count)
                {
                    popular = breeds[i];
                    count = filtered.Count;
                }
            }
            return popular;
        }
        /// <summary>
        /// Select dogs from all the branches
        /// </summary>
        /// <param name="ba">Branches</param>
        /// <param name="NumberOfBranches">Number of branches</param>
        /// <param name="allDogs">Collection of selected dogs</param>
        /// <param name="forma">Title</param>
        public static void GetAllDogs(Branch[] ba, int NumberOfBranches, ref Branch allDogs,
       string forma)
        {
            for (int i = 0; i < NumberOfBranches; i++)
            {
                Branch bDogs = GetAnimals(ba[i], forma, typeof(Dog));
                allDogs += bDogs;
            }
        }

        public static void GetAllCats(Branch[] ba, int NumberOfBranches, ref Branch allCats,
        string forma)
        {
            for (int i = 0; i < NumberOfBranches; i++)
            {
                Branch bCats = GetAnimals(ba[i], forma, typeof(Cat));
                allCats += bCats;
            }
        }

        public static void GetAllGP(Branch[] ba, int NumberOfBranches, ref Branch allGP,
        string forma)
        {
            for (int i = 0; i < NumberOfBranches; i++)
            {
                Branch bGP = GetAnimals(ba[i], forma, typeof(GuineaPig));
                allGP += bGP;
            }
        }
    }
}
