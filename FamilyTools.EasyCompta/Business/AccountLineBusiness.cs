using EasyCompta.Server.Data;
using EasyCompta.Server.IBusiness;
using EasyCompta.Server.Model;

namespace EasyCompta.Server.Business
{
    public class AccountLineBusiness(AccountContext context) : BaseBusiness<AccountLine>(context), IAccountLineBusiness
    {
    }
}
