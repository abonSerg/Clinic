using System;
using Medicine.Clinic.Client.Model;

namespace Medicine.Clinic.Client.Presentation
{
    public class DoctorPresenter
    {
        readonly IDoctorView doctorView;
        readonly IDoctorModel doctorModel;

        public DoctorPresenter(IDoctorView doctorView)
        {
            this.doctorView = doctorView;
            doctorModel = new DoctorModel();
            doctorView.SearchClick += LoadSearchResultGrid;
            doctorView.ClearClick += LoadAllDoctorGrids;
            doctorView.LoadForm += LoadAllDoctorGrids;
        }

        void LoadSearchResultGrid(object sender, EventArgs e)
        {
            doctorView.DoctorViewGridControlData = doctorModel.SearchDoctors(doctorView.DoctorViewSearchCode, 
                                                                                       doctorView.DoctorViewSearchFirstName,
                                                                                       doctorView.DoctorViewSearchLastName);
        }

        void LoadAllDoctorGrids(object sender, EventArgs e)
        {
            doctorView.DoctorViewGridControlData = doctorModel.SearchDoctors(string.Empty, string.Empty, string.Empty);
        }
    }
}
