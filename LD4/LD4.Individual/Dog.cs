using System;

namespace LD4.Individual
{
    class Dog : AnimalMarked
    {
        private static int VaccinationDuration = 1;
        public Dog(string name, int chipId, string breed, string owner, string phone, DateTime
       vaccinationDate, bool aggressive)
        : base(name, chipId, breed, owner, phone, vaccinationDate)
        {
            Aggressive = aggressive;
        }
        public Dog(string data)
        : base(data)
        {
            SetData(data);
        }
        public override void SetData(string line)
        {
            base.SetData(line);
            string[] values = line.Split(',');
            Aggressive = bool.Parse(values[7]);
        }
        public bool Aggressive { get; set; }
        /// <summary>
        /// Implementation of abstract method of Animal class
        /// </summary>
        /// <returns></returns>
        public override bool isVaccinationExpired()
        {
            return VaccinationDate.AddYears(VaccinationDuration).CompareTo(DateTime.Now) > 0;
        }
        public override String ToString()
        {
            return String.Format("|{0,-3}|{1,-20}|{2,-9}|{3,-10} ({4})|{5:yyyy-MM-dd}|{6}|",
           chipId, Breed, Name, Owner, Phone, VaccinationDate, Aggressive ? '+' : ' ');
        }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Dog); //call to type-specific method in the same class
        }
        public bool Equals(Dog dog)
        {
            return base.Equals(dog); //call to base class Animal Equals method
                                     //We can do like this:
                                     //return base.Equals(dog) && this.Aggressive == dog.Aggressive;
        }
        public override int GetHashCode()
        {
            return chipId.GetHashCode() ^ Name.GetHashCode();
        }
    }

}
