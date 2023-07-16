using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using UnitOfWork.Models;

namespace UnitOfWork.Services
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> Get();
        TEntity GetById(int Id);
        void Add(TEntity data);

        void Save();
    }

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private PresupuestoContext _presupuestoContext;
        private DbSet<TEntity> _dbSet;

        public Repository(PresupuestoContext presupuestoContext)
        {
            _presupuestoContext = presupuestoContext;
            _dbSet = _presupuestoContext.Set<TEntity>();
        }

        public void Add(TEntity data) => _dbSet.Add(data);

        public IEnumerable<TEntity> Get() => _dbSet.ToList();

        public TEntity GetById(int Id) => _dbSet.Find(Id);

        public void Save() => _presupuestoContext.SaveChangesAsync();
    }
}
