using MobileFront.Models;
using System.Collections.ObjectModel;

namespace MobileFront.Services
{
    public interface IAssetsServices
    {
        Task<List<Asset>> GetAssetsAsync();
    }
}
