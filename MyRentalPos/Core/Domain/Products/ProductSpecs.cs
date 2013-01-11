using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyRentalPos.Core.Domain.Products
{
    public class ProductSpecs : BaseEntity
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public string SpecType { get; set; }
        public string SpecName { get; set; }
    }
}