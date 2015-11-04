using System.ComponentModel;
using Medicine.Clinic.Client.Model.GridControlsEntities;
using DtoTest1 = Medicine.Clinic.Client.Model.TestService.DtoTest;
using DtoSpecimen1 = Medicine.Clinic.Client.Model.SpecimenService.DtoSpecimen;
using DtoTube1 = Medicine.Clinic.Client.Model.TubeService.DtoTube;
using DtoIndication1 = Medicine.Clinic.Client.Model.IndicationService.DtoIndication;

namespace Medicine.Clinic.Client.Model
{
    public interface INewOrderModel
    {
        BindingList<TestForGrid> SearchConcreteTests(string number);
        BindingList<SpecimenForGrid> SearchConcreteSpecimens(string number, BindingList<TubeForGrid> tubeGrids);
        BindingList<TubeForGrid> SearchConcreteTubes(string number);
        BindingList<IndicationForGrid> SearchConcreteIndications(string number);
        BindingList<DtoTest1> SearchAllowedTestsByVisit(string billingNumber);
        BindingList<DtoSpecimen1> SearchSpecimens();
        BindingList<DtoTube1> SearchTubes();
        BindingList<DtoIndication1> SearchIndications();
        string LoadDefaultEntities(string code, BindingList<TestForGrid> testGrids, BindingList<SpecimenForGrid> specimenGrids, BindingList<TubeForGrid> tubeGrids);
        string GetOrderNamber();
        string EditOrder(string number, string clinicalInfo, string billingNumber);
        BindingList<TestForGrid> LoadTestsToCheckBox(BindingList<TestForGrid> testsFromGrid);
        BindingList<TubeForGrid> LoadTubesToCheckBox(BindingList<TubeForGrid> tubesFromGrid);
        BindingList<TubeForGrid> AddConcreteTube(BindingList<TubeForGrid> tubeGrids, string orderNumber);
        BindingList<SpecimenForGrid> AddConcreteSpecimen(BindingList<SpecimenForGrid> specimenGrids, string orderNumber);
        BindingList<TestForGrid> AddConcreteTest(BindingList<TestForGrid> testGrids, string orderNumber);
        BindingList<IndicationForGrid> AddConcreteIndication(BindingList<IndicationForGrid> indicationGrids, string orderNumber);
        void AddTestTubeAttch(BindingList<TubeForGrid> tubeGrids, BindingList<TestForGrid> testGrids);
        void AddSpecimenTubeAttch(BindingList<SpecimenForGrid> specimenGrids, BindingList<TubeForGrid> tubeGrids);
        string CheckForConstrains(BindingList<SpecimenForGrid> specimenGrids, BindingList<TubeForGrid> tubeGrids, BindingList<TestForGrid> testGrids, BindingList<IndicationForGrid> indicationGrids);
        //string LoadIndications(string code, BindingList<IndicationForGrid> indicationGrids);
        BindingList<TubeForGrid> DeleteCheckedTests(BindingList<TubeForGrid> tubeGrids, string deletedTestCode);
        BindingList<SpecimenForGrid> DeleteCheckedTubes(BindingList<SpecimenForGrid> specimenGrids, string deletedTubeCode);
        string IsDodExis(string billingNumber);
    }
}
