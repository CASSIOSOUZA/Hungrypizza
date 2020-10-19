using HungryPizza.Repositorio.Context;
using HungryPizza.Servico.Interfaces.Repositories;

namespace HungryPizza.Repositorio.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected SQLContext Ctx;

        public BaseRepository(SQLContext ctx)
        {
            this.Ctx = ctx;
        }
    }
}