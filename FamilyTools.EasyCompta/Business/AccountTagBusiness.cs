using FamilyTools.EasyCompta.DataBase.Context;
using FamilyTools.EasyCompta.IBusiness;
using FamilyTools.EasyCompta.Model;

namespace FamilyTools.EasyCompta.Business
{
    public class AccountTagBusiness(AccountContext context) : BaseBusiness<AccountTag>(context), IAccountTagBusiness
    {
    }
}
