using SuperZapatos.Models.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperZapatos.RepositoryHandler
{
    public class StoreHandler : IRespositoryHandler<Store>
    {
        public void Delete(int id)
        {
            using (var context = new DataAccess.SuperZapatosContext())
            {
                var store = context.Stores.Where(r => r.Id == id).FirstOrDefault();

                context.Stores.Remove(store);

                context.SaveChanges();
            }
        }

        public Store GetById(int id)
        {
            using (var context = new DataAccess.SuperZapatosContext())
            {
                var store = context.Stores.Where(r => r.Id == id).FirstOrDefault();

                return new Store { Id = store.Id, Address = store.Address, Name = store.Name };
            }
        }

        public void Insert(Store entity)
        {
            using (var context = new DataAccess.SuperZapatosContext())
            {
                var store = new DataAccess.Store() { Address = entity.Address, Id = entity.Id, Name = entity.Name };
                context.Stores.Add(store);
                context.SaveChanges();
            }
        }

        public IEnumerable<Store> List()
        {
            using (var context = new DataAccess.SuperZapatosContext())
            {
                var stores = context.Stores;

                var array = stores.ToArray();

                return stores.ToArray().Select(r => new Store() { Address = r.Address, Id = r.Id, Name = r.Name });
            }
        }

        public void Update(Store entity)
        {
            using (var context = new DataAccess.SuperZapatosContext())
            {
                var store = context.Stores.Where(r => r.Id == entity.Id).FirstOrDefault();

                store.Address = entity.Address;
                store.Name = entity.Name;

                context.SaveChanges();
            }
        }
    }
}
