using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserService
    {
        List<User> GetList();
        void AddUser(User user);
        void UserUpdate(User user);
        void UserDelete(User user);
        User GetById(int id);
    }
}
