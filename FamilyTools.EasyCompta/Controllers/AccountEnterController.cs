using FamilyTools.EasyCompta.IBusiness;
using FamilyTools.EasyCompta.Models;

using Microsoft.AspNetCore.Mvc;

namespace FamilyTools.EasyCompta.Controllers
{
    [ApiController]
    [Route("easycompta/[controller]")]
    public class AccountEnterController(IAccountEnterBusiness business, ILogger<AccountEnterController> logger) : ControllerBase
    {
        private readonly ILogger<AccountEnterController> logger = logger;
        private readonly IAccountEnterBusiness business = business;

        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            try
            {
                return this.Ok(await this.business.Find(id));
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message);
                return this.BadRequest();
            }
        }

        [Route("[action]")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Lines,Tag,Name,LifeTime")] AccountEnter accountEnter)
        {
            try
            {
                return this.Ok(await this.business.Create(accountEnter));
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message);
                return this.BadRequest();
            }
        }

        [Route("[action]")]
        [HttpPost]
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Lines,Tag,Name,LifeTime")] AccountEnter accountEnter)
        {
            try
            {
                return this.Ok(await this.business.Update(accountEnter));
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message);
                return this.BadRequest();
            }
        }

        [Route("[action]/{id}")]
        [HttpGet]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return this.Ok(await this.business.Delete(id));
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message);
                return this.BadRequest();
            }
        }
    }
}
