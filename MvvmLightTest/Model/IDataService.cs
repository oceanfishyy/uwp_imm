using System.Threading.Tasks;

namespace MvvmLightTest.Model
{
    public interface IDataService
    {
        Task<DataItem> GetData();
    }
}