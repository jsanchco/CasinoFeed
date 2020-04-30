namespace Codere.SGBOnlineGames.CasinoFeed.ServiceJackpotCodere
{
    #region Using

    using Domain.Entities;
    using Domain.Services;
    using Codere.SGBOnlineGames.CasinoFeed.ServiceJackpotCodere.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    #endregion

    public class ServiceJackpotCodere : IServiceJackpot
    {
        public async Task<List<Jackpot>> GetJackpotsWithGames()
        {
            var httpClient = GetClientHttp();
            var httpResponseMessage = await httpClient.GetAsync(Constants.ApiGetJackpotsWithGames);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var content = await httpResponseMessage.Content.ReadAsStringAsync();
                var jackpots = JsonConvert.DeserializeObject<List<Jackpot>>(content);
                return jackpots;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(httpResponseMessage.ToString());
                return null;
            }
        }

        private async Task<AnonymousToken> GetAnonymousToken()
        {
            var httpClient = GetClientHttp();
            var httpResponseMessage = await httpClient.GetAsync(Constants.ApiGetAnonymousToken);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var content = await httpResponseMessage.Content.ReadAsStringAsync();
                var anonymousToken = JsonConvert.DeserializeObject<AnonymousToken>(content);
                return anonymousToken;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(httpResponseMessage.ToString());
                return null;
            }
        }

        private HttpClient GetClientHttp()
        {
            var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri(Constants.Uri);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            return httpClient;
        }
    }
}
