using Medicine.Clinic.Client.Model.VisitService;
using System.Data;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Medicine.Clinic.Client.Model.OrderService;
using System.ComponentModel;
using Medicine.Clinic.Client.Model.TestService;
using DtoOrder = Medicine.Clinic.Client.Model.OrderService.DtoOrder;
using DtoConcreteTest = Medicine.Clinic.Client.Model.TestService.DtoConcreteTest;
using ClinicDataSetAccess;
using Medicine.Clinic.Client.Model.GridControlsEntities;

namespace Medicine.Clinic.Client.Model
{
    public class BillingModel : IBillingModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string searchBillingNumber;
        private string totalCost;

        public string SearchBillingNumber
        {
            get { return searchBillingNumber; }
            set
            {
                if (searchBillingNumber != value)
                {
                    searchBillingNumber = value;
                    OnPropertyChanged("SearchBillingNumber");
                }
            }
        }

        public string TotalCost
        {
            get { return totalCost; }
            set
            {
                if (totalCost != value)
                {
                    totalCost = value;
                    OnPropertyChanged("TotalCost");
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
