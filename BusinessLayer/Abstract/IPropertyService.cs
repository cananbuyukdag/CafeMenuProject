using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPropertyService
    {
        List<Property> GetList();
        void PropertyAdd(Property entity);
        Property GetById(int id);
        void Delete(Property entity);
        void Update(Property entity);
    }
}
