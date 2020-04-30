namespace Codere.SGBOnlineGames.CasinoFeed.Controllers
{
    #region Using

    using Domain.Services;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;

    #endregion

    public class JackpotsController : ApiController
    {
        private readonly IServiceJackpot _serviceJackpot;

        public JackpotsController(IServiceJackpot serviceJackpot)
        {
            _serviceJackpot = serviceJackpot ??
                throw new ArgumentNullException(nameof(serviceJackpot));
        }

        // GET: api/Jackpots
        [HttpGet]
        [Route("GetJackpotsWithGames")]
        public async Task<IHttpActionResult> GetJackpotsWithGames()
        {
            try
            {
                var result = await _serviceJackpot.GetJackpotsWithGames();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(System.Net.HttpStatusCode.InternalServerError, ex.Message));
            }
        }
    }
}
