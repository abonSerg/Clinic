using System;
using DevExpress.XtraEditors.DXErrorProvider;

namespace Medicine.Clinic.Client.Model.GridControlsEntities
{
    public class TubeForGrid 
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ConcreteCode { get; set; }
        public DateTime? ReceivedDt { get; set; }
        public string Tests { get; set; }

        public TubeForGrid()
        {
            Id = DateTime.Now.Ticks.ToString();
        }

        


   
    }
}
