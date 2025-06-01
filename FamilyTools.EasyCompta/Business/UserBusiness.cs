using System.Linq;

using FamilyTools.EasyCompta.DataBase.Context;
using FamilyTools.EasyCompta.IBusiness;
using FamilyTools.EasyCompta.Models;

using Microsoft.EntityFrameworkCore;

namespace FamilyTools.EasyCompta.Business
{
    public class UserBusiness(AccountContext context) : BaseBusiness<User>(context), IUserBusiness
    {
        public async Task<List<User>> UserList()
        {
		    List<User> users = await this._context.Users.ToListAsync() ?? [];

            return users;
        }
    }
}
