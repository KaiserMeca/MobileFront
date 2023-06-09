using AutoMapper;
using AutoMapper.QueryableExtensions;
using MobileFront.Models;
using MobileFront.Models.DTOs;
using System.Net.Http.Json;
using System.Text.Json;

namespace MobileFront.Services
{
    class AssetsServices : IAssetsServices
    {
        private readonly IMapper _mapper;

        public AssetsServices(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<List<AssetDTO>> GetAssetsAsync()
        {
            try
            {
                var client = new HttpClient();
                string url = "http://10.0.2.2:44386/api/Assets";
                client.BaseAddress = new Uri(url);

                var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
                var requestTask = client.GetAsync("", cancellationTokenSource.Token);
                var timeoutTask = Task.Delay(TimeSpan.FromSeconds(10));

                var completedTask = await Task.WhenAny(requestTask, timeoutTask);

                if (completedTask == requestTask)
                {
                    HttpResponseMessage response = await requestTask;

                    if (response.IsSuccessStatusCode)
                    {
                        var assets = await response.Content.ReadFromJsonAsync<List<Asset>>();

                        if (assets != null)
                        {
                            List<AssetDTO> assetDTOs = assets.AsQueryable().ProjectTo<AssetDTO>(_mapper.ConfigurationProvider).ToList();
                            return assetDTOs;
                        }
                    }
                }
                else
                {
                    // Aquí puedes manejar la situación cuando ha pasado más de 10 segundos sin respuesta
                }

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
