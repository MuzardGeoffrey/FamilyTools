using FamilyTools.EasyCompta.IBusiness;

using Microsoft.AspNetCore.Mvc;

namespace FamilyTools.EasyCompta.Controllers
{

    [ApiController]
    [Route("easycompta/[controller]")]
    public class AccountPageController(IAccountPageBusiness business, ILogger<AccountPageController> logger) : ControllerBase
    {

        private readonly IAccountPageBusiness business = business;
        private readonly ILogger<AccountPageController> logger = logger;

        [Route("")]
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                return this.Ok(await this.business.GetPageByDate(DateTime.Now));
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message);
                return this.BadRequest();
            }
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> Get(DateTime date)
        {
            try
            {
                return this.Ok(await this.business.GetPageByDate(date));
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message);
                return this.BadRequest();
            }
        }
    }
}
