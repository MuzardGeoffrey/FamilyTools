using EasyCompta.Server.IBusiness;
using EasyCompta.Server.Model;

using Microsoft.AspNetCore.Mvc;

namespace FamilyTools.EasyCompta.Controllers
{

    [ApiController]
    [Route("easycompta/[controller]")]
    public class AccountPageController(IAccountPageBusiness business, ILogger<AccountPageController> logger) : ControllerBase
    {

        private readonly IAccountPageBusiness _business = business;
        private readonly ILogger<AccountPageController> _logger = logger;

        [Route("")]
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                return this.Ok(await _business.GetPageByDate(DateTime.Now));
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return this.BadRequest();
            }
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> Get(DateTime date)
        {
            try
            {
                return this.Ok(await _business.GetPageByDate(date));
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return this.BadRequest();
            }
        }
    }
}
