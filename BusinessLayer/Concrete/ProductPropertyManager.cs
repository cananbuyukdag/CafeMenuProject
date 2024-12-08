using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductPropertyManager : IProductPropertyService
    {
        IProductPropertyDal _productPropertyDal;

        public ProductPropertyManager(IProductPropertyDal productPropertyDal)
        {
            _productPropertyDal = productPropertyDal;
        }
        public void Delete(ProductProperty entity)
        {
            _productPropertyDal.Delete(entity);
        }

        public ProductProperty GetById(int id)
        {
            return _productPropertyDal.GetById(x => x.ProductProdpertyId == id);
        }

        public List<ProductProperty> GetList()
        {
            return _productPropertyDal.List();
        }

        public void ProductPropertyAdd(ProductProperty entity)
        {
            _productPropertyDal.Add(entity);
        }

        public void Update(ProductProperty entity)
        {
            _productPropertyDal.Update(entity);
        }
    }
}
