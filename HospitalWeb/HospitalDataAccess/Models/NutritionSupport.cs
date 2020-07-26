

using System;

namespace HospitalDataAccess.Models
{
    public class NutritionSupport
    {
        public long NutritionSupportId { get; set; }

        public long PatientId { get; set; }

        public string UserId { get; set; }

        public long DrugId { get; set; }

        public Drug Drug { get; set; }

        public DateTime ProvisionDate { get; set; }

        public double DrugVolume { get; set; }
    }
}
