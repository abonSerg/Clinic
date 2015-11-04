using Medicine.Clinic.Client.Model;

namespace Medicine.Clinic.Client.Presentation
{
    public class MainPresenter 
    {
        readonly IMainView mainView = null;
        readonly IMainModel mainModel = null;

        public MainPresenter(IMainView mainView)
        {
            this.mainView = mainView;
            this.mainModel = new MainModel();
        }

        public void Run()
        {
            mainView.Show();
        }


    }
}
