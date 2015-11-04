using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISD.Clinic.Client.Model.TubeService;




namespace ISD.Clinic.Client.Model
{
    public class NewTubeEditModel : INewTubeEditModel
    {
        public bool EditTube(string id, string code, string name, string volume)
        {
            DtoTube dtoTube = new DtoTube() 
            {
                Id = int.Parse(id),
                Code = code,
                Name = name,
                Volume = int.Parse(volume)
                
            };
            return new TubeServiceClient().EditTube(dtoTube);
            
           
        }
    }
}
