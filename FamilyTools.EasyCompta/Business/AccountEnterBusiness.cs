﻿using FamilyTools.Data.Context;
using FamilyTools.Data.Models.EasyCompta;
using FamilyTools.EasyCompta.IBusiness;

using Microsoft.EntityFrameworkCore;

namespace FamilyTools.EasyCompta.Business
{
    public class AccountEnterBusiness(EasyComptaContext context, IAccountLineBusiness lineBusiness) : BaseBusiness<AccountEnter>(context), IAccountEnterBusiness
    {
        private readonly IAccountLineBusiness _lineBusiness = lineBusiness;
        private AccountEnter AccountEnter = new();

        public override async Task<AccountEnter> Create(AccountEnter accountEnter)
        {
            if(accountEnter == default)
            {
                return new ();
            }
            accountEnter.Id = default;

            this.AccountEnter = accountEnter;
            CalculTotalValue();
            this.AccountEnter.CreationDate = DateTime.Now;
            this.AccountEnter = _context.AccountEnters.Add(this.AccountEnter).Entity;

            await _context.SaveChangesAsync();

            return this.AccountEnter;
        }

        public override async Task<AccountEnter> Update(AccountEnter accountEnter)
        {
            if (accountEnter == default)
            {
                return new AccountEnter();
            }

            if (_context.AccountEnters.Any(enter => this.AccountEnter.Id == enter.Id))
            {
                this.AccountEnter = accountEnter;
                CalculTotalValue();
                this.AccountEnter.UpdateDate = DateTime.Now;
                this.AccountEnter = _context.AccountEnters.Update(accountEnter).Entity;
                await _context.SaveChangesAsync();

                return AccountEnter;
            }

            return new();
            
        }

        public async Task<List<AccountEnter>> CreateList(ICollection<AccountEnter> list)
        {
            List<AccountEnter> newEnters = [];

            if (list == default) return newEnters;

            foreach (var accountEnter in list)
            {
                if (accountEnter != default 
                    && !await this._context.AccountEnters
                    .AnyAsync(a => a.Name == accountEnter.Name && a.TotalValue == accountEnter.TotalValue && a.Date == accountEnter.Date)
                    )
                {
                    accountEnter.Id = default;
                    this.AccountEnter = accountEnter;
                    CalculTotalValue();
                    this.AccountEnter.CreationDate = DateTime.Now;
                    newEnters.Add(this._context.AccountEnters.Add(this.AccountEnter).Entity);
                }
            }
            
            await _context.SaveChangesAsync();

            await GenerateLine(newEnters);
            
            return newEnters;
        }

        public async Task<Dictionary<int, int>> ExpensesByTagForAMonth(int month, int year)
        {
            if (month >= 1 && month <= 12)
            {
                await this._context.AccountEnters.Where(data => data.Date.Month == month && data.Date.Year == year)
                    .GroupBy(data => data.Tag.Id)
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

            foreach (AccountLine line in this.AccountEnter.Lines)
            {
                totalValue = +line.Value;
            }

            this.AccountEnter.TotalValue = totalValue;
        }

        private async Task GenerateLine(List<AccountEnter> enters)
        {
            var Lines = new List<AccountLine>();
            foreach (var enter in enters)
            {
                foreach (var line in enter.Lines)
                {
                    line.Enter = enter;
                }
                Lines.AddRange(enter.Lines);
            }
            await this._lineBusiness.CreateList(Lines);
        }


    }
}
