namespace Codere.SGBOnlineGames.CasinoFeed.Domain.Entities
{
    #region Using

    using System;
    using System.ComponentModel.DataAnnotations;


    #endregion

    public class JackpotDto
    {
        public Guid GameId { get; set; }
        public string Name { get; set; }
        public string Provider { get; set; }
        public string Jackpot { get; set; }
        public string Step { get; set; }
    }
}
