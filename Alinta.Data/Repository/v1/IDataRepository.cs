using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alinta.Data.Repository.v1
{
    public interface IDataRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int Id);
        T GetByName(string name);
        T AddCustomer(T entity);
        T UpdateCustomer(T entity);
        T DeleteCustomer(int Id);
    }
}
