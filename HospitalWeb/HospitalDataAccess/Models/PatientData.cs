using System;

namespace HospitalDataAccess.Models
{
    public class PatientData
    {
        public long PatientDataId { get; set; }

        public DateTime ChoosedData { get; set; }

        public long PatientId { get; set; }

        public string UserId { get; set; }

        public double Temperature { get; set; }

        public double ActivityFactor { get; set; }

        public double DamageFactor { get;  set; }

        public double WeightInitial { get; set; }

        public double WeightCurrent { get; set; }

        public double Growth { get; set; }
    }
}
