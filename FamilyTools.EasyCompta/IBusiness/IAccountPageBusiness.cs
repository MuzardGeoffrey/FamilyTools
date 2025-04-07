using FamilyTools.EasyCompta.Model;

namespace FamilyTools.EasyCompta.IBusiness
{
    public interface IAccountPageBusiness : IBaseBusiness<AccountPage>
    {
        public Task<AccountPage> GetPageByDate(DateTime date);
    }
}
