using SuperZapatos.Models.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SuperZapatos.WebApp.Models
{
    public class ArticleStore
    {
        public string Description { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
        [Display(Name = "Total In Shelf")]
        public int TotalInShelf { get; set; }
        [Display(Name = "Total In Vault")]
        public int TotalInVault { get; set; }

        public Store Store { get; set; }

        public ArticleStore(Article article, Store store)
        {
            this.Id = article.Id;
            this.Name = article.Name;
            this.Price = article.Price;
            this.Description = article.Description;
            this.TotalInShelf = article.Total_In_Shelf;

            this.TotalInVault = article.Total_In_Vault;

            this.Store = store;
        }
    }
}
