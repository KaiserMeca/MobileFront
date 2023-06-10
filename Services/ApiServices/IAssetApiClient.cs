
using MobileFront.Models.DTOs;

namespace MobileFront.Services.ApiServices
{
    public interface IAssetApiClient
    {
        Task<List<AssetDTO>> GetAssetsAsync();
    }
}
