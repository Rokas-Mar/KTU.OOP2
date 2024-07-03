using System;
using System.Text;

namespace LD4.Individual
{
    internal class Program
    {
        public const int MaxNumberOfBranches = 10;
        public const int MaxNumberOfAnimals = 50;
        public const int MaxNumberOfBreeds = 50;
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding(1257);
            Branch[] branches = new Branch[MaxNumberOfBranches];
            int NumberOfBranches = 0;
            const string DataDir = @"..\..\Data";
            InOutUtils.ReadData(DataDir, branches, ref NumberOfBranches);
            InOutUtils.PrintDataToConsole(branches, NumberOfBranches);
            Console.WriteLine("Registruoti šunys surikiuoti:");
            Branch KaunoSunys = TaskUtils.GetAnimals(branches[0], branches[0].Town,
            typeof(Dog));
            KaunoSunys.SortAnimals();
            InOutUtils.PrintAnimalsToConsole(KaunoSunys, branches[0].Town);
            Console.WriteLine();
            Console.WriteLine("Registruotos katės surikiuotos:");
            Branch KaunoKates = TaskUtils.GetAnimals(branches[0], branches[0].Town,
            typeof(Cat));
            KaunoKates.SortAnimals();
            InOutUtils.PrintAnimalsToConsole(KaunoKates, branches[0].Town);
            Console.WriteLine();

            Console.WriteLine("Registruotos jūrų kliaulytes surikiuotos:");
            Branch KaunoKiaulytes = TaskUtils.GetAnimals(branches[0], branches[0].Town, typeof(GuineaPig));
            KaunoKiaulytes.SortAnimals();
            InOutUtils.PrintAnimalsToConsole(KaunoKiaulytes, branches[0].Town);
            Console.WriteLine();

            Console.WriteLine("Agresyvūs šunys\n {0}: {1}", branches[0].Town,
            TaskUtils.CountAggressive(branches[0]));
            Console.WriteLine("Agresyvūs šunys\n {0}: {1}", branches[1].Town,
            TaskUtils.CountAggressive(branches[1]));
            Console.WriteLine("Populiariausia šunų veislė\n {0}: {1}", branches[0].Town,
            TaskUtils.GetMostPopularBreed(TaskUtils.GetAnimals(branches[0], "Filialas: {0} Gyvūnas: šuo", typeof(Dog))));

            Console.WriteLine("Populiariausia kačių veislė\n {0}: {1}", branches[1].Town,
            TaskUtils.GetMostPopularBreed(TaskUtils.GetAnimals(branches[1], "Filialas: {0} Gyvūnas: katė", typeof(Cat))));

            Console.WriteLine("Populiariausia jūrų kiaulyčių veislė\n {0}: {1}", branches[1].Town,
            TaskUtils.GetMostPopularBreed(TaskUtils.GetAnimals(branches[1], "Filialas: {0} Gyvūnas: katė", typeof(GuineaPig))));

            Console.WriteLine();
            Console.WriteLine("Pagal lusto Nr. surūšiuotas visų filialų šunų sąrašas:");
            Console.WriteLine();
            Branch allDogs = new Branch("Visi šunys");
            TaskUtils.GetAllDogs(branches, NumberOfBranches, ref allDogs, "Filialas: {0} Gyvūnas: šuo");

            allDogs.SortAnimals();
            InOutUtils.PrintAnimalsToConsole(allDogs, allDogs.Town);

            Console.WriteLine();
            Console.WriteLine("Pagal lusto Nr. surūšiuotas visų filialų kačių sąrašas:");
            Console.WriteLine();
            Branch allCats = new Branch("Visos katės");
            TaskUtils.GetAllCats(branches, NumberOfBranches, ref allCats, "Filialas: {0} Gyvūnas: katė");

            allCats.SortAnimals();
            InOutUtils.PrintAnimalsToConsole(allCats, allCats.Town);

            Console.WriteLine();
            Console.WriteLine("Pagal vardą surūšiuotas visų filialų jųrų kiaulyčių sąrašas:");
            Console.WriteLine();
            Branch allGP = new Branch("Visos jūrų kiaulytės");
            TaskUtils.GetAllGP(branches, NumberOfBranches, ref allGP, "Filialas: {0} Gyvūnas: jūrų kiaulytė");

            allGP.SortAnimals();
            InOutUtils.PrintAnimalsToConsole(allGP, allGP.Town);
        }
    }
}
