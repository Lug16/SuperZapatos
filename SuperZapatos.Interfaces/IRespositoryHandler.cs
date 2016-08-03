using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperZapatos.RepositoryHandler
{
    public interface IRespositoryHandler<T> where T : class
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        IEnumerable<T> List();
        T GetById(int id);
    }
}
