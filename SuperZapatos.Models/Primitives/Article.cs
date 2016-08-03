using System.ComponentModel.DataAnnotations;

namespace SuperZapatos.Models.Primitives
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        [Display(Name = "Total In Shelf")]
        public int Total_In_Shelf { get; set; }
        [Display(Name = "Total In Vault")]
        public int Total_In_Vault { get; set; }

        [Display(Name = "Store")]
        public int StoreId { get; set; }

    }
}
