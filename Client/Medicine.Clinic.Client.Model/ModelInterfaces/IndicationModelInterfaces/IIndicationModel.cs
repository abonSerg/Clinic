using Medicine.Clinic.Client.Model.IndicationService;
using System.ComponentModel;

namespace Medicine.Clinic.Client.Model
{
    public interface IIndicationModel
    {
        BindingList<DtoIndication> SearchIndications(string code, string name);
    }
}
