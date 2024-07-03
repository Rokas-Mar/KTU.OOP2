using System;

namespace LD4.Individual
{
    internal class GuineaPig : Animal
    {
        private static int VaccinationDurationMonths = 6;
        public GuineaPig(string name, string breed, string owner, string phone, DateTime vaccinationDate)
        : base(name, breed, owner, phone, vaccinationDate)
        {
        }

        public GuineaPig(string data) : base(data)
        {

        }

        public override bool isVaccinationExpired()
        {
            return VaccinationDate.AddMonths(VaccinationDurationMonths).CompareTo(DateTime.Now) > 0;
        }

        public override String ToString()
        {
            return String.Format("|{0,-3}|{1,-20}|{2,-9}|{3,-10} ({4})|{5:yyyy-MM-dd}|", "",
           Breed, Name, Owner, Phone, VaccinationDate);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as GuineaPig);
        }
        public bool Equals(GuineaPig obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
