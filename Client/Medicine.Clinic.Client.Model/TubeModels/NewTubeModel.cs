using System.ComponentModel;
using Medicine.Clinic.Client.Model.TubeService;


namespace Medicine.Clinic.Client.Model
{
    public class NewTubeModel : INewTubeModel, INewTubeEditModel, INotifyPropertyChanged
    {      
        public event PropertyChangedEventHandler PropertyChanged;

        private string code;
        private string name;
        private string volume;
        private bool okEnabling = true;

        public string Code
        {
            get { return code; }
            set
            {
                if (code != value)
                {
                    code = value;
                    OnPropertyChanged("Code");
                }
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Volume
        {
            get { return volume; }
            set
            {
                if (volume != value)
                {
                    volume = value;
                    OnPropertyChanged("Volume");
                }
            }
        }

        public bool OkEnabling
        {
            get { return okEnabling; }
            set
            {
                if (okEnabling != value)
                {
                    okEnabling = value;
                    OnPropertyChanged("OkEnabling");
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

