using System.ComponentModel;
using System.Data;
using Medicine.Clinic.Client.Model.GridControlsEntities;

namespace Medicine.Clinic.Client.Model
{
    public interface INewVisitEditModel
    {
        void GetDataSet();
        string EditVisit(string billingNumber, string mrn, string doctorCode, int apartmentId);
        string GetPatientMrnByVisit(string billingNumber);
        string GetDoctorCodeByVisit(string billingNumber);
        int GetApartmentIdByVisit(string billingNumber);
        string GetDefaultDoctorCode(int apartmentId);
        BindingList<PatientForGrid> LoadPatients();
        BindingList<DoctorForGrid> LoadDoctors();
        BindingList<ApartmentForGrid> LoadApartments();
    }
}
