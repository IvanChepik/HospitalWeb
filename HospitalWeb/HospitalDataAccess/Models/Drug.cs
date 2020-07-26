using System;

namespace HospitalDataAccess.Models
{
    public class Drug
    {
        public long DrugId {get; set;}

        public string UserId { get; set; }

        public DateTime CreationDate { get; set; }

        public string DrugName { get; set; }

        public double Protein { get; set; }

        public double Fat { get; set; }

        public double Carbohydrate { get; set; }

        public double KCal { get; set; }
    }
}
