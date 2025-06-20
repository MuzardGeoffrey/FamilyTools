
using FamilyTools.EasyCompta.Models;

namespace FamilyTools.EasyCompta.IBusiness
{
    public interface IAccountTagBusiness : IBaseBusiness<AccountTag>
    {
        Task<List<AccountTag>> TagList();
    }
}
