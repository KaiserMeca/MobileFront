using MobileFront.Models;
using MobileFront.Models.DTOs;
using System.Collections.ObjectModel;

namespace MobileFront.Services
{
    public interface IAssetsServices
    {
        Task<List<AssetDTO>> GetAssetsAsync();
        Task<List<AssetDTO>> GetAssetOffLineAsync();
    }
}
