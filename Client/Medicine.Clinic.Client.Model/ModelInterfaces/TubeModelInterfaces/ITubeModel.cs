using Medicine.Clinic.Client.Model.TubeService;
using System.ComponentModel;


namespace Medicine.Clinic.Client.Model
{
    public interface ITubeModel
    {
        string SearchName { get; set; }
        string SearchCode { get; set; }
    }
}
