using clean_code_refactor.Domain.Bases;
using Microsoft.EntityFrameworkCore;

namespace clean_code_refactor.Dal.Repositories.Base
{
    //Esta classe não pode ser abstrata, para que o AddScoped funcione
    public class BaseRepository<T> : IBaseRepository<T> where T : Identificador
    {
        protected readonly DbContext Db;
        protected readonly DbSet<T> DbSet;
        public BaseRepository(AppDbContext context)
        {
            Db = context;
            DbSet = Db.Set<T>();
        }

        public async Task<IList<T>> ObterTodosAsync() => await DbSet.AsNoTracking().ToListAsync();

        public async Task<T?> ObterPorIdAsync(int id) => await DbSet.FirstOrDefaultAsync(c => c.Id == id);
        public T? ObterPorId(int id) => DbSet.Find(id);

        public async Task<T> AdicionarAsync(T entity)
        {
            await DbSet.AddAsync(entity);
            await Db.SaveChangesAsync();

            return entity;
        }

        public async Task AtualizarAsync(T entity)
        {
            DbSet.Update(entity);
            await Db.SaveChangesAsync();
        }

        public async Task RemoverAsync(T entity)
        {
            DbSet.Remove(entity);
            await Db.SaveChangesAsync();
        }
    }
}
