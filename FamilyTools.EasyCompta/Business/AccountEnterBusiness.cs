using EasyCompta.Server.Data;
using EasyCompta.Server.IBusiness;
using EasyCompta.Server.Model;

namespace EasyCompta.Server.Business
{
    public class AccountEnterBusiness(AccountContext context) : BaseBusiness<AccountEnter>(context), IAccountEnterBusiness
    {
    }
}
