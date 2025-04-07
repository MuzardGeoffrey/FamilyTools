using FamilyTools.EasyCompta.DataBase.Context;
using FamilyTools.EasyCompta.IBusiness;
using FamilyTools.EasyCompta.Model;

using Microsoft.EntityFrameworkCore;

namespace FamilyTools.EasyCompta.Business
{
    public class AccountPageBusiness(AccountContext context) : BaseBusiness<AccountPage>(context), IAccountPageBusiness
    {
        private readonly AccountContext context = context;

        public async Task<AccountPage> GetPageByDate(DateTime date) {
            if (date != default)
            {
                return await this.context.AccountPages.Where(page => page.Date.Month == date.Month && page.Date.Year == date.Year).FirstOrDefaultAsync();
            }
            return default;
        }
    }
}
