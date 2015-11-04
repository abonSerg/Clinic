
namespace Medicine.Clinic.Client.Model
{
    public interface INewDiagnosisEditModel
    {
        string EditDiagnosis(string code, string name, bool isEdit);
    }
}
