using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ProductProperty
    {
        [Key]
        public int ProductProdpertyId { get; set; }
        public int ProductId { get; set; }
        public int PropertyId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Property Property { get; set; }
    }
}
