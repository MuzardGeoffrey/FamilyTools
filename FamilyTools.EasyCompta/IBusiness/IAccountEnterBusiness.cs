using FamilyTools.Data.Models.EasyCompta;

namespace FamilyTools.EasyCompta.IBusiness
{
    public interface IAccountEnterBusiness : IBaseBusiness<AccountEnter>
    {
        Task<List<AccountEnter>> CreateList(ICollection<AccountEnter> list);
        Task<Dictionary<int, int>> ExpensesByTagForAMonth(int month, int year);
    }
}
