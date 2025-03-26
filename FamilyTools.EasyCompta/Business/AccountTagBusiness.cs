using EasyCompta.Server.Data;
using EasyCompta.Server.IBusiness;
using EasyCompta.Server.Model;

namespace EasyCompta.Server.Business
{
    public class AccountTagBusiness(AccountContext context) : BaseBusiness<AccountTag>(context), IAccountTagBusiness
    {
    }
}
