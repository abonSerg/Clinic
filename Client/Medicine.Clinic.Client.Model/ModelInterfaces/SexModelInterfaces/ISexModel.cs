using Medicine.Clinic.Client.Model.SexService;
using System.ComponentModel;

namespace Medicine.Clinic.Client.Model
{
    public interface ISexModel
    {
        BindingList<DtoSex> SearchSexes(string code, string name);
    }
}
