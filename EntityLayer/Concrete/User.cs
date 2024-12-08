using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Surname { get; set; }
        [StringLength(200)]
        public string Username { get; set; }
        public string HashPassword { get; set; }
        public string SaltPassword { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
