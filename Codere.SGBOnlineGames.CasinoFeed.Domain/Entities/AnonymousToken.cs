namespace Codere.SGBOnlineGames.CasinoFeed.Domain.Entities
{
    #region Using

    using System;

    #endregion

    public class AnonymousToken
    {
        public Meta meta { get; set; }
        public Data data { get; set; }
    }

    public class Meta
    {
        public string eventId { get; set; }
        public DateTime eventArrivalTime { get; set; }
        public string userId { get; set; }
        public string sessionId { get; set; }
    }

    public class Data
    {
        public string fbJWT { get; set; }
        public string userJWT { get; set; }
    }
}
