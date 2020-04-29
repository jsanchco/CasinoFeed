namespace Codere.SGBOnlineGames.CasinoFeed.Domain.Services
{
    #region Using

    using System.Threading.Tasks;
    using Codere.SGBOnlineGames.CasinoFeed.Domain.Entities;
    using System.Collections.Generic;
    using Codere.SGBOnlineGames.CasinoFeed.Domain.ViewModels;

    #endregion

    public interface IServiceSlotsGames
    {
        Task<List<JackpotDto>> GetJackpots();
        Task<List<GameDto>> GetSlotsGames();
        Task<List<JackpotViewModel>> GetAll();
    }
}
