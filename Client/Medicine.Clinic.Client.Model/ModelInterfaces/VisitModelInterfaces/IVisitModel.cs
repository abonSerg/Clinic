using System.ComponentModel;
using System.Data;
using ClinicDataSetAccess;
using Medicine.Clinic.Client.Model.GridControlsEntities;

namespace Medicine.Clinic.Client.Model
{
    public interface IVisitModel
    {
        BindingList<VisitForGrid> SearchVisits(string mrn, string patientFirstName, string billingNumber);
    }
}
