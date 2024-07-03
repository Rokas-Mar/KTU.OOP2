using System;

namespace LD4.Individual
{
    internal abstract class AnimalMarked : Animal
    {
        public int chipId { get; set; }

        public AnimalMarked(string name, int chipId, string breed, string owner, string phone, DateTime vaccinationDate)
            : base(name, breed, owner, phone, vaccinationDate)
        {
            this.chipId = chipId;
        }

        public AnimalMarked(string data) : base(data)
        {
            this.SetData(data);
        }

        public override void SetData(string line)
        {
            string[] values = line.Split(',');
            Name = values[1];
            chipId = int.Parse(values[2]);
            Breed = values[3];
            Owner = values[4];
            Phone = values[5];
            VaccinationDate = DateTime.Parse(values[6]);
        }

        public override int GetHashCode()
        {
            return chipId.GetHashCode() ^ Name.GetHashCode();
        }

        public override int CompareTo(object a1)
        {
            if (chipId == (a1 as AnimalMarked).chipId)
                return 0;
            else if (chipId < (a1 as AnimalMarked).chipId)
                return -1;
            else
                return 1;
        }

        public bool Equals(AnimalMarked animal)
        {
            if (Object.ReferenceEquals(animal, null))
            {
                return false;
            }
            if (this.GetType() != animal.GetType())
            {
                return false;
            }
            return (chipId == animal.chipId) && (Name == animal.Name);
        }
    }
}
