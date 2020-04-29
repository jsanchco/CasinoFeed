namespace Codere.SGBOnlineGames.CasinoFeed.Domain.Entities
{
    #region Using

    using System.ComponentModel.DataAnnotations;

    #endregion

    public class LicenseOrder
    {
        [Display(Name = "LicenseType")]
        public int Type { get; set; }

        [Display(Name = "LicenseOrder")]
        public int Order { get; set; }
    }
}
