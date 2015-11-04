
namespace Medicine.Clinic.Client.Model
{
    public interface INewClinicEditModel
    {
        string EditClinic(string code, string name, string address, bool isEdit);
    }
}
