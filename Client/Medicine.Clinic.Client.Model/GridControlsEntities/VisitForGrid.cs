using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine.Clinic.Client.Model.GridControlsEntities
{
    public class VisitForGrid
    {
        public string BillingNumber { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
        public string ClinicName { get; set; }
        public int Room { get; set; }
        public int Bed { get; set; }
    }
}
