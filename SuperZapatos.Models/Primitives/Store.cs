using System.ComponentModel.DataAnnotations;

namespace SuperZapatos.Models.Primitives
{
    public class Store
    {
        public int Id { get; set; }
        [Display(Name = "Store")]
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
