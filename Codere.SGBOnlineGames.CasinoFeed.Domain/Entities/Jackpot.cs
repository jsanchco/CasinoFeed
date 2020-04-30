namespace Codere.SGBOnlineGames.CasinoFeed.Domain.Entities
{
    #region Using

    using System.Collections.Generic;

    #endregion

    public class Jackpot
    {
        public string jackpotId { get; set; }
        public string jackpotName { get; set; }
        public string jackpotDescription { get; set; }
        public string potId { get; set; }
        public double currentAmount { get; set; }
        public List<Game> games { get; set; }
    }
}
