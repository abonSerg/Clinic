using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDataSetAccess
{
    public static class ClinicSetTables
    {
        public static ClinicDataSet ClinicDataSet
        {
            
            get
            {
                return new ClinicDataSet();
            }
        }
    }
}
