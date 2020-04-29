namespace Codere.SGBOnlineGames.CasinoFeed.Domain.Entities
{
    #region Using

    using System.ComponentModel.DataAnnotations;

    #endregion

    public class LicenseOrderDto
    {
        public int LicenseType { get; set; }
        public int LicenseOrder { get; set; }
    }
}
