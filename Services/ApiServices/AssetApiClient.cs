using AutoMapper;
using AutoMapper.QueryableExtensions;
using MobileFront.Models;
using MobileFront.Models.DTOs;
using System.Net.Http.Json;

namespace MobileFront.Services.ApiServices
{
    /// <summary>
    /// API client for accessing asset data
    /// </summary>
    public class AssetApiClient : IAssetApiClient
    {
        private HttpClient client;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializs a new instance of the <see cref="AssetApiClient"/> class.
        /// </summary>
        /// <param name="mapper">The mapper instance</param>
        public AssetApiClient(IMapper mapper)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://10.0.2.2:44386/api/Assets");
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves a list of assets async
        /// </summary>
        /// <returns>The list of asset DTOs</returns>
        public async Task<List<AssetDTO>> GetAssetsAsync()
        {
            try
            {
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
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw new Exception();
            }
            return null;
        }
    }
}
