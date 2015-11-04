using System.ComponentModel;
using System.Data;
using Medicine.Clinic.Client.Model.GridControlsEntities;

namespace Medicine.Clinic.Client.Model
{
    public interface INewVisitModel
    {
        void GetDataSet();
        string GetBillingNumber();
        string EditVisit(string billingNumber, string mrn, string doctorCode, int apartmentId);
        string GetDefaultDoctorCode(int apartmentId);
        BindingList<PatientForGrid> LoadPatients();
        BindingList<DoctorForGrid> LoadDoctors();
        BindingList<ApartmentForGrid> LoadApartments();
    }
}
