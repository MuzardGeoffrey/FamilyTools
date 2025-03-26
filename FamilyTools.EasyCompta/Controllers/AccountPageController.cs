using EasyCompta.Server.IBusiness;
using EasyCompta.Server.IModel;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FamilyTools.EasyCompta.Controllers
{

    [ApiController]
    [Route("easycompta/[controller]")]
    public class AccountPageController : ControllerBase
    {

        private readonly IAccountPageBusiness business;

        public AccountPageController(IAccountPageBusiness business)
        {
            this.business = business;
        }

        [Route("")]
        [Route("Index")]
        [HttpGet]
        public async Task<ActionResult<IAccountPage>> Index()
        {
            var result = await business.GetPageByDate(DateTime.Now);
            return result;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult<IAccountPage>> Get(DateTime date)
        {
            var result = await business.GetPageByDate(date);
            return result;
        }
    }
}
