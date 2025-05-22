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
                _context.Add(t);
                await _context.SaveChangesAsync();
                return await Find(t);
            }
            return default;
        }

        public virtual async Task<bool> Delete(int id)
        {
            if (id != null)
            {
                _context.Remove(id);
                var count = await _context.SaveChangesAsync();
                if (count > 0) { 
                    return true;
                }
            }
            return false;
        }

        public virtual async Task<T> Find(T t)
        {
            if (t != null)
            {
                return (T)await _context.FindAsync(typeof(T), t);
            }
            return default;
        }

        public virtual async Task<T> Find(int id)
        {
            if (id != null)
            {
                return (T)await _context.FindAsync(typeof(T), id);
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
                    _context.Update(t);
                    await _context.SaveChangesAsync();
                    return await Find(t);
                }
            }
            return default;
        }

        public async ValueTask DisposeAsync()
        {
            await DisposeAsync();
            GC.SuppressFinalize(this);
        }
    }
}
