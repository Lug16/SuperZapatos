using SuperZapatos.Models.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperZapatos.RepositoryHandler
{
    public class ArticleHandler : IRespositoryHandler<Article>
    {
        public void Delete(int id)
        {
            using (var context = new DataAccess.SuperZapatosContext())
            {
                var article = context.Articles.Where(r => r.Id == id).FirstOrDefault();

                context.Articles.Remove(article);

                context.SaveChanges();
            }
        }

        public Article GetById(int id)
        {
            using (var context = new DataAccess.SuperZapatosContext())
            {
                var entity = context.Articles.Where(r => r.Id == id).FirstOrDefault();

                var article = new Article
                {
                    Description = entity.Description,
                    Id = entity.Id,
                    Name = entity.Name,
                    Price = entity.Price,
                    StoreId = entity.StoreId,
                    Total_In_Shelf = entity.Total_In_Shelf,
                    Total_In_Vault = entity.Total_In_Vault
                };

                return article;
            }
        }

        public void Insert(Article article)
        {
            using (var context = new DataAccess.SuperZapatosContext())
            {
                var entity = new DataAccess.Article
                {
                    Description = article.Description,
                    Name = article.Name,
                    Price = article.Price,
                    StoreId = article.StoreId,
                    Total_In_Shelf = article.Total_In_Shelf,
                    Total_In_Vault = article.Total_In_Vault
                };

                context.Articles.Add(entity);
                context.SaveChanges();
            }
        }

        public IEnumerable<Article> List()
        {
            using (var context = new DataAccess.SuperZapatosContext())
            {
                var articles = context.Articles;

                return articles.ToArray().Select(
                        r => new Article
                        {
                            Description = r.Description,
                            Id = r.Id,
                            Name = r.Name,
                            Price = r.Price,
                            StoreId = r.StoreId,
                            Total_In_Shelf = r.Total_In_Shelf,
                            Total_In_Vault = r.Total_In_Vault
                        });
                    }
        }

        public IEnumerable<Article> ListByStore(int storeId)
        {
            using (var context = new DataAccess.SuperZapatosContext())
            {
                //context.Configuration.LazyLoadingEnabled = true;

                var store = context.Stores.Where(r => r.Id == storeId).Single();

                var articles = context.Articles.Where(r => r.StoreId == storeId);

                return articles.ToArray().Select(
                                            r => new Article
                                            {
                                                Description = r.Description,
                                                Id = r.Id,
                                                Name = r.Name,
                                                Price = r.Price,
                                                StoreId = r.StoreId,
                                                Total_In_Shelf = r.Total_In_Shelf,
                                                Total_In_Vault = r.Total_In_Vault
                                            }); 
            }
        }

        public void Update(Article article)
        {
            using (var context = new DataAccess.SuperZapatosContext())
            {
                var entity = context.Articles.Where(r => r.Id == article.Id).FirstOrDefault();

                entity.Description = article.Description;
                entity.Name = article.Name;
                entity.Price = article.Price;
                entity.StoreId = article.StoreId;
                entity.Total_In_Shelf = article.Total_In_Shelf;
                entity.Total_In_Vault = article.Total_In_Vault;


                context.SaveChanges();
            }
        }
    }
}
