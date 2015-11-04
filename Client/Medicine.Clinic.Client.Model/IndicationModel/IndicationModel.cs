using System.ComponentModel;
using Medicine.Clinic.Client.Model.IndicationService;

namespace Medicine.Clinic.Client.Model
{
   public  class IndicationModel : IIndicationModel
    {
       public BindingList<DtoIndication> SearchIndications(string code, string name)
       {
           var dtoIndication = new DtoIndication()
           {
               Code = code,
               Name = name
           };
           return new BindingList<DtoIndication>(new IndicationServiceClient().FindIndications(dtoIndication));
       }
            
   }
    
}
