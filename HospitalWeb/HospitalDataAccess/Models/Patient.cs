using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HospitalDataAccess.Models
{

    public class Patient
    {
        public long PatientId { get; set; }

        public string UserId { get; set; }

        public string CaseHistoryNumber { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Patronymic { get; set; }

        public string Diagnosis { get; set; }

        public DateTime DateOfHospital { get; set; }

        public DateTime DateOfOITR { get; set; }

        public DateTime DateBirth { get; set; }

        public DateTime DateDischarge { get; set; }

        public bool IsMale { get; set; }

        public virtual ICollection<PatientData> PatientDatas { get; set; }

        public virtual ICollection<NutritionSupport> NutritionSupports { get; set; }
    }
}
