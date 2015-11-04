using System.ComponentModel;
using Medicine.Clinic.Client.Model.SexService;

namespace Medicine.Clinic.Client.Model
{
    public class SexModel: ISexModel
    {
        public BindingList<DtoSex> SearchSexes(string code, string name)
        {
            var dtoSex = new DtoSex()
            {
                Code = code,
                Name = name
            };
            return new BindingList<DtoSex>(new SexServiceClient().FindSexes(dtoSex));
        }
    }
}
