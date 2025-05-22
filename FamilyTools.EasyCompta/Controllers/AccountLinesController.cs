using Microsoft.AspNetCore.Mvc;
using FamilyTools.EasyCompta.IBusiness;
using FamilyTools.EasyCompta.Models;

namespace FamilyTools.EasyCompta.Controllers
{
    [ApiController]
    [Route("easycompta/[controller]")]
    public class AccountLinesController(IAccountLineBusiness business, ILogger<AccountLinesController> logger) : Controller
    {
        private readonly IAccountLineBusiness business = business;
        private readonly ILogger<AccountLinesController> logger = logger;

        [Route("[action]")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Value")] AccountLine accountLine)
        {
            try
            {
                return this.Ok(await this.business.Create(accountLine));
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
        public async Task<IActionResult> Edit([Bind("Id,Name,Value")] AccountLine accountLine)
        {
            try
            {
                return this.Ok(await this.business.Update(accountLine));
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message);
                return this.BadRequest();
            }
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
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
