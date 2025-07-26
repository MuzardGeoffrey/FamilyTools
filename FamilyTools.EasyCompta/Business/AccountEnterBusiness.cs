using FamilyTools.EasyCompta.DataBase.Context;
using FamilyTools.EasyCompta.IBusiness;
using FamilyTools.EasyCompta.Models;

using Microsoft.EntityFrameworkCore;

namespace FamilyTools.EasyCompta.Business
{
    public class AccountEnterBusiness(AccountContext context) : BaseBusiness<AccountEnter>(context), IAccountEnterBusiness
    {
        
        private AccountEnter AccountEnter = new();

        public override async Task<AccountEnter> Create(AccountEnter accountEnter)
        {
            if(accountEnter == default)
            {
                return new ();
            }
            accountEnter.Id = default;

            AccountEnter = accountEnter;
            CalculTotalValue();
            AccountEnter.CreationDate = DateTime.Now;
            AccountEnter = _context.AccountEnters.Add(AccountEnter).Entity;

            await _context.SaveChangesAsync();

            return AccountEnter;
        }

        public override async Task<AccountEnter> Update(AccountEnter accountEnter)
        {
            if (accountEnter == default)
            {
                return new AccountEnter();
            }

            if (_context.AccountEnters.Any(enter => AccountEnter.Id == enter.Id))
            {
                AccountEnter = accountEnter;
                CalculTotalValue();
                AccountEnter.UpdateDate = DateTime.Now;
                AccountEnter = _context.AccountEnters.Update(accountEnter).Entity;
                await _context.SaveChangesAsync();

                return AccountEnter;
            }

            return new();
            
        }

        public async Task<Dictionary<int, int>> ExpensesByTagForAMonth(int month, int year)
        {
            if (month >= 1 && month <= 12)
            {
                await this._context.AccountEnters.Where(data => data.Date.Month == month && data.Date.Year == year)
                    .GroupBy(data => data.TagId)
                    .Select(data => new
                    {
                        data.Key,
                        sum = data.Sum(value => value.TotalValue)
                    })
                    .ToDictionaryAsync(group => group.Key, group => group.sum);
            }

            return [];
        }

        private void CalculTotalValue()
        {
            float totalValue = 0;

            foreach (AccountLine line in AccountEnter.Lines)
            {
                totalValue = +line.Value;
            }

            AccountEnter.TotalValue = totalValue;
        }


    }
}
