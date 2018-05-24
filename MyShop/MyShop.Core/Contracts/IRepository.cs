using System.Linq;
using MyShop.Core.Models;

namespace MyShop.Core.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Commit();
        void Update(T item);
        T Find(string ID);
        IQueryable<T> Collection();
        void Insert(T item);
        void Delete(string ID);
    }
}