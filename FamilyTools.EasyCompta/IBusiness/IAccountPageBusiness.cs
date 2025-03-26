using EasyCompta.Server.Model;

namespace EasyCompta.Server.IBusiness
{
    public interface IAccountPageBusiness : IBaseBusiness<AccountPage>
    {
        public Task<AccountPage> GetPageByDate(DateTime date);
    }
}
