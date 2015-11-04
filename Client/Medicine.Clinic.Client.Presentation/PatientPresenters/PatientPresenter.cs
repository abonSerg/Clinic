using System;
using Medicine.Clinic.Client.Model;

namespace Medicine.Clinic.Client.Presentation
{
    public class PatientPresenter
    {
        readonly IPatientView patientView;
        readonly IPatientModel patientModel;

        public PatientPresenter(IPatientView patientView)
        {
            this.patientView = patientView;
            patientModel = new PatientModel();
            patientView.SearchClick += LoadSearchResultGrid;
            patientView.ClearClick += LoadAllPatientGrids;
            patientView.LoadForm += LoadAllPatientGrids;
        }

        void LoadSearchResultGrid(object sender, EventArgs e)
        {
            patientView.PatientViewGridControlData = patientModel.SearchPatients(patientView.PatientViewSearchMrn,
                                                                                 patientView.PatientViewSearchSsn,
                                                                                 patientView.PatientViewSearchFirstName,
                                                                                 patientView.PatientViewSearchLastName,
                                                                                 patientView.PatientViewSearchMiddleName);
        }

        void LoadAllPatientGrids(object sender, EventArgs e)
        {
            patientView.PatientViewGridControlData = patientModel.SearchPatients(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
        }
    }
}
