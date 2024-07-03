namespace LD4.Individual
{
    class Branch
    {
        public string Town { get; private set; }
        private Animal[] Animals;
        public int Count { get; private set; }
        public Branch(string town = "")
        {
            Town = town;
            Animals = new Animal[Program.MaxNumberOfAnimals];
        }
        /// <summary>
        /// Add animal into collection
        /// </summary>
        /// <param name="a">Animal to add</param>
        public void AddAnimal(Animal a)
        {
            Animals[Count] = a;
            Count++;
        }
        /// <summary>
        /// Get animal according to the index
        /// </summary>
        public Animal GetAnimal(int index)
        {
            return Animals[index];
        }
        /// </summary>
        /// Sort animals according to method CompareTo()
        public void SortAnimals()
        {
            for (int i = 0; i < Count - 1; i++)
            {
                int m = i;
                for (int j = i + 1; j < Count; j++)
                    if (Animals[j].CompareTo(Animals[m]) == -1)
                        m = j;
                Animal a = Animals[i];
                Animals[i] = Animals[m];
                Animals[m] = a;
            }
        }
        /// <summary>
        /// Join to collections of animals without making a data copy
        /// </summary>
        /// <param name="a">First collection</param>
        /// <param name="b">Second collection</param>
        /// <returns></returns>
        public static Branch operator +(Branch a, Branch b)
        {
            Branch c = new Branch(a.Town);
            for (int i = 0; i < a.Count; i++)
                c.AddAnimal(a.Animals[i]);
            for (int i = 0; i < b.Count; i++)
                c.AddAnimal(b.Animals[i]);
            return c;
        }
    }
}
