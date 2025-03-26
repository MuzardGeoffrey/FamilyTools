using EasyCompta.Server.Data;
using EasyCompta.Server.IBusiness;
using EasyCompta.Server.Model;

namespace EasyCompta.Server.Business
{
    public class UserBusiness(AccountContext context) : BaseBusiness<User>(context), IUserBusiness
    {
    }
}
