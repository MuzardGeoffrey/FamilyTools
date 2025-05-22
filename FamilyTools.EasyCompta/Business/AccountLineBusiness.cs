using FamilyTools.EasyCompta.DataBase.Context;
using FamilyTools.EasyCompta.IBusiness;
using FamilyTools.EasyCompta.Models;

namespace FamilyTools.EasyCompta.Business
{
    public class AccountLineBusiness(AccountContext context) : BaseBusiness<AccountLine>(context), IAccountLineBusiness
    {
    }
}
