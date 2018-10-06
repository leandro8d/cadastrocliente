using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
   public abstract class RepositoryBase<TEntity> where TEntity : class
    {
        protected CadastroUsuarioContext context;
        public RepositoryBase() {
            context = CadastroUsuarioContext.GetSingleton();
        }
        

        public TEntity Get(long id) {
            return context.Set<TEntity>().Find(id);
        }

        public IList<TEntity> ListAll()
        {
          
            return context.Set<TEntity>().ToList();
        }

        public void Delete(TEntity entity) {
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }

        public void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            context.SaveChanges();
        }
    }
}
