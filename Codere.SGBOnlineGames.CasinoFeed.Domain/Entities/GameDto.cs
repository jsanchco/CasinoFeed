namespace Codere.SGBOnlineGames.CasinoFeed.Domain.Entities
{
    #region Using

    using System;
    using System.Collections.Generic;

    #endregion

    public class GameDto
    {
        public string Name { get; set; }   
        public Guid GameId { get; set; }
        public Guid ProviderId { get; set; }
        public string ProviderGameID { get; set; }
        public string DemoUrl { get; set; }
        public string DemoMobileUrl { get; set; }
        public string PlayUrl { get; set; }
        public string GameType { get; set; }
        public List<int> LicenseType { get; set; }
        public List<LicenseOrderDto> LicensesOrder { get; set; }
        public int Order { get; set; }
        public bool Jackpot { get; set; }
        public bool HasDemo { get; set; }
        public string Description { get; set; }
        public string Client { get; set; }
    }
}
