namespace Codere.SGBOnlineGames.CasinoFeed.Domain.ViewModels
{
    #region Using

    using Domain.Entities;
    using System.Collections.Generic;

    #endregion

    public class JackpotViewModel
    {
        public JackpotDto Jackpot { get; set; }
        public List<GameDto> Games { get; set; }
    }
}
