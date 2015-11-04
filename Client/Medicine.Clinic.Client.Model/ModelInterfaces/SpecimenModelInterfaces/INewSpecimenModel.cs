using Medicine.Clinic.Client.Model.TubeService;
using System.ComponentModel;

namespace Medicine.Clinic.Client.Model
{
    public interface INewSpecimenModel
    {
        string EditSpecimen(string code, string name, string defaultTubeCode, bool isEdit);
        BindingList<DtoTube> LoadDefaultTubes();
    }
}
