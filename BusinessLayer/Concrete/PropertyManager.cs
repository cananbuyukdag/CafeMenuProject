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
    public class PropertyManager : IPropertyService
    {

        IPropertyDal _propertyDal;

        public PropertyManager(IPropertyDal propertyDal)
        {
            _propertyDal = propertyDal;
        }

        
        public void Delete(Property entity)
        {
            _propertyDal.Delete(entity);
        }

        public Property GetById(int id)
        {
            return _propertyDal.GetById(x => x.PropertyId == id);
        }

        public List<Property> GetList()
        {
            return _propertyDal.List();
        }

        public void PropertyAdd(Property entity)
        {
            _propertyDal.Add(entity);
        }

        public void Update(Property entity)
        {
            _propertyDal.Update(entity);
        }
    }
}
