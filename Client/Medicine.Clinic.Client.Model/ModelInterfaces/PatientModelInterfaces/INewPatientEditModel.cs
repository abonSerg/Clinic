using Medicine.Clinic.Client.Model.SexService;
using System;
using System.ComponentModel;

namespace Medicine.Clinic.Client.Model
{
    public interface INewPatientEditModel
    {
        string EditPatient(string mrn, string ssn, string firstName, string lastName, string middleName, DateTime dob, string sexCode, DateTime? dod, bool isEdit, bool isSsnFull);
        BindingList<DtoSex> LoadSexes();
    }
}
