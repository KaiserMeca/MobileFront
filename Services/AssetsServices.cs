using MobileFront.Models.DTOs;
using MobileFront.Services.ApiServices;
using MobileFront.ViewModels;
using System.Text.Json;

namespace MobileFront.Services
{
    /// <summary>
    /// Service class for asset operations
    /// </summary>
    class AssetsServices : IAssetsServices 
    {
        private readonly IAssetApiClient _assetsServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetsServices"/> class
        /// </summary>
        /// <param name="assetsServices">The asset API client</param>
        public AssetsServices(IAssetApiClient assetsServices)
        {
            _assetsServices = assetsServices;
        }

        /// <summary>
        /// Retrieves a list of assets asyn
        /// </summary>
        /// <returns>The list of asset DTOs</returns>
        public async Task<List<AssetDTO>> GetAssetsAsync()
        {
            try
            {
                Title = "Assets list";
                return await _assetsServices.GetAssetsAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return await GetAssetOffLineAsync();
            }
        }

        /// <summary>
        /// Retrieves a list of assets from offline storage async
        /// </summary>
        /// <returns>The list of asset DTOs</returns>
        public async Task<List<AssetDTO>> GetAssetOffLineAsync()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("DataOffLine.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            var assetDTOs = JsonSerializer.Deserialize<List<AssetDTO>>(contents);
            return assetDTOs;
        }
    }
}
