using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFOS.DataAccessLayer.Abstractions
{
    public interface IAdminrepository<Type> where Type : class
    {
        Type insert(Type Entity);
        IList<Type> findAll();
        Type selectById(int id);
        void DeleteOrder(int id);
    }
}
