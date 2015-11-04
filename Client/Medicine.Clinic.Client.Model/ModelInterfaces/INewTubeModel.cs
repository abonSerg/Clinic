using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISD.Clinic.Client.Model
{
    public interface INewTubeModel
    {
        void AddTube(string code, string name, int volume);
    }
}
