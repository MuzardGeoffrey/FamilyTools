using EasyCompta.Server.Data;
using EasyCompta.Server.IBusiness;
using EasyCompta.Server.Model;

using Microsoft.EntityFrameworkCore;

namespace EasyCompta.Server.Business
{
    public class BaseBusiness<T>(AccountContext context) : IBaseBusiness<T>
    {
        private readonly AccountContext _context = context;

        public async Task<T> Create(T t)
        {
            if (t != null)
            {
                this._context.Add(t);
                await this._context.SaveChangesAsync();
                return await this.Find(t);
            }
            return default;
        }

        public async Task<bool> Delete(int id)
        {
            if (id != null)
            {
                this._context.Remove(id);
                var count = await this._context.SaveChangesAsync();
                if (count > 0) { 
                    return true;
                }
            }
            return false;
        }

        public async Task<T> Find(T t)
        {
            if (t != null)
            {
                return (T)await this._context.FindAsync(typeof(T), t);
            }
            return default;
        }

        public async Task<T> Find(int id)
        {
            if (id != null)
            {
                return (T)await this._context.FindAsync(typeof(T), id);
            }
            return default;
        }

        public async Task<T> Update(T t)
        {
            if (t != null)
            {
                var checkT = await this.Find(t);

                if (checkT != null)
                {
                    this._context.Update(t);
                    await this._context.SaveChangesAsync();
                    return await this.Find(t);
                }
            }
            return default;
        }
    }
}
