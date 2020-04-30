namespace Codere.SGBOnlineGames.CasinoFeed.Controllers
{
    #region Using

    using Domain.Services;
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;

    #endregion

    [Route("api/[controller]")]
    public class GamesController : ApiController
    {
        private readonly IServiceSlotsGames _serviceSlotsGames;

        public GamesController(IServiceSlotsGames serviceSlotsGames)
        {
            _serviceSlotsGames = serviceSlotsGames ??
                throw new ArgumentNullException(nameof(serviceSlotsGames));
        }

        // GET: api/Events
        [HttpGet]
        [Route("GetJackpots")]
        public async Task<IHttpActionResult> GetJackpots()
        {
            try
            {
                var result = await _serviceSlotsGames.GetJackpots();
                return Ok(result);
            }
            catch(Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(System.Net.HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [HttpGet]
        [Route("GetSlotsGames")]
        public async Task<IHttpActionResult> GetSlotsGames()
        {
            try
            {
                var result = await _serviceSlotsGames.GetSlotsGames();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(System.Net.HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IHttpActionResult> GetAll()
        {
            try
            {
                var result = await _serviceSlotsGames.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(System.Net.HttpStatusCode.InternalServerError, ex.Message));
            }
        }
    }
}
