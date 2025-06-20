using FamilyTools.EasyCompta.DataBase.Context;
using FamilyTools.EasyCompta.IBusiness;
using FamilyTools.EasyCompta.Models;

namespace FamilyTools.EasyCompta.Business
{
    public class BaseBusiness<T>(AccountContext context) : IBaseBusiness<T> where T : BaseModel
    {
        protected readonly AccountContext _context = context;

        public virtual async Task<T> Create(T t)
        {
            if (t != null)
            {
                t.CreationDate = DateTime.Now;
                this._context.Add(t);
                await _context.SaveChangesAsync();
                return await this.Find(t) ?? default;
            }
            return default;
        }

        public virtual async Task<bool> Delete(int id)
        {
            if (id != default)
            {
                T? t = await this.Find(id);
                if (t != null)
                {
                    this._context.Remove(t);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }

        public virtual async Task<T?> Find(T t)
        {
            if (t != null)
            {
                return (T?)await this._context.FindAsync(typeof(T), t.Id);
            }
            return default;
        }

        public virtual async Task<T?> Find(int id)
        {
            if (id != default)
            {
                return (T?)await this._context.FindAsync(typeof(T), id);
            }
            return default;
        }

        public virtual async Task<T> Update(T t)
        {
            if (t != null)
            {
                var checkT = await Find(t);

                if (checkT != null)
                {
                    t.UpdateDate = DateTime.Now;
                    this._context.Update(t);
                    await this._context.SaveChangesAsync();
                    return await this.Find(t) ?? default;
                }
            }
            return default;
        }
    }
}
