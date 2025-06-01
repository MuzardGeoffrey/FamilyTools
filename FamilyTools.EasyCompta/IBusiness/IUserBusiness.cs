using FamilyTools.EasyCompta.Models;

namespace FamilyTools.EasyCompta.IBusiness
{
    public interface IUserBusiness : IBaseBusiness<User>
    {
        Task<List<User>> UserList();
    }
}