using FamilyTools.EasyCompta.DataBase.Context;
using FamilyTools.EasyCompta.IBusiness;
using FamilyTools.EasyCompta.Models;

using Microsoft.EntityFrameworkCore;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FamilyTools.EasyCompta.Business
{
    public class AccountLineBusiness(AccountContext context) : BaseBusiness<AccountLine>(context), IAccountLineBusiness
    {
        public async Task<Dictionary<int, int>> ExpensesByUserForAYear(int year)
        {
            if (year != default)
            {
                await this._context.AccountLines.Where(data => data.Enter.Date.Year == year)
                    .GroupBy(data => data.UserId)
                    .Select(group => new
                    {
                        group.Key,
                        sum = group.Sum(value => value.Value)
                    })
                    .ToDictionaryAsync(group => group.Key, group => group.sum);
            }

            return [];
        }
    }
}
