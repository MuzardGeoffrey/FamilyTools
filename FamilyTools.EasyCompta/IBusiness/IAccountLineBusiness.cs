using FamilyTools.EasyCompta.Models;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FamilyTools.EasyCompta.IBusiness
{
    public interface IAccountLineBusiness : IBaseBusiness<AccountLine>
    {
        Task<Dictionary<int, int>> ExpensesByUserForAYear(int year);
    }
}
