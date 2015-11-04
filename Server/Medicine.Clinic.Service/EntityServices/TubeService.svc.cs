using System.Linq;
using Medicine.Clinic.DataAccess;

namespace Medicine.Clinic.Service
{
    public class TubeService : ITubeService
    {
        public string EditTube(DtoTube dtoTube)
        {
            var uniqeTube = TubeMethods.Instance.GetTubeByCode(dtoTube.Code);
            if (!dtoTube.IsEdit)
            {
                var tube = new Tube()
                {
                    Code = dtoTube.Code,
                    Name = dtoTube.Name,
                    Volume = dtoTube.Volume
                };
                return TubeMethods.Instance.InsertTube(tube);
            }
            else
            {
                var tube = new Tube()
                {
                    Id = TubeMethods.Instance.GetTubeByCode(dtoTube.Code).Id,
                    Code = dtoTube.Code,
                    Name = dtoTube.Name,
                    Volume = dtoTube.Volume
                };
                return TubeMethods.Instance.UpdateTube(tube);
            }
        }

        public DtoTube[] FindTubes(DtoTube dtoTube)
        {
            string code = dtoTube.Code;
            string name = dtoTube.Name;
            int volume = dtoTube.Volume;
            Tube[] tubes=TubeMethods.Instance.GetTubes(code, name);
            DtoTube[] dtoTubes = tubes.Select(tube => new DtoTube()
                                      {   
                                          Id=tube.Id,
                                          Code = tube.Code,
                                          Name = tube.Name,
                                          Volume = tube.Volume
                                      }).ToArray();           
             return dtoTubes;                                           
        }

        public DtoTube GetTubeByCode(string code)
        {
            Tube tube = TubeMethods.Instance.GetTubeByCode(code);
            var dtoTube = new DtoTube()
            {
                Id = tube.Id,
                Name = tube.Name,
                Code = tube.Code,
                Volume = tube.Volume
            };
            return dtoTube;
        }
    }
}
