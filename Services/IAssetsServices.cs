using MobileFront.Models;

namespace MobileFront.Services
{
    public interface IAssetsServices
    {
        Task<List<Asset>> SeeList();
    }
}
