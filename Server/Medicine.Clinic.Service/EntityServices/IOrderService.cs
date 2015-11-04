using System.ServiceModel;

namespace Medicine.Clinic.Service
{
    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]
        string EditOrder(DtoOrder dtoOrder);
        [OperationContract]
        DtoOrder[] FindOrders(DtoOrder dtoOrder);
        [OperationContract]
        string GetOrderNumber();
        [OperationContract]
        DtoOrder[] GetOrdersByVisit(string billingNumber);
        [OperationContract]
        DtoConcreteTest[] FindConcreteTestsByOrder(string number);
        [OperationContract]
        DtoConcreteSpecimen[] FindConcreteSpecimensByOrder(string number);
        [OperationContract]
        DtoConcreteTube[] FindConcreteTubesByOrder(string number);
        [OperationContract]
        DtoConcreteIndication[] FindConcreteIndicationsByOrder(string number);
        [OperationContract]
        string AddTestSexAllowed(DtoTestSexAllowed dtoTestSexAllowed);
        [OperationContract]
        DtoTestSexAllowed[] SearchTestSexAllowedsByTest(string testCode);
        [OperationContract]
        string DeleteTestSexAllowed(DtoTestSexAllowed dtoTestSexAllowed);
        [OperationContract]
        string AddConcreteTest(DtoConcreteTest dtoConcreteTest);
        [OperationContract]
        string AddConcreteTube(DtoConcreteTube dtoConcreteTube);
        [OperationContract]
        string AddConcreteSpecimen(DtoConcreteSpecimen dtoConcreteSpecimen);
        [OperationContract]
        void AddTestTubeAttach(DtoTestTubeAttach dtoTestTubeAttach);
        [OperationContract]
        void AddSpecimenTubeAttach(DtoSpecimenTubeAttach dtoSpecimenTubeAttach);
        [OperationContract]
        DtoConcreteTest GetConcreteTestByCode(string code);
        [OperationContract]
        DtoConcreteSpecimen GetConcreteSpecimenByCode(string code);
        [OperationContract]
        DtoConcreteTube GetConcreteTubeByCode(string code);
        [OperationContract]
        string AddConcreteIndication(DtoConcreteIndication dtoConcreteIndication);
        [OperationContract]
        string GetTestTubeAttachesStringByTube(string concreteTubeCode);
        [OperationContract]
        DtoSpecimenTubeAttach[] GetSpecimenTubeAttachesBySpecimen(string concreteSpecimenCode);
        [OperationContract]
        bool EditConcreteTest(DtoConcreteTest dtoConcreteTest);
        [OperationContract]
        bool EditConcreteTube(DtoConcreteTube dtoConcreteTube);
        [OperationContract]
        bool EditConcreteSpecimen(DtoConcreteSpecimen dtoConcreteSpecimen);
        [OperationContract]
        bool EditConcreteIndication(DtoConcreteIndication dtoConcreteIndication);
        [OperationContract]
        void DeleteTestTubeAttach(string orderNumber);
        [OperationContract]
        void DeleteSpecimenTubeAttach(string orderNumber);
        [OperationContract]
        void DeleteConcreteTest(string code);
        [OperationContract]
        void DeleteConcreteSpecimen(string code);
        [OperationContract]
        void DeleteConcreteTube(string code);
        [OperationContract]
        void DeleteConcreteIndication(string code);
        
    }
}
