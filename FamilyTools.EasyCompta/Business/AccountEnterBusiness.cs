using FamilyTools.EasyCompta.DataBase.Context;
using FamilyTools.EasyCompta.IBusiness;
using FamilyTools.EasyCompta.Models;

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
