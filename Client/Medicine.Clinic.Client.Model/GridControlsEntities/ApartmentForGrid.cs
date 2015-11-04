using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine.Clinic.Client.Model.GridControlsEntities
{
    public class ApartmentForGrid
    {
        public int Id { get; set; }
        public string ClinicCode { get; set; }
        public string ClinicName { get; set; }
        public int Room { get; set; }
        public int Bed { get; set; }
    }
}
