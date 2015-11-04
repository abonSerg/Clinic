using System.ComponentModel;
using Medicine.Clinic.Client.Model.TubeService;

namespace Medicine.Clinic.Client.Model
{
    public class TubeModel : ITubeModel, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private string searchCode;
        private string searchName;

        public string SearchCode
        {
            get { return searchCode; }
            set
            {
                if (searchCode != value)
                {
                    searchCode = value;
                    OnPropertyChanged("SearchCode");
                }
            }
        }

        public string SearchName
        {
            get { return searchName; }
            set
            {
                if (searchName != value)
                {
                    searchName = value;
                    OnPropertyChanged("SearchName");
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
