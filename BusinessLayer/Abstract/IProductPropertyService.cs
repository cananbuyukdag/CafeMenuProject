using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProductPropertyService
    {
        List<ProductProperty> GetList();
        void ProductPropertyAdd(ProductProperty entity);
        ProductProperty GetById(int id);
        void Delete(ProductProperty entity);
        void Update(ProductProperty entity);
    }
}
