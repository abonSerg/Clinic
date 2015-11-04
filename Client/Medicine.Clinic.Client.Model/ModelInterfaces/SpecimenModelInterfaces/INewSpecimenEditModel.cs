using Medicine.Clinic.Client.Model.TubeService;
using System.ComponentModel;

namespace Medicine.Clinic.Client.Model
{
    public interface INewSpecimenEditModel
    {
        BindingList<DtoTube> LoadDefaultTubes();
        string EditSpecimen(string code, string name, string defaultTubeCode, bool isEdit);
    }
}
