using System.Threading.Tasks;

namespace UWP_Ocean.Model
{
    public interface IDataService
    {
        Task<DataItem> GetData();
    }
}