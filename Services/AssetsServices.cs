using AutoMapper;
using AutoMapper.QueryableExtensions;
using MobileFront.Models;
using MobileFront.Models.DTOs;
using MobileFront.Services.ApiServices;
using System.Net.Http.Json;
using System.Text.Json;

namespace MobileFront.Services
{
    class AssetsServices : IAssetsServices
    {
        //private readonly IMapper _mapper;
        private readonly IAssetApiClient _assetsServices;

        public AssetsServices(/*IMapper mapper*/IAssetApiClient assetsServices)
        {
            _assetsServices = assetsServices;
            //_mapper = mapper;
        }
        public async Task<List<AssetDTO>> GetAssetsAsync()
        {
            try
            {
                return await _assetsServices.GetAssetsAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return await GetAssetOffLineAsync();
            }
            return null;
        }
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
