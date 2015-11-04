using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medicine.Clinic.DataAccess
{
    public interface ICodedEntity
    {
        string Code { get; set; }
    }
}
