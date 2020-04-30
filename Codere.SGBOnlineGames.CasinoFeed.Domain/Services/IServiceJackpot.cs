namespace Codere.SGBOnlineGames.CasinoFeed.Domain.Services
{
    #region Using

    using Codere.SGBOnlineGames.CasinoFeed.Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    #endregion

    public interface IServiceJackpot
    {
        Task<List<Jackpot>> GetJackpotsWithGames();
    }
}
