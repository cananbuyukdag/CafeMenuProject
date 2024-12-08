using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Property
    {
        [Key]
        public int PropertyId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public ICollection<ProductProperty> ProductProperties { get; set; }
    }
}
