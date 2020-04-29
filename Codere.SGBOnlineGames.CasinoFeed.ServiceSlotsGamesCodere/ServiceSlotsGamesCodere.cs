namespace Codere.SGBOnlineGames.CasinoFeed.ServiceSlotsGamesCodere
{   
    #region Using

    using Domain.Entities;
    using Domain.Services;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Helpers;
    using Newtonsoft.Json;
    using System.Net;
    using Codere.SGBOnlineGames.CasinoFeed.Domain.ViewModels;
    using System.Linq;

    #endregion

    public class ServiceSlotsGamesCodere : IServiceSlotsGames
    {
        public async Task<List<GameDto>> GetSlotsGames()
        {
            var httpClient = GetClientHttp();
            var httpResponseMessage = await httpClient.GetAsync(Constants.ApiSlotsGames);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var content = await httpResponseMessage.Content.ReadAsStringAsync();
                var games = JsonConvert.DeserializeObject<List<GameDto>>(content);
                return games;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(httpResponseMessage.ToString());
                return null;
            }
        }

        public async Task<List<JackpotDto>> GetJackpots()
        {
            var httpClient = GetClientHttp();
            var httpResponseMessage = await httpClient.GetAsync(Constants.ApiJackpots);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var content = await httpResponseMessage.Content.ReadAsStringAsync();
                var jackpots = JsonConvert.DeserializeObject<List<JackpotDto>>(content);
                return jackpots;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(httpResponseMessage.ToString());
                return null;
            }
        }

        public async Task<List<JackpotViewModel>> GetAll()
        {
            var httpClient = GetClientHttp();
            var httpResponseMessage = await httpClient.GetAsync(Constants.ApiJackpots);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var content = await httpResponseMessage.Content.ReadAsStringAsync();
                var jackpots = JsonConvert.DeserializeObject<List<JackpotDto>>(content);
                if (!jackpots.Any())
                    return null;

                List<JackpotViewModel> result;
                httpResponseMessage = await httpClient.GetAsync(Constants.ApiSlotsGames);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    content = await httpResponseMessage.Content.ReadAsStringAsync();
                    var slotsGames = JsonConvert.DeserializeObject<List<GameDto>>(content);

                    result = FillJackpot(jackpots, slotsGames);
                    return result;
                }

                result = FillJackpot(jackpots, null);
                return result;
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

        private List<JackpotViewModel> FillJackpot(List<JackpotDto> listJackpotDto, List<GameDto> listGameDto)
        {
            var result = new List<JackpotViewModel>();

            var listJackpotDtoGroupByName = listJackpotDto.GroupBy(x => x.Name).Select(x => x.Key).ToList();
            foreach(var item in listJackpotDtoGroupByName)
            {
                var itemsInListJackpotDto = listJackpotDto.Where(x => x.Name == item);
                var jackpotViewModel = new JackpotViewModel
                {
                    Jackpot = new JackpotDto
                    {
                        Name = item
                    },
                    Games = new List<GameDto>()
                };

                foreach(var itemInListJackpotDto in itemsInListJackpotDto)
                {
                    if (listGameDto == null)
                        continue;

                    var findInListGameDto = listGameDto.FirstOrDefault(x => x.GameId == itemInListJackpotDto.GameId);
                    if (findInListGameDto != null)
                        jackpotViewModel.Games.Add(findInListGameDto);
                }
                result.Add(jackpotViewModel);
            }

            return result;
        }
    }
}
