using System;

namespace Medicine.Clinic.Client.Model.GridControlsEntities
{
    public class SpecimenForGrid
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string ConcreteCode { get; set; }
        public DateTime? CollectedDt { get; set; }
        public int Volume { get; set; }
        public string Tubes { get; set; }
    }
}
