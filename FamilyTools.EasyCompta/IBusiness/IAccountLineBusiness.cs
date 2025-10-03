﻿using FamilyTools.Data.Models.EasyCompta;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FamilyTools.EasyCompta.IBusiness
{
    public interface IAccountLineBusiness : IBaseBusiness<AccountLine>
    {
        Task CreateList(List<AccountLine> lines);
        Task<Dictionary<int, int>> ExpensesByUserForAYear(int year);
    }
}
