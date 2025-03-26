using EasyCompta.Server.Data;
using EasyCompta.Server.IBusiness;
using EasyCompta.Server.Model;

using Microsoft.EntityFrameworkCore;

namespace EasyCompta.Server.Business
{
    public class AccountPageBusiness(AccountContext context) : BaseBusiness<AccountPage>(context), IAccountPageBusiness
    {
        private readonly AccountContext _context = context;

        public async Task<AccountPage> GetPageByDate(DateTime date) {
            if (date != default)
            {
                return await this._context.AccountPages.Where(page => page.Date.Month == date.Month && page.Date.Year == date.Year).FirstOrDefaultAsync();
            }
            return default;
        }
    }
}
