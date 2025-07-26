using FamilyTools.EasyCompta.Models;

namespace FamilyTools.EasyCompta.IBusiness
{
    public interface IAccountEnterBusiness : IBaseBusiness<AccountEnter>
    {
        Task<Dictionary<int, int>> ExpensesByTagForAMonth(int month, int year);
    }
}
