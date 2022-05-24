using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFOS.DataAccessLayer.Abstractions
{
    public interface ICalisanRepository<Type> where Type : class
    {
        Type insert(Type entity);
        void deleteOrder(int id);
        Type update(int id, Type updated);

    }
}
