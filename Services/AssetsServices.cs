using MobileFront.Models;
using System.Collections.ObjectModel;
using System.Net.Http.Json;

namespace MobileFront.Services
{
    class AssetsServices : IAssetsServices
    {
        public async Task<List<Asset>> GetAssetsAsync()
        {
            var client = new HttpClient();
            string url = "http://10.0.2.2:44386/api/Assets";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                var assets = await response.Content.ReadFromJsonAsync<List<Asset>>();
                return assets;
            }
            else
            {
                return null;
            }
        }
    }
}
