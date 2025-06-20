using FamilyTools.EasyCompta.DataBase.Context;
using FamilyTools.EasyCompta.IBusiness;
using FamilyTools.EasyCompta.Models;

using Microsoft.EntityFrameworkCore;

namespace FamilyTools.EasyCompta.Business
{
    public class AccountTagBusiness(AccountContext context) : BaseBusiness<AccountTag>(context), IAccountTagBusiness
    {
        public async Task<List<AccountTag>> TagList()
        {
            return await this._context.AccountTags.ToListAsync() ?? [];
        }
    }
}
